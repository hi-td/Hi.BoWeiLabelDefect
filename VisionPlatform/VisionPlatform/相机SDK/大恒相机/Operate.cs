using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using GxIAPINET;
using GxIAPINET.Sample.Common;
using VisionPlatform;

namespace GxMultiCam
{
    public class Operate
    {
        static CFps m_objCFps = new CFps();          ///<统计帧率的对象
        IGXDevice m_objIGXDevice = null;                ///<设备对像
        public IGXStream m_objIGXStream = null;                ///<流对像
        IGXFeatureControl m_objIGXFeatureControl = null;                ///远端设备属性控制器对像                            ///<图像显示类对象
        IGXFeatureControl m_objIGXStreamFeatureControl = null;                ///<流层属性控制器对象
        string m_strSN = "";                  ///<序列号
        bool m_bIsColor = false;               ///<是否支持彩色相机
        byte[] m_byMonoBuffer = null;                ///<黑白相机buffer
        byte[] m_byColorBuffer = null;                ///<彩色相机buffer       
        int m_nWidth = 0;                   ///<图像宽度
        int m_nHeigh = 0;                   ///<图像高度
        Bitmap m_bitmap = null;                ///<bitmap对象
        const uint PIXEL_FORMATE_BIT = 0x00FF0000;          ///<用于与当前的数据格式进行与运算得到当前的数据位数
        const uint GX_PIXEL_8BIT = 0x00080000;          ///<8位数据图像格式
        const int CP_NOCLOSE_BUTTON = 0x200;               ///<用于禁用窗体的关闭按钮
        Function m_tmFun = null;
        GxBitmap m_objGxBitmap = null;                ///<图像显示类对象              
        bool m_bIsTrigValid = true;                 // 触发是否有效标志:当一次触发正在执行时，将该标志置为false                                                                                  ///
        public Operate(IGXDevice objIGXDevice, Function fun)
        {
            m_objIGXDevice = objIGXDevice;
            //m_nOperateID = nOperateID + 1;
            m_tmFun = fun;
            Init();
            ////使用双缓冲，让图像显示不闪烁
            //System.Windows.Forms.Control.SetStyle(
            //         ControlStyles.OptimizedDoubleBuffer
            //         | ControlStyles.ResizeRedraw
            //         | ControlStyles.Selectable
            //         | ControlStyles.AllPaintingInWmPaint
            //         | ControlStyles.UserPaint
            //         | ControlStyles.SupportsTransparentBackColor,
            //         true);
        }

        /// <summary>
        /// 显示图像等过程的初始化操作
        /// </summary>
        void Init()
        {
            m_strSN = m_objIGXDevice.GetDeviceInfo().GetSN();
            string strValue = null;
            if (null != m_objIGXDevice)
            {
                m_nWidth = (int)m_objIGXDevice.GetRemoteFeatureControl().GetIntFeature("Width").GetValue();
                m_nHeigh = (int)m_objIGXDevice.GetRemoteFeatureControl().GetIntFeature("Height").GetValue();
                m_byMonoBuffer = new byte[m_nWidth * m_nHeigh];
                m_byColorBuffer = new byte[m_nWidth * m_nHeigh * 3];
                if (m_objIGXDevice.GetRemoteFeatureControl().IsImplemented("PixelColorFilter"))
                {
                    strValue = m_objIGXDevice.GetRemoteFeatureControl().GetEnumFeature("PixelColorFilter").GetValue();
                    if ("None" != strValue)
                    {
                        m_bIsColor = true;
                    }
                }
            }
            //if (null != m_pic_ShowImage)
            //{
            //    Bitmap bitmap = m_pic_ShowImage.Image as Bitmap;
            //    m_pic_ShowImage.Image = m_bitmap;
            //    if (bitmap != null)
            //    {
            //        bitmap.Dispose();
            //    }
            //}
        }

        /// <summary>
        ///禁用窗体的关闭按钮只是ControlBox=false，会连同最小化和最大化按钮都不显示，所以，如果你想
        ///只想让关闭按钮不起作用，然后保留最小化、最大化的话，就重写窗体的CreateParams方法：
        /// </summary>
        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        CreateParams objCP = base.CreateParams;
        //        objCP.ClassStyle = objCP.ClassStyle | CP_NOCLOSE_BUTTON;
        //        return objCP;
        //    }
        //}

        /// <summary>
        /// 单独设备的打开操作
        /// </summary>
        public void OpenDevice()
        {
            //打开流
            if (null != m_objIGXDevice)
            {
                m_objIGXStream = m_objIGXDevice.OpenStream(0);
                m_objIGXFeatureControl = m_objIGXDevice.GetRemoteFeatureControl();
                m_objIGXStreamFeatureControl = m_objIGXStream.GetFeatureControl();
                m_objGxBitmap = new GxBitmap(m_objIGXDevice, m_tmFun);

                // 建议用户在打开网络相机之后，根据当前网络环境设置相机的流通道包长值，
                // 以提高网络相机的采集性能,设置方法参考以下代码。
                GX_DEVICE_CLASS_LIST objDeviceClass = m_objIGXDevice.GetDeviceInfo().GetDeviceClass();
                if (GX_DEVICE_CLASS_LIST.GX_DEVICE_CLASS_GEV == objDeviceClass)
                {
                    // 判断设备是否支持流通道数据包功能
                    if (true == m_objIGXFeatureControl.IsImplemented("GevSCPSPacketSize"))
                    {
                        // 获取当前网络环境的最优包长值
                        uint nPacketSize = m_objIGXStream.GetOptimalPacketSize();
                        // 将最优包长值设置为当前设备的流通道包长值
                        m_objIGXFeatureControl.GetIntFeature("GevSCPSPacketSize").SetValue(nPacketSize);
                    }
                }
            }
        }

        /// <summary>
        /// 开始采集
        /// </summary>
        public void StartDevice()
        {
            if (null != m_objIGXStreamFeatureControl)
            {
                //设置流层Buffer处理模式为OldestFirst
                m_objIGXStreamFeatureControl.GetEnumFeature("StreamBufferHandlingMode").SetValue("OldestFirst");
            }

            //开启采集流通道
            if (null != m_objIGXStream)
            {
                //RegisterCaptureCallback第一个参数属于用户自定参数(类型必须为引用
                //类型)，若用户想用这个参数可以在委托函数中进行使用
                m_objIGXStream.RegisterCaptureCallback(this, __OnFrameCallbackFun);
                m_objIGXStream.StartGrab();
                //m_timer_UpdateFPS.Start();
            }
            //发送开采命令
            if (null != m_objIGXFeatureControl)
            {
                m_objIGXFeatureControl.GetCommandFeature("AcquisitionStart").Execute();
            }
        }

        /// <summary>
        /// 停止采集
        /// </summary>
        public void StopDevice()
        {
            //m_timer_UpdateFPS.Stop();
            //发送停采命令
            if (null != m_objIGXFeatureControl)
            {
                m_objIGXFeatureControl.GetCommandFeature("AcquisitionStop").Execute();
            }

            //关闭采集流通道
            if (null != m_objIGXStream)
            {
                m_objIGXStream.StopGrab();
                //注销采集回调函数
                m_objIGXStream.UnregisterCaptureCallback();
            }
        }

        //软触发拍照一次
        public void GrabImage()
        {

            try
            {
                // 如果当触发回调正在执行的过程中，再次点击触发按键后，此次点击会被屏蔽掉
                //if (!m_bIsTrigValid)
                //{
                //    return;
                //}
                //else
                //{
                //    m_bIsTrigValid = false;
                //}
                //发送软触发命令
                if (null != m_objIGXFeatureControl)
                {
                    m_objIGXFeatureControl.GetCommandFeature("TriggerSoftware").Execute();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
              //  m_bIsTrigValid = true;
            }

        }

        /// <summary>
        /// 关闭设备接口
        /// </summary>
        public void CloseDevice()
        {
            try
            {
                //m_timer_UpdateFPS.Stop(); //Timer
                // 如果未停采则先停止采集
                if (null != m_objIGXFeatureControl)
                {
                    m_objIGXFeatureControl.GetCommandFeature("AcquisitionStop").Execute();
                    m_objIGXFeatureControl = null;
                }
            }
            catch (Exception)
            {

            }
            try
            {
                //停止流通道、注销采集回调和关闭流
                if (null != m_objIGXStream)
                {
                    m_objIGXStream.StopGrab();
                    //注销采集回调函数
                    m_objIGXStream.UnregisterCaptureCallback();
                    m_objIGXStream.Close();
                    m_objIGXStream = null;
                    m_objIGXStreamFeatureControl = null;
                }
            }
            catch (Exception)
            {

            }

            try
            {
                //关闭设备
                if (null != m_objIGXDevice)
                {
                    m_objIGXDevice.Close();
                    m_objIGXDevice = null;
                    // this.Close();  //form窗体关闭
                }
            }
            catch (Exception)
            {

            }
        }

        /// <summary>
        /// 更新图像数据
        /// </summary>
        /// <param name="objIBaseData">图像数据对象</param>
        void __UpdateImageData(IBaseData objIBaseData)
        {
            try
            {
                GX_VALID_BIT_LIST emValidBits = GX_VALID_BIT_LIST.GX_BIT_0_7;
                if (null != objIBaseData)
                {
                    emValidBits = __GetBestValudBit(objIBaseData.GetPixelFormat());
                    if (GX_FRAME_STATUS_LIST.GX_FRAME_STATUS_SUCCESS == objIBaseData.GetStatus())
                    {
                        if (m_bIsColor)
                        {
                            IntPtr pBufferColor = objIBaseData.ConvertToRGB24(emValidBits, GX_BAYER_CONVERT_TYPE_LIST.GX_RAW2RGB_NEIGHBOUR, true);
                            Marshal.Copy(pBufferColor, m_byColorBuffer, 0, m_nWidth * m_nHeigh * 3);
                        }
                        else
                        {
                            IntPtr pBufferMono = IntPtr.Zero;
                            if (__IsPixelFormat8(objIBaseData.GetPixelFormat()))
                            {
                                pBufferMono = objIBaseData.GetBuffer();
                            }
                            else
                            {
                                pBufferMono = objIBaseData.ConvertToRaw8(emValidBits);
                            }
                            Marshal.Copy(pBufferMono, m_byMonoBuffer, 0, m_nWidth * m_nHeigh);
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// 回调函数,用于获取图像信息和显示图像
        /// </summary>
        /// <param name="obj">用户自定义传入参数</param>
        /// <param name="objIFrameData">图像信息对象</param>
        private void __OnFrameCallbackFun(object objUserParam, IFrameData objIFrameData)
        {
            try
            {
                lock (this)
                {
                    m_objCFps.IncreaseFrameNum();
                    __UpdateImageData(objIFrameData);
                    m_objGxBitmap.Show(objIFrameData);
                }
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// 更新界面的帧率显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public double UpdateFPS()
        {
            m_objCFps.UpdateFps();
            //string strSN = string.Format("序号:{0} SN:{1}", m_nOperateID.ToString(), m_strSN) + "  FPS:";
            double dFPS = m_objCFps.GetFps();
            ////this.Text = strText;
            return dFPS;
        }


        /// <summary>
        /// 判断PixelFormat是否为8位
        /// </summary>
        /// <param name="emPixelFormatEntry">图像数据格式</param>
        /// <returns>true为8为数据，false为非8位数据</returns>
        private bool __IsPixelFormat8(GX_PIXEL_FORMAT_ENTRY emPixelFormatEntry)
        {
            bool bIsPixelFormat8 = false;
            uint uiPixelFormatEntry = (uint)emPixelFormatEntry;
            if ((uiPixelFormatEntry & PIXEL_FORMATE_BIT) == GX_PIXEL_8BIT)
            {
                bIsPixelFormat8 = true;
            }
            return bIsPixelFormat8;
        }

        /// <summary>
        /// 通过GX_PIXEL_FORMAT_ENTRY获取最优Bit位
        /// </summary>
        /// <param name="em">图像数据格式</param>
        /// <returns>最优Bit位</returns>
        private GX_VALID_BIT_LIST __GetBestValudBit(GX_PIXEL_FORMAT_ENTRY emPixelFormatEntry)
        {
            GX_VALID_BIT_LIST emValidBits = GX_VALID_BIT_LIST.GX_BIT_0_7;
            switch (emPixelFormatEntry)
            {
                case GX_PIXEL_FORMAT_ENTRY.GX_PIXEL_FORMAT_MONO8:
                case GX_PIXEL_FORMAT_ENTRY.GX_PIXEL_FORMAT_BAYER_GR8:
                case GX_PIXEL_FORMAT_ENTRY.GX_PIXEL_FORMAT_BAYER_RG8:
                case GX_PIXEL_FORMAT_ENTRY.GX_PIXEL_FORMAT_BAYER_GB8:
                case GX_PIXEL_FORMAT_ENTRY.GX_PIXEL_FORMAT_BAYER_BG8:
                    {
                        emValidBits = GX_VALID_BIT_LIST.GX_BIT_0_7;
                        break;
                    }
                case GX_PIXEL_FORMAT_ENTRY.GX_PIXEL_FORMAT_MONO10:
                case GX_PIXEL_FORMAT_ENTRY.GX_PIXEL_FORMAT_BAYER_GR10:
                case GX_PIXEL_FORMAT_ENTRY.GX_PIXEL_FORMAT_BAYER_RG10:
                case GX_PIXEL_FORMAT_ENTRY.GX_PIXEL_FORMAT_BAYER_GB10:
                case GX_PIXEL_FORMAT_ENTRY.GX_PIXEL_FORMAT_BAYER_BG10:
                    {
                        emValidBits = GX_VALID_BIT_LIST.GX_BIT_2_9;
                        break;
                    }
                case GX_PIXEL_FORMAT_ENTRY.GX_PIXEL_FORMAT_MONO12:
                case GX_PIXEL_FORMAT_ENTRY.GX_PIXEL_FORMAT_BAYER_GR12:
                case GX_PIXEL_FORMAT_ENTRY.GX_PIXEL_FORMAT_BAYER_RG12:
                case GX_PIXEL_FORMAT_ENTRY.GX_PIXEL_FORMAT_BAYER_GB12:
                case GX_PIXEL_FORMAT_ENTRY.GX_PIXEL_FORMAT_BAYER_BG12:
                    {
                        emValidBits = GX_VALID_BIT_LIST.GX_BIT_4_11;
                        break;
                    }
                case GX_PIXEL_FORMAT_ENTRY.GX_PIXEL_FORMAT_MONO14:
                    {
                        //暂时没有这样的数据格式待升级
                        break;
                    }
                case GX_PIXEL_FORMAT_ENTRY.GX_PIXEL_FORMAT_MONO16:
                case GX_PIXEL_FORMAT_ENTRY.GX_PIXEL_FORMAT_BAYER_GR16:
                case GX_PIXEL_FORMAT_ENTRY.GX_PIXEL_FORMAT_BAYER_RG16:
                case GX_PIXEL_FORMAT_ENTRY.GX_PIXEL_FORMAT_BAYER_GB16:
                case GX_PIXEL_FORMAT_ENTRY.GX_PIXEL_FORMAT_BAYER_BG16:
                    {
                        //暂时没有这样的数据格式待升级
                        break;
                    }
                default:
                    break;
            }
            return emValidBits;
        }

        /// <summary>
        /// 窗体和图像显示控件保持一致
        /// </summary>
        /// <param name="e"></param>
        //protected override void OnResize(EventArgs e)
        //{
        //    base.OnResizeEnd(e);
        //    m_pic_ShowImage.Width = this.Width;
        //    m_pic_ShowImage.Height = this.Height;

        //}

    }
}

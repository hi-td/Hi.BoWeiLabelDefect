/***********************************************************
* CLR版本：4.0.30319.42000
* 类 名 称：MindVision
* 机器名称：WIN-C8KIOVQPABN
* 命名空间：迈德威视
* 文 件 名：MindVision
* 创建时间：2022/1/18 13:44:30
* 作    者： Chustange
* 公    司：HaiLan Intelligent
* 说   明：
* 修改时间：
* 修 改 人：
* 修改说明：
* 深圳市海蓝智能科技有限公司  2021  保留所有权利.
***********************************************************/
using EnumData;
using MVSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using CameraHandle = System.Int32;
using VisionPlatform;
using MvCamCtrl.NET;
using Newtonsoft.Json.Linq;
using StaticFun;
using static System.Windows.Forms.AxHost;

namespace CamSDK
{
    class MindVision
    {
        static tSdkCameraDevInfo[] DevList;
        private static IntPtr m_Grabber = IntPtr.Zero;
        private static List<CameraHandle> CamHandle1 = new List<CameraHandle>();//相机句柄
        private static List<IntPtr> CamIntPtr = new List<IntPtr>();//相机指针
        private static List<string> CamID = new List<string>();//相机序列号
        private static CameraHandle m_hCamera = 0;
        public static  Dictionary<IntPtr, CameraHandle> CamHandle = new Dictionary<IntPtr, CameraHandle>();    //相机句柄
        protected static pfnCameraGrabberFrameCallback m_FrameCallback;
        //protected static pfnCameraGrabberSaveImageComplete m_SaveImageComplete;
        public static Dictionary<CameraHandle, Function> Cam_Fun = new Dictionary<CameraHandle, Function>();    //相机句柄
        // GPIO模式                                                                                                    // GPIO模式
        public enum emCameraGPIOMode
        {
            IOMODE_TRIG_INPUT = 0,		//触发输入
            IOMODE_STROBE_OUTPUT,		//闪光灯输出
            IOMODE_GP_INPUT,			//通用型输入
            IOMODE_GP_OUTPUT,			//通用型输出
            IOMODE_PWM_OUTPUT,			//PWM型输出
        }
        /// 枚举设备
        public static bool EnumDeviceMV()
        {
            try
            {
                m_FrameCallback = new pfnCameraGrabberFrameCallback(CameraGrabberFrameCallback);
                //m_SaveImageComplete = new pfnCameraGrabberSaveI
                //mageComplete(CameraGrabberSaveImageComplete);
                CameraSdkStatus status = 0;
                MvApi.CameraEnumerateDevice(out DevList);
                int NumDev = (DevList != null ? DevList.Length : 0);
                if (NumDev < 1)
                {
                    MessageBox.Show("未扫描到相机");
                    return false;
                }
                for (int i = 0; i < DevList.Length; i++)
                {
                    status = MvApi.CameraGrabber_Create(out m_Grabber, ref DevList[i]);
                    MvApi.CameraGrabber_GetCameraHandle(m_Grabber, out m_hCamera);
                    string strFriendName = Encoding.Default.GetString(DevList[i].acSn, 0, 12);
                    CamHandle1.Add(m_hCamera);
                    CamHandle.Add(m_Grabber,m_hCamera);
                    CamID.Add(strFriendName);
                    CamIntPtr.Add(m_Grabber);
                    CamCommon.m_listCamSer.Add(strFriendName,i);
                    MvApi.CameraGrabber_SetRGBCallback(m_Grabber, m_FrameCallback, IntPtr.Zero);
                    MvApi.CameraSetAeState(m_hCamera,0);
                    // 黑白相机设置ISP输出灰度图像
                    // 彩色相机ISP默认会输出BGR24图像
                    tSdkCameraCapbility cap;
                    MvApi.CameraGetCapability(m_hCamera, out cap);
                    if (cap.sIspCapacity.bMonoSensor != 0)
                    {
                        MvApi.CameraSetIspOutFormat(m_hCamera, (uint)MVSDK.emImageFormat.CAMERA_MEDIA_TYPE_MONO8);
                    }
                    MvApi.CameraSetOutPutIOMode(m_hCamera, 0, (int)emCameraGPIOMode.IOMODE_GP_OUTPUT);
                    //MvApi.CameraSetIOState(m_hCamera, 0, 0);
                    //MvApi.CameraSetIOState(m_hCamera, 1, 0);
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageFun.ShowMessage("枚举相机出错：" + ex.ToString());
                return false;
            }
        }

        //打开相机
        public static void LiveThread(int i, Function fun)
        {
            try
            {
                // 设置触发模式
                //一般情况，0表示连续采集模式；1表示
                //软件触发模式；2表示硬件触发模式。
                if (Cam_Fun.ContainsKey(CamHandle1[i]))
                {
                    Cam_Fun[CamHandle1[i]] = fun;
                }
                else
                {
                    Cam_Fun.Add(CamHandle1[i], fun);
                }
                MvApi.CameraSetTriggerMode(CamHandle1[i], 0);
                // 功能描述 : 设置触发模式下的触发帧数。对软件触发和硬件触发
                //        模式都有效。默认为1帧，即一次触发信号采集一帧图像。
                MvApi.CameraSetTriggerCount(CamHandle1[i], 1);
                
                //MvApi.CameraGrabber_StartLive(CamIntPtr[i]);
            }
            catch (SystemException ex)
            {
                ex.ToString();
                return;
            }
        }
        private static void CameraGrabberFrameCallback(
           IntPtr Grabber,
           IntPtr pFrameBuffer,
           ref tSdkFrameHead pFrameHead,
           IntPtr Context)
        {
            // 数据处理回调

            // 由于黑白相机在相机打开后设置了ISP输出灰度图像
            // 因此此处pFrameBuffer=8位灰度数据
            // 否则会和彩色相机一样输出BGR24数据

            // 彩色相机ISP默认会输出BGR24图像
            // pFrameBuffer=BGR24数据
            uint uIspOutFmt = 0;
            MvApi.CSharpImageFromFrame(pFrameBuffer, ref pFrameHead);
            MvApi.CameraGetIspOutFormat(CamHandle[Grabber], ref uIspOutFmt);
            int w = pFrameHead.iWidth, h = pFrameHead.iHeight;
            if (pFrameHead.iWidthZoomSw > 0 && pFrameHead.iHeightZoomSw > 0)
            {
                w = pFrameHead.iWidthZoomSw;
                h = pFrameHead.iHeightZoomSw;
            }

            bool IspOutGray = (uIspOutFmt == (uint)emImageFormat.CAMERA_MEDIA_TYPE_MONO8);
            if (pFrameBuffer != IntPtr.Zero)
            {
                //MvApi.CameraImageProcess(m_hCamera, pRaw, pFrameBuffer, ref FrameHead);
                //MvApi.CameraDisplayRGB24(item.hCamera, pFrameBuffer, ref FrameHead);
                //MvApi.CameraSaveImage(item.hCamera, item.FileName, pFrameBuffer, ref FrameHead, item.FileType, item.Quality);
                if (IspOutGray)
                {
                    Cam_Fun[CamHandle[Grabber]].GetImageFromCam(CamColor.mono, pFrameBuffer, w, h, "bgr");
                }
                else
                {
                    Cam_Fun[CamHandle[Grabber]].GetImageFromCam(CamColor.color, pFrameBuffer, w, h, "bgr");
                }
                //MvApi.CameraAlignFree(pFrameBuffer);
            }
        }
        //// 执行软触发：拍一张照
        //// execute software trigger once 
        public static void GrabImage(int i)
        {
            if (CamIntPtr[i] != IntPtr.Zero)
            {
                int mode = 0;
                MvApi.CameraGetTriggerMode(CamHandle1[i], ref mode);
                if (mode== 1)
                {
                    // 只触发模式下调用软触发指令
                    MvApi.CameraSoftTrigger(CamHandle1[i]);
                }
                else
                {
                    MvApi.CameraSetTriggerMode(CamHandle1[i], 1);
                    MvApi.CameraSoftTrigger(CamHandle1[i]);
                }
            }
        }
        //修改为硬触发模式
        public static void Trigger(int i)
        {
            if (CamIntPtr[i] != IntPtr.Zero)
            {
                int mode = 0;
                MvApi.CameraGetTriggerMode(CamHandle1[i], ref mode);
                if (mode == 0 || mode == 1)
                {
                    MvApi.CameraSetTriggerMode(CamHandle1[i], 2);
                    MvApi.CameraSetExtTrigJitterTime(CamHandle1[i], 2000);
                    //0:上升沿触发 1:下降沿触发 2:高电平触发,电平宽度决定曝光时间 3:低电平触发 4:双边沿触发 
                    MvApi.CameraSetExtTrigSignalType(CamHandle1[i], 1);
                }
            }
        }
        //全部修改为硬触发模式
        public static void TriggerAll()
        {
            for (int i = 0; i < CamIntPtr.Count; i++)
            {
                if (CamIntPtr[i] != IntPtr.Zero)
                {
                    int mode = 0;
                    MvApi.CameraGetTriggerMode(CamHandle1[i], ref mode);
                    if (mode == 0 || mode == 1)
                    {
                        MvApi.CameraSetTriggerMode(CamHandle1[i], 2);
                        MvApi.CameraSetExtTrigJitterTime(CamHandle1[i], (uint)DataSerializer._Ioandtime.Io.cam1ytime);
                        //0:上升沿触发 1:下降沿触发 2:高电平触发,电平宽度决定曝光时间 3:低电平触发 4:双边沿触发 
                        MvApi.CameraSetExtTrigSignalType(CamHandle1[i], 1);
                    }
                }
            }
        }
        
        //停止所有相机的实时模式：改为触发模式
        public static void StopLiveAll()
        {
            try
            {
                for (int i = 0; i < CamIntPtr.Count; i++)
                {
                    MvApi.CameraSetTriggerMode(CamHandle1[i], 1);
                }
            }
            catch (SystemException ex)
            {
                ex.ToString();
                return;
            }

        }

        public static void AllsetoutIO()
        {
            try
            {
                for (int i = 0; i < CamIntPtr.Count; i++)
                {
                    MvApi.CameraSetIOState(CamHandle1[i], 0, 1);
                    MvApi.CameraSetIOState(CamHandle1[i], 1, 1);
                }
            }
            catch (SystemException ex)
            {
                MessageFun.ShowMessage(ex.ToString());
                return;
            }

        }
        //实时
        public static void Live(int i)
        {
            try
            {
                if (CamIntPtr[i] != IntPtr.Zero)
                {
                    int mode = 0;
                    MvApi.CameraGetTriggerMode(CamHandle1[i], ref mode);
                    if (mode == 0)
                    {
                        MvApi.CameraGrabber_StartLive(CamIntPtr[i]);
                    }
                    else
                    {
                        MvApi.CameraSetTriggerMode(CamHandle1[i], 0);
                        MvApi.CameraGrabber_StartLive(CamIntPtr[i]);
                    }
                }
            }
            catch (SystemException ex)
            {
                ex.ToString();
                return;
            }
        }

        public static CamCommon.CamParam GetCamParam(int camID)
        {
            CamCommon.CamParam camParam = new CamCommon.CamParam();
            try
            {
                //帧率
                camParam.frame = (float)(Math.Round(GetFPS(camID), 2));
                //增益
                camParam.gain = (float)(GetGain(camID));
                //曝光
                camParam.exposure = (float)(GetShutter(camID));

            }
            catch (SystemException ex)
            {
                StaticFun.MessageFun.ShowMessage(ex.ToString());
            }
            return camParam;
        }
        //获取帧率
        public static double GetFPS(int nCamID)
        {
            float dFPS = 0;
            if (CamIntPtr[nCamID] != IntPtr.Zero)
            {
                tSdkGrabberStat stat;
                MvApi.CameraGrabber_GetStat(CamIntPtr[nCamID], out stat);
                dFPS = stat.CapFps;
            }
            return Math.Round(dFPS, 2);
        }
        //获取增益值
        public static double GetGain(int nCamID)
        {
            int dCurGain = 0;             //当前增益值
            if (CamIntPtr[nCamID] != IntPtr.Zero)
            {
                MvApi.CameraGetAnalogGain(CamHandle1[nCamID], ref dCurGain);
            }
            return dCurGain;
        }
        //设置增益值
        public static void SetGain(int nCamID, double dGain)
        {
            try
            {
                if (CamIntPtr[nCamID] != IntPtr.Zero)
                {
                    tSdkCameraCapbility tCameraDeviceInfo;
                    MvApi.CameraGetCapability(CamHandle1[nCamID], out tCameraDeviceInfo);

                    //判断输入值是否在增益值的范围内
                    //若输入的值大于最大值则将增益值设置成最大值
                    if (dGain > (int)tCameraDeviceInfo.sExposeDesc.uiAnalogGainMax)
                    {
                        dGain = (int)tCameraDeviceInfo.sExposeDesc.uiAnalogGainMax;
                    }

                    //若输入的值小于最小值则将增益的值设置成最小值
                    if (dGain < (int)tCameraDeviceInfo.sExposeDesc.uiAnalogGainMin)
                    {
                        dGain = (int)tCameraDeviceInfo.sExposeDesc.uiAnalogGainMin;
                    }
                    MvApi.CameraSetAnalogGain(CamHandle1[nCamID], (int)dGain);
                    //MessageFun.ShowMessage("增益最大值:"+ tCameraDeviceInfo.sExposeDesc.uiAnalogGainMax.ToString()+ "  增益最小值:"+ tCameraDeviceInfo.sExposeDesc.uiAnalogGainMin.ToString());
                }
            }
            catch (Exception ex)
            {
                string strErrorInfo ="错误描述信息为：" + ex.Message;
                MessageBox.Show(strErrorInfo);
            }
        }
        //获取曝光值
        public static double GetShutter(int nCamID)
        {
            double dCurShuter = 0.0;                 //当前曝光值
            if (CamIntPtr[nCamID] != IntPtr.Zero)
            {
                MvApi.CameraGetExposureTime(CamHandle1[nCamID], ref dCurShuter);
            }
            return Math.Round(dCurShuter, 2);
        }
        //设置曝光值
        public static void SetShutter(int nCamID, double dShutter)
        {
            try
            {
                double dMin = 0.0;                       //最小值
                double dMax = 0.0;                       //最大值
                double d = 0.0;
                if (CamIntPtr[nCamID] != IntPtr.Zero)
                {
                    MvApi.CameraGetExposureTimeRange(CamHandle1[nCamID], ref dMin, ref dMax, ref d);
                    //判断输入值是否在曝光时间的范围内
                    //若大于最大值则将曝光值设为最大值
                    if (dShutter > dMax)
                    {
                        dShutter = dMax;
                    }
                    //若小于最小值将曝光值设为最小值
                    if (dShutter < dMin)
                    {
                        dShutter = dMin;
                    }
                    //MessageFun.ShowMessage("曝光值："+dShutter.ToString());
                    MvApi.CameraSetExposureTime(CamHandle1[nCamID], dShutter);
                    //MessageFun.ShowMessage("曝光最大值:" + dMax.ToString() + "  曝光最小值:" + dMin.ToString());
                }
            }
            catch (Exception ex)
            {
                string strErrorInfo ="错误描述信息为：" + ex.Message;
                MessageBox.Show(strErrorInfo);
            }
        }
        public static void DestroyDev()
        {
            try
            {
                // ch:关闭设备 || en: Close device90
                for (int i = 0; i < CamIntPtr.Count; i++)
                {
                    MvApi.CameraGrabber_Destroy(CamIntPtr[i]);
                }
            }
            catch (SystemException ex)
            {
                ex.ToString();
                return;
            }

        }
        public static void GetCapability(int nCamID, out tSdkCameraCapbility tCameraCapability)
        {
            MvApi.CameraGetCapability(CamHandle1[nCamID], out tCameraCapability);
        }
        public static void SetIOState(int nCamID, int iPoint, bool bState)
        {
            uint uistate = (uint)Convert.ToInt32(bState);
            MvApi.CameraSetIOState(CamHandle1[nCamID], iPoint, uistate);
        }
        public static void GetIOState(int nCamID, int iPoint, ref uint bState)
        {
            MvApi.CameraGetIOState(CamHandle1[nCamID], iPoint, ref bState);
        }
    }
}

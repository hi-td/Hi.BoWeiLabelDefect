using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThridLibray;
using System.Diagnostics;
using Chustange.Functional;

namespace CamSDK
{
    class DahuaCamera
    {
        private static List<string> m_listCamSer = new List<string>();       //相机序列号
        public static CameraOperator[] m_cameraVec;                          //相机方法                                   
        private static List<bool> m_bLive = new List<bool>();
        public static List<DahuaCamera> m_vecs = new List<DahuaCamera>();
        IDevice m_dev;
        CameraOperator m_cameraOperator;

        public enum EStatus
        {
            eStatusOK = 0,
            eStatusFailed = -1,
            eStatusNullPtr = -2,
            eStatusDisconnect = -3,
            eStatusAlreadyDone = -4,
            eStatusTimeout = -5,
            eStatusNotAvailable = -6,
        };
        public DahuaCamera(IDevice dev)
        {
            m_dev = dev;
        }

        ~DahuaCamera() { }
  

        //搜索所有相机
        public static int EnumCameras()
        {
            try
            {
                m_listCamSer.Clear();
                CamCommon.m_listCamSer.Clear();
                m_bLive.Clear();
                //CamCommon.m_bLive.Clear();
                List<IDeviceInfo> deviceInfoListCnt = Enumerator.EnumerateDevices();
                if (deviceInfoListCnt.Count <= 0)
                    return -1;
                //m_vecs.Clear();
                //做多支持四个相机
                for (int i = 0; i < deviceInfoListCnt.Count; i++)
                {
                    if (i >= 4)
                    {
                        break;
                    }
                    IDevice dev = Enumerator.GetDeviceByIndex(i);
                    Trace.WriteLine(dev.DeviceInfo.DeviceType + "\n");

                    m_vecs.Add(new DahuaCamera(dev));
                    //打印相机信息
                    if (dev.DeviceInfo.DeviceType == 0)
                    {
                        StaticFun.MessageFun.ShowMessage("GigE: " + dev.DeviceInfo.ManufactureInfo + " " + dev.DeviceInfo.Model + " (" + dev.DeviceInfo.SerialNumber + ")");
                    }
                    else if (dev.DeviceInfo.DeviceType == 1)
                    {
                        StaticFun.MessageFun.ShowMessage("USB: " + dev.DeviceInfo.ManufactureInfo + " " + dev.DeviceInfo.Model + " (" + dev.DeviceInfo.SerialNumber + ")");

                    }
                    //添加相机的序列号
                    m_listCamSer.Add(dev.DeviceInfo.SerialNumber);
                    CamCommon.m_listCamSer.Add(dev.DeviceInfo.SerialNumber);
                }
                //初始化实时显示状态
                m_cameraVec = new CameraOperator[m_listCamSer.Count];
                for (int n = 0; n < m_listCamSer.Count; n++)
                {
                    m_bLive.Add(false);
                }
                if (m_listCamSer.Count == 0)
                {
                    StaticFun.MessageFun.ShowMessage(DateTime.Now + " 没有搜索到相机设备，请检查相机设备是否正确连接！");
                }
                return deviceInfoListCnt.Count;
            }
            catch (Exception ex)
            {
                ex.Message.ToLog();
                return 0;
            }
        }

        //打开单个相机
        public static void OpenCam(int i, VisionPlatform.Function fun)
        {
            if (DahuaCamera.EStatus.eStatusOK != m_vecs[i].Open())
            {
                StaticFun.MessageFun.ShowMessage(DateTime.Now + " Camera " + m_listCamSer[i] + " Open fail");
            }
            else
            {
                StaticFun.MessageFun.ShowMessage(DateTime.Now + " Camera " + m_listCamSer[i] + " Open success");
            }
            if(i >= m_cameraVec.Count())
            {
                StaticFun.MessageFun.ShowMessage("相机序号错误！");
                return;
            }
            m_cameraVec[i] = new CameraOperator(i, fun);
        }

        #region 属性设置和获取函数
        /*SDK有六种属性类型，对应六种通用属性设置方法，属性类型和名称可以通过MVviewer查看
         注意，部分属性在开始采图后不能设置，对应MVviewer可以看到该栏属性名称变暗，但可以获取该属性*/

        /*整型属性*/
        public int setIntegerAttr(string attrName, long nValue)
        {
            if ((m_dev == null) || (!m_dev.IsOpen))
                return -1;

            using (IIntegraParameter p = m_dev.ParameterCollection[new IntegerName(attrName)])
            {
                if (false == p.SetValue(nValue))
                {
                    return -1;
                }
            }
            return 0;
        }

        public long getIntegerAttr(string attrName)
        {
            if ((m_dev == null) || (!m_dev.IsOpen))
            {
                return -1;
            }
            long nValue = -1;
            using (IIntegraParameter p = m_dev.ParameterCollection[new IntegerName(attrName)])
            {
                /*获取失败失败返回0*/
                nValue = p.GetValue();
            }

            return nValue;
        }

        /*浮点型属性*/
        public int setFloatAttr(string attrName, double dValue)
        {
            if ((m_dev == null) || (!m_dev.IsOpen))
                return -1;

            using (IFloatParameter p = m_dev.ParameterCollection[new FloatName(attrName)])
            {
                if (false == p.SetValue(dValue))
                {
                    return -1;
                }
            }
            return 0;
        }

        public double getFloatAttr(string attrName)
        {
            if ((m_dev == null) || (!m_dev.IsOpen))
                return -1.0;

            double dValue = -1.0;
            using (IFloatParameter p = m_dev.ParameterCollection[new FloatName(attrName)])
            {
                /*获取失败失败返回0.0*/
                dValue = p.GetValue();
            }
            return dValue;
        }
        /*布尔型属性*/
        public int setBoolAttr(string attrName, bool bValue)
        {
            if ((m_dev == null) || (!m_dev.IsOpen))
                return -1;

            using (IBooleanParameter p = m_dev.ParameterCollection[new BooleanName(attrName)])
            {
                if (false == p.SetValue(bValue))
                {
                    return -1;
                }
            }
            return 0;
        }

        public bool getBoolAttr(string attrName)
        {
            if ((m_dev == null) || (!m_dev.IsOpen))
                return false;

            bool bValue = false;
            using (IBooleanParameter p = m_dev.ParameterCollection[new BooleanName(attrName)])
            {
                bValue = p.GetValue();
            }
            return bValue;
        }

        /*枚举类型*/
        public int setEnumAttr(string attrName, string sValue)
        {
            if ((m_dev == null) || (!m_dev.IsOpen))
                return -1;
            using (IEnumParameter p = m_dev.ParameterCollection[new EnumName(attrName)])
            {
                if (false == p.SetValue(sValue))
                {
                    return -1;
                }
            }
            return 0;
        }

        public string getEnumAttr(string attrName)
        {
            if ((m_dev == null) || (!m_dev.IsOpen))
                return null;

            string sValue = null;
            using (IEnumParameter p = m_dev.ParameterCollection[new EnumName(attrName)])
            {
                sValue = p.GetValue();
            }
            return sValue;
        }

        /*字符串类型*/
        public int setStringAttr(string attrName, string sValue)
        {
            if ((m_dev == null) || (!m_dev.IsOpen))
                return -1;
            using (IStringParameter p = m_dev.ParameterCollection[new StringName(attrName)])
            {
                if (false == p.SetValue(sValue))
                {
                    return -1;
                }
            }
            return 0;
        }
        public string getStringAttr(string attrName)
        {
            if ((m_dev == null) || (!m_dev.IsOpen))
                return null;

            string sValue = null;
            using (IStringParameter p = m_dev.ParameterCollection[new StringName(attrName)])
            {
                sValue = p.GetValue();
            }
            return sValue;
        }
        /*命令型属性*/
        public int executeCommand(string attrName)
        {
            if ((m_dev == null) || (!m_dev.IsOpen))
                return -1;

            using (ICommandParameter p = m_dev.ParameterCollection[new CommandName(attrName)])
            {
                if (false == p.Execute())
                {
                    return -1;
                }
            }
            return 0;
        }
        #endregion 

        public EStatus Open()
        {
            if (m_dev == null)
                return EStatus.eStatusNullPtr;

            if (m_dev.IsOpen)
                return EStatus.eStatusAlreadyDone;

            if (false == m_dev.Open())
                return EStatus.eStatusFailed;

            return EStatus.eStatusOK;
        }

        public EStatus Close()
        {
            if (m_dev == null)
                return EStatus.eStatusNullPtr;

            if (false == m_dev.IsOpen)
                return EStatus.eStatusAlreadyDone;

            StopGrabbing();

            if (false == m_dev.Close())
                return EStatus.eStatusFailed;

            return EStatus.eStatusOK;
        }

        public EStatus StartGrabbing()
        {
            if (m_dev == null)
                return EStatus.eStatusNullPtr;

            if (false == m_dev.IsOpen)
                return EStatus.eStatusDisconnect;

            if (m_dev.IsGrabbing)
                return EStatus.eStatusAlreadyDone;

            //注册回调函数
            m_dev.StreamGrabber.ImageGrabbed += m_cameraOperator.OnImageGrabbed;

            if (false == m_dev.GrabUsingGrabLoopThread())
                return EStatus.eStatusFailed;

            return EStatus.eStatusOK;
        }

        public EStatus StopGrabbing()
        {
            if (m_dev == null)
                return EStatus.eStatusNullPtr;

            if (false == m_dev.IsOpen)
                return EStatus.eStatusDisconnect;

            if (false == m_dev.IsGrabbing)
                return EStatus.eStatusAlreadyDone;

            m_dev.StreamGrabber.ImageGrabbed -= m_cameraOperator.OnImageGrabbed;

            if (false == m_dev.ShutdownGrab())
                return EStatus.eStatusFailed;

            return EStatus.eStatusOK;
        }

        public bool isOpen()
        {
            return m_dev.IsOpen;
        }

        public void SetCameraOperator(CameraOperator cameraOperator)
        {
            m_cameraOperator = cameraOperator;
        }

        public bool SetTriggerClose()
        {
            if (m_dev == null || !m_dev.IsOpen)
                return false;

            return m_dev.TriggerSet.Close();
        }
       
        //获取一帧图像
        public bool TriggerOnce()
        {
            if (m_dev == null || !m_dev.IsOpen)
                return false;
            /* 打开Software Trigger */
            if (false == m_dev.TriggerSet.Open(TriggerSourceEnum.Software))
                return false;
            if (false == m_dev.ExecuteSoftwareTrigger())
                return false;
            return true;
        }


        //关闭所有相机
        public static void CloseCam()
        {
            for (int i = 0; i < DahuaCamera.m_vecs.Count; i++)
            {
                if (DahuaCamera.EStatus.eStatusOK != m_cameraVec[i].Close())
                {
                    StaticFun.MessageFun.ShowMessage(DateTime.Now + " Camera " + m_listCamSer[i] + " Close fail");
                }
                else
                {
                    StaticFun.MessageFun.ShowMessage(DateTime.Now + " Camera " + m_listCamSer[i] + " Close success");
                }
            }
        }
        //开启抓图:实时
        public static void StartGrab(int i)
        {
            if (i == -1)
            {
                StaticFun.MessageFun.ShowMessage(DateTime.Now + " 相机序号输入异常！");
                return;
            }
            if (null == m_cameraVec[i]) return;
            m_cameraVec[i].SetTriggerClose();//关闭触发模式
            if (DahuaCamera.EStatus.eStatusOK != m_cameraVec[i].StartGrabbing())
            {
                StaticFun.MessageFun.ShowMessage(DateTime.Now + " Camera " + m_listCamSer[i] + " 开启实时显示失败！");
                m_bLive[i] = false;
                return;
            }
            //else
            //{
            //    GlobalFun.MessageFun.ShowMessage(DateTime.Now + " Camera " + m_listCamSer[i] + " StartGrabbing success");
            //}
            m_bLive[i] = true;
        }
        //停止抓图：实时
        public static void StopGrab(int i)
        {
            if (i == -1)
            {
                StaticFun.MessageFun.ShowMessage(DateTime.Now + " 相机序号输入异常！");
                return;
            }
            if (null == m_cameraVec[i]) return;
            if (DahuaCamera.EStatus.eStatusOK != m_cameraVec[i].StopGrabbing())
            {
                StaticFun.MessageFun.ShowMessage(DateTime.Now + " Camera " + m_listCamSer[i] + " 停止实时显示失败！");
                return;
            }
            //else
            //{
            //    Function.ShowMessage(DateTime.Now + " Camera " + m_strSeriNum[i] + " StopGrabbing success");
            //}
            m_bLive[i] = false;
        }

        //外部触发Line1
        public bool SetTriggerMode(bool bValue)
        {
            if (m_dev == null || !m_dev.IsOpen)
                return false;

            string str = (bValue == true ? TriggerSourceEnum.Software : TriggerSourceEnum.Line1);
            return m_dev.TriggerSet.Open(str);
        }


        //外部触发
        public static bool ExternalGabImg(int i)
        {
            try
            {
                if (i == -1)
                {
                    StaticFun.MessageFun.ShowMessage(DateTime.Now + " 相机序号输入异常！");
                    return false;
                }
                if (!m_cameraVec[i].m_bShowLoop)
                    m_cameraVec[i].StartGrabbing();
                m_cameraVec[i].SetTriggerMode(false);
                return true;
            }
            catch (Exception ex)
            {
                (ex.Message + ex.StackTrace).ToLog();
                return false;
            }
        }
        //// 执行软触发：拍一张照
        //// execute software trigger once 
        public static bool GrabImage(int i)
        {
            try
            {
                if (i == -1)
                {
                    StaticFun.MessageFun.ShowMessage(DateTime.Now + " 相机序号输入异常！");
                    return false;
                }
                if (m_cameraVec[i] == null)
                    return false;
                if (!m_cameraVec[i].m_bShowLoop)
                    m_cameraVec[i].StartGrabbing();
                m_cameraVec[i].TriggerOnce();
                return true;
            }
            catch (Exception ex)
            {
                (ex.Message + ex.StackTrace).ToLog();
                return false;
            }
        }
        //获取参数
        public static CamCommon.CamParam GetCamParam(int i)
        {
            CamCommon.CamParam param = new CamCommon.CamParam();
            param.exposure = (int)m_cameraVec[i].GetExposureTime();
            param.gain = (int)m_cameraVec[i].GetGain();
            return param;
        }
        //设置参数
        public static void SetCamParam(int i, CamCommon.CamParam param)
        {
            m_cameraVec[i].SetExposureTime(param.exposure);
            m_cameraVec[i].SetGain(param.gain);
        }

        //设置曝光
        public static void SetExposure(int i, int value)
        {
            m_cameraVec[i].SetExposureTime((double)value);
        }
        //设置参数
        public static void SetGain(int i, int value)
        {
            m_cameraVec[i].SetGain((double)value);
        }

    }
}

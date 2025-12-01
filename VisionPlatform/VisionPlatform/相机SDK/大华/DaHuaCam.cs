/***********************************************************
* CLR版本：4.0.30319.42000
* 类 名 称：DaHuaCam1
* 机器名称：WIN-C8KIOVQPABN
* 命名空间：VisionPlatform.相机SDK.大华
* 文 件 名：DaHuaCam1
* 创建时间：2022/7/26 11:00:17
* 作    者： Chustange
* 公    司：HaiLan Intelligent
* 说   明：
* 修改时间：
* 修 改 人：
* 修改说明：
* 深圳市海蓝智能科技有限公司  2021  保留所有权利.
***********************************************************/
using CamSDK;
using StaticFun;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using ThridLibray;

namespace VisionPlatform
{
    class DaHuaCam
    {
        public static List<IDevice> m_dev = new List<IDevice>(); //相机对象
        public static List<CameraOperator1> m_vecs = new List<CameraOperator1>(); //相机对象
        private static List<string> m_listCamSer = new List<string>();       //相机序列号
        static CameraOperator1 m_cameraOperator1;
        public static Dictionary<IDevice, Function> Cam_Fun = new Dictionary<IDevice, Function>();    //相机句柄

        //枚举所有相机

        public static int EnumCameras()
        {
            try
            {
                List<IDeviceInfo> deviceInfoListCnt = Enumerator.EnumerateDevices();
                if (deviceInfoListCnt.Count <= 0)
                    return -1;
                for (int i = 0; i < deviceInfoListCnt.Count; i++)
                {
                    IDevice dev = Enumerator.GetDeviceByIndex(i);
                    IGigeDeviceInfo a= Enumerator.GigeCameraInfo(i);
                    Trace.WriteLine(dev.DeviceInfo.DeviceType + "\n");
                    m_dev.Add(dev);

                    //打印相机信息
                    if (dev.DeviceInfo.DeviceType == 0)
                    {
                        StaticFun.MessageFun.ShowMessage("GigE: " + dev.DeviceInfo.ManufactureInfo + " " + dev.DeviceInfo.Model + " (" + dev.DeviceInfo.SerialNumber + ")");
                    }
                    else if (dev.DeviceInfo.DeviceType == 1)
                    {
                        StaticFun.MessageFun.ShowMessage("USB: " + dev.DeviceInfo.ManufactureInfo + " " + dev.DeviceInfo.Model + " (" + dev.DeviceInfo.SerialNumber + ")");

                    }
                    // 打开设备 
                    // open device 
                    if (!dev.Open())
                    {
                        MessageFun.ShowMessage(dev.DeviceInfo.SerialNumber + "Open camera failed");
                    }
                    else
                    {
                        // 打开Software Trigger 
                        // Set Software Trigger 

                        dev.TriggerSet.Open(TriggerSourceEnum.Software);

                        // 设置缓存个数为8（默认值为16） 
                        dev.StreamGrabber.SetBufferCount(4);
                    }
                    //GvspPixelFormatType.gvspPixelMono8
                    //添加相机的序列号
                    m_listCamSer.Add(dev.DeviceInfo.SerialNumber);
                    CamCommon.m_listCamSer.Add(dev.DeviceInfo.SerialNumber,i);
                }
                if (m_listCamSer.Count == 0)
                {
                    StaticFun.MessageFun.ShowMessage(DateTime.Now + " 没有搜索到相机设备，请检查相机设备是否正确连接！");
                }
                return deviceInfoListCnt.Count;
            }
            catch (Exception ex)
            {
                MessageFun.ShowMessage(ex.ToString());
                return 0;
            }
        }

        //打开单个相机
        public static void OpenCam(int i, Function fun)
        {
            m_cameraOperator1 = new CameraOperator1(m_dev[i], fun);
            m_vecs.Add(m_cameraOperator1);
            opencam(i);
            Cam_Fun.Add(m_dev[i], fun);
        }
        // 执行软触发 
        // execute software trigger once 
        public static bool GrabImage(int i)
        {
            try
            {
                if (m_dev[i] != null)
                {
                    /* 打开Software Trigger */
                    if (false == m_dev[i].TriggerSet.Open(TriggerSourceEnum.Software))
                    {
                        MessageFun.ShowMessage(@"打开软触发失败");
                        return false;
                    }
                    m_dev[i].ExecuteSoftwareTrigger();
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception exception)
            {
                MessageFun.ShowMessage(exception.ToString());
                return false;
            }
        }
        // 开启码流 
        // stop grabbing 
        private static void opencam(int i)
        {
            try
            {
                /* 开启码流 */
                if (!m_dev[i].GrabUsingGrabLoopThread())
                {
                    MessageFun.ShowMessage(@"开启码流失败");
                    m_dev[i].ShutdownGrab(); /*停止拉流*/
                    m_dev[i].Dispose(); /*释放*/
                    return;
                }
            }
            catch (Exception exception)
            {
                MessageFun.ShowMessage(exception.ToString());
            }

        }
        //实时
        public static void Live(int i)
        {
            try
            {
                if (m_dev[i] != null)
                {
                    /* 关闭触发模式*/
                    using (IEnumParameter p = m_dev[i].ParameterCollection[ParametrizeNameSet.TriggerMode])
                    {
                        if (false == p.SetValue("Off"))
                        {
                            MessageFun.ShowMessage(@"关闭触发失败");
                        }
                    }
                }
            }
            catch (SystemException ex)
            {
                MessageFun.ShowMessage(ex.ToString());
                return;
            }
        }
        //停止抓图
        public static void StopGrab(int i)
        {
            try
            {
                if (m_dev[i] != null)
                {
                    /* 打开触发模式*/
                    /* 打开Software Trigger */
                    if (false == m_dev[i].TriggerSet.Open(TriggerSourceEnum.Software))
                    {
                        MessageFun.ShowMessage(@"打开软触发失败");
                    }
                }
            }
            catch (SystemException ex)
            {
                MessageFun.ShowMessage(ex.ToString());
                return;
            }
        }
        //public static void 
        //获取参数
        public static CamCommon.CamParam GetCamParam(int i)
        {
            CamCommon.CamParam param = new CamCommon.CamParam();
            param.exposure = (int)getFloatAttr(i, "ExposureTime");
            param.gain = (int)getFloatAttr(i, "GainRaw");
            return param;
        }
        //设置曝光
        public static void SetExposure(int i, int value)
        {
            setFloatAttr(i, "ExposureTime",(double)value);
        }
        //设置增益
        public static void SetGain(int i, int value)
        {
            setFloatAttr(i, "GainRaw",(double)value);
        }
        public static double getFloatAttr(int i, string attrName)
        {
            if ((m_dev[i] == null) || (!m_dev[i].IsOpen))
                return -1.0;

            double dValue = -1.0;
            using (IFloatParameter p = m_dev[i].ParameterCollection[new FloatName(attrName)])
            {
                /*获取失败失败返回0.0*/
                dValue = p.GetValue();
            }
            return dValue;
        }
        /*浮点型属性*/
        public static  int setFloatAttr(int i,string attrName, double dValue)
        {
            if ((m_dev[i] == null) || (!m_dev[i].IsOpen))
                return -1;

            using (IFloatParameter p = m_dev[i].ParameterCollection[new FloatName(attrName)])
            {
                if (false == p.SetValue(dValue))
                {
                    return -1;
                }
            }
            return 0;
        }
        //关闭所有相机
        public static void CloseCam()
        {
            for (int i = 0; i < m_vecs.Count; i++)
            {
                m_vecs[i].Closecam();
            }
        }
    }
}

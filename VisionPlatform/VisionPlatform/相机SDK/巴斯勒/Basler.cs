/***********************************************************
* CLR版本：4.0.30319.42000
* 类 名 称：Basler
* 机器名称：WIN-C8KIOVQPABN
* 命名空间：VisionPlatform
* 文 件 名：Basler
* 创建时间：2023/5/31 12:01:23
* 作    者： Chustange
* 公    司：HaiLan Intelligent
* 说   明：
* 修改时间：
* 修 改 人：
* 修改说明：
* 深圳市海蓝智能科技有限公司  2021  保留所有权利.
***********************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Basler.Pylon;
using Chustange.Functional;
using EnumData;
using GxMultiCam;
using HalconDotNet;
using Hi.RL.Resource.Structure;
using MvCamCtrl.NET;
using MVSDK;
using StaticFun;
using VisionPlatform;
using VisionPlatform.相机SDK.巴斯勒;
using static System.Resources.ResXFileRef;

namespace CamSDK
{
    class Basler
    {
        /// <summary>
        /// 相机列表
        /// </summary>
        private static Dictionary<int,Camera> cameras = new Dictionary<int,Camera>();
        private static Dictionary<int, int> TriggerMode = new Dictionary<int, int>();
        private static int Triggerlast = 0;
        static Version sfnc2_0_0 = new Version(2, 0, 0);
        static  List<ICameraInfo> allDeviceInfos;
        private static Dictionary<int, GrabEvent> grabEventlist = new Dictionary<int, GrabEvent>();
        // 枚举设备
        public static bool Enumerate()
        {
            try
            {
                CamCommon.m_listCamSer.Clear();
                 allDeviceInfos = CameraFinder.Enumerate(DeviceType.GigE);

                if (allDeviceInfos.Count == 0)
                {
                    MessageBox.Show("未扫描到相机!");
                    return false;
                }
                for (int i = 0; i < allDeviceInfos.Count; i++)
                {
                    Camera camera = new Camera(allDeviceInfos[i]);
                    cameras.Add(i, camera);
                    CamCommon.m_listCamSer.Add(camera.CameraInfo[CameraInfoKey.FriendlyName],i);
                }
                //allDeviceInfos.ForEach(cameraInfo => cameras.Add(new Camera(cameraInfo)));
                //cameras.ForEach(camera => CamCommon.m_listCamSer.Add(camera.CameraInfo[CameraInfoKey.FriendlyName]));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        //打开相机
        public static void OpenDevice(int nCamID, CamFunction fun)
        {
            if (cameras[nCamID].IsOpen)
            {
                if (cameras[nCamID].StreamGrabber.IsGrabbing)
                {
                    MessageBox.Show("相机已被配置!");
                }

                return;
            }
            GrabEvent grabEvent = new GrabEvent(fun);
            cameras[nCamID].StreamGrabber.ImageGrabbed += grabEvent.OnImageGrabbed;
            grabEventlist.Add(nCamID, grabEvent);
            TriggerMode.Add(nCamID,0);
            cameras[nCamID].Open();
            cameras[nCamID].Parameters[PLCamera.PixelFormat].TrySetValue(PLCamera.PixelFormat.BayerRG8);
            cameras[nCamID].Parameters[PLCamera.GammaEnable].SetValue(false);
            //cameras[nCamID].Parameters[PLCamera.AcquisitionFrameRateEnable].SetValue(true);
            //cameras[nCamID].Parameters[PLCamera.AcquisitionFrameRateAbs].SetValue(40);
        }

        //实时显示
        public static void Live(int nCamID)
        {
            if (TriggerMode[nCamID] == 2)
            {
                TriggerMode[nCamID] = 1;
                stop(nCamID);
                if (Triggerlast == 2)
                {
                    cameras[nCamID].Parameters[PLCamera.TriggerMode].TrySetValue(PLCamera.TriggerMode.Off);
                }
                cameras[nCamID].CameraOpened += Configuration.AcquireContinuous;
                cameras[nCamID].Open();
                cameras[nCamID].StreamGrabber.Start(GrabStrategy.LatestImages, GrabLoop.ProvidedByStreamGrabber);
                Triggerlast = 1;
            }
            else if(TriggerMode[nCamID] == 0)
            {
                TriggerMode[nCamID] = 1;
                cameras[nCamID].Parameters[PLCamera.TriggerMode].TrySetValue(PLCamera.TriggerMode.Off);
                cameras[nCamID].CameraOpened += Configuration.AcquireContinuous;
                //cameras[nCamID].Open();
                cameras[nCamID].StreamGrabber.Start(GrabStrategy.LatestImages, GrabLoop.ProvidedByStreamGrabber);
                Triggerlast = 1;
            }
        }
        //抓图1张
        public static void GrabImage(int nCamID)
        {
            try
            {
                if (TriggerMode[nCamID] == 2)
                {
                    SoftwareTrigger(nCamID);
                }
                else if (TriggerMode[nCamID] == 1)
                {
                    stop(nCamID);
                    cameras[nCamID].Close();
                    cameras.Remove(nCamID);
                    Camera camera = new Camera(allDeviceInfos[nCamID]);
                    cameras.Add(nCamID, camera);
                    TriggerMode[nCamID] = 2;
                    cameras[nCamID].StreamGrabber.ImageGrabbed += grabEventlist[nCamID].OnImageGrabbed;
                    cameras[nCamID].CameraOpened += Configuration.SoftwareTrigger;
                    cameras[nCamID].Open();
                    cameras[nCamID].StreamGrabber.Start(GrabStrategy.LatestImages, GrabLoop.ProvidedByStreamGrabber);
                    Triggerlast = 2;
                    SoftwareTrigger(nCamID);
                }
                else if (TriggerMode[nCamID] == 0)
                {
                    cameras[nCamID].CameraOpened += Configuration.SoftwareTrigger;
                    cameras[nCamID].Open();
                    cameras[nCamID].StreamGrabber.Start(GrabStrategy.LatestImages, GrabLoop.ProvidedByStreamGrabber);
                    Triggerlast = 2;
                    SoftwareTrigger(nCamID);
                }
            }
            catch (Exception ex)
            {
                StaticFun.MessageFun.ShowMessage("GrabImage出错！" + ex.ToString());
            }

        }
        //停止抓图
        public static void stop(int nCamID)
        {
            if (TriggerMode[nCamID]!=0&& Triggerlast!=0&& TriggerMode[nCamID]!= Triggerlast)
            {
                cameras[nCamID].StreamGrabber.Stop();
            }
        }

        /// <summary>
        /// 获取曝光时间
        /// </summary>
        public static int GetExposureTime(int nCamID)
        {
            int dCurShuter = 0;                 //当前曝光值
            try
            {

                if (cameras[nCamID].GetSfncVersion() < sfnc2_0_0)
                {
                    if (cameras[nCamID].Parameters[PLCamera.ExposureTimeRaw].IsReadable)
                    {
                        dCurShuter=(int)cameras[nCamID].Parameters[PLCamera.ExposureTimeRaw].GetValue();
                    }
                }
                else
                {
                    if (cameras[nCamID].Parameters[PLCamera.ExposureTime].IsReadable)
                    {
                        dCurShuter = (int)cameras[nCamID].Parameters[PLCamera.ExposureTime].GetValue();
                    }
                }
                return dCurShuter;
            }
            catch
            {
                return dCurShuter;
            }
        }
        /// <summary>
        /// 设置曝光时间
        /// </summary>
        public static void SetExposureTime(int nCamID, int ExposureTime)
        {
            try
            {
                if (cameras[nCamID].GetSfncVersion() < sfnc2_0_0)
                {
                    var minExposureTime = cameras[nCamID].Parameters[PLCamera.ExposureTimeRaw].GetMinimum();
                    var maxExposureTime = cameras[nCamID].Parameters[PLCamera.ExposureTimeRaw].GetMaximum();
                    if (cameras[nCamID].Parameters[PLCamera.ExposureTimeRaw].IsReadable)
                    {
                        if (ExposureTime >= minExposureTime && ExposureTime <= maxExposureTime)
                        {
                            cameras[nCamID].Parameters[PLCamera.ExposureTimeRaw].SetValue(ExposureTime);
                        }

                    }
                }
                else
                {
                    var minExposureTime = (long)cameras[nCamID].Parameters[PLUsbCamera.ExposureTime].GetMinimum();
                    var maxExposureTime = (long)cameras[nCamID].Parameters[PLUsbCamera.ExposureTime].GetMaximum();
                    if (cameras[nCamID].Parameters[PLCamera.ExposureTime].IsReadable)
                    {
                        if (ExposureTime >= minExposureTime && ExposureTime <= maxExposureTime)
                        {
                            cameras[nCamID].Parameters[PLCamera.ExposureTime].SetValue(ExposureTime);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                StaticFun.MessageFun.ShowMessage("设置曝光时间失败！"+ex.ToString());
            }
        }
        /// <summary>
        /// 获取增益
        /// </summary>
        public static  int GetGain(int nCamID)
        {
            int dCurGain = 0;             //当前增益值
            try
            {
                if (cameras[nCamID].GetSfncVersion() < sfnc2_0_0)
                {
                    if (cameras[nCamID].Parameters[PLCamera.GainRaw].IsReadable)
                    {
                        dCurGain=(int)cameras[nCamID].Parameters[PLCamera.GainRaw].GetValue();
                    }

                }
                else
                {
                    if (cameras[nCamID].Parameters[PLCamera.Gain].IsReadable)
                    {
                        dCurGain = (int)cameras[nCamID].Parameters[PLCamera.Gain].GetValue();
                    }
                }
                return dCurGain;
            }
             catch (Exception ex)
            {
                return dCurGain;
            }
        }

        /// <summary>
        /// 设置增益
        /// </summary>
        public static void SetGain(int nCamID, int dGain)
        {
            try
            {
                if (cameras[nCamID].GetSfncVersion() < sfnc2_0_0)
                {
                    var minGain = cameras[nCamID].Parameters[PLCamera.GainRaw].GetMinimum();
                    var maxGain = cameras[nCamID].Parameters[PLCamera.GainRaw].GetMaximum();
                    if (cameras[nCamID].Parameters[PLCamera.ExposureTimeRaw].IsReadable)
                    {
                        if (dGain >= minGain && dGain <= maxGain)
                        {
                            cameras[nCamID].Parameters[PLCamera.GainRaw].SetValue(dGain);
                        }

                    }
                }
                else
                {
                    var minGain = (long)cameras[nCamID].Parameters[PLUsbCamera.Gain].GetMinimum();
                    var maxGain = (long)cameras[nCamID].Parameters[PLUsbCamera.Gain].GetMaximum();
                    if (cameras[nCamID].Parameters[PLCamera.Gain].IsReadable)
                    {
                        if (dGain >= minGain && dGain <= maxGain)
                        {
                            cameras[nCamID].Parameters[PLCamera.Gain].SetValue(dGain);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                StaticFun.MessageFun.ShowMessage("设置增益失败！" + ex.ToString());
            }
        }
        /// <summary>
        /// 关闭相机,释放相关资源
        /// </summary>
        public static void Close()
        {
            for (int i = 0; i < cameras.Count; i++)
            {
                stop(i);
                cameras[i].Close();
            }
        }
        public static CamCommon.CamParam GetCamParam(int camID)
        {
            CamCommon.CamParam camParam = new CamCommon.CamParam();
            try
            {
                //帧率
                //camParam.frame = (float)(Math.Round(Basler.GetFPS(camID), 2));
                //增益
                camParam.gain = (float)(Basler.GetGain(camID));
                //曝光
                camParam.exposure = (float)(Basler.GetExposureTime(camID));

            }
            catch (SystemException ex)
            {
                StaticFun.MessageFun.ShowMessage(ex.ToString());
            }
            return camParam;
        }
        //设置为触发模式
        public static bool SetTriggerMode(int nCamID, int TriggerModeNum)//设置触发模式
        {
            //1:为On 触发模式
            //0:Off 触发模式
            try
            {
                cameras[nCamID].Parameters[PLCamera.TriggerSelector].SetValue(PLCamera.TriggerSelector.FrameStart);
                cameras[nCamID].Parameters[PLCamera.TriggerMode].TrySetValue(PLCamera.TriggerMode.On);
                cameras[nCamID].Parameters[PLCamera.TriggerSource].TrySetValue(PLCamera.TriggerSource.Software);
                return true;
            }
            catch
            {
                return false;
            }
        }
        //执行一次软触发
        public static void SoftwareTrigger(int nCamID)
        {
            try
            {
                if (cameras[nCamID].Parameters[PLCamera.TriggerMode].GetValueOrDefault(PLCamera.TriggerMode.Off) == PLCamera.TriggerMode.Off)
                {
                    StaticFun.MessageFun.ShowMessage("相机" + nCamID + "未设置为触发！" , "相机" + nCamID + "未设置为触发！", System.Drawing.Color.Red);
                    return; // Do nothing if the trigger is disabled.
                }
                // Some camera models don't signal their FrameTriggerReady state.
                if (cameras[nCamID].CanWaitForFrameTriggerReady)
                {
                    cameras[nCamID].WaitForFrameTriggerReady(1000, TimeoutHandling.ThrowException);
                }
                cameras[nCamID].ExecuteSoftwareTrigger();
            }
            catch (Exception error)
            {
                StaticFun.MessageFun.ShowMessage("相机"+ nCamID+"触发失败！" + error.ToString(), "相机" + nCamID + "触发失败！" + error.ToString(), System.Drawing.Color.Red);
            }

        }
    }
}

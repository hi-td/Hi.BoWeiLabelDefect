using Hi.Ltd;
using MVSDK;
using System;
using System.Collections.Generic;
using VisionPlatform;

namespace CamSDK
{
    public class CamCommon
    {

        public struct CamParam
        {
            public float exposure;   //曝光
            public float gain;       //增益
            public float frame;      //帧率
        }
        public static Dictionary<string,int> m_listCamSer = new Dictionary<string,int>();//相机名称列表，添加到comboBox控件，后续所有list的顺序与此变量保持一致
        public static bool[] m_bOpen;                 //相机是否打开
        public static bool[] m_bLive;                 //相机是否处于实时显示状态
        public static bool[] m_bTriggerMode;           //相机是否处于触发状态
        public static EnumData.CamBrand m_camBrand = EnumData.CamBrand.DaHeng; //当前使用的相机品牌，默认为大恒（2022.10.14修改）

        /// <summary>
        /// //枚举所有相机，但并未打开实时显示
        /// </summary>
        public static void EnumCams()
        {
            try
            {
                EnumData.CamBrand camBrand = GlobalData.Config._InitConfig.initConfig.camBrand;
                if (camBrand == EnumData.CamBrand.DaHeng)
                {
                    DaHengCam.__EnumDevice();
                }
                else if (camBrand == EnumData.CamBrand.HiKVision)
                {
                    HikVisionCam.DeviceListAcq();
                    HikVisionCam.OpenListDevice();
                }
                else if (camBrand == EnumData.CamBrand.DaHua)
                {
                    DaHuaCam.EnumCameras();
                }
                else if (camBrand == EnumData.CamBrand.MindVision)
                {
                    MindVision.EnumDeviceMV();
                }
                else if (camBrand == EnumData.CamBrand.Other)
                {
                    //Basler.Enumerate();
                }
                else
                {
                    "错误的相机品牌".Log();
                    return;
                }
                if (m_listCamSer.Count > 0)
                {
                    m_bOpen = new bool[m_listCamSer.Count];
                    m_bLive = new bool[m_listCamSer.Count];
                    m_bTriggerMode = new bool[m_listCamSer.Count];
                }
            }
            catch (Exception ex)
            {
                StaticFun.MessageFun.ShowMessage(ex.Message);
            }
        }
        //打开相机
        public static void OpenCam(string strCamSer, Function fun)
        {
            try
            {
                int camID = GetCamID(strCamSer);
                if (-1 == camID)
                {
                    return;
                }
                if (m_bOpen[camID])
                {
                    StopLive(strCamSer);
                }
                EnumData.CamBrand camBrand = GlobalData.Config._InitConfig.initConfig.camBrand;
                if (camBrand == EnumData.CamBrand.DaHeng)
                {
                    DaHengCam.OpenDevice(camID, fun);
                    //if (DataSerializer._globalData.camParam.ContainsKey(strCamSer))
                    //{
                    //    DaHengCam.SetShutter(camID, DataSerializer._globalData.camParam[strCamSer].exposure);
                    //    DaHengCam.SetGain(camID, DataSerializer._globalData.camParam[strCamSer].gain);
                    //}
                }
                else if (camBrand == EnumData.CamBrand.HiKVision)
                {
                    HikVisionCam.LiveThread(camID, fun);
                    //if (DataSerializer._globalData.camParam.ContainsKey(strCamSer))
                    //{
                    //    HikVisionCam.Exposure(camID,(int)DataSerializer._globalData.camParam[strCamSer].exposure);
                    //}
                }
                else if (camBrand == EnumData.CamBrand.DaHua)
                {
                    DaHuaCam.OpenCam(camID, fun);
                    //if (DataSerializer._globalData.dicImageing.ContainsKey(strCamSer))
                    //{
                    //    DaHuaCam.SetExposure(camID,(int)DataSerializer._globalData.camParam[strCamSer].exposure);
                    //    DaHuaCam.SetGain(camID, (int)DataSerializer._globalData.camParam[strCamSer].gain);
                    //}

                }
                else if (camBrand == EnumData.CamBrand.MindVision)
                {
                    MindVision.LiveThread(camID, fun);
                    //if (DataSerializer._globalData.camParam.ContainsKey(strCamSer))
                    //{
                    //    MindVision.SetShutter(camID, (int)DataSerializer._globalData.camParam[strCamSer].exposure);
                    //    MindVision.SetGain(camID, (int)DataSerializer._globalData.camParam[strCamSer].gain);
                    //}
                }
                else if (camBrand == EnumData.CamBrand.Other)
                {
                    //Basler.OpenDevice(camID, fun);
                    //if (TMData_Serializer._globalData.camParam.ContainsKey(strCamSer))
                    //{
                    //    Basler.SetExposureTime(camID,(int)TMData_Serializer._globalData.camParam[strCamSer].exposure);
                    //    Basler.SetGain(camID, (int)TMData_Serializer._globalData.camParam[strCamSer].gain);
                    //}
                }
                else
                {
                    StaticFun.MessageFun.ShowMessage("无法识别的相机品牌。");
                    return;
                }
                m_bOpen[camID] = true;

            }
            catch (Exception ex)
            {
                StaticFun.MessageFun.ShowMessage(ex.Message);
            }
        }

        //实时显示
        public static void Live(string strCamSer)
        {
            try
            {
                int camID = GetCamID(strCamSer);
                if (-1 == camID) return;
                EnumData.CamBrand camBrand = GlobalData.Config._InitConfig.initConfig.camBrand;
                if (camBrand == EnumData.CamBrand.DaHeng)
                {
                    if (m_bLive[camID])
                    {
                        DaHengCam.StopDevice(camID);
                    }
                    DaHengCam.Live(camID);
                }
                else if (camBrand == EnumData.CamBrand.HiKVision)
                {
                    HikVisionCam.Live(camID);
                }
                else if (camBrand == EnumData.CamBrand.DaHua)
                {
                    DaHuaCam.Live(camID);
                }
                else if (camBrand == EnumData.CamBrand.MindVision)
                {
                    MindVision.Live(camID);
                }
                else if (camBrand == EnumData.CamBrand.Other)
                {
                    //Basler.Live(camID);
                }
                else
                {
                    StaticFun.MessageFun.ShowMessage("无法识别的相机品牌。");
                    return;
                }
                m_bLive[camID] = true;
            }
            catch (Exception ex)
            {
                StaticFun.MessageFun.ShowMessage(ex.Message);
            }
        }

        //停止实时显示
        public static void StopLive(string strCamSer)
        {
            try
            {
                int camID = GetCamID(strCamSer);
                if (-1 == camID) return;
                EnumData.CamBrand camBrand = GlobalData.Config._InitConfig.initConfig.camBrand;
                if (camBrand == EnumData.CamBrand.DaHeng)
                {
                    DaHengCam.StopDevice(camID);
                }
                else if (camBrand == EnumData.CamBrand.HiKVision)
                {
                    HikVisionCam.StopLive(camID);
                }
                else if (camBrand == EnumData.CamBrand.DaHua)
                {
                    DaHuaCam.StopGrab(camID);
                }
                else if (camBrand == EnumData.CamBrand.MindVision)
                {
                    MindVision.StopLiveAll();
                }
                else if (camBrand == EnumData.CamBrand.Other)
                {
                    //Basler.stop(camID);
                }
                else
                {
                    StaticFun.MessageFun.ShowMessage("无法识别的相机品牌。");
                    return;
                }
                m_bLive[camID] = false;
                m_bOpen[camID] = false;
            }
            catch (Exception ex)
            {
                StaticFun.MessageFun.ShowMessage(ex.Message);
            }
        }
        //停止所有相机的实时模式：改为触发模式
        public static void StopLiveAll()
        {
            try
            {
                EnumData.CamBrand camBrand = GlobalData.Config._InitConfig.initConfig.camBrand;
                if (camBrand == EnumData.CamBrand.DaHeng)
                {
                    DaHengCam.StopLiveAll();
                }
                else if (camBrand == EnumData.CamBrand.HiKVision)
                {
                    //HikVisionCam.StopLiveAll();
                }
                else if (camBrand == EnumData.CamBrand.DaHua)
                {
                    //DahuaCamera.StopGrab(camID);
                }
                else if (camBrand == EnumData.CamBrand.MindVision)
                {
                    MindVision.TriggerAll();
                }
                else if (camBrand == EnumData.CamBrand.Other)
                {
                    //MindVision.TriggerAll();
                }
                else
                {
                    StaticFun.MessageFun.ShowMessage("无法识别的相机品牌。");
                    return;
                }
                m_bLive = new bool[GlobalData.Config._InitConfig.initConfig.CamNum];
            }
            catch (Exception ex)
            {
                StaticFun.MessageFun.ShowMessage(ex.Message);
                ex.Message.Log();
            }
        }
        //拍照:软触发
        public static void GrabImage(string strCamSer)
        {

            try
            {
                int camID = GetCamID(strCamSer);
                if (-1 == camID) return;
                EnumData.CamBrand camBrand = GlobalData.Config._InitConfig.initConfig.camBrand;
                if (camBrand == EnumData.CamBrand.DaHeng)
                {
                    DaHengCam.GrabImage(camID);
                }
                else if (camBrand == EnumData.CamBrand.HiKVision)
                {
                    HikVisionCam.GrabImage(camID);
                }
                else if (camBrand == EnumData.CamBrand.DaHua)
                {
                    DaHuaCam.GrabImage(camID);
                }
                else if (camBrand == EnumData.CamBrand.MindVision)
                {
                    MindVision.GrabImage(camID);
                }
                else if (camBrand == EnumData.CamBrand.Other)
                {
                    //Basler.GrabImage(camID);
                }
                else
                {
                    StaticFun.MessageFun.ShowMessage("无法识别的相机品牌。");
                    return;
                }
                m_bLive[camID] = false;
            }
            catch (Exception ex)
            {
                StaticFun.MessageFun.ShowMessage(ex.Message);
            }

        }
        //抓图停止
        public static void GrabImagestop(string strCamSer)
        {

            try
            {
                int camID = GetCamID(strCamSer);
                if (-1 == camID) return;
                EnumData.CamBrand camBrand = GlobalData.Config._InitConfig.initConfig.camBrand;
                if (camBrand == EnumData.CamBrand.DaHeng)
                {
                    DaHengCam.TouchImage(camID);
                }
                else if (camBrand == EnumData.CamBrand.HiKVision)
                {
                    HikVisionCam.GrabImage(camID);
                }
                else if (camBrand == EnumData.CamBrand.DaHua)
                {
                    DaHuaCam.StopGrab(camID);
                }
                else if (camBrand == EnumData.CamBrand.MindVision)
                {
                }
                else if (camBrand == EnumData.CamBrand.Other)
                {
                    //Basler.stop(camID);
                }
                else
                {
                    StaticFun.MessageFun.ShowMessage("无法识别的相机品牌。");
                    return;
                }
                m_bLive[camID] = false;
            }
            catch (Exception ex)
            {
                StaticFun.MessageFun.ShowMessage(ex.Message);
            }

        }
        /// <summary>
        /// 设置相机的触发模式
        /// </summary>
        /// <param name="strCamSer"></param> 相机的序列号
        /// <param name="bTriggerMode"></param> true:软触发，false:外触发
        public static void SetTriggerMode(string strCamSer, bool bTriggerMode)
        {
            try
            {
                int camID = GetCamID(strCamSer);
                if (-1 == camID) return;
                EnumData.CamBrand camBrand = GlobalData.Config._InitConfig.initConfig.camBrand;
                if (camBrand == EnumData.CamBrand.DaHeng)
                {
                    //DaHengCam.GrabImage(camID);
                    m_bLive[camID] = false;
                    return;
                }
                else if (camBrand == EnumData.CamBrand.HiKVision)
                {
                    HikVisionCam.SetTriggerMode(camID, bTriggerMode);
                    m_bTriggerMode[camID] = bTriggerMode;
                    m_bLive[camID] = false;
                    return;
                }
                else if (camBrand == EnumData.CamBrand.DaHua)
                {
                    DaHuaCam.GrabImage(camID);
                    m_bLive[camID] = false;
                    return;
                }
                else if (camBrand == EnumData.CamBrand.MindVision)
                {
                    return;
                }
                else if (camBrand == EnumData.CamBrand.Other)
                {
                    return;

                }
                else
                {
                    StaticFun.MessageFun.ShowMessage("无法识别的相机品牌。");
                    return;
                }
               
            }
            catch (Exception ex)
            {
                StaticFun.MessageFun.ShowMessage(ex.Message);
            }
        }

        //获取相机的曝光、增益和帧率等参数
        public static CamParam GetCamParam(string strCamSer)
        {
            CamParam camParam = new CamParam();

            try
            {
                int camID = GetCamID(strCamSer);
                if (-1 == camID) return camParam;
                EnumData.CamBrand camBrand = GlobalData.Config._InitConfig.initConfig.camBrand;
                if (camBrand == EnumData.CamBrand.DaHeng)
                {
                    camParam = DaHengCam.GetCamParam(camID);
                }
                else if (camBrand == EnumData.CamBrand.HiKVision)
                {
                    camParam = HikVisionCam.GetCamParam(camID);
                }
                else if (camBrand == EnumData.CamBrand.DaHua)
                {
                    camParam = DaHuaCam.GetCamParam(camID);
                }
                else if (camBrand == EnumData.CamBrand.MindVision)
                {
                    camParam = MindVision.GetCamParam(camID);
                }
                else if (camBrand == EnumData.CamBrand.Other)
                {
                    //camParam = Basler.GetCamParam(camID);
                }
                else
                {
                    StaticFun.MessageFun.ShowMessage("无法识别的相机品牌。");

                }
            }
            catch (Exception ex)
            {
                StaticFun.MessageFun.ShowMessage(ex.Message);
            }
            return camParam;
        }

        public static void SetExposure(string strCamSer, int value)
        {
            try
            {
                int camID = GetCamID(strCamSer);
                if (-1 == camID) return;
                EnumData.CamBrand camBrand = GlobalData.Config._InitConfig.initConfig.camBrand;
                if (camBrand == EnumData.CamBrand.DaHeng)
                {
                    DaHengCam.SetShutter(camID, value);
                }
                else if (camBrand == EnumData.CamBrand.HiKVision)
                {
                    HikVisionCam.Exposure(camID, value);
                }
                else if (camBrand == EnumData.CamBrand.DaHua)
                {
                    DaHuaCam.SetExposure(camID, value);
                }
                else if (camBrand == EnumData.CamBrand.MindVision)
                {
                    MindVision.SetShutter(camID, value);
                }
                else if (camBrand == EnumData.CamBrand.Other)
                {
                    //Basler.SetExposureTime(camID, value);
                }
                else
                {
                    StaticFun.MessageFun.ShowMessage("无法识别的相机品牌。");
                    return;
                }
            }
            catch (Exception ex)
            {
                StaticFun.MessageFun.ShowMessage(ex.Message);
            }
        }

        public static void SetGain(string strCamSer, int value)
        {
            try
            {
                int camID = GetCamID(strCamSer);
                if (-1 == camID) return;
                EnumData.CamBrand camBrand = GlobalData.Config._InitConfig.initConfig.camBrand;
                if (camBrand == EnumData.CamBrand.DaHeng)
                {
                    DaHengCam.SetGain(camID, value);
                }
                else if (camBrand == EnumData.CamBrand.HiKVision)
                {
                    HikVisionCam.Gain(camID, value);
                }
                else if (camBrand == EnumData.CamBrand.DaHua)
                {
                    DaHuaCam.SetGain(camID, value);
                }
                else if (camBrand == EnumData.CamBrand.MindVision)
                {
                    MindVision.SetGain(camID, value);
                }
                else if (camBrand == EnumData.CamBrand.Other)
                {
                    //Basler.SetGain(camID, value);
                }
                else
                {
                    StaticFun.MessageFun.ShowMessage("无法识别的相机品牌。");
                    return;
                }
            }
            catch (Exception ex)
            {
                StaticFun.MessageFun.ShowMessage(ex.Message);
            }
        }

        public static void CloseAllCam()
        {
            try
            {
                EnumData.CamBrand camBrand = GlobalData.Config._InitConfig.initConfig.camBrand;
                if (camBrand == EnumData.CamBrand.DaHeng)
                {
                    DaHengCam.__CloseAll();
                }
                else if (camBrand == EnumData.CamBrand.HiKVision)
                {
                    HikVisionCam.DestroyDev();
                }
                else if (camBrand == EnumData.CamBrand.DaHua)
                {
                    DaHuaCam.CloseCam();
                }
                else if (camBrand == EnumData.CamBrand.MindVision)
                {
                    MindVision.DestroyDev();
                }
                else if (camBrand == EnumData.CamBrand.Other)
                {
                    //Basler.Close();
                }
                else
                {
                    StaticFun.MessageFun.ShowMessage("无法识别的相机品牌。");
                    return;
                }
            }
            catch (Exception ex)
            {
                StaticFun.MessageFun.ShowMessage(ex.Message);
            }
        }

        public static void ReConnect()
        {
            try
            {
                CloseAllCam();
                EnumCams();
            }
            catch (Exception ex)
            {
                StaticFun.MessageFun.ShowMessage(ex.Message);
            }
        }

        private static int GetCamID(string strCamSer)
        {
            int camID = -1;
            try
            {
                if (m_listCamSer.ContainsKey(strCamSer))
                {
                    camID=m_listCamSer[strCamSer];
                    return camID;
                }
                return -1;
            }
            catch (Exception ex)
            {
                StaticFun.MessageFun.ShowMessage(ex.Message);
                return -1;
            }           
        }
        public static void GetCapability(string strCamSer, out tSdkCameraCapbility tCameraCapability)
        {
            int camID = GetCamID(strCamSer);
            MindVision.GetCapability(camID, out tCameraCapability);
        }
        public static void SetIOState(string strCamSer, int iPoint, bool bState)
        {
            int camID = GetCamID(strCamSer);
            MindVision.SetIOState(camID, iPoint, bState);
        }
        public static void GetIOState(string strCamSer, int iPoint, ref uint bchek)
        {
            int camID = GetCamID(strCamSer);
            MindVision.GetIOState(camID, iPoint, ref bchek);
        }




    }
}

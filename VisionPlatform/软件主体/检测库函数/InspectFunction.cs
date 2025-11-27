using Aardvark.Base;
using BaseData;
using CamSDK;
using DAL;
using HalconDotNet;
using Hi.Ltd;
using Hi.Ltd.Enumerations;
using StaticFun;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VisionPlatform.Auxiliary;
using VisionPlatform.Tables;
using VisionPlatform.软件主体.检测功能配置;
using WENYU_IO;
using static VisionPlatform.InspectData;
using static VisionPlatform.语音提示.Warning;
using Address = Hi.Ltd.Data.Address;

namespace VisionPlatform
{
    public class InspectFunction : Function
    {
        public FrontFun myFrontFun = new FrontFun();
        public LEDControl myLEDCtrl = new LEDControl();
        public int NGadd = 0;      //连续报警次数
        public static bool isAuto = false;
        ushort[] registerBufferOK = new ushort[1] { 1 };
        ushort[] registerBufferNG = new ushort[1] { 0 };
        ushort[] registerBufferFinish = new ushort[1] { 1 };
        ushort[] registerBuffer = new ushort[1] { 0 };
        public static Dictionary<InspectData.CamInspectItem, CtrlStates> m_ListFormSTATS = new Dictionary<InspectData.CamInspectItem, CtrlStates>(); //计数用form窗体个数
        public static CtrlImageSave myCtrlImageSave = new CtrlImageSave();             //图像保存控件
        public static CtrlOK_NG myCtrlOK_NG = new CtrlOK_NG();             //图像保存控件
        public InspectFunction(HWindowControl hWndCtrl)
        {
            if (hWndCtrl != null)
            {
                //获取WindowControl的句柄
                HWndCtrl = hWndCtrl;
                HWnd = HWndCtrl.HalconWindow;
                HWnd.SetColor("red");
                HWnd.SetDraw("margin");
            }
            myFrontFun.InitFunction(this);
        }
        ~InspectFunction() { GC.Collect(); }

        public static string GetStrCheckItem(InspectItem item)
        {
            string str = "";
            try
            {
                switch (item)
                {
                    case InspectItem.Front:
                        str = GlobalData.Config._language == EnumData.Language.english ? "Front Insepct" : "正面检测";
                        break;
                    case InspectItem.LeftSide:
                        str = GlobalData.Config._language == EnumData.Language.english ? "LeftSide Insepct" : "左侧检测";
                        break;
                    case InspectItem.RightSide:
                        str = GlobalData.Config._language == EnumData.Language.english ? "RightSide Insepct" : "右侧检测";
                        break;
                    default:
                        str = "";
                        break;
                }
            }
            catch (SystemException error)
            {
                MessageFun.ShowMessage(error);
            }
            return str;
        }

        public static InspectData.InspectItem GetEnumCheckItem(string str)
        {
            InspectData.InspectItem item = new InspectItem();
            try
            {
                switch (str)
                {
                    case "正面检测":
                        item = InspectItem.Front;
                        break;
                    case "左侧检测":
                        item = InspectItem.LeftSide;
                        break;
                    case "右侧检测":
                        item = InspectItem.RightSide;
                        break;
                    case "Front Inspect":
                        item = InspectItem.Front;
                        break;
                    case "LeftSide Inspect":
                        item = InspectItem.LeftSide;
                        break;
                    case "RightSide Inspect":
                        item = InspectItem.RightSide;
                        break;
                    default:
                        item = InspectItem.Default;
                        break;
                }
            }
            catch (SystemException error)
            {
                MessageFun.ShowMessage(error);
            }
            return item;
        }

        public static void GetCameraNum(string text, out int cam, out int sub_cam)
        {
            cam = 0;
            sub_cam = 0;
            try
            {
                if (GlobalData.Config._language == EnumData.Language.english)
                {
                    cam = int.Parse(text.Substring(6, 1));
                    if (text.Length > 7)
                    {
                        sub_cam = int.Parse(text.Substring(8, 1));
                    }
                }
                else
                {
                    cam = int.Parse(text.Substring(2, 1));
                    if (text.Length > 3)
                    {
                        sub_cam = int.Parse(text.Substring(3, 1));
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void GetIOPoint(CamInspectItem camItem, out int readIO, out IOSend sendIO)
        {
            readIO = -1;
            sendIO = new IOSend();
            sendIO.sendOK = -1;
            sendIO.sendNG = -1;
            try
            {
                bool bContains = false;
                foreach (IOSet ioSet in DataSerializer._COMConfig.listIOSet)
                {
                    if (ioSet.camItem.cam == camItem.cam && ioSet.camItem.item == camItem.item)
                    {
                        readIO = ioSet.read;
                        sendIO = ioSet.send;
                        bContains = true;
                    }
                }
                if (!bContains)
                {
                    string sendMessage = "";
                    if (GlobalData.Config._language == EnumData.Language.english)
                    {
                        sendMessage = "Camera" + camItem.ten().ToString();
                        if (camItem.unit() != 0)
                        {
                            sendMessage = sendMessage + "_" + camItem.unit().ToString();
                        }
                        sendMessage = sendMessage + "No[" + GetStrCheckItem(camItem.item) + "]IO configuration!";
                    }
                    else
                    {
                        sendMessage = "相机" + camItem.ten().ToString();
                        if (camItem.unit() != 0)
                        {
                            sendMessage = sendMessage + "_" + camItem.unit().ToString();
                        }
                        sendMessage = sendMessage + "无【" + GetStrCheckItem(camItem.item) + "】IO配置！";
                    }
                    MessageFun.ShowMessage(sendMessage);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageFun.ShowMessage("获取相机" + camItem.cam.ToString() + "【" + GetStrCheckItem(camItem.item) + "】IO点位错误：" + ex.ToString(), true, strEnglish: "Get Camera" + camItem.cam.ToString() + "[" + GetStrCheckItem(camItem.item) + "]IO point error:" + ex.ToString());
            }
        }
        /// <summary>
        /// IO通讯
        /// </summary>
        /// <param name="cam"></param> 
        /// <param name="sub_cam"></param>
        /// <param name="strCamSer"></param>
        public void RunCam_IO(int cam, int sub_cam, string strCamSer, params object[] signal)
        {
            int bit1 = -1, bit2 = -1, bit3 = -1, bit4 = -1, bit5 = -1;
            bool BTF1 = false;
            bool BTF2 = false;
            bool BTF3 = false;
            bool BTF4 = false;
            bool BTF5 = false;
            InspectData.CamInspectItem camItem1_stripLen = new InspectData.CamInspectItem();
            InspectData.CamInspectItem camItem1_Rubber = new InspectData.CamInspectItem();
            InspectData.CamInspectItem camItem1_TM = new InspectData.CamInspectItem();
            InspectData.CamInspectItem camItem1_LineColor = new InspectData.CamInspectItem();
            InspectData.CamInspectItem camItem1_RubberSide = new InspectData.CamInspectItem();
            Dictionary<int, int> dicCH_open_stripLen = new Dictionary<int, int>();
            Dictionary<int, int> dicCH_open_Rubber = new Dictionary<int, int>();
            Dictionary<int, int> dicCH_open_TM = new Dictionary<int, int>();
            Dictionary<int, int> dicCH_open_LineColor = new Dictionary<int, int>();
            Dictionary<int, int> dicCH_open_RubberSide = new Dictionary<int, int>();
            Dictionary<int, int> dicCH_close_stripLen = new Dictionary<int, int>();
            Dictionary<int, int> dicCH_close_Rubber = new Dictionary<int, int>();
            Dictionary<int, int> dicCH_close_TM = new Dictionary<int, int>();
            Dictionary<int, int> dicCH_close_LineColor = new Dictionary<int, int>();
            Dictionary<int, int> dicCH_close_RubberSide = new Dictionary<int, int>();
            object lc_write = new object();
            bool[] bCheckList = new bool[5];
            int[] readIO = new int[5];
            InspectData.IOSend[] sendIO = new InspectData.IOSend[5];

            try
            {
                int ncam = cam * 10 + sub_cam;
                camItem1_stripLen.cam = ncam;
                camItem1_Rubber.cam = ncam;
                camItem1_TM.cam = ncam;
                camItem1_LineColor.cam = ncam;
                camItem1_RubberSide.cam = ncam;
                if (!DataSerializer._globalData.dicInspectList.ContainsKey(ncam))
                {
                    MessageFun.ShowMessage($"未给相机{ncam}配置检测项！", false, strEnglish: "No Detection item provided to camera" + ncam.ToString());
                    return;
                }
                List<InspectData.InspectItem> listItems = DataSerializer._globalData.dicInspectList[ncam];
                //LEDSet.myLEDCtrl.SetLEDCH(cam, out int[] nSetLed, out Dictionary<int, List<int>> nDelLed);
                foreach (InspectData.InspectItem item in listItems)
                {
                    //if (item == InspectData.InspectItem.MultiStripLen)
                    //{
                    //    bCheckList[0] = true;
                    //    camItem1_stripLen.item = InspectData.InspectItem.MultiStripLen;
                    //    GetIOPoint(camItem1_stripLen, out readIO[0], out sendIO[0]);
                    //    //光源控制
                    //   // myLEDCtrl.GetLightCH(camItem1_stripLen, out dicCH_open_stripLen, out dicCH_close_stripLen);
                    //}
                    //if (item == InspectData.InspectItem.Rubber)
                    //{
                    //    bCheckList[1] = true;
                    //    camItem1_Rubber.item = InspectData.InspectItem.Rubber;
                    //    GetIOPoint(camItem1_Rubber, out readIO[1], out sendIO[1]);
                    //    //光源控制
                    //    //myLEDCtrl.GetLightCH(camItem1_Rubber, out dicCH_open_Rubber, out dicCH_close_Rubber);
                    //}
                    //if (item == InspectData.InspectItem.MultiTM)
                    //{
                    //    bCheckList[2] = true;
                    //    camItem1_TM.item = InspectData.InspectItem.MultiTM;
                    //    GetIOPoint(camItem1_TM, out readIO[2], out sendIO[2]);
                    //    //光源控制
                    //    //myLEDCtrl.GetLightCH(camItem1_TM, out dicCH_open_TM, out dicCH_close_TM);
                    //}
                    //if (item == InspectData.InspectItem.LineColor)
                    //{
                    //    bCheckList[3] = true;
                    //    camItem1_LineColor.item = InspectData.InspectItem.LineColor;
                    //    GetIOPoint(camItem1_LineColor, out readIO[3], out sendIO[3]);
                    //    //光源控制
                    //    //myLEDCtrl.GetLightCH(camItem1_LineColor, out dicCH_open_LineColor, out dicCH_close_LineColor);
                    //}
                    //if (item == InspectData.InspectItem.RubberSide)
                    //{
                    //    bCheckList[4] = true;
                    //    camItem1_RubberSide.item = InspectData.InspectItem.RubberSide;
                    //    GetIOPoint(camItem1_RubberSide, out readIO[4], out sendIO[4]);
                    //    //光源控制
                    //    //myLEDCtrl.GetLightCH(camItem1_RubberSide, out dicCH_open_RubberSide, out dicCH_close_RubberSide);
                    //}
                }
                while (isAuto)
                {
                    //lock (lc_write)
                    //{
                    //剥皮检测
                    if (bCheckList[0] && 0 == WENYU.ReadIO(readIO[0], ref bit1))
                    {
                        if (bit1 == 0 && !BTF1)
                        {
                            //MessageFun.ShowMessage("剥皮信号读取成功");
                            BTF1 = true;
                        }
                        else if (bit1 == 1)
                        {
                            BTF1 = false;
                        }

                    }
                    //插壳检测
                    if (bCheckList[1] && 0 == WENYU.ReadIO(readIO[1], ref bit2))
                    {
                        if (bit2 == 0 && !BTF2)
                        {
                            BTF2 = true;
                            // myLEDCtrl.SetLED(dicCH_open_Rubber, dicCH_close_Rubber);
                            Thread.Sleep(30);
                            //Inspect(camItem1_Rubber, strCamSer);
                            // myLEDCtrl.LEDOff(dicCH_open_Rubber);
                        }
                        else if (bit2 == 1)
                        {
                            BTF2 = false;
                        }
                    }
                    //打端检测
                    if (bCheckList[2] && 0 == WENYU.ReadIO(readIO[2], ref bit3))
                    {
                        if (bit3 == 0 && !BTF3)
                        {
                            BTF3 = true;
                            // myLEDCtrl.SetLED(dicCH_open_TM, dicCH_close_TM);
                            //Thread.Sleep(10);
                            //Inspect(camItem1_TM, strCamSer);
                            // myLEDCtrl.LEDOff(dicCH_open_TM);
                        }
                        else if (bit3 == 1)
                        {
                            BTF3 = false;
                        }
                    }
                    //线序检测
                    if (bCheckList[3] && 0 == WENYU.ReadIO(readIO[3], ref bit4))
                    {
                        if (bit4 == 0 && !BTF4)
                        {
                            BTF4 = true;
                            //myLEDCtrl.SetLED(dicCH_open_LineColor, dicCH_close_LineColor);
                            Thread.Sleep(10);
                            //MessageFun.ShowMessage("加60ms延时");
                            //Inspect(camItem1_LineColor, strCamSer);
                            // myLEDCtrl.LEDOff(dicCH_open_LineColor);
                        }
                        else if (bit4 == 1)
                        {
                            BTF4 = false;
                        }
                    }
                    //插壳检测-侧面
                    if (bCheckList[4] && 0 == WENYU.ReadIO(readIO[4], ref bit5))
                    {
                        if (bit5 == 0 && !BTF5)
                        {
                            BTF5 = true;
                            // myLEDCtrl.SetLED(dicCH_open_RubberSide, dicCH_close_RubberSide);
                            Thread.Sleep(10);
                            //Inspect(camItem1_RubberSide, strCamSer);
                            // myLEDCtrl.LEDOff(dicCH_open_RubberSide);
                        }
                        else if (bit5 == 1)
                        {
                            BTF5 = false;
                        }
                    }

                }
                Thread.Sleep(2);
                //}
            }
            catch (SystemException error)
            {
                ("[FormHome]->[Run]:/t" + error.Message + Environment.NewLine + error.StackTrace).Log();

            }
        }

        public void RunCam_CamIO(int cam, int sub_cam, string strCamSer)
        {
            int bit1 = -1, bit2 = -1, bit3 = -1, bit4 = -1;
            bool BTF1 = false;
            bool BTF2 = false;
            bool BTF3 = false;
            bool BTF4 = false;
            InspectData.CamInspectItem camItem1_stripLen = new InspectData.CamInspectItem();
            InspectData.CamInspectItem camItem1_Rubber = new InspectData.CamInspectItem();
            InspectData.CamInspectItem camItem1_TM = new InspectData.CamInspectItem();
            InspectData.CamInspectItem camItem1_LineColor = new InspectData.CamInspectItem();
            Dictionary<int, int> dicCH_open_stripLen = new Dictionary<int, int>();
            Dictionary<int, int> dicCH_open_Rubber = new Dictionary<int, int>();
            Dictionary<int, int> dicCH_open_TM = new Dictionary<int, int>();
            Dictionary<int, int> dicCH_open_LineColor = new Dictionary<int, int>();
            Dictionary<int, int> dicCH_close_stripLen = new Dictionary<int, int>();
            Dictionary<int, int> dicCH_close_Rubber = new Dictionary<int, int>();
            Dictionary<int, int> dicCH_close_TM = new Dictionary<int, int>();
            Dictionary<int, int> dicCH_close_LineColor = new Dictionary<int, int>();
            object lc_write = new object();
            bool[] bCheckList = new bool[4];
            int[] readIO = new int[4];
            InspectData.IOSend[] sendIO = new InspectData.IOSend[4];

            try
            {
                int ncam = cam * 10 + sub_cam;
                camItem1_stripLen.cam = ncam;
                // camItem1_stripLen.sub_cam = sub_cam;
                camItem1_Rubber.cam = ncam;
                //camItem1_Rubber.sub_cam = sub_cam;
                camItem1_TM.cam = ncam;
                // camItem1_TM.sub_cam = sub_cam;
                camItem1_LineColor.cam = ncam;
                // camItem1_LineColor.sub_cam = sub_cam;
                if (!DataSerializer._globalData.dicInspectList.ContainsKey(ncam))
                {
                    MessageFun.ShowMessage($"未给相机{ncam}配置检测项！", false, strEnglish: "No detection item provided to camera" + ncam);
                    return;
                }
                List<InspectData.InspectItem> listItems = DataSerializer._globalData.dicInspectList[ncam];
                //LEDSet.myLEDCtrl.SetLEDCH(cam, out int[] nSetLed, out Dictionary<int, List<int>> nDelLed);
                foreach (InspectData.InspectItem item in listItems)
                {
                    //if (item == InspectData.InspectItem.MultiStripLen)
                    //{
                    //    bCheckList[0] = true;
                    //    camItem1_stripLen.item = InspectData.InspectItem.MultiStripLen;
                    //    GetIOPoint(camItem1_stripLen, out readIO[0], out sendIO[0]);
                    //    //光源控制
                    //    //myLEDCtrl.GetLightCH(camItem1_stripLen, out dicCH_open_stripLen, out dicCH_close_stripLen);
                    //}
                    //if (item == InspectData.InspectItem.Rubber)
                    //{
                    //    bCheckList[1] = true;
                    //    camItem1_Rubber.item = InspectData.InspectItem.Rubber;
                    //    GetIOPoint(camItem1_Rubber, out readIO[1], out sendIO[1]);
                    //    //光源控制
                    //    //myLEDCtrl.GetLightCH(camItem1_Rubber, out dicCH_open_Rubber, out dicCH_close_Rubber);
                    //}
                    //if (item == InspectData.InspectItem.MultiTM)
                    //{
                    //    bCheckList[2] = true;
                    //    camItem1_TM.item = InspectData.InspectItem.MultiTM;
                    //    GetIOPoint(camItem1_TM, out readIO[2], out sendIO[2]);
                    //    //光源控制
                    //    //myLEDCtrl.GetLightCH(camItem1_TM, out dicCH_open_TM, out dicCH_close_TM);
                    //}
                    //if (item == InspectData.InspectItem.LineColor)
                    //{
                    //    bCheckList[3] = true;
                    //    camItem1_LineColor.item = InspectData.InspectItem.LineColor;
                    //    GetIOPoint(camItem1_LineColor, out readIO[3], out sendIO[3]);
                    //    //光源控制
                    //    //myLEDCtrl.GetLightCH(camItem1_LineColor, out dicCH_open_LineColor, out dicCH_close_LineColor);
                    //}

                }
                while (isAuto)
                {
                    //lock (lc_write)
                    //{
                    uint bchek1 = 1, bchek2 = 1, bchek3 = 1, bchek4 = 1;
                    //剥皮检测
                    if (bCheckList[0] && 0 == AllCamIO.ReadCamIO(strCamSer, readIO[0], ref bchek1))
                    {
                        if (bchek1 == 0 && !BTF1)
                        {
                            BTF1 = true;
                            //myLEDCtrl.SetLED(dicCH_open_stripLen, dicCH_close_stripLen);
                            //Inspect_CamIO(camItem1_stripLen, strCamSer, sendIO[0]);
                            // myLEDCtrl.LEDOff(dicCH_open_stripLen);
                        }
                        else if (bchek1 == 1)
                        {
                            BTF1 = false;
                        }
                    }
                    //插壳检测
                    if (bCheckList[1] && 0 == AllCamIO.ReadCamIO(strCamSer, readIO[1], ref bchek2))
                    {
                        if (bchek2 == 0 && !BTF2)
                        {
                            BTF2 = true;
                            //myLEDCtrl.SetLED(dicCH_open_Rubber, dicCH_close_Rubber);
                            //Inspect_CamIO(camItem1_Rubber, strCamSer, sendIO[1]);
                            // myLEDCtrl.LEDOff(dicCH_open_Rubber);
                        }
                        else if (bchek2 == 1)
                        {
                            BTF2 = false;
                        }
                    }
                    else
                    {
                        BTF2 = false;

                    }
                    //打端检测
                    if (bCheckList[2] && 0 == AllCamIO.ReadCamIO(strCamSer, readIO[2], ref bchek3))
                    {
                        if (bchek3 == 0 && !BTF3)
                        {
                            BTF3 = true;
                            //myLEDCtrl.SetLED(dicCH_open_TM, dicCH_close_TM);
                            //Inspect_CamIO(camItem1_TM, strCamSer, sendIO[2]);
                            //myLEDCtrl.LEDOff(dicCH_open_TM);
                        }
                        else if (bchek3 == 1)
                        {
                            BTF3 = false;
                        }
                    }
                    //线序检测
                    if (bCheckList[3] && 0 == AllCamIO.ReadCamIO(strCamSer, readIO[3], ref bchek4))
                    {
                        //MessageFun.ShowMessage(bchek4.ToString());
                        if (bchek4 == 0 && !BTF4)
                        {
                            BTF4 = true;
                            //myLEDCtrl.SetLED(dicCH_open_LineColor, dicCH_close_LineColor);
                            //Inspect_CamIO(camItem1_LineColor, strCamSer, sendIO[3]);
                            //myLEDCtrl.LEDOff(dicCH_open_LineColor);
                        }
                        else if (bchek4 == 1)
                        {
                            BTF4 = false;
                        }

                    }
                    else
                    {
                        BTF4 = false;
                    }

                }
                Thread.Sleep(2);
                //}
            }
            catch (SystemException error)
            {
                ("[FormHome]->[Run]:/t" + error.Message + Environment.NewLine + error.StackTrace).Log();
            }
        }

        public void RunCam_ModbusRTU(int cam, int sub_cam, string strCamSer, Modbus_RTU modbus_RTUs)
        {
            InspectData.CamInspectItem camItem1_stripLen = new InspectData.CamInspectItem();
            InspectData.CamInspectItem camItem1_Rubber = new InspectData.CamInspectItem();
            InspectData.CamInspectItem camItem1_TM = new InspectData.CamInspectItem();
            InspectData.CamInspectItem camItem1_LineColor = new InspectData.CamInspectItem();
            InspectData.CamInspectItem camItem1_CoreNum = new InspectData.CamInspectItem();
            Dictionary<int, int> dicCH_open_stripLen = new Dictionary<int, int>();
            Dictionary<int, int> dicCH_open_Rubber = new Dictionary<int, int>();
            Dictionary<int, int> dicCH_open_TM = new Dictionary<int, int>();
            Dictionary<int, int> dicCH_open_LineColor = new Dictionary<int, int>();
            Dictionary<int, int> dicCH_open_CoreNum = new Dictionary<int, int>();
            Dictionary<int, int> dicCH_close_stripLen = new Dictionary<int, int>();
            Dictionary<int, int> dicCH_close_Rubber = new Dictionary<int, int>();
            Dictionary<int, int> dicCH_close_TM = new Dictionary<int, int>();
            Dictionary<int, int> dicCH_close_LineColor = new Dictionary<int, int>();
            Dictionary<int, int> dicCH_close_CoreNum = new Dictionary<int, int>();
            object lc_write = new object();
            bool[] bCheckList = new bool[4];
            try
            {
                int ncam = cam * 10 + sub_cam;
                camItem1_stripLen.cam = ncam;
                camItem1_Rubber.cam = ncam;
                camItem1_TM.cam = ncam;
                camItem1_LineColor.cam = ncam;
                camItem1_CoreNum.cam = ncam;
                if (!DataSerializer._globalData.dicInspectList.ContainsKey(ncam))
                {
                    MessageFun.ShowMessage($"未给相机{ncam}配置检测项！", false, strEnglish: "No Detection item provided to camera" + ncam.ToString());
                    return;
                }
                List<InspectData.InspectItem> listItems = DataSerializer._globalData.dicInspectList[ncam];
                //LEDSet.myLEDCtrl.SetLEDCH(cam, out int[] nSetLed, out Dictionary<int, List<int>> nDelLed);
                foreach (InspectData.InspectItem item in listItems)
                {
                    if (item == InspectData.InspectItem.Front)
                    {
                        bCheckList[0] = true;
                        camItem1_stripLen.item = InspectData.InspectItem.Front;
                        //光源控制
                        //myLEDCtrl.GetLightCH(camItem1_stripLen, out dicCH_open_stripLen, out dicCH_close_stripLen);
                    }
                    //if (item == InspectData.InspectItem.Back)
                    //{
                    //    bCheckList[1] = true;
                    //    camItem1_Rubber.item = InspectData.InspectItem.Back;
                    //    //光源控制
                    //    //myLEDCtrl.GetLightCH(camItem1_Rubber, out dicCH_open_Rubber, out dicCH_close_Rubber);
                    //}
                    //if (item == InspectData.InspectItem.SidePin1)
                    //{
                    //    bCheckList[2] = true;
                    //    camItem1_TM.item = InspectData.InspectItem.SidePin1;
                    //    //光源控制
                    //    //myLEDCtrl.GetLightCH(camItem1_TM, out dicCH_open_TM, out dicCH_close_TM);
                    //}


                }
                ushort[] Res = new ushort[6];
                InspectData.CamInspectItem DetectionItem = new CamInspectItem();
                while (isAuto)
                {
                    lock (lc_write)
                    {

                        if (cam == 1) // 相机一信号
                        {

                            Res = modbus_RTUs.Read_Register("03", DataSerializer._PlcRTU.PlcRTU[cam - 1].slaveAddress, 1880, 7);
                            if (Res != null && Res.Length == 7)
                            {
                                //剥皮检测
                                if (Res[0] == 1)
                                {
                                    //MessageFun.ShowMessage("剥皮开光源信号读取成功");
                                    // myLEDCtrl.SetLED(dicCH_open_stripLen, dicCH_close_stripLen);
                                    DetectionItem.cam = ncam;
                                    DetectionItem.item = InspectData.InspectItem.Front;
                                    modbus_RTUs.Write_Register("06", DataSerializer._PlcRTU.PlcRTU[cam - 1].slaveAddress, 1880, registerBuffer);

                                }
                                //插壳检测
                                else if (Res[0] == 2)
                                {
                                    //MessageFun.ShowMessage("插壳开光源信号读取成功");
                                    // myLEDCtrl.SetLED(dicCH_open_Rubber, dicCH_close_Rubber);
                                    //DetectionItem.cam = ncam;
                                    //DetectionItem.item = InspectData.InspectItem.Back;
                                    modbus_RTUs.Write_Register("06", DataSerializer._PlcRTU.PlcRTU[cam - 1].slaveAddress, 1880, registerBuffer);
                                }
                                //打端检测
                                else if (Res[0] == 4)
                                {
                                    // myLEDCtrl.SetLED(dicCH_open_TM, dicCH_close_TM);
                                    // DetectionItem.cam = ncam;
                                    //DetectionItem.item = InspectData.InspectItem.SidePin1;
                                    modbus_RTUs.Write_Register("06", DataSerializer._PlcRTU.PlcRTU[cam - 1].slaveAddress, 1880, registerBuffer);
                                }
                                if (Res[6] == 1)
                                {
                                    //MessageFun.ShowMessage("开相机信号读取成功");
                                    if (DetectionItem.item == camItem1_stripLen.item && DetectionItem.cam == camItem1_stripLen.cam)
                                    {
                                        new Task(() => { ModbusRTUInspect(camItem1_stripLen, strCamSer, dicCH_open_stripLen, modbus_RTUs); }, TaskCreationOptions.LongRunning).Start();
                                    }
                                    else if (DetectionItem.item == camItem1_Rubber.item && DetectionItem.cam == camItem1_Rubber.cam)
                                    {
                                        new Task(() => { ModbusRTUInspect(camItem1_Rubber, strCamSer, dicCH_open_Rubber, modbus_RTUs); }, TaskCreationOptions.LongRunning).Start();
                                    }
                                    if (DetectionItem.item == camItem1_TM.item && DetectionItem.cam == camItem1_TM.cam)
                                    {
                                        new Task(() => { ModbusRTUInspect(camItem1_TM, strCamSer, dicCH_open_TM, modbus_RTUs); }, TaskCreationOptions.LongRunning).Start();
                                    }
                                    modbus_RTUs.Write_Register("06", DataSerializer._PlcRTU.PlcRTU[cam - 1].slaveAddress, 1886, registerBuffer);
                                }
                            }
                            if (Res[0] == 3) //复位
                            {
                                //myLEDCtrl.LEDOff(dicCH_open_stripLen);
                                //myLEDCtrl.LEDOff(dicCH_open_Rubber);
                                //myLEDCtrl.LEDOff(dicCH_open_TM);
                                modbus_RTUs.Write_Register("06", DataSerializer._PlcRTU.PlcRTU[cam - 1].slaveAddress, 1880, registerBuffer);

                            }
                        }
                        else if (cam == 2) // 相机二信号
                        {
                            Res = modbus_RTUs.Read_Register("03", DataSerializer._PlcRTU.PlcRTU[cam - 1].slaveAddress, 1880, 7);
                            if (Res != null && Res.Length == 7)
                            {
                                //剥皮检测
                                if (Res[0] == 1)
                                {
                                    // myLEDCtrl.SetLED(dicCH_open_stripLen, dicCH_close_stripLen);
                                    DetectionItem.cam = ncam;
                                    DetectionItem.item = InspectData.InspectItem.Front;
                                    modbus_RTUs.Write_Register("06", DataSerializer._PlcRTU.PlcRTU[cam - 1].slaveAddress, 1880, registerBuffer);

                                }
                                //插壳检测
                                else if (Res[0] == 2)
                                {
                                    // myLEDCtrl.SetLED(dicCH_open_Rubber, dicCH_close_Rubber);
                                    //DetectionItem.cam = ncam;
                                    //DetectionItem.item = InspectData.InspectItem.Back;
                                    modbus_RTUs.Write_Register("06", DataSerializer._PlcRTU.PlcRTU[cam - 1].slaveAddress, 1880, registerBuffer);
                                }//打端检测
                                else if (Res[0] == 4)
                                {
                                    // myLEDCtrl.SetLED(dicCH_open_TM, dicCH_close_TM);
                                    //DetectionItem.cam = ncam;
                                    //DetectionItem.item = InspectData.InspectItem.SidePin1;
                                    modbus_RTUs.Write_Register("06", DataSerializer._PlcRTU.PlcRTU[cam - 1].slaveAddress, 1880, registerBuffer);
                                }
                                if (Res[6] == 1)
                                {
                                    if (DetectionItem.item == camItem1_stripLen.item && DetectionItem.cam == camItem1_stripLen.cam)
                                    {
                                        new Task(() => { ModbusRTUInspect(camItem1_stripLen, strCamSer, dicCH_open_stripLen, modbus_RTUs); }, TaskCreationOptions.LongRunning).Start();
                                    }
                                    else if (DetectionItem.item == camItem1_Rubber.item && DetectionItem.cam == camItem1_Rubber.cam)
                                    {
                                        new Task(() => { ModbusRTUInspect(camItem1_Rubber, strCamSer, dicCH_open_Rubber, modbus_RTUs); }, TaskCreationOptions.LongRunning).Start();
                                    }
                                    else if (DetectionItem.item == camItem1_TM.item && DetectionItem.cam == camItem1_TM.cam)
                                    {
                                        new Task(() => { ModbusRTUInspect(camItem1_TM, strCamSer, dicCH_open_TM, modbus_RTUs); }, TaskCreationOptions.LongRunning).Start();
                                    }
                                    modbus_RTUs.Write_Register("06", DataSerializer._PlcRTU.PlcRTU[cam - 1].slaveAddress, 1886, registerBuffer);
                                }

                            }
                            if (Res[0] == 3) //复位
                            {
                                //myLEDCtrl.LEDOff(dicCH_open_stripLen);
                                //myLEDCtrl.LEDOff(dicCH_open_Rubber);
                                //myLEDCtrl.LEDOff(dicCH_open_TM);
                                modbus_RTUs.Write_Register("06", DataSerializer._PlcRTU.PlcRTU[cam - 1].slaveAddress, 1870, registerBuffer);

                            }
                        }
                    }
                    Thread.Sleep(2);
                }
            }
            catch (SystemException error)
            {
                ("[FormHome]->[Run]:/t" + error.Message + Environment.NewLine + error.StackTrace).Log();
            }
        }

        public struct InspectItems
        {
            public InspectFunction fun;
            public string strCamSer;
            public CamInspectItem camItem;
            public InspectItems(string strCamSer, InspectFunction fun, CamInspectItem camItem)
            {
                this.strCamSer = strCamSer;
                this.fun = fun;
                this.camItem = camItem;
            }
        }

        public void RunTcp(Dictionary<int, CtrlCamShow> m_dicCtrlCamShow)
        {
            object lc_write = new object();
            bool[] bCheckList = new bool[4];
            int rRes;
            bool bLock = false;
            bool bCheckOut = false;
            bool bResult = true;
            Dictionary<InspectData.CamInspectItem, bool> dicResults = new Dictionary<CamInspectItem, bool>();
            Dictionary<InspectData.CamInspectItem, double> dicTimes = new Dictionary<CamInspectItem, double>();
            try
            {
                List<int> listCamID = new List<int>();
                foreach (int camID in FormMainUI.m_dicCtrlCamShow.Keys)
                {
                    if (null != DataSerializer._globalData.dicInspectList && !DataSerializer._globalData.dicInspectList.ContainsKey(camID))
                    {
                        MessageFun.ShowMessage($"未给相机{camID}配置检测项！", false, strEnglish: $"No items configured to camera{camID}");
                        continue;
                    }
                    listCamID.Add(camID);
                }
                ModbusTCPConfig tcp = DataSerializer._ModbusTcp.ModbusTcpConfig;
                Dictionary<Address[], InspectItems> dicInspectItems = new Dictionary<Address[], InspectItems>();
                foreach (int id in listCamID)
                {
                    //相机对应的检测项列表
                    List<InspectData.InspectItem> listItems = DataSerializer._globalData.dicInspectList[id];
                    foreach (InspectItem item in listItems)
                    {
                        if (item == InspectItem.Default)
                        {
                            continue;
                        }
                        for (int i = 0; i < tcp.listItemsAdress.Count; i++)
                        {
                            InspectData.ItemAddress config = tcp.listItemsAdress[i];
                            if (config.camItem.cam == id && config.camItem.item == item)
                            {
                                string strCamSer = FormMainUI.m_dicCtrlCamShow[id].strCamSer;
                                CamInspectItem camItem = new CamInspectItem(id, item);
                                InspectItems inspectItem = new InspectItems(strCamSer, FormMainUI.m_dicCtrlCamShow[id].Fun, camItem);
                                var keys = new Address[2] {
                                StaticFun.TCP.Deserialize(config.readKey),
                                StaticFun.TCP.Deserialize(config.sendKey)};
                                dicInspectItems.Add(keys, inspectItem);
                                MessageFun.ShowMessage($"相机id:{id}{strCamSer}-{camItem.item}:{keys[0].Index}");
                            }
                            Thread.Sleep(20);
                        }
                    }
                }
                Address addressOK = StaticFun.TCP.Deserialize(tcp.isOK.strAddress);
                Address addressNG = StaticFun.TCP.Deserialize(tcp.isNG.strAddress);
                Address addressTrigger = StaticFun.TCP.Deserialize(tcp.isTrigger.strAddress);
                Address addressFinish = StaticFun.TCP.Deserialize(tcp.isFinish.strAddress);
                TimeSpan ts = new TimeSpan(DateTime.Now.Ticks);
                while (isAuto)
                {
                    //一直和PLC保持通讯读取信号的状态
                    rRes = FormMainUI._plc.ReadDeviceRandom(Variable.addresses, out var datas);
                    if (rRes == 0)
                    {
                        //检测信号
                        foreach (Address[] keys in dicInspectItems.Keys)
                        {
                            InspectItems inspectItems = dicInspectItems[keys];
                            int nRead = Convert.ToInt32(datas[keys[0].GetHashCode()].Value);
                            if (nRead == 1 && !bLock)
                            {
                                bLock = true;
                                bCheckOut = true;
                                //复位信号
                                var Receiveindex = keys[0].Index;
                                var address = new Address(SoftType.M, Receiveindex, DataType.Bit);
                                address.Value = 0;
                                FormMainUI._plc.WriteDevice(address);
                                ts = new TimeSpan(DateTime.Now.Ticks);
                                if (Receiveindex == 0)
                                {
                                    CamInspectItem camItem = new CamInspectItem(10, InspectItem.LeftSide);
                                    InspectItems inspectItem = new InspectItems(FormMainUI.m_dicCtrlCamShow[10].strCamSer, FormMainUI.m_dicCtrlCamShow[10].Fun, camItem);
                                    PhotometricInspect(inspectItem);
                                    Thread.Sleep(10);
                                    camItem = new CamInspectItem(20, InspectItem.RightSide);
                                    inspectItem = new InspectItems(FormMainUI.m_dicCtrlCamShow[20].strCamSer, FormMainUI.m_dicCtrlCamShow[20].Fun, camItem);
                                    PhotometricInspect(inspectItem);
                                }
                                else
                                {
                                    CamInspectItem camItem = new CamInspectItem(30, InspectItem.Front);
                                    InspectItems inspectItem = new InspectItems(FormMainUI.m_dicCtrlCamShow[30].strCamSer, FormMainUI.m_dicCtrlCamShow[30].Fun, camItem);
                                    inspectItems.camItem = new CamInspectItem(30, InspectItem.Front);
                                    PhotometricInspect(inspectItem);
                                }
                                #region 发送当前拍照完成信号
                                var index = keys[1].Index;
                                var addr = new Address(SoftType.M, index, DataType.Bit);
                                addr.Value = 1;
                                FormMainUI._plc.WriteDevice(addr);
                                #endregion
                                TimeSpan ts_end = new TimeSpan(DateTime.Now.Ticks);
                                double spanSeconds = ts_end.Subtract(ts).Duration().TotalSeconds;
                                if (spanSeconds > 30)
                                {
                                    WriteStringtoImage(20, 40, 20, "检测超时！", "red", strEnglish: "Capture timeout!");
                                    break;
                                }

                            }
                            else if (nRead == 0)
                            {
                                //信号复位
                                bLock = false;
                                bCheckOut = false;
                            }
                            else if (nRead == 1 && bCheckOut)
                            {
                                TimeSpan ts3_z = new TimeSpan(DateTime.Now.Ticks);
                                double spanSeconds = ts3_z.Subtract(ts).Duration().TotalMilliseconds;
                                if (spanSeconds > 3000)
                                {
                                    ts = new TimeSpan(DateTime.Now.Ticks);
                                    StaticFun.MessageFun.ShowMessage("拍照信号复位超时！");
                                }
                            }
                        }
                    }
                    Thread.Sleep(5);
                }
            }
            catch (SystemException error)
            {
                ("[FormHome]->[Run]:/t" + error.Message + Environment.NewLine + error.StackTrace).Log();
                StaticFun.MessageFun.ShowMessage(error);
            }
        }

        public void ModbusTCPInspect(InspectData.CamInspectItem camItem, string strCamSer, Dictionary<int, int> dicCH_open)
        {
            InspectData.InspectResult result = new InspectResult();
            result.outcome = new Dictionary<string, string>();

            FormMainUI.dCountTime = new TimeSpan(DateTime.Now.Ticks);

            bool bStart = true;
            try
            {
                b_image = false;
                TimeSpan ts1, ts2, ts3;
                bool bResult = true;
                string strInspectItem = "";
                int NumOK = 0;
                int NumNG = 0;
                CamCommon.GrabImage(strCamSer);
                TimeSpan ts = new TimeSpan(DateTime.Now.Ticks);
                InspectData.MultiStripLength.StripLenResult slResult = new InspectData.MultiStripLength.StripLenResult();
                InspectData.MultiTM.MultiResult tmResult = new InspectData.MultiTM.MultiResult();
                RubberResult Result = new RubberResult();
                while (bStart)
                {
                    if (b_image)
                    {
                        ts1 = new TimeSpan(DateTime.Now.Ticks);
                        result.GrabTime = Math.Round((ts1.Subtract(ts).Duration().TotalSeconds) * 1000, 0);   //拍照时间
                                                                                                              //#region 剥皮检测
                                                                                                              //if (camItem.item == InspectItem.Front)
                                                                                                              //{
                                                                                                              //    //Fun.LoadImageFromFile("D:\\image\\1.bmp");
                                                                                                              //    if (!multiStripLength.StrippingInspect(DataSerializer._globalData.dic_StripLenParam[camItem.cam], false, out slResult, out NumOK))
                                                                                                              //    {
                                                                                                              //        NumOK = 0;
                                                                                                              //        bResult = false;
                                                                                                              //        MessageFun.ShowMessage("剥皮检测失败。", false, strEnglish: "Strip Length inspect failed.");
                                                                                                              //    }
                                                                                                              //    ts2 = new TimeSpan(DateTime.Now.Ticks);
                                                                                                              //    result.InspectTime = Math.Round((ts2.Subtract(ts1).Duration().TotalSeconds) * 1000, 1);   //检测时间
                                                                                                              //    NumNG = (int)DataSerializer._globalData.dic_StripLenParam[camItem.cam].nLineNum - NumOK;
                                                                                                              //    break;
                                                                                                              //}
                                                                                                              //#endregion

                        //#region 插壳检测
                        //else if (camItem.item == InspectItem.Back)
                        //{
                        //    //Fun.LoadImageFromFile("D:\\image\\2.bmp");
                        //    InspectData.RubberParam rubberParam = DataSerializer._globalData.dic_RubberParam[camItem.cam];

                        //    if (!myRubber.RubberInspect(rubberParam, false, out Result))
                        //    {
                        //        NumOK = 0;
                        //        bResult = false;
                        //        MessageFun.ShowMessage("插壳检测失败。", false, "Shell insertion detection failed.");
                        //    }
                        //    ts2 = new TimeSpan(DateTime.Now.Ticks);
                        //    result.InspectTime = Math.Round((ts2.Subtract(ts1).Duration().TotalSeconds) * 1000, 1);   //检测时间
                        //    //NumNG = (int)DataSerializer._globalData.dic_RubberParam[camItem.cam].rubberLocate.nRubberNum - NumOK;
                        //    break;
                        //}
                        //#endregion

                        //#region 端子检测
                        //else if (camItem.item == InspectItem.SidePin)
                        //{
                        //    ///Fun.LoadImageFromFile("D:\\image\\1.bmp");
                        //    if (!myMultiTM.MultiTMInspect(DataSerializer._globalData.dic_MultiTMParam[camItem.cam], false, out tmResult))
                        //    {
                        //        bResult = false;
                        //        MessageFun.ShowMessage("端子检测失败。", false, "Terminal detection failed.");
                        //    }
                        //    ts2 = new TimeSpan(DateTime.Now.Ticks);
                        //    result.InspectTime = Math.Round((ts2.Subtract(ts1).Duration().TotalSeconds) * 1000, 0);   //检测时间
                        //    break;
                        //}
                        //#endregion

                        //#region 线序检测
                        //else if (camItem.item == InspectItem.FrontPin)
                        //{
                        //    LineColorParam lineColorParam = DataSerializer._globalData.dic_LineColor[camItem.cam];
                        //    //lineColorParam.listColorID = DataSerializer._globalData.listColorID;
                        //    //if (!myLineColor.LineColorMLP(DataSerializer._globalData.dic_LineColor[camItem.cam], null, false, false, out LineColorResult lineColorResult))
                        //    //{
                        //    //    bResult = false;
                        //    //    MessageFun.ShowMessage("线序检测失败。", "Line sequence detection failed.");
                        //    //}
                        //    ts2 = new TimeSpan(DateTime.Now.Ticks);
                        //    result.InspectTime = Math.Round((ts2.Subtract(ts1).Duration().TotalSeconds) * 1000, 0);   //检测时间
                        //    break;
                        //}
                        //#endregion

                    }
                    ts3 = new TimeSpan(DateTime.Now.Ticks);
                    double spanTotalSeconds = ts3.Subtract(ts).Duration().TotalSeconds;
                    if (spanTotalSeconds > 0.3)
                    {
                        bResult = false;
                        WriteStringtoImage(20, 40, 20, "抓图超时！", "red", strEnglish: "Capture timeout!");

                        //WriteStringtoImage(50, 80, (int)(Function.imageWidth / 2.1), "NG", "red");
                        break;
                    }
                    Thread.Sleep(2);
                }

                if (bResult)
                {
                    //如果产品OK,给PLC发送信号
                    signalTCP(camItem, 1);
                    WriteStringtoImage(30, 80, (int)(Function.imageWidth / 2.1), "OK", "green");
                    result.outcome.Add(strInspectItem, "OK");
                    //保存原始或结果OK图
                    SaveOKImage(camItem.ten(), strInspectItem);
                }
                else
                {
                    //如果产品NG,给PLC发送信号
                    signalTCP(camItem, 2);
                    WriteStringtoImage(30, 80, (int)(Function.imageWidth / 2.1), "NG", "red");
                    result.outcome.Add(strInspectItem, "NG");
                    //保存原始NG图/结果NG图
                    SaveNGImage(camItem.ten(), strInspectItem, "AA");
                }
                //为了节约显示的时间
                //if (camItem.item == InspectItem.MultiTM)
                //{
                //    myMultiTM.MultiTMShowResult(camItem.cam, DataSerializer._globalData.dic_MultiTMParam[camItem.cam], tmResult, out NumOK, out NumNG);
                //}
                //else if (camItem.item == InspectItem.Rubber)
                //{
                //    //myRubber.MultiCKShowResult(camItem.cam, DataSerializer._globalData.dic_RubberParam[camItem.cam], Result);
                //}
                //else if (camItem.item == InspectItem.MultiStripLen)
                //{
                //    multiStripLength.ShowMultiStripResult(camItem.cam, DataSerializer._globalData.dic_StripLenParam[camItem.cam], slResult,NumOK);
                //}
                m_ListFormSTATS[camItem].Add(bResult, NumOK, NumNG, result.InspectTime);
                // myLEDCtrl.LEDOff(dicCH_open);
                FormMainUI.formShowResult.ShowResult(result);
            }
            catch (SystemException ex)
            {
                //myLEDCtrl.LEDOff(dicCH_open);
                MessageFun.ShowMessage(ex.ToString());
                return;
            }
        }

        private void signalTCP(InspectData.CamInspectItem camItem, int iValue)
        {

        }
        public void ModbusRTUInspect(InspectData.CamInspectItem camItem, string strCamSer, Dictionary<int, int> dicCH_open, Modbus_RTU modbus_RTUs)
        {
            InspectData.InspectResult result = new InspectResult();
            result.outcome = new Dictionary<string, string>();

            FormMainUI.dCountTime = new TimeSpan(DateTime.Now.Ticks);

            bool bStart = true;
            try
            {
                b_image = false;
                TimeSpan ts1, ts2, ts3;
                bool bResult = true;
                string strInspectItem = "";
                int NumOK = 0;
                int NumNG = 0;
                CamCommon.GrabImage(strCamSer);
                TimeSpan ts = new TimeSpan(DateTime.Now.Ticks);
                InspectData.MultiStripLength.StripLenResult slResult = new InspectData.MultiStripLength.StripLenResult();
                InspectData.MultiTM.MultiResult tmResult = new InspectData.MultiTM.MultiResult();
                RubberResult Result = new RubberResult();
                while (bStart)
                {
                    if (b_image)
                    {
                        ts1 = new TimeSpan(DateTime.Now.Ticks);
                        result.GrabTime = Math.Round((ts1.Subtract(ts).Duration().TotalSeconds) * 1000, 0);   //拍照时间
                                                                                                              //#region 剥皮检测
                                                                                                              //if (camItem.item == InspectItem.Front)
                                                                                                              //{
                                                                                                              //    //Fun.LoadImageFromFile("D:\\image\\1.bmp");
                                                                                                              //    if (!multiStripLength.StrippingInspect(DataSerializer._globalData.dic_StripLenParam[camItem.cam], false, out slResult, out NumOK))
                                                                                                              //    {
                                                                                                              //        NumOK = 0;
                                                                                                              //        bResult = false;
                                                                                                              //        MessageFun.ShowMessage("剥皮检测失败。", false, "Peeling detection failed.");
                                                                                                              //    }
                                                                                                              //    ts2 = new TimeSpan(DateTime.Now.Ticks);
                                                                                                              //    result.InspectTime = Math.Round((ts2.Subtract(ts1).Duration().TotalSeconds) * 1000, 1);   //检测时间
                                                                                                              //    NumNG = (int)DataSerializer._globalData.dic_StripLenParam[camItem.cam].nLineNum - NumOK;
                                                                                                              //    break;
                                                                                                              //}
                                                                                                              //#endregion

                        //#region 插壳检测
                        //else if (camItem.item == InspectItem.Back)
                        //{
                        //    //Fun.LoadImageFromFile("D:\\image\\2.bmp");
                        //    InspectData.RubberParam rubberParam = DataSerializer._globalData.dic_RubberParam[camItem.cam];

                        //    if (!myRubber.RubberInspect(rubberParam, false, out RubberResult outData))
                        //    {
                        //        NumOK = 0;
                        //        bResult = false;
                        //        MessageFun.ShowMessage("插壳检测失败。", false, "Shell insertion detection failed.");
                        //    }
                        //    ts2 = new TimeSpan(DateTime.Now.Ticks);
                        //    result.InspectTime = Math.Round((ts2.Subtract(ts1).Duration().TotalSeconds) * 1000, 1);   //检测时间
                        //    //NumNG = (int)DataSerializer._globalData.dic_RubberParam[camItem.cam].rubberLocate.nRubberNum - NumOK;
                        //    break;
                        //}
                        //#endregion

                        //#region 端子检测
                        //else if (camItem.item == InspectItem.Front)
                        //{
                        //    ///Fun.LoadImageFromFile("D:\\image\\1.bmp");
                        //    if (!myMultiTM.MultiTMInspect(DataSerializer._globalData.dic_MultiTMParam[camItem.cam], false, out tmResult))
                        //    {
                        //        bResult = false;
                        //        MessageFun.ShowMessage("端子检测失败。", false, "Terminal detection failed.");
                        //    }
                        //    ts2 = new TimeSpan(DateTime.Now.Ticks);
                        //    result.InspectTime = Math.Round((ts2.Subtract(ts1).Duration().TotalSeconds) * 1000, 0);   //检测时间
                        //    break;
                        //}
                        //#endregion

                        //#region 线序检测
                        //else if (camItem.item == InspectItem.SidePin)
                        //{
                        //    LineColorParam lineColorParam = DataSerializer._globalData.dic_LineColor[camItem.cam];
                        //    //lineColorParam.listColorID = DataSerializer._globalData.listColorID;
                        //    //if (!myLineColor.LineColorMLP(DataSerializer._globalData.dic_LineColor[camItem.cam], null, false, false, out LineColorResult lineColorResult))
                        //    //{
                        //    //    bResult = false;
                        //    //    MessageFun.ShowMessage("线序检测失败。", "Line sequence detection failed.");
                        //    //}
                        //    ts2 = new TimeSpan(DateTime.Now.Ticks);
                        //    result.InspectTime = Math.Round((ts2.Subtract(ts1).Duration().TotalSeconds) * 1000, 0);   //检测时间
                        //    break;
                        //}
                        //#endregion

                    }
                    ts3 = new TimeSpan(DateTime.Now.Ticks);
                    double spanTotalSeconds = ts3.Subtract(ts).Duration().TotalSeconds;
                    if (spanTotalSeconds > 0.3)
                    {
                        bResult = false;
                        WriteStringtoImage(20, 40, 20, "抓图超时！", "red", strEnglish: "Capture timeout!");

                        //WriteStringtoImage(50, 80, (int)(Function.imageWidth / 2.1), "NG", "red");
                        break;
                    }
                    Thread.Sleep(2);
                }
                if (bResult)
                {
                    //如果产品OK,给PLC发送信号
                    if (camItem.ten() == 1)
                    {
                        modbus_RTUs.Write_Register("06", DataSerializer._PlcRTU.PlcRTU[camItem.ten() - 1].slaveAddress, 1882, registerBufferOK);
                        MessageFun.ShowMessage("1882-1-前端OK信号发出");
                    }
                    else if (camItem.ten() == 2)
                    {
                        modbus_RTUs.Write_Register("06", DataSerializer._PlcRTU.PlcRTU[camItem.ten() - 1].slaveAddress, 1882, registerBufferOK);
                        MessageFun.ShowMessage("1872-1-前端OK信号发出");
                    }
                    //MessageFun.ShowMessage("1882-OK信号已给出");
                    WriteStringtoImage(30, 80, (int)(Function.imageWidth / 2.1), "OK", "green");
                    result.outcome.Add(strInspectItem, "OK");
                    //保存原始或结果OK图
                    SaveOKImage(camItem.ten(), strInspectItem);
                }
                else
                {
                    //如果产品NG,给PLC发送信号
                    if (camItem.ten() == 1)
                    {
                        modbus_RTUs.Write_Register("06", DataSerializer._PlcRTU.PlcRTU[camItem.ten() - 1].slaveAddress, 1882, registerBufferNG);
                        MessageFun.ShowMessage("1882-0-前端NG信号发出");
                    }
                    else if (camItem.ten() == 2)
                    {
                        modbus_RTUs.Write_Register("06", DataSerializer._PlcRTU.PlcRTU[camItem.ten() - 1].slaveAddress, 1882, registerBufferNG);
                        MessageFun.ShowMessage("1872-0-后端NG信号发出");
                    }
                    WriteStringtoImage(30, 80, (int)(Function.imageWidth / 2.1), "NG", "red");
                    result.outcome.Add(strInspectItem, "NG");
                    //保存原始NG图/结果NG图
                    SaveNGImage(camItem.ten(), strInspectItem, "AA");
                }
                //为了节约显示的时间
                //if (camItem.item == InspectItem.MultiTM)
                //{
                //    myMultiTM.MultiTMShowResult(camItem.cam, DataSerializer._globalData.dic_MultiTMParam[camItem.cam], tmResult, out NumOK, out NumNG);
                //}
                //else if (camItem.item == InspectItem.Rubber)
                //{
                //    //myRubber.MultiCKShowResult(camItem.cam, DataSerializer._globalData.dic_RubberParam[camItem.cam], Result);
                //}
                //else if (camItem.item == InspectItem.MultiStripLen)
                //{
                //    multiStripLength.ShowMultiStripResult(camItem.cam, DataSerializer._globalData.dic_StripLenParam[camItem.cam], slResult, NumOK);
                //}
                m_ListFormSTATS[camItem].Add(bResult, NumOK, NumNG, result.InspectTime);
                //myLEDCtrl.LEDOff(dicCH_open);
                FormMainUI.formShowResult.ShowResult(result);
                if (camItem.ten() == 1)
                {
                    modbus_RTUs.Write_Register("06", DataSerializer._PlcRTU.PlcRTU[camItem.ten() - 1].slaveAddress, 1884, registerBufferFinish);
                    MessageFun.ShowMessage("1884-1-检测完成信号发出");
                }
                else if (camItem.ten() == 2)
                {
                    modbus_RTUs.Write_Register("06", DataSerializer._PlcRTU.PlcRTU[camItem.ten() - 1].slaveAddress, 1884, registerBufferFinish);
                    MessageFun.ShowMessage("1874-1-检测完成信号发出");
                }
                //MessageFun.ShowMessage("1884复位信号已给出");
                //MessageFun.ShowMessage("************************************");
            }
            catch (SystemException ex)
            {
                bStart = false;
                // myLEDCtrl.LEDOff(dicCH_open);
                MessageFun.ShowMessage(ex.ToString());
                return;
            }
        }

        public bool PhotometricInspect(InspectItems inspectItem)
        {
            bool bResult = true, bStart = true;
            TimeSpan ts_grab, ts_check, ts_timeOut;
            InspectData.InspectResult result = new InspectResult();
            FrontResult frontResult = new FrontResult();

            try
            {
                string strInspectItem = GetStrCheckItem(inspectItem.camItem.item);
                int camID = inspectItem.camItem.cam;
                CamCommon.OpenCam(inspectItem.strCamSer, inspectItem.fun);
                TimeSpan ts = new TimeSpan(DateTime.Now.Ticks);
                
                CamCommon.OpenCam(inspectItem.strCamSer, inspectItem.fun);
                List<HObject> listImages = inspectItem.fun.PhotometricGrabImages(inspectItem.camItem.cam, inspectItem.strCamSer);
                //拍照总用时
                ts_grab = new TimeSpan(DateTime.Now.Ticks);
                result.GrabTime = Math.Round((ts_grab.Subtract(ts).Duration().TotalSeconds) * 1000, 0);
                PhotometricStereoImage proImages = PhotometricStereo(listImages);
                inspectItem.fun.DispRegion(proImages.Gradient);
                inspectItem.fun.myFrontFun.ho_AIImage = proImages.Gradient.Clone();
                if (!inspectItem.fun.myFrontFun.FrontInspect(DataSerializer._globalData.dic_FrontParam[camID], inspectItem.camItem.item, false, out frontResult, inspectItem.fun.myFrontFun.ho_AIImage))
                {
                    bResult = false;
                }
                //检测时间
                ts_check = new TimeSpan(DateTime.Now.Ticks);
                result.InspectTime = Math.Round((ts_check.Subtract(ts_grab).Duration().TotalSeconds) * 1000, 1);
                frontResult.bFrontResult = bResult;
                //显示检测结果
                inspectItem.fun.myFrontFun.FrontResultShow(inspectItem.camItem, DataSerializer._globalData.dic_FrontParam[camID], ref frontResult);
                if (!frontResult.bFrontResult) bResult = false;
                result.outcome.Add(strInspectItem, bResult ? "OK" : "NG");
                //保存图像
                SavePhotometricImages(inspectItem.camItem.cam, strInspectItem, listImages, proImages);
                //显示结果到ListView
                FormMainUI.formShowResult.ShowResult(result);
            }
            catch (SystemException ex)
            {
                bStart = false;
                bResult = false;
                MessageFun.ShowMessage(ex, true);
            }
            return bResult;
        }
        public bool UpLoadMES()
        {
            var bOverallResult = true;
            try
            {
                var produceInfo = new List<ProduceInfo>();
                var bPlugIn = true;

                myCtrlOK_NG.ShowRes(bOverallResult);
                //语音播报
                speechSynthesizer.Volume = 100;
                speechSynthesizer.Rate = 2;
                speechSynthesizer.Speak(!bOverallResult ? "NG" : "OK");
                //NG弹窗锁屏
                if (!bOverallResult)
                {
                    var addr = new Address(SoftType.M, 807, DataType.Bit);
                    addr.Value = 1;
                    FormMainUI._plc.WriteDevice(addr);
                    //弹窗锁屏
                    LockScreenForm lockScreenForm = new LockScreenForm();
                    lockScreenForm.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
                    lockScreenForm.ShowDialog();
                }
                var strCode = string.Empty;
                strCode = Variable.m_Result10.strQRCode == null ? "无" : Variable.m_Result10.strQRCode;
                var produ = new ProduceInfo()
                {
                    DateTime = DateTime.Now,
                    Code = strCode,
                    CharacterContent = Variable.m_Result10.strPNCode,
                    PlugIn = bPlugIn,
                    paster = true,
                    SolderInspection = true,
                    CopperColumnDetection = Variable.m_Result30.GuidePinRes.listFlag == null ? false : Variable.m_Result30.GuidePinRes.listFlag.Contains(false) ? false : true,
                    OverallResult = bOverallResult
                };
                MessageFun.ShowMessage("开始上传数据库");
                var sqlServeresult = Variable.sqlServer.InsertTable(produ);
                MessageFun.ShowMessage("数据上传完成！");
            }
            catch (Exception ex)
            {
                StaticFun.MessageFun.ShowMessage(ex, true);
            }
            //Variable.m_Result = new Dictionary<int, object>();
            Variable.m_Result10 = new InspectData.FrontResult();//正面检测结果
            Variable.m_Result30 = new InspectData.BackResult();//背面检测结果
            return bOverallResult;
        }

        //public void Inspect_CamIO(InspectData.CamInspectItem camItem, string strCamSer, InspectData.IOSend ioSend)
        //{
        //    FormMainUI.bLogoClose = true;
        //    InspectData.InspectResult result = new InspectResult();
        //    result.outcome = new Dictionary<string, string>();
        //    FormMainUI.dCountTime = new TimeSpan(DateTime.Now.Ticks);
        //    bool bStart = true;
        //    try
        //    {
        //        b_image = false;
        //        ClearObjShow();
        //        TimeSpan ts1, ts2, ts3;
        //        bool bResult = true;
        //        string strInspectItem = "";
        //        int NumOK = 0;
        //        int NumNG = 0;
        //        InspectData.MultiStripLength.StripLenResult stripResult = new InspectData.MultiStripLength.StripLenResult();
        //        InspectData.MultiTM.MultiResult tmResult = new InspectData.MultiTM.MultiResult();
        //        InspectData.RubberResult rubberResult = new RubberResult();
        //        InspectData.SideRubberResult sideRubberResult = new SideRubberResult();
        //        LineColorResult lineColorResult = new LineColorResult();
        //        //若未设置信号翻转，在此会先将信号关闭
        //        if (!ioSend.bSendInvert)
        //        {
        //            CamCommon.SetIOState(strCamSer, ioSend.sendOK, true);
        //        }
        //        //CamCommon.OpenCam(strCamSer, FormMainUI.m_dicFormCamShows[camItem.ten()][camItem.unit()].form.fun);
        //        //FormMainUI.m_dicFormCamShows[camItem.ten()][camItem.unit()].form.fun.ClearObjShow();
        //        CamCommon.GrabImage(strCamSer);
        //        TimeSpan ts = new TimeSpan(DateTime.Now.Ticks);
        //        while (bStart)
        //        {
        //            if (b_image)
        //            {
        //                ts1 = new TimeSpan(DateTime.Now.Ticks);
        //                result.GrabTime = Math.Round((ts1.Subtract(ts).Duration().TotalSeconds) * 1000, 0);   //拍照时间
        //                #region 剥皮检测
        //                if (camItem.item == InspectItem.MultiStripLen)
        //                {
        //                    //LoadImageFromFile("D:\\image\\1.bmp");
        //                    if (!multiStripLength.StrippingInspect(DataSerializer._globalData.dic_StripLenParam[camItem.cam], false, out stripResult, out NumOK))
        //                    {
        //                        bResult = false;
        //                        MessageFun.ShowMessage("剥皮检测失败。", false, "Peeling detection failed.");
        //                    }
        //                    ts2 = new TimeSpan(DateTime.Now.Ticks);
        //                    result.InspectTime = Math.Round((ts2.Subtract(ts1).Duration().TotalSeconds) * 1000, 1);   //检测时间
        //                                                                                                              //NumNG = (int)TMData_Serializer._globalData.dic_StripLenParam[camItem.cam].nLineNum - NumOK;
        //                    strInspectItem = GetStrCheckItem(InspectItem.MultiStripLen);
        //                    break;
        //                }
        //                #endregion

        //                #region 插壳检测

        //                else if (camItem.item == InspectItem.Rubber)
        //                {
        //                    //LoadImageFromFile("D:\\image\\2.bmp");
        //                    InspectData.RubberParam rubberParam = DataSerializer._globalData.dic_RubberParam[camItem.cam];

        //                    if (!myRubber.RubberInspect(rubberParam, false, out rubberResult))
        //                    {
        //                        bResult = false;
        //                        MessageFun.ShowMessage("插壳检测失败。", false, "Shell insertion detection failed.");
        //                    }
        //                    ts2 = new TimeSpan(DateTime.Now.Ticks);
        //                    result.InspectTime = Math.Round((ts2.Subtract(ts1).Duration().TotalSeconds) * 1000, 1);   //检测时间
        //                                                                                                              //NumNG = (int)TMData_Serializer._globalData.dic_RubberParam[camItem.cam].rubberLocate.nRubberNum - NumOK;
        //                    strInspectItem = GetStrCheckItem(InspectItem.Rubber);
        //                    break;
        //                }
        //                #endregion

        //                #region 端子检测
        //                else if (camItem.item == InspectItem.MultiTM)
        //                {
        //                    //LoadImageFromFile("D:\\image\\3.bmp");
        //                    if (!myMultiTM.MultiTMInspect(DataSerializer._globalData.dic_MultiTMParam[camItem.cam], false, out tmResult))
        //                    {
        //                        bResult = false;
        //                        MessageFun.ShowMessage("端子检测失败。", false, "Terminal detection failed.");
        //                    }
        //                    ts2 = new TimeSpan(DateTime.Now.Ticks);
        //                    result.InspectTime = Math.Round((ts2.Subtract(ts1).Duration().TotalSeconds) * 1000, 0);   //检测时间
        //                    strInspectItem = GetStrCheckItem(InspectItem.MultiTM);
        //                    break;
        //                }
        //                #endregion

        //                #region 线序检测
        //                else if (camItem.item == InspectItem.LineColor)
        //                {
        //                    LineColorParam lineColorParam = DataSerializer._globalData.dic_LineColor[camItem.cam];
        //                    //lineColorParam.listColorID = DataSerializer._globalData.listColorID;
        //                    //bResult = true;
        //                    ////NumOK = lineColorParam.pos.nDivideNum * lineColorParam.nDivideNum;
        //                    //if (!myLineColor.LineColorMLP(DataSerializer._globalData.dic_LineColor[camItem.cam], null, false, false, out lineColorResult))
        //                    //{
        //                    //    bResult = false;
        //                    //    NumOK = 0;
        //                    //    MessageFun.ShowMessage("线序检测失败。", "Line sequence detection failed.");
        //                    //}
        //                    ts2 = new TimeSpan(DateTime.Now.Ticks);
        //                    result.InspectTime = Math.Round((ts2.Subtract(ts1).Duration().TotalSeconds) * 1000, 0);   //检测时间
        //                    strInspectItem = GetStrCheckItem(InspectItem.LineColor);
        //                    for (int i = 0; i < lineColorResult.listFlag.Count(); i++)
        //                    {
        //                        if (lineColorResult.listFlag[i] == false)
        //                        {
        //                            bResult = false;
        //                            NumOK--;
        //                        }
        //                    }
        //                    //NumNG = lineColorParam.selROI.nDivideNum * lineColorParam.nDivideNum - NumOK;
        //                    break;
        //                }
        //                #endregion

        //                #region 插壳检测-侧面
        //                else if (camItem.item == InspectItem.RubberSide)
        //                {
        //                    InspectData.SideRubberParam siderubberParam = DataSerializer._globalData.dic_SideRubberParam[camItem.cam];
        //                    if (!myRubber.SideRubberInsert(siderubberParam, true, out sideRubberResult))
        //                    {
        //                        bResult = false;
        //                        MessageFun.ShowMessage("插壳-侧面检测失败。", false, "Shell insertion - side detection failed.");
        //                    }
        //                    ts2 = new TimeSpan(DateTime.Now.Ticks);
        //                    result.InspectTime = Math.Round((ts2.Subtract(ts1).Duration().TotalSeconds) * 1000, 1);   //检测时间
        //                    strInspectItem = GetStrCheckItem(InspectItem.RubberSide);
        //                    break;
        //                }
        //                #endregion

        //            }
        //            ts3 = new TimeSpan(DateTime.Now.Ticks);
        //            double spanTotalSeconds = ts3.Subtract(ts).Duration().TotalSeconds;
        //            if (spanTotalSeconds > 0.55)
        //            {
        //                bResult = false;
        //                WriteStringtoImage(20, 40, 20, "抓图超时！", "red", strEnglish: "Capture timeout!");
        //                break;
        //            }
        //            Thread.Sleep(2);
        //        }
        //        if (bResult)
        //        {
        //            NumOK = 1;
        //            NumNG = 0;
        //            //如果产品OK,给PLC发送信号
        //            if (ioSend.bSendOK)
        //            {
        //                CamCommon.SetIOState(strCamSer, ioSend.sendOK, false);
        //                Thread.Sleep((int)ioSend.nSleep);
        //                CamCommon.SetIOState(strCamSer, ioSend.sendOK, true);
        //            }
        //            WriteStringtoImage(30, 80, (int)(Function.imageWidth / 2.1), "OK", "green");
        //            result.outcome.Add(strInspectItem, "OK");
        //            //保存原始或结果OK图
        //            SaveOKImage(camItem.ten(), strInspectItem);
        //        }
        //        else
        //        {
        //            NumOK = 0;
        //            NumNG = 1;
        //            //如果产品NG,给PLC发送信号
        //            if (ioSend.bSendNG)
        //            {
        //                CamCommon.SetIOState(strCamSer, ioSend.sendNG, false);
        //                Thread.Sleep((int)ioSend.nSleep);
        //                CamCommon.SetIOState(strCamSer, ioSend.sendNG, true);
        //            }
        //            WriteStringtoImage(30, 80, (int)(Function.imageWidth / 2.1), "NG", "red");
        //            result.outcome.Add(strInspectItem, "NG");
        //            //保存原始NG图/结果NG图
        //            SaveNGImage(camItem.ten(), strInspectItem);
        //        }
        //        //添加到数据统计
        //        m_ListFormSTATS[camItem].Add(bResult, NumOK, NumNG, result.InspectTime);
        //        //为了节约显示的时间
        //        if (camItem.item == InspectItem.MultiTM)
        //        {
        //            myMultiTM.MultiTMShowResult(camItem.cam, DataSerializer._globalData.dic_MultiTMParam[camItem.cam], tmResult,  out NumOK, out NumNG);
        //        }
        //        else if (camItem.item == InspectItem.Rubber)
        //        {
        //            //myRubber.MultiCKShowResult(camItem.cam, DataSerializer._globalData.dic_RubberParam[camItem.cam], rubberResult);
        //        }
        //        else if (camItem.item == InspectItem.MultiStripLen)
        //        {
        //            multiStripLength.ShowMultiStripResult(camItem.cam, DataSerializer._globalData.dic_StripLenParam[camItem.cam], stripResult, NumOK);
        //        }
        //        else if (camItem.item == InspectItem.RubberSide)
        //        {
        //            myRubber.SideRubberResultShow(camItem.cam, DataSerializer._globalData.dic_SideRubberParam[camItem.cam], sideRubberResult);
        //        }
        //        else if (camItem.item == InspectItem.LineColor)
        //        {
        //            myMultiTM.MultiLCShowResult(camItem.cam, DataSerializer._globalData.dic_LineColor[camItem.cam], lineColorResult);
        //        }
        //        FormMainUI.formShowResult.ShowResult(result);
        //    }
        //    catch (SystemException ex)
        //    {
        //        bStart = false;
        //        //如果产品NG,给PLC发送信号
        //        if (ioSend.bSendNG)
        //        {
        //            WENYU.SendIO(ioSend.sendNG, ioSend.bSendInvert, ioSend.nSleep);
        //            WriteStringtoImage(30, 80, (int)(Function.imageWidth / 2.1), "NG", "red");
        //        }
        //        MessageFun.ShowMessage(ex.ToString());
        //        return;
        //    }
        //}

        public List<HObject> PhotometricGrabImages(int camID, string strCamSer, List<HWindowControl> listHWndCtrl = null)
        {
            List<HObject> listImages = new List<HObject>();
            bool bStart = true;
            TimeSpan ts_grab, ts_timeOut;
            try
            {
                ClearObjShow();
                CHBright[] cHBrights = new CHBright[4];
                cHBrights[0] = new CHBright();
                for (int i = 0; i < 4; i++)
                {
                    //设置相机的曝光时间
                    CamSDK.CamCommon.SetExposure(strCamSer, (int)DataSerializer._globalData.dicImageing[camID].camParam.exposure);
                    //设置光源亮度
                    cHBrights = new CHBright[4];
                    int nLight = DataSerializer._globalData.dicImageing[camID].CHBright[i].nBrightness;
                    string strPort = DataSerializer._globalData.dicImageing[camID].strPort;
                    LEDRTU ledRTU = DataSerializer._COMConfig.dicLed[strPort];
                    cHBrights[i] = new CHBright(true, nLight);
                    myLEDCtrl.SetLED(ledRTU, cHBrights);
                    b_image = false;
                    CamCommon.GrabImage(strCamSer);
                    TimeSpan ts = new TimeSpan(DateTime.Now.Ticks);
                    while (bStart)
                    {
                        if (b_image)
                        {
                            b_image = false;
                            //拍照时间
                            ts_grab = new TimeSpan(DateTime.Now.Ticks);
                            double grabTime = Math.Round((ts_grab.Subtract(ts).Duration().TotalSeconds) * 1000, 0);
                            MessageFun.ShowMessage($"相机{camID}-【{i + 1}】拍照用时：{grabTime}");
                            if (null != m_hImage)
                            {
                                listImages.Add(m_hImage.Clone());
                                if (null != listHWndCtrl)
                                {
                                    listHWndCtrl[i].HalconWindow.DispObj(m_hImage);
                                    ShowImageToHWnd(m_hImage, listHWndCtrl[i]);
                                }
                                Thread.Sleep(2);
                            }
                            myLEDCtrl.LEDAllOff(ledRTU, cHBrights);
                            break;
                        }
                        ts_timeOut = new TimeSpan(DateTime.Now.Ticks);
                        double spanTotalSeconds = ts_timeOut.Subtract(ts).Duration().TotalSeconds;
                        if (spanTotalSeconds > 3)
                        {
                            WriteStringtoImage(20, 40, 20, "抓图超时！", "red", strEnglish: "Capture timeout!");
                            break;
                        }
                        Thread.Sleep(20);
                    }
                }
            }
            catch (SystemException ex)
            {
                StaticFun.MessageFun.ShowMessage(ex, true);
            }
            return listImages;
        }
    }

}

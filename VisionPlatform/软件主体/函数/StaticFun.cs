using BaseData;
using CamSDK;
using DAL;
using HalconDotNet;
using Hi.Ltd;
using Hi.Ltd.Data;
using Hi.Ltd.Enumerations;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using VisionPlatform;
using VisionPlatform.Auxiliary;
using VisionPlatform.Properties;
using WENYU_IO;
using static GlobalData.Config;
using static VisionPlatform.InspectData;

namespace StaticFun
{
    public class Fun
    {
        public static bool isRunning;              //监听程序是否处于生产状态
        public static void ReadDisk()
        {
            try
            {
                string AppPath = Application.StartupPath.ToString();
                string volume = AppPath.Substring(0, AppPath.IndexOf(':'));
                long totalSize = 0;
                volume = volume + ":\\";
                System.IO.DriveInfo[] drives = System.IO.DriveInfo.GetDrives();
                foreach (System.IO.DriveInfo drive in drives)
                {
                    if (drive.Name == volume)
                    {
                        totalSize = drive.TotalFreeSpace / (1024 * 1024 * 1024);
                    }
                }
                if (totalSize < 2)
                {
                    MessageBox.Show("磁盘空间不足2G，请及时清理图片！");
                }
            }
            catch (Exception ex)
            {
                ex.ToString().Log();
            }
        }
        public static long GetHardDiskSpace(string str_HardDiskName)
        {
            str_HardDiskName = "";
            long totalSize = 0;
            try
            {
                str_HardDiskName = str_HardDiskName + ":\\";
                System.IO.DriveInfo[] drives = System.IO.DriveInfo.GetDrives();
                foreach (System.IO.DriveInfo drive in drives)
                {
                    if (drive.Name == str_HardDiskName)
                    {
                        totalSize = drive.TotalFreeSpace;
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString().Log();
            }
            return totalSize;
        }
        //修改图片保存地址
        public static void LoadImageAddress(string strAddress)
        {
            try
            {
                if (null != strAddress && "" != strAddress)
                {
                    GlobalPath.SavePath.ImageFold = $"{strAddress}:\\ImageSaving";
                }
            }
            catch (Exception)
            {
                StaticFun.MessageFun.ShowMessage("图片保存地址加载错误。", true, strEnglish: "Image save address loading error!");
            }
        }

    }

    public class Run
    {
        public static System.Timers.Timer timer;
        private static bool timeExceeded = false;//计时时间
        private static bool PlcExceeded = false;//PLC标志点
                                                // 计时器触发的事件处理方法
        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            timeExceeded = true;
        }
        public static bool InitModbusRTU(out Modbus_RTU[] _RTUs)
        {
            _RTUs = null;
            try
            {
                int num = DataSerializer._PlcRTU.PlcRTU?.Count();
                if (0 == num)
                {
                    return false;
                }
                _RTUs = new Modbus_RTU[num];
                for (int n = 0; n < num; n++)
                {
                    if (!_RTUs[n].isOpen)
                    {
                        int try_connect = 0;
                        while (!_RTUs[n].isOpen && try_connect < 3)
                        {
                            _RTUs[n].OpenCom(DataSerializer._PlcRTU.PlcRTU[n]);
                            try_connect++;
                            Thread.Sleep(20);
                        }
                    }
                    if (!_RTUs[n].isOpen)
                    {
                        MessageBox.Show("PLC-ModbusRTU连接异常，请检查！！！", "提示", MessageBoxButtons.OK);
                    }

                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static void LoadRun(System.Windows.Forms.Button but_Run)
        {
            try
            {
                Zoom();
                if (but_Run.Text == "运行" || but_Run.Text == "Start")
                {
                    //timeExceeded = false;
                    //PlcExceeded = false;
                    //timer = new System.Timers.Timer(20000);
                    //timer.Elapsed += OnTimedEvent;
                    //timer.AutoReset = false; // 只触发一次

                    but_Run.Image = Resources.runing;
                    if (CamCommon.m_listCamSer.Count != 0)
                    {
                        ////整机还原
                        //var addressM5 = new Address(SoftType.M, 5, DataType.Bit);
                        //addressM5.Value = 1;
                        //FormMainUI._plc.WriteDevice(addressM5);
                        //Thread.Sleep(2000);
                        ////整机启动
                        //var address = new Address(SoftType.M, 1, DataType.Bit);
                        //address.Value = 1;
                        //FormMainUI._plc.WriteDevice(address);
                        //timer.Start();
                        //while (!timeExceeded && !PlcExceeded)
                        //{
                        //    //整机运行中
                        //    var readAdress = new Address(SoftType.M, 13, DataType.Bit);
                        //    var rRes = FormMainUI._plc.ReadDeviceRandom(FormMainUI.addressesPlc, out var datas);
                        //    int key = FormMainUI.M13.GetHashCode();
                        //    if (rRes == 0)
                        //    {
                        //        if (Convert.ToInt32(datas[key].Value) == 1)
                        //        {
                        //            PlcExceeded = true;
                        //            timeExceeded = false;
                        //            timer.Stop();
                        //            continue;
                        //        }
                        //    }
                        //}
                        //if (timeExceeded)
                        //{
                        //    return;
                        //}
                        //FormMainUI.M826.Value = false;
                        //FormMainUI._plc.WriteDevice(FormMainUI.M826);
                        //FormMainUI.M800.Value = 0;
                        //FormMainUI._plc.WriteDevice(FormMainUI.M800);
                        //NG产品无论怎样在自动运行前都置位一次
                        //var addr = new Address(SoftType.M, 807, DataType.Bit);
                        //addr.Value = 0;
                        //FormMainUI._plc.WriteDevice(addr);
                        CamCommon.StopLiveAll();   //防止抓拍出来的图片不对
                        if (Start())
                        {
                            //timeExceeded = false;//计时时间
                            //PlcExceeded = false;//PLC标志点
                            FormMainUI.bRun = true;
                            InspectFunction.isAuto = true;
                            FormMainUI.bCountNum = true;
                            FormMainUI.dCountTime = new TimeSpan(DateTime.Now.Ticks);
                            but_Run.Text = _language == EnumData.Language.english ? "Running..." : "运行中";
                            but_Run.BackColor = Color.LightGreen;
                        }
                        else
                        {
                            FormMainUI.bRun = false;
                            InspectFunction.isAuto = false;
                        }
                    }
                    else
                    {
                        FormMainUI.bRun = false;
                        MessageBox.Show("相机连接异常！", "提示", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    InspectFunction.isAuto = false;
                    FormMainUI.bRun = false;
                    FormMainUI.bCountNum = false;
                    Thread.Sleep(3);
                    but_Run.Image = Resources.stop;
                    but_Run.Text = GlobalData.Config._language == EnumData.Language.english ? "Start" : "运行";
                    but_Run.BackColor = default;
                }
            }
            catch (SystemException error)
            {
                MessageFun.ShowMessage($"错误：{error}");
                FormMainUI.bCountNum = false;
                return;
            }
        }
        public static bool Start()
        {
            try
            {
                //检测光源控制器是否链接正常
                if (_InitConfig.initConfig.bDigitLight)
                {
                    foreach (var led in DataSerializer._COMConfig.dicLed)
                    {
                        BaseData.LEDRTU ledRTU = led.Value;
                        if (!ledRTU.bOpen)
                        {
                            int try_connect = 0;
                            while (!led.Value.bOpen && try_connect < 3)
                            {
                                LEDControl.OpenLedCom(ref ledRTU);
                                try_connect++;
                                Thread.Sleep(20);
                            }
                        }
                        if (!ledRTU.bOpen)
                        {
                            MessageBox.Show($"光源控制器{led.Key}链接异常，请检查。");
                            return false;
                        }
                    }
                }
                //检测通讯是否正常
                switch (_InitConfig.initConfig.comMode.TYPE)
                {
                    case EnumData.COMType.IO:
                        int try_connect = 0;
                        while (!WENYU.isOpen && try_connect < 3)
                        {
                            WENYU.OpenIO();
                            try_connect++;
                            Thread.Sleep(20);
                        }
                        if (!WENYU.isOpen)
                        {
                            MessageBox.Show("板卡通讯异常！", "提示", MessageBoxButtons.OK);
                            return false;
                        }
                        InspectFunction.isAuto = true;
                        //开启检测线程
                        foreach (int camID in FormMainUI.m_dicCtrlCamShow.Keys)
                        {
                            CtrlCamShow ctrlCamShow = FormMainUI.m_dicCtrlCamShow[camID];
                            if (camID.ToString()[1] == 0)
                            {
                                //new Task(() => { ctrlCamShow.Fun.RunCam_IO(cam, sub_cam, strCamSer); }, TaskCreationOptions.LongRunning).Start();
                                Thread.Sleep(20);
                            }
                        }
                        break;
                    case EnumData.COMType.COM:
                        if (InitModbusRTU(out Modbus_RTU[] _RTUs))
                        {
                            InspectFunction.isAuto = true;
                        }
                        ;
                        break;
                    case EnumData.COMType.CamIO:
                        break;
                    case EnumData.COMType.NET:
                        //开启检测线程
                        foreach (int camID in FormMainUI.m_dicCtrlCamShow.Keys)
                        {
                            CtrlCamShow ctrlCamShow = FormMainUI.m_dicCtrlCamShow[camID];
                            if (camID % 10 == 0)
                            {
                                //只给主相机开线程
                                new Task(() => { ctrlCamShow.Fun.RunTcp(FormMainUI.m_dicCtrlCamShow); }, TaskCreationOptions.LongRunning).Start();
                                Thread.Sleep(20);
                                break;
                            }
                        }
                        break;
                }
                Thread.Sleep(10);
                return true;
            }
            catch (Exception ex)
            {
                ("[FormHome]->[Run]:/t" + ex.Message + Environment.NewLine + ex.StackTrace).Log();
                return false;
            }
        }
        public void LoadRun(Modbus_RTU[] modbus_RTUs, Button but_Run)
        {
            try
            {
                Zoom();
                if (but_Run.Text == "运行" || but_Run.Text == "Start")
                {
                    but_Run.Image = Resources.runing;
                    if (CamCommon.m_listCamSer.Count != 0)
                    {
                        CamCommon.StopLiveAll();   //防止抓拍出来的图片不对
                        if (Start(modbus_RTUs))
                        {
                            FormMainUI.bRun = true;
                            InspectFunction.isAuto = true;
                            FormMainUI.bCountNum = true;
                            FormMainUI.dCountTime = new TimeSpan(DateTime.Now.Ticks);
                            if (_language == EnumData.Language.english)
                            {
                                but_Run.Text = "Running...";
                            }
                            else
                            {
                                but_Run.Text = "运行中";
                            }

                            but_Run.BackColor = Color.LightGreen;
                        }
                        else
                        {
                            FormMainUI.bRun = false;
                            InspectFunction.isAuto = false;
                        }
                    }
                    else
                    {
                        FormMainUI.bRun = false;
                        MessageBox.Show("相机连接异常！", "提示", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    InspectFunction.isAuto = false;
                    FormMainUI.bRun = false;
                    FormMainUI.bCountNum = false;
                    Thread.Sleep(3);
                    if (_InitConfig.initConfig.comMode.TYPE == EnumData.COMType.COM)
                    {
                        if (FormMainUI.m_dicCtrlCamShow.Count == 1)
                        {
                            modbus_RTUs[0].ClosePort();
                        }
                        else
                        {
                            modbus_RTUs[0].ClosePort();
                            modbus_RTUs[1].ClosePort();
                        }
                    }
                    but_Run.Image = Resources.stop;
                    but_Run.Text = GlobalData.Config._language == EnumData.Language.english ? "Start" : "运行";
                    but_Run.BackColor = default;
                }
            }
            catch (SystemException error)
            {
                MessageFun.ShowMessage("错误：" + error.ToString());
                FormMainUI.bCountNum = false;
                return;
            }
        }
        public bool Start(Modbus_RTU[] modbus_RTUs)
        {
            try
            {
                //检测光源控制器是否链接正常
                if (_InitConfig.initConfig.bDigitLight)
                {
                    foreach (var led in DataSerializer._COMConfig.dicLed)
                    {
                        BaseData.LEDRTU ledRTU = led.Value;
                        if (!ledRTU.bOpen)
                        {
                            int try_connect = 0;
                            while (!led.Value.bOpen && try_connect < 3)
                            {
                                LEDControl.OpenLedCom(ref ledRTU);
                                try_connect++;
                                Thread.Sleep(20);
                            }
                        }
                        if (!ledRTU.bOpen)
                        {
                            MessageBox.Show($"光源控制器{led.Key}链接异常，请检查。");
                            return false;
                        }
                    }
                }
                //检测IO通讯是否正常
                if (_InitConfig.initConfig.comMode.TYPE == EnumData.COMType.IO)
                {

                    #region IO通讯
                    int try_connect = 0;
                    while (!WENYU.isOpen && try_connect < 3)
                    {
                        WENYU.OpenIO();
                        try_connect++;
                        Thread.Sleep(20);
                    }
                    if (!WENYU.isOpen)
                    {
                        MessageBox.Show("板卡通讯异常！", "提示", MessageBoxButtons.OK);
                        return false;
                    }
                    #endregion

                    InspectFunction.isAuto = true;
                    //MessageFun.ShowMessage();
                    foreach (int camID in FormMainUI.m_dicCtrlCamShow.Keys)
                    {
                        //ShowItems[] arrayShows = FormMainUI.m_dicCtrlCamShow[camID];
                        //for (int sub_cam = 0; sub_cam < arrayShows.Length; sub_cam++)
                        //{
                        //    InspectFunction TMFun = arrayShows[sub_cam].form.fun;
                        //    String strCamSer = arrayShows[sub_cam].form.m_strCamSer;
                        //    new Task(() => { TMFun.RunCam_IO(cam, sub_cam, strCamSer); }, TaskCreationOptions.LongRunning).Start();
                        //    Thread.Sleep(20);
                        //}
                    }

                }
                else if (_InitConfig.initConfig.comMode.TYPE == EnumData.COMType.NET)
                {
                    //foreach (int cam in FormMainUI.m_dicFormCamShows.Keys)
                    //{
                    //    ShowItems[] arrayShows = FormMainUI.m_dicFormCamShows[cam];
                    //    for (int sub_cam = 0; sub_cam < arrayShows.Length; sub_cam++)
                    //    {
                    //        InspectFunction TMFun = arrayShows[sub_cam].form.fun;
                    //        String strCamSer = arrayShows[sub_cam].form.m_strCamSer;
                    //        new Task(() => { TMFun.RunCam_ModbusTcp(cam, sub_cam, strCamSer); }, TaskCreationOptions.LongRunning).Start();
                    //        Thread.Sleep(20);
                    //    }
                    //}
                }
                else if (_InitConfig.initConfig.comMode.TYPE == EnumData.COMType.COM)
                {

                    InspectFunction.isAuto = true;
                    foreach (int cam in FormMainUI.m_dicCtrlCamShow.Keys)
                    {
                        if (!modbus_RTUs[cam - 1].isOpen)
                        {
                            int try_connect = 0;
                            while (!modbus_RTUs[cam - 1].isOpen && try_connect < 3)
                            {
                                modbus_RTUs[cam - 1].OpenCom(DataSerializer._PlcRTU.PlcRTU[cam - 1]);
                                try_connect++;
                                Thread.Sleep(20);
                            }
                        }
                        if (!modbus_RTUs[cam - 1].isOpen)
                        {
                            MessageBox.Show("PLC-ModbusRTU连接异常，请检查！！！", "提示", MessageBoxButtons.OK);
                            return false;
                        }

                        //ShowItems[] arrayShows = FormMainUI.m_dicFormCamShows[cam];
                        //for (int sub_cam = 0; sub_cam < arrayShows.Length; sub_cam++)
                        //{
                        //    InspectFunction TMFun = arrayShows[sub_cam].form.fun;
                        //    String strCamSer = arrayShows[sub_cam].form.m_strCamSer;
                        //    new Task(() => { TMFun.RunCam_ModbusRTU(cam, sub_cam, strCamSer, modbus_RTUs[cam - 1]); }, TaskCreationOptions.LongRunning).Start();
                        //    Thread.Sleep(20);
                        //}
                    }
                }
                else if (_InitConfig.initConfig.comMode.TYPE == EnumData.COMType.CamIO)
                {
                    InspectFunction.isAuto = true;
                    //MessageFun.ShowMessage();
                    //foreach (int cam in FormMainUI.m_dicFormCamShows.Keys)
                    //{
                    //    ShowItems[] arrayShows = FormMainUI.m_dicFormCamShows[cam];
                    //    for (int sub_cam = 0; sub_cam < arrayShows.Length; sub_cam++)
                    //    {
                    //        InspectFunction TMFun = arrayShows[sub_cam].form.fun;
                    //        //CamFunction TMcamFun = arrayShows[sub_cam].form.camFun;
                    //        String strCamSer = arrayShows[sub_cam].form.m_strCamSer;
                    //        new Task(() => { TMFun.RunCam_CamIO(cam, sub_cam, strCamSer); }, TaskCreationOptions.LongRunning).Start();
                    //        Thread.Sleep(20);
                    //    }
                    //}

                }

                Thread.Sleep(10);
                return true;
            }
            catch (Exception ex)
            {
                ("[FormHome]->[Run]:/t" + ex.Message + Environment.NewLine + ex.StackTrace).Log();
                return false;
            }
        }
        public static void Zoom()
        {
            try
            {
                foreach (int camID in FormMainUI.m_dicCtrlCamShow.Keys)
                {
                    CtrlCamShow ctrlCamShow = FormMainUI.m_dicCtrlCamShow[camID];
                    if (null != ctrlCamShow.Fun)
                    {
                        InspectFunction fun = ctrlCamShow.Fun;
                        fun.dReslutRow0 = 0;
                        fun.dReslutCol0 = 0;
                        fun.dReslutRow1 = 0;
                        fun.dReslutCol1 = 0;
                        fun.FitImageToWindow(ref fun.dReslutRow0, ref fun.dReslutCol0, ref fun.dReslutRow1, ref fun.dReslutCol1);
                    }
                }
            }
            catch (Exception)
            {
            }
        }
    }
    public class MessageFun
    {
        public static RichTextBox m_richTextBox = null;

        #region 初始化消息列表
        public static void GetRichText(RichTextBox richTextBox)
        {
            m_richTextBox = richTextBox;
        }
        //在richTextBox显示字符串消息
        public static void ShowMessage(object obj, bool bLog = false, string strEnglish = "", System.Drawing.Color color = default)
        {
            try
            {
                string str = obj.ToString();
                if (GlobalData.Config._language == EnumData.Language.english && strEnglish != "")
                {
                    str = strEnglish;
                }
                if (bLog) str.Log();
                if (null == m_richTextBox) return;
                string strDate = DateTime.Now.ToString() + "：";
                string mes = strDate + str + "\r\n";
                if (null != m_richTextBox)
                    Append(m_richTextBox, mes, color);
                Thread.Sleep(1);
            }
            catch (Exception error)
            {
                ("ShowMessage:" + error.Message).Log();
                return;
            }
        }

        private static readonly ReaderWriterLockSlim writerLock = new ReaderWriterLockSlim();
        private static void Append(RichTextBox richTextBox, string txt, System.Drawing.Color color)
        {
            try
            {
                //m_richTextBox.SelectionColor( color);
                writerLock.EnterWriteLock();
                if (richTextBox.InvokeRequired)
                {
                    richTextBox.BeginInvoke(new Action(() =>
                    {
                        richTextBox.SelectionColor = color;
                        richTextBox.AppendText(txt);
                        richTextBox.ScrollToCaret();
                        if (richTextBox.Lines.Length > 150)
                        {
                            richTextBox.Clear();
                        }
                    }));
                }
                else
                {
                    richTextBox.AppendText(txt);
                    richTextBox.ScrollToCaret();
                    if (richTextBox.Lines.Length > 150)
                    {
                        richTextBox.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                ("Append" + ex.Message + ex.StackTrace).Log();
                return;
            }
            finally
            {
                writerLock.ExitWriteLock();
            }
        }

        #endregion

        public static FontShowParam ReadFontParam(int cam, InspectItem item)
        {
            FontShowParam fontParam = new FontShowParam();
            try
            {
                //读取字体设置参数
                if (null != DataSerializer._globalData.dicFontShowSet && DataSerializer._globalData.dicFontShowSet.ContainsKey(cam) && DataSerializer._globalData.dicFontShowSet[cam].ContainsKey(item))
                {
                    fontParam = DataSerializer._globalData.dicFontShowSet[cam][item];
                }
                else
                {
                    //默认字体显示设置
                    fontParam = new FontShowParam()
                    {
                        nRowStartPos = 2000,
                        nColStartPos = 200,
                        nFrontSize = 15,
                        nRowGap = 100,
                        nColGap = 100,
                    };
                }
            }
            catch (Exception ex)
            {
                MessageFun.ShowMessage("ReadFontParam：" + ex.ToString());
            }
            return fontParam;
        }
    }

    public class UIConfig
    {
        public static void CreateFormTeachMaster(int camID)
        {
            FormTeachMaster teachmaster = new FormTeachMaster(camID);
            FormMainUI.m_PanelShow.Controls.Clear();
            FormMainUI.m_PanelShow.Controls.Add(teachmaster);
        }

        public static void MoveCamPos(int camID)
        {
            try
            {
                var M16 = new Address(SoftType.M, 16, DataType.Bit);
                List<Address> addressesPlc = [M16];
                var rRes = FormMainUI._plc.ReadDeviceRandom(addressesPlc, out var datas);
                int key = M16.GetHashCode();
                if (rRes == 0)
                {
                    if (Convert.ToInt32(datas[key].Value) != 1)
                    {
                        MessageBox.Show("请等待设备回原完成。");
                        return;
                    }
                }
                if (null != DataSerializer._globalData.dicInspectList && DataSerializer._globalData.dicInspectList.ContainsKey(camID))
                {
                    List<InspectData.InspectItem> listItem = DataSerializer._globalData.dicInspectList[camID];
                    foreach (InspectData.InspectItem item in listItem)
                    {
                        switch (item)
                        {
                            case InspectData.InspectItem.Front:
                                var addr_Front = new Hi.Ltd.Data.Address(Hi.Ltd.Enumerations.SoftType.M, 2033, Hi.Ltd.Enumerations.DataType.Bit);
                                addr_Front.Value = 1;
                                FormMainUI._plc.WriteDevice(addr_Front);
                                break;
                            case InspectData.InspectItem.LeftSide:
                                var addr_SidePin1 = new Hi.Ltd.Data.Address(Hi.Ltd.Enumerations.SoftType.M, 2133, Hi.Ltd.Enumerations.DataType.Bit);
                                addr_SidePin1.Value = 1;
                                FormMainUI._plc.WriteDevice(addr_SidePin1);
                                break;
                            case InspectData.InspectItem.RightSide:
                                var addr_SidePin2 = new Hi.Ltd.Data.Address(Hi.Ltd.Enumerations.SoftType.M, 2134, Hi.Ltd.Enumerations.DataType.Bit);
                                addr_SidePin2.Value = 1;
                                FormMainUI._plc.WriteDevice(addr_SidePin2);
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                StaticFun.MessageFun.ShowMessage(ex);
            }

        }
        //public static Dictionary<int, InspectData.ShowItems[]> InitShowUI(ContextMenuStrip contextMenuStrip, TableLayoutPanel tableLayoutPanel, bool bDisp = false)
        //{
        //    Dictionary<int, InspectData.ShowItems[]> dic_formCamShows = new Dictionary<int, ShowItems[]>();
        //    try
        //    {
        //        InspectData.ShowItems[] showItems;
        //        foreach (int cam in GlobalData.Config._InitConfig.initConfig.dic_SubCam.Keys)
        //        {
        //            string strCamSer = "";
        //            if (_CamConfig.camConfig.ContainsKey(cam))
        //                strCamSer = _CamConfig.camConfig[cam];
        //            int num = GlobalData.Config._InitConfig.initConfig.dic_SubCam[cam];
        //            FormCamShow formCamShow = new FormCamShow(strCamSer, cam, 0);
        //            if (bDisp)
        //            {
        //                formCamShow.label_d.Visible = true;
        //                formCamShow.label_x.Visible = true;
        //            }
        //            if (0 != num)
        //            {
        //                showItems = new InspectData.ShowItems[num + 1];
        //                showItems[0].form = formCamShow;
        //                for (int i = 0; i < num; i++)
        //                {
        //                    FormCamShow formCamShow_sprite = new FormCamShow(strCamSer, cam, i + 1);
        //                    if (bDisp)
        //                    {
        //                        formCamShow_sprite.label_d.Visible = true;
        //                        formCamShow_sprite.label_x.Visible = true;
        //                    }
        //                    formCamShow_sprite.TopLevel = false;
        //                    formCamShow_sprite.Visible = true;
        //                    formCamShow_sprite.Dock = DockStyle.Fill;
        //                    showItems[i + 1].form = formCamShow_sprite;
        //                }
        //                dic_formCamShows.Add(cam, showItems);
        //            }
        //            else
        //            {
        //                dic_formCamShows.Add(cam, new InspectData.ShowItems[1] { new InspectData.ShowItems() { form = formCamShow } });
        //            }
        //        }
        //        contextMenuStrip.Items.Clear();
        //        foreach (int cam in _InitConfig.initConfig.dic_SubCam.Keys)
        //        {
        //            string strCam = "相机" + cam.ToString();
        //            contextMenuStrip.Items.Add(strCam);
        //            contextMenuStrip.Items[contextMenuStrip.Items.Count - 1].Image = Resources.camera2;
        //            int num = _InitConfig.initConfig.dic_SubCam[cam];
        //            for (int i = 0; i < num; i++)
        //            {
        //                strCam = "相机" + cam.ToString() + "-" + (i + 1).ToString();
        //                contextMenuStrip.Items.Add(strCam);
        //                contextMenuStrip.Items[contextMenuStrip.Items.Count - 1].Image = Resources.subcam;
        //            }
        //        }
        //        //若已经配置，则加载已配置好的相机画面
        //        RefeshCamShow(tableLayoutPanel, dic_formCamShows);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageFun.ShowMessage(ex.ToString());
        //    }
        //    return dic_formCamShows;
        //}

        //public static void RefeshCamShow(TableLayoutPanel tableLayoutPanel, Dictionary<int, InspectData.ShowItems[]> dic_formCamShows)
        //{
        //    //若已经配置，则加载已配置好的相机画面
        //    foreach (int panelSer in DataSerializer._globalData.dicCamShowParam.Keys)
        //    {
        //        CamShowParam camshow = DataSerializer._globalData.dicCamShowParam[panelSer];
        //        foreach (Control panel in tableLayoutPanel.Controls)
        //        {
        //            if (panel.Name == "panel" + panelSer.ToString())
        //            {
        //                panel.Controls.Clear();
        //                panel.Controls.Add(dic_formCamShows[camshow.cam][camshow.sub_cam].form);
        //            }
        //        }
        //    }
        //}
        ////public static CamShowParam ConfigShowItems(object sender, ToolStripItemClickedEventArgs e, ref Dictionary<int, InspectData.ShowItems[]> dic_formCamShows)
        //{
        //    CamShowParam camshow = new CamShowParam();
        //    try
        //    {
        //        string strItem = e.ClickedItem.Text;
        //        int ncam = int.Parse(strItem.Substring(2, 1));
        //        int sub_cam = 0;
        //        if (strItem.Length > 3)
        //        {
        //            sub_cam = int.Parse(strItem.Substring(4, 1));
        //        }
        //        if (sender is ContextMenuStrip cms)
        //        {
        //            var panel = (Panel)cms.SourceControl;
        //            dic_formCamShows[ncam][sub_cam].panel = panel;
        //            panel.Controls.Clear();
        //            panel.Controls.Add(dic_formCamShows[ncam][sub_cam].form);
        //            camshow.cam = ncam;
        //            camshow.sub_cam = sub_cam;
        //            int ser = int.Parse(panel.Name.Substring(5, 1));
        //            if (DataSerializer._globalData.dicCamShowParam.ContainsKey(ser))
        //            {
        //                DataSerializer._globalData.dicCamShowParam[ser] = camshow;
        //            }
        //            else
        //            {
        //                DataSerializer._globalData.dicCamShowParam.Add(ser, camshow);
        //            }

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ex.ToString();
        //    }
        //    return camshow;
        //}
        public static InspectFunction RefreshFun(int camID, out string str_CamSer)
        {
            InspectFunction Fun = null;
            str_CamSer = "";
            try
            {
                if (FormMainUI.m_dicCtrlCamShow.ContainsKey(camID))
                {
                    Fun = FormMainUI.m_dicCtrlCamShow[camID].Fun;
                    str_CamSer = FormMainUI.m_dicCtrlCamShow[camID].strCamSer;
                }
            }
            catch (Exception ex)
            {
                StaticFun.MessageFun.ShowMessage(ex);
            }
            return Fun;
        }

        /// <summary>
        /// 刷新界面的数据统计界面
        /// </summary>
        /// <param name="tLPanel"></param> 数据统计form依靠的控件
        /// <param name="dicFormSTATS"></param> 返回数据统计forms
        /// <param name="nRows"></param>  控件平均nrows行,if nRows=1(默认值)，否则 nRows=2,将nCols/2向上取整
        public static void RefreshSTATS(TableLayoutPanel tLPanel, out Dictionary<CamInspectItem, CtrlStates> dicFormSTATS, int nRows = 1)
        {
            dicFormSTATS = new Dictionary<CamInspectItem, CtrlStates>();   //计数用form窗体个数
            int nCheckItem = 0;
            double width = 0;
            try
            {
                if (DataSerializer._globalData.dicInspectList?.Count != 0)
                {
                    dicFormSTATS.Clear();
                    tLPanel.Controls.Clear();
                    foreach (int cam in DataSerializer._globalData.dicInspectList.Keys)
                    {
                        int main_cam = (cam % 100) / 10 == 0 ? cam : ((cam % 100) / 10);
                        if (main_cam > GlobalData.Config._InitConfig.initConfig.CamNum)
                        {
                            break;  //如果主相机数大于枚举的相机数量，则跳出
                        }
                        nCheckItem += DataSerializer._globalData.dicInspectList[cam].Count;
                    }

                    if (1 == nRows)
                    {
                        tLPanel.ColumnCount = nCheckItem;
                        width = 100.0 / tLPanel.ColumnCount;
                    }
                    else
                    {
                        //默认nRows == 2
                        tLPanel.ColumnCount = (int)Math.Ceiling(nCheckItem / 2d);
                        tLPanel.RowCount = 2;
                    }
                    width = 100.0 / tLPanel.ColumnCount;
                    tLPanel.RowStyles.Clear();
                    tLPanel.ColumnStyles.Clear();
                    List<InspectData.CamInspectItem> list_camItem = new List<InspectData.CamInspectItem>();
                    //FormSTATS form = new FormSTATS(1, strCheckItem: "");
                    foreach (int cam in DataSerializer._globalData.dicInspectList.Keys)
                    {
                        CamInspectItem camItem = new CamInspectItem();
                        camItem.cam = cam;
                        List<InspectItem> listItem = DataSerializer._globalData.dicInspectList[cam];
                        foreach (InspectItem item in listItem)
                        {
                            camItem.item = item;
                            list_camItem.Add(camItem);
                        }
                    }
                    int n = 0;
                    for (int row = 0; row < nRows; row++)
                    {
                        tLPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50f));
                        for (int col = 0; col < tLPanel.ColumnCount; col++)
                        {
                            tLPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, (float)width));
                            //int cam = list_camItem[n].cam;
                            //InspectItem item = list_camItem[n].item;
                            //form = new FormSTATS(cam, TMFunction.GetStrCheckItem(item))
                            //{
                            //    TopLevel = false,
                            //    Visible = true,
                            //    Dock = DockStyle.Fill,
                            //};

                            CtrlStates form = new CtrlStates();
                            tLPanel.Controls.Add(form, col, row);
                            dicFormSTATS.Add(list_camItem[n], form);
                            n++;
                        }
                    }

                }
                else
                {
                    MessageBox.Show("请到【管理员】配置检测项目。");
                    return;
                }
            }
            catch (SystemException ex)
            {
                ex.ToString();
                return;
            }
        }

        /// <summary>
        /// 根据窗体大小调整控件大小
        /// </summary>
        /// <param name="newx">窗体宽度缩放比例</param>
        /// <param name="newy">窗体高度缩放比例</param>
        /// <param name="cons">随窗体改变控件大小</param>
        public void setControls(float newx, float newy, Control cons)
        {
            //遍历窗体中的控件，重新设置控件的值
            foreach (Control con in cons.Controls)
            {

                string[] mytag = con.Tag.ToString().Split(new char[] { ':' });//获取控件的Tag属性值，并分割后存储字符串数组
                float a = System.Convert.ToSingle(mytag[0]) * newx;//根据窗体缩放比例确定控件的值，宽度
                con.Width = (int)a;//宽度
                a = System.Convert.ToSingle(mytag[1]) * newy;//高度
                con.Height = (int)(a);
                a = System.Convert.ToSingle(mytag[2]) * newx;//左边距离
                con.Left = (int)(a);
                a = System.Convert.ToSingle(mytag[3]) * newy;//上边缘距离
                con.Top = (int)(a);
                Single currentSize = System.Convert.ToSingle(mytag[4]) * newy;//字体大小
                con.Font = new Font(con.Font.Name, currentSize, con.Font.Style, con.Font.Unit);
                if (con.Controls.Count > 0)
                {
                    setControls(newx, newy, con);
                }
            }
        }

        /// <summary>
        /// 将控件的宽，高，左边距，顶边距和字体大小暂存到tag属性中,Load属性中加载
        /// </summary>
        /// <param name="cons">递归控件中的控件</param>
        private void setTag(Control cons)
        {
            foreach (Control con in cons.Controls)//循环窗体中的控件
            {
                con.Tag = con.Width + ":" + con.Height + ":" + con.Left + ":" + con.Top + ":" + con.Font.Size;
                if (con.Controls.Count > 0)
                    setTag(con);
            }
        }
    }

    public class LoadConfig
    {
        public static EnumData.Language LoadLanguage()
        {
            EnumData.Language language = new EnumData.Language();
            try
            {
                string strData = File.ReadAllText(GlobalPath.SavePath.LanguagePath);
                var DynamicObject = JsonConvert.DeserializeObject<EnumData.Language>(strData);
                language = DynamicObject;
            }
            catch (Exception)
            {
                MessageFun.ShowMessage("Language loading error.");
            }
            return language;
        }
        public static bool LoadTMData(string serDataName)
        {
            try
            {
                string loadFile = GlobalPath.SavePath.GlobalDataPath + serDataName + ".json";
                string strFile = System.IO.File.ReadAllText(loadFile);
                var DynamicObject = JsonConvert.DeserializeObject<DataSerializer.GlobalData>(strFile);
                DataSerializer._globalData = (DataSerializer.GlobalData)DynamicObject;
                return true;
            }
            catch (Exception)
            {
                MessageFun.ShowMessage("未找到示教参数，请设置!");
                MessageBox.Show("未找到示教参数，请设置!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

        }
        //加载相机曝光等参数
        public static Dictionary<string, CamCommon.CamParam> LoadCamParam()
        {
            Dictionary<string, CamCommon.CamParam> camParam = new Dictionary<string, CamCommon.CamParam>();
            try
            {
                if (System.IO.File.Exists(GlobalPath.SavePath.CamConfigPath))
                {
                    string OutData = System.IO.File.ReadAllText(GlobalPath.SavePath.CamConfigPath);
                    var expourse_cam = JsonConvert.DeserializeObject<GlobalData.Config.CamConfig>(OutData);
                    //camParam = expourse_cam.camParam;
                }
            }
            catch (Exception)
            {
                MessageFun.ShowMessage("相机曝光等参数加载出错。");
            }
            return camParam;
        }

        /// <summary>
        /// 初始化导入模板ID
        /// </summary>
        /// <param name="fileName"></param> json文件名称
        /// <returns></returns>
        public static bool LoadModelID(string fileName)
        {
            try
            {
                //加载模板ID
                string strFilePath = System.IO.Path.Combine(GlobalPath.SavePath.ModelPath, fileName);
                DirectoryInfo theFolder = new DirectoryInfo(strFilePath);
                DirectoryInfo[] fileInfo = theFolder.GetDirectories();
                if (0 == fileInfo.Length)
                {
                    MessageFun.ShowMessage("无文件，模板ID导入失败！", true, strEnglish: "No file, template ID import failed!");
                    MessageBox.Show("模板ID导入失败！", "Template ID import failed!");
                    return false;
                }
                foreach (DirectoryInfo NextFile in fileInfo) //遍历文件
                {
                    if (NextFile.Name.Length > 5)
                    {
                        if (GlobalData.Config._language != EnumData.Language.english)
                        {
                            continue;
                        }
                    }
                    InspectFunction.GetCameraNum(NextFile.Name, out int cam, out int sub_cam);
                    ReadID(strFilePath, cam, sub_cam);
                    string strModelImagePath = Path.Combine(GlobalPath.SavePath.ModelImagePath, fileName);
                    CopyMoveModelImage(strModelImagePath, cam, sub_cam);

                }
                MessageFun.ShowMessage("模板ID导入成功！", true, strEnglish: "Template ID import failed!");
                return true;
            }
            catch (Exception ex)
            {
                MessageFun.ShowMessage("模板ID导入失败！" + ex.ToString(), true, strEnglish: "Template ID import failed!" + ex.ToString());
                return false;

            }
        }
        private static void ReadID(string strFilePath, int cam, int sub_cam)
        {
            try
            {
                int camID = cam * 10 + sub_cam;
                DirectoryInfo theFolder11 = new DirectoryInfo("\\");
                string name = GlobalData.Config._language == EnumData.Language.english ? "Camera" : "相机";
                theFolder11 = new DirectoryInfo(strFilePath + "\\" + name + cam.ToString() + sub_cam.ToString() + "\\");
                FileInfo[] files = theFolder11.GetFiles();
                List<string> list_LineColorModel = new List<string>();
                foreach (FileInfo NextFile1 in files) //遍历文件
                {
                    string strFile = theFolder11 + NextFile1.ToString();
                    if (NextFile1.Name.Contains("插件模板") || NextFile1.Name.Contains("正面模板") || NextFile1.Name.Contains("Shell insertion template"))
                    {
                        object nID = new object();
                        if (NextFile1.Name.Contains("ncm"))
                        {
                            Function.ReadModelFromFile(BaseData.ModelType.ncc, strFile, out nID);
                        }
                        else
                        {
                            Function.ReadModelFromFile(BaseData.ModelType.contour, strFile, out nID);
                        }
                        FrontParam arrayItem = DataSerializer._globalData.dic_FrontParam[camID];
                        if (NextFile1.Name.Contains("正面模板"))
                        {
                            arrayItem.modelID = nID;
                        }
                        DataSerializer._globalData.dic_FrontParam[camID] = arrayItem;
                        CopyModelFile(strFile, cam, sub_cam);
                    }
                    else if (NextFile1.Name.Contains("data_code_model"))
                    {
                        Function.ReadModelFromFile(BaseData.ModelType.dcm, strFile, out object nID);
                        FrontParam arrayItem = DataSerializer._globalData.dic_FrontParam[camID];
                        arrayItem.QRCode.hv_Handel = nID;
                        DataSerializer._globalData.dic_FrontParam[camID] = arrayItem;
                        CopyModelFile(strFile, cam, sub_cam);
                    }
                }
                //读取线序检测的模板
                //if (DataSerializer._globalData.dic_LineColor.ContainsKey(cam2))
                //{
                //    var dic_lineColor = DataSerializer._globalData.dic_LineColor[cam2];
                //    //ReadColorID(ref dic_lineColor.listColorData, list_LineColorModel);
                //    DataSerializer._globalData.dic_LineColor[cam2] = dic_lineColor;
                //}
                //插壳线序模板
                //if (DataSerializer._globalData.dic_RubberParam.ContainsKey(cam2))
                //{
                //    var dic_rubberParam = DataSerializer._globalData.dic_RubberParam[cam2];
                //    //ReadColorID(ref dic_rubberParam.lineColor.listColorID, list_RubberLineColorModel);
                //    DataSerializer._globalData.dic_RubberParam[cam2] = dic_rubberParam;
                //}  DataSerializer._globalData.dic_StripLenParam[cam2] = dic_stripLen;

            }
            catch (Exception ex)
            {
                MessageFun.ShowMessage($"模板ID读取错误：{ex}", true);
                return;
            }
        }

        private static void CopyMoveModelImage(string strFilePath, int cam, int sub_cam)
        {
            try
            {
                DirectoryInfo theFolder11 = new DirectoryInfo("\\");
                string name = "";
                if (GlobalData.Config._language == EnumData.Language.english)
                {
                    name = "Camera";
                }
                else
                {
                    name = "相机";
                }
                if (sub_cam == 0)
                {
                    theFolder11 = new DirectoryInfo(strFilePath + "\\" + name + cam.ToString() + "\\");
                }
                else
                {
                    theFolder11 = new DirectoryInfo(strFilePath + "\\" + name + cam.ToString() + "_" + sub_cam.ToString() + "\\");
                }

                FileInfo[] files = theFolder11.GetFiles();
                List<string> list_LineColorModel = new List<string>();
                List<string> list_SkinPosLineColorModel = new List<string>();
                foreach (FileInfo NextFile1 in files) //遍历文件
                {
                    string strFile = "";
                    if (sub_cam == 0)
                    {
                        strFile = strFilePath + "\\" + name + cam.ToString() + "\\" + NextFile1.ToString();
                    }
                    else
                    {
                        strFile = strFilePath + "\\" + name + cam.ToString() + "_" + sub_cam.ToString() + "\\" + NextFile1.ToString();
                    }
                    if (NextFile1.Name.Contains("插壳模板图像") || NextFile1.Name.Contains("Shell template image"))
                    {
                        CopyModelImage(strFile, cam, sub_cam);
                    }
                    else if (NextFile1.Name.Contains("端子模板图像") || NextFile1.Name.Contains("Terminal Template Image"))
                    {

                        CopyModelImage(strFile, cam, sub_cam);
                    }
                    else if (NextFile1.Name.Contains("剥皮模板图像") || NextFile1.Name.Contains("Peeling Template Image"))
                    {

                        CopyModelImage(strFile, cam, sub_cam);
                    }
                    if (NextFile1.Name.Contains("线序模板图像") || NextFile1.Name.Contains("Line sequence template image"))
                    {
                        list_LineColorModel.Add(strFile);
                        CopyModelImage(strFile, cam, sub_cam);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageFun.ShowMessage("模板图像读取错误：" + ex.ToString());
                ("模板图像读取错误：" + ex.ToString()).Log();
                return;
            }
        }

        private static void ReadColorID(ref List<ColorID> listColorData, List<string> listPath)
        {
            try
            {
                if (null != listColorData && listColorData.Count != 0)
                {
                    int add = 0, run = 0;
                    List<ColorID> listColorIDNew = new List<ColorID>();
                    listPath.RemoveAll(a => !a.Contains("线序模板") && !a.Contains("线序模型"));
                    while (add < listPath.Count)
                    {
                        for (int n = 0; n < listPath.Count; n++)
                        {
                            char[] delimiterChars = { '\\' };
                            string[] path = listPath[n].Split(delimiterChars);
                            string result = System.Text.RegularExpressions.Regex.Replace(path[path.Count() - 1], @"[^0-9]+", "");
                            int name = int.Parse(result);
                            if (add == name)
                            {
                                //if (add < listColorID.Count)
                                //{
                                ColorID colorID = new ColorID();
                                //colorID.dGray = listColorID[add].dGray;
                                InspectFunction.ReadGmmModel(listPath[n], out HTuple[] hv_colorID);
                                colorID.ID = hv_colorID;
                                listColorIDNew.Add(colorID);
                                add++;
                                break;
                                //}

                            }
                        }
                    }
                    //listColorID = listColorIDNew;
                }
            }
            catch (Exception ex)
            {
                MessageFun.ShowMessage("线序模板ID导入错误：" + ex.ToString());
            }
        }

        private static void CopyModelFile(string fileName, int ncam, int sub_cam)
        {
            try
            {
                //目标文件夹
                string folderPath = "";
                //if (sub_cam == 0)
                //{

                //    folderPath = GlobalPath.SavePath.ModelPath + "相机" + ncam.ToString();
                //}
                //else
                //{
                folderPath = GlobalPath.SavePath.ModelPath + "相机" + ncam.ToString() + sub_cam.ToString();
                //}

                if (!Directory.Exists(folderPath))
                    Directory.CreateDirectory(folderPath);
                //目标文件名
                string strName = Path.GetFileName(fileName);
                //目标路径
                string targetPath = Path.Combine(folderPath, strName);
                FileInfo file = new FileInfo(fileName);
                if (file.Exists)
                {
                    //true 覆盖已存在的同名文件，false不覆盖
                    file.CopyTo(targetPath, true);
                }
            }
            catch (Exception ex)
            {
                (ex.Message + ex.StackTrace).Log();
                MessageFun.ShowMessage(ex.ToString());
            }
        }

        private static void CopyModelImage(string fileName, int ncam, int sub_cam)
        {
            try
            {
                //目标文件夹
                string folderPath = "";
                if (sub_cam == 0)
                {

                    folderPath = GlobalPath.SavePath.ModelImagePath + "相机" + ncam.ToString();
                }
                else
                {
                    folderPath = GlobalPath.SavePath.ModelImagePath + "相机" + ncam.ToString() + "_" + sub_cam.ToString();
                }

                if (!Directory.Exists(folderPath))
                    Directory.CreateDirectory(folderPath);
                //目标文件名
                string strName = Path.GetFileName(fileName);
                //目标路径
                string targetPath = Path.Combine(folderPath, strName);
                FileInfo file = new FileInfo(fileName);
                if (file.Exists)
                {
                    //true 覆盖已存在的同名文件，false不覆盖
                    file.CopyTo(targetPath, true);
                }
            }
            catch (Exception ex)
            {
                (ex.Message + ex.StackTrace).Log();
                MessageFun.ShowMessage(ex.ToString());
            }
        }

        public static SetImageSaveDays LoadImageSaveDays()
        {
            SetImageSaveDays days = new SetImageSaveDays();
            try
            {
                string strData = System.IO.File.ReadAllText(GlobalPath.SavePath.TimePath);
                strData = Registered.DESDecrypt(strData);
                var DynamicObject = JsonConvert.DeserializeObject<SetImageSaveDays>(strData);
                days = DynamicObject;
            }
            catch (Exception)
            {
                MessageFun.ShowMessage("图片保存天数加载错误。");
            }
            return days;
        }
        public static void LoadCOMConfig()
        {
            try
            {
                string strData = System.IO.File.ReadAllText(GlobalPath.SavePath.IOPath);
                var DynamicObject = JsonConvert.DeserializeObject<DataSerializer.GlobalData_COM>(strData);
                DataSerializer._COMConfig = DynamicObject;
            }
            catch (Exception)
            {
                MessageFun.ShowMessage("IO配置文件加载错误。");
            }
        }

        public static void LoadJsonData(System.Windows.Forms.ListView listView)
        {
            try
            {
                listView.Items.Clear();
                //路径
                DirectoryInfo folder = new DirectoryInfo(GlobalPath.SavePath.GlobalDataPath);
                FileInfo[] fileInfo = folder.GetFiles();

                foreach (FileInfo NextFile in fileInfo) //遍历文件
                {
                    if (NextFile.Name.Contains(".json") && NextFile.Name != "NewestFileName.json")
                    {
                        int len = NextFile.Extension.Length;
                        string name = NextFile.Name.Substring(0, (NextFile.Name.Length - len));
                        string createTime = NextFile.LastWriteTime.ToString();
                        int n = listView.Items.Count;
                        listView.Items.Add(n.ToString());
                        listView.Items[n].SubItems.Add(name);
                        listView.Items[n].SubItems.Add(createTime);
                        listView.Items[n].EnsureVisible();
                    }
                }
            }
            catch (Exception ex)
            {
                (ex.Message + ex.StackTrace).Log();
                MessageFun.ShowMessage(ex.ToString());
            }
        }

        /// <summary>
        /// 加载【联系我们】数据
        /// </summary>
        public static void LoadContactData()
        {
            try
            {
                string strData = System.IO.File.ReadAllText(GlobalPath.SavePath.ContactPath);
                var DynamicObject = JsonConvert.DeserializeObject<GlobalData.Config.ContactUs>(strData);
                GlobalData.Config._Contact = DynamicObject;
            }
            catch (Exception)
            {
                MessageFun.ShowMessage("IO配置文件加载错误。");
            }
        }
    }

    public class SaveData
    {
        public static bool SaveLanguage(EnumData.Language language)
        {
            try
            {
                GlobalData.Config._language = language;
                var json = JsonConvert.SerializeObject(GlobalData.Config._language);
                System.IO.File.WriteAllText(GlobalPath.SavePath.LanguagePath, json);
                return true;
            }
            catch (Exception ex)
            {
                MessageFun.ShowMessage("Langua serialize error");
                return false;
            }
        }
        public static void SaveCamConfig()
        {
            try
            {
                //保存到配置文件
                var json = JsonConvert.SerializeObject(GlobalData.Config._CamConfig);
                System.IO.File.WriteAllText(GlobalPath.SavePath.CamConfigPath, json);
            }
            catch (Exception)
            {
                //MessageBox.Show("修改保存失败！");
            }
        }
        public static void SaveOtherConfig(BaseData.OtherConfig otherConfiData)
        {
            try
            {
                GlobalData.Config.InitConfig config = GlobalData.Config._InitConfig;
                config.otherConfig = otherConfiData;
                var json = JsonConvert.SerializeObject(config);
                System.IO.File.WriteAllText(GlobalPath.SavePath.InitConfigPath, json);
            }
            catch (Exception)
            {
                MessageBox.Show("修改保存失败！");
            }
        }

        /// <summary>
        /// 保存IO配置
        /// </summary>
        /// <param name="strCheckItem"></param> 检测项
        /// <param name="nSelIO"></param>  该检测项的IO点位
        /// <param name="nInorOut"></param> 此次保存输入点位还是输出点位 0：输入 1：输出
        public static void SaveIOConfig(InspectData.IOSet ioSet)
        {
            try
            {
                bool bContain = false;
                if (DataSerializer._COMConfig.listIOSet.Count != 0)
                {

                    for (int i = 0; i < DataSerializer._COMConfig.listIOSet.Count; i++)
                    {
                        IOSet io = DataSerializer._COMConfig.listIOSet[i];
                        if (ioSet.camItem.cam == io.camItem.cam && ioSet.camItem.item == io.camItem.item)
                        {
                            DataSerializer._COMConfig.listIOSet[i] = ioSet;
                            bContain = true;
                        }
                    }
                }
                if (!bContain)
                {
                    DataSerializer._COMConfig.listIOSet.Add(ioSet);
                }
                var json = JsonConvert.SerializeObject(DataSerializer._COMConfig);
                System.IO.File.WriteAllText(GlobalPath.SavePath.IOPath, json);
            }
            catch (Exception ex)
            {
                ("IO配置保存失败:" + ex.ToString()).Log();
                MessageFun.ShowMessage("IO配置保存失败:" + ex.ToString());
            }
        }

        //public static void SaveLightConfig(LightCtrlSet lightCtrlSet)
        //{
        //    try
        //    {
        //        bool bContain = false;
        //        List<int> Del = new List<int>();
        //        if (DataSerializer._globalData.listLightCtrl.Count != 0)
        //        {
        //            for (int i = 0; i < DataSerializer._globalData.listLightCtrl.Count; i++)
        //            {
        //                LightCtrlSet orgLightSet = DataSerializer._globalData.listLightCtrl[i];
        //                if (lightCtrlSet.camItem.cam == orgLightSet.camItem.cam && lightCtrlSet.camItem.item == orgLightSet.camItem.item)
        //                {
        //                    orgLightSet.CH = new bool[6];
        //                    orgLightSet.CH = lightCtrlSet.CH;
        //                    orgLightSet.nBrightness = new int[6];
        //                    orgLightSet.nBrightness = lightCtrlSet.nBrightness;
        //                    DataSerializer._globalData.listLightCtrl[i] = orgLightSet;
        //                    bContain = true;
        //                }
        //            }
        //        }
        //        if (!bContain)
        //        {
        //            DataSerializer._globalData.listLightCtrl.Add(lightCtrlSet);
        //        }
        //        //var json = JsonConvert.SerializeObject(TMData_Serializer._COMConfig);
        //        //System.IO.File.WriteAllText(GlobalPath.SavePath.IOPath, json);
        //    }
        //    catch (Exception ex)
        //    {
        //        ("光源配置保存失败:" + ex.ToString()).Log();
        //        MessageFun.ShowMessage("光源配置保存失败:" + ex.ToString());
        //    }
        //}

        /// <summary>
        /// 保存【联系我们】数据
        /// </summary>
        public static void SaveContactData()
        {
            try
            {
                //保存到配置文件
                var json = JsonConvert.SerializeObject(GlobalData.Config._Contact);
                System.IO.File.WriteAllText(GlobalPath.SavePath.ContactPath, json);
            }
            catch (Exception)
            {
                //MessageBox.Show("修改保存失败！");
            }
        }

        public static void SaveTMData()
        {
            try
            {
                var json = JsonConvert.SerializeObject(DataSerializer._globalData);
                if (string.IsNullOrEmpty(json))
                {
                    return;
                }
                System.IO.File.WriteAllText(GlobalPath.SavePath.GlobalDataPath, json);
            }
            catch (Exception ex)
            {
                StaticFun.MessageFun.ShowMessage($"检测数据序列化保存出错。{ex}", true, strEnglish: "Data saving failed!");
            }
            return;
        }

    }

    public class DelectData
    {
        public static void DelectJsonFile(string selectFile, System.Windows.Forms.ListView listView)
        {
            try
            {
                //删除json文件
                System.IO.File.Delete(GlobalPath.SavePath.GlobalDataPath + selectFile + ".json");
                //删除模板文件夹及其下文件
                Directory.Delete(GlobalPath.SavePath.ModelPath + selectFile, true);
                //删除模板图像
                Directory.Delete(GlobalPath.SavePath.ModelImagePath + selectFile, true);
                LoadConfig.LoadJsonData(listView);
            }
            catch (Exception ex)
            {
                MessageFun.ShowMessage("删除文件" + selectFile + "出错：" + ex.ToString());
                return;
            }
        }
    }

    public class Tools
    {
        /// <summary>
        /// 计算二位数的十位和个位数字分别是多少
        /// </summary>
        /// <param name="ncam"></param> 输入的二位数
        /// <param name="unit"></param>返回个位
        /// <returns></returns> 返回十位
        public static int SplitInt(int ncam, out int unit)
        {
            int ten = -1;
            unit = -1;
            try
            {
                ten = (ncam % 100) / 10 == 0 ? ncam : ((ncam % 100) / 10);
                unit = (ncam % 100) / 10 == 0 ? 0 : (ncam % 10);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return ten;
        }

    }

    public class TCP
    {
        public static Address Deserialize(string strAddress, bool isStandard = false)
        {
            if (string.IsNullOrWhiteSpace(strAddress))
            {
                return null;
            }
            //执行标准转换
            if (isStandard)
            {
                string[] array = strAddress.Split(',');
                if (array.Length < 8)
                {
                    return null;
                }
                if (!Enum.TryParse<SoftType>(array[0], out var result) || !ushort.TryParse(array[1], out var result2) || !Enum.TryParse<DataType>(array[2], out var result3) || !int.TryParse(array[3], out var result4) || !int.TryParse(array[4], out var result5) || !ushort.TryParse(array[5], out var result6) || !Enum.TryParse<NumberBase>(array[6], out var result7) || !short.TryParse(array[7], out var result8))
                {
                    return null;
                }
                return new Address(result, result2, result3, result4, result5, result8, result6, result7);
            }
            else
            {
                if (strAddress.Contains(":"))
                {
                    string[] array = strAddress.Split(ASCII.CLN);
                    if (array.Length == 2)
                    {

                        if (!Enum.TryParse<DataType>(array[1], out var datatype))
                        {
                            return null;
                        }
                        var softStr = array[0].Substring(0, 1);

                        if (!Enum.TryParse<SoftType>(softStr, out var softType))
                        {
                            return null;
                        }

                        var indexStr = array[0].Substring(1, (int)softStr.Length - 2);

                        int index = indexStr.ToInt32();

                        return new Address(softType, index, datatype);
                    }
                    return null;
                }
                else
                {
                    var softStr = strAddress.Substring(0, 1);

                    if (!Enum.TryParse<SoftType>(softStr, out var softType))
                    {
                        return null;
                    }

                    var indexStr = strAddress.Substring(1, (int)strAddress.Length - 1);

                    int index = indexStr.ToInt32();

                    return new Address(softType, index);
                }
            }
        }

        /// <summary>
        /// 将地址转换成字符串
        /// </summary>
        /// <param name="addr"></param>
        /// <returns></returns>
        /// <remarks>
        /// 例如： M100的地址 转换成字符串 “M100” 
        /// 例如： D100的地址  Int类型 转换成字符串 “D100:Int32”
        /// 
        /// </remarks>
        public static string Serialize(Address addr, bool isStandard = false)
        {
            if (!isStandard)
            {
                if (addr.DataType == DataType.Bit)
                {
                    return $"{addr.SoftType}{addr.Index}";
                }
                else
                {
                    return $"{addr.SoftType}{addr.Index}:{addr.DataType}";
                }
            }
            //标准转换
            return addr.ToString();


        }
    }
}

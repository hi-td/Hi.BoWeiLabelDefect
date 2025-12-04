#define DOG
using BaseData;
using CamSDK;
using GlobalPath;
using Hi.Ltd;
using Hi.Ltd.Data;
using Hi.Ltd.Enumerations;
using hzjd_modbusRTU;
using Microsoft.Win32;
using Newtonsoft.Json;
using StaticFun;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using VisionPlatform.Auxiliary;
using VisionPlatform.多线插.PLC交互窗口;
using VisionPlatform.多线插.历史记录;
using WENYU_IO;
using static VisionPlatform.Auxiliary.Dog;
using static VisionPlatform.Auxiliary.Variable;
using static VisionPlatform.InspectData;
using static VisionPlatform.Security.Md5;
namespace VisionPlatform
{
    public partial class FormMainUI : Form
    {
        public static IModbusTcp _plc;
        //IO板卡测试界面
        private FormPLCRTU formPLCRTU = new FormPLCRTU();
        private FormMindVisionCamIO formMindVisionCamIO = new FormMindVisionCamIO();
        public static Login login;
        static FormSaveGlobalData formSaveGlobalData;
        static FormReadGlobalData formReadGlobalData;
        private FormLED formLED = new FormLED();
        public FormModelBusTcpComm modbusTcp;
        public History m_history;
        public DatabaseSetting m_databaseSetting;
        public static Panel m_PanelShow;
        public static Show1 m_Show1;                                          //1个画面
        public static Show2 m_Show2;                                          //2个画面
        public static Show3 m_Show3;                                          //3个画面
        public static Show4 m_Show4;                                          //4个画面
        public static Show5 m_Show5;                                          //5个画面
        public static Show6 m_Show6;                                          //6个画面
        public static FormShowResult formShowResult = new FormShowResult();   //显示消息列表及检测结果
        public static CtrlAllStates ctrlAllStates = new CtrlAllStates();      //检测数据统计
        private Home home;
        //public static bool isControlCalledFromAsyncThread = false;          //判断初始化界面是否启用异步
        FormLogo logo;                                                        //logo界面
        public static Dictionary<int, CtrlCamShow> m_dicCtrlCamShow = new Dictionary<int, CtrlCamShow>();    //<相机ID,相机显示窗口>
        public bool formshow = false;
        public static bool bRun;                   //是否处于生产状态
        public string serDataName = "";            //检测保存模板名称
        public static bool bCamShowFlag = false;
        #region 初始化参数
        /// <summary>
        /// 初始化进度显示
        /// </summary>
        internal int progress = 0;
        /// <summary>
        /// 初始化信息显示
        /// </summary>
        internal string progressTips = string.Empty;
        #endregion
        [DllImport("user32.dll")]
        public static extern int MessageBoxTimeoutA(IntPtr hWnd, string msg, string Caps, int type, int Id, int time);   //引用DLL
        //logo
        public static bool bCountNum = false;
        public static TimeSpan dCountTime = new TimeSpan(DateTime.Now.Ticks);
        public static bool bLogoShow = false;
        public static bool bLogoClose = false;
        public static Address M13 = new Address(SoftType.M, 13, DataType.Bit);//PLC运行标志点
        public static List<Address> addressesPlc = [M13];
        public FormMainUI(string title = null)
        {
            InitializeComponent();
            Function.InitSystem();
            _plc = new ModbusTcp();
#if DOG
            RegisterDeviceNotification();//注册加密锁事件插拨通知
            // RegisteredLogin();
#endif
            CamCommon.EnumCams();
            serDataName = LoadDeteDataName();
            LoadCamConfig();
            LoadData(serDataName);
            LoadUI();
            #region 初始化参数
            var bgw = new BackgroundWorker
            {
                WorkerSupportsCancellation = true
            };
            //注册后台运行事件
            bgw.DoWork += Bgw_DoWork;
            //执行事件
            bgw.RunWorkerAsync();
            new Welcome(bgw, this)
            {
                StartPosition = FormStartPosition.CenterParent
            }.ShowDialog();
            #endregion
            if (Directory.Exists(SavePath.ImageFold))
            {
                ClearRecord(SavePath.ImageFold);
            }
            Text = title ?? Text;//<=>title==null?Text:title; 修改公司名称
            m_PanelShow = this.panel_MainUI;
        }
        /// <summary>
        /// 加载相机配置
        /// </summary>
        private void LoadCamConfig()
        {
            try
            {
                if (!File.Exists(GlobalPath.SavePath.CamConfigPath))
                    return;
                string OutData = System.IO.File.ReadAllText(GlobalPath.SavePath.CamConfigPath);
                var DynamicObj_cam = JsonConvert.DeserializeObject<GlobalData.Config.CamConfig>(OutData);
                GlobalData.Config._CamConfig = DynamicObj_cam;
            }
            catch (SystemException ex)
            {

                MessageFun.ShowMessage("相机配置加载错误：" + ex.ToString(), strEnglish: "Camera configuration loading error:" + ex.ToString());
            }
        }

        /// <summary>
        /// 初始化参数函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (GlobalData.Config._language == EnumData.Language.english)
                {
                    progress = 0;
                    progressTips = "Environment initialization configuration...";
                    Thread.Sleep(100);
                    //枚举相机
                    progress = 20;
                    progressTips = "Enumerating cameras...";
                    Thread.Sleep(100);
                    //读取模板ID
                    progress = 50;
                    progressTips = "Importing Visual Model...";
                    LoadConfig.LoadModelID(serDataName);
                    Thread.Sleep(100);
                    progress = 100;
                    progressTips = "Loading completed, parsing in progress...";
                    Thread.Sleep(200);
                }
                else
                {
                    progress = 0;
                    progressTips = "环境初始化配置中...";
                    Thread.Sleep(100);
                    //枚举相机
                    progress = 20;
                    progressTips = "枚举相机中...";
                    Thread.Sleep(100);
                    //读取模板ID
                    progress = 40;
                    progressTips = "视觉Model导入中...";
                    LoadConfig.LoadModelID(serDataName);
                    Thread.Sleep(100);
                    if (GlobalData.Config._InitConfig.initConfig.comMode.TYPE == EnumData.COMType.NET)
                    {
                        if (File.Exists(SavePath.ModbusTcpPath))
                        {
                            var content = File.ReadAllText(SavePath.ModbusTcpPath);
                            DataSerializer._ModbusTcp.ModbusTcpPara =
                                JsonConvert.DeserializeObject<ModbusTcpPara>(content);
                            _plc.IpAddress = "192.168.3.250";
                            _plc.Port = 502;
                        }
                        else
                        {
                            _plc.IpAddress = "192.168.3.250";
                            _plc.Port = 502;
                        }
                        progress = 60;
                        progressTips = "正在测试与PLC通讯...";
                        Thread.Sleep(500);
                        OpenRes = _plc.Open();
                        progress = 80;
                        if (OpenRes != 0)
                        {
                            progressTips = "与PLC通讯测试失败，请检查相关参数配置...";
                        }
                        else
                        {
                            if (!File.Exists(SavePath.ModbusTcpPath))
                            {
                                DataSerializer._ModbusTcp.ModbusTcpPara.IpAddress = "192.168.3.250";
                                DataSerializer._ModbusTcp.ModbusTcpPara.Port = 502;
                                DataSerializer._ModbusTcp.ModbusTcpPara.nSlaveAddress = 1;
                                DataSerializer._ModbusTcp.ModbusTcpPara.ConnectTimeout = 1000;
                                DataSerializer._ModbusTcp.ModbusTcpPara.ResponseTimeout = 1000;
                                DataSerializer._ModbusTcp.ModbusTcpPara.Retries = 5;
                                SavePath.ModbusTcpPath.SerializeJson(DataSerializer._ModbusTcp.ModbusTcpPara);
                            }
                            progressTips = "与PLC通讯加载完成...";
                        }
                        Thread.Sleep(500);
                    }
                    progress = 100;
                    progressTips = "加载完成，解析中...";
                    Thread.Sleep(100);
                }

            }
            catch (Exception ex)
            {
                StaticFun.MessageFun.ShowMessage(ex);
            }
        }

        private void LoadUI()
        {
            #region 打开主界面:根据相机数量
            try
            {
                List<int> listCamID = new List<int>();
                if (null == GlobalData.Config._InitConfig.initConfig.dic_SubCam)
                {
                    GlobalData.Config._InitConfig.initConfig.dic_SubCam = new Dictionary<int, int>();
                    GlobalData.Config._InitConfig.initConfig.dic_SubCam.Add(1, 0);
                }
                foreach (int cam in GlobalData.Config._InitConfig.initConfig.dic_SubCam.Keys)
                {
                    int sub = GlobalData.Config._InitConfig.initConfig.dic_SubCam[cam];
                    for (int i = 0; i <= sub; i++)
                    {
                        listCamID.Add(cam * 10 + i);
                    }
                }
                switch (listCamID.Count)
                {
                    case 1:
                        m_Show1 = new Show1();
                        m_dicCtrlCamShow.Add(listCamID[0], m_Show1.ctrlCamShow1);
                        this.panel_MainUI.Controls.Clear();
                        this.panel_MainUI.Controls.Add(m_Show1);
                        break;
                    case 2:
                        m_Show2 = new Show2();
                        m_dicCtrlCamShow.Add(listCamID[0], m_Show2.ctrlCamShow1);
                        m_dicCtrlCamShow.Add(listCamID[1], m_Show2.ctrlCamShow2);
                        this.panel_MainUI.Controls.Clear();
                        this.panel_MainUI.Controls.Add(m_Show2);
                        break;
                    case 3:
                        m_Show3 = new Show3();
                        m_dicCtrlCamShow.Add(listCamID[0], m_Show3.ctrlCamShow1);
                        m_dicCtrlCamShow.Add(listCamID[1], m_Show3.ctrlCamShow2);
                        m_dicCtrlCamShow.Add(listCamID[2], m_Show3.ctrlCamShow3);
                        this.panel_MainUI.Controls.Clear();
                        this.panel_MainUI.Controls.Add(m_Show3);
                        break;
                    case 4:
                        m_Show4 = new Show4();
                        m_dicCtrlCamShow.Add(listCamID[0], m_Show4.ctrlCamShow1);
                        m_dicCtrlCamShow.Add(listCamID[1], m_Show4.ctrlCamShow2);
                        m_dicCtrlCamShow.Add(listCamID[2], m_Show4.ctrlCamShow3);
                        m_dicCtrlCamShow.Add(listCamID[3], m_Show4.ctrlCamShow4);
                        this.panel_MainUI.Controls.Clear();
                        this.panel_MainUI.Controls.Add(m_Show4);
                        break;
                    case 5:
                        m_Show5 = new Show5();
                        m_dicCtrlCamShow.Add(listCamID[0], m_Show5.ctrlCamShow1);
                        m_dicCtrlCamShow.Add(listCamID[1], m_Show5.ctrlCamShow2);
                        m_dicCtrlCamShow.Add(listCamID[2], m_Show5.ctrlCamShow3);
                        m_dicCtrlCamShow.Add(listCamID[3], m_Show5.ctrlCamShow4);
                        m_dicCtrlCamShow.Add(listCamID[4], m_Show5.ctrlCamShow5);
                        this.panel_MainUI.Controls.Clear();
                        this.panel_MainUI.Controls.Add(m_Show5);
                        break;
                    case 6:
                        m_Show6 = new Show6();
                        m_dicCtrlCamShow.Add(listCamID[0], m_Show6.ctrlCamShow1);
                        m_dicCtrlCamShow.Add(listCamID[1], m_Show6.ctrlCamShow2);
                        m_dicCtrlCamShow.Add(listCamID[2], m_Show6.ctrlCamShow3);
                        m_dicCtrlCamShow.Add(listCamID[3], m_Show6.ctrlCamShow4);
                        m_dicCtrlCamShow.Add(listCamID[4], m_Show6.ctrlCamShow5);
                        m_dicCtrlCamShow.Add(listCamID[5], m_Show6.ctrlCamShow6);
                        this.panel_MainUI.Controls.Clear();
                        this.panel_MainUI.Controls.Add(m_Show6);
                        break;
                    default:
                        //默认打开一个相机画面
                        m_Show1 = new Show1();
                        m_dicCtrlCamShow.Add(10, m_Show1.ctrlCamShow1);
                        this.panel_MainUI.Controls.Clear();
                        this.panel_MainUI.Controls.Add(m_Show1);
                        break;
                }
                //更新图像显示窗口信息
                foreach (int camID in m_dicCtrlCamShow.Keys)
                {
                    CamShowItem camShowItem = new CamShowItem();
                    if (GlobalData.Config._CamConfig.camConfig.ContainsKey(camID))
                    {
                        camShowItem = GlobalData.Config._CamConfig.camConfig[camID];
                    }
                    m_dicCtrlCamShow[camID].UpdateFun(camID, camShowItem);
                }
                //是否数字型光源控制器
                toolStripBut_LightControl.Visible = GlobalData.Config._InitConfig.initConfig.bDigitLight;
                FormMainUI.ctrlAllStates.RefreshDatas();
            }
            catch (SystemException ex)
            {
                ex.ToString();
            }
            #endregion
        }

        private string LoadDeteDataName()
        {
            try
            {
                //默认加载最新的序列化文件
                string strNewestFileName = File.ReadAllText(GlobalPath.SavePath.NewestFile);
                if (File.Exists(GlobalPath.SavePath.CompanyLogoPath))
                {
                    str_LogoPath = File.ReadAllText(GlobalPath.SavePath.CompanyLogoPath);
                    LoadCompanyLogo();
                }
                //读取最新保存的序列化文件名称
                var name = JsonConvert.DeserializeObject<string>(strNewestFileName);
                //将导入的序列化参数名称显示到主页面
                label_SerialName.Text = name;
                label_NowModel.Text = name;
                return name;
            }
            catch (Exception ex)
            {
                ex.Log();
                return "";
            }
        }

        private void LoadData(string name)
        {
            try
            {
                LoadConfig.LoadTMData(name);
                //加载串口通讯
                LoadConfig.LoadCOMConfig();
                if (null != GlobalData.Config._InitConfig.initConfig.comMode)
                {
                    switch (GlobalData.Config._InitConfig.initConfig.comMode.TYPE)
                    {
                        case EnumData.COMType.COM:
                            try
                            {
                                string tup_Path = AppDomain.CurrentDomain.BaseDirectory + "PLC(RTU).json";
                                if (!File.Exists(tup_Path))
                                {
                                    if (GlobalData.Config._language == EnumData.Language.english)
                                    {
                                        MessageBox.Show("The current software communication configuration file is abnormal. Please enter the PLC debugging interface to set it up!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                    else
                                    {
                                        MessageBox.Show("当前软件通讯配置文件异常，请进入PLC调试界面进行设置！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }

                                }
                                else
                                {
                                    string strPLCData = File.ReadAllText(tup_Path);
                                    DataSerializer._PlcRTU.PlcRTU = JsonConvert.DeserializeObject<InspectData.PLCRTU[]>(strPLCData);
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageFun.ShowMessage("读取RTU配置文件错误：" + ex.ToString(), strEnglish: "Error reading RTU configuration file:" + ex.ToString());
                            }
                            break;
                        case EnumData.COMType.NET:

                            string strData = System.IO.File.ReadAllText(SavePath.ModbusTcpPath);
                            var DynamicObject = JsonConvert.DeserializeObject<DataSerializer.GlobalData_ModbusTcp>(strData);
                            DataSerializer._ModbusTcp = DynamicObject;

                            //if (File.Exists(SavePath.ModbusTcpPath))
                            //{
                            //    var content = File.ReadAllText(SavePath.ModbusTcpPath);
                            //    TMData_Serializer._ModbusTcp.ModbusTcpPara =
                            //        JsonConvert.DeserializeObject<ModbusTcpPara>(content);
                            //    _plc.IpAddress = TMData_Serializer._ModbusTcp.ModbusTcpPara.IpAddress;
                            //    _plc.Port = TMData_Serializer._ModbusTcp.ModbusTcpPara.Port;
                            //}
                            //else
                            //{
                            //    _plc.IpAddress = "192.168.1.88";
                            //    _plc.Port = 502;
                            //}
                            //progress = 60;
                            //progressTips = "正在测试与PLC通讯...";
                            //Thread.Sleep(500);
                            //OpenRes = _plc.Open();
                            //progress = 80;
                            //if (OpenRes != 0)
                            //{
                            //    progressTips = "与PLC通讯测试失败，请检查相关参数配置...";
                            //    //MessageBox.Show("与PLC通讯测试失败，请检查相关参数配置...", "通讯异常提示");
                            //}
                            //else
                            //{
                            //    if (!File.Exists(SavePath.ModbusTcpPath))
                            //    {
                            //        TMData_Serializer._ModbusTcp.ModbusTcpPara.IpAddress = "192.168.1.88";
                            //        TMData_Serializer._ModbusTcp.ModbusTcpPara.Port = 502;
                            //        TMData_Serializer._ModbusTcp.ModbusTcpPara.nSlaveAddress = 1;
                            //        TMData_Serializer._ModbusTcp.ModbusTcpPara.ConnectTimeout = 1000;
                            //        TMData_Serializer._ModbusTcp.ModbusTcpPara.ResponseTimeout = 1000;
                            //        TMData_Serializer._ModbusTcp.ModbusTcpPara.Retries = 5;
                            //        SavePath.ModbusTcpPath.SerializeJson(TMData_Serializer._ModbusTcp.ModbusTcpPara);
                            //    }
                            //    progressTips = "与PLC通讯加载完成...";
                            //}
                            //Thread.Sleep(500);
                            break;
                        case EnumData.COMType.IO:
                            try
                            {
                                switch (GlobalData.Config._InitConfig.initConfig.comMode.IO)
                                {
                                    case EnumData.IO.WENYU8:
                                    case EnumData.IO.WENYU16:
                                        WENYU.OpenIO();
                                        if (GlobalData.Config._InitConfig.initConfig.bIOLight)
                                        {
                                            WENYU_PIO32P.WY_WriteOutPutBit0(WENYU.DevID, 0);
                                            WENYU_PIO32P.WY_WriteOutPutBit1(WENYU.DevID, 0);
                                            WENYU_PIO32P.WY_WriteOutPutBit2(WENYU.DevID, 0);
                                            WENYU_PIO32P.WY_WriteOutPutBit3(WENYU.DevID, 0);
                                            WENYU_PIO32P.WY_WriteOutPutBit4(WENYU.DevID, 0);
                                            WENYU_PIO32P.WY_WriteOutPutBit5(WENYU.DevID, 0);
                                            WENYU_PIO32P.WY_WriteOutPutBit6(WENYU.DevID, 0);
                                            WENYU_PIO32P.WY_WriteOutPutBit7(WENYU.DevID, 0);
                                        }
                                        break;
                                    case EnumData.IO.WENYU232:
                                        WENYU.SearchIO();
                                        break;
                                    default:
                                        break;
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageFun.ShowMessage("读取IO配置文件错误：" + ex.ToString(), strEnglish: "Error reading IO configuration file:" + ex.ToString());
                            }
                            break;
                        case EnumData.COMType.CamIO:
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    MessageFun.ShowMessage("未配置通讯方式，请先选择一种通讯模式。", strEnglish: "No communication mode has been configured. Please select a communication mode first.");
                }

                if (GlobalData.Config._InitConfig.initConfig.bDigitLight)
                {
                    LEDControl.OpenAllLedCom(ref DataSerializer._COMConfig.dicLed);
                    Thread.Sleep(10);
                }
            }
            catch (Exception ex)
            {
                if (GlobalData.Config._language == EnumData.Language.english)
                {
                    MessageBox.Show("The working mode configuration file was not found. Please go to the administrator interface to set it up!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("未找到工作模式配置文件，请到管理员界面设置!", caption: "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                ex.ToString().Log();
            }

        }
        private void RegisteredLogin()
        {
            //判断当前软件是否注册
            try
            {
                RegistryKey localKey = Registry.LocalMachine;
                RegistryKey softWareKey = localKey.OpenSubKey("SOFTWARE", true);
                RegistryKey HLZNKey = softWareKey.OpenSubKey("BPY2\\PAR", true);
                if (null == HLZNKey)
                {
                    Registered registered = new Registered();
                    registered.ShowDialog();
                    HLZNKey = softWareKey.OpenSubKey("BPY2\\PAR", true);
                }
                string strInstalled = HLZNKey.GetValue("installed").ToString();
                if (strInstalled == Registered.SHA1(Registered.getMNum()))
                {
                    //当前软件已经注册过
                }
                else
                {
                    //没有注册
                    Registered registered = new Registered();
                    registered.ShowDialog();
                    strInstalled = HLZNKey.GetValue("installed").ToString();
                }
            }
            catch (Exception ex)
            {
                MessageFun.ShowMessage("注册异常！ 注册失败！" + ex.ToString(), true, "Registration exception! Registration failed!" + ex.ToString());
                Process.GetCurrentProcess().Kill();
            }
        }
        //保存数据
        private void toolStripBut_SaveGlobalData_Click(object sender, EventArgs e)
        {
            try
            {
                if (null == formSaveGlobalData || formSaveGlobalData.IsDisposed)
                {
                    formSaveGlobalData = new FormSaveGlobalData(label_NowModel, label_SerialName);
                    formSaveGlobalData.Show();
                }
                else
                {
                    formSaveGlobalData.Activate(); //使子窗体获得焦点
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                (ex.Message + ex.StackTrace).Log();
            }
            string Address = System.AppDomain.CurrentDomain.BaseDirectory + "Address.json";
        }
        //导入数据
        private void toolStripBut_importData_Click(object sender, EventArgs e)
        {
            if (!bRun)
            {
                try
                {
                    if (null == formReadGlobalData || formReadGlobalData.IsDisposed)
                    {
                        formReadGlobalData = new FormReadGlobalData(label_NowModel, label_SerialName);
                        formReadGlobalData.Show();
                    }
                    else
                    {
                        formReadGlobalData.Activate(); //使子窗体获得焦点
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    (ex.Message + ex.StackTrace).Log();
                }
            }
            else
            {
                if (GlobalData.Config._language == EnumData.Language.english)
                {
                    MessageBox.Show("The current program is running. Please stop the detection button<Running>before proceeding with other operations. Thank you for your cooperation.", "Operation prompt", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("当前程序正在运行中，请停止检测按钮<运行中>后，再进行其它操作，谢谢配合。", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                return;
            }
        }

        //通讯
        private void toolStripBut_PLCComm_Click(object sender, EventArgs e)
        {

            //if (but_Run.Text == "运行" || m_Show1.but_Run.Text == "Run")
            //{
            //    LoginTX loginTX = new LoginTX();
            //    loginTX.ShowDialog();
            //    if (loginTX.Ba)
            //    {
            //        formPLCRTU.ShowDialog();
            //    }
            //}
            //else
            //{
            //    if (GlobalData.Config._language == EnumData.Language.english)
            //    {
            //        MessageBox.Show("The current program is running. Please stop the detection button<Running>before proceeding with other operations. Thank you for your cooperation.", "Operation prompt", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    }
            //    else
            //    {
            //        MessageBox.Show("当前程序正在运行中，请停止检测按钮<运行中>后，再进行其它操作，谢谢配合。", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    }
            //    return;
            //}
        }

        private void FormMainUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            bool flag = false;
            if (GlobalData.Config._language == EnumData.Language.english)
            {
                flag = MessageBox.Show("Are you sure you want to close the software?", "Tips", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1) == DialogResult.Yes;
            }
            else
            {
                flag = MessageBox.Show("您确定要关闭软件吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1) == DialogResult.Yes;
            }

            if (flag)
            {
                try
                {
                    if (GlobalData.Config._InitConfig.initConfig.comMode.TYPE == EnumData.COMType.IO && WENYU.isOpen)
                    {
                        WENYU_PIO32P.WY_WriteOutPutBit0(WENYU.DevID, 1);
                        WENYU_PIO32P.WY_WriteOutPutBit1(WENYU.DevID, 1);
                        WENYU_PIO32P.WY_WriteOutPutBit2(WENYU.DevID, 1);
                        WENYU.CloseIO();
                    }
                    //if (GlobalData.Config._InitConfig.initConfig.bDigitLight && LEDControl.isOpen)
                    //{
                    //    //将所有光源通道亮度值设置为0
                    //    for (int ch = 1; ch <= GlobalData.Config._InitConfig.initConfig.nLightCH; ch++)
                    //    {
                    //        LEDControl.SetBrightness(ch, 0);
                    //    }
                    //    //关闭光源控制器串口
                    //    LEDControl.CloseLED();
                    //}
                    if (GlobalData.Config._InitConfig.initConfig.comMode.TYPE == EnumData.COMType.NET)//关闭M1点
                    {
                        var address = new Address(SoftType.M, 1, DataType.Bit);
                        address.Value = 0;
                        FormMainUI._plc.WriteDevice(address);
                    }
                    CamCommon.CloseAllCam();
                }
                catch
                {

                }
                Process.GetCurrentProcess().Kill();
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void tSBut_InitCam_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FormMainUI.bRun)
                {
                    CamCommon.CloseAllCam();
                    CamCommon.EnumCams();
                }
                else
                {
                    if (GlobalData.Config._language == EnumData.Language.english)
                    {
                        MessageBox.Show("The current program is running. Please stop the detection button<Running>before proceeding with other operations. Thank you for your cooperation.", "Operation prompt", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show("当前程序正在运行中，请停止检测按钮<运行中>后，再进行其它操作，谢谢配合。", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageFun.ShowMessage(ex.ToString());
                throw;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                formLED = new FormLED();
                formLED.TopMost = true;
                formLED.Show();
            }
            catch (Exception ex)
            {
                MessageFun.ShowMessage(ex.ToString());
                throw;
            }
        }
        private void ClearRecord(string path)
        {
            if (Directory.Exists(path))
            {
                var folder = Directory.GetDirectories(path);

                if (folder != null && folder.Length > 0)
                {
                    foreach (var temp in folder)
                    {
                        if (temp.Contains("-"))
                        {
                            DirectoryInfo directory = new DirectoryInfo(temp);
                            if (directory.CreationTime < DateTime.Now.AddDays(GlobalData.Config._InitConfig.initConfig.nDaySave))
                            {
                                directory.Delete(true);
                            }
                            continue;
                        }
                        ClearRecord(temp);
                    }
                }
            }
        }
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FormMainUI.bRun)
                {
                    if (GlobalData.Config._InitConfig.initConfig.comMode.TYPE == EnumData.COMType.IO)
                    {
                        if (GlobalData.Config._InitConfig.initConfig.comMode.IO == EnumData.IO.WENYU8 ||
                            GlobalData.Config._InitConfig.initConfig.comMode.IO == EnumData.IO.WENYU16)
                        {
                            FormIOcomm formIOcomm = new FormIOcomm();
                            formIOcomm.ShowDialog();
                        }
                        else if (GlobalData.Config._InitConfig.initConfig.comMode.IO == EnumData.IO.WENYU232)
                        {
                            if (WENYU.isOpen)
                            {
                                FormModbusIO formModbusIO = new FormModbusIO(DataSerializer._COMConfig.WENYU232_ComPort);
                                formModbusIO.StartPosition = FormStartPosition.CenterScreen;
                                formModbusIO.TopMost = true;
                                formModbusIO.Show();
                            }
                            else
                            {
                                FormSetCom formSetCom = new FormSetCom();
                                formSetCom.ShowDialog();
                            }

                        }

                    }
                    else if (GlobalData.Config._InitConfig.initConfig.comMode.TYPE == EnumData.COMType.NET)
                    {
                        if (bRun)
                        {
                            MessageBox.Show("设备处于运行中，请在设备处于待运行时进行此操作！", "运行提示");
                            return;
                        }
                        try
                        {
                            if (null == modbusTcp || modbusTcp.IsDisposed)
                            {
                                modbusTcp = new FormModelBusTcpComm(_plc);
                                modbusTcp.StartPosition = FormStartPosition.CenterParent;
                            }
                            modbusTcp.ShowDialog(this);
                        }
                        catch (Exception ex)
                        {
                            ex.Error();
                        }
                        finally
                        {
                            // home = null;
                        }
                    }
                    else if (GlobalData.Config._InitConfig.initConfig.comMode.TYPE == EnumData.COMType.COM)
                    {
                        formPLCRTU.ShowDialog();
                    }
                    else if (GlobalData.Config._InitConfig.initConfig.comMode.TYPE == EnumData.COMType.CamIO)
                    {
                        formMindVisionCamIO.ShowDialog();
                    }
                }
                else
                {
                    if (GlobalData.Config._language == EnumData.Language.english)
                    {
                        MessageBox.Show("The current program is running. Please stop the detection button<Running>before proceeding with other operations. Thank you for your cooperation.", "Operation prompt", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show("当前程序正在运行中，请停止检测按钮<运行中>后，再进行其它操作，谢谢配合。", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageFun.ShowMessage(ex.ToString());
            }
        }

        private void ts_But_Admin_Click(object sender, EventArgs e)
        {
            try
            {
                if (null == login || login.IsDisposed)
                {
                    login = new Login();
                    login.TopMost = true;
                    login.ShowDialog();
                }
                else
                {
                    login.Activate(); //使子窗体获得焦点
                }
            }
            catch (Exception ex)
            {
                MessageFun.ShowMessage(ex, true);
            }
        }
        private void ts_But_CamIO_Click(object sender, EventArgs e)
        {

        }

        #region 导入公司Logo
        string str_LogoPath = "";
        private void 导入Logo_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog file = new OpenFileDialog();
                file.InitialDirectory = ".";
                // file.Filter = "BMP图片|*.bmp|JPG图片|*.jpg|Gif图片|*.gif|PNG图片|*.png";
                file.Filter = "所有文件(*.*)|*.*";
                file.ShowDialog();
                if (file.FileName != string.Empty)
                {
                    try
                    {
                        //str_LogoPath = file.FileName;   //获得文件的绝对路径
                        str_LogoPath = Path.Combine(Path.GetDirectoryName(file.FileName), Path.GetFileName(file.FileName));
                        this.tsb_Plc.SizeMode = PictureBoxSizeMode.StretchImage;
                        this.tsb_Plc.Load(str_LogoPath);
                        File.WriteAllText(GlobalPath.SavePath.CompanyLogoPath, str_LogoPath);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void 清除公司LOGO_Click(object sender, EventArgs e)
        {
            this.tsb_Plc.Image = null;
            str_LogoPath = "";
            File.WriteAllText(GlobalPath.SavePath.CompanyLogoPath, str_LogoPath);
        }

        private void LoadCompanyLogo()
        {
            try
            {
                if ("" != str_LogoPath)
                {
                    this.tsb_Plc.SizeMode = PictureBoxSizeMode.StretchImage;
                    this.tsb_Plc.Load(str_LogoPath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void 填充_Click(object sender, EventArgs e)
        {
            this.tsb_Plc.SizeMode = PictureBoxSizeMode.StretchImage;
            LoadCompanyLogo();
        }

        private void 按图像大小_Click(object sender, EventArgs e)
        {
            this.tsb_Plc.SizeMode = PictureBoxSizeMode.AutoSize;
            LoadCompanyLogo();
        }

        private void 居中显示_Click(object sender, EventArgs e)
        {
            this.tsb_Plc.SizeMode = PictureBoxSizeMode.CenterImage;
            LoadCompanyLogo();
        }

        private void 图像自适应_Click(object sender, EventArgs e)
        {
            this.tsb_Plc.SizeMode = PictureBoxSizeMode.Zoom;
            LoadCompanyLogo();
        }
        #endregion

#if DOG
        #region<!--DOG-->
        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            switch (m.Msg)
            {
                case WM_DEVICECHANGE: OnDeviceChange(ref m); break;
            }
            base.WndProc(ref m);
        }
        private void OnDeviceChange(ref System.Windows.Forms.Message msg)
        {
            int wParam = (int)msg.WParam;
            if (wParam == DBT_DEVICEREMOVECOMPLETE)//收到硬件拨出信息后，调用检查锁函数来检查是否锁被拨出
            {
                DEV_BROADCAST_DEVICEINTERFACE1 DeviceInfo = (DEV_BROADCAST_DEVICEINTERFACE1)Marshal.PtrToStructure(msg.LParam, typeof(DEV_BROADCAST_DEVICEINTERFACE1));
                // 这里使用 FindDogOnPnp检查加密锁是否被拨出，也可以使用其它检查锁函数来检查加密锁是否被拨出
                var path = string.Empty;
                if (FindPort(0, ref path) != 0)
                {
                    if (GlobalData.Config._language == EnumData.Language.english)
                    {
                        MessageBoxTimeoutA((IntPtr)0, "The encryption dog has been dialed out, and the program will exit abnormally!", "Message", 0, 0, 10000);    // 直接调用  3秒后自动关闭
                    }
                    else
                    {
                        MessageBoxTimeoutA((IntPtr)0, "加密狗被拨出，程序将异常退出！", "消息框", 0, 0, 10000);    // 直接调用  3秒后自动关闭
                    }
                    //MessageBox.Show(" 加密狗被拨出，程序将异常退出！");
                    Environment.Exit(0);
                }
                else
                {
                    Company = GetValue("Company", DogPath);
                    Author = GetValue("Author", DogPath);
                    ModeChar = GetValue("ModeChar", DogPath);
                    Md5Value = GetValue("Md5", DogPath);
                    SerserialNumber = GetValue("SerserialNumber", DogPath);
                    GetOrder = GetValue("GetOrder", DogPath);
                    GetState = GetValue("GetState", DogPath);
                    GetAdaptImageSize = GetValue("GetAdaptImageSize", DogPath);
                    if (string.IsNullOrEmpty(Company) || string.IsNullOrEmpty(Author) || string.IsNullOrEmpty(ModeChar) || string.IsNullOrEmpty(Md5Value) || string.IsNullOrEmpty(SerserialNumber) || string.IsNullOrEmpty(GetOrder) || string.IsNullOrEmpty(GetState) || string.IsNullOrEmpty(GetAdaptImageSize))
                    {
                        if (GlobalData.Config._language == EnumData.Language.english)
                        {
                            MessageBox.Show("Detected abnormal current encryption dog, please contact the manufacturer for factory verification!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBox.Show("检测到当前加密狗异常，请联系厂家进行出厂校验！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        Environment.Exit(0);
                    }
                    else
                    {
                        if (!Md5Value.Equals(Encrypt(Company)))
                        {
                            if (GlobalData.Config._language == EnumData.Language.english)
                            {
                                MessageBox.Show("Detected abnormal current encryption dog, please contact the manufacturer for factory verification!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                MessageBox.Show("检测到当前加密狗异常，请联系厂家进行出厂校验！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            Environment.Exit(0);
                        }
                    }
                }
            }
        }
        private void RegisterDeviceNotification()
        {
            DEV_BROADCAST_DEVICEINTERFACE dbi = new DEV_BROADCAST_DEVICEINTERFACE();
            int size = Marshal.SizeOf(dbi);
            dbi.dbcc_size = size;
            dbi.dbcc_devicetype = DBT_DEVTYP_DEVICEINTERFACE;
            dbi.dbcc_reserved = 0;
            dbi.dbcc_classguid = GUID_DEVINTERFACE_USB_DEVICE;
            dbi.dbcc_name = 0;
            IntPtr buffer = Marshal.AllocHGlobal(size);
            Marshal.StructureToPtr(dbi, buffer, true);
            RegisterDeviceNotification(Handle, buffer, DEVICE_NOTIFY_WINDOW_HANDLE);
        }

        #endregion
#endif

        public static readonly Guid GUID_DEVINTERFACE_USB_DEVICE = new Guid("4D1E55B2-F16F-11CF-88CB-001111000030");
        public const int WM_DEVICECHANGE = 0x0219;
        public const int DBT_DEVICEREMOVECOMPLETE = 0x8004; // device is gone
        public const int DBT_DEVTYP_DEVICEINTERFACE = 0x00000005; // deviceinterface class
        public const int DEVICE_NOTIFY_WINDOW_HANDLE = 0x0;
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr RegisterDeviceNotification(IntPtr hRecipient, IntPtr
            NotificationFilter, int Flags);

        FormContactUs formContactUs;     //联系我们
        private void 联系我们_Click(object sender, EventArgs e)
        {
            try
            {
                if (null == formContactUs || !formContactUs.Created || formContactUs.IsDisposed)
                {
                    formContactUs = new FormContactUs();
                }
                formContactUs.Show();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        FormOperateInstruct formOperateInstruct;    //操作视频
        private void 操作视频_Click(object sender, EventArgs e)
        {
            try
            {
                if (null == formOperateInstruct || !formOperateInstruct.Created || formOperateInstruct.IsDisposed)
                {
                    formOperateInstruct = new FormOperateInstruct();
                }
                formOperateInstruct.Show();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        private void 用户操作指导说明书_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, Application.StartupPath + @"\Hi.MultTM.chm");//打开debug文件夹下的chm文件
            //Help.ShowHelp(this, Application.StartupPath + @"\yourchm.chm", "yourchm_chapter.htm");//打开debug文件夹下的chm文件的yourchm_chapter.htm这一页
            //Help.ShowHelpIndex(this, Application.StartupPath + @"\yourchm.chm");//开debug文件夹下的chm文件的索引
        }

        private void ts_But_Language_Click(object sender, EventArgs e)
        {
            FormLanguage formLanguage = new FormLanguage();
            formLanguage.ShowDialog();
        }

        private void toolStripButton_PLC_Click(object sender, EventArgs e)
        {
            try
            {
                if (null == home || home.IsDisposed)
                {
                    home = new Home(_plc);
                    home.StartPosition = FormStartPosition.CenterParent;
                }
                home.ShowDialog(this);
            }
            catch (Exception ex)
            {
                ex.Error();
            }
            finally
            {
                // home = null;
            }
        }

        private void ts_But_Record_Click(object sender, EventArgs e)
        {
            try
            {
                m_history = new History();
                m_history.TopMost = true;
                m_history.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                (ex.Message + ex.StackTrace).Log();
            }
        }

        private void tsb_Database_Click(object sender, EventArgs e)
        {
            try
            {

                m_databaseSetting = new DatabaseSetting();
                m_databaseSetting.TopMost = true;
                m_databaseSetting.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                (ex.Message + ex.StackTrace).Log();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            var address = new Address(SoftType.M, 1051, DataType.Bit);
            address.Value = 1;
            _plc.WriteDevice(address);

        }
    }
}

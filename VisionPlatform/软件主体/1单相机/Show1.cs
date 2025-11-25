using DAL;
using Hi.Ltd;
using StaticFun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace VisionPlatform
{
    public partial class Show1 : Form
    {
        public static List<string> m_listCamSer = new List<string>();
        Run run = new Run();
        Modbus_RTU modbus_RTU1 = new Modbus_RTU();
        Modbus_RTU[] modbus_RTUs = new Modbus_RTU[2];

        public Show1()
        {
            InitializeComponent();
            this.TopLevel = false;
            this.Visible = true;
            this.Dock = DockStyle.Fill;
            _InitUI();
        }
        /// <summary>
        /// 解决窗体加载慢、卡顿问题
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;              //用双缓冲绘制窗口的所有子控件
                return cp;
            }
        }

        //初始化Function
        private void _InitUI()
        {
            this.tLPanel_Run.Controls.Add(FormMainUI.ctrlAllStates,1,0);
            //图像保存
            InspectFunction.myCtrlImageSave = this.ctrlImageSave;
            //加载消息显示
            this.panel_Message.Controls.Clear();
            this.panel_Message.Controls.Add(FormMainUI.formShowResult);
        }

        public void RefreshUI()
        {
            try
            {
                //刷新图像显示窗口
                ctrlCamShow1.Visible = true;
                this.panel1.Controls.Clear();
                this.panel1.Controls.Add(ctrlCamShow1);
                //刷新消息列表
                this.panel_Message.Controls.Clear();
                this.panel_Message.Controls.Add(FormMainUI.formShowResult);
            }
            catch (Exception ex)
            {
                StaticFun.MessageFun.ShowMessage(ex);
            }
        }

        private void Show1_Load(object sender, EventArgs e)
        {
            //if (GlobalData.Config._InitConfig.initConfig.comMode.IO == EnumData.IO.WENYU8 || 
            //    GlobalData.Config._InitConfig.initConfig.comMode.IO == EnumData.IO.WENYU16)
            //{
            //    long VersionNumber = -1;
            //    Fun.isOpenIO = WENYU_PIO32P.WY_GetCardVersion(WENYU.DevID, ref VersionNumber) == 0 ? true : false;
            //}
            //else if (GlobalData.Config._InitConfig.initConfig.comMode.IO == EnumData.IO.WENYU232)
            //{
            //    Fun.isOpenIO = JD_modbusRTU.WENYUIO.OpenIO();
            //}
            //if (GlobalData.Config._InitConfig.initConfig.bDigitLight)
            //{
            //    Fun.isOpenLed = LEDSet.OpenLedcom();
            //}

        }

        private void Show1_SizeChanged(object sender, EventArgs e)
        {
            StaticFun.Run.Zoom();
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            //StaticFun.UIConfig.ConfigShowItems(sender, e, ref FormMainUI.m_dicFormCamShows);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static VisionPlatform.InspectData;

namespace VisionPlatform
{
    public partial class Show6 : Form
    {
        public Show6()
        {
            InitializeComponent();
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
        //界面初始化
        private void _InitUI()
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        public void RefreshUI()
        {
            try
            {
                //刷新图像显示窗口
                ctrlCamShow1.Visible = true;
                this.panel1.Controls.Clear();
                this.panel1.Controls.Add(ctrlCamShow1);
                ctrlCamShow2.Visible = true;
                this.panel2.Controls.Clear();
                this.panel2.Controls.Add(ctrlCamShow2);
                ctrlCamShow3.Visible = true;
                this.panel4.Controls.Clear();
                this.panel4.Controls.Add(ctrlCamShow3);
                ctrlCamShow4.Visible = true;
                this.panel5.Controls.Clear();
                this.panel5.Controls.Add(ctrlCamShow4);
                ctrlCamShow5.Visible = true;
                this.panel3.Controls.Clear();
                this.panel3.Controls.Add(ctrlCamShow5);
                ctrlCamShow6.Visible = true;
                this.panel6.Controls.Clear();
                this.panel6.Controls.Add(ctrlCamShow6);
                //刷新消息列表
                this.panel_Message.Controls.Clear();
                this.panel_Message.Controls.Add(FormMainUI.formShowResult);
            }
            catch (Exception ex)
            {
                StaticFun.MessageFun.ShowMessage(ex);
            }
        }

        private void Show4_Load(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            //StaticFun.UIConfig.ConfigShowItems(sender, e, ref FormMainUI.m_dicFormCamShows);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using StaticFun;

namespace VisionPlatform
{
    public partial class Show2 : Form
    {
        public Show2()
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
        public void _InitUI()
        {
            try
            {
                //图像保存
                InspectFunction.myCtrlImageSave = this.ctrlImageSave;
                //加载检测结果显示
                this.panel_Message.Controls.Clear();
                this.panel_Message.Controls.Add(FormMainUI.formShowResult);
                //数据统计
                //UIConfig.RefreshSTATS(tLPanel, out InspectFunction.m_ListFormSTATS);
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
                //刷新消息列表
                this.panel_Message.Controls.Clear();
                this.panel_Message.Controls.Add(FormMainUI.formShowResult);
            }
            catch (Exception ex)
            {
                StaticFun.MessageFun.ShowMessage(ex);
            }
        }

        private void Show2_Load(object sender, EventArgs e)
        {
            // CheckSave();
        }

        private void Show2_SizeChanged(object sender, EventArgs e)
        {
            StaticFun.Run.Zoom();
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            //StaticFun.UIConfig.ConfigShowItems(sender, e, ref FormMainUI.m_dicFormCamShows);
        }

    }
}

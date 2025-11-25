using StaticFun;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace VisionPlatform
{
    [ToolboxItem(false)]
    public partial class Show4 : UserControl
    {
        public Show4()
        {
            InitializeComponent();
            this.Visible = true;
            this.Dock = DockStyle.Fill;
            _InitUI();
        }
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
                ctrlCamShow3.Visible = true;
                this.panel3.Controls.Clear();
                this.panel3.Controls.Add(ctrlCamShow3);
                ctrlCamShow4.Visible = true;
                this.panel4.Controls.Clear();
                this.panel4.Controls.Add(ctrlCamShow4);
                //刷新消息列表
                this.panel_Message.Controls.Clear();
                this.panel_Message.Controls.Add(FormMainUI.formShowResult);
            }
            catch (Exception ex)
            {
                StaticFun.MessageFun.ShowMessage(ex);
            }
        }


        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            //StaticFun.UIConfig.ConfigShowItems(sender, e, ref FormMainUI.m_dicFormCamShows);
        }

    }
}

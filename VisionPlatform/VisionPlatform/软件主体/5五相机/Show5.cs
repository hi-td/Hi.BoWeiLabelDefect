using Hi.Ltd.Data;
using Hi.Ltd.Enumerations;
using System;
using System.Windows.Forms;

namespace VisionPlatform
{
    public partial class Show5 : Form
    {
        public Show5()
        {
            InitializeComponent();
            this.TopLevel = false;
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
                FormMainUI.ctrlAllStates.SetRowCol(2, 3);
                //图像保存
                InspectFunction.myCtrlImageSave = this.ctrlImageSave;
                InspectFunction.myCtrlOK_NG = this.ctrlOK_NG;
                //加载检测结果显示
                this.panel_Message.Controls.Clear();
                this.panel_Message.Controls.Add(FormMainUI.formShowResult);
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
                ctrlCamShow5.Visible = true;
                this.panel5.Controls.Clear();
                this.panel5.Controls.Add(ctrlCamShow5);
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

        private void button1_Click(object sender, EventArgs e)
        {
            var M120 = new Address(SoftType.M, 120, DataType.Bit);
            M120.Value = 0;
            FormMainUI._plc.WriteDevice(M120);

            M120.Value = 1;
            FormMainUI._plc.WriteDevice(M120);
        }

    }
}

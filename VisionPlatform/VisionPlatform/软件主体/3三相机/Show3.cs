/***********************************************************
* CLR版本：4.0.30319.42000
* 类 名 称：Show3
* 机器名称：WIN-C8KIOVQPABN
* 命名空间：VisionPlatform.宜鑫端子机
* 文 件 名：Show3
* 创建时间：2022/1/10 11:16:45
* 作    者： Chustange
* 公    司：HaiLan Intelligent
* 说   明：
* 修改时间：
* 修 改 人：
* 修改说明：
* 深圳市海蓝智能科技有限公司  2021  保留所有权利.
***********************************************************/
using System;
using System.Windows.Forms;

namespace VisionPlatform
{
    public partial class Show3 : Form
    {

        public Show3()
        {
            InitializeComponent();
            this.TopLevel = false;
            this.Visible = true;
            this.Dock = DockStyle.Fill;
            _InitUI();
        }

        //界面初始化
        private void _InitUI()
        {
            try
            {
                FormMainUI.ctrlAllStates.SetRowCol(1, 3);
                this.tLPanel1.Controls.Add(FormMainUI.ctrlAllStates, 1, 0);
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
                this.ctrlCamShow1.Visible = true;
                this.panel1.Controls.Clear();
                this.panel1.Controls.Add(ctrlCamShow1);
                this.ctrlCamShow2.Visible = true;
                this.panel2.Controls.Clear();
                this.panel2.Controls.Add(ctrlCamShow2);
                this.ctrlCamShow3.Visible = true;
                this.panel3.Controls.Clear();
                this.panel3.Controls.Add(ctrlCamShow3);
                //刷新消息列表
                this.panel_Message.Controls.Clear();
                this.panel_Message.Controls.Add(FormMainUI.formShowResult);
            }
            catch (Exception ex)
            {
                StaticFun.MessageFun.ShowMessage(ex);
            }
        }

        //public static MultiPressDef MultiPress;
        //private MultiPressWindow MultiPressWin = null;
        private void Show3_Load(object sender, EventArgs e)
        {
            try
            {
                #region<!--汇众压力-->
                //MultiPress = new MultiPressDef();
                //this.MultiPressWin = new MultiPressWindow(MultiPress);
                //this.MultiPressWin.FormBorderStyle = FormBorderStyle.None;
                //this.MultiPressWin.TopLevel = false;
                //this.MultiPressWin.Dock = DockStyle.Fill;
                //tlp_Home.ColumnCount = 1;
                //tlp_Home.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
                //tlp_Home.RowCount = 1;
                //tlp_Home.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
                //tlp_Home.Controls.Add(MultiPressWin, 0, 0);
                //MultiPressWin.Show();
                #endregion
            }
            catch (Exception)
            {
            }
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            //StaticFun.UIConfig.ConfigShowItems(sender, e, ref FormMainUI.m_dicFormCamShows);
        }
    }
}

using StaticFun;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace VisionPlatform
{
    public partial class FormShowResult : Form
    {
        List<TabPage> listTabPages = new List<TabPage>();
        //public static MultiPressDef MultiPress;
        //private MultiPressWindow MultiPressWin = null;
        public FormShowResult()
        {
            InitializeComponent();
            this.TopLevel = false;
            this.Visible = true;
            this.Dock = DockStyle.Fill;
            MessageFun.GetRichText(richTextBox);
            foreach (TabPage page in tabCtrl.TabPages)
            {//tabCtrl.TabPages的数量会随着设置Parent减少
                this.listTabPages.Add(page);
            }  
            //MultiPress = new MultiPressDef();
            //Load += FormShowResult_Load;
        }
        private void FormShowResult_Load(object sender, EventArgs e)
        {
            #region<!--汇众压力-->
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

        public void ShowResult(InspectData.InspectResult inspectResult)
        {
            try
            {
                Action method = delegate ()
                {
                    //添加序号
                    int m = this.listView1.Items.Count;
                    listView1.Items.Add(m.ToString());
                    //添加检测项和检测结果
                    Dictionary<string, string> item = inspectResult.outcome;
                    if (0 == item.Count)
                    {
                        listView1.Items[m].BackColor = Color.Red;
                    }
                    else
                    {
                        foreach (string str in item.Keys)
                        {
                            listView1.Items[m].SubItems.Add(str);
                            listView1.Items[m].SubItems.Add(item[str]);
                            if (item[str].Contains("NG"))
                            {
                                listView1.Items[m].BackColor = Color.Red;
                            }
                        }
                    }
                    //添加采图时间
                    listView1.Items[m].SubItems.Add(inspectResult.GrabTime.ToString());
                    //添加检测时间
                    listView1.Items[m].SubItems.Add(inspectResult.InspectTime.ToString());
                    //添加总时间
                    listView1.Items[m].SubItems.Add((inspectResult.GrabTime + inspectResult.InspectTime).ToString());
                    this.listView1.Items[this.listView1.Items.Count - 1].EnsureVisible();
                    if (this.listView1.Items.Count > 100)
                    {
                        this.listView1.Items.Clear();
                    }
                };
                Invoke(method);
            }
            catch (Exception ex)
            {
                MessageFun.ShowMessage("显示检测结果错误：" + ex.ToString(), true, strEnglish: "Display detection result error:" + ex.ToString());
            }
            inspectResult = new InspectData.InspectResult();
        }

        private void 清除_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            ContextMenuStrip menu = item.Owner as ContextMenuStrip;
            if(menu.SourceControl.Name == "richTextBox")
            {
                richTextBox.Clear();
            }
            if(menu.SourceControl.Name == "listView1")
            {
                listView1.Items.Clear();
            }
        }

        public void ShowMessagePageOnly(bool bShow)
        {
            try
            {
                foreach (TabPage page in listTabPages)
                {
                    if (bShow)
                    {
                        page.Parent = !(page.Text == "消息列表") ? null : this.tabCtrl;
                    }
                    else
                    {
                        page.Parent = this.tabCtrl;
                    }
                }
                if (!bShow)
                {
                    this.tabCtrl.SelectedTab = this.tabPage_Result;
                }
            }
            catch (Exception ex)
            {
                StaticFun.MessageFun.ShowMessage(ex);
            }
            this.tabCtrl.Refresh();
        }

        private void 数据统计_Click(object sender, EventArgs e)
        {
            try
            {
                ToolStripMenuItem item = sender as ToolStripMenuItem;
                tabPage_States.Parent = item.Checked ? tabCtrl : null;
                if (item.Checked)
                {
                    this.tabPage_States.Controls.Clear();
                    this.tabPage_States.Controls.Add(FormMainUI.ctrlAllStates);
                }
                tabCtrl.Refresh();
            }
            catch(Exception ex)
            {
                StaticFun.MessageFun.ShowMessage(ex);
            }
        }
    }
}

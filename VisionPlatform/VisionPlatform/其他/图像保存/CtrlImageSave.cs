using BaseData;
using StaticFun;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisionPlatform
{
    public partial class CtrlImageSave : UserControl
    {
        public CtrlImageSave()
        {
            InitializeComponent();
            this.Visible = true;
            this.Dock = DockStyle.Fill;
            this.Padding = new System.Windows.Forms.Padding(1);
        }

        private void CtrlImageSave_Load(object sender, EventArgs e)
        {
            try
            {
                OtherConfig otherConfig = GlobalData.Config._InitConfig.otherConfig;
                checkBox_ShowData.Checked = otherConfig.bDisplay;
                checkBox_SaveOrgImageOK.Checked = otherConfig.bOrgOK;
                checkBox_SaveResultImgOK.Checked = otherConfig.bResultOK;
                checkBox_SaveOrgImageNG.Checked = otherConfig.bOrgNG;
                checkBox_SaveResultImgNG.Checked = otherConfig.bResultNG;
            }
            catch (Exception ex)
            {
                StaticFun.MessageFun.ShowMessage(ex);
            }
        }

        private void Save(object sender, EventArgs e)
        {
            try
            {
                OtherConfig otherConfig = GlobalData.Config._InitConfig.otherConfig;
                otherConfig.bDisplay = checkBox_ShowData.Checked;
                otherConfig.bOrgOK = checkBox_SaveOrgImageOK.Checked;
                otherConfig.bResultOK = checkBox_SaveResultImgOK.Checked;
                otherConfig.bOrgNG = checkBox_SaveOrgImageNG.Checked;
                otherConfig.bResultNG = checkBox_SaveResultImgNG.Checked;
                GlobalData.Config._InitConfig.otherConfig = otherConfig;
                SaveData.SaveOtherConfig(GlobalData.Config._InitConfig.otherConfig);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        /// <summary>
        /// 设置显示的方式
        /// </summary>
        /// <param name="i"></param> 1：5行1列  2：3行2列
        public void RefeshUI(int i = 1)
        {
            try
            {
                double height, width;
                tLPanel.RowCount = 5;
                tLPanel.ColumnCount = 1;
                height = 20;
                width = 100.0;
                if (i == 2)
                {
                    tLPanel.RowCount = 3;
                    tLPanel.ColumnCount = 2;
                    height = 33.33;
                    width = 50.0;
                }
                for (int row = 0; row < tLPanel.RowCount; row++)
                {
                    tLPanel.RowStyles.Add(new RowStyle(SizeType.Percent, (float)height));
                    for (int col = 0; col < tLPanel.ColumnCount; col++)
                    {
                        tLPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, (float)width));
                    }
                }
                if (i == 1)
                {
                    tLPanel.Controls.Add(checkBox_ShowData, 0, 0);
                    tLPanel.Controls.Add(checkBox_SaveOrgImageOK, 0, 1);
                    tLPanel.Controls.Add(checkBox_SaveResultImgOK, 0, 2);
                    tLPanel.Controls.Add(checkBox_SaveOrgImageNG, 0, 3);
                    tLPanel.Controls.Add(checkBox_SaveResultImgNG, 0, 4);
                }
                else if (i == 2)
                {
                    tLPanel.Controls.Add(checkBox_SaveOrgImageOK, 0, 0);
                    tLPanel.Controls.Add(checkBox_SaveResultImgOK, 0, 1);
                    tLPanel.Controls.Add(checkBox_SaveOrgImageNG, 1, 0);
                    tLPanel.Controls.Add(checkBox_SaveResultImgNG, 1, 1);
                    tLPanel.Controls.Add(checkBox_ShowData, 0, 2);
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        private void 显示1_Click(object sender, EventArgs e)
        {
            RefeshUI(1);
        }

        private void 显示2_Click(object sender, EventArgs e)
        {
            RefeshUI(2);
        }
    }
}

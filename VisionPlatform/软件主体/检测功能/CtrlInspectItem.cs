using System;
using System.Windows.Forms;

namespace VisionPlatform
{
    public partial class CtrlInspectItem : UserControl
    {
        public CtrlInspectItem()
        {
            InitializeComponent();
            this.Visible = true;
            this.Dock = DockStyle.Fill;
            this.Padding = new System.Windows.Forms.Padding(0);
        }

        private void checkBox_CheckedChanged(object sender, System.EventArgs e)
        {
            try
            {
                CheckBox cb = sender as CheckBox;
                if (null == cb) return;
                if (!checkBox_Font.Checked && !checkBox_Back.Checked && !checkBox_Top.Checked)
                {
                    checkBox_Font.Checked = true;
                    checkBox_Back.Checked = true;
                    checkBox_Top.Checked = true;
                }
                InspectData.LabelInspectItem item = new InspectData.LabelInspectItem(checkBox_Font.Checked, checkBox_Back.Checked, checkBox_Top.Checked);
                DataSerializer._globalData.labelInspect = item;
                //MessageBox.Show($"标签检测面更新设置完成！");
            }
            catch (SystemException ex)
            {
                StaticFun.MessageFun.ShowMessage(ex);
            }
        }
    }
}

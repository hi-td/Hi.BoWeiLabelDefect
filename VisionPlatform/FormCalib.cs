using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace VisionPlatform
{
    public partial class FormCalib : Form
    {
        NumericUpDown numUpD_CalibVal = new NumericUpDown();
        List<TabPage> listTabPages = new List<TabPage>();
        public FormCalib(NumericUpDown numUpD)
        {
            InitializeComponent();
            this.Visible = true;
            this.numUpD_CalibVal = numUpD;
            listTabPages = new List<TabPage> { tabPage1, tabPage2 };
        }

        private void but_Calib_Click(object sender, EventArgs e)
        {
            try
            {
                bool bResult1 = double.TryParse(textBox_mm.Text, out double mm);
                bool bResult2 = double.TryParse(textBox_pixel.Text, out double dPixel);
                if(bResult1 && bResult2)
                {
                    double dCalibVal = Math.Round(mm / dPixel,5);
                    numUpD_CalibVal.Value = (decimal)dCalibVal;
                    label_CalibVal.Text = dCalibVal.ToString();
                }
            }
            catch (Exception ex)
            {
                StaticFun.MessageFun.ShowMessage(ex);
            }
        }
        bool bChange;
        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (bChange) return;
            CheckBox cb = sender as CheckBox;
            if (cb == null) return;
            foreach(TabPage tab in listTabPages)
            {
                tab.Parent = (cb.Checked && tab.Text == cb.Text) ? tabCtrl : null;
            }
            tabCtrl.Refresh();
            bChange = true;
            foreach (CheckBox checkBox in tLPanel.Controls)
            {
                checkBox.Checked = (cb.Checked && checkBox.Text == cb.Text) ? true : false;
            }
            bChange = false;
        }

        private void FormCalib_Load(object sender, EventArgs e)
        {
            checkBox1.Checked = true;
            checkBox_CheckedChanged(checkBox1, null);
        }
    }
}

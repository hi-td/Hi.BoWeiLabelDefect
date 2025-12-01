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
    public partial class CtrlSaturation : UserControl
    {
        Function fun;
        public CtrlSaturation(Function fun)
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            this.Visible = true;
            this.fun = fun;
        }
        public int[] InitParam()
        {
            int[] nHSV = new int[3];
            try
            {
                nHSV[0] = (int)numUpDH.Value;
                nHSV[1] = (int)numUpDS.Value;
                nHSV[2] = (int)numUpDV.Value;
                trackBarH.Value = nHSV[0];
                trackBarS.Value = nHSV[1];
                trackBarV.Value = nHSV[2];
            }
            catch (Exception ex)
            {
                MessageFun.ShowMessage(ex);
            }
            return nHSV;
        }
        public void LoadParam(int[] nHSV)
        {
            try
            {
                numUpDH.Value = nHSV[0];
                numUpDS.Value = nHSV[1];
                numUpDV.Value = nHSV[2];
                trackBarH.Value = nHSV[0];
                trackBarS.Value = nHSV[1];
                trackBarV.Value = nHSV[2];
            }
            catch (Exception ex)
            {
                MessageFun.ShowMessage(ex);
            }
        }
        private void Inspect(object sender, EventArgs e)
        {
            fun.ImageSaturation(InitParam());
        }
        private void trackBarH_Scroll(object sender, EventArgs e)
        {
            numUpDH.Value = trackBarH.Value;
        }

        private void trackBarS_Scroll(object sender, EventArgs e)
        {
            numUpDS.Value= trackBarS.Value;
        }

        private void trackBarV_Scroll(object sender, EventArgs e)
        {
            numUpDV.Value = trackBarV.Value;
        }
    }
}

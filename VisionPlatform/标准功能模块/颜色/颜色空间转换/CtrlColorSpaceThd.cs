using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static VisionPlatform.InspectData;

namespace VisionPlatform
{
    public partial class CtrlColorSpaceThd : UserControl
    {
        Function Fun;
        string m_color = "";
        bool bLoad = false;
        private event CtrlColorSpaceThdEventHandler _valueChanged;
        public CtrlColorSpaceThd()
        {
            InitializeComponent();
            this.Visible = true;
            this.Dock = DockStyle.Top;
            this.Margin = new Padding(0);
        }
        public void UpdateFun(Function fun)
        {
            this.Fun = fun;
            ctrlColorSpaceTrans.UpdateFun(fun);
        }
        public event CtrlColorSpaceThdEventHandler ValueChanged
        {
            add { _valueChanged += value; }
            remove { _valueChanged -= value; }
        }
        public ColorSpaceThdData InitParam()
        {
            ColorSpaceThdData param = new ColorSpaceThdData();
            try
            {
                bLoad = true;
                param.spaceTrans = ctrlColorSpaceTrans.InitParam();
                param.Thd.bFlag = checkBox_bThd.Checked;
                int nMinThd = (int)numUpD_MinThd.Value;
                int nMaxThd = (int)numUpD_MaxThd.Value;
                if (nMinThd >= nMaxThd)
                {
                    nMaxThd = nMinThd + 1;
                }
                param.Thd.dMin = nMinThd;
                trackBar_MinThd.Value = nMinThd;
                numUpD_MinThd.Value = nMinThd;
                param.Thd.dMax = nMaxThd;
                trackBar_MaxThd.Value = nMaxThd;
                numUpD_MaxThd.Value = nMaxThd;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            bLoad = false;
            return param;
        }
        public void LoadParam(ColorSpaceThdData param)
        {
            bLoad = true;
            try
            {
                ctrlColorSpaceTrans.LoadParam(param.spaceTrans);
                checkBox_bThd.Checked = param.Thd.bFlag;
                tLPanel_Thd.Visible = param.Thd.bFlag;
                numUpD_MinThd.Value = (decimal)param.Thd.dMin;
                trackBar_MinThd.Value = (int)param.Thd.dMin;
                numUpD_MaxThd.Value = (decimal)param.Thd.dMax;
                trackBar_MaxThd.Value = (int)param.Thd.dMax;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            bLoad = false;
        }
        private void Inspect(object sender, EventArgs e)
        {
            try
            {
                if (bLoad) { return; }
                _valueChanged?.Invoke(sender, e);
            }
            catch (Exception ex)
            {

            }
        }
        private void trackBar_MinThd_Scroll(object sender, EventArgs e)
        {
            numUpD_MinThd.Value = trackBar_MinThd.Value;
        }
        private void trackBar_MaxThd_Scroll(object sender, EventArgs e)
        {
            numUpD_MaxThd.Value = trackBar_MaxThd.Value;
        }

        private void checkBox_bThd_CheckedChanged(object sender, EventArgs e)
        {
            tLPanel_Thd.Visible = checkBox_bThd.Checked;
        }
    }
}

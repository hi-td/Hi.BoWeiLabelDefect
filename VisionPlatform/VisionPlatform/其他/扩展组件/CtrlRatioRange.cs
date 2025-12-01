using BaseData;
using System;
using System.Windows.Forms;

namespace VisionPlatform
{
    public partial class CtrlRatioRange : UserControl
    {
        bool bLoad = false;
        private event CtrlRatioRangeEventHandler _valueChanged;
        public CtrlRatioRange()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            this.Visible = true;
            this.Padding = new Padding(1);
        }

        public event CtrlRatioRangeEventHandler ValueChanged
        {
            add { _valueChanged += value; }
            remove { _valueChanged -= value; }
        }
        public RatioRange InitParam()
        {
            RatioRange param = new RatioRange();
            try
            {
                param.dVal = (double)numUpD_Val.Value;
                param.dRatioMin = (double)numUpD_Min.Value;
                param.dRatioMax = (double)numUpD_Max.Value;
                label_Min.Text = param.MinVal().ToString();
                label_Max.Text = param.MaxVal().ToString();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return param;
        }

        public void LoadParam(RatioRange param)
        {
            try
            {
                bLoad = true;
                numUpD_Val.Value = (decimal)param.dVal;
                numUpD_Min.Value = (decimal)param.dRatioMin;
                numUpD_Max.Value = (decimal)param.dRatioMax;
                label_Min.Text = param.MinVal().ToString();
                label_Max.Text = param.MaxVal().ToString();
            }
            catch (Exception ex)
            {
                StaticFun.MessageFun.ShowMessage(ex);
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
                StaticFun.MessageFun.ShowMessage(ex);
            }
        }
    }
}

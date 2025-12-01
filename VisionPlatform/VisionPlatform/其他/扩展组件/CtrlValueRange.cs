using System;
using System.Windows.Forms;

namespace VisionPlatform
{
    public partial class CtrlValueRange : UserControl
    {
        bool bLoad = false;
        private event CtrlValueRangeEventHandler _valueChanged;
        public CtrlValueRange()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            this.Visible = true;
            this.Margin = new Padding(0);
        }
        public event CtrlValueRangeEventHandler ValueChanged
        {
            add { _valueChanged += value; }
            remove { _valueChanged -= value; }
        }
        public BaseData.ValueRange InitParam()
        {
            BaseData.ValueRange param = new BaseData.ValueRange();
            try
            {
                param.bFlag = checkBox_Name.Visible ? checkBox_Name.Checked : true;
                if (numUpD_Min.Value > numUpD_Max.Value)
                {
                    numUpD_Min.Value = numUpD_Max.Value - numUpD_Min.Increment;
                }
                if (numUpD_Max.Value < numUpD_Min.Value)
                {
                    numUpD_Max.Value = numUpD_Min.Value + numUpD_Max.Increment;
                }
                param.dMin = (double)numUpD_Min.Value;
                param.dMax = (double)numUpD_Max.Value;
            }
            catch (Exception ex)
            {
                StaticFun.MessageFun.ShowMessage(ex.ToString());
            }
            return param;
        }

        public void LoadParam(BaseData.ValueRange param)
        {
            try
            {
                bLoad = true;
                checkBox_Name.Checked = param.bFlag;
                numUpD_Min.Value = (decimal)param.dMin;
                numUpD_Max.Value = (param.dMax != 0 ? (decimal)param.dMax : numUpD_Max.Maximum);
            }
            catch (Exception ex)
            {
                StaticFun.MessageFun.ShowMessage(ex);
            }
            bLoad = false;
        }

        public void SetValue(bool bCBName, string strName, int nMin, int nMax, double dIncrement, int nDecimalPlaces)
        {
            try
            {
                checkBox_Name.Text = strName;
                label_Name.Text = strName;
                checkBox_Name.Visible = bCBName;
                tLPanel_LableName.Visible = !bCBName;
                label_Name.Visible = !bCBName;
                //最小值取值范围
                numUpD_Min.Minimum = nMin;
                numUpD_Min.Maximum = nMax;
                numUpD_Min.Increment = (decimal)dIncrement;
                numUpD_Min.DecimalPlaces = nDecimalPlaces;
                //最大值取值范围
                numUpD_Max.Minimum = nMin;
                numUpD_Max.Maximum = nMax;
                numUpD_Max.Increment = (decimal)dIncrement;
                numUpD_Max.DecimalPlaces = nDecimalPlaces;
                //numUpD_Min.Value = nMin;
                //numUpD_Max.Value = nMax;
            }
            catch (Exception ex)
            {
                StaticFun.MessageFun.ShowMessage(ex);
            }
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
    }
}

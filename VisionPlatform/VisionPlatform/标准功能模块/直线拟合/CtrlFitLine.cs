using BaseData;
using System;
using System.Windows.Forms;

namespace VisionPlatform
{
    public partial class CtrlFitLine : UserControl
    {
        bool bLoad = false;
        private event CtrlFitLineEventHandler _valueChanged;
        public CtrlFitLine()
        {
            InitializeComponent();
            this.Visible = true;
            this.Dock = DockStyle.Fill;
            this.Margin = new Padding(0);
        }
        public event CtrlFitLineEventHandler ValueChanged
        {
            add { _valueChanged += value; }
            remove { _valueChanged -= value; }
        }
        public BaseData.EdgePointMeasure InitParam()
        {
            BaseData.EdgePointMeasure param = new EdgePointMeasure();
            try
            {
                param.bShow = checkBox_show.Checked;
                param.nLen1 = (int)numUpD_Len2.Value;
                trackBar_Len2.Value = (int)numUpD_Len2.Value;
                param.dLen2 = 5;
                param.nThd = (int)numUpD_Thd.Value;
                trackBar_Thd.Value = (int)numUpD_Thd.Value;
                switch (comBox_Trans.SelectedIndex)
                {
                    case 0:
                        param.strTrans = "negative";
                        break;
                    case 1:
                        param.strTrans = "positive";
                        break;
                    default:
                        comBox_Trans.SelectedIndex = 0;
                        param.strTrans = "negative";
                        break;
                }
                switch (comBox_EdgePoint.SelectedIndex)
                {
                    case 0:
                        param.strSelect = "first";
                        break;
                    case 1:
                        param.strSelect = "last";
                        break;
                    default:
                        comBox_EdgePoint.SelectedIndex = 0;
                        param.strSelect = "first";
                        break;
                }
                switch (comboBox_Direction.Text)
                {
                    case "从上往下":
                        param.direct = MesDirect.UpDown;
                        break;
                    case "从下往上":
                        param.direct = MesDirect.DownUp;
                        break;
                    case "从左往右":
                        param.direct = MesDirect.LeftRight;
                        break;
                    case "从右往左":
                        param.direct = MesDirect.RightLeft;
                        break;
                    default:
                        param.direct = MesDirect.UpDown;
                        break;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return param;
        }

        public void LoadParam(BaseData.EdgePointMeasure param)
        {
            try
            {
                bLoad = true;
                checkBox_show.Checked = param.bShow;
                numUpD_Len2.Value = param.nLen1;
                trackBar_Len2.Value = param.nLen1;
                numUpD_Thd.Value = param.nThd;
                trackBar_Thd.Value = param.nThd;
                comBox_Trans.SelectedIndex = (param.strTrans == "negative") ? 0 : 1;
                comBox_EdgePoint.SelectedIndex = (param.strSelect == "first") ? 0 : 1;
                switch (param.direct)
                {
                    case MesDirect.UpDown:
                        comboBox_Direction.SelectedIndex = 0;
                        break;
                    case MesDirect.DownUp:
                        comboBox_Direction.SelectedIndex = 1;
                        break;
                    case MesDirect.LeftRight:
                        comboBox_Direction.SelectedIndex = 2;
                        break;
                    case MesDirect.RightLeft:
                        comboBox_Direction.SelectedIndex = 3;
                        break;
                    default:
                        comboBox_Direction.SelectedIndex = 0;
                        break;
                }
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
                StaticFun.MessageFun.ShowMessage(ex);
            }
        }

        private void trackBar_Len2_Scroll(object sender, EventArgs e)
        {
            numUpD_Len2.Value = trackBar_Len2.Value;
        }

        private void trackBar_Thd_Scroll(object sender, EventArgs e)
        {
            numUpD_Thd.Value = trackBar_Thd.Value;
        }
    }
}

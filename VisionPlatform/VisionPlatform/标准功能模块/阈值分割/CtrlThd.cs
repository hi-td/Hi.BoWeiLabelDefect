using System;
using System.Windows.Forms;

namespace VisionPlatform
{
    public partial class CtrlThd : UserControl
    {
        bool bLoad = false;
        private event CtrlThdEventHandler _valueChanged;
        public CtrlThd()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            this.Visible = true;
            this.Margin = new Padding(1);
        }
        public event CtrlThdEventHandler ValueChanged
        {
            add { _valueChanged += value; }
            remove { _valueChanged -= value; }
        }
        public BaseData.ThdParam InitParam()
        {
            BaseData.ThdParam param = new BaseData.ThdParam();
            try
            {
                param.bAutoThd = checkBox_AutoThd.Checked;                     //true：自动阈值 false：静态阈值
                param.nMeanMask = (int)numUpD_MeanMask.Value;                  //动态阈值：均值滤波
                param.nDynThd = (int)numUpD_DynThd.Value;                      //动态阈值：Offset
                if (radioButton_dark.Checked)
                {
                    param.sLightDark = "dark";
                }
                else
                {
                    param.sLightDark = "light";
                }
                param.nStaticThdMin = (int)numUpD_StaticThdMin.Value;          //静态阈值最小值
                trackBar_StaticThdMin.Value = (int)numUpD_StaticThdMin.Value;
                param.nStaticThdMax = (int)numUpD_StaticThdMax.Value;          //静态阈值最大值
                trackBar_StaticThdMax.Value = (int)numUpD_StaticThdMax.Value;
            }
            catch (Exception ex)
            {
                StaticFun.MessageFun.ShowMessage(ex.ToString());
            }
            return param;

        }

        public void LoadParam(BaseData.ThdParam param)
        {
            try
            {
                bLoad = true;
                checkBox_AutoThd.Checked = param.bAutoThd ? true : false;
                checkBox_StaticThd.Checked = !checkBox_AutoThd.Checked;
                numUpD_MeanMask.Value = (param.nMeanMask != 0) ? param.nMeanMask : 25;
                numUpD_DynThd.Value = (param.nDynThd != 0) ? param.nDynThd : 5;
                if (param.sLightDark == "dark")
                {
                    radioButton_dark.Checked = true;
                }
                else
                {
                    radioButton_light.Checked = true;
                }
                numUpD_StaticThdMin.Value = param.nStaticThdMin;          //静态阈值最小值
                trackBar_StaticThdMin.Value = param.nStaticThdMin;
                numUpD_StaticThdMax.Value = (param.nStaticThdMax != 0) ? param.nStaticThdMax : 255;          //静态阈值最大值
                trackBar_StaticThdMax.Value = (int)numUpD_StaticThdMax.Value;
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

            }
        }

        private void trackBar_StaticThd_Scroll(object sender, EventArgs e)
        {
            numUpD_StaticThdMin.Value = trackBar_StaticThdMin.Value;
        }

        private void checkBox_AutoThd_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_AutoThd.Checked)
            {
                checkBox_StaticThd.Checked = false;
                tLPanel_DynThd.Visible = true;
            }
            else
            {
                checkBox_StaticThd.Checked = true;
                tLPanel_DynThd.Visible = false;
            }
        }
        private void checkBox_StaticThd_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_StaticThd.Checked)
            {
                checkBox_AutoThd.Checked = false;
                tLPanel_DynThd.Visible = false;
            }
            else
            {
                checkBox_AutoThd.Checked = true;
                tLPanel_DynThd.Visible = true;
            }
        }

        private void trackBar_StaticThdMax_Scroll(object sender, EventArgs e)
        {
            numUpD_StaticThdMax.Value = trackBar_StaticThdMax.Value;
        }
    }
}

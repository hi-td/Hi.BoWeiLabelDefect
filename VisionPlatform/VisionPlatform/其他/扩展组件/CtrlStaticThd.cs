using BaseData;
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
    public partial class CtrlStaticThd : UserControl
    {
        private event CtrlStaticThdEventHandler _valueChanged;
        bool bLoad = false;
        public CtrlStaticThd()
        {
            InitializeComponent();
            this.Visible = true;
            this.Dock = DockStyle.Fill;
            this.Margin = new Padding(0);
        }
        public event CtrlStaticThdEventHandler ValueChanged
        {
            add { _valueChanged += value; }
            remove { _valueChanged -= value; }
        }
        public BaseData.StaticThdParam InitParam()
        {
            BaseData.StaticThdParam param = new StaticThdParam();
            try
            {
                param.b0_x = checkBox_Thd0.Checked;
                param.nThd = (int)numUpD_Thd.Value;
                trackBar_Thd.Value = param.nThd;
            }
            catch (Exception ex)
            {
                StaticFun.MessageFun.ShowMessage(ex.ToString());
            }
            return param;
        }
        public void LoadParam(BaseData.StaticThdParam param)
        {
            try
            {
                bLoad = true;
                checkBox_Thd0.Checked = param.b0_x;
                checkBox_Thd255.Checked = !param.b0_x;
                numUpD_Thd.Value = param.nThd;
                trackBar_Thd.Value = param.nThd;
            }
            catch (Exception ex)
            {
                StaticFun.MessageFun.ShowMessage($"Thd0_255LoadParam:{ex}");
            }
            bLoad = false;
        }

        private void trackBar_Thd_Scroll(object sender, EventArgs e)
        {
            numUpD_Thd.Value = trackBar_Thd.Value;
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CheckBox cb = sender as CheckBox;
                if (null != cb)
                {
                    if (cb.Name.Contains("Thd0"))
                    {
                        checkBox_Thd255.Checked = !cb.Checked;
                    }
                    else if (cb.Name.Contains("Thd255"))
                    {
                        checkBox_Thd0.Checked = !cb.Checked;
                    }
                }
            }
            catch (Exception ex)
            {
                StaticFun.MessageFun.ShowMessage(ex);
            }
        }

        private void numUpD_Thd_ValueChanged(object sender, EventArgs e)
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

        public void SetEnabled(bool bEnabeld, bool bSelThd0 = false)
        {
            checkBox_Thd0.Enabled = bEnabeld;
            checkBox_Thd255.Enabled = bEnabeld;
            if (!bEnabeld)
            {
                if (bSelThd0)
                {
                    checkBox_Thd0.Checked = true;
                    checkBox_Thd255.Checked = false;
                }
                else
                {
                    checkBox_Thd0.Checked = false;
                    checkBox_Thd255.Checked = true;
                }
            }
        }
    }
}

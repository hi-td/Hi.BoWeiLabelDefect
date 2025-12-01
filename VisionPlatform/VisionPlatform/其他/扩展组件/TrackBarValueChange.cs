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
    public partial class TrackBarValueChange : UserControl
    {
        private event TrackBarValueChangeEventHandler _valueChanged;
        bool bLoad = false;
        public TrackBarValueChange()
        {
            InitializeComponent();
            this.Visible = true;
            this.Dock = DockStyle.Fill;
            this.Margin = new Padding(0);
        }

        public event TrackBarValueChangeEventHandler ValueChanged
        {
            add { _valueChanged += value; }
            remove { _valueChanged -= value; }
        }
        public int GetValue()
        {
            return (int)numUpD_value.Value;
        }
        public void SetValue(object val)
        {
            try
            {
                bLoad = true;
                if (val!=null && int.TryParse(val.ToString(), out var intVal))
                {
                    if (intVal >= (int)(numUpD_value.Minimum) && intVal <= (int)numUpD_value.Maximum)
                    {
                        numUpD_value.Value = intVal;
                        trackBar_value.Value = intVal;
                    }
                }
            }
            catch (Exception ex)
            {
                StaticFun.MessageFun.ShowMessage(ex);
            }
            bLoad = false;
        }
        public void SetValueRange(int min, int max)
        {
            try
            {
                bLoad = true;
                numUpD_value.Maximum = max;
                numUpD_value.Minimum = min;
                trackBar_value.Maximum = max;
                trackBar_value.Minimum = min;
            }
            catch (Exception ex)
            {
                StaticFun.MessageFun.ShowMessage(ex);
            }
            bLoad = false;
        }
        private void trackBar_value_Scroll(object sender, EventArgs e)
        {
            numUpD_value.Value = trackBar_value.Value;
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
                ex.ToString();
            }
        }
    }
}

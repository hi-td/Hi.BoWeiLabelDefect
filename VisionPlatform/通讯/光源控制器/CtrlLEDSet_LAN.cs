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

namespace VisionPlatform.通讯.光源控制器
{
    public partial class CtrlLEDSet_LAN : UserControl
    {
        public string myIP;
        public BaseData.LEDLAN myLed = new LEDLAN();
        public int nCH;
        bool bLoad = false;
        private event TrackBarValueChangedEventHandler _valueChanged;
        public CtrlLEDSet_LAN()
        {
            InitializeComponent();
            this.Visible = true;
            this.Dock = DockStyle.Top;
            this.Margin = new Padding(1);
        }

        public void SetLAN(string ip)
        {
            if (null == ip) return;
            this.myIP = ip;
            if (null != DataSerializer._COMConfig.dicLedLan &&
                DataSerializer._COMConfig.dicLedLan.ContainsKey(ip))
            {
                this.myLed = DataSerializer._COMConfig.dicLedLan[ip];
            }
        }
        public event TrackBarValueChangedEventHandler ValueChanged
        {
            add { _valueChanged += value; }
            remove { _valueChanged -= value; }
        }
        public CHBright InitParam()
        {
            CHBright param = new CHBright();
            try
            {
                param.bOpen = checkBox_bSel.Checked;
                param.nBrightness = (int)numUpD_Brightness.Value;
            }
            catch (Exception ex)
            {
                StaticFun.MessageFun.ShowMessage(ex);
            }
            return param;
        }

        public void LoadParam(int nCH, CHBright cHBright)
        {
            try
            {
                checkBox_bSel.Checked = cHBright.bOpen;
                this.nCH = nCH;
                this.label_CH.Text = "CH" + nCH.ToString();
                trackBar_Brightness.Enabled = cHBright.bOpen;
                numUpD_Brightness.Enabled = cHBright.bOpen;
                trackBar_Brightness.Value = cHBright.nBrightness;
                numUpD_Brightness.Value = cHBright.nBrightness;
                if (cHBright.bOpen && DataSerializer._COMConfig.dicLedLan.ContainsKey(myIP))
                {
                    LEDControl_LAN.SetBrightness(this.myLed, nCH, cHBright.nBrightness);
                }
            }
            catch (Exception ex)
            {
                StaticFun.MessageFun.ShowMessage(ex);
            }
        }

        private void trackBar_Brightness_Scroll(object sender, EventArgs e)
        {
            numUpD_Brightness.Value = trackBar_Brightness.Value;
        }

        private void Inspect(object sender, EventArgs e)
        {
            try
            {
                if (bLoad) { return; }
                CheckBox cb = sender as CheckBox;
                if (null != cb)
                {
                    if (cb.Checked)
                    {
                        cb.BackColor = Color.Green;
                    }
                    else
                    {
                        cb.BackColor = Color.Transparent;
                        numUpD_Brightness.Value = 0;
                        trackBar_Brightness.Value = 0;
                    }
                    trackBar_Brightness.Enabled = cb.Checked;
                    numUpD_Brightness.Enabled = cb.Checked;
                }
                trackBar_Brightness.Value = (int)numUpD_Brightness.Value;
                LEDControl_LAN.SetBrightness(this.myLed, nCH, (int)numUpD_Brightness.Value);
                _valueChanged?.Invoke(sender, e);
            }
            catch (Exception ex)
            {

            }
        }

    }
}

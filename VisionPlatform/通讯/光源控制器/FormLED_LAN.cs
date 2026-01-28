using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BaseData;
using Hi.Ltd.Threading;
using Newtonsoft.Json;
using StaticFun;

namespace VisionPlatform.通讯.光源控制器
{
    public partial class FormLED_LAN : Form
    {
        Dictionary<string, CheckBox> dicCheckBox = new Dictionary<string, CheckBox>();
        LEDControl_LAN ledControl_LAN = new LEDControl_LAN();
        public FormLED_LAN()
        {
            InitializeComponent();
            InitUI();
        }
        
        private void InitUI()
        {
            //if (DataSerializer._COMConfig.dicLedLan == null) return;
            try
            {
                foreach (var ip in DataSerializer._COMConfig.dicLedLan.Keys)
                {
                    CheckBox cb = new CheckBox();
                    cb.Text = ip;
                    cb.Enabled = false;
                    cb.Padding = new Padding(1);
                    flowLayoutPanel.Controls.Add(cb);
                    dicCheckBox.Add(ip, cb);
                    dicCheckBox[ip].Checked = true;
                    dicCheckBox[ip].BackColor = Color.Green;

                    cbx_ipList.Items.Add(ip);
                    cbx_ipList.SelectedItem = cbx_ipList.Items[0];
                }
            }
            catch (Exception ex)
            {
                MessageFun.ShowMessage("未找到光源控制器网口配置信息!" + ex.Message);
            }
        }

        private BaseData.LEDLAN InitParam()
        {
            BaseData.LEDLAN param = new BaseData.LEDLAN();
            try
            {
                param.Port = int.Parse(textBox_Port.Text);
                param.IP = textBox_IP.Text;
                param.bOpen = false;
                if (lbl_statu.Text == "已打开")
                {
                    param.bOpen = true;
                }
            }
            catch (SystemException error)
            {

            }
            return param;
        }
        private void btn_openPort_Click(object sender, EventArgs e)
        {
            LEDLAN ledLAN = InitParam();

            if (cbx_ipList.Items.Count == 0 || !cbx_ipList.Items.Contains(ledLAN.IP)) 
            {
                MessageBox.Show("请先添加IP地址！");
                return;
            }
            //刷新配置
            if (lbl_statu.Text == "已打开" || lbl_statu.Text == "Opened")
            {
                DialogResult dr = DialogResult.OK;
                if (GlobalData.Config._language == EnumData.Language.english)
                {
                    dr = MessageBox.Show("The lan has been opened, do you want to reset it?", "Tips:", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                }
                else
                {
                    dr = MessageBox.Show("网口已打开，是否重新设置？", "提示：", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                }
                if (dr != DialogResult.OK)
                {
                    return;
                }
                LEDControl_LAN.CloseLED(ref ledLAN);
            }
            try
            {
                foreach (Control cb in flowLayoutPanel.Controls)
                {
                    if ((cb as CheckBox).Text == ledLAN.IP)
                    {
                        flowLayoutPanel.Controls.Remove(cb);
                    }
                }
                dicCheckBox.Remove(ledLAN.IP);
                if (ledControl_LAN.OpenLedLan(ref ledLAN))
                {
                    if (GlobalData.Config._language == EnumData.Language.english)
                    {
                        lbl_statu.Text = "Opened";
                        MessageBox.Show("Reset and open lan successfully!");
                    }
                    else
                    {
                        lbl_statu.Text = "已打开";
                        lbl_statu.ForeColor = Color.Green;
                        MessageBox.Show("重新设置并打开网口成功！");
                    }

                    CheckBox cb = new CheckBox();
                    cb.Text = ledLAN.IP;
                    cb.Enabled = false;
                    cb.Padding = new Padding(1);
                    flowLayoutPanel.Controls.Add(cb);
                    dicCheckBox.Add(ledLAN.IP, cb);
                    dicCheckBox[ledLAN.IP].Checked = true;
                    dicCheckBox[ledLAN.IP].BackColor = Color.Green;
                }
            }
            catch (Exception ex)
            {
                MessageFun.ShowMessage("打开网口失败:" + ex.ToString(), true, "Failed to open lan:" + ex.ToString());
                return;
            }
        }

        private void btn_closePort_Click(object sender, EventArgs e)
        {
            try
            {
                LEDLAN ledLAN = InitParam();
                LEDControl_LAN.CloseLED(ref ledLAN);

                foreach (Control cb in flowLayoutPanel.Controls)
                {
                    if ((cb as CheckBox).Text == ledLAN.IP)
                    {
                        flowLayoutPanel.Controls.Remove(cb);
                    }
                }
                dicCheckBox.Remove(ledLAN.IP);
                cbx_ipList.Items.Remove(ledLAN.IP);
                
                if (GlobalData.Config._language == EnumData.Language.english)
                {
                    lbl_statu.Text = "Not opened";
                }
                else
                {
                    lbl_statu.Text = "未打开";
                }
                lbl_statu.ForeColor = Color.Red;
                if (DataSerializer._COMConfig.dicLedLan.ContainsKey(ledLAN.IP))
                {
                    DataSerializer._COMConfig.dicLedLan.Remove(ledLAN.IP);
                }
            }
            catch (Exception ex)
            {
                if (GlobalData.Config._language == EnumData.Language.english)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String strIP = textBox_IP.Text;
            BaseData.LEDLAN ledLAN = InitParam();
            if (null != DataSerializer._COMConfig.dicLedLan && DataSerializer._COMConfig.dicLedLan.ContainsKey(strIP))
            {
                DialogResult dr = DialogResult.OK;
                if (GlobalData.Config._language == EnumData.Language.english)
                {
                    dr = MessageBox.Show("Do you want to update the lan configuration file of the light source controller?", "Tips:", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                }
                else
                {
                    dr = MessageBox.Show($"是否更新光源控制器{strIP}的配置文件？", "提示：", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                }
                if (dr != DialogResult.OK)
                {
                    return;
                }
                DataSerializer._COMConfig.dicLedLan[strIP] = ledLAN;
            }
            else
            {
                DataSerializer._COMConfig.dicLedLan.Add(strIP, ledLAN);
            }
            var json = JsonConvert.SerializeObject(DataSerializer._COMConfig);
            System.IO.File.WriteAllText(GlobalPath.SavePath.IOPath, json);
            MessageFun.ShowMessage("光源控制器网口配置数据保存成功！", strEnglish: "The lan configuration data of the light source controller has been successfully saved!");
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            if (!this.cbx_ipList.Items.Contains(textBox_IP.Text))
            {
                if (!string.IsNullOrWhiteSpace(textBox_IP.Text) && IPAddress.TryParse(textBox_IP.Text, out _))
                {
                    this.cbx_ipList.Items.Add(textBox_IP.Text);
                    string ip = textBox_IP.Text;
                    int port = int.Parse(textBox_Port.Text);
                }
                else
                {
                    MessageBox.Show("IP地址格式错误!请重新设置!");
                }
            }
            else
            {
                MessageBox.Show("已经添加了该IP地址!请重新设置!");
            }
        }

        private void cbx_ipList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ipaddress = cbx_ipList.SelectedItem.ToString();
            foreach (var ip in DataSerializer._COMConfig.dicLedLan.Keys)
            {
                if (ip == ipaddress)
                {
                    LEDLAN ledData = DataSerializer._COMConfig.dicLedLan[ip];
                    textBox_IP.Text = ledData.IP;
                    textBox_Port.Text = ledData.Port.ToString();
                }
            }
        }
    }
}

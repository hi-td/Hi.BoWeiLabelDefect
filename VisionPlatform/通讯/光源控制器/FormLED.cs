using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StaticFun;

namespace VisionPlatform
{
    public partial class FormLED : Form
    {
        public FormLED()
        {
            InitializeComponent();
            InitUI();
        }
        private void InitUI()
        {
            //COM口
            string[] strPort = SerialPort.GetPortNames();
            if (strPort.Length > 0)
            {
                foreach (var item in strPort)
                {
                    this.cbx_portName.Items.Add(item);
                }
                this.cbx_portName.SelectedIndex = 0;
            }
            //波特率
            this.cbx_baudRate.Items.Add(9600);
            this.cbx_baudRate.Items.Add(19200);
            this.cbx_baudRate.Items.Add(38400);
            this.cbx_baudRate.SelectedIndex = 1;

            if (GlobalData.Config._language == EnumData.Language.english)
            {
                //校验位
                this.cbx_parityBit.Items.Add("None Parity");
                this.cbx_parityBit.Items.Add("Odd Parity");
                this.cbx_parityBit.Items.Add("Even Parity");
            }
            else
            {
                //校验位
                this.cbx_parityBit.Items.Add("无校验");
                this.cbx_parityBit.Items.Add("奇校验");
                this.cbx_parityBit.Items.Add("偶校验");
            }
            
            this.cbx_parityBit.SelectedIndex = 0;

            //数据位
            this.tbx_dataBit.Items.Add(8);
            this.tbx_dataBit.Items.Add(7);
            this.tbx_dataBit.Items.Add(6);
            this.tbx_dataBit.SelectedIndex = 0;
            //停止位
            //this.cmb_stopBits.Items.Add(0);
            this.cbx_stopBit.Items.Add(1);
            //this.cmb_stopBits.Items.Add(1.5);
            this.cbx_stopBit.Items.Add(2);
            this.cbx_stopBit.SelectedIndex = 0;
            //ComDevice.DataReceived += new SerialDataReceivedEventHandler(ComDevice_DataReceived);
        }

        private BaseData.LEDRTU InitParam()
        {
            BaseData.LEDRTU param = new BaseData.LEDRTU();
            try
            {
                int iparity = 0;
                if (this.cbx_parityBit.Text == "无校验" || this.cbx_parityBit.Text == "None Parity")
                {
                    iparity = (int)Parity.None;
                }
                else if (this.cbx_parityBit.Text == "奇校验" || this.cbx_parityBit.Text == "Odd Parity")
                {
                    iparity = (int)Parity.Odd;
                }
                else if (this.cbx_parityBit.Text == "偶校验" || this.cbx_parityBit.Text == "Even Parity")
                {
                    iparity = (int)Parity.Even;
                }

                int iStopBits = 0;
                if (this.cbx_stopBit.Text == "0")
                {
                    iStopBits = (int)StopBits.None;
                }
                else if (this.cbx_stopBit.Text == "1")
                {
                    iStopBits = (int)StopBits.One;
                }
                else if (this.cbx_stopBit.Text == "1.5")
                {
                    iStopBits = (int)StopBits.OnePointFive;
                }
                else if (this.cbx_stopBit.Text == "2")
                {
                    iStopBits = (int)StopBits.Two;
                }
                param.BaudRate = int.Parse(cbx_baudRate.Text);
                param.PortName = cbx_portName.Text;
                param.DataBits = int.Parse(tbx_dataBit.Text);
                param.parity = (Parity)iparity;
                param.stopBits = (StopBits)iStopBits;
                
            }
            catch (SystemException error)
            {

            }
            return param;
        }
        private void ComDevice_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //接收反回数据
            //byte[] ReDatas = new byte[ComDevice.BytesToRead];//返回命令包
            //ComDevice.Read(ReDatas, 0, ReDatas.Length);//读取数据             
            ////ASCII码显示
            //UpdateRecevie(System.Text.Encoding.Default.GetString(ReDatas));                
            //UpdateReceiveCount(ReDatas.Length);
            //不接受返回数据
           // ComDevice.DiscardInBuffer();
        }

        private void btn_openPort_Click(object sender, EventArgs e)
        {
            //刷新配置
            if (lbl_statu.Text == "已打开" || lbl_statu.Text == "Opened")
            {
                DialogResult dr = DialogResult.OK;
                if (GlobalData.Config._language == EnumData.Language.english)
                {
                    dr = MessageBox.Show("The serial port has been opened, do you want to reset it?", "Tips:", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                }
                else
                {
                    dr = MessageBox.Show("串口已打开，是否重新设置？", "提示：", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                }
                
                if (dr != DialogResult.OK)
                {
                    return;
                }
                LEDControl.CloseLED();
            }
            try
            {
                LEDControl.OpenLedCom(InitParam());
                if (GlobalData.Config._language == EnumData.Language.english)
                {
                    lbl_statu.Text = "Opened";
                    MessageBox.Show("Reset and open serial port successfully!");
                }
                else
                {
                    lbl_statu.Text = "已打开";
                    MessageBox.Show("重新设置并打开串口成功！");
                }
                lbl_statu.ForeColor = Color.Green;
            }
            catch (Exception ex)
            {
                MessageFun.ShowMessage("打开串口失败:" + ex.ToString(),true, "Failed to open serial port:" + ex.ToString());
                return;
            }
           
        }

        private void btn_closePort_Click(object sender, EventArgs e)
        {
            try
            {
                LEDControl.CloseLED();
                if (GlobalData.Config._language == EnumData.Language.english)
                {
                    lbl_statu.Text = "Not opened";
                }
                else
                {
                    lbl_statu.Text = "未打开";
                }
                
                lbl_statu.ForeColor = Color.Red;
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

        private void FormLED_Load(object sender, EventArgs e)
        {
            LoadLED();
        }

        private void LoadLED()
        {
            try
            {
                if (LEDControl.isOpen)
                {
                    if (GlobalData.Config._language == EnumData.Language.english)
                    {
                        lbl_statu.Text = "Opened";
                    }
                    else
                    {
                        lbl_statu.Text = "已打开";
                    }
                    lbl_statu.ForeColor = Color.Green;
                }
                else
                {
                    if (GlobalData.Config._language == EnumData.Language.english)
                    {
                        lbl_statu.Text = "Not opened";
                    }
                    else
                    {
                        lbl_statu.Text = "未打开";
                    }
                    
                    lbl_statu.ForeColor = Color.Red;
                }
                BaseData.LEDRTU LedRTU = DataSerializer._COMConfig.Led;
                cbx_baudRate.Text = LedRTU.BaudRate.ToString();
                cbx_portName.Text = LedRTU.PortName;
                tbx_dataBit.Text = LedRTU.DataBits.ToString();
                if (Parity.None == LedRTU.parity)
                {
                    if (GlobalData.Config._language == EnumData.Language.english)
                    {
                        cbx_parityBit.Text = "None Parity";
                    }
                    else
                    {
                        cbx_parityBit.Text = "无校验";
                    }
                    
                }
                else if (Parity.Odd == LedRTU.parity)
                {
                    if (GlobalData.Config._language == EnumData.Language.english)
                    {
                        cbx_parityBit.Text = "Odd Parity";
                    }
                    else
                    {
                        cbx_parityBit.Text = "奇校验";
                    }
                }
                else if (Parity.Even == LedRTU.parity)
                {
                    if (GlobalData.Config._language == EnumData.Language.english)
                    {
                        cbx_parityBit.Text = "Even Parity";
                    }
                    else
                    {
                        cbx_parityBit.Text = "偶校验";
                    }
                }
                if (StopBits.One == LedRTU.stopBits)
                {
                    cbx_stopBit.Text = "1";
                }
                else if (StopBits.Two == LedRTU.stopBits)
                {
                    cbx_stopBit.Text = "2";
                }
            }
            catch (Exception)
            {
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(DataSerializer._COMConfig.Led.PortName !=null)
            {
                DialogResult dr = DialogResult.OK;
                if (GlobalData.Config._language == EnumData.Language.english)
                {
                    dr = MessageBox.Show("Do you want to update the serial port configuration file of the light source controller?", "Tips:", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                }
                else
                {
                    dr = MessageBox.Show("是否更新光源控制器串口配置文件？", "提示：", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                }
                if (dr != DialogResult.OK)
                {
                    return;
                }
            }
            DataSerializer._COMConfig.Led = InitParam();
            var json = JsonConvert.SerializeObject(DataSerializer._COMConfig);
            System.IO.File.WriteAllText(GlobalPath.SavePath.IOPath, json);
            MessageFun.ShowMessage("更新并保存成功！", strEnglish: "Updated and saved successfully!");
            MessageFun.ShowMessage("光源控制器串口配置数据保存成功！", strEnglish: "The serial port configuration data of the light source controller has been successfully saved!");
        }
    }
}

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
using DAL;
using Newtonsoft.Json;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace VisionPlatform
{
    public partial class FormPLCRTU : Form
    {
        Modbus_RTU objMod = new Modbus_RTU();
        //参数(分别为站号,起始地址,长度)
        private byte slaveAddress;
        private ushort startAddress;
        private ushort numberOfPoints;
        //写线圈或写寄存器数组
        private bool[] coilsBuffer;
        private ushort[] registerBuffer;
        public FormPLCRTU()
        {
            InitializeComponent();
            InitPort();
        }
        private void InitPort()
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
            this.cbx_baudRate.Items.Add(115200);
            this.cbx_baudRate.SelectedIndex = 0;

            //校验位
            this.cbx_parityBit.Items.Add("无校验");
            this.cbx_parityBit.Items.Add("奇校验");
            this.cbx_parityBit.Items.Add("偶校验");
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
        }

        private InspectData.PLCRTU InitSerialPortParameter()
        {
            InspectData.PLCRTU pLCRTU = new InspectData.PLCRTU();
            try
            {
                if (cbx_portName.SelectedIndex < 0 || cbx_baudRate.SelectedIndex < 0 || cbx_parityBit.SelectedIndex < 0 || tbx_dataBit.SelectedIndex < 0 || cbx_stopBit.SelectedIndex < 0)
                {
                    MessageBox.Show("请选择串口参数");
                }
                else
                {
                    pLCRTU.PortName = cbx_portName.SelectedItem.ToString();
                    pLCRTU.BaudRate = int.Parse(cbx_baudRate.SelectedItem.ToString());
                    switch (cbx_parityBit.SelectedItem.ToString())
                    {
                        case "奇校验":
                            pLCRTU.parity = Parity.Odd;
                            break;
                        case "偶校验":
                            pLCRTU.parity = Parity.Even;
                            break;
                        case "无校验":
                            pLCRTU.parity = Parity.None;
                            break;
                        default:
                            break;
                    }
                    pLCRTU.DataBits = int.Parse(tbx_dataBit.SelectedItem.ToString());
                    switch (cbx_stopBit.SelectedItem.ToString())
                    {
                        case "1":
                            pLCRTU.stopBits = StopBits.One;
                            break;
                        case "2":
                            pLCRTU.stopBits = StopBits.Two;
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return pLCRTU;
        }

        /// <summary>
        /// 打开或更新串口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_openPort_Click(object sender, EventArgs e)
        {
            if (lbl_statu.Text == "已打开")
            {
                DialogResult dr = MessageBox.Show("串口已打开，是否重新设置？", "提示：", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr != DialogResult.OK)
                {
                    return;
                }
                objMod.ClosePort();
            }
            try
            {
                if (objMod.OpenCom(InitSerialPortParameter()))
                {
                    lbl_statu.Text = "已打开";
                    lbl_statu.ForeColor = Color.Green;
                    MessageBox.Show("重新设置并打开串口成功！");
                }
                else
                {
                    lbl_statu.Text = "未打开";
                    lbl_statu.ForeColor = Color.Red;
                    MessageBox.Show("打开串口失败！");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("打开串口失败！");
                return;
            }
        }

        private void btn_closePort_Click(object sender, EventArgs e)
        {
            objMod.ClosePort();
            lbl_statu.Text = "未打开";
            lbl_statu.ForeColor = Color.Red;
        }

        private void lnk_clear_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.listBox1.Items.Clear();
        }
        /// <summary>
        /// 初始化读参数
        /// </summary>
        private void SetReadParameters()
        {
            try
            {
                if (txt_DecAdd.Text == "" || txt_Address.Text == "" || txt_Length.Text == "")
                {
                    MessageBox.Show("请填写读参数!");
                }
                else
                {
                    slaveAddress = byte.Parse(txt_DecAdd.Text);
                    startAddress = ushort.Parse(txt_Address.Text);
                    numberOfPoints = ushort.Parse(txt_Length.Text);
                }
            }
            catch
            {

            }

        }
        /// <summary>
        /// 初始化写参数
        /// </summary>
        private void SetWriteParametes()
        {
            if (txt_DecAdd.Text == "" || textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("请填写写参数!");
            }
            else
            {
                slaveAddress = byte.Parse(txt_DecAdd.Text);
                startAddress = ushort.Parse(textBox1.Text);
                //转化ushort数组
                string[] strarr = textBox2.Text.Split(' ');
                registerBuffer = new ushort[strarr.Length];
                for (int i = 0; i < strarr.Length; i++)
                {
                    registerBuffer[i] = ushort.Parse(strarr[i]);
                }
            }
        }
        private void btn_ReadReg_Click(object sender, EventArgs e)
        {
            try
            {
                SetReadParameters();
                registerBuffer = objMod.Read_Register("03", slaveAddress, startAddress, numberOfPoints);
                if (registerBuffer != null && registerBuffer.Length > 0)
                {
                    this.listBox1.Items.Clear();
                    for (int i = 0; i < registerBuffer.Length; i++)
                    {
                        this.listBox1.Items.Add(registerBuffer[i].ToString());
                    }
                }
                else
                {
                    this.listBox1.Items.Clear();
                    MessageBox.Show("读取失败");
                }
            }
            catch (SystemException error)
            {
                StaticFun.MessageFun.ShowMessage(error.ToString());
            }

        }
        private void btn_SetSingleReg_Click(object sender, EventArgs e)
        {
            SetWriteParametes();
            objMod.Write_Register("06", slaveAddress, startAddress, registerBuffer);
        }

        private void FormPLCRTU_Load(object sender, EventArgs e)
        {
            try
            {
                string tup_Path = AppDomain.CurrentDomain.BaseDirectory + "PLC(RTU).json";
                string strData = System.IO.File.ReadAllText(tup_Path);
                var DynamicObject = JsonConvert.DeserializeObject<InspectData.PLCRTU[]>(strData);
                InspectData.PLCRTU pLCRTU = new InspectData.PLCRTU();
                pLCRTU = DynamicObject[0];
                cbx_baudRate.Text = pLCRTU.BaudRate.ToString();
                cbx_portName.Text = pLCRTU.PortName;
                tbx_dataBit.Text = pLCRTU.DataBits.ToString();
                if (Parity.None == pLCRTU.parity)
                {
                    cbx_parityBit.Text = "无校验";
                }
                else if (Parity.Odd == pLCRTU.parity)
                {
                    cbx_parityBit.Text = "奇校验";
                }
                else if (Parity.Even == pLCRTU.parity)
                {
                    cbx_parityBit.Text = "偶校验";
                }
                if (StopBits.One == pLCRTU.stopBits)
                {
                    cbx_stopBit.Text = "1";
                }
                else if (StopBits.Two == pLCRTU.stopBits)
                {
                    cbx_stopBit.Text = "2";
                }
                txt_DecAdd.Text = pLCRTU.slaveAddress.ToString();
            }
            catch (Exception)
            {
                return;
            }
        }


        private void btn_Save_Click(object sender, EventArgs e)
        {
            int iparity = 0;
            if (this.cbx_parityBit.Text == "无校验")
            {
                iparity = (int)Parity.None;
            }
            else if (this.cbx_parityBit.Text == "奇校验")
            {
                iparity = (int)Parity.Odd;
            }
            else if (this.cbx_parityBit.Text == "偶校验")
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
            try
            {
                InspectData.PLCRTU pLCRTU = new InspectData.PLCRTU()
                {
                    BaudRate = int.Parse(cbx_baudRate.Text),
                    PortName = cbx_portName.Text,
                    DataBits = int.Parse(tbx_dataBit.Text),
                    parity = (Parity)iparity,
                    stopBits = (StopBits)iStopBits,
                    slaveAddress = byte.Parse(txt_DecAdd.Text)
                };
                Button button = (Button)sender;
                switch (button.Name)
                {
                    case "btn_Save_qian":
                        DataSerializer._PlcRTU.PlcRTU[0] = pLCRTU;
                        break;
                    case "btn_Save_hou":
                        DataSerializer._PlcRTU.PlcRTU[1] = pLCRTU;
                        break;
                    default:
                        break;
                }
                //导入序列化参数
                var json = JsonConvert.SerializeObject(DataSerializer._PlcRTU.PlcRTU);
                string tup_Path = System.AppDomain.CurrentDomain.BaseDirectory + "PLC(RTU).json";
                System.IO.File.WriteAllText(tup_Path, json);
                MessageBox.Show("保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SystemException error)
            {
                MessageBox.Show("保存失败！");
                StaticFun.MessageFun.ShowMessage(error.ToString());
            }
        }
    }
}

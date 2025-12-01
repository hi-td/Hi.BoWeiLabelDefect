using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WENYU_IO;
using System.Threading;
using VisionPlatform;

namespace hzjd_modbusRTU
{
    public partial class FormModbusIO : Form
    {
        private int com;
        public FormModbusIO(int _com)
        {
            InitializeComponent();
            com = _com;
        }

        private void FormModbusIO_Load(object sender, EventArgs e)
        {
            int Result = 0;
            if (!WENYU.isOpen)
            {
                WENYU.SearchIO();
            }
            string IO_BAND_string = "9600";
            if (WENYU_IO.hzjd_modbusRTU.IO_BANDRate == 0) IO_BAND_string = "9600";
            else if (WENYU_IO.hzjd_modbusRTU.IO_BANDRate == 1) IO_BAND_string = "19200";
            else if (WENYU_IO.hzjd_modbusRTU.IO_BANDRate == 2) IO_BAND_string = "38400";
            else if (WENYU_IO.hzjd_modbusRTU.IO_BANDRate == 3) IO_BAND_string = "57600";
            else if (WENYU_IO.hzjd_modbusRTU.IO_BANDRate == 4) IO_BAND_string = "115200";
            else
            {
                IO_BAND_string = "9600";
                WENYU_IO.hzjd_modbusRTU.IO_BANDRate = 0;
            }
            string IO_PARITYBit_str = "";
            if (WENYU_IO.hzjd_modbusRTU.IO_PARITYBit == WENYU_IO.hzjd_modbusRTU.NONE_PARITY)
            { IO_PARITYBit_str = "NONE"; }
            else if (WENYU_IO.hzjd_modbusRTU.IO_PARITYBit == WENYU_IO.hzjd_modbusRTU.ODD_PARITY)
            { IO_PARITYBit_str = "ODD"; }
            else if (WENYU_IO.hzjd_modbusRTU.IO_PARITYBit == WENYU_IO.hzjd_modbusRTU.EVEN_PARITY)
            { IO_PARITYBit_str = "EVEN"; }
            else if (WENYU_IO.hzjd_modbusRTU.IO_PARITYBit == WENYU_IO.hzjd_modbusRTU.MARK_PARITY)
            { IO_PARITYBit_str = "MARK"; }
            else if (WENYU_IO.hzjd_modbusRTU.IO_PARITYBit == WENYU_IO.hzjd_modbusRTU.SPACE_PARITY)
            { IO_PARITYBit_str = "SPACE"; }//技鼎科技
            this.Text = "串口IO控制器DEMO程序 " +
                        "(COM" + (WENYU_IO.hzjd_modbusRTU.IO_COM_Number + 1).ToString() +
                        "," + IO_BAND_string + "," +
                        IO_PARITYBit_str + ",8,1)  Address=" + WENYU_IO.hzjd_modbusRTU.IO_Address.ToString();

            this.comboBox2.Items.Clear();
            this.comboBox2.Items.Add("9600");
            this.comboBox2.Items.Add("19200");
            this.comboBox2.Items.Add("38400");
            this.comboBox2.Items.Add("57600");
            this.comboBox2.Items.Add("115200");
            this.comboBox2.SelectedIndex= WENYU_IO.hzjd_modbusRTU.IO_BANDRate;

            this.comboBox3.Items.Clear();
            this.comboBox3.Items.Add("NONE_PARITY");
            this.comboBox3.Items.Add("ODD_PARITY");
            this.comboBox3.Items.Add("EVEN_PARITY");
            this.comboBox3.Items.Add("MARK_PARITY");
            this.comboBox3.Items.Add("SPACE_PARITY");
            this.comboBox3.SelectedIndex = WENYU_IO.hzjd_modbusRTU.IO_PARITYBit;

            this.comboBox4.Items.Clear();
            for (int i = 1; i < 256; i++) this.comboBox4.Items.Add(i.ToString());
            this.comboBox4.SelectedIndex = WENYU_IO.hzjd_modbusRTU.IO_Address-1;
            for (byte j = 0; j < 12; j++)
            {
                Result = WENYU_IO.hzjd_modbusRTU.JD_SetOutPortFunction(WENYU_IO.hzjd_modbusRTU.DevCOM,
                    WENYU_IO.hzjd_modbusRTU.IO_Address, j, 0, 100);
                if (Result != 0)
                {
                    MessageBox.Show("通讯异常！退出系统！");
                    Environment.Exit(0);
                    return;
                }
            }
            textBox1.Text = "100";
            textBox2.Text = "100";
            textBox3.Text = "100";
            textBox4.Text = "100";
            textBox5.Text = "100";
            textBox6.Text = "100";
            textBox7.Text = "100";
            textBox8.Text = "100";
            textBox9.Text = "100";
            textBox10.Text = "100";
            textBox11.Text = "100";
            textBox12.Text = "100";
            radio1_out0.Checked = true;
            radio1_out1.Checked = true;
            radio1_out2.Checked = true;
            radio1_out3.Checked = true;
            radio1_out4.Checked = true;
            radio1_out5.Checked = true;
            radio1_out6.Checked = true;
            radio1_out7.Checked = true;
            radio1_out8.Checked = true;
            radio1_out9.Checked = true;
            radio1_out10.Checked = true;
            radio1_out11.Checked = true;
            timer1.Interval = 20;
            timer1.Enabled = true;
            timer1.Start();
        }
        private void FormModbusIO_FormClosing(object sender, FormClosingEventArgs e)
        {
            WENYU.CloseIO();
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            int result = 0;
            UInt16 value = 0;
            int bit_value=0;
            result = WENYU_IO.hzjd_modbusRTU.DJ_ReadInputPortData(WENYU_IO.hzjd_modbusRTU.DevCOM, WENYU_IO.hzjd_modbusRTU.IO_Address, ref value);
           if (result == 0) this.label26.Text = "输入数据为：" + value.ToString();
           else goto Error;
          
           result = WENYU_IO.hzjd_modbusRTU.DJ_ReadInputBit(WENYU_IO.hzjd_modbusRTU.DevCOM, WENYU_IO.hzjd_modbusRTU.IO_Address, 0,ref bit_value);
           if (result != 0) goto Error;
           if (bit_value == 0x01) this.InputPort0.Checked  = true;
           else this.InputPort0.Checked = false;



           if ((value & 0x02) == 0x02) this.InputPort1.Checked = true;
           else this.InputPort1.Checked = false;

           if ((value & 0x04) == 0x04) this.InputPort2.Checked = true;
           else this.InputPort2.Checked = false;

           if ((value & 0x08) == 0x08) this.InputPort3.Checked = true;
           else this.InputPort3.Checked = false;

           if ((value & 0x10) == 0x10) this.InputPort4.Checked = true;
           else this.InputPort4.Checked = false;

           if ((value & 0x20) == 0x20) this.InputPort5.Checked = true;
           else this.InputPort5.Checked = false;

           if ((value & 0x40) == 0x40) this.InputPort6.Checked = true;
           else this.InputPort6.Checked = false;

           if ((value & 0x80) == 0x80) this.InputPort7.Checked = true;
           else this.InputPort7.Checked = false;

           if ((value & 0x100) == 0x100) this.InputPort8.Checked = true;
           else this.InputPort8.Checked = false;

           if ((value & 0x200) == 0x200) this.InputPort9.Checked = true;
           else this.InputPort9.Checked = false;

           if ((value & 0x400) == 0x400) this.InputPort10.Checked = true;
           else this.InputPort10.Checked = false;

           if ((value & 0x800) == 0x800) this.InputPort11.Checked = true;
           else this.InputPort11.Checked = false;
           
           

            result = WENYU_IO.hzjd_modbusRTU.JD_ReadOutputData(WENYU_IO.hzjd_modbusRTU.DevCOM, WENYU_IO.hzjd_modbusRTU.IO_Address, ref value);
            this.label27.Text = "输出数据为：" + value.ToString();
            if (result == 0)
            {
                if ((value & 0x01) == 0x01) this.OutPort0.Checked = true;
                else this.OutPort0.Checked = false;

                if ((value & 0x02) == 0x02) this.OutPort1.Checked = true;
                else this.OutPort1.Checked = false;

                if ((value & 0x04) == 0x04) this.OutPort2.Checked = true;
                else this.OutPort2.Checked = false;

                if ((value & 0x08) == 0x08) this.OutPort3.Checked = true;
                else this.OutPort3.Checked = false;

                if ((value & 0x10) == 0x10) this.OutPort4.Checked = true;
                else this.OutPort4.Checked = false;

                if ((value & 0x20) == 0x20) this.OutPort5.Checked = true;
                else this.OutPort5.Checked = false;

                if ((value & 0x40) == 0x40) this.OutPort6.Checked = true;
                else this.OutPort6.Checked = false;

                if ((value & 0x80) == 0x80) this.OutPort7.Checked = true;
                else this.OutPort7.Checked = false;

                if ((value & 0x100) == 0x100) this.OutPort8.Checked = true;
                else this.OutPort8.Checked = false;

                if ((value & 0x200) == 0x200) this.OutPort9.Checked = true;
                else this.OutPort9.Checked = false;

                if ((value & 0x400) == 0x400) this.OutPort10.Checked = true;
                else this.OutPort10.Checked = false;

                if ((value & 0x800) == 0x800) this.OutPort11.Checked = true;
                else this.OutPort11.Checked = false;
            }
            else goto Error;
           
            return;
            Error:
            MessageBox.Show("通讯异常！退出系统！");
            Environment.Exit(0);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            UInt16 OutPutData = 0;
            bool Result = UInt16.TryParse(this.OutPutData.Text, out OutPutData);
            if (!Result)
            {
                MessageBox.Show("输入框中不是一个有效的数字，请重新输入0~65535之间的数字！");
                return;
            }
            int rtn= WENYU_IO.hzjd_modbusRTU.DJ_SetOutputPortData(WENYU_IO.hzjd_modbusRTU.DevCOM, WENYU_IO.hzjd_modbusRTU.IO_Address, OutPutData);
            if (rtn == 0)  MessageBox.Show("输出数据写入成功！");
            else MessageBox.Show("输出数据写入失败！");
        }
        private void button5_Click(object sender, EventArgs e)
        {
            int Result = 0;
            UInt16 ReverseTime = 0;
            bool rtn = false;

            if (radio1_out2.Checked)
            {
                Result = WENYU_IO.hzjd_modbusRTU.JD_SetOutPortFunction(
                WENYU_IO.hzjd_modbusRTU.DevCOM, WENYU_IO.hzjd_modbusRTU.IO_Address, 2, 0, 0);
            }
            else if (radio2_out2.Checked)
            {
                rtn = UInt16.TryParse(textBox3.Text, out ReverseTime);
                if (rtn == false)
                {
                    MessageBox.Show("翻转定时参数输入框中为无效参数，请重新输入！");
                    return;
                }
                Result = WENYU_IO.hzjd_modbusRTU.JD_SetOutPortFunction(
                WENYU_IO.hzjd_modbusRTU.DevCOM, WENYU_IO.hzjd_modbusRTU.IO_Address,2, 1, ReverseTime);
            }
            else if (radio3_out2.Checked)
            {
                rtn = UInt16.TryParse(textBox3.Text, out ReverseTime);
                if (rtn == false)
                {
                    MessageBox.Show("翻转定时参数输入框中为无效参数，请重新输入！");
                    return;
                }
                Result = WENYU_IO.hzjd_modbusRTU.JD_SetOutPortFunction(
                WENYU_IO.hzjd_modbusRTU.DevCOM, WENYU_IO.hzjd_modbusRTU.IO_Address, 2, 2, ReverseTime);
            }
            else
            {
                Result = WENYU_IO.hzjd_modbusRTU.JD_SetOutPortFunction(
                WENYU_IO.hzjd_modbusRTU.DevCOM, WENYU_IO.hzjd_modbusRTU.IO_Address, 2, 0, 0);
            }
            if (Result != 0) MessageBox.Show("通讯异常！");
        }
        private void button6_Click(object sender, EventArgs e)
        {
            int Result = 0;
            UInt16 ReverseTime = 0;
            bool rtn = false;
            if (radio1_out3.Checked)
            {
                Result = WENYU_IO.hzjd_modbusRTU.JD_SetOutPortFunction(
                WENYU_IO.hzjd_modbusRTU.DevCOM, WENYU_IO.hzjd_modbusRTU.IO_Address, 3, 0, 0);
            }
            else if (radio2_out3.Checked)
            {
                rtn = UInt16.TryParse(textBox4.Text, out ReverseTime);
                if (rtn == false)
                {
                    MessageBox.Show("翻转定时参数输入框中为无效参数，请重新输入！");
                    return;
                }
                Result = WENYU_IO.hzjd_modbusRTU.JD_SetOutPortFunction(
                WENYU_IO.hzjd_modbusRTU.DevCOM, WENYU_IO.hzjd_modbusRTU.IO_Address, 3, 1, ReverseTime);
            }
            else if (radio3_out3.Checked)
            {
                rtn = UInt16.TryParse(textBox4.Text, out ReverseTime);
                if (rtn == false)
                {
                    MessageBox.Show("翻转定时参数输入框中为无效参数，请重新输入！");
                    return;
                }
                Result = WENYU_IO.hzjd_modbusRTU.JD_SetOutPortFunction(
                WENYU_IO.hzjd_modbusRTU.DevCOM, WENYU_IO.hzjd_modbusRTU.IO_Address, 3, 2, ReverseTime);
            }
            else
            {
                Result = WENYU_IO.hzjd_modbusRTU.JD_SetOutPortFunction(
                WENYU_IO.hzjd_modbusRTU.DevCOM, WENYU_IO.hzjd_modbusRTU.IO_Address, 3, 0, 0);
            }
            if (Result != 0) MessageBox.Show("通讯异常！");
          
        }

        private void OutPort0_ON_Click(object sender, EventArgs e)
        {
          if (WENYU_IO.hzjd_modbusRTU.JD_SetOutBit0(WENYU_IO.hzjd_modbusRTU.DevCOM, WENYU_IO.hzjd_modbusRTU.IO_Address,1) != 0) 
              MessageBox.Show("ModbusRTU异常！");
        }

        private void OutPort1_ON_Click(object sender, EventArgs e)
        {
            if (WENYU_IO.hzjd_modbusRTU.JD_SetOutBit1(WENYU_IO.hzjd_modbusRTU.DevCOM, WENYU_IO.hzjd_modbusRTU.IO_Address, 1) != 0)
                MessageBox.Show("ModbusRTU异常！");
        }

        private void OutPort2_ON_Click(object sender, EventArgs e)
        {
            if (WENYU_IO.hzjd_modbusRTU.JD_SetOutBit2(WENYU_IO.hzjd_modbusRTU.DevCOM, WENYU_IO.hzjd_modbusRTU.IO_Address,  1) != 0)
                MessageBox.Show("ModbusRTU异常！");
        }

        private void OutPort3_ON_Click(object sender, EventArgs e)
        {
            if (WENYU_IO.hzjd_modbusRTU.JD_SetOutBit3(WENYU_IO.hzjd_modbusRTU.DevCOM, WENYU_IO.hzjd_modbusRTU.IO_Address,  1) != 0)
                MessageBox.Show("ModbusRTU异常！");
        }

        private void OutPort4_ON_Click(object sender, EventArgs e)
        {
            if (WENYU_IO.hzjd_modbusRTU.JD_SetOutBit4(WENYU_IO.hzjd_modbusRTU.DevCOM, WENYU_IO.hzjd_modbusRTU.IO_Address, 1) != 0)
                MessageBox.Show("ModbusRTU异常！");
        }

        private void OutPort5_ON_Click(object sender, EventArgs e)
        {
            if (WENYU_IO.hzjd_modbusRTU.JD_SetOutBit5(WENYU_IO.hzjd_modbusRTU.DevCOM, WENYU_IO.hzjd_modbusRTU.IO_Address,  1) != 0)
                MessageBox.Show("ModbusRTU异常！");
        }

        private void OutPort6_ON_Click(object sender, EventArgs e)
        {
            if (WENYU_IO.hzjd_modbusRTU.JD_SetOutBit6(WENYU_IO.hzjd_modbusRTU.DevCOM, WENYU_IO.hzjd_modbusRTU.IO_Address, 1) != 0)
                MessageBox.Show("ModbusRTU异常！");
        }

        private void OutPort7_ON_Click(object sender, EventArgs e)
        {
            if (WENYU_IO.hzjd_modbusRTU.JD_SetOutBit7(WENYU_IO.hzjd_modbusRTU.DevCOM, WENYU_IO.hzjd_modbusRTU.IO_Address,  1) != 0)
                MessageBox.Show("ModbusRTU异常！");
        }

        private void OutPort8_ON_Click(object sender, EventArgs e)
        {
            if (WENYU_IO.hzjd_modbusRTU.JD_SetOutBit8(WENYU_IO.hzjd_modbusRTU.DevCOM, WENYU_IO.hzjd_modbusRTU.IO_Address,  1) != 0)
                MessageBox.Show("ModbusRTU异常！");
        }

        private void OutPort9_ON_Click(object sender, EventArgs e)
        {
            if (WENYU_IO.hzjd_modbusRTU.JD_SetOutBit9(WENYU_IO.hzjd_modbusRTU.DevCOM, WENYU_IO.hzjd_modbusRTU.IO_Address, 1) != 0)
                MessageBox.Show("ModbusRTU异常！");
        }

        private void OutPort10_ON_Click(object sender, EventArgs e)
        {
            if (WENYU_IO.hzjd_modbusRTU.JD_SetOutBit10(WENYU_IO.hzjd_modbusRTU.DevCOM, WENYU_IO.hzjd_modbusRTU.IO_Address, 1) != 0)
                MessageBox.Show("ModbusRTU异常！");
        }

        private void OutPort11_ON_Click(object sender, EventArgs e)
        {
            if (WENYU_IO.hzjd_modbusRTU.JD_SetOutBit11(WENYU_IO.hzjd_modbusRTU.DevCOM, WENYU_IO.hzjd_modbusRTU.IO_Address, 1) != 0)
                MessageBox.Show("ModbusRTU异常！");
        }

        private void OutPort0_OFF_Click(object sender, EventArgs e)
        {
            if (WENYU_IO.hzjd_modbusRTU.JD_SetOutBit0(WENYU_IO.hzjd_modbusRTU.DevCOM, WENYU_IO.hzjd_modbusRTU.IO_Address,  0) != 0)
                MessageBox.Show("ModbusRTU异常！");
        }

        private void OutPort1_OFF_Click(object sender, EventArgs e)
        {
            if (WENYU_IO.hzjd_modbusRTU.JD_SetOutBit1(WENYU_IO.hzjd_modbusRTU.DevCOM, WENYU_IO.hzjd_modbusRTU.IO_Address,  0) != 0)
                MessageBox.Show("ModbusRTU异常！");
        }

        private void OutPort2_OFF_Click(object sender, EventArgs e)
        {
            if (WENYU_IO.hzjd_modbusRTU.JD_SetOutBit2(WENYU_IO.hzjd_modbusRTU.DevCOM, WENYU_IO.hzjd_modbusRTU.IO_Address,  0) != 0)
                MessageBox.Show("ModbusRTU异常！");
        }

        private void OutPort3_OFF_Click(object sender, EventArgs e)
        {
            if (WENYU_IO.hzjd_modbusRTU.JD_SetOutBit3(WENYU_IO.hzjd_modbusRTU.DevCOM, WENYU_IO.hzjd_modbusRTU.IO_Address, 0) != 0)
                MessageBox.Show("ModbusRTU异常！");
        }

        private void OutPort4_OFF_Click(object sender, EventArgs e)
        {
            if (WENYU_IO.hzjd_modbusRTU.JD_SetOutBit4(WENYU_IO.hzjd_modbusRTU.DevCOM, WENYU_IO.hzjd_modbusRTU.IO_Address, 0) != 0)
                MessageBox.Show("ModbusRTU异常！");
        }

        private void OutPort5_OFF_Click(object sender, EventArgs e)
        {
            if (WENYU_IO.hzjd_modbusRTU.JD_SetOutBit5(WENYU_IO.hzjd_modbusRTU.DevCOM, WENYU_IO.hzjd_modbusRTU.IO_Address,  0) != 0)
                MessageBox.Show("ModbusRTU异常！");
        }

        private void OutPort6_OFF_Click(object sender, EventArgs e)
        {
            if (WENYU_IO.hzjd_modbusRTU.JD_SetOutBit6(WENYU_IO.hzjd_modbusRTU.DevCOM, WENYU_IO.hzjd_modbusRTU.IO_Address,  0) != 0)
                MessageBox.Show("ModbusRTU异常！");
        }

        private void OutPort7_OFF_Click(object sender, EventArgs e)
        {
            if (WENYU_IO.hzjd_modbusRTU.JD_SetOutBit7(WENYU_IO.hzjd_modbusRTU.DevCOM, WENYU_IO.hzjd_modbusRTU.IO_Address,  0) != 0)
                MessageBox.Show("ModbusRTU异常！");
        }

        private void OutPort8_OFF_Click(object sender, EventArgs e)
        {
            if (WENYU_IO.hzjd_modbusRTU.JD_SetOutBit8(WENYU_IO.hzjd_modbusRTU.DevCOM, WENYU_IO.hzjd_modbusRTU.IO_Address, 0) != 0)
                MessageBox.Show("ModbusRTU异常！");
        }

        private void OutPort9_OFF_Click(object sender, EventArgs e)
        {
            if (WENYU_IO.hzjd_modbusRTU.JD_SetOutBit9(WENYU_IO.hzjd_modbusRTU.DevCOM, WENYU_IO.hzjd_modbusRTU.IO_Address,  0) != 0)
                MessageBox.Show("ModbusRTU异常！");
        }

        private void OutPort10_OFF_Click(object sender, EventArgs e)
        {
            if (WENYU_IO.hzjd_modbusRTU.JD_SetOutBit10(WENYU_IO.hzjd_modbusRTU.DevCOM, WENYU_IO.hzjd_modbusRTU.IO_Address, 0) != 0)
                MessageBox.Show("ModbusRTU异常！");
        }

        private void OutPort11_OFF_Click(object sender, EventArgs e)
        {
            if (WENYU_IO.hzjd_modbusRTU.JD_SetOutBit11(WENYU_IO.hzjd_modbusRTU.DevCOM, WENYU_IO.hzjd_modbusRTU.IO_Address, 0) != 0)
                MessageBox.Show("ModbusRTU异常！");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            byte SetIO_Addr = 0, SetIO_NONE_PARITY = 0, SetIO_BANDRate = 0;
            SetIO_Addr = (byte)this.comboBox4.FindString(comboBox4.Text);
            SetIO_Addr++;
            SetIO_NONE_PARITY = WENYU_IO.hzjd_modbusRTU.NONE_PARITY;
            SetIO_BANDRate = (byte)this.comboBox2.FindString(comboBox2.Text);

            DialogResult Result= MessageBox.Show("确定更改IO控制器的通讯参数码？", "提示", MessageBoxButtons.OKCancel);
            if (Result == DialogResult.Cancel) return;
            int rtn = WENYU_IO.hzjd_modbusRTU.JD_SetIOControllerParam(WENYU_IO.hzjd_modbusRTU.DevCOM, SetIO_Addr, SetIO_NONE_PARITY, SetIO_BANDRate);
            if (rtn != 0) MessageBox.Show("IO控制器参数写入失败！");
            MessageBox.Show("IO控制器参数写入成功！请关掉IO控制器电源后重起生效！同时该程序也重启！");
        }
        private void button4_Click_1(object sender, EventArgs e)
        {
            int Result=0;
            UInt16 ReverseTime=0;
            bool rtn = false;
           
            if (radio1_out0.Checked)
            {
                Result = WENYU_IO.hzjd_modbusRTU.JD_SetOutPortFunction(
                WENYU_IO.hzjd_modbusRTU.DevCOM, WENYU_IO.hzjd_modbusRTU.IO_Address,0, 0, 0);
            }
            else if (radio2_out0.Checked)
            {
                rtn = UInt16.TryParse(textBox1.Text, out ReverseTime);
                if (rtn == false)
                {
                    MessageBox.Show("翻转定时参数输入框中为无效参数，请重新输入！");
                    return;
                }
                Result = WENYU_IO.hzjd_modbusRTU.JD_SetOutPortFunction(
                WENYU_IO.hzjd_modbusRTU.DevCOM, WENYU_IO.hzjd_modbusRTU.IO_Address, 0, 1,ReverseTime);
            }
            else if (radio3_out0.Checked)
            {
                rtn = UInt16.TryParse(textBox1.Text, out ReverseTime);
                if (rtn == false)
                {
                    MessageBox.Show("翻转定时参数输入框中为无效参数，请重新输入！");
                    return;
                }
                Result = WENYU_IO.hzjd_modbusRTU.JD_SetOutPortFunction(
                WENYU_IO.hzjd_modbusRTU.DevCOM, WENYU_IO.hzjd_modbusRTU.IO_Address, 0, 2, ReverseTime);
            }
            else
            {
                Result = WENYU_IO.hzjd_modbusRTU.JD_SetOutPortFunction(
                WENYU_IO.hzjd_modbusRTU.DevCOM, WENYU_IO.hzjd_modbusRTU.IO_Address, 0, 0, 0);
            }
            if (Result != 0) MessageBox.Show("通讯异常！");
        }
        private void button2_Click(object sender, EventArgs e)
        {
            int Result = 0;
            UInt16 ReverseTime = 0;
            bool rtn = false;

            if (radio1_out1.Checked)
            {
                Result = WENYU_IO.hzjd_modbusRTU.JD_SetOutPortFunction(
                WENYU_IO.hzjd_modbusRTU.DevCOM, WENYU_IO.hzjd_modbusRTU.IO_Address, 1, 0, 0);
            }
            else if (radio2_out1.Checked)
            {
                rtn = UInt16.TryParse(textBox2.Text, out ReverseTime);
                if (rtn == false)
                {
                    MessageBox.Show("翻转定时参数输入框中为无效参数，请重新输入！");
                    return;
                }
                Result = WENYU_IO.hzjd_modbusRTU.JD_SetOutPortFunction(
                WENYU_IO.hzjd_modbusRTU.DevCOM, WENYU_IO.hzjd_modbusRTU.IO_Address, 1, 1, ReverseTime);
            }
            else if (radio3_out1.Checked)
            {
                rtn = UInt16.TryParse(textBox2.Text, out ReverseTime);
                if (rtn == false)
                {
                    MessageBox.Show("翻转定时参数输入框中为无效参数，请重新输入！");
                    return;
                }
                Result = WENYU_IO.hzjd_modbusRTU.JD_SetOutPortFunction(
                WENYU_IO.hzjd_modbusRTU.DevCOM, WENYU_IO.hzjd_modbusRTU.IO_Address, 1, 2, ReverseTime);
            }
            else
            {
                Result = WENYU_IO.hzjd_modbusRTU.JD_SetOutPortFunction(
                WENYU_IO.hzjd_modbusRTU.DevCOM, WENYU_IO.hzjd_modbusRTU.IO_Address, 1, 0, 0);
            }
            if (Result != 0) MessageBox.Show("通讯异常！");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int Result = 0;
            UInt16 ReverseTime = 0;
            bool rtn = false;

            if (radio1_out4.Checked)
            {
                Result = WENYU_IO.hzjd_modbusRTU.JD_SetOutPortFunction(
                WENYU_IO.hzjd_modbusRTU.DevCOM, WENYU_IO.hzjd_modbusRTU.IO_Address, 4, 0, 0);
            }
            else if (radio2_out4.Checked)
            {
                rtn = UInt16.TryParse(textBox5.Text, out ReverseTime);
                if (rtn == false)
                {
                    MessageBox.Show("翻转定时参数输入框中为无效参数，请重新输入！");
                    return;
                }
                Result = WENYU_IO.hzjd_modbusRTU.JD_SetOutPortFunction(
                WENYU_IO.hzjd_modbusRTU.DevCOM, WENYU_IO.hzjd_modbusRTU.IO_Address, 4, 1, ReverseTime);
            }
            else if (radio3_out4.Checked)
            {
                rtn = UInt16.TryParse(textBox5.Text, out ReverseTime);
                if (rtn == false)
                {
                    MessageBox.Show("翻转定时参数输入框中为无效参数，请重新输入！");
                    return;
                }
                Result = WENYU_IO.hzjd_modbusRTU.JD_SetOutPortFunction(
                WENYU_IO.hzjd_modbusRTU.DevCOM, WENYU_IO.hzjd_modbusRTU.IO_Address, 4, 2, ReverseTime);
            }
            else
            {
                Result = WENYU_IO.hzjd_modbusRTU.JD_SetOutPortFunction(
                WENYU_IO.hzjd_modbusRTU.DevCOM, WENYU_IO.hzjd_modbusRTU.IO_Address, 4, 0, 0);
            }
            if (Result != 0) MessageBox.Show("通讯异常！");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            int Result = 0;
            UInt16 ReverseTime = 0;
            bool rtn = false;

            if (radio1_out5.Checked)
            {
                Result = WENYU_IO.hzjd_modbusRTU.JD_SetOutPortFunction(
                WENYU_IO.hzjd_modbusRTU.DevCOM, WENYU_IO.hzjd_modbusRTU.IO_Address, 5, 0, 0);
            }
            else if (radio2_out5.Checked)
            {
                rtn = UInt16.TryParse(textBox6.Text, out ReverseTime);
                if (rtn == false)
                {
                    MessageBox.Show("翻转定时参数输入框中为无效参数，请重新输入！");
                    return;
                }
                Result = WENYU_IO.hzjd_modbusRTU.JD_SetOutPortFunction(
                WENYU_IO.hzjd_modbusRTU.DevCOM, WENYU_IO.hzjd_modbusRTU.IO_Address, 5, 1, ReverseTime);
            }
            else if (radio3_out5.Checked)
            {
                rtn = UInt16.TryParse(textBox6.Text, out ReverseTime);
                if (rtn == false)
                {
                    MessageBox.Show("翻转定时参数输入框中为无效参数，请重新输入！");
                    return;
                }
                Result = WENYU_IO.hzjd_modbusRTU.JD_SetOutPortFunction(
                WENYU_IO.hzjd_modbusRTU.DevCOM, WENYU_IO.hzjd_modbusRTU.IO_Address, 5, 2, ReverseTime);
            }
            else
            {
                Result = WENYU_IO.hzjd_modbusRTU.JD_SetOutPortFunction(
                WENYU_IO.hzjd_modbusRTU.DevCOM, WENYU_IO.hzjd_modbusRTU.IO_Address, 5, 0, 0);
            }
            if (Result != 0) MessageBox.Show("通讯异常！");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            int Result = 0;
            UInt16 ReverseTime = 0;
            bool rtn = false;

            if (radio1_out6.Checked)
            {
                Result = WENYU_IO.hzjd_modbusRTU.JD_SetOutPortFunction(
                WENYU_IO.hzjd_modbusRTU.DevCOM, WENYU_IO.hzjd_modbusRTU.IO_Address, 6, 0, 0);
            }
            else if (radio2_out6.Checked)
            {
                rtn = UInt16.TryParse(textBox7.Text, out ReverseTime);
                if (rtn == false)
                {
                    MessageBox.Show("翻转定时参数输入框中为无效参数，请重新输入！");
                    return;
                }
                Result = WENYU_IO.hzjd_modbusRTU.JD_SetOutPortFunction(
                WENYU_IO.hzjd_modbusRTU.DevCOM, WENYU_IO.hzjd_modbusRTU.IO_Address, 6, 1, ReverseTime);
            }
            else if (radio3_out6.Checked)
            {
                rtn = UInt16.TryParse(textBox7.Text, out ReverseTime);
                if (rtn == false)
                {
                    MessageBox.Show("翻转定时参数输入框中为无效参数，请重新输入！");
                    return;
                }
                Result = WENYU_IO.hzjd_modbusRTU.JD_SetOutPortFunction(
                WENYU_IO.hzjd_modbusRTU.DevCOM, WENYU_IO.hzjd_modbusRTU.IO_Address, 6, 2, ReverseTime);
            }
            else
            {
                Result = WENYU_IO.hzjd_modbusRTU.JD_SetOutPortFunction(
                WENYU_IO.hzjd_modbusRTU.DevCOM, WENYU_IO.hzjd_modbusRTU.IO_Address, 6, 0, 0);
            }
            if (Result != 0) MessageBox.Show("通讯异常！");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            int Result = 0;
            UInt16 ReverseTime = 0;
            bool rtn = false;

            if (radio1_out7.Checked)
            {
                Result = WENYU_IO.hzjd_modbusRTU.JD_SetOutPortFunction(
                WENYU_IO.hzjd_modbusRTU.DevCOM, WENYU_IO.hzjd_modbusRTU.IO_Address, 7, 0, 0);
            }
            else if (radio2_out7.Checked)
            {
                rtn = UInt16.TryParse(textBox8.Text, out ReverseTime);
                if (rtn == false)
                {
                    MessageBox.Show("翻转定时参数输入框中为无效参数，请重新输入！");
                    return;
                }
                Result = WENYU_IO.hzjd_modbusRTU.JD_SetOutPortFunction(
                WENYU_IO.hzjd_modbusRTU.DevCOM, WENYU_IO.hzjd_modbusRTU.IO_Address, 7, 1, ReverseTime);
            }
            else if (radio3_out7.Checked)
            {
                rtn = UInt16.TryParse(textBox8.Text, out ReverseTime);
                if (rtn == false)
                {
                    MessageBox.Show("翻转定时参数输入框中为无效参数，请重新输入！");
                    return;
                }
                Result = WENYU_IO.hzjd_modbusRTU.JD_SetOutPortFunction(
                WENYU_IO.hzjd_modbusRTU.DevCOM, WENYU_IO.hzjd_modbusRTU.IO_Address, 7, 2, ReverseTime);
            }
            else
            {
                Result = WENYU_IO.hzjd_modbusRTU.JD_SetOutPortFunction(
                WENYU_IO.hzjd_modbusRTU.DevCOM, WENYU_IO.hzjd_modbusRTU.IO_Address, 7, 0, 0);
            }
            if (Result != 0) MessageBox.Show("通讯异常！");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            int Result = 0;
            UInt16 ReverseTime = 0;
            bool rtn = false;

            if (radio1_out8.Checked)
            {
                Result = WENYU_IO.hzjd_modbusRTU.JD_SetOutPortFunction(
                WENYU_IO.hzjd_modbusRTU.DevCOM, WENYU_IO.hzjd_modbusRTU.IO_Address, 8, 0, 0);
            }
            else if (radio2_out8.Checked)
            {
                rtn = UInt16.TryParse(textBox9.Text, out ReverseTime);
                if (rtn == false)
                {
                    MessageBox.Show("翻转定时参数输入框中为无效参数，请重新输入！");
                    return;
                }
                Result = WENYU_IO.hzjd_modbusRTU.JD_SetOutPortFunction(
                WENYU_IO.hzjd_modbusRTU.DevCOM, WENYU_IO.hzjd_modbusRTU.IO_Address, 8, 1, ReverseTime);
            }
            else if (radio3_out8.Checked)
            {
                rtn = UInt16.TryParse(textBox9.Text, out ReverseTime);
                if (rtn == false)
                {
                    MessageBox.Show("翻转定时参数输入框中为无效参数，请重新输入！");
                    return;
                }
                Result = WENYU_IO.hzjd_modbusRTU.JD_SetOutPortFunction(
                WENYU_IO.hzjd_modbusRTU.DevCOM, WENYU_IO.hzjd_modbusRTU.IO_Address, 8, 2, ReverseTime);
            }
            else
            {
                Result = WENYU_IO.hzjd_modbusRTU.JD_SetOutPortFunction(
                WENYU_IO.hzjd_modbusRTU.DevCOM, WENYU_IO.hzjd_modbusRTU.IO_Address, 8, 0, 0);
            }
            if (Result != 0) MessageBox.Show("通讯异常！");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            int Result = 0;
            UInt16 ReverseTime = 0;
            bool rtn = false;

            if (radio1_out9.Checked)
            {
                Result = WENYU_IO.hzjd_modbusRTU.JD_SetOutPortFunction(
                WENYU_IO.hzjd_modbusRTU.DevCOM, WENYU_IO.hzjd_modbusRTU.IO_Address, 9, 0, 0);
            }
            else if (radio2_out9.Checked)
            {
                rtn = UInt16.TryParse(textBox10.Text, out ReverseTime);
                if (rtn == false)
                {
                    MessageBox.Show("翻转定时参数输入框中为无效参数，请重新输入！");
                    return;
                }
                Result = WENYU_IO.hzjd_modbusRTU.JD_SetOutPortFunction(
                WENYU_IO.hzjd_modbusRTU.DevCOM, WENYU_IO.hzjd_modbusRTU.IO_Address, 9, 1, ReverseTime);
            }
            else if (radio3_out9.Checked)
            {
                rtn = UInt16.TryParse(textBox10.Text, out ReverseTime);
                if (rtn == false)
                {
                    MessageBox.Show("翻转定时参数输入框中为无效参数，请重新输入！");
                    return;
                }
                Result = WENYU_IO.hzjd_modbusRTU.JD_SetOutPortFunction(
                WENYU_IO.hzjd_modbusRTU.DevCOM, WENYU_IO.hzjd_modbusRTU.IO_Address, 9, 2, ReverseTime);
            }
            else
            {
                Result = WENYU_IO.hzjd_modbusRTU.JD_SetOutPortFunction(
                WENYU_IO.hzjd_modbusRTU.DevCOM, WENYU_IO.hzjd_modbusRTU.IO_Address, 9, 0, 0);
            }
            if (Result != 0) MessageBox.Show("通讯异常！");
        }

        private void button13_Click(object sender, EventArgs e)
        {
            int Result = 0;
            UInt16 ReverseTime = 0;
            bool rtn = false;

            if (radio1_out10.Checked)
            {
                Result = WENYU_IO.hzjd_modbusRTU.JD_SetOutPortFunction(
                WENYU_IO.hzjd_modbusRTU.DevCOM, WENYU_IO.hzjd_modbusRTU.IO_Address, 10, 0, 0);
            }
            else if (radio2_out10.Checked)
            {
                rtn = UInt16.TryParse(textBox11.Text, out ReverseTime);
                if (rtn == false)
                {
                    MessageBox.Show("翻转定时参数输入框中为无效参数，请重新输入！");
                    return;
                }
                Result = WENYU_IO.hzjd_modbusRTU.JD_SetOutPortFunction(
                WENYU_IO.hzjd_modbusRTU.DevCOM, WENYU_IO.hzjd_modbusRTU.IO_Address, 10, 1, ReverseTime);
            }
            else if (radio3_out10.Checked)
            {
                rtn = UInt16.TryParse(textBox11.Text, out ReverseTime);
                if (rtn == false)
                {
                    MessageBox.Show("翻转定时参数输入框中为无效参数，请重新输入！");
                    return;
                }
                Result = WENYU_IO.hzjd_modbusRTU.JD_SetOutPortFunction(
                WENYU_IO.hzjd_modbusRTU.DevCOM, WENYU_IO.hzjd_modbusRTU.IO_Address, 10, 2, ReverseTime);
            }
            else
            {
                Result = WENYU_IO.hzjd_modbusRTU.JD_SetOutPortFunction(
                WENYU_IO.hzjd_modbusRTU.DevCOM, WENYU_IO.hzjd_modbusRTU.IO_Address, 10, 0, 0);
            }
            if (Result != 0) MessageBox.Show("通讯异常！");
        }

        private void button14_Click(object sender, EventArgs e)
        {
            int Result = 0;
            UInt16 ReverseTime = 0;
            bool rtn = false;

            if (radio1_out11.Checked)
            {
                Result = WENYU_IO.hzjd_modbusRTU.JD_SetOutPortFunction(
                WENYU_IO.hzjd_modbusRTU.DevCOM, WENYU_IO.hzjd_modbusRTU.IO_Address, 11, 0, 0);
            }
            else if (radio2_out11.Checked)
            {
                rtn = UInt16.TryParse(textBox12.Text, out ReverseTime);
                if (rtn == false)
                {
                    MessageBox.Show("翻转定时参数输入框中为无效参数，请重新输入！");
                    return;
                }
                Result = WENYU_IO.hzjd_modbusRTU.JD_SetOutPortFunction(
                WENYU_IO.hzjd_modbusRTU.DevCOM, WENYU_IO.hzjd_modbusRTU.IO_Address, 11, 1, ReverseTime);
            }
            else if (radio3_out11.Checked)
            {
                rtn = UInt16.TryParse(textBox12.Text, out ReverseTime);
                if (rtn == false)
                {
                    MessageBox.Show("翻转定时参数输入框中为无效参数，请重新输入！");
                    return;
                }
                Result = WENYU_IO.hzjd_modbusRTU.JD_SetOutPortFunction(
                WENYU_IO.hzjd_modbusRTU.DevCOM, WENYU_IO.hzjd_modbusRTU.IO_Address, 11, 2, ReverseTime);
            }
            else
            {
                Result = WENYU_IO.hzjd_modbusRTU.JD_SetOutPortFunction(
                WENYU_IO.hzjd_modbusRTU.DevCOM, WENYU_IO.hzjd_modbusRTU.IO_Address, 11, 0, 0);
            }
            if (Result != 0) MessageBox.Show("通讯异常！");
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            timer2.Enabled = true;
            timer2.Interval = 50;
        }
        int bit = -1;
        int bit1 = -1;
        bool BTF3;
        bool BTF4;
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (cb_Q.Checked)
            {
                int Qresult = WENYU_IO.hzjd_modbusRTU.DJ_ReadInputBit9(WENYU_IO.hzjd_modbusRTU.DevCOM, WENYU_IO.hzjd_modbusRTU.IO_Address, ref bit);
                if (0 == Qresult)//插壳
                {
                    if (bit == 0x01 && !BTF3)
                    {
                        BTF3 = true;
                        if (WENYU_IO.hzjd_modbusRTU.JD_SetOutBit2(WENYU_IO.hzjd_modbusRTU.DevCOM, WENYU_IO.hzjd_modbusRTU.IO_Address, 1) != 0)
                            MessageBox.Show("ModbusRTU异常！");
                        Thread.Sleep(20);
                        if (WENYU_IO.hzjd_modbusRTU.JD_SetOutBit2(WENYU_IO.hzjd_modbusRTU.DevCOM, WENYU_IO.hzjd_modbusRTU.IO_Address, 0) != 0)
                            MessageBox.Show("ModbusRTU异常！");
                    }
                    else if (bit == 1)
                    {
                        BTF3 = false;
                    }
                }
                else
                {
                    StaticFun.MessageFun.ShowMessage(Qresult.ToString());
                }
                
            }
            if (cb_H.Checked)
            {
                if (0 == WENYU_IO.hzjd_modbusRTU.DJ_ReadInputBit8(WENYU_IO.hzjd_modbusRTU.DevCOM, WENYU_IO.hzjd_modbusRTU.IO_Address, ref bit))//插壳
                {
                    if (bit1 == 0x01 && !BTF4)
                    {
                        BTF4 = true;
                        if (WENYU_IO.hzjd_modbusRTU.JD_SetOutBit3(WENYU_IO.hzjd_modbusRTU.DevCOM, WENYU_IO.hzjd_modbusRTU.IO_Address, 1) != 0)
                            MessageBox.Show("ModbusRTU异常！");
                        Thread.Sleep(20);
                        if (WENYU_IO.hzjd_modbusRTU.JD_SetOutBit3(WENYU_IO.hzjd_modbusRTU.DevCOM, WENYU_IO.hzjd_modbusRTU.IO_Address, 0) != 0)
                            MessageBox.Show("ModbusRTU异常！");
                    }
                    else if (bit == 1)
                    {
                        BTF4 = false;
                    }
                }
                
            }    
        }

        private void btn_stop_Click(object sender, EventArgs e)
        {
            timer2.Enabled = false;
        }
    }
}

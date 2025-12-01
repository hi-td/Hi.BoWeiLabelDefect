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
using hzjd_modbusRTU;
using Newtonsoft.Json;

namespace VisionPlatform
{
    public partial class FormSetCom : Form
    {

        FormModbusIO formModbusIO;
        public FormSetCom()
        {
            InitializeComponent();
            InitPort();
        }

        public void InitPort()
        {
            string[] strPort = SerialPort.GetPortNames();
            for (int i = 0; i < strPort.Length; i++)
            {
                this.comboBox_com.Items.Add(strPort[i]);
            }
            if (this.comboBox_com.Items.Count != 0)
                this.comboBox_com.SelectedIndex = 0;
        }

        private void but_ComSet_Click(object sender, EventArgs e)
        {
           
            int comPort = -1;
            comPort = int.Parse(comboBox_com.Text.Split('M')[1]) - 1;
            DataSerializer._COMConfig.WENYU232_ComPort = comPort;
            var json = JsonConvert.SerializeObject(DataSerializer._COMConfig);
            System.IO.File.WriteAllText(GlobalPath.SavePath.IOPath, json);
            formModbusIO = new FormModbusIO(comPort);
            formModbusIO.StartPosition = FormStartPosition.CenterScreen;
            formModbusIO.TopMost = true;
            formModbusIO.Show();
            this.Close();
          
        }
    }
}

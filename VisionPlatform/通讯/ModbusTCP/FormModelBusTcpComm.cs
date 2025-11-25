/***********************************************************
* CLR版本：4.0.30319.42000
* 类 名 称：FormModelBusTcpComm
* 机器名称：HLZN
* 命名空间：VisionPlatform.宜鑫端子机.通讯
* 文 件 名：FormModelBusTcpComm
* 创建时间：2022/10/26 10:26:06
* 作    者： Chustange
* 公    司：HaiLan Intelligent
* 说   明：
* 修改时间：
* 修 改 人：
* 修改说明：
* 深圳市海蓝智能科技有限公司 © 2022  保留所有权利.
***********************************************************/
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using GlobalPath;
using VisionPlatform.Auxiliary;
using System.Threading.Tasks;
using static VisionPlatform.InspectData;
using System.Linq;
using Hi.Ltd.Windows.Data;
using Hi.Ltd;
namespace VisionPlatform
{

    public partial class FormModelBusTcpComm : Form
    {
        private readonly IModbusTcp plc;
        public FormModelBusTcpComm(IModbusTcp _plc)
        {
            this.plc = _plc;
            InitializeComponent();
            Load += FormModelBusTcpComm_Load;
            base.FormClosing += this.FormModelBusTcpComm_FormClosing;

        }
        private InspectData.ModbusTcpPara InitParam()
        {
            InspectData.ModbusTcpPara modbusTcpPara = default(InspectData.ModbusTcpPara);
            try
            {
                modbusTcpPara.IpAddress = this.txt_Address.Text;
                DataSerializer._ModbusTcp.ModbusTcpPara.Port = int.Parse(this.txt_Port.Text);
                DataSerializer._ModbusTcp.ModbusTcpPara.ConnectTimeout = int.Parse(this.txt_ConnectTimeout.Text);
                DataSerializer._ModbusTcp.ModbusTcpPara.ResponseTimeout = int.Parse(this.txt_ResponceTimeout.Text);
                DataSerializer._ModbusTcp.ModbusTcpPara.Retries = int.Parse(this.txt_Retries.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "初始化");
            }
            return modbusTcpPara;
        }
        private void FormModelBusTcpComm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //socket.Close();
        }

        private void FormModelBusTcpComm_Load(object sender, EventArgs e)
        {
            if (File.Exists(SavePath.ModbusTcpPath))
            {
                var content = File.ReadAllText(SavePath.ModbusTcpPath);
                DataSerializer._ModbusTcp.ModbusTcpPara =
                    JsonConvert.DeserializeObject<ModbusTcpPara>(content);
                this.txt_IpAddress.Text = DataSerializer._ModbusTcp.ModbusTcpPara.IpAddress;
                this.txt_Port.Text = DataSerializer._ModbusTcp.ModbusTcpPara.Port.ToString();
                this.txt_ConnectTimeout.Text = DataSerializer._ModbusTcp.ModbusTcpPara.ConnectTimeout.ToString();
                this.txt_ResponceTimeout.Text = DataSerializer._ModbusTcp.ModbusTcpPara.ResponseTimeout.ToString();
                this.txt_Retries.Text = DataSerializer._ModbusTcp.ModbusTcpPara.Retries.ToString();
            }
            this.cbb_Function.DataSource<FunctionCode>();
            btn_Ok.Enabled = Variable.OpenRes != 0;
            btn_Ok.BackColor = Variable.OpenRes != 0 ? SystemColors.Control : Color.Lime;
            LoadAdress();
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            try
            {
                if (Variable.OpenRes != 0)
                {
                    Task.Run(() =>
                    {
                        lock (plc)
                        {
                            plc.Close();
                            plc.IpAddress = this.txt_IpAddress.Text;
                            plc.Port = this.txt_Port.Text.ToInt32();
                            Variable.OpenRes = plc.Open();
                        }
                    });
                }
                if (Variable.OpenRes == 0)
                {
                    btn_Ok.Enabled = Variable.OpenRes != 0;
                    btn_Ok.BackColor = Color.Lime;
                    DataSerializer._ModbusTcp.ModbusTcpPara.IpAddress = this.txt_IpAddress.Text;
                    DataSerializer._ModbusTcp.ModbusTcpPara.Port = this.txt_Port.Text.ToInt32();
                    DataSerializer._ModbusTcp.ModbusTcpPara.nSlaveAddress = byte.Parse(this.txt_SlaveId.Text);
                    DataSerializer._ModbusTcp.ModbusTcpPara.ConnectTimeout = this.txt_ConnectTimeout.Text.ToInt32();
                    DataSerializer._ModbusTcp.ModbusTcpPara.ResponseTimeout = this.txt_ResponceTimeout.Text.ToInt32();
                    DataSerializer._ModbusTcp.ModbusTcpPara.Retries = this.txt_Retries.Text.ToInt32();
                    SavePath.ModbusTcpPath.SerializeJson(DataSerializer._ModbusTcp.ModbusTcpPara);
                    MessageBox.Show("连接成功！", "连接提示");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("连接失败，请检查地址和端口号是否正确！", "连接提示");
                MessageBox.Show(ex.Message, "连接提示");
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            btn_Ok.Enabled = true;
            btn_Ok.BackColor = SystemColors.Control;
            plc.Close();
            Variable.OpenRes = -1;
        }

        private void btn_Read_Click(object sender, EventArgs e)
        {
            if (Variable.OpenRes == 0)
            {
                byte b = (byte)this.txt_SlaveId.Text.ToByte();
                ushort num = this.txt_Address.Text.ToUInt16();
                ushort num2 = this.txt_Quantity.Text.ToUInt16();
                this.rtb_Result.Clear();
                try
                {
                    FunctionCode functionCode;
                    bool flag2 =
                        Enum.TryParse<FunctionCode>(this.cbb_Function.SelectedValue.ToString(), out functionCode);
                    if (flag2)
                    {
                        switch (functionCode)
                        {
                            case FunctionCode.ReadCoils:
                                {
                                    bool[] array = plc.ReadCoils(b, num, num2);
                                    bool flag3 = array != null && array.Length != 0;
                                    if (flag3)
                                    {
                                        for (int i = 0; i < array.Length; i++)
                                        {
                                            this.rtb_Result.AppendText(i.ToString() + ":" + array[i].ToString() + "\r\n");
                                        }
                                    }

                                    break;
                                }
                            case FunctionCode.ReadDiscreteInputs:
                                {
                                    bool[] array2 = plc.ReadInputs(b, num, num2);
                                    bool flag4 = array2 != null && array2.Length != 0;
                                    if (flag4)
                                    {
                                        for (int j = 0; j < array2.Length; j++)
                                        {
                                            this.rtb_Result.AppendText(j.ToString() + ":" + array2[j].ToString() + "\r\n");
                                        }
                                    }

                                    break;
                                }
                            case FunctionCode.ReadHoldingRegister:
                                {
                                    ushort[] array3 = plc.ReadHoldingRegisters(b, num, num2);
                                    bool flag5 = array3 != null && array3.Length != 0;
                                    if (flag5)
                                    {
                                        for (int k = 0; k < array3.Length; k++)
                                        {
                                            this.rtb_Result.AppendText(array3[k].ToString() + "\t");
                                        }
                                    }

                                    break;
                                }
                            case FunctionCode.ReadInputRegister:
                                {
                                    ushort[] array4 = plc.ReadInputRegisters(b, num, num2);
                                    bool flag6 = array4 != null && array4.Length != 0;
                                    if (flag6)
                                    {
                                        for (int l = 0; l < array4.Length; l++)
                                        {
                                            this.rtb_Result.AppendText(array4[l].ToString() + "\t");
                                        }
                                    }

                                    break;
                                }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "输入提示");
                }
            }
        }

        private void btn_Write_Click(object sender, EventArgs e)
        {
            if (Variable.OpenRes == 0)
            {
                try
                {
                    byte b = (byte)this.txt_SlaveId.Text.ToByte();
                    ushort num = this.txt_Address.Text.ToUInt16();
                    ushort num2 = this.txt_Quantity.Text.ToUInt16();
                    FunctionCode functionCode;
                    bool flag2 = Enum.TryParse<FunctionCode>(this.cbb_Function.SelectedValue.ToString(), out functionCode);
                    if (flag2)
                    {
                        FunctionCode functionCode2 = functionCode;
                        FunctionCode functionCode3 = functionCode2;
                        if (functionCode3 <= FunctionCode.WriteSingledRegister)
                        {
                            if (functionCode3 != FunctionCode.WriteSingleCoils)
                            {
                                if (functionCode3 == FunctionCode.WriteSingledRegister)
                                {
                                    ushort num3 = this.txt_Value.Text.ToUInt16();
                                    plc.WriteSingleRegister(b, num, num3);
                                }
                            }
                            else
                            {
                                bool flag3 = this.txt_Value.Text.ToUInt16() == 1;
                                plc.WriteSingleCoil(b, num, flag3);
                            }
                        }
                        else if (functionCode3 != FunctionCode.WriteMultipleCoils)
                        {
                            if (functionCode3 == FunctionCode.WriteMultipleRegister)
                            {
                                string[] array = this.txt_Value.Text.Split(new char[] { ' ' });
                                bool flag4 = array != null && array.Length == (int)num2;
                                if (flag4)
                                {
                                    ushort[] array2 = new ushort[(int)num2];
                                    for (int i = 0; i < (int)num2; i++)
                                    {
                                        array2[i] = array[i].ToUInt16();
                                    }
                                    plc.WriteMultipleRegisters(b, num, array2);
                                }
                            }
                        }
                        else
                        {
                            string[] array3 = this.txt_Value.Text.Split(new char[] { ' ' });
                            bool flag5 = array3 != null && array3.Length == (int)num2;
                            if (flag5)
                            {
                                bool[] array4 = new bool[(int)num2];
                                for (int j = 0; j < (int)num2; j++)
                                {
                                    array4[j] = array3[j].ToUInt16() == 1;
                                }
                                plc.WriteMultipleCoils(b, num, array4);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "输入提示");
                }
            }
        }
        private void btn_Save_Click(object sender, EventArgs e)
        {
            string text = JsonConvert.SerializeObject(DataSerializer._ModbusTcp.ModbusTcpPara);
            string text2 = AppDomain.CurrentDomain.BaseDirectory + "PLC-IP(RTU).json";
            bool flag = !File.Exists(text2);
            if (flag)
            {
                File.Create(text2).Dispose();
            }
            File.WriteAllText(text2, text);
            MessageBox.Show("保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        #region 地址分配

        public void LoadAdress()
        {
            try
            {
                this.panel_Items.Controls.Clear();
                if (null != DataSerializer._globalData.dicInspectList)
                {
                    foreach (int camID in DataSerializer._globalData.dicInspectList.Keys)
                    {
                        List<InspectData.InspectItem> listItem = DataSerializer._globalData.dicInspectList[camID];
                        foreach (InspectData.InspectItem item in listItem)
                        {
                            CtrlTcpAdress ctrl = new CtrlTcpAdress(camID, item);
                            this.panel_Items.Controls.Add(ctrl);
                            if (DataSerializer._ModbusTcp.ModbusTcpConfig.listItemsAdress?.Count() != 0)
                            {
                                for (int i = 0; i < DataSerializer._ModbusTcp.ModbusTcpConfig.listItemsAdress.Count(); i++)
                                {
                                    InspectData.ItemAddress config = DataSerializer._ModbusTcp.ModbusTcpConfig.listItemsAdress[i];
                                    if (config.camItem.cam == camID && config.camItem.item == item)
                                    {
                                        ctrl.LoadParam(config);
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
                InspectData.ModbusTCPConfig TCP_Config = DataSerializer._ModbusTcp.ModbusTcpConfig;
                checkBox_bOK.Checked = TCP_Config.isOK.bUse;
                textBox_SendOK.Text = TCP_Config.isOK.strAddress;
                checkBox_bNG.Checked = TCP_Config.isNG.bUse;
                textBox_SendNG.Text = TCP_Config.isNG.strAddress;
                checkBox_bSendData.Checked = TCP_Config.bSendData;
                textBox_StartAdress.Text = TCP_Config.strDataAdress[0];
                textBox_EndAdress.Text = TCP_Config.strDataAdress[1];
                checkBox_Trigger.Checked = TCP_Config.isTrigger.bUse;
                textBox_Trigger.Text = TCP_Config.isTrigger.strAddress;
                checkBox_Finish.Checked = TCP_Config.isFinish.bUse;
                textBox_Finish.Text = TCP_Config.isFinish.strAddress;
            }
            catch (Exception ex)
            {
                StaticFun.MessageFun.ShowMessage(ex);
            }
        }

        private void but_SaveAdress_Click(object sender, EventArgs e)
        {
            try
            {
                InspectData.ModbusTCPConfig config = new ModbusTCPConfig();
                foreach (Control ctrl in this.panel_Items.Controls)
                {
                    CtrlTcpAdress myCtrl = ctrl as CtrlTcpAdress;
                    if (null != myCtrl)
                    {
                        config.listItemsAdress.Add(myCtrl.InitParam());
                    }
                }
                config.isOK = new isAddress(checkBox_bOK.Checked, $"M{textBox_SendOK.Text}");
                config.isNG = new isAddress(checkBox_bNG.Checked, $"M{textBox_SendNG.Text}");
                config.bSendData = checkBox_bSendData.Checked;
                config.strDataAdress[0] = textBox_StartAdress.Text;
                config.strDataAdress[1] = textBox_EndAdress.Text;
                config.isTrigger = new isAddress(checkBox_Trigger.Checked, $"M{textBox_Trigger.Text}");
                config.isFinish = new isAddress(checkBox_Finish.Checked, $"M{textBox_Finish.Text}");

                DataSerializer._ModbusTcp.ModbusTcpConfig = config;
                var save = GlobalPath.SavePath.ModbusTcpPath;
                var json = JsonConvert.SerializeObject(DataSerializer._ModbusTcp);
                System.IO.File.WriteAllText(save, json);

            }
            catch (Exception ex)
            {
                StaticFun.MessageFun.ShowMessage(ex);
            }
        }
        #endregion
    }
}

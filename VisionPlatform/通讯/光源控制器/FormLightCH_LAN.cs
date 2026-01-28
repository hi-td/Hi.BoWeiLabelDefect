using Aardvark.Base;
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
    public partial class FormLightCH_LAN : Form
    {
        bool isLoad = true;
        string myIP = "";
        CHBright[] arrayCHBright = new CHBright[6];
        int myCamID;
        public FormLightCH_LAN(int camID, string strIP, CHBright[] cHBright)
        {
            InitializeComponent();
            this.TopLevel = false;
            this.Visible = true;
            this.Dock = DockStyle.Fill;
            this.myCamID = camID;
            this.myIP = strIP;
            this.arrayCHBright = cHBright;
            InitUI();
        }
        private void InitUI()
        {
            try
            {
                ctrlLEDSet_LAN3.Visible = false;
                ctrlLEDSet_LAN4.Visible = false;
                ctrlLEDSet_LAN5.Visible = false;
                ctrlLEDSet_LAN6.Visible = false;
                if (GlobalData.Config._InitConfig.initConfig.bDigitLight)
                {
                    if (GlobalData.Config._InitConfig.initConfig.nLightCH == 4)
                    {
                        ctrlLEDSet_LAN3.Visible = true;
                        ctrlLEDSet_LAN4.Visible = true;
                    }
                    if (GlobalData.Config._InitConfig.initConfig.nLightCH == 6)
                    {
                        ctrlLEDSet_LAN3.Visible = true;
                        ctrlLEDSet_LAN4.Visible = true;
                        ctrlLEDSet_LAN5.Visible = true;
                        ctrlLEDSet_LAN6.Visible = true;
                    }
                }
                ctrlLEDSet_LAN1.ValueChanged += but_Confirm_Click;
                ctrlLEDSet_LAN2.ValueChanged += but_Confirm_Click;
                ctrlLEDSet_LAN3.ValueChanged += but_Confirm_Click;
                ctrlLEDSet_LAN4.ValueChanged += but_Confirm_Click;
                ctrlLEDSet_LAN5.ValueChanged += but_Confirm_Click;
                ctrlLEDSet_LAN6.ValueChanged += but_Confirm_Click;
                ctrlLEDSet_LAN1.SetLAN(myIP);
                ctrlLEDSet_LAN2.SetLAN(myIP);
                ctrlLEDSet_LAN3.SetLAN(myIP);
                ctrlLEDSet_LAN4.SetLAN(myIP);
                ctrlLEDSet_LAN5.SetLAN(myIP);
                ctrlLEDSet_LAN6.SetLAN(myIP);
                ctrlLEDSet_LAN1.LoadParam(1, this.arrayCHBright[0]);
                ctrlLEDSet_LAN2.LoadParam(2, this.arrayCHBright[1]);
                ctrlLEDSet_LAN3.LoadParam(3, this.arrayCHBright[2]);
                ctrlLEDSet_LAN4.LoadParam(4, this.arrayCHBright[3]);
                ctrlLEDSet_LAN5.LoadParam(5, this.arrayCHBright[4]);
                ctrlLEDSet_LAN6.LoadParam(6, this.arrayCHBright[5]);
                cmbBox_IP.Items.Clear();
                foreach (string strPort in DataSerializer._COMConfig.dicLedLan.Keys)
                {
                    cmbBox_IP.Items.Add(strPort);
                }
                if ("" != myIP)
                {
                    cmbBox_IP.Text = myIP;
                }
            }
            catch (Exception ex)
            {
                StaticFun.MessageFun.ShowMessage(ex);
            }
        }
        private CHBright[] InitParam()
        {
            CHBright[] param = new CHBright[6];
            try
            {
                param[0] = ctrlLEDSet_LAN1.InitParam();
                param[1] = ctrlLEDSet_LAN2.InitParam();
                param[2] = ctrlLEDSet_LAN3.InitParam();
                param[3] = ctrlLEDSet_LAN4.InitParam();
                param[4] = ctrlLEDSet_LAN5.InitParam();
                param[5] = ctrlLEDSet_LAN6.InitParam();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return param;
        }
        private void but_Confirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (DataSerializer._globalData.dicImageing.Count != 0 &&
                    DataSerializer._globalData.dicImageing.ContainsKey(myCamID))
                {
                    Imageing param = DataSerializer._globalData.dicImageing[myCamID];
                    param.CHBright = InitParam();
                    param.strPort = myIP;
                    DataSerializer._globalData.dicImageing[myCamID] = param;
                }
                else
                {
                    Imageing param = new Imageing()
                    {
                        strPort = myIP,
                        CHBright = InitParam(),
                    };
                    DataSerializer._globalData.dicImageing.Add(myCamID, param);
                }
            }
            catch (Exception ex)
            {
                StaticFun.MessageFun.ShowMessage($"光源配置保存失败:{ex}", true);
            }
        }
        private void cmbBox_PortName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                myIP = cmbBox_IP.Text;
                ctrlLEDSet_LAN1.SetLAN(myIP);
                ctrlLEDSet_LAN2.SetLAN(myIP);
                ctrlLEDSet_LAN3.SetLAN(myIP);
                ctrlLEDSet_LAN4.SetLAN(myIP);
                ctrlLEDSet_LAN5.SetLAN(myIP);
                ctrlLEDSet_LAN6.SetLAN(myIP);
            }
            catch (Exception ex)
            {
                StaticFun.MessageFun.ShowMessage(ex);
            }
        }
    }
}

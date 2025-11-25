using BaseData;
using Newtonsoft.Json;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace VisionPlatform
{
    public partial class FormLightCH : Form
    {
        bool isLoad = true;
        CHBright[] arrayCHBright = new CHBright[6];
        int myCamID;
        public FormLightCH(int camID, CHBright[] cHBright)
        {
            InitializeComponent();
            this.TopLevel = false;
            this.Visible = true;
            this.Dock = DockStyle.Fill;
            this.myCamID = camID;
            this.arrayCHBright = cHBright;
            InitUI();
        }

        private void InitUI()
        {
            try
            {
                ctrlLEDSet3.Visible = false;
                ctrlLEDSet4.Visible = false;
                ctrlLEDSet5.Visible = false;
                ctrlLEDSet6.Visible = false;
                if (GlobalData.Config._InitConfig.initConfig.bDigitLight)
                {
                    if (GlobalData.Config._InitConfig.initConfig.nLightCH == 4)
                    {
                        ctrlLEDSet3.Visible = true;
                        ctrlLEDSet4.Visible = true;
                    }
                    if (GlobalData.Config._InitConfig.initConfig.nLightCH == 6)
                    {
                        ctrlLEDSet3.Visible = true;
                        ctrlLEDSet4.Visible = true;
                        ctrlLEDSet5.Visible = true;
                        ctrlLEDSet6.Visible = true;
                    }
                }
                ctrlLEDSet1.ValueChanged += but_Confirm_Click;
                ctrlLEDSet2.ValueChanged += but_Confirm_Click;
                ctrlLEDSet3.ValueChanged += but_Confirm_Click;
                ctrlLEDSet4.ValueChanged += but_Confirm_Click;
                ctrlLEDSet5.ValueChanged += but_Confirm_Click;
                ctrlLEDSet6.ValueChanged += but_Confirm_Click;

                ctrlLEDSet1.LoadParam(1, this.arrayCHBright[0]);
                ctrlLEDSet2.LoadParam(2, this.arrayCHBright[1]);
                ctrlLEDSet3.LoadParam(3, this.arrayCHBright[2]);
                ctrlLEDSet4.LoadParam(4, this.arrayCHBright[3]);
                ctrlLEDSet5.LoadParam(5, this.arrayCHBright[4]);
                ctrlLEDSet6.LoadParam(6, this.arrayCHBright[5]);
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
                param[0] = ctrlLEDSet1.InitParam();
                param[1] = ctrlLEDSet2.InitParam();
                param[2] = ctrlLEDSet3.InitParam();
                param[3] = ctrlLEDSet4.InitParam();
                param[4] = ctrlLEDSet5.InitParam();
                param[5] = ctrlLEDSet6.InitParam();
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
                    DataSerializer._globalData.dicImageing[myCamID] = param;
                }
                else
                {
                    Imageing param = new Imageing()
                    {
                        CHBright = InitParam(),
                    };
                    DataSerializer._globalData.dicImageing.Add(myCamID, param);
                }
            }
            catch (Exception ex)
            {
                StaticFun.MessageFun.ShowMessage($"光源配置保存失败:{ex}",true);
            }
        }
    }

}
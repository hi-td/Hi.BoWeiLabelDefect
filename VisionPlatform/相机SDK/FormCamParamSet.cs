using BaseData;
using CamSDK;
using System;
using System.Windows.Forms;

namespace VisionPlatform
{
    public partial class FormCamParamSet : Form
    {
        int myCamID;
        string myStrCamSer;
        CamCommon.CamParam m_CamParam = new CamCommon.CamParam();
        FormLightCH formLightSet;
        public FormCamParamSet(int camID, string strCamSer)
        {
            InitializeComponent();
            this.myCamID = camID;
            this.myStrCamSer = strCamSer;
            this.Text = $"画质调节：相机{camID.ToString()[0]}-{camID.ToString()[1]}({strCamSer})";
            LoadCam();
        }

        public bool LoadCam()
        {
            try
            {
                //相机曝光时间
                m_CamParam = CamCommon.GetCamParam(this.myStrCamSer);
                if (DataSerializer._globalData.dicImageing.ContainsKey(myCamID))
                {
                    m_CamParam = DataSerializer._globalData.dicImageing[myCamID].camParam;
                }
                textBox_expourse.Text = m_CamParam.exposure.ToString("F1");
                textBox_gain.Text = m_CamParam.gain.ToString("F1");
                //光源控制
                this.groupBox_Light.Controls.Clear();
                if (GlobalData.Config._InitConfig.initConfig.bDigitLight)
                {
                    groupBox_Light.Visible = true;
                    CHBright[] cHBright = new CHBright[6];
                    if (DataSerializer._globalData.dicImageing.ContainsKey(myCamID))
                    {
                        cHBright = DataSerializer._globalData.dicImageing[myCamID].CHBright;
                    }
                    formLightSet = new FormLightCH(myCamID, cHBright);
                    this.groupBox_Light.Controls.Add(formLightSet);
                }
                return true;

            }
            catch (SystemException ex)
            {
                StaticFun.MessageFun.ShowMessage(ex.ToString());
                return false;
            }
        }

        private void trackBar_Exposure_Scroll(object sender, EventArgs e)
        {
            textBox_expourse.Text = trackBar_Exposure.Value.ToString();
            CamCommon.SetExposure(myStrCamSer, trackBar_Exposure.Value);
            m_CamParam.exposure = trackBar_Exposure.Value;
        }

        private void trackBar_Gain_Scroll(object sender, EventArgs e)
        {
            textBox_gain.Text = trackBar_Gain.Value.ToString();
            CamCommon.SetGain(myStrCamSer, trackBar_Gain.Value);
            m_CamParam.gain = trackBar_Gain.Value;
        }

        private void textBox_expourse_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBox_expourse.Text != "")
                {
                    float expourse = -1F;
                    if (!float.TryParse(textBox_expourse.Text, out expourse))
                    {
                        textBox_expourse.Text = "";
                        MessageBox.Show("当前输入值类型有误，请检查!（只能输入数值！）");
                        return;
                    }

                    if (expourse < 0 || expourse > 99999)
                    {
                        MessageBox.Show("当前输入值不合法，请检查！取值范围（0--99999）");
                        return;
                    }
                    trackBar_Exposure.Value = (int)expourse;
                    label_expourse.Text = Convert.ToString(trackBar_Exposure.Value);
                }
                else
                {
                    label_expourse.Text = "0";
                    return;
                }
            }
            catch (Exception)
            {

                MessageBox.Show("输入有误！ ");
            }
        }

        private void textBox_gain_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBox_gain.Text != "")
                {
                    float gain = -1;
                    if (!float.TryParse(textBox_gain.Text, out gain))
                    {
                        MessageBox.Show("当前输入值类型有误，请检查!（只能输入数值！）");
                        textBox_gain.Text = "";
                        return;
                    }

                    if (gain < 0 || gain > 9999)
                    {
                        MessageBox.Show("当前输入值不合法，请检查！取值范围（0--9999）");
                        return;
                    }
                    trackBar_Gain.Value = (int)gain;
                    label_gain.Text = Convert.ToString(trackBar_Gain.Value);
                }
                else
                {
                    label_gain.Text = "0";
                    return;
                }

            }
            catch (Exception)
            {
                MessageBox.Show("输入有误！ ");
            }
        }

        private void FormCamParamSet_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (DataSerializer._globalData.dicImageing.ContainsKey(myCamID))
                {
                    var param = DataSerializer._globalData.dicImageing[myCamID];
                    param.camParam = m_CamParam;
                    DataSerializer._globalData.dicImageing[myCamID] = param;
                }
                else
                {
                    Imageing imageing = new Imageing();
                    imageing.camParam = m_CamParam;
                    DataSerializer._globalData.dicImageing.Add(myCamID, imageing);
                }
            }
            catch (Exception ex)
            {
                StaticFun.MessageFun.ShowMessage(ex, true);
            }
        }
    }

}

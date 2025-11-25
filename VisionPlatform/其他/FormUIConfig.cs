using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using BaseData;
using CamSDK;
using EnumData;
using Newtonsoft.Json;
using WENYU_IO;
using StaticFun;
using Microsoft.Win32;
using Hi.Ltd;

namespace VisionPlatform
{
    public partial class FormUIConfig : Form
    {
        GlobalData.Config.InitConfig initConfig = new GlobalData.Config.InitConfig();
        Dictionary<int, int> dic_SubCam = new Dictionary<int, int>();
        public FormUIConfig()
        {
            InitializeComponent();
            initConfig.initConfig.comMode = new BaseData.ComMode();
        }
        private void FormUIConfig_Load(object sender, EventArgs e)
        {
            try
            {
                if (GlobalData.Config._InitConfig.initConfig.comMode != null)
                {
                    //加载相机品牌
                    switch (GlobalData.Config._InitConfig.initConfig.camBrand)
                    {
                        case CamBrand.DaHeng:
                            checkBox_DaHeng.Checked = true;
                            break;
                        case CamBrand.HiKVision:
                            checkBox_HikiVision.Checked = true;
                            break;
                        case CamBrand.DaHua:
                            checkBox_DaHua.Checked = true;
                            break;
                        case CamBrand.MindVision:
                            checkBox_MindVision.Checked = true;
                            break;
                        case CamBrand.Other:
                            checkBox_OtherCam.Checked = true;
                            break;
                        default:
                            checkBox_OtherCam.Checked = true;
                            break;
                    }
                    check_USB.Checked = GlobalData.Config._InitConfig.initConfig.bUSBCam;
                    //加载相机数量
                    switch (GlobalData.Config._InitConfig.initConfig.CamNum)
                    {
                        case 1:
                            checkBox_1Cam.Checked = true;
                            break;
                        case 2:
                            checkBox_2Cam.Checked = true;
                            break;
                        case 3:
                            checkBox_3Cam.Checked = true;
                            break;
                        case 4:
                            checkBox_4Cam.Checked = true;
                            break;
                        case 5:
                            checkBox_5Cam.Checked = true;
                            break;
                        case 6:
                            checkBox_6Cam.Checked = true;
                            break;
                        default:
                            break;
                    }
                    comboBox_Cam.Items.Clear();
                    for (int n = 0; n < GlobalData.Config._InitConfig.initConfig.CamNum; n++)
                    {
                        comboBox_Cam.Items.Add(n + 1);
                    }
                    dic_SubCam = GlobalData.Config._InitConfig.initConfig.dic_SubCam;
                    //加载通讯方式
                    ComMode comMode = GlobalData.Config._InitConfig.initConfig.comMode;
                    switch (comMode.TYPE)
                    {
                        case COMType.COM:
                            checkBox_COM.Checked = true;
                            if (comMode.COM == COM.Modbus)
                                cB_Modbus_RTU.Checked = true;
                            break;
                        case COMType.NET:
                            checkBox_IP.Checked = true;
                            break;
                        case COMType.IO:
                            checkBox_IO.Checked = true;
                            switch (comMode.IO)
                            {
                                case EnumData.IO.WENYU8:
                                    checkBox_WENYU8.Checked = true;
                                    break;
                                case EnumData.IO.WENYU16:
                                    checkBox_WENYU16.Checked = true;
                                    break;
                                case EnumData.IO.WENYU232:
                                    checkBox_WENYU232.Checked = true;
                                    break;
                                default:
                                    break;
                            }
                            checkBox_Light.Checked = GlobalData.Config._InitConfig.initConfig.bIOLight;
                            break;
                        case COMType.CamIO:
                            checkBox_CamIO.Checked = true;
                            break;
                        default:
                            break;
                    }
                    //加载光源控制
                    if (GlobalData.Config._InitConfig.initConfig.bDigitLight)
                    {
                        checkBox_Digit.Checked = true;
                        initConfig.initConfig.bDigitLight = GlobalData.Config._InitConfig.initConfig.bDigitLight;
                        switch (GlobalData.Config._InitConfig.initConfig.nLightCH)
                        {
                            case 2:
                                checkBox_CH2.Checked = true;
                                break;
                            case 4:
                                checkBox_CH4.Checked = true;
                                break;
                            case 6:
                                checkBox_CH6.Checked = true;
                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        checkBox_Analog.Checked = true;
                    }
                    numUpDown_Day.Value = -GlobalData.Config._InitConfig.initConfig.nDaySave;

                    if (GlobalData.Config._InitConfig.initConfig.bAutostarts)
                    {
                        checkBox_Autostarts.Checked = true;
                    }
                    else
                    {
                        checkBox_Autostarts.Checked = false;
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
                return;
            }
        }
        private BaseData.ConfigData InitParam()
        {
            //防止鼠标不点击触发响应事件时，全局变量initConfig未赋值
            BaseData.ConfigData param = new BaseData.ConfigData();
            param.comMode = new ComMode();
            try
            {
                #region 相机品牌
                if (checkBox_DaHeng.Checked)
                {
                    param.camBrand = CamBrand.DaHeng;
                }
                else if (checkBox_HikiVision.Checked)
                {
                    param.camBrand = CamBrand.HiKVision;
                }
                else if (checkBox_DaHua.Checked)
                {
                    param.camBrand = CamBrand.DaHua;
                }
                else if (checkBox_MindVision.Checked)
                {
                    param.camBrand = CamBrand.MindVision;
                }
                //else if()
                //{

                //}
                else
                {
                    MessageFun.ShowMessage("请先选择一个相机品牌。", strEnglish: "Please select a camera brand first.");
                }
                #endregion

                #region 相机数量
                if (checkBox_1Cam.Checked)
                {
                    param.CamNum = 1;
                }
                else if (checkBox_2Cam.Checked)
                {
                    param.CamNum = 2;
                }
                else if (checkBox_3Cam.Checked)
                {
                    param.CamNum = 3;
                }
                else if (checkBox_4Cam.Checked)
                {
                    param.CamNum = 4;
                }
                else if (checkBox_5Cam.Checked)
                {
                    param.CamNum = 5;
                }
                else if (checkBox_6Cam.Checked)
                {
                    param.CamNum = 6;
                }
                else
                {
                    MessageFun.ShowMessage("请先选择相机的数量。", strEnglish: "Please select the number of cameras first.");
                }
                param.dic_SubCam = dic_SubCam;
                #endregion

                #region 通讯方式
                if (checkBox_IO.Checked)
                {
                    param.comMode.TYPE = COMType.IO;
                    if (checkBox_WENYU8.Checked)
                    {
                        param.comMode.IO = EnumData.IO.WENYU8;
                    }
                    else if (checkBox_WENYU16.Checked)
                    {
                        param.comMode.IO = EnumData.IO.WENYU16;
                    }
                    else if (checkBox_WENYU232.Checked)
                    {
                        param.comMode.IO = EnumData.IO.WENYU232;
                    }
                    else
                    {
                        MessageBox.Show("请先选择一种IO通讯方式。", "Please select an IO communication method first.");
                    }
                    param.bIOLight = checkBox_Light.Checked;
                }
                else if (checkBox_COM.Checked)
                {
                    param.comMode.TYPE = COMType.COM;
                    if (cB_Modbus_RTU.Checked)
                    {
                        param.comMode.COM = COM.RTU;
                    }
                    else if (cB_Modbus.Checked)
                    {
                        param.comMode.COM = COM.Modbus;
                    }
                    else if (cBox_RS485.Checked)
                    {
                        param.comMode.COM = COM.RS485;
                    }
                }
                else if (checkBox_IP.Checked)
                {
                    param.comMode.TYPE = COMType.NET;
                }
                else if (checkBox_CamIO.Checked)
                {
                    param.comMode.TYPE = COMType.CamIO;
                }
                else
                {
                    MessageBox.Show("请先选择一种通讯方式。", "Please choose a communication method first.");
                }
                #endregion

                param.bUSBCam = check_USB.Checked;
                param.nDaySave = -(int)numUpDown_Day.Value;
                param.bAutostarts = checkBox_Autostarts.Checked;
                #region 光源控制器
                if (checkBox_Digit.Checked)
                {
                    param.bDigitLight = true;
                    if (checkBox_CH2.Checked)
                    {
                        param.nLightCH = 2;
                    }
                    else if (checkBox_CH4.Checked)
                    {
                        param.nLightCH = 4;
                    }
                    else if (checkBox_CH6.Checked)
                    {
                        param.nLightCH = 6;
                    }
                    else
                    {
                        MessageBox.Show("请光源控制器的通道数量。", "Please specify the number of channels for the light source controller.");
                    }
                }
                else if (checkBox_Analog.Checked)
                {
                    param.bDigitLight = false;
                }
                else
                {
                    MessageBox.Show("Please select the type of light source controller to use first.");
                }
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return param;
        }

        private void But_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("确定后软件将重启，是否确定？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    try
                    {
                        //保存相机品牌、数量、通讯方式
                        string savePath = GlobalPath.SavePath.InitConfigPath;
                        GlobalData.Config._InitConfig.initConfig = InitParam();
                        var json = JsonConvert.SerializeObject(GlobalData.Config._InitConfig);
                        System.IO.File.WriteAllText(savePath, json);
                        //保存打端检测项

                        MessageBox.Show("保存成功！退出软件并重启生效！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        try
                        {
                            if (GlobalData.Config._InitConfig.initConfig.comMode.TYPE == EnumData.COMType.IO)
                            {
                                WENYU_PIO32P.WY_WriteOutPutBit0(WENYU.DevID, 1);
                                WENYU_PIO32P.WY_WriteOutPutBit1(WENYU.DevID, 1);
                                WENYU_PIO32P.WY_WriteOutPutBit2(WENYU.DevID, 1);
                                WENYU.CloseIO();
                            }
                            if (GlobalData.Config._InitConfig.initConfig.bDigitLight)
                            {
                                //将所有光源通道亮度值设置为0
                                for (int ch = 1; ch <= GlobalData.Config._InitConfig.initConfig.nLightCH; ch++)
                                {
                                    LEDControl.SetBrightness(ch, 0);
                                }
                                //关闭光源控制器串口
                                LEDControl.CloseLED();
                            }
                            CamCommon.CloseAllCam();
                            Process.GetCurrentProcess().Kill();
                        }
                        catch
                        {
                            Process.GetCurrentProcess().Kill();
                        }
                        //关闭所有进程，退出软件并重启
                        Application.ExitThread();
                        Thread.Sleep(2000);
                        this.Close();
                        //Restart();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("保存失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    ////保存公司名称
                    //var name = JsonConvert.SerializeObject(textBox1.Text);
                    //name = Registered.DESEncrypt(name);
                    ////string tup_Path = System.AppDomain.CurrentDomain.BaseDirectory + "Name.json";
                    //System.IO.File.WriteAllText(GlobalPath.SavePath.CompanyNamePath, name);
                    //MessageBox.Show("修改保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //MessageBox.Show("保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ////关闭所有进程，退出软件并重启
                    //Application.ExitThread();

                }
                else
                {
                    return;
                }
                //Restart();
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存失败！");
                ex.Message.Log();
                return;
            }
        }

        private void Restart()
        {
            Thread thtmp = new Thread(new ParameterizedThreadStart(run));
            object appName = Application.ExecutablePath;
            Thread.Sleep(2000);
            thtmp.Start(appName);
        }
        private void run(Object obj)
        {
            Process ps = new Process();
            ps.StartInfo.FileName = obj.ToString();
            ps.Start();
        }

        #region 相机品牌
        private void checkBox_DaHeng_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox_DaHeng.Checked)
            {
                checkBox_DaHeng.Checked = true;
                checkBox_HikiVision.Checked = false;
                checkBox_DaHua.Checked = false;
                checkBox_MindVision.Checked = false;
                checkBox_OtherCam.Checked = false;
                initConfig.initConfig.camBrand = EnumData.CamBrand.DaHeng;
            }

        }

        private void checkBox_HikiVision_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox_HikiVision.Checked)
            {
                checkBox_DaHeng.Checked = false;
                checkBox_HikiVision.Checked = true;
                checkBox_DaHua.Checked = false;
                checkBox_MindVision.Checked = false;
                checkBox_OtherCam.Checked = false;
                initConfig.initConfig.camBrand = EnumData.CamBrand.HiKVision;
            }
        }

        private void checkBox_DaHua_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox_DaHua.Checked)
            {
                checkBox_DaHeng.Checked = false;
                checkBox_HikiVision.Checked = false;
                checkBox_DaHua.Checked = true;
                checkBox_MindVision.Checked = false;
                checkBox_OtherCam.Checked = false;
                initConfig.initConfig.camBrand = EnumData.CamBrand.DaHua;
            }
        }
        private void checkBox_MindVision_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_MindVision.Checked)
            {
                checkBox_DaHeng.Checked = false;
                checkBox_HikiVision.Checked = false;
                checkBox_DaHua.Checked = false;
                checkBox_MindVision.Checked = true;
                checkBox_OtherCam.Checked = false;
                initConfig.initConfig.camBrand = EnumData.CamBrand.MindVision;
            }
        }

        private void checkBox_OtherCam_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_OtherCam.Checked)
            {
                checkBox_DaHeng.Checked = false;
                checkBox_HikiVision.Checked = false;
                checkBox_DaHua.Checked = false;
                checkBox_MindVision.Checked = false;
                checkBox_OtherCam.Checked = true;
                initConfig.initConfig.camBrand = EnumData.CamBrand.Other;
            }

        }

        private void check_USB_CheckedChanged(object sender, EventArgs e)
        {
            initConfig.initConfig.bUSBCam = check_USB.Checked;
        }

        #endregion

        #region 相机数量
        private void checkBox_1Cam_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox_1Cam.Checked)
            {
                initConfig.initConfig.CamNum = 1;
                checkBox_2Cam.Checked = false;
                checkBox_3Cam.Checked = false;
                checkBox_4Cam.Checked = false;
                checkBox_5Cam.Checked = false;
                checkBox_6Cam.Checked = false;
                RefreshSubCam(1);
            }
        }

        private void checkBox_2Cam_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_2Cam.Checked)
            {
                initConfig.initConfig.CamNum = 2;
                checkBox_1Cam.Checked = false;
                checkBox_3Cam.Checked = false;
                checkBox_4Cam.Checked = false;
                checkBox_5Cam.Checked = false;
                checkBox_6Cam.Checked = false;
                RefreshSubCam(2);
            }
        }

        private void checkBox_3Cam_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_3Cam.Checked)
            {
                initConfig.initConfig.CamNum = 3;
                checkBox_1Cam.Checked = false;
                checkBox_2Cam.Checked = false;
                checkBox_4Cam.Checked = false;
                checkBox_5Cam.Checked = false;
                checkBox_6Cam.Checked = false;
                RefreshSubCam(3);
            }
        }

        private void checkBox_4Cam_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_4Cam.Checked)
            {
                initConfig.initConfig.CamNum = 4;
                checkBox_1Cam.Checked = false;
                checkBox_2Cam.Checked = false;
                checkBox_3Cam.Checked = false;
                checkBox_5Cam.Checked = false;
                checkBox_6Cam.Checked = false;
                RefreshSubCam(4);
            }
        }

        private void checkBox_5Cam_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_5Cam.Checked)
            {
                initConfig.initConfig.CamNum = 5;
                checkBox_1Cam.Checked = false;
                checkBox_2Cam.Checked = false;
                checkBox_3Cam.Checked = false;
                checkBox_4Cam.Checked = false;
                checkBox_6Cam.Checked = false;
                RefreshSubCam(5);
            }
        }

        private void checkBox_6Cam_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox_6Cam.Checked)
            {
                initConfig.initConfig.CamNum = 6;
                checkBox_1Cam.Checked = false;
                checkBox_2Cam.Checked = false;
                checkBox_3Cam.Checked = false;
                checkBox_4Cam.Checked = false;
                checkBox_5Cam.Checked = false;
                RefreshSubCam(6);
            }
        }
        #endregion

        private void RefreshSubCam(int nCamNum)
        {
            try
            {
                comboBox_Cam.Items.Clear();
                dic_SubCam.Clear();
                for (int i = 0; i < nCamNum; i++)
                {
                    comboBox_Cam.Items.Add(i + 1);
                    dic_SubCam.Add(i + 1, 0);
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        private void FormUIConfig_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }


        private void checkBox_IO_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_IO.Checked)
            {
                initConfig.initConfig.comMode.TYPE = EnumData.COMType.IO;
                checkBox_IP.Checked = false;
                checkBox_COM.Checked = false;
                checkBox_IO.Checked = true;
                checkBox_CamIO.Checked = false;
                checkBox_WENYU8.Enabled = true;
                checkBox_WENYU16.Enabled = true;
                checkBox_WENYU232.Enabled = true;
            }
            else
            {
                checkBox_WENYU8.Enabled = false;
                checkBox_WENYU16.Enabled = false;
                checkBox_WENYU232.Enabled = false;
            }
        }

        private void checkBox_CamIO_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_CamIO.Checked)
            {
                initConfig.initConfig.comMode.TYPE = EnumData.COMType.CamIO;
                checkBox_IP.Checked = false;
                checkBox_COM.Checked = false;
                checkBox_IO.Checked = false;
                checkBox_CamIO.Checked = true;
            }
            else
            {

            }
        }

        private void checkBox_IP_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_IP.Checked)
            {
                initConfig.initConfig.comMode.TYPE = EnumData.COMType.NET;
                checkBox_IP.Checked = true;
                checkBox_COM.Checked = false;
                checkBox_IO.Checked = false;
                checkBox_CamIO.Checked = false;
                comboBox_Brand.Enabled = true;
                comboBox_model.Enabled = true;

            }
            else
            {
                comboBox_Brand.Enabled = false;
                comboBox_model.Enabled = false;
            }

        }

        #region 串口通讯
        private void checkBox_COM_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_COM.Checked)
            {
                initConfig.initConfig.comMode.TYPE = EnumData.COMType.COM;
                checkBox_IP.Checked = false;
                checkBox_COM.Checked = true;
                checkBox_CamIO.Checked = false;
                checkBox_IO.Checked = false;
                cB_Modbus_RTU.Enabled = true;
                //checkBox_RS423.Enabled = true;
                //checkBox_RS485.Enabled = true;
                //checkBox_RS499.Enabled = true;
            }
            else
            {
                cB_Modbus_RTU.Enabled = false;
                //checkBox_RS423.Enabled = false;
                //checkBox_RS485.Enabled = false;
                //checkBox_RS499.Enabled = false;
            }
        }


        #endregion

        private void comboBox_Brand_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (initConfig.initConfig.comMode.TYPE == EnumData.COMType.NET)
            {
                initConfig.initConfig.comMode.wan.Brand = comboBox_Brand.Text;
            }
        }

        private void comboBox_model_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (initConfig.initConfig.comMode.TYPE == EnumData.COMType.NET)
            {
                initConfig.initConfig.comMode.wan.Model = comboBox_model.Text;
            }
        }

        private void checkBox_WENYU_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_WENYU8.Checked)
            {
                if (initConfig.initConfig.comMode.TYPE == EnumData.COMType.IO)
                {
                    initConfig.initConfig.comMode.IO = EnumData.IO.WENYU8;
                }
                checkBox_WENYU16.Checked = false;
                checkBox_WENYU232.Checked = false;
            }

        }

        private void checkBox_WENYU16_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_WENYU16.Checked)
            {
                if (initConfig.initConfig.comMode.TYPE == EnumData.COMType.IO)
                {
                    initConfig.initConfig.comMode.IO = EnumData.IO.WENYU16;
                }
                checkBox_WENYU8.Checked = false;
                checkBox_WENYU232.Checked = false;
            }
        }

        private void checkBox_WENYU232_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_WENYU232.Checked)
            {
                if (initConfig.initConfig.comMode.TYPE == EnumData.COMType.IO)
                {
                    initConfig.initConfig.comMode.IO = EnumData.IO.WENYU232;
                }
                checkBox_WENYU8.Checked = false;
                checkBox_WENYU16.Checked = false;
            }
        }

        private void but_saveName_Click(object sender, EventArgs e)
        {
            try
            {
                //this.Invoke(new MethodInvoker(() =>
                //{
                //     m_formMain.Text = textBox1.Text;
                //}));
                var json = JsonConvert.SerializeObject(textBox1.Text);
                json = Registered.DESEncrypt(json);
                //string tup_Path = System.AppDomain.CurrentDomain.BaseDirectory + "Name.json";
                System.IO.File.WriteAllText(GlobalPath.SavePath.CompanyNamePath, json);
                MessageBox.Show("修改保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("修改保存失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void checkBox_Digit_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Digit.Checked)
            {
                checkBox_Analog.Checked = false;
                initConfig.initConfig.bDigitLight = true;
                tLPanel_CH.Visible = true;
            }
            else
            {
                checkBox_Analog.Checked = true;
                initConfig.initConfig.bDigitLight = false;
                tLPanel_CH.Visible = false;
            }

        }

        private void checkBox_Analog_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Analog.Checked)
            {
                checkBox_Digit.Checked = false;
                initConfig.initConfig.bDigitLight = false;
                tLPanel_CH.Visible = false;
            }
            else
            {
                checkBox_Digit.Checked = true;
                initConfig.initConfig.bDigitLight = true;
                tLPanel_CH.Visible = true;
            }
        }

        private void checkBox_CH2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_CH2.Checked)
            {
                checkBox_CH4.Checked = false;
                checkBox_CH6.Checked = false;
                initConfig.initConfig.nLightCH = 2;
            }
        }

        private void checkBox_CH4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_CH4.Checked)
            {
                checkBox_CH2.Checked = false;
                checkBox_CH6.Checked = false;
                initConfig.initConfig.nLightCH = 4;
            }
        }

        private void checkBox_CH6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_CH6.Checked)
            {
                checkBox_CH2.Checked = false;
                checkBox_CH4.Checked = false;
                initConfig.initConfig.nLightCH = 6;
            }
        }

        private void checkBox_Light_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Light.Checked)
            {
                checkBox_Light.Checked = true;
            }
            else
            {
                checkBox_Light.Checked = false;
            }
        }

        private void comboBox_Cam_SelectedIndexChanged(object sender, EventArgs e)
        {
            int nSel = comboBox_Cam.SelectedIndex + 1;
            if (null != dic_SubCam && dic_SubCam.ContainsKey(nSel))
            {
                numUpD_SubCam.Value = dic_SubCam[nSel];
            
            }
            else
            {
                numUpD_SubCam.Value = 0;
            }
        }

        private void numUpD_SubCam_ValueChanged(object sender, EventArgs e)
        {
            int nSel = comboBox_Cam.SelectedIndex + 1;
            if (null != dic_SubCam && dic_SubCam.ContainsKey(nSel))
            {
                dic_SubCam[nSel] = (int)numUpD_SubCam.Value;
            }
            else
            {
                dic_SubCam.Add(nSel, (int)numUpD_SubCam.Value);
            }
        }

        #region 串口通讯方式
        private void cB_Modbus_RTU_CheckedChanged(object sender, EventArgs e)
        {
            if (cB_Modbus_RTU.Checked)
            {
                if (initConfig.initConfig.comMode.TYPE == EnumData.COMType.COM)
                {
                    initConfig.initConfig.comMode.COM = EnumData.COM.RTU;
                }
                cB_Modbus.Checked = false;
                cBox_RS485.Checked = false;
            }
        }

        private void cB_Modbus_CheckedChanged(object sender, EventArgs e)
        {
            if(cB_Modbus.Checked)
            {
                if (initConfig.initConfig.comMode.TYPE == EnumData.COMType.COM)
                {
                    initConfig.initConfig.comMode.COM = EnumData.COM.Modbus;
                }
                cB_Modbus_RTU.Checked = false;
                cBox_RS485.Checked = false;
            }
        }

        private void cBox_RS485_CheckedChanged(object sender, EventArgs e)
        {
            if (cBox_RS485.Checked)
            {
                if (initConfig.initConfig.comMode.TYPE == EnumData.COMType.COM)
                {
                    initConfig.initConfig.comMode.COM = EnumData.COM.RS485;
                }
                cB_Modbus_RTU.Checked = false;
                cB_Modbus.Checked = false;
            }
        }
        #endregion

        private void checkBox_Autostarts_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Autostarts.Checked)
            {
                AutoStart(true);
                //initConfig.initConfig.bAutostarts = true;
            }
            else
            {
                AutoStart(false);
                //initConfig.initConfig.bAutostarts = false;
            }
        }

        private void AutoStart(bool isAuto)
        {
            RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\Run", true);
            try
            {
                string filename = Application.ExecutablePath;
                if (!System.IO.File.Exists(filename))
                {
                    return;
                }
                String name = filename.Substring(filename.LastIndexOf(@"\") + 1);
                if (isAuto)
                {
                    if (key == null)
                    {
                        key = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\Run");
                        key.SetValue(name, filename);
                    }
                    else
                    {
                        key.SetValue(name, filename);
                    }
                    key.Close();
                }
                else
                {

                    if (key != null && key.GetValue(name) != null)
                    {
                        key.DeleteValue(name);
                    }
                }
            }
            catch (Exception)
            {

            }
        }
    }
}


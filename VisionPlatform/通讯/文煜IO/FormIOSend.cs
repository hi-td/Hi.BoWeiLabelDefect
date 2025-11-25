using EnumData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static VisionPlatform.InspectData;

namespace VisionPlatform
{
    public partial class FormIOSend : Form
    {
        //string m_strCheckItem;
        InspectData.CamInspectItem m_camItem;
        bool is_Load = false;
        /// <summary>
        /// 相机及其对应的检测项目的IO输出信号
        /// </summary>
        /// <param name="cam"></param>   相机
        /// <param name="strCheckItem"></param> string类型的检测项名称
        /// <param name="inspectItem"></param>enum类型的检测项名称
        public FormIOSend(int cam, int sub_cam, string strCheckItem, InspectData.InspectItem inspectItem)
        {
            InitializeComponent();
            InitUI();
            int ncam = cam * 10 + sub_cam;
            m_camItem.cam = ncam;
            m_camItem.item = inspectItem;
            //m_strCheckItem = strCheckItem;
            if (GlobalData.Config._language == EnumData.Language.english)
            {
                this.Text = "Camera" + ncam.ToString() + "【" + strCheckItem + "】I/O output point configuration";
            }
            else
            {
                this.Text = "相机" + ncam.ToString() + "【" + strCheckItem + "】I/O输出点位配置";
            }
        }

        private void InitUI()
        {
            try
            {
                int total_io = 8;
                if (GlobalData.Config._InitConfig.initConfig.comMode.IO == EnumData.IO.WENYU16)
                {
                    total_io = 16;
                }
                else if (GlobalData.Config._InitConfig.initConfig.comMode.IO == EnumData.IO.WENYU232)
                {
                    total_io = 12;
                }
                else if (GlobalData.Config._InitConfig.initConfig.comMode.TYPE == EnumData.COMType.CamIO)
                {
                    total_io = 3;
                }
                for (int i = 0; i < total_io; i++)
                {
                    comboBox_OK.Items.Add(i);
                    comboBox_NG.Items.Add(i);
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        private void checkBox_OK_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_OK.Checked)
            {
                comboBox_OK.Visible = true;
                comboBox_OK.Enabled = true;
            }
            else
            {
                comboBox_OK.Visible = false;
                comboBox_OK.Enabled = true;
                label_PreSendOK.Text = "null";
            }
        }

        private void checkBox_NG_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_NG.Checked)
            {
                comboBox_NG.Visible = true;
                comboBox_NG.Enabled = true;
            }
            else
            {
                comboBox_NG.Visible = false;
                comboBox_NG.Enabled = false;
                label_PreSendNG.Text = "null";
            }
        }

        private void FormIOSend_Load(object sender, EventArgs e)
        {
            try
            {
                is_Load = true;
                if (DataSerializer._COMConfig.listIOSet?.Count != 0)
                {
                    for (int n = 0; n < DataSerializer._COMConfig.listIOSet.Count; n++)
                    {

                        IOSet io = DataSerializer._COMConfig.listIOSet[n];
                        if (io.camItem.cam == m_camItem.cam && io.camItem.item == m_camItem.item)
                        {
                            if (io.send.bSendOK)
                            {
                                checkBox_OK.Checked = io.send.bSendOK;
                                label_PreSendOK.Text = io.send.sendOK.ToString();
                                label_PreSendOK.Enabled = true;
                                comboBox_OK.SelectedIndex = io.send.sendOK;
                                comboBox_OK.Enabled = true;
                            }
                            else
                            {
                                checkBox_OK.Checked = io.send.bSendOK;
                                label_PreSendOK.Text = "null";
                                label_PreSendOK.Enabled = false;
                                comboBox_OK.SelectedIndex = -1;
                                comboBox_OK.Enabled = false;
                            }
                            if (io.send.bSendNG)
                            {
                                checkBox_NG.Checked = io.send.bSendNG;
                                label_PreSendNG.Text = io.send.sendNG.ToString();
                                label_PreSendNG.Enabled = true;
                                comboBox_NG.SelectedIndex = io.send.sendNG;
                                comboBox_NG.Enabled = true;
                            }
                            else
                            {
                                checkBox_NG.Checked = io.send.bSendNG;
                                label_PreSendNG.Text = "null";
                                label_PreSendNG.Enabled = false;
                                comboBox_NG.SelectedIndex = -1;
                                comboBox_NG.Enabled = false;
                            }
                            checkBox_Invert.Checked = io.send.bSendInvert;
                            if (io.send.bSendInvert)
                            {
                                tLPanel_Sleep.Visible = true;
                            }
                            numUpD_Sleep.Value = io.send.nSleep;
                            is_Load = false;
                            return;
                        }
                    }
                }
                else
                {
                    label_PreSendOK.Text = "null";
                    label_PreSendNG.Text = "null";
                    checkBox_Invert.Checked = false;
                    numUpD_Sleep.Value = 20;
                    comboBox_OK.SelectedIndex = -1;
                    comboBox_NG.SelectedIndex = -1;
                }
                
                is_Load = false;
            }
            catch (Exception ex)
            {
                ex.ToString();
                is_Load = false;
                return;
            }

        }

        private void comboBox_OK_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (-1 != comboBox_OK.SelectedIndex)
            {
                label_PreSendOK.Text = comboBox_OK.SelectedIndex.ToString();
            }
        }

        private void comboBox_NG_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (-1 != comboBox_NG.SelectedIndex)
            {
                label_PreSendNG.Text = comboBox_NG.SelectedIndex.ToString();
            }
        }

        private bool SaveIOSend()
        {
            try
            {
                if (is_Load) return true;
                IOSet ioSet = new IOSet();
                ioSet.camItem = m_camItem;
                ioSet.send.bSendOK = checkBox_OK.Checked;
                ioSet.send.bSendNG = checkBox_NG.Checked;
                if (-1 != comboBox_OK.SelectedIndex)
                {
                    ioSet.send.sendOK = comboBox_OK.SelectedIndex;
                }
                if (-1 != comboBox_NG.SelectedIndex)
                {
                    ioSet.send.sendNG = comboBox_NG.SelectedIndex;
                }
                ioSet.send.bSendInvert = checkBox_Invert.Checked;
                ioSet.send.nSleep = (int)numUpD_Sleep.Value;
                foreach (IOSet io in DataSerializer._COMConfig.listIOSet)
                {
                    if (io.camItem.cam == m_camItem.cam && io.camItem.item == m_camItem.item)
                    {
                        ioSet.read = io.read;
                    }
                }
                StaticFun.SaveData.SaveIOConfig(ioSet);
                return true;
            }
            catch (Exception ex)
            {
                StaticFun.MessageFun.ShowMessage("I/O输出点位保存错误：" + ex.ToString(), strEnglish: "I/O output point save error:" + ex.ToString());
                return false;
            }
        }

        private void checkBox_Invert_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Invert.Checked)
            {
                tLPanel_Sleep.Visible = true;
            }
            else
            {
                tLPanel_Sleep.Visible = false;
            }
        }
        private void but_SaveSet_Click(object sender, EventArgs e)
        {
            if (SaveIOSend())
            {
                this.Close();
            }
            else
            {
                StaticFun.MessageFun.ShowMessage("保存配置出错。", strEnglish: "Error saving configuration.");
            }
        }
    }
}

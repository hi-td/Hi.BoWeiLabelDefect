/***********************************************************
* CLR版本：4.0.30319.42000
* 类 名 称：FormCamIO
* 机器名称：DESKTOP-5NCLPK1
* 命名空间：VisionPlatform.铝材角度检测._7通讯
* 文 件 名：FormCamIO
* 创建时间：2023/6/8 16:22:19
* 作    者：BaoPengYu
* 公    司：HaiLan Intelligent
* 说   明：
* 修改时间：
* 修 改 人：
* 修改说明：
* 深圳市海蓝智能科技有限公司  2021  保留所有权利.
***********************************************************/
using CamSDK;
using MvCamCtrl.NET;
using MVSDK;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using CameraHandle = System.Int32;

namespace VisionPlatform
{
    public partial class FormMindVisionCamIO : Form
    {
         string m_cameSer;
        int m_iInputIoCounts = 0;
        public FormMindVisionCamIO()
        {
            InitializeComponent();          
        }
        private void RadioButton_LowOut1_CheckedChanged(object sender, EventArgs e)
        {
            bool bState = radioButton_LowOut1.Checked;
            CamCommon.SetIOState(m_cameSer, 0, bState);
        }

        private void RadioButton_LowOut2_CheckedChanged(object sender, EventArgs e)
        {
            bool bState = radioButton_LowOut2.Checked;
            CamCommon.SetIOState(m_cameSer, 1, bState);
        }

        private void RadioButton_LowOut3_CheckedChanged(object sender, EventArgs e)
        {
            bool bState = radioButton_LowOut3.Checked;
            CamCommon.SetIOState(m_cameSer, 2, bState);
        }

        private void RadioButton_LowOut4_CheckedChanged(object sender, EventArgs e)
        {
            bool bState = radioButton_LowOut4.Checked;
            CamCommon.SetIOState(m_cameSer, 3, bState);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            uint bchek = 0;
            //bool bchek = false;
            for (int i = 0; i < m_iInputIoCounts; i++)
            {
                CamCommon.GetIOState(m_cameSer, i, ref bchek);
                if (bchek != 0)
                {
                    switch (i)
                    {
                        case 0:
                            radioButton_LowIN1.Checked = false;
                            break;
                        case 1:
                            radioButton_LowIN2.Checked = false;
                            break;
                        case 2:
                            radioButton_LowIN3.Checked = false;
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    switch (i)
                    {
                        case 0:
                            radioButton_LowIN1.Checked = true;
                            break;
                        case 1:
                            radioButton_LowIN2.Checked = true;
                            break;
                        case 2:
                            radioButton_LowIN3.Checked = true;
                            break;
                        default:
                            break;
                    }
                }
            }
        }



        private void FormCamIO_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text==null|| comboBox1.Text == "")
            {
                return;
            }
            m_cameSer = comboBox1.Text;
            CamCommon.GetCapability(m_cameSer, out tSdkCameraCapbility tCameraCapability);
            if (tCameraCapability.iInputIoCounts == 0 && tCameraCapability.iOutputIoCounts == 0)
            {
                MessageBox.Show("该型号相机没有GPIO，演示程序无法运行", "Information");
                //Environment.Exit(0);
                //return false;
            }
            m_iInputIoCounts = tCameraCapability.iInputIoCounts;

            //radioButton_HighIN1.Checked = true;
            //radioButton_HighIN2.Checked = true;
            //radioButton_HighIN3.Checked = true;

            //IO初始化为高电平，与控件上显示的同步
            for (int i = 0; i < tCameraCapability.iOutputIoCounts; i++)
            {
                CamSDK.CamCommon.SetIOState(m_cameSer, i, true);
                switch (i)
                {
                    case 0:
                        radioButton_LowOut1.Checked = true;
                        break;
                    case 1:
                        radioButton_LowOut2.Checked = true;
                        break;
                    case 2:
                        radioButton_LowOut3.Checked = true;
                        break;
                    case 3:
                        radioButton_LowOut4.Checked = true;
                        break;
                    default:
                        break;
                }
            }
            timer1.Start();
        }

        private void FormCamIO_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            if (CamCommon.m_listCamSer.Count> 0)
            {
                foreach (var item in CamCommon.m_listCamSer)
                {
                    comboBox1.Items.Add(item.Key);
                }
                comboBox1.SelectedIndex = 0;
            }
        }
        

    }
}

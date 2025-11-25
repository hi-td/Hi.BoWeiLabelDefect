using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WENYU_IO;

namespace VisionPlatform
{
    public partial class FormIOcomm : Form
    {
        public WENYU_PIO32P.WY_hDevice DeviceID0;  //定义板卡句柄参数
        public FormIOcomm()
        {
            InitializeComponent();
        }
        public void OpenIO()
        {

            //IO板卡通讯
            int Result;
            long VersionNumber = 0;
            try
            {
                Result = WENYU_PIO32P.WY_Open(0, ref WENYU.DevID);
                if (Result != 0)
                {
                    if (GlobalData.Config._language == EnumData.Language.english)
                    {
                        MessageBox.Show("Board not found!", "Tips", MessageBoxButtons.OK);
                    }
                    else
                    {
                        MessageBox.Show("板卡没有找到！", "提示", MessageBoxButtons.OK);
                    }
                    //System.Environment.Exit(0);
                }
                //ScanOutPutPort();
                Result = WENYU_PIO32P.WY_GetCardVersion(WENYU.DevID, ref VersionNumber);
                if (Result == 0) { }
                else
                {
                    if (GlobalData.Config._language == EnumData.Language.english)
                    {
                        MessageBox.Show("Abnormal board communication!", "Tips", MessageBoxButtons.OK);
                    }
                    else
                    {
                        MessageBox.Show("板卡通讯异常！", "提示", MessageBoxButtons.OK);
                    }
                }
                
                DeviceID0 = WENYU.DevID;
            }
            catch (Exception)
            {
                return ;
            }          
        }
        public void CloseIO()
        {
            int Result;
            Result = WENYU_PIO32P.WY_Close(WENYU.DevID);
        }
        private void ScanInPutPort()
        {

            long HighData = 0;
            long LowData = 0;
            long InputData = 0;

            int Res;
            int Result;
            int value = 0;

            Res = WENYU_PIO32P.WY_GetHighInPutData(WENYU.DevID, ref HighData);
            if (Res == 0)
            {
                if (GlobalData.Config._language == EnumData.Language.english)
                {
                    label5.Text = "The input data for the top 8 digits is:" + Convert.ToString(HighData);
                }
                else
                {
                    label5.Text = "输入高8位数据为：" + Convert.ToString(HighData);
                }
            }


            Res = WENYU_PIO32P.WY_GetInPutData(WENYU.DevID, ref InputData);
            if (Res == 0) 
            {
                if (GlobalData.Config._language == EnumData.Language.english)
                {
                    label3.Text = "The input port data is:" + Convert.ToString(InputData);
                }
                else
                {
                    label3.Text = "输入端口数据为：" + Convert.ToString(InputData);
                }
            }


            Res = WENYU_PIO32P.WY_GetLowInPutData(WENYU.DevID, ref LowData);
            if (Res == 0) 
            {
                if (GlobalData.Config._language == EnumData.Language.english)
                {
                    label4.Text = "Input the low 8 bits of data as:" + Convert.ToString(LowData);
                }
                else
                {
                    label4.Text = "输入低8位数据为：" + Convert.ToString(LowData);
                }
            }

            Result = WENYU_PIO32P.WY_ReadInPutbit0(WENYU.DevID, ref value);
            if (Result == 0)
            {
                if (value == 0) checkBox1.Checked = true;
                else checkBox1.Checked = false;
            }
            Result = WENYU_PIO32P.WY_ReadInPutbit1(WENYU.DevID, ref value);
            if (Result == 0)
            {
                if (value == 0) checkBox2.Checked = true;
                else checkBox2.Checked = false;
            }
            Result = WENYU_PIO32P.WY_ReadInPutbit2(WENYU.DevID, ref value);
            if (Result == 0)
            {
                if (value == 0) checkBox3.Checked = true;
                else checkBox3.Checked = false;
            }
            Result = WENYU_PIO32P.WY_ReadInPutbit3(WENYU.DevID, ref value);
            if (Result == 0)
            {
                if (value == 0) checkBox4.Checked = true;
                else checkBox4.Checked = false;
            }
            Result = WENYU_PIO32P.WY_ReadInPutbit4(WENYU.DevID, ref value);
            if (Result == 0)
            {
                if (value == 0) checkBox5.Checked = true;
                else checkBox5.Checked = false;
            }
            Result = WENYU_PIO32P.WY_ReadInPutbit5(WENYU.DevID, ref value);
            if (Result == 0)
            {
                if (value == 0) checkBox6.Checked = true;
                else checkBox6.Checked = false;
            }
            Result = WENYU_PIO32P.WY_ReadInPutbit6(WENYU.DevID, ref value);
            if (Result == 0)
            {
                if (value == 0) checkBox7.Checked = true;
                else checkBox7.Checked = false;
            }
            Result = WENYU_PIO32P.WY_ReadInPutbit7(WENYU.DevID, ref value);
            if (Result == 0)
            {
                if (value == 0) checkBox8.Checked = true;
                else checkBox8.Checked = false;
            }


            Result = WENYU_PIO32P.WY_ReadInPutbit8(WENYU.DevID, ref value);
            if (Result == 0)
            {
                if (value == 0) checkBox9.Checked = true;
                else checkBox9.Checked = false;
            }


            Result = WENYU_PIO32P.WY_ReadInPutbit9(WENYU.DevID, ref value);
            if (Result == 0)
            {
                if (value == 0) checkBox10.Checked = true;
                else checkBox10.Checked = false;
            }

            Result = WENYU_PIO32P.WY_ReadInPutbit10(WENYU.DevID, ref value);
            if (Result == 0)
            {
                if (value == 0) checkBox11.Checked = true;
                else checkBox11.Checked = false;
            }

            Result = WENYU_PIO32P.WY_ReadInPutbit11(WENYU.DevID, ref value);
            if (Result == 0)
            {
                if (value == 0) checkBox12.Checked = true;
                else checkBox12.Checked = false;
            }


            Result = WENYU_PIO32P.WY_ReadInPutbit12(WENYU.DevID, ref value);
            if (Result == 0)
            {
                if (value == 0) checkBox13.Checked = true;
                else checkBox13.Checked = false;
            }


            Result = WENYU_PIO32P.WY_ReadInPutbit13(WENYU.DevID, ref value);
            if (Result == 0)
            {
                if (value == 0) checkBox14.Checked = true;
                else checkBox14.Checked = false;
            }

            Result = WENYU_PIO32P.WY_ReadInPutbit14(WENYU.DevID, ref value);
            if (Result == 0)
            {
                if (value == 0) checkBox15.Checked = true;
                else checkBox15.Checked = false;
            }
            Result = WENYU_PIO32P.WY_ReadInPutbit15(WENYU.DevID, ref value);
            if (Result == 0)
            {
                if (value == 0) checkBox16.Checked = true;
                else checkBox16.Checked = false;
            }
        }
        private void ScanOutPutPort()
        {
            int Res;
            long OutPutData = 0;
            long HighData = 0;
            long LowData = 0;

            int Result;
            int value = 0;

            Res = WENYU_PIO32P.WY_GetOutPutData(WENYU.DevID, ref OutPutData);
            if (Res == 0) 
            { 
                if (GlobalData.Config._language == EnumData.Language.english)
                {
                    label8.Text = "The output port data is:" + Convert.ToString(OutPutData);
                }
                else
                {
                    label8.Text = "输出端口数据为：" + Convert.ToString(OutPutData);
                }
            }

            Res = WENYU_PIO32P.WY_GetLowOutPutData(WENYU.DevID, ref LowData);
            if (Res == 0) 
            {
                if (GlobalData.Config._language == EnumData.Language.english)
                {
                    label7.Text = "The output of the low 8 bits of data is:" + Convert.ToString(LowData);
                }
                else
                {
                    label7.Text = "输出低8位数据为：" + Convert.ToString(LowData);
                }
            }

            Res = WENYU_PIO32P.WY_GetHighOutPutData(WENYU.DevID, ref HighData);
            if (Res == 0) 
            {
                if (GlobalData.Config._language == EnumData.Language.english)
                {
                    label6.Text = "Output the high 8-bit data as:" + Convert.ToString(HighData);
                }
                else
                {
                    label6.Text = "输出高8位数据为：" + Convert.ToString(HighData);
                } 
            }

            Result = WENYU_PIO32P.WY_ReadOutPutBit15(WENYU.DevID, ref value);
            if (Result == 0)
            {
                if (value == 0) checkBox17.Checked = true;
                else checkBox17.Checked = false;
            }


            Result = WENYU_PIO32P.WY_ReadOutPutBit14(WENYU.DevID, ref value);
            if (Result == 0)
            {
                if (value == 0) checkBox18.Checked = true;
                else checkBox18.Checked = false;
            }


            Result = WENYU_PIO32P.WY_ReadOutPutBit13(WENYU.DevID, ref value);
            if (Result == 0)
            {
                if (value == 0) checkBox19.Checked = true;
                else checkBox19.Checked = false;
            }


            Result = WENYU_PIO32P.WY_ReadOutPutBit12(WENYU.DevID, ref value);
            if (Result == 0)
            {
                if (value == 0) checkBox20.Checked = true;
                else checkBox20.Checked = false;
            }


            Result = WENYU_PIO32P.WY_ReadOutPutBit11(WENYU.DevID, ref value);
            if (Result == 0)
            {
                if (value == 0) checkBox21.Checked = true;
                else checkBox21.Checked = false;
            }


            Result = WENYU_PIO32P.WY_ReadOutPutBit10(WENYU.DevID, ref value);
            if (Result == 0)
            {
                if (value == 0) checkBox22.Checked = true;
                else checkBox22.Checked = false;
            }


            Result = WENYU_PIO32P.WY_ReadOutPutBit9(WENYU.DevID, ref value);
            if (Result == 0)
            {
                if (value == 0) checkBox23.Checked = true;
                else checkBox23.Checked = false;
            }


            Result = WENYU_PIO32P.WY_ReadOutPutBit8(WENYU.DevID, ref value);
            if (Result == 0)
            {
                if (value == 0) checkBox24.Checked = true;
                else checkBox24.Checked = false;
            }


            Result = WENYU_PIO32P.WY_ReadOutPutBit7(WENYU.DevID, ref value);
            if (Result == 0)
            {
                if (value == 0) checkBox25.Checked = true;
                else checkBox25.Checked = false;
            }


            Result = WENYU_PIO32P.WY_ReadOutPutBit6(WENYU.DevID, ref value);
            if (Result == 0)
            {
                if (value == 0) checkBox26.Checked = true;
                else checkBox26.Checked = false;
            }


            Result = WENYU_PIO32P.WY_ReadOutPutBit5(WENYU.DevID, ref value);
            if (Result == 0)
            {
                if (value == 0) checkBox27.Checked = true;
                else checkBox27.Checked = false;
            }


            Result = WENYU_PIO32P.WY_ReadOutPutBit4(WENYU.DevID, ref value);
            if (Result == 0)
            {
                if (value == 0) checkBox28.Checked = true;
                else checkBox28.Checked = false;
            }


            Result = WENYU_PIO32P.WY_ReadOutPutBit3(WENYU.DevID, ref value);
            if (Result == 0)
            {
                if (value == 0) checkBox29.Checked = true;
                else checkBox29.Checked = false;
            }


            Result = WENYU_PIO32P.WY_ReadOutPutBit2(WENYU.DevID, ref value);
            if (Result == 0)
            {
                if (value == 0) checkBox30.Checked = true;
                else checkBox30.Checked = false;
            }


            Result = WENYU_PIO32P.WY_ReadOutPutBit1(WENYU.DevID, ref value);
            if (Result == 0)
            {
                if (value == 0) checkBox31.Checked = true;
                else checkBox31.Checked = false;
            }


            Result = WENYU_PIO32P.WY_ReadOutPutBit0(WENYU.DevID, ref value);
            if (Result == 0)
            {
                if (value == 0) checkBox32.Checked = true;
                else checkBox32.Checked = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ScanInPutPort();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int Result;
            Result = WENYU_PIO32P.WY_WriteOutPutBit0(WENYU.DevID, 0);
            if (Result != 0) 
            {
                if (GlobalData.Config._language == EnumData.Language.english)
                {
                    MessageBox.Show("Function return value error!", "Tips", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("函数返回值错误！", "提示", MessageBoxButtons.OK);
                }
            }
            ScanOutPutPort();
        }

        private void button14_Click(object sender, EventArgs e)
        {

            int Result;
            Result = WENYU_PIO32P.WY_WriteOutPutBit0(WENYU.DevID, 1);
            if (Result != 0) 
            {
                if (GlobalData.Config._language == EnumData.Language.english)
                {
                    MessageBox.Show("Function return value error!", "Tips", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("函数返回值错误！", "提示", MessageBoxButtons.OK);
                }
                
            }
            ScanOutPutPort();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int Result;
            Result = WENYU_PIO32P.WY_WriteOutPutBit1(WENYU.DevID, 0);
            if (Result != 0) 
            {
                if (GlobalData.Config._language == EnumData.Language.english)
                {
                    MessageBox.Show("Function return value error!", "Tips", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("函数返回值错误！", "提示", MessageBoxButtons.OK);
                }
            }
            ScanOutPutPort();
        }

        private void button15_Click(object sender, EventArgs e)
        {

            int Result;
            Result = WENYU_PIO32P.WY_WriteOutPutBit1(WENYU.DevID, 1);
            if (Result != 0) 
            {
                if (GlobalData.Config._language == EnumData.Language.english)
                {
                    MessageBox.Show("Function return value error!", "Tips", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("函数返回值错误！", "提示", MessageBoxButtons.OK);
                }
            }
            ScanOutPutPort();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int Result;
            Result = WENYU_PIO32P.WY_WriteOutPutBit2(WENYU.DevID, 0);
            if (Result != 0)
            {
                if (GlobalData.Config._language == EnumData.Language.english)
                {
                    MessageBox.Show("Function return value error!", "Tips", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("函数返回值错误！", "提示", MessageBoxButtons.OK);
                }
            }
            ScanOutPutPort();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int Result;
            Result = WENYU_PIO32P.WY_WriteOutPutBit2(WENYU.DevID, 1);
            if (Result != 0)
            {
                if (GlobalData.Config._language == EnumData.Language.english)
                {
                    MessageBox.Show("Function return value error!", "Tips", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("函数返回值错误！", "提示", MessageBoxButtons.OK);
                }
            }
            ScanOutPutPort();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int Result;
            Result = WENYU_PIO32P.WY_WriteOutPutBit3(WENYU.DevID, 0);
            if (Result != 0)
            {
                if (GlobalData.Config._language == EnumData.Language.english)
                {
                    MessageBox.Show("Function return value error!", "Tips", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("函数返回值错误！", "提示", MessageBoxButtons.OK);
                }
            }
            ScanOutPutPort();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int Result;
            Result = WENYU_PIO32P.WY_WriteOutPutBit3(WENYU.DevID, 1);
            if (Result != 0)
            {
                if (GlobalData.Config._language == EnumData.Language.english)
                {
                    MessageBox.Show("Function return value error!", "Tips", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("函数返回值错误！", "提示", MessageBoxButtons.OK);
                }
            }
            ScanOutPutPort();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            int Result;
            Result = WENYU_PIO32P.WY_WriteOutPutBit4(WENYU.DevID, 0);
            if (Result != 0)
            {
                if (GlobalData.Config._language == EnumData.Language.english)
                {
                    MessageBox.Show("Function return value error!", "Tips", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("函数返回值错误！", "提示", MessageBoxButtons.OK);
                }
            }
            ScanOutPutPort();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            int Result;
            Result = WENYU_PIO32P.WY_WriteOutPutBit4(WENYU.DevID, 1);
            if (Result != 0)
            {
                if (GlobalData.Config._language == EnumData.Language.english)
                {
                    MessageBox.Show("Function return value error!", "Tips", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("函数返回值错误！", "提示", MessageBoxButtons.OK);
                }
            }
            ScanOutPutPort();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            int Result;
            Result = WENYU_PIO32P.WY_WriteOutPutBit5(WENYU.DevID, 0);
            if (Result != 0)
            {
                if (GlobalData.Config._language == EnumData.Language.english)
                {
                    MessageBox.Show("Function return value error!", "Tips", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("函数返回值错误！", "提示", MessageBoxButtons.OK);
                }
            }
            ScanOutPutPort();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            int Result;
            Result = WENYU_PIO32P.WY_WriteOutPutBit5(WENYU.DevID, 1);
            if (Result != 0)
            {
                if (GlobalData.Config._language == EnumData.Language.english)
                {
                    MessageBox.Show("Function return value error!", "Tips", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("函数返回值错误！", "提示", MessageBoxButtons.OK);
                }
            }
            ScanOutPutPort();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            int Result;
            Result = WENYU_PIO32P.WY_WriteOutPutBit6(WENYU.DevID, 0);
            if (Result != 0)
            {
                if (GlobalData.Config._language == EnumData.Language.english)
                {
                    MessageBox.Show("Function return value error!", "Tips", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("函数返回值错误！", "提示", MessageBoxButtons.OK);
                }
            }
            ScanOutPutPort();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            int Result;
            Result = WENYU_PIO32P.WY_WriteOutPutBit6(WENYU.DevID, 1);
            if (Result != 0)
            {
                if (GlobalData.Config._language == EnumData.Language.english)
                {
                    MessageBox.Show("Function return value error!", "Tips", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("函数返回值错误！", "提示", MessageBoxButtons.OK);
                }
            }
            ScanOutPutPort();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            int Result;
            Result = WENYU_PIO32P.WY_WriteOutPutBit7(WENYU.DevID, 0);
            if (Result != 0)
            {
                if (GlobalData.Config._language == EnumData.Language.english)
                {
                    MessageBox.Show("Function return value error!", "Tips", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("函数返回值错误！", "提示", MessageBoxButtons.OK);
                }
            }
            ScanOutPutPort();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            int Result;
            Result = WENYU_PIO32P.WY_WriteOutPutBit7(WENYU.DevID, 1);
            if (Result != 0)
            {
                if (GlobalData.Config._language == EnumData.Language.english)
                {
                    MessageBox.Show("Function return value error!", "Tips", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("函数返回值错误！", "提示", MessageBoxButtons.OK);
                }
            }
            ScanOutPutPort();
        }

        private void FormIOcomm_FormClosing(object sender, FormClosingEventArgs e)
        {
            WENYU_PIO32P.WY_WriteOutPutBit0(WENYU.DevID, 1);
            WENYU_PIO32P.WY_WriteOutPutBit1(WENYU.DevID, 1);
            WENYU_PIO32P.WY_WriteOutPutBit2(WENYU.DevID, 1);
            WENYU_PIO32P.WY_WriteOutPutBit3(WENYU.DevID, 1);
            WENYU_PIO32P.WY_WriteOutPutBit4(WENYU.DevID, 1);
            WENYU_PIO32P.WY_WriteOutPutBit5(WENYU.DevID, 1);
            WENYU_PIO32P.WY_WriteOutPutBit6(WENYU.DevID, 1);
            WENYU_PIO32P.WY_WriteOutPutBit7(WENYU.DevID, 1);
        }
    }
}

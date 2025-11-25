using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisionPlatform
{
    public partial class LoginTX : Form
    {
        public LoginTX()
        {
            InitializeComponent();
        }
        public bool Ba = false;
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("请输入用户名", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (textBox2.Text == "")
                {
                    MessageBox.Show("请输入密码", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {


                    if (textBox1.Text == "111" && textBox2.Text == "111")
                    {
                        Ba = true;
                        //MessageBox.Show("登录成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();

                    }
                    else
                    {
                        if (textBox1.Text != "111")
                        {
                            MessageBox.Show("请检查用户名！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            if (textBox1.Text == "111" && textBox2.Text != "111")
                            {
                                MessageBox.Show("密码错误！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                textBox2.Text = "";
                            }
                        }
                    }
                }
            }
        }
    }
}

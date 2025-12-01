using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace VisionPlatform
{
    public partial class FormLogIn : Form
    {
        FormContactUs m_formContactUs = new FormContactUs();
        public FormLogIn(FormContactUs formContactUs)
        {
            InitializeComponent();
            m_formContactUs = formContactUs;
        }

        private void but_Close_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void but_LogIn_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox_UserName.Text == "")
                {
                    MessageBox.Show("请输入用户名", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (textBox_PassWord.Text == "")
                    {
                        MessageBox.Show("请输入密码", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        if (textBox_UserName.Text == "111" && textBox_PassWord.Text == "111")
                        {
                            //MessageBox.Show("登录成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Hide();
                            FormContactEdit formEdit = new FormContactEdit(m_formContactUs);
                            formEdit.TopMost = true;
                            formEdit.ShowDialog();
                            this.Dispose();
                        }
                        else
                        {
                            if (textBox_UserName.Text != "111")
                            {
                                MessageBox.Show("请检查用户名！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                if (textBox_UserName.Text == "111" && textBox_PassWord.Text != "111")
                                {
                                    MessageBox.Show("密码错误！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    textBox_PassWord.Text = "";
                                }
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                ex.ToString();
                return;
            }
        }
    }
}

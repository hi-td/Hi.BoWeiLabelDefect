using CamSDK;
using System;
using System.Windows.Forms;

namespace VisionPlatform
{
    public partial class FormLanguage : Form
    {
        EnumData.Language m_language;
        public FormLanguage()
        {
            InitializeComponent();
        }

        private void checkBox_Chinese_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Chinese.Checked)
            {
                checkBox_English.Checked = false;
                m_language = EnumData.Language.chinese;
            }
            else
            {
                checkBox_English.Checked = true;
                m_language = EnumData.Language.english;
            }
           
        }

        private void checkBox_English_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_English.Checked)
            {
                checkBox_Chinese.Checked = false;
                m_language = EnumData.Language.english;
            }
            else
            {
                checkBox_Chinese.Checked = true;
                m_language = EnumData.Language.chinese;
            }
        }
        private void but_Save_Click(object sender, EventArgs e)
        {
            if (GlobalData.Config._language == EnumData.Language.english)
            {
                if (MessageBox.Show("After confirmation, the software will shut down, and you need to manually restart it？", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    if (!StaticFun.SaveData.SaveLanguage(m_language))
                    {
                        return;
                    }
                    CamCommon.CloseAllCam();
                    Application.ExitThread();
                    Environment.Exit(0);
                    this.Close();
                }
                else
                {
                    return;
                }
            }
            else
            {
                if (MessageBox.Show("确定后软件将关闭，需手动重启，是否确定更改？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    if (!StaticFun.SaveData.SaveLanguage(m_language))
                    {
                        return;
                    }
                    CamCommon.CloseAllCam();
                    Application.ExitThread();
                    Environment.Exit(0);
                    this.Close();
                }
                else
                {
                    return;
                }
            }


        }

        private void FormLanguage_Load(object sender, EventArgs e)
        {
            m_language = GlobalData.Config._language;
            if (m_language == EnumData.Language.chinese)
            {
                checkBox_Chinese.Checked = true;
                checkBox_English.Checked = false;
            }
            else
            {
                checkBox_Chinese.Checked = false;
                checkBox_English.Checked = true;
            }
        }
    }
}

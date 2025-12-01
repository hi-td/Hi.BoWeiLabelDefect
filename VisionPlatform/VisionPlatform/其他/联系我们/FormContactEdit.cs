using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VisionPlatform.Auxiliary;

namespace VisionPlatform
{
    public partial class FormContactEdit : Form
    {
        public string m_strCode2D = "";
        FormContactUs m_formContactUs = new FormContactUs();
        public FormContactEdit(FormContactUs formContactUs)
        {
            InitializeComponent();
            m_formContactUs = formContactUs;
        }

        private void but_Load_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog file = new OpenFileDialog();
                file.InitialDirectory = ".";
                file.Filter = "所有文件(*.*)|*.*";
                file.ShowDialog();
                if (file.FileName != string.Empty)
                {
                    try
                    {
                        m_strCode2D = file.FileName;        //获得文件的绝对路径
                        this.picBox_Code2D.Load(m_strCode2D);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }  
            }
            catch(Exception ex)
            {

            }
        }
        public BaseData.ContactData Save()
        {
            BaseData.ContactData data = new BaseData.ContactData();
            try
            {
                data.strCompanyName = textBox_company.Text;
                data.strWeb = textBox_http.Text;
                data.strAdress = textBox_address.Text;
                data.strContactName = textBox_contact.Text;
                data.strTel = textBox_tel.Text;
                data.strCode2DPath = m_strCode2D;
                data.strMail = textBox_mail.Text;
                data.strPhone = textBox_phone.Text;
            }
            catch(Exception ex)
            {
                ex.ToString();
            }
            return data;
        }
        private void but_Save_Click(object sender, EventArgs e)
        {
            m_formContactUs.RefreshData(Save());
            GlobalData.Config._Contact.contact = Save();
            StaticFun.SaveData.SaveContactData();
            this.Close();
            m_formContactUs.Show();
        }
    }
}

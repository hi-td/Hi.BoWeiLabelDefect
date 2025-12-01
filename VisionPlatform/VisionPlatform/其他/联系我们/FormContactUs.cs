using System;
using System.Windows.Forms;

namespace VisionPlatform
{
    public partial class FormContactUs : Form
    {

        FormLogIn formLogIn;
        public FormContactUs()
        {
            InitializeComponent();
        }

        private void tsBut_Edit_Click(object sender, EventArgs e)
        {
            try
            {
                if (null == formLogIn ||!formLogIn.Created || formLogIn.IsDisposed)
                {
                    formLogIn = new FormLogIn(this);
                    formLogIn.Show();
                }
            }
            catch (Exception ex)
            {

            }
        }
        public void RefreshData(BaseData.ContactData data)
        {
            try
            {
                this.label_CompanyName.Text = data.strCompanyName;
                this.label_Http.Text = data.strWeb;
                this.label_address.Text = data.strAdress;
                this.label_ContactName.Text = data.strContactName;
                this.label_Tel.Text = data.strTel;
                if(""!=data.strCode2DPath)
                    this.pictBox_Code2D.Load(data.strCode2DPath);
                if(null != data.strMail && ""!=data.strMail)
                {
                    this.panel_mail.Visible = true;
                    this.label_Textmail.Visible = true;
                    this.label_mail.Text = data.strMail;
                }
                else
                {
                    this.panel_mail.Visible = false;
                    this.label_Textmail.Visible = false;
                    this.label_mail.Text = "";
                }
                if(null != data.strPhone && "" !=data.strPhone)
                {
                    this.panel_phone.Visible = true;
                    this.label_TextPhone.Visible = true;
                    this.label_phone.Text = data.strPhone;
                }
                else
                {
                    this.panel_phone.Visible = false;
                    this.label_TextPhone.Visible = false;
                    this.label_phone.Text = "";
                }
            }
            catch(Exception ex)
            {
                ex.ToString();
            }
        }

        private void FormContactUs_Load(object sender, EventArgs e)
        {
            StaticFun.LoadConfig.LoadContactData();
            RefreshData(GlobalData.Config._Contact.contact);
        }

        private void label_Http_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                System.Diagnostics.Process.Start("http://" + GlobalData.Config._Contact.contact.strWeb);
            }
        }

        private void tSBut_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

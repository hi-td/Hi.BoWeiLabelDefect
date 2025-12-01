using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisionPlatform
{
    public partial class FormLogo : Form
    {
        string str_LogoPath = "";
        public FormLogo()
        {
            InitializeComponent();
        }


        private void FormLogo_Load(object sender, EventArgs e)
        {
            try
            {

                if (File.Exists(GlobalPath.SavePath.CompanyLogo))
                {
                    str_LogoPath = File.ReadAllText(GlobalPath.SavePath.CompanyLogo);

                }

                if ("" != str_LogoPath)
                {
                    this.picBox_Logo.SizeMode = PictureBoxSizeMode.StretchImage;
                    this.picBox_Logo.Load(str_LogoPath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void import_LOGO_Click(object sender, EventArgs e)
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
                        str_LogoPath = Path.Combine(Path.GetDirectoryName(file.FileName),    Path.GetFileName(file.FileName));
                        this.picBox_Logo.SizeMode = PictureBoxSizeMode.StretchImage;
                        this.picBox_Logo.Load(str_LogoPath);
                        File.WriteAllText(GlobalPath.SavePath.CompanyLogo, str_LogoPath);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void Del_Click(object sender, EventArgs e)
        {
            this.picBox_Logo.Image = null;
            str_LogoPath = "";
            File.WriteAllText(GlobalPath.SavePath.CompanyLogo, str_LogoPath);
        }

        private void FormLogo_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormMainUI.bLogoShow = false;
            FormMainUI.dCountTime = new TimeSpan(DateTime.Now.Ticks);
        }

        private void 填充_Click(object sender, EventArgs e)
        {
            this.picBox_Logo.Image = null;
            this.picBox_Logo.SizeMode = PictureBoxSizeMode.StretchImage;
            this.picBox_Logo.Load(str_LogoPath);
        }

        private void 按图像大小_Click(object sender, EventArgs e)
        {
            this.picBox_Logo.Image = null;
            this.picBox_Logo.SizeMode = PictureBoxSizeMode.AutoSize;
            this.picBox_Logo.Load(str_LogoPath);
        }

        private void 居中显示_Click(object sender, EventArgs e)
        {
            this.picBox_Logo.Image = null;
            this.picBox_Logo.SizeMode = PictureBoxSizeMode.CenterImage;
            this.picBox_Logo.Load(str_LogoPath);
        }

        private void 图像自适应_Click(object sender, EventArgs e)
        {
            this.picBox_Logo.Image = null;
            this.picBox_Logo.SizeMode = PictureBoxSizeMode.Zoom;
            this.picBox_Logo.Load(str_LogoPath);
        }
    }
}

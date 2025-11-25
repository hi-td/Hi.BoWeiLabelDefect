using BaseData;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace VisionPlatform
{
    public partial class FormPhotometricStereo : Form
    {
        CtrlCamShow myCtrl;
        string strCamSer;
        List<HalconDotNet.HWindowControl> myListWndCtrl = new List<HalconDotNet.HWindowControl>();
        List<HalconDotNet.HObject> myListImages = new List<HalconDotNet.HObject>();
        PhotometricStereoImage photometricStereoImage = new PhotometricStereoImage();
        public FormPhotometricStereo(CtrlCamShow ctrlCamShow)
        {
            InitializeComponent();
            this.myCtrl = ctrlCamShow;
            myListWndCtrl = new List<HalconDotNet.HWindowControl>() { hWndCtrl1, hWndCtrl2, hWndCtrl3, hWndCtrl4 };
        }

        private void tSBut_Grab_Click(object sender, System.EventArgs e)
        {
            myListImages = myCtrl.Fun.PhotometricGrabImages(myCtrl.camID, myCtrl.strCamSer, myListWndCtrl);
        }

        private void tSBut_Fusion_Click(object sender, System.EventArgs e)
        {
            if (myListImages.Count < 3) return;
            photometricStereoImage = myCtrl.Fun.PhotometricStereo(myListImages);
            MessageBox.Show("图像融合完成！");
        }

        private void Lbl_NormalField_Click(object sender, System.EventArgs e)
        {
            myCtrl.Fun.ShowImageToHWnd(photometricStereoImage.NormalField, hWndCtrl);
            myCtrl.Fun.DispRegion(photometricStereoImage.NormalField);
        }

        private void Lbl_Albedo_Click(object sender, System.EventArgs e)
        {
            myCtrl.Fun.ShowImageToHWnd(photometricStereoImage.Albedo, hWndCtrl);
            myCtrl.Fun.DispRegion(photometricStereoImage.Albedo);
        }

        private void Lbl_Gradient_Click(object sender, System.EventArgs e)
        {
            myCtrl.Fun.ShowImageToHWnd(photometricStereoImage.Gradient, hWndCtrl);
            myCtrl.Fun.DispRegion(photometricStereoImage.Gradient);
        }

        private void Lbl_Curvature_Click(object sender, System.EventArgs e)
        {
            myCtrl.Fun.ShowImageToHWnd(photometricStereoImage.Curvature, hWndCtrl);
            myCtrl.Fun.DispRegion(photometricStereoImage.Curvature);
        }

        private void Lbl_HeightField_Click(object sender, System.EventArgs e)
        {
            myCtrl.Fun.ShowImageToHWnd(photometricStereoImage.HeightField, hWndCtrl);
            myCtrl.Fun.DispRegion(photometricStereoImage.HeightField);
        }

        private void tSBut_Load_Click(object sender, System.EventArgs e)
        {
            folderBrowserDialog1.Description = "请选择一个文件夹";
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                string folderPath = folderBrowserDialog1.SelectedPath;
                string[] files = Directory.GetFiles(folderPath);
                if (files.Length >= 4)
                {
                    myCtrl.Fun.ReadImageToHWnd(files[0], hWndCtrl1);
                    myCtrl.Fun.ReadImageToHWnd(files[1], hWndCtrl2);
                    myCtrl.Fun.ReadImageToHWnd(files[2], hWndCtrl3);
                    myCtrl.Fun.ReadImageToHWnd(files[3], hWndCtrl4);
                }
                myListImages = new List<HalconDotNet.HObject>();
                for (int i = 0; i < files.Length; i++)
                {
                    myCtrl.Fun.ReadImage(files[i]);
                    myListImages.Add(myCtrl.Fun.HImage);
                }

            }

        }
    }
}

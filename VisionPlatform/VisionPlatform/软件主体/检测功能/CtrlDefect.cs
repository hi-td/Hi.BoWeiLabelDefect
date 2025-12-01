using BaseData;
using System;
using System.Windows.Forms;

namespace VisionPlatform
{
    public partial class CtrlDefect : UserControl
    {
        CtrlHome myCtrlHome;
        InspectFunction Fun;
        BaseData.Arbitrary myArbitrary = new BaseData.Arbitrary();
        PhotometricStereoImage myPhotometricStereoImages;
        bool bLoad = false;
        public CtrlDefect(CtrlHome ctrlHome)
        {
            InitializeComponent();
            this.myCtrlHome = ctrlHome;
            this.Visible = true;
            this.Dock = DockStyle.Fill;
            this.Margin = new System.Windows.Forms.Padding(0);
            InitUI();
        }
        /// <summary>
        /// 解决窗体加载慢、卡顿问题
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;              //用双缓冲绘制窗口的所有子控件
                return cp;
            }
        }
        private void InitUI()
        {
            try
            {
            }
            catch (Exception ex)
            {
                StaticFun.MessageFun.ShowMessage(ex);
            }
        }

        public InspectData.DefectParam InitParam()
        {
            InspectData.DefectParam param = new InspectData.DefectParam();
            try
            {
                param.arbitrary = myArbitrary;
                param.dBrokenScore = (double)numUpD_BrokenScore.Value;
                param.dDirtyScore = (double)(numUpD_DirtyScore.Value);
            }
            catch (Exception ex)
            {
                StaticFun.MessageFun.ShowMessage(ex);
            }
            return param;
        }

        public void LoadParam(InspectData.DefectParam param)
        {
            try
            {
                bLoad = true;
                myArbitrary = param.arbitrary;
                numUpD_BrokenScore.Value = (decimal)param.dBrokenScore;
                numUpD_DirtyScore.Value = (decimal)param.dDirtyScore;
            }
            catch (SystemException ex)
            {
                StaticFun.MessageFun.ShowMessage(ex);
            }
            bLoad = false;
        }

        private void but_Test_Click(object sender, EventArgs e)
        {
            myCtrlHome.Fun.myFrontFun.DefectAI(InitParam(), myCtrlHome.myCamItem.item, myCtrlHome.Fun.myFrontFun.ho_AIImage);
        }

        private void but_SetBrokenROI_Click(object sender, EventArgs e)
        {
            if (myCtrlHome.Fun.m_arbitrary.isEmpty())
            {
                MessageBox.Show("请先在图像窗口，鼠标右键，选择【绘制-任意形状】，绘制检测区域。");
                return;
            }
            myArbitrary = myCtrlHome.Fun.m_arbitrary;
            myCtrlHome.Fun.ShowArbitrary(myArbitrary);
        }

        private void btn_ShowBrokenROI_Click(object sender, EventArgs e)
        {
            myCtrlHome.Fun.ShowArbitrary(myArbitrary);
        }

        private void cmbBox_ImageSel_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (null == FormMainUI.m_dicCtrlCamShow[myCtrlHome.camID].formPhotometricStereo)
                {
                    return;
                }
                this.myPhotometricStereoImages = FormMainUI.m_dicCtrlCamShow[myCtrlHome.camID].formPhotometricStereo.photometricStereoImage;
                switch (cmbBox_ImageSel.Text)
                {
                    case "法向量图":
                        myCtrlHome.Fun.DispRegion(this.myPhotometricStereoImages.NormalField);
                        myCtrlHome.Fun.myFrontFun.ho_AIImage = this.myPhotometricStereoImages.NormalField.Clone();
                        break;
                    case "反照率信息图":
                        myCtrlHome.Fun.DispRegion(this.myPhotometricStereoImages.Albedo);
                        myCtrlHome.Fun.myFrontFun.ho_AIImage = this.myPhotometricStereoImages.Albedo.Clone();
                        break;
                    case "梯度信息图":
                        myCtrlHome.Fun.DispRegion(this.myPhotometricStereoImages.Gradient);
                        myCtrlHome.Fun.myFrontFun.ho_AIImage = this.myPhotometricStereoImages.Gradient.Clone();
                        break;
                    case "曲率图":
                        myCtrlHome.Fun.DispRegion(this.myPhotometricStereoImages.Curvature);
                        myCtrlHome.Fun.myFrontFun.ho_AIImage = this.myPhotometricStereoImages.Curvature.Clone();
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                StaticFun.MessageFun.ShowMessage(ex);
            }
        }
    }
}

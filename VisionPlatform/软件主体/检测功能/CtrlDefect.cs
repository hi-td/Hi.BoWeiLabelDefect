using System;
using System.Windows.Forms;

namespace VisionPlatform
{
    public partial class CtrlDefect : UserControl
    {
        CtrlHome myCtrlHome;
        InspectFunction Fun;
        BaseData.Arbitrary myArbitrary = new BaseData.Arbitrary();
        FormPhotometricStereo myPhotometricStereo;
        bool bLoad = false;
        public CtrlDefect(CtrlHome ctrlHome)
        {
            InitializeComponent();
            this.myCtrlHome = ctrlHome;
            this.Visible = true;
            this.Dock = DockStyle.Fill;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.myPhotometricStereo = FormMainUI.m_dicCtrlCamShow[ctrlHome.camID].formPhotometricStereo;
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

        private void but_SaveParam_Click(object sender, EventArgs e)
        {

        }
    }
}

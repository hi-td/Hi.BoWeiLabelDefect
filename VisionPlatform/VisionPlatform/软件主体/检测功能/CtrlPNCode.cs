using BaseData;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace VisionPlatform
{
    [ToolboxItem(false)]
    public partial class CtrlPNCode : UserControl
    {
        CtrlHome myCtrlHome;
        Rect2 m_rect2 = new Rect2();
        string myStrCode = string.Empty;
        bool bLoad;
        private event PNCodeEventHandler _valueChanged;
        public CtrlPNCode(CtrlHome ctrlHome)
        {
            InitializeComponent();
            this.myCtrlHome = ctrlHome;
            this.Visible = true;
            this.Dock = DockStyle.Fill;
            this.Margin = new System.Windows.Forms.Padding(0);
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

        public event PNCodeEventHandler ValueChanged
        {
            add { _valueChanged += value; }
            remove { _valueChanged -= value; }
        }

        public InspectData.PNCodeParam InitParam()
        {
            InspectData.PNCodeParam param = new InspectData.PNCodeParam();
            try
            {
                param.rect2ROI = m_rect2;
                param.strPNCode = myStrCode;
            }
            catch (Exception ex)
            {
                StaticFun.MessageFun.ShowMessage(ex);
            }
            return param;
        }

        public void LoadParam(InspectData.PNCodeParam param)
        {
            try
            {
                bLoad = true;
                m_rect2 = param.rect2ROI;
                label_OrgCode.Text = param.strPNCode;
                myStrCode = param.strPNCode;
            }
            catch (SystemException ex)
            {
                StaticFun.MessageFun.ShowMessage(ex);
            }
            bLoad = false;
        }

        private void Inspect(object sender, EventArgs e)
        {
            try
            {
                if (bLoad) { return; }
                this.myCtrlHome.Fun.myFrontFun.PNCodeRecognize(InitParam(), true, out string strPNCode);
                label_Code.Text = strPNCode;

            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        private void but_SetROI_Click(object sender, EventArgs e)
        {
            if (this.myCtrlHome.Fun.m_rect2.isEmpty())
            {
                MessageBox.Show("请先在图像窗口，鼠标右键，选择【绘制-矩形2】，绘制检测区域。");
                return;
            }
            m_rect2 = this.myCtrlHome.Fun.m_rect2;
            this.myCtrlHome.Fun.ShowRect2(m_rect2);
        }

        private void but_ShowROI_Click(object sender, EventArgs e)
        {
            this.myCtrlHome.Fun.ShowRect2(m_rect2);
        }

        private void but_SaveParam_Click(object sender, EventArgs e)
        {
            myStrCode = label_Code.Text;
            if (label_OrgCode.Text == "原码")
            {
                label_OrgCode.Text = myStrCode;
            }
            MessageBox.Show("保存成功！");
        }
    }
}

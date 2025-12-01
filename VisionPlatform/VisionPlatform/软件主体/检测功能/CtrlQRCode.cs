using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static VisionPlatform.InspectData;

namespace VisionPlatform
{
    public partial class CtrlQRCode : UserControl
    {
        CtrlHome myCtrlHome;
        object m_hvCode2DHandle = new object();   //二维码识别模型句柄
        bool bLoad;
        string myStrCode = string.Empty;
        public CtrlQRCode(CtrlHome ctrlHome)
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
                m_hvCode2DHandle = (object)this.myCtrlHome.Fun.ReadCode2dModel(myCtrlHome.camID);
            }
            catch (Exception ex)
            {
                StaticFun.MessageFun.ShowMessage(ex);
            }
        }
        public InspectData.QRCodeParam InitParam()
        {
            InspectData.QRCodeParam param = new InspectData.QRCodeParam();
            try
            {
                param.strCodeType = cb_CodeType.Text;
                param.hv_Handel = m_hvCode2DHandle;
                param.strCode = myStrCode;
                param.nCodeLength = (int)num_COdeLength.Value;
                param.nCodeCaptureLength = (int)num_COdeCaptureLength.Value;
            }
            catch (Exception ex)
            {
                StaticFun.MessageFun.ShowMessage(ex);
            }
            return param;
        }

        public void LoadParam(QRCodeParam param)
        {
            try
            {
                bLoad = true;
                cb_CodeType.Text = param.strCodeType;
                label_OrgCode.Text = param.strCode;
                myStrCode = param.strCode;
                m_hvCode2DHandle = param.hv_Handel;
                num_COdeCaptureLength.Value = param.nCodeCaptureLength;
                num_COdeLength.Value = param.nCodeLength;

            }
            catch (SystemException ex)
            {
                StaticFun.MessageFun.ShowMessage(ex);
            }
            bLoad = false;
        }

        private void Test_Btn_Click(object sender, EventArgs e)
        {
            label_Code.Text = "";
            this.myCtrlHome.Fun.ClearObjShow();
            if (this.myCtrlHome.Fun.FindCode2D((HTuple)m_hvCode2DHandle, out List<string> listStrings))
            {
                this.myCtrlHome.Fun.WriteStringtoImage(22, 50, 100, listStrings[0]);
                label_Code.Text = listStrings[0];
                num_COdeLength.Value = listStrings[0].Length;
            }
        }

        private void but_Create_Click(object sender, EventArgs e)
        {
            try
            {
                if ("" == cb_CodeType.Text)
                {
                    MessageBox.Show("请先选择一种二维码类型。");
                    return;
                }
                if (this.myCtrlHome.Fun.CreateCode2dModel(myCtrlHome.camID, cb_CodeType.Text, out HTuple hv_Code2DHandle))
                {
                    m_hvCode2DHandle = (object)hv_Code2DHandle;
                    MessageBox.Show("模型创建成功！");
                }
            }
            catch (Exception ex)
            {
                StaticFun.MessageFun.ShowMessage($"模型创建失败：{ex}");
            }
        }

        private void but_Save_Click(object sender, EventArgs e)
        {
            myStrCode = label_Code.Text;
            if (label_OrgCode.Text == "原码内容")
            {
                label_OrgCode.Text = myStrCode;
            }
            MessageBox.Show("保存成功！");
        }

        private void but_SetROI_Click(object sender, EventArgs e)
        {

        }
    }
}

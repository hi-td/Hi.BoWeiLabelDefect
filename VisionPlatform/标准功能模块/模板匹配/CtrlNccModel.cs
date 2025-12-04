using BaseData;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace VisionPlatform
{
    public partial class CtrlNccModel : UserControl
    {
        Rect2 m_rect2;
        Function Fun;
        public object nModelID = -1;
        int myCamID = -1;
        string myModelName = string.Empty;
        private event CtrlNccModelEventHandler _valueChanged;
        public event CtrlNccModelEventHandler ValueChanged
        {
            add { _valueChanged += value; }
            remove { _valueChanged -= value; }
        }
        public CtrlNccModel()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            this.Visible = true;
            this.Padding = new Padding(0);
        }
        public void UpdateFun(Function fun, int camID, string strModelName)
        {
            this.Fun = fun;
            this.myCamID = camID;
            this.myModelName = strModelName;
        }
        private void but_CreateNCCModel_Click(object sender, EventArgs e)
        {
            try
            {
                if (0 == Fun.m_rect2.dLength1 && 0 == Fun.m_rect2.dLength2)
                {
                    MessageBox.Show("请先在图像窗口-鼠标右键-绘制，选择【矩形2】绘制模板区域");
                    return;
                }
                m_rect2 = Fun.m_rect2;
                Fun.m_lastDraw = ObjDraw.rect2;
                NccLocateParam param = InitParam();
                if (Fun.CreateNccModel(param.modelData, out nModelID, out List<LocateOutParams> listOutData))
                {
                    Fun.NccLocate(param.modelData, nModelID, m_rect2, out _);
                    if (Fun.WriteModel(myCamID, param.modelData.strModelName, param.modelData.modelType, nModelID))
                    {
                        MessageBox.Show("模板创建成功");
                    }
                    else
                    {
                        MessageBox.Show("模板创建失败");
                    }
                }
            }
            catch (SystemException ex)
            {
                MessageBox.Show($"模板创建失败:{ex}");
                return;
            }
        }

        private void but_TestNccModel_Click(object sender, EventArgs e)
        {
            try
            {
                Fun.ClearObjShow();
                Fun.DispRegion(Fun.HImage);
                Fun.NccLocate(InitParam().modelData, nModelID, m_rect2, out _);
            }
            catch (SystemException ex)
            {
                MessageBox.Show($"模板匹配失败:{ex}");
                return;
            }
        }

        public BaseData.NccLocateParam InitParam()
        {
            BaseData.NccLocateParam param = new BaseData.NccLocateParam();
            try
            {
                param.modelData = new LocateInParams()
                {
                    modelType = ModelType.ncc,
                    dAngleStart = -45,
                    dAngleEnd = 180,
                    bScale = false,
                    strModelName = this.myModelName,
                    dScore = (double)numUpD_Score.Value,
                };
                param.nModelID = nModelID;
                param.rect2 = m_rect2;
            }
            catch (Exception ex)
            {
                StaticFun.MessageFun.ShowMessage(ex);
            }
            return param;
        }
        public void LoadParam(BaseData.NccLocateParam param)
        {
            try
            {
                numUpD_Score.Value = (decimal)(param.modelData.dScore == 0 ? 0.65 : param.modelData.dScore);
                this.nModelID = param.nModelID;
                m_rect2 = param.rect2;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"LoadParam:{ex}");
            }
        }
    }
}

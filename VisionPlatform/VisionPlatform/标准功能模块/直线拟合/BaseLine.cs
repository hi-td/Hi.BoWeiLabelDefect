using System;
using System.Windows.Forms;

namespace VisionPlatform
{
    public partial class BaseLine : UserControl
    {
        int m_Cam;
        //FormRubberInsert m_formRubber;
        InspectData.BaseLineParam m_baseLineParam = new InspectData.BaseLineParam();
        bool bLoad = false;
        /// <summary>
        /// 设定基准参考线，用于计算端子到基准线的距离
        /// </summary>
        /// <param name="id"></param>           第camID个相机的插壳检测
        /// <param name="formRubber"></param> 
        /// <param name="baseLineParam"></param> 用于初始化界面数据
        public BaseLine(int camID,  InspectData.BaseLineParam baseLineParam)
        {
            InitializeComponent();
            m_Cam = camID;
           // this.m_formRubber = formRubber;
            m_baseLineParam = baseLineParam;
            bLoad = true;
            comboBox_Transition.SelectedIndex = 0;
            comboBox_Direction.SelectedIndex = 0;
            bLoad = false;
        }
        private void ValueChanged(object sender, EventArgs e)
        {
            if (bLoad) return;
            //InitParam();
            sender.RubberValueChanged(e);
            return;
            //if (myType == InspectType.defect)
            //{
            //    sender.DefectValueChanged(e);
            //    return;
            //}
            //else if (myType == InspectType.pinFoot)
            //{
            //    sender.PinFootValueChanged(e);
            //    return;
            //}
            //else if (myType == InspectType.pinHole)
            //{
            //    sender.PinHoleValueChanged(e);
            //    return;
            //}
            //else if (myType == InspectType.colorDiff)
            //{
            //    sender.ColorDiffValueChanged(e);
            //    return;
            //}
            //else if (myType == InspectType.groundLug)
            //{
            //    sender.GroundLugValueChanged(e);
            //    return;
            //}
        }

        public InspectData.BaseLineParam InitParam()
        {
            InspectData.BaseLineParam param = new InspectData.BaseLineParam();
            try
            {
                #region 基准线
                param.bBaseLine = true;
                param.nLen1 = (int)numUpD_BaseLineWidth.Value;
                trackBar_BaseLineWidth.Value = (int)numUpD_BaseLineWidth.Value;
                param.nLen2 = (int)numUpD_BaseLineHeight.Value;
                trackBar_BaseLineHeight.Value = (int)numUpD_BaseLineHeight.Value;
                param.nMoveX = (int)numUpD_BaseLineMoveX.Value;
                trackBar_BaseLineMoveX.Value = (int)(numUpD_BaseLineMoveX.Value);
                param.nMoveY = (int)numUpD_BaseLineMoveY.Value;
                trackBar_BaseLineMoveY.Value = (int)((numUpD_BaseLineMoveY.Value));
                //灰度变化
                if (comboBox_Transition.SelectedIndex == 0)
                {
                    param.strTransiton = "从暗到亮";
                }
                else if (comboBox_Transition.SelectedIndex == 1)
                {
                    param.strTransiton = "从亮到暗";
                }
                else
                {
                    param.strTransiton = "从亮到暗";
                }
                //拟合方向
                if (comboBox_Direction.SelectedIndex == 0)
                {
                    param.strDirection = "从左往右";
                }
                else if (comboBox_Direction.SelectedIndex == 1)
                {
                    param.strDirection = "从右往左";
                }
                else
                {
                    param.strDirection = "从左往右";
                }
                //变化点
                if (comboBox_TransPoint.SelectedIndex == 0)
                {
                    param.strPoint = "first";
                }
                else if (comboBox_TransPoint.SelectedIndex == 1)
                {
                    param.strPoint = "last";
                }
                else
                {
                    param.strPoint = "first";
                }
                param.nThd = (int)numUpD_BaseLineThd.Value;
                #endregion
                //m_formRubber.baseLineParam = param;
                //if (myType == InspectType.pinFoot)
                //{
                //    var item = formDefect2.m_listPinFootItems[ID - 1];
                //    item.baseLine = param;
                //    formDefect2.m_listPinFootItems[ID - 1] = item;
                //}
                //else if (myType == InspectType.groundLug)
                //{
                //    var item = formDefect2.m_listGroundLugItems[ID - 1];
                //    item.baseLine = param;
                //    formDefect2.m_listGroundLugItems[ID - 1] = item;
                //}
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return param;
        }

        public void LoadParam(InspectData.BaseLineParam param)
        {
            try
            {
                bLoad = true;
                numUpD_BaseLineWidth.Value = (decimal)param.nLen1;
                trackBar_BaseLineWidth.Value = param.nLen1;
                numUpD_BaseLineHeight.Value = (decimal)param.nLen2;
                trackBar_BaseLineHeight.Value = param.nLen2;
                numUpD_BaseLineMoveX.Value = (decimal)param.nMoveX;
                trackBar_BaseLineMoveX.Value = param.nMoveX;
                numUpD_BaseLineMoveY.Value = (decimal)param.nMoveY;
                trackBar_BaseLineMoveY.Value = param.nMoveY;
                if (null != param.strDirection)
                {
                    if ("从左往右" == param.strDirection)
                    {
                        comboBox_Direction.SelectedIndex = 0;
                    }
                    else if ("从右往左" == param.strDirection)
                    {
                        comboBox_Direction.SelectedIndex = 1;
                    }
                }
                else
                {
                    comboBox_Transition.SelectedIndex = 0;
                }
                if (null != param.strTransiton)
                {
                    if ("从暗到亮" == param.strTransiton)
                    {
                        comboBox_Transition.SelectedIndex = 0;
                    }
                    else if ("从亮到暗" == param.strTransiton)
                    {
                        comboBox_Transition.SelectedIndex = 1;
                    }
                }
                else
                {
                    comboBox_Direction.SelectedIndex = 0;
                }
                //变化点
                if (null != param.strPoint)
                {
                    if("first" == param.strPoint) 
                    {
                        comboBox_TransPoint.SelectedIndex = 0;
                    }
                    else if("last" == param.strPoint)
                    {
                        comboBox_TransPoint.SelectedIndex = 1;
                    }
                }
                else 
                {
                    comboBox_TransPoint.SelectedIndex = 0;
                }

                if (0 != param.nThd)
                {
                    numUpD_BaseLineThd.Value = param.nThd;
                }
            }
            catch (Exception ex)
            {
                StaticFun.MessageFun.ShowMessage("相机" + m_Cam.ToString() + "【插壳检测】基准线参数加载错误：" + ex.ToString());
            }
            bLoad = false;
        }

        private void BaseLine_Load(object sender, EventArgs e)
        {
            LoadParam(m_baseLineParam);
        }

        private void trackBar_BaseLineHeight_Scroll(object sender, EventArgs e)
        {
            numUpD_BaseLineHeight.Value = trackBar_BaseLineHeight.Value;
        }

        private void trackBar_BaseLineWidth_Scroll(object sender, EventArgs e)
        {
            numUpD_BaseLineWidth.Value = trackBar_BaseLineWidth.Value;
        }

        private void trackBar_BaseLineMoveX_Scroll(object sender, EventArgs e)
        {
            numUpD_BaseLineMoveX.Value = trackBar_BaseLineMoveX.Value;
        }

        private void trackBar_BaseLineMoveY_Scroll(object sender, EventArgs e)
        {
            numUpD_BaseLineMoveY.Value = trackBar_BaseLineMoveY.Value;
        }

        private void trackBar_BaseLineThd_Scroll(object sender, EventArgs e)
        {
            numUpD_BaseLineThd.Value = trackBar_BaseLineThd.Value;
        }
    }
}

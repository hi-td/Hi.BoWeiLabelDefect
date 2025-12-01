using StaticFun;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace VisionPlatform
{
    public partial class XYCalib : UserControl
    {
        private int m_cam;                   //第几个相机
        private InspectFunction Fun;                //对应的Function
        private string str_CamSer;           //对应的相机序列号
        // BaseData.Rect2 m_rect2;

        PointF x_start = new PointF();
        PointF x_end = new PointF();
        PointF y_start = new PointF();
        PointF y_end = new PointF();
        double dCalibVal_x, dCalibVal_y;
        public XYCalib(int camID)
        {
            InitializeComponent();
            m_cam = camID;
            Fun = UIConfig.RefreshFun(camID, out str_CamSer);
            LoadParam();
        }
        bool bLoad = false;
        private void LoadParam()
        {
            try
            {
                /*导入检测参数*/
                if (null != DataSerializer._globalCalib.dic_XYCalibParam &&
                   DataSerializer._globalCalib.dic_XYCalibParam.ContainsKey(m_cam))
                {

                    BaseData.XYCalibParam param = DataSerializer._globalCalib.dic_XYCalibParam[m_cam];
                    bLoad = true;
                    textBox_XStartRow.Text = param.calibX.line.dStartRow.ToString();
                    textBox_XStartCol.Text = param.calibX.line.dStartCol.ToString();
                    textBox_XEndRow.Text = param.calibX.line.dEndRow.ToString();
                    textBox_XEndCol.Text = param.calibX.line.dEndCol.ToString();
                    textBox_XCalibVal.Text = param.calibX.dCalibVal.ToString();
                    textBox_XAngleX.Text = param.calibX.dAngleCol.ToString();
                    textBox_XAngleY.Text = param.calibX.dAngleRow.ToString();

                    textBox_YStartRow.Text = param.calibY.line.dStartRow.ToString();
                    textBox_YStartCol.Text = param.calibY.line.dStartCol.ToString();
                    textBox_YEndRow.Text = param.calibY.line.dEndRow.ToString();
                    textBox_YEndCol.Text = param.calibY.line.dEndCol.ToString();
                    textBox_YCalibVal.Text = param.calibY.dCalibVal.ToString();
                    textBox_YAngleX.Text = param.calibY.dAngleCol.ToString();
                    textBox_YAngleY.Text = param.calibY.dAngleRow.ToString();
                    bLoad = false;
                }
            }
            catch (SystemException ex)
            {
                ex.ToString();
                return;
            }
        }

        private void but_XStart_Click(object sender, EventArgs e)
        {
            //CutBeforeParam param = TMData_Serializer._globalData.m_cutBeforeParam;
            //param.rect1 = Fun.m_rect1;
            //param.nThd = (int)numUpD_Thd.Value;
            //if (TMFun.GetModelPoint(param, out CenterParam center))
            //{
            //    textBox_XStartRow.Text = center.point.Y.ToString();
            //    textBox_XStartCol.Text = center.point.X.ToString();
            //    x_start = center.point;
            //}
        }

        private void but_XEnd_Click(object sender, EventArgs e)
        {
            //CutBeforeParam param = TMData_Serializer._globalData.m_cutBeforeParam;
            //param.rect1 = Fun.m_rect1;
            //param.nThd = (int)numUpD_Thd.Value;
            //if (TMFun.GetModelPoint(param, out CenterParam center))
            //{
            //    textBox_XEndRow.Text = center.point.Y.ToString();
            //    textBox_XEndCol.Text = center.point.X.ToString();
            //    x_end = center.point;
            //}

        }

        private void but_YStart_Click(object sender, EventArgs e)
        {
           // Fun.GetCenterPoint(out y_start);
            textBox_YStartRow.Text = y_start.Y.ToString();
            textBox_YStartCol.Text = y_start.X.ToString();
        }

        private void but_YEnd_Click(object sender, EventArgs e)
        {
           // Fun.GetCenterPoint(out y_end);
            textBox_YEndRow.Text = y_end.Y.ToString();
            textBox_YEndCol.Text = y_end.X.ToString();
        }

        private void but_XCalib_Click(object sender, EventArgs e)
        {
            double[] pMm = new double[2];
            pMm[0] = (double)num_XStart.Value;
            pMm[1] = (double)num_XEnd.Value;
            #region 可输入点
            PointF pointStart = new PointF();
            pointStart.X = float.Parse(textBox_XStartCol.Text);
            pointStart.Y = float.Parse(textBox_XStartRow.Text);
            x_start = pointStart;
            PointF pointEnd = new PointF();
            pointEnd.X = float.Parse(textBox_XEndCol.Text);
            pointEnd.Y = float.Parse(textBox_XEndRow.Text);
            x_end = pointEnd;
            #endregion
            if (Fun.GetCalibVal(x_start, x_end, pMm, out dCalibVal_x, out double dAngleX, out double dAngleY))
            {
                textBox_XCalibVal.Text = dCalibVal_x.ToString();
                textBox_XAngleX.Text = dAngleX.ToString();
                textBox_XAngleY.Text = dAngleY.ToString();
            }
        }

        private BaseData.XYCalibParam InitCalibParam()
        {
            BaseData.XYCalibParam param = new BaseData.XYCalibParam();
            try
            {
                param.calibX.line.dStartRow = double.Parse(textBox_XStartRow.Text);
                param.calibX.line.dStartCol = double.Parse(textBox_XStartCol.Text);
                param.calibX.line.dEndRow = double.Parse(textBox_XEndRow.Text);
                param.calibX.line.dEndCol = double.Parse(textBox_XEndCol.Text);
                param.calibX.dCalibVal = dCalibVal_x;
                param.calibX.dAngleCol = double.Parse(textBox_XAngleX.Text);
                param.calibX.dAngleRow = double.Parse(textBox_XAngleY.Text);
                param.calibY.line.dStartRow = double.Parse(textBox_YStartRow.Text);
                param.calibY.line.dStartCol = double.Parse(textBox_YStartCol.Text);
                param.calibY.line.dEndRow = double.Parse(textBox_YEndRow.Text);
                param.calibY.line.dEndCol = double.Parse(textBox_YEndCol.Text);
                param.calibY.dCalibVal = dCalibVal_y;
                param.calibY.dAngleCol = double.Parse(textBox_YAngleX.Text);
                param.calibY.dAngleRow = double.Parse(textBox_YAngleY.Text);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return param;
        }


        private void but_YCalibSave_Click(object sender, EventArgs e)
        {

        }

        private void FormCalib_Load(object sender, EventArgs e)
        {

        }

        private void numUpD_Thd_ValueChanged(object sender, EventArgs e)
        {
            //CutBeforeParam param = TMData_Serializer._globalData.m_cutBeforeParam;
            //param.rect1 = Fun.m_rect1;
            //param.nThd = (int)numUpD_Thd.Value;
            //TMFun.GetModelPoint(param, out CenterParam center);
        }

        private void trackBar_Thd_Scroll(object sender, EventArgs e)
        {
            numUpD_Thd.Value = trackBar_Thd.Value;
        }

        private void but_YCalibSave_Click_1(object sender, EventArgs e)
        {

        }

        private void but_YCalib_Click(object sender, EventArgs e)
        {
            double[] pMm = new double[2];
            pMm[0] = (double)num_YStart.Value;
            pMm[1] = (double)num_YEnd.Value;

            #region 可输入点
            PointF pointStart = new PointF();
            pointStart.X = float.Parse(textBox_YStartCol.Text);
            pointStart.Y = float.Parse(textBox_YStartRow.Text);
            y_start = pointStart;
            PointF pointEnd = new PointF();
            pointEnd.X = float.Parse(textBox_YEndCol.Text);
            pointEnd.Y = float.Parse(textBox_YEndRow.Text);
            y_end = pointEnd;
            #endregion

            if (Fun.GetCalibVal(y_start, y_end, pMm, out dCalibVal_y, out double dAngleX, out double dAngleY))
            {
                textBox_YCalibVal.Text = dCalibVal_y.ToString();
                textBox_YAngleX.Text = dAngleX.ToString();
                textBox_YAngleY.Text = dAngleY.ToString();
            }

        }
    }
}

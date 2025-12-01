using System;
using System.Windows.Forms;
using static VisionPlatform.InspectData;

namespace VisionPlatform
{
    public partial class CtrlColorMethod : UserControl
    {
        Function Fun;
        public CtrlColorMethod()
        {
            InitializeComponent();
            this.Visible = true;
            this.Margin = new Padding(0);
        }
        public void UpdateFun(Function fun)
        {
            this.Fun = fun;
            ctrlColorTrain.UpdateFun(fun);
            ctrlColorTrain_Add.UpdateFun(fun);
            ctrlColorSpaceThd.UpdateFun(fun);
        }
        private void InitUI(int colorID, ColorData colorData)
        {
            try
            {
               // LoadParam(colorData);
            }
            catch (Exception ex)
            {
                StaticFun.MessageFun.ShowMessage(ex);
            }
        }
        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CheckBox cb = sender as CheckBox;
                if (cb.Text.Contains("训练"))
                {
                    if (cb.Checked)
                    {
                        checkBox_ColorSpaceThd.Checked = false;
                        checkBox_AddNew.Checked = false;
                    }
                }
                else if (cb.Text.Contains("颜色空间"))
                {
                    if (cb.Checked)
                    {
                        checkBox_Train.Checked = false;
                        checkBox_AddNew.Checked = false;
                    }
                }
                else if (cb.Text.Contains("新增"))
                {
                    if (checkBox_AddNew.Checked)
                    {
                        checkBox_ColorSpaceThd.Checked = false;
                        checkBox_Train.Checked = false;
                    }
                }
                tabPage_Train.Parent = checkBox_Train.Checked ? tabCtrl : null;
                tabPage_AddNew.Parent = checkBox_AddNew.Checked ? tabCtrl : null;
                tabPage_colorSpaceThd.Parent = checkBox_ColorSpaceThd.Checked ? tabCtrl : null;
                tabCtrl.Refresh();
            }
            catch(Exception ex)
            {
                ex.ToString();
            }
        }

        public ColorData InitParam()
        {
            ColorData param = new ColorData();
            try
            {
                if (checkBox_Train.Checked)
                {
                    param.method = ColorMethod.Train;
                    param.colorTrain = ctrlColorTrain.InitParam();
                }
                else if (checkBox_ColorSpaceThd.Checked)
                {
                    param.method = ColorMethod.ColorSpace;
                    param.colorSpace = ctrlColorSpaceThd.InitParam();
                }
                else if (checkBox_AddNew.Checked)
                {
                    param.method = ColorMethod.AddNew;
                    param.colorAdd = ctrlColorTrain_Add.InitParam();
                }
                else
                {
                    param.method = ColorMethod.Defult;
                }
                param.bAdd = checkBox_AddNew.Checked;
            }
            catch (Exception ex)
            {
                StaticFun.MessageFun.ShowMessage(ex);
            }
            return param;
        }
        public void LoadParam(ColorData data)
        {
            try
            {
                switch (data.method)
                {
                    case ColorMethod.Train:
                        checkBox_Train.Checked = true;
                        checkBox_AddNew.Checked = false;
                        checkBox_ColorSpaceThd.Checked = false;
                        break;
                    case ColorMethod.ColorSpace:
                        checkBox_ColorSpaceThd.Checked = true;
                        checkBox_AddNew.Checked = false;
                        checkBox_Train.Checked = false;
                        break;
                    case ColorMethod.AddNew:
                        checkBox_AddNew.Checked = true;
                        checkBox_Train.Checked = false;
                        checkBox_ColorSpaceThd.Checked = false;
                        break;
                    default:
                        break;
                }
                tabPage_Train.Parent = checkBox_Train.Checked ? tabCtrl : null;
                tabPage_colorSpaceThd.Parent = checkBox_ColorSpaceThd.Checked ? tabCtrl : null;
                tabPage_AddNew.Parent = checkBox_AddNew.Checked ? tabCtrl : null;
                tabCtrl.Refresh();
            }
            catch(Exception ex)
            {

            }
        }

        private void but_Save_Click(object sender, EventArgs e)
        {
            try
            {
                ColorData colorData = new ColorData();
                //colorData.side = this.m_sideType;
                colorData.method = checkBox_ColorSpaceThd.Checked ? ColorMethod.ColorSpace : ColorMethod.Train;
                //if (colorData.method == ColorMethod.ColorSpace)
                //{
                //    colorData.colorSpace = formColorSpace.InitParam();
                //}
                //else if (colorData.method == ColorMethod.EnhanceTrain)
                //{
                //    colorData.colorTrain = formColorTrain.InitParam();
                //}
                //if (null != main.m_dicColor && main.m_dicColor.ContainsKey(m_strColor))
                //{
                //    main.m_dicColor[m_strColor] = colorData;
                //}
                //else
                //{
                //    main.m_dicColor.Add(m_strColor, colorData);
                //}
                MessageBox.Show("颜色空间数据保存成功！");
            }
            catch (Exception ex)
            {
                MessageBox.Show("颜色空间数据保存失败！" + ex.ToString());
            }
        }
    }
    
}

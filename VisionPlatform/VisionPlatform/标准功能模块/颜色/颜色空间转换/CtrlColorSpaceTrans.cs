using BaseData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisionPlatform
{
    /// <summary>
    ///图像颜色空间转换及相应颜色空间单张图像的显示、两个颜色空间图像的叠加显示
    /// </summary>
    public partial class CtrlColorSpaceTrans : UserControl
    {
        Function Fun;
        bool bLoad = false;
       
        public CtrlColorSpaceTrans()
        {
            InitializeComponent();
            this.Visible = true;
            this.Margin = new Padding(0);
        }
        public void UpdateFun(Function fun)
        {
            this.Fun = fun;
        }
       
        public ColorSpaceTransParam InitParam()
        {
            ColorSpaceTransParam param = new ColorSpaceTransParam();
            try
            {
                bLoad = true;
                param.strColorSpace = "hsv";
                if ("" != cmbBox_ColorSpace.Text)
                {
                    param.strColorSpace = cmbBox_ColorSpace.Text;
                }
                param.arrayImageChannels = TransImageChecked();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            bLoad = false;
            return param;
        }
        public void LoadParam(ColorSpaceTransParam param)
        {
            bLoad = true;
            try
            {
                
                if (param.strColorSpace == "hsv")
                {
                    cmbBox_ColorSpace.SelectedIndex = 0;
                }
                else if (param.strColorSpace == "hsi")
                {
                    cmbBox_ColorSpace.SelectedIndex = 1;
                }
                else
                {
                    cmbBox_ColorSpace.Text = "hsv";
                }
                if (null != param.arrayImageChannels)
                {
                    checkBox_Cont.Checked = param.arrayImageChannels[0];
                    checkBox_gray.Checked = param.arrayImageChannels[1];
                    checkBox_imageR.Checked = param.arrayImageChannels[2];
                    checkBox_imageG.Checked = param.arrayImageChannels[3];
                    checkBox_imageB.Checked = param.arrayImageChannels[4];
                    checkBox_image1.Checked = param.arrayImageChannels[5];
                    checkBox_image2.Checked = param.arrayImageChannels[6];
                    checkBox_image3.Checked = param.arrayImageChannels[7];
                }
                else
                {
                    checkBox_Cont.Checked = false;
                    checkBox_gray.Checked = false;
                    checkBox_imageR.Checked = false;
                    checkBox_imageG.Checked = false;
                    checkBox_imageB.Checked = false;
                    checkBox_image1.Checked = false;
                    checkBox_image2.Checked = false;
                    checkBox_image3.Checked = false;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            bLoad = false;
        }
        public void checkBox_Images_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                var obj = this;
                if (bLoad) return;
                CheckBox cb = (CheckBox)sender;
                if (null != cb && cb.Checked)
                {
                    foreach (Control control in tLPanel_colorSpace.Controls)
                    {
                        CheckBox ctrl = control as CheckBox;
                        if (ctrl.Text != cb.Text)
                        {
                            ctrl.Checked = false;
                        }
                    }
                }
                ColorSpaceTransParam param = InitParam();
                if (null == param.arrayImageChannels) return;
                if (null != Fun) Fun.SpaceTransImage(param, true);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        public bool[] TransImageChecked()
        {
            bool[] arrayBool = new bool[8];
            try
            {
                arrayBool[0] = checkBox_Cont.Checked;       //轮廓图像
                arrayBool[1] = checkBox_gray.Checked;       //灰度图像
                if (checkBox_imageR.Checked)
                {
                    arrayBool[2] = true;
                }
                if (checkBox_imageG.Checked)
                {
                    arrayBool[3] = true;
                }
                if (checkBox_imageB.Checked)
                {
                    arrayBool[4] = true;
                }
                if (checkBox_image1.Checked)
                {
                    arrayBool[5] = true;
                }
                if (checkBox_image2.Checked)
                {
                    arrayBool[6] = true;
                }
                if (checkBox_image3.Checked)
                {
                    arrayBool[7] = true;
                }
            }
            catch (Exception ex)
            {
                StaticFun.MessageFun.ShowMessage(ex);
            }
            return arrayBool;
        }

    }
}

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
    public partial class RectROIMove : UserControl
    {
        bool bLoad = false;
        private event RectROIMoveEventHandler _valueChanged;
        public RectROIMove()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            this.Visible = true;
            this.Padding = new Padding(0);
        }

        public event RectROIMoveEventHandler ValueChanged
        {
            add { _valueChanged += value; }
            remove { _valueChanged -= value; }
        }

        public BaseData.RectROIMove InitParam()
        {
            BaseData.RectROIMove param = new BaseData.RectROIMove();
            try
            {
                //检测框宽
                param.nWidth = (int)numUpD_Width.Value;
                trackBar_Width.Value = (int)numUpD_Width.Value;
                //检测框高
                param.nHeight = (int)numUpD_Height.Value;
                trackBar_Height.Value = (int)numUpD_Height.Value;
                //检测框水平移动
                param.nXMove = (int)numUpD_XMove.Value;
                trackBar_XMove.Value = (int)numUpD_XMove.Value;
                //检测框垂直移动
                param.nYMove = (int)numUpD_YMove.Value;
                trackBar_YMove.Value = (int)numUpD_YMove.Value;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return param;
        }

        public void LoadParam(BaseData.RectROIMove param)
        {
            try
            {
                //检测框宽
                numUpD_Width.Value = param.nWidth != 0 ? param.nWidth : 50;
                trackBar_Width.Value = (int)numUpD_Width.Value;
                //检测框高
                numUpD_Height.Value = param.nHeight != 0 ? param.nHeight : 0;
                trackBar_Height.Value = (int)numUpD_Height.Value;
                //检测框水平移动
                numUpD_XMove.Value = param.nXMove != 0 ? param.nXMove : 5;
                trackBar_XMove.Value = (int)numUpD_XMove.Value;
                //检测框垂直移动
                numUpD_YMove.Value = param.nYMove != 0 ? param.nYMove : 0;
                trackBar_YMove.Value = (int)numUpD_YMove.Value;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        private void Inspect(object sender, EventArgs e)
        {
            try
            {
                if (bLoad) { return; }
                _valueChanged?.Invoke(sender, e);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        private void trackBar_Width_Scroll(object sender, EventArgs e)
        {
            numUpD_Width.Value = trackBar_Width.Value;
        }

        private void trackBar_Height_Scroll(object sender, EventArgs e)
        {
            numUpD_Height.Value = trackBar_Height.Value;
        }

        private void trackBar_XMove_Scroll(object sender, EventArgs e)
        {
            numUpD_XMove.Value = trackBar_XMove.Value;
        }

        private void trackBar_YMove_Scroll(object sender, EventArgs e)
        {
            numUpD_YMove.Value = trackBar_YMove.Value;
        }
    }
}

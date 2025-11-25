using BaseData;
using EnumData;
using GlobalPath;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using static VisionPlatform.InspectData;

namespace VisionPlatform
{
    [ToolboxItem(true)]
    public partial class CtrlColorTrain : UserControl
    {
        private event CtrlColorTrainEventHandler _valueChanged;
        Function Fun;
        bool bLoad = false;                                     //是否正在加载序列化数据
        public List<Rect2> listRect2ROIs = new List<Rect2>();   //颜色训练区域集合
        public ColorID m_ColorID = new ColorID();               //颜色模板ID
        public CtrlColorTrain()
        {
            InitializeComponent();
            this.Visible = true;
            //this.Dock = DockStyle.Fill;
            this.Margin = new Padding(0);
        }
        public event CtrlColorTrainEventHandler ValueChanged
        {
            add { _valueChanged += value; }
            remove { _valueChanged -= value; }
        }
        public void UpdateFun(Function fun)
        {
            this.Fun = fun;
        }
        public ColorTrainData InitParam(bool bSave = true)
        {
            ColorTrainData param = new ColorTrainData();
            try
            {
                param.colorID = m_ColorID;
                param.dRejThd = (double)numUpD_RejThd.Value;
            }
            catch (Exception ex)
            {
                StaticFun.MessageFun.ShowMessage(ex);
            }
            return param;
        }
        public void LoadParam(ColorTrainData param)
        {
            try
            {
                bLoad = true;
                m_ColorID = param.colorID;
                numUpD_RejThd.Value = param.dRejThd == 0 ? (decimal)0.05 : (decimal)param.dRejThd;
            }
            catch (Exception ex)
            {
                StaticFun.MessageFun.ShowMessage(ex);
            }
            bLoad = false;
        }

        private void but_Add_Click(object sender, EventArgs e)
        {
            try
            {
                if (0 == Fun.m_rect2.dLength1 && 0 == Fun.m_rect2.dLength2)
                {
                    MessageBox.Show("请先绘制一个区域");
                    return;
                }
                if (null == listRect2ROIs)
                {
                    listRect2ROIs = new List<Rect2>();
                }
                listRect2ROIs.Add(Fun.m_rect2);
                Fun.m_rect2 = new Rect2();
                comboBox_ColorRegion.Items.Clear();
                for (int n = 0; n < listRect2ROIs.Count; n++)
                {
                    comboBox_ColorRegion.Items.Add("区域" + (n + 1).ToString());
                }
                comboBox_ColorRegion.SelectedIndex = comboBox_ColorRegion.Items.Count - 1;
            }
            catch (Exception ex)
            {
                StaticFun.MessageFun.ShowMessage(ex);
            }
        }
        private void 清空_Click(object sender, EventArgs e)
        {
            try
            {
                comboBox_ColorRegion.Items.Clear();
                comboBox_ColorRegion.Text = "";
                listRect2ROIs = new List<Rect2>();
            }
            catch (Exception ex)
            {
                StaticFun.MessageFun.ShowMessage(ex);
            }

        }
        private void but_Show_Click(object sender, EventArgs e)
        {
            try
            {
                Fun.HWnd.DispObj(Fun.HImage);
                foreach (Rect2 rect2 in listRect2ROIs)
                {
                    Fun.ShowRect2(rect2);
                }
            }
            catch (Exception ex)
            {
                StaticFun.MessageFun.ShowMessage(ex);
            }
        }
        private void but_Del_Click(object sender, EventArgs e)
        {
            try
            {
                int n = comboBox_ColorRegion.SelectedIndex;
                if (-1 == n)
                {
                    return;
                }
                listRect2ROIs.RemoveAt(n);
                comboBox_ColorRegion.Items.Clear();
                for (int m = 0; m < listRect2ROIs.Count; m++)
                {
                    comboBox_ColorRegion.Items.Add("区域" + (m + 1).ToString());
                }
                if (comboBox_ColorRegion.Items.Count > 0)
                {
                    comboBox_ColorRegion.SelectedIndex = 0;
                }
                else
                {
                    comboBox_ColorRegion.Text = "";
                }
            }
            catch (Exception ex)
            {
                StaticFun.MessageFun.ShowMessage(ex);
            }

        }
        private void comboBox_ColorRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bLoad) return;
            int n = comboBox_ColorRegion.SelectedIndex;
            Fun.ShowRect2(listRect2ROIs[n]);
        }
        private void but_Test_Click(object sender, EventArgs e)
        {
            try
            {
                if (bLoad) return;
                Button but = sender as Button;
                ColorTrainData param = InitParam();
                if (Fun.CreateColorGmm(Fun.GenAllRect2(listRect2ROIs), out ColorID id, param.dRejThd))
                {
                    m_ColorID = id;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("颜色学习错误：" + ex.ToString());
            }
        }

    }
}

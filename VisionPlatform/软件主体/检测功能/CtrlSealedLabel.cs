using BaseData;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static VisionPlatform.InspectData;

namespace VisionPlatform
{
    public partial class CtrlSealedLabel : UserControl
    {
        CtrlHome myCtrlHome;
        InspectFunction Fun;
        Rect2 m_rect2;
        bool bLoad;
        public List<HalconDotNet.HObject> myListImages = new List<HalconDotNet.HObject>();
        public PhotometricStereoImage photometricStereoImage = new PhotometricStereoImage();
        public CtrlSealedLabel(CtrlHome ctrlHome)
        {
            InitializeComponent();
            this.myCtrlHome = ctrlHome;
            this.Visible = true;
            this.Dock = DockStyle.Fill;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Fun = ctrlHome.Fun;
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
                this.myListImages = FormMainUI.m_dicCtrlCamShow[myCtrlHome.camID].myListImages;
                this.photometricStereoImage = FormMainUI.m_dicCtrlCamShow[myCtrlHome.camID].photometricStereoImage;
                ValueRange1.SetValue(false, "偏移量1", -3000, 3000, 1, 0);
                ValueRange1.ValueChanged += Inspect;
                ValueRange2.SetValue(false, "偏移量2", -3000, 3000, 1, 0);
                ValueRange2.ValueChanged += Inspect;
                CamInspectItem camItem = myCtrlHome.myCamItem;
                string strItem = InspectFunction.GetStrCheckItem(camItem.item);
                ctrlNccModel1.ValueChanged += Inspect;
                ctrlNccModel1.UpdateFun(this.Fun, myCtrlHome.camID, strItem + "_封口标签1");
                ctrlNccModel2.ValueChanged += Inspect;
                ctrlNccModel2.UpdateFun(this.Fun, myCtrlHome.camID, strItem + "_封口标签2");
                ctrlFitLine.ValueChanged += Inspect;
            }
            catch (Exception ex)
            {
                StaticFun.MessageFun.ShowMessage(ex);
            }
        }
        public SealedLabelParam InitParam()
        {
            SealedLabelParam param = new SealedLabelParam();
            try
            {
                param.nImageSel = cmbBox_ImageSel.SelectedIndex + 1;
                param.nccLocate1 = ctrlNccModel1.InitParam();
                param.nccLocate2 = ctrlNccModel2.InitParam();
                string id = System.Text.RegularExpressions.Regex.Replace(label_Name.Text, @"[^0-9]+", "");
                int nSel = int.Parse(id) - 1;
                if (null != ListROIItems && ListROIItems.Count > nSel)
                {
                    ROILineItem item = new ROILineItem()
                    {
                        dist1 = ValueRange1.InitParam(),
                        dist2 = ValueRange2.InitParam(),
                        roiLine = new ROILine()
                        {
                            rect2 = m_rect2,
                            lineParam = new LineParam()
                            {
                                measure = ctrlFitLine.InitParam(),
                            }
                        }
                    };
                    ListROIItems[nSel] = item;
                }
                param.listROIItems = ListROIItems;
            }
            catch (Exception ex)
            {
                StaticFun.MessageFun.ShowMessage(ex);
            }
            return param;
        }

        public void LoadParam(SealedLabelParam param)
        {
            try
            {
                bLoad = true;
                cmbBox_ImageSel.SelectedIndex = 0 == param.nImageSel ? 3 : param.nImageSel - 1;
                checkBox2.Checked = param.bTwoLabels;
                checkBox1.Checked = !checkBox2.Checked;
                tLPanel1.Visible = checkBox1.Checked;
                tLPanel2.Visible = checkBox2.Checked;
                ValueRange1.Visible = checkBox1.Checked;
                ValueRange2.Visible = checkBox2.Checked;
                ctrlNccModel1.LoadParam(param.nccLocate1);
                ctrlNccModel2.LoadParam(param.nccLocate2);
                if (null != param.listROIItems && param.listROIItems.Count > 0)
                {
                    int n = param.listROIItems.Count;
                    listView_Item.Items.Clear();
                    for (int i = 0; i < n; i++)
                    {
                        listView_Item.Items.Add($"位置{i + 1}");
                    }
                    ValueRange1.LoadParam(param.listROIItems[n - 1].dist1);
                    ValueRange2.LoadParam(param.listROIItems[n - 1].dist2);
                    m_rect2 = param.listROIItems[n - 1].roiLine.rect2;
                    ctrlFitLine.LoadParam(param.listROIItems[n - 1].roiLine.lineParam.measure);
                }
            }
            catch (SystemException ex)
            {
                StaticFun.MessageFun.ShowMessage(ex);
            }
            bLoad = false;
        }
        private void Inspect(object sender, EventArgs e)
        {
            bool bResult = true;
            try
            {
                if (bLoad) { return; }
                this.myListImages = FormMainUI.m_dicCtrlCamShow[myCtrlHome.camID].myListImages;
                this.photometricStereoImage = FormMainUI.m_dicCtrlCamShow[myCtrlHome.camID].photometricStereoImage;
                SealedLabelParam param = InitParam();
                TimeSpan ts = new TimeSpan(DateTime.Now.Ticks);
                if (!myCtrlHome.Fun.myFrontFun.SealedLabelInspect(param, true, out SealedLabelResult result, photometricStereoImage.Albedo))
                {
                    bResult = false;
                }
                TimeSpan ts_check = new TimeSpan(DateTime.Now.Ticks);
                string span = ((ts_check.Subtract(ts).Duration().TotalSeconds) * 1000).ToString("F0");
                StaticFun.MessageFun.ShowMessage("检测用时：" + span);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CheckBox cb = sender as CheckBox;
                if (null == cb.Checked) return;
                if (cb.Checked)
                {
                    switch (cb.Text)
                    {
                        case "1":
                            checkBox2.Checked = false;

                            break;
                        case "2":
                            checkBox1.Checked = false;
                            break;
                        default:
                            break;
                    }
                }
                if (!checkBox1.Checked && !checkBox2.Checked)
                {
                    checkBox1.Checked = true;
                }
                tLPanel1.Visible = true;
                tLPanel2.Visible = checkBox2.Checked;
                ValueRange1.Visible = true;
                ValueRange2.Visible = checkBox2.Checked;
            }
            catch (Exception ex)
            {
                StaticFun.MessageFun.ShowMessage(ex);
            }
        }

        #region 标签与边缘线的间距
        bool bAdd = false;
        List<ROILineItem> ListROIItems = new List<ROILineItem>();
        private void but_AddItem_Click(object sender, EventArgs e)
        {
            try
            {
                //if (bLoad) return;
                //添加到左边tree_view
                int n = listView_Item.Items.Count;
                string strName = $"位置{n + 1}";
                listView_Item.Items.Add(strName);
                //获取新增项焦点，并选中
                listView_Item.EnsureVisible(n);
                bAdd = true;
                listView_Item.Items[n].Selected = true;
                for (int i = 0; i < listView_Item.Items.Count - 1; i++)
                {
                    listView_Item.Items[i].Selected = false;
                }
                label_Name.Text = "位置" + (n + 1).ToString() + "参数设置";
                //添加list
                ROILineItem item = new ROILineItem();
                ListROIItems.Add(item);
                bAdd = false;
            }
            catch (Exception ex)
            {
                StaticFun.MessageFun.ShowMessage("AddItem:" + ex.ToString());
            }
        }

        private void Remove_Click(object sender, EventArgs e)
        {
            try
            {
                if (listView_Item.SelectedItems.Count == 0)
                    return;
                else
                {
                    //选中点击那一行的第一列的值，索引值必须是0，而且无论点这一行的第几列，选中的都是这一行第一列的值 ，如果想获取这一行除第一列外的值，则用subitems获取，[]中为索引，从1开始。
                    string str = listView_Item.SelectedItems[0].ToString();
                    string result = System.Text.RegularExpressions.Regex.Replace(str, @"[^0-9]+", "");
                    int nSel = int.Parse(result) - 1;
                    ListROIItems.RemoveAt(nSel);
                    listView_Item.Items.Clear();
                    for (int i = 0; i < ListROIItems.Count; i++)
                    {
                        listView_Item.Items.Add($"位置{i + 1}");
                    }
                    listView_Item.EnsureVisible(ListROIItems.Count - 1);
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            listView_Item.Items.Clear();
            ListROIItems.Clear();
        }

        private void listView_Item_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (listView_Item.SelectedItems.Count == 0 || bAdd)
                    return;
                else
                {
                    //选中点击那一行的第一列的值，索引值必须是0，而且无论点这一行的第几列，选中的都是这一行第一列的值 ，如果想获取这一行除第一列外的值，则用subitems获取，[]中为索引，从1开始。
                    string str = listView_Item.SelectedItems[0].ToString();
                    string result = System.Text.RegularExpressions.Regex.Replace(str, @"[^0-9]+", "");
                    int row = int.Parse(result) - 1;
                    label_Name.Text = "位置" + result;
                    //加载检测项的参数
                    ROILineItem param = ListROIItems[row];
                    ValueRange1.LoadParam(param.dist1);
                    ValueRange2.LoadParam(param.dist2);
                    m_rect2 = param.roiLine.rect2;
                    ctrlFitLine.LoadParam(param.roiLine.lineParam.measure);
                }
            }
            catch (Exception ex)
            {
                StaticFun.MessageFun.ShowMessage(ex);
            }
        }
        #endregion

        private void cmbBox_ImageSel_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (null == FormMainUI.m_dicCtrlCamShow[myCtrlHome.camID])
                {
                    return;
                }
                this.myListImages = FormMainUI.m_dicCtrlCamShow[myCtrlHome.camID].myListImages;
                if (this.myListImages.Count > cmbBox_ImageSel.SelectedIndex)
                {
                    myCtrlHome.Fun.DispRegion(this.myListImages[cmbBox_ImageSel.SelectedIndex]);
                }
            }
            catch (Exception ex)
            {
                StaticFun.MessageFun.ShowMessage(ex);
            }
        }

        private void but_LineROI_Click(object sender, EventArgs e)
        {
            if (this.Fun.m_rect2.isEmpty())
            {
                MessageBox.Show("请先在图像窗口，鼠标右键，选择【绘制-矩形2】，绘制区域。");
                return;
            }
            m_rect2 = this.Fun.m_rect2;
        }

        private void btn_ShowROI_Click(object sender, EventArgs e)
        {
            this.Fun.ShowRect2(m_rect2);
        }
    }
}

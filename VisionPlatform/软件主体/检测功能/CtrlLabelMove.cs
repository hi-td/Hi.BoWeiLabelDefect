using BaseData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using static VisionPlatform.InspectData;

namespace VisionPlatform
{
    [ToolboxItem(false)]
    public partial class CtrlLabelMove : UserControl
    {
        CtrlHome myCtrlHome;
        InspectFunction Fun;
        bool bLoad;
        Rect2 labelRect2, boxRect2;
        private event CtrlLabelEventHandler _valueChanged;
        public CtrlLabelMove(CtrlHome ctrlHome)
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

        public event CtrlLabelEventHandler ValueChanged
        {
            add { _valueChanged += value; }
            remove { _valueChanged -= value; }
        }
        private void InitUI()
        {
            try
            {
                ctrlFitLine_Label.ValueChanged += Inspect;
                ctrlFitLine_Box.ValueChanged += Inspect;
                AngleValueRange.SetValue(true, "角度偏移范围", -45, 45, 1, 0);
                AngleValueRange.ValueChanged += Inspect;
                MoveValueRange.SetValue(false, "偏移量", -2000, 2000, 1, 0);
                MoveValueRange.ValueChanged += Inspect;
                ctrlNccModel.ValueChanged += Inspect;
                CamInspectItem camItem = myCtrlHome.myCamItem;
                string strItem = InspectFunction.GetStrCheckItem(camItem.item);
                ctrlNccModel.UpdateFun(this.Fun, myCtrlHome.camID, strItem);
            }
            catch (Exception ex)
            {
                StaticFun.MessageFun.ShowMessage(ex);
            }
        }

        public LabelMoveParam InitParam()
        {
            LabelMoveParam param = new LabelMoveParam();
            try
            {
                param.nccLocate = ctrlNccModel.InitParam();
                param.AngleValue = AngleValueRange.InitParam();
                param.dicLabelMoveItems = dicLabelMoveItems;
            }
            catch (Exception ex)
            {
                StaticFun.MessageFun.ShowMessage(ex);
            }
            return param;
        }

        public void LoadParam(LabelMoveParam param)
        {
            try
            {
                bLoad = true;
                ctrlNccModel.LoadParam(param.nccLocate);
                AngleValueRange.LoadParam(param.AngleValue);
                if (null == param.dicLabelMoveItems)
                {
                    tLPanel_Box.Visible = false;
                    tLPanel_Label.Visible = false;
                    tLPanel_Point.Visible = false;
                    return;
                }
                dicLabelMoveItems = new Dictionary<string, LabelMoveItem>();
                foreach (var item in param.dicLabelMoveItems)
                {
                    if ("" == item.Key) continue;
                    ToolStripMenuItem send = new ToolStripMenuItem();
                    switch (item.Value.type)
                    {
                        case MoveType.point_line:
                            send.Text = "模板中心到边缘线的距离";
                            break;
                        case MoveType.line_line:
                            send.Text = "标签与边缘线的间距";
                            break;
                        case MoveType.point_point:
                            send.Text = "模板中心到点的矢量";
                            break;
                        default:
                            break;
                    }
                    but_AddItem_Click(send, null);
                    dicLabelMoveItems[strSelName] = item.Value;
                    MoveValueRange.LoadParam(item.Value.dist);
                    ctrlFitLine_Box.LoadParam(item.Value.boxLine.lineParam.measure);
                    ctrlFitLine_Label.LoadParam(item.Value.labelLine.lineParam.measure);
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
            try
            {
                if (bLoad) { return; }
                if (null != dicLabelMoveItems && dicLabelMoveItems.ContainsKey(strSelName))
                {
                    LabelMoveItem item = dicLabelMoveItems[strSelName];
                    item.dist = MoveValueRange.InitParam();
                    ROILine boxLine = new ROILine()
                    {
                        rect2 = boxRect2,
                        lineParam = new BaseData.LineParam()
                        {
                            lineIn = new BaseData.Line(),
                            measure = ctrlFitLine_Box.InitParam()
                        }
                    };
                    item.boxLine = boxLine;

                    ROILine labelLine = new ROILine()
                    {
                        rect2 = labelRect2,
                        lineParam = new BaseData.LineParam()
                        {
                            lineIn = new BaseData.Line(),
                            measure = ctrlFitLine_Label.InitParam()
                        }
                    };
                    item.labelLine = labelLine;
                    dicLabelMoveItems[strSelName] = item;
                }
                InitParam();
                _valueChanged?.Invoke(sender, e);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        #region 标签与边缘线的间距
        bool bAdd = false;
        string strSelName = "";
        Dictionary<string, LabelMoveItem> dicLabelMoveItems = new Dictionary<string, LabelMoveItem>();
        private void but_AddItem_Click(object sender, EventArgs e)
        {
            try
            {
                //if (bLoad) return;
                //添加到左边tree_view
                int n = listView_Item.Items.Count;
                string strName = $"检测项{n + 1}";
                strSelName = strName;
                ToolStripMenuItem item = sender as ToolStripMenuItem;
                ListViewItem addItem = new ListViewItem();
                addItem.ToolTipText = item.Text;
                addItem.Text = strName;
                InspectData.MoveType myType = MoveType.point_line;
                switch (item.Text)
                {
                    case "模板中心到边缘线的距离":
                        myType = MoveType.point_line;
                        addItem.ImageIndex = 0;
                        tLPanel_Label.Visible = false;
                        tLPanel_Box.Visible = true;
                        tLPanel_Point.Visible = false;
                        break;
                    case "标签与边缘线的间距":
                        myType = MoveType.line_line;
                        addItem.ImageIndex = 1;
                        tLPanel_Label.Visible = true;
                        tLPanel_Box.Visible = true;
                        tLPanel_Point.Visible = false;
                        break;
                    case "模板中心到点的矢量":
                        myType = MoveType.point_point;
                        addItem.ImageIndex = 2;
                        tLPanel_Label.Visible = false;
                        tLPanel_Box.Visible = false;
                        tLPanel_Point.Visible = true;
                        break;
                    default:
                        break;
                }
                listView_Item.Items.Add(addItem);
                //获取新增项焦点，并选中
                listView_Item.EnsureVisible(n);
                bAdd = true;
                listView_Item.Items[n].Selected = true;
                for (int i = 0; i < listView_Item.Items.Count - 1; i++)
                {
                    listView_Item.Items[i].Selected = false;
                }
                listView_Item.Text = "检测项" + (n + 1).ToString() + "参数设置";
                //添加list
                LabelMoveItem labelMoveItem = new LabelMoveItem()
                {
                    type = myType,
                };
                dicLabelMoveItems.Add(strName, labelMoveItem);
                bAdd = false;
            }
            catch (Exception ex)
            {
                StaticFun.MessageFun.ShowMessage("AddBrokenROI:" + ex.ToString());
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
                    if (null != dicLabelMoveItems && dicLabelMoveItems.ContainsKey(str))
                    {
                        dicLabelMoveItems.Remove(str);
                        listView_Item.Items.RemoveAt(0);
                    }
                    tLPanel_Label.Visible = false;
                    tLPanel_Box.Visible = false;
                    tLPanel_Point.Visible = false;
                    if (dicLabelMoveItems.Count > 0)
                    {
                        listView_Item.EnsureVisible(0);
                        LabelMoveItem param = dicLabelMoveItems["检测项1"];
                        switch (param.type)
                        {
                            case MoveType.point_line:
                                tLPanel_Label.Visible = false;
                                tLPanel_Box.Visible = true;
                                tLPanel_Point.Visible = false;
                                break;
                            case MoveType.line_line:
                                tLPanel_Label.Visible = true;
                                tLPanel_Box.Visible = true;
                                tLPanel_Point.Visible = false;
                                break;
                            case MoveType.point_point:
                                tLPanel_Label.Visible = false;
                                tLPanel_Box.Visible = false;
                                tLPanel_Point.Visible = true;
                                break;
                            default:
                                break;
                        }
                        MoveValueRange.LoadParam(param.dist);
                        ctrlFitLine_Box.LoadParam(param.boxLine.lineParam.measure);
                        ctrlFitLine_Label.LoadParam(param.labelLine.lineParam.measure);
                    }
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
            dicLabelMoveItems.Clear();
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
                    int row = int.Parse(result);
                    string stsr = $"检测项{row}";
                    but_Test.Text = "检测项" + (row) + "测试";
                    //加载检测项的参数
                    if (null != dicLabelMoveItems && dicLabelMoveItems.ContainsKey(stsr))
                    {
                        LabelMoveItem param = dicLabelMoveItems[stsr];
                        switch (param.type)
                        {
                            case MoveType.point_line:
                                tLPanel_Label.Visible = false;
                                tLPanel_Box.Visible = true;
                                tLPanel_Point.Visible = false;
                                break;
                            case MoveType.line_line:
                                tLPanel_Label.Visible = true;
                                tLPanel_Box.Visible = true;
                                tLPanel_Point.Visible = false;
                                break;
                            case MoveType.point_point:
                                tLPanel_Label.Visible = false;
                                tLPanel_Box.Visible = false;
                                tLPanel_Point.Visible = true;
                                break;
                            default:
                                break;
                        }
                        MoveValueRange.LoadParam(param.dist);
                        labelRect2 = param.labelLine.rect2;
                        ctrlFitLine_Label.LoadParam(param.labelLine.lineParam.measure);
                        boxRect2 = param.boxLine.rect2;
                        ctrlFitLine_Box.LoadParam(param.boxLine.lineParam.measure);
                    }
                }
            }
            catch (Exception ex)
            {
                StaticFun.MessageFun.ShowMessage(ex);
            }
        }
        #endregion

        private void but_SaveParam_Click(object sender, EventArgs e)
        {

        }

        private void DropDownBut_Add_Click(object sender, EventArgs e)
        {

        }

        private void but_LabelLineROI_Click(object sender, EventArgs e)
        {
            if (this.Fun.m_rect2.isEmpty())
            {
                MessageBox.Show("请先在图像窗口，鼠标右键，选择【绘制-矩形2】，绘制区域。");
                return;
            }
            labelRect2 = this.Fun.m_rect2;
        }

        private void btn_ShowLabelLine_Click(object sender, EventArgs e)
        {
            this.Fun.ShowRect2(labelRect2);
        }

        private void but_BoxLineROI_Click(object sender, EventArgs e)
        {
            if (this.Fun.m_rect2.isEmpty())
            {
                MessageBox.Show("请先在图像窗口，鼠标右键，选择【绘制-矩形2】，绘制区域。");
                return;
            }
            boxRect2 = this.Fun.m_rect2;
        }

        private void btn_ShowBoxLine_Click(object sender, EventArgs e)
        {
            this.Fun.ShowRect2(boxRect2);
        }
    }
}

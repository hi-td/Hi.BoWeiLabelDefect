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
                foreach (var item in param.dicLabelMoveItems)
                {

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
                    ROILine roiLine = new ROILine()
                    {
                        rect2 = Fun.m_rect2,
                        lineParam = new BaseData.LineParam()
                        {
                            lineIn = new BaseData.Line(),
                            measure = ctrlFitLine_Box.InitParam()
                        }
                    };
                    item.arrayROILine = new ROILine[1] { roiLine };
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
                if (bLoad) return;
                ToolStripMenuItem item = sender as ToolStripMenuItem;
                InspectData.MoveType myType = MoveType.point_line;
                switch (item.Text)
                {
                    case "模板中心到边缘线的距离":
                        myType = MoveType.point_line;
                        tLPanel_Label.Visible = false;
                        tLPanel_Box.Visible = true;
                        tLPanel_Point.Visible = false;
                        break;
                    case "标签与边缘线的间距":
                        myType = MoveType.line_line;
                        tLPanel_Label.Visible = true;
                        tLPanel_Box.Visible = true;
                        tLPanel_Point.Visible = false;
                        break;
                    case "模板中心到点的矢量":
                        myType = MoveType.point_point;
                        tLPanel_Label.Visible = false;
                        tLPanel_Box.Visible = false;
                        tLPanel_Point.Visible = true;
                        break;
                    default:
                        break;
                }
                //添加到左边tree_view
                int n = listView_Item.Items.Count;
                string strName = $"检测项{n + 1}";
                strSelName = strName;
                ListViewItem addItem = new ListViewItem();
                addItem.ToolTipText = item.Text;
                addItem.Text = strName;
                addItem.ImageIndex = 0;
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
                    string result = System.Text.RegularExpressions.Regex.Replace(str, @"[^0-9]+", "");
                    int row = int.Parse(result);
                    //listItemParams.RemoveAt(row - 1);
                    // listCtrlRubbers.RemoveAt(row - 1);
                    // listBrokenRect2. ;//必须放在上面两句代码后面
                    listView_Item.Items.Clear();
                    //for (int n = 0; n < listItemParams.Count; n++)
                    //{
                    //    listView_Item.Items.Add("检测项" + (n + 1).ToString());
                    //}
                    panel_Item.Controls.Clear();
                    if (listView_Item.Items.Count > 0)
                    {
                        listView_Item.Items[0].Selected = true;
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
            if (listView_Item.SelectedItems.Count == 0 || bAdd)
                return;
            else
            {
                //选中点击那一行的第一列的值，索引值必须是0，而且无论点这一行的第几列，选中的都是这一行第一列的值 ，如果想获取这一行除第一列外的值，则用subitems获取，[]中为索引，从1开始。
                string str = listView_Item.SelectedItems[0].ToString();
                string result = System.Text.RegularExpressions.Regex.Replace(str, @"[^0-9]+", "");
                int row = int.Parse(result) - 1;
                //but_Test.Text = "检测项" + (row + 1) + "测试";
                //加载检测项的参数
                //this.panel_Item.Controls.Clear();
                //if (null != listCtrlRubbers && listCtrlRubbers.Count > 0)
                //{
                //    listCtrlRubbers[row].LoadParam(listRubberItemParams[row]);
                //}
                //this.panel_RubberItem.Controls.Add(listCtrlRubbers[row]);
            }
        }
        #endregion

        private void but_SaveParam_Click(object sender, EventArgs e)
        {

        }

        private void DropDownBut_Add_Click(object sender, EventArgs e)
        {

        }
    }
}

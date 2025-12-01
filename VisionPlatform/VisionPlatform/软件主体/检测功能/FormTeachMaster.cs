using Hi.Ltd;
using StaticFun;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static GlobalData.Config;
using static VisionPlatform.InspectData;

namespace VisionPlatform
{
    public partial class FormTeachMaster : Form
    {
        int myCamID;                                         //相机ID
        int nPreIO_in;                                       //输入/输出的IO点位
        private string m_SelNode_z = null;                   //关联相机时选中的根节点
        InspectData.InspectItem m_item = new InspectData.InspectItem();//当前选中的检测项目
        FormIOSend formIOSend;
        FormLightCH formLightCH;
        TreeNode CurrentNode;
        ToolStripComboBox cb_IO = new ToolStripComboBox();  //IO点位
        ToolStripMenuItem item_IOIn = new ToolStripMenuItem("I/O输入点");
        ToolStripMenuItem item_IOOut = new ToolStripMenuItem("I/O输出点");
        ToolStripComboBox cb_light = new ToolStripComboBox(); //光源通道
        ToolStripItem del = new ToolStripMenuItem("删除");
        public static Panel m_panelWindow;
        public FormTeachMaster(int camID)
        {
            InitializeComponent();
            this.TopLevel = false;
            this.Visible = true;
            this.Dock = DockStyle.Fill;
            this.myCamID = camID;
            ts_Label_cam.Text = $"编辑：相机{camID.ToString()[0]}-{camID.ToString()[1]}";
            LoadUI(camID);
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
        private void LoadUI(int camID)
        {
            if (GlobalData.Config._language == EnumData.Language.english)
            {
                item_IOIn = new ToolStripMenuItem("I/O Input Points");
                item_IOOut = new ToolStripMenuItem("I/O Output Point");
                //item_light = new ToolStripMenuItem("Light Source Control");
                cb_light = new ToolStripComboBox(); //光源通道
                del = new ToolStripMenuItem("Delete");
            }
            //加载图像显示窗口
            RefreshUI(camID);
            //加载消息显示
            FormMainUI.formShowResult.ShowMessagePageOnly(true);
            this.panel_message.Controls.Clear();
            this.panel_message.Controls.Add(FormMainUI.formShowResult);
            //加载左边检测列表
            InitTreeView();
            if (null != DataSerializer._globalData.dicInspectList &&
                DataSerializer._globalData.dicInspectList.ContainsKey(camID))
            {
                InspectItem strCheck = DataSerializer._globalData.dicInspectList[camID][0];
                this.panel.Controls.Clear();
                Control form = new Control();
                switch (strCheck)
                {
                    case InspectItem.Front:
                        form = new CtrlHome(camID, InspectItem.Front);
                        break;
                    case InspectItem.LeftSide:
                        form = new CtrlHome(camID, InspectItem.LeftSide);
                        break;
                    case InspectItem.RightSide:
                        form = new CtrlHome(camID, InspectItem.RightSide);
                        break;
                    default: break;
                }
                this.panel.Controls.Add(form);
            }
        }
        private void RefreshUI(int camID)
        {
            try
            {
                this.panelWindow.Controls.Clear();
                this.panelWindow.Controls.Add(FormMainUI.m_dicCtrlCamShow[camID]);

            }
            catch (Exception ex)
            {
                StaticFun.MessageFun.ShowMessage(ex);
            }
        }

        private void InitTreeView()
        {
            try
            {
                treeViewFun.Nodes.Clear();
                TreeNode father_node = new TreeNode();
                foreach (int camID in FormMainUI.m_dicCtrlCamShow.Keys)
                {
                    String Name = GlobalData.Config._language == EnumData.Language.english ? "Camera" : "相机";
                    father_node = new TreeNode()
                    {
                        Text = Name + $"{camID.ToString()[0]}-{camID.ToString()[1]}",
                    };
                    if (null != DataSerializer._globalData.dicInspectList && DataSerializer._globalData.dicInspectList.ContainsKey(camID))
                    {
                        foreach (InspectData.InspectItem item in DataSerializer._globalData.dicInspectList[camID])
                        {
                            TreeNode node = new TreeNode();
                            node.Text = InspectFunction.GetStrCheckItem(item);
                            if ("" != node.Text)
                            {
                                father_node.Nodes.Add(node);
                            }
                        }
                    }
                    treeViewFun.Nodes.Add(father_node);  //须放在if外：即使无检测项也要添加父节点
                }
                treeViewFun.ExpandAll();
            }
            catch (Exception ex)
            {
                MessageFun.ShowMessage(ex.ToString());
            }
        }

        private void CheckNodeAdd(TreeNode node)
        {
            node.Nodes.Clear();
            if (node.Text == "")
            {

            }
        }

        private void Teachmaster_Load(object sender, EventArgs e)
        {
            m_panelWindow = this.panelWindow;
        }

        private void ts_But_close_Click(object sender, EventArgs e)
        {
            try
            {
                FormMainUI.ctrlAllStates.RefreshDatas();
                FormMainUI.formShowResult.ShowMessagePageOnly(false);
                FormMainUI.m_PanelShow.Controls.Clear();
                switch (FormMainUI.m_dicCtrlCamShow.Count)
                {
                    case 1:
                        FormMainUI.m_Show1.RefreshUI();
                        FormMainUI.m_PanelShow.Controls.Add(FormMainUI.m_Show1);
                        break;
                    case 2:
                        FormMainUI.m_Show2.RefreshUI();
                        FormMainUI.m_PanelShow.Controls.Add(FormMainUI.m_Show2);
                        break;
                    case 3:
                        FormMainUI.m_Show3.RefreshUI();
                        FormMainUI.m_PanelShow.Controls.Add(FormMainUI.m_Show3);
                        break;
                    case 4:
                        FormMainUI.m_Show4.RefreshUI();
                        FormMainUI.m_PanelShow.Controls.Add(FormMainUI.m_Show4);
                        break;
                    case 5:
                        FormMainUI.m_Show5.RefreshUI();
                        FormMainUI.m_PanelShow.Controls.Add(FormMainUI.m_Show5);
                        break;
                    case 6:
                        FormMainUI.m_Show6.RefreshUI();
                        FormMainUI.m_PanelShow.Controls.Add(FormMainUI.m_Show6);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageFun.ShowMessage(ex);
            }
            GC.Collect();
            this.Close();
        }

        private void AddCheckItem(object sender, EventArgs e)
        {
            try
            {
                string strItem = sender.ToString();
                if (m_SelNode_z != null)
                {
                    string strCam = m_SelNode_z;
                    if (null == treeViewFun.SelectedNode.Parent)
                    {
                        bool bContain = false;  //是否已经存在该检测项目
                        foreach (TreeNode node in treeViewFun.SelectedNode.Nodes)
                        {
                            if (node.Text == strItem)
                            {
                                bContain = true;
                                break;
                            }
                        }
                        if (!bContain)
                        {
                            treeViewFun.SelectedNode.Nodes.Add(strItem);
                        }
                    }
                    treeViewFun.ExpandAll();
                    RefreshCheckList();
                }
            }
            catch (SystemException ex)
            {
                StaticFun.MessageFun.ShowMessage(ex);
            }
        }

        private void RefreshCheckList()
        {
            try
            {
                foreach (TreeNode node0 in treeViewFun.Nodes)
                {
                    List<InspectData.InspectItem> strCheckList = new List<InspectData.InspectItem>();
                    foreach (TreeNode node1 in node0.Nodes)
                    {
                        if (node1.Nodes.Count > 0)
                        {
                            foreach (TreeNode node2 in node1.Nodes)
                            {
                                InspectData.InspectItem item = InspectFunction.GetEnumCheckItem(node2.Text);
                                strCheckList.Add(item);
                            }
                        }
                        else
                        {
                            InspectData.InspectItem item = InspectFunction.GetEnumCheckItem(node1.Text);
                            strCheckList.Add(item);
                        }
                    }
                    string result = System.Text.RegularExpressions.Regex.Replace(node0.Text, @"[^0-9]+", "");
                    int camID = int.Parse(result);
                    if (DataSerializer._globalData.dicInspectList.ContainsKey(camID))
                    {
                        DataSerializer._globalData.dicInspectList[camID] = strCheckList;
                    }
                    else
                    {
                        DataSerializer._globalData.dicInspectList.Add(camID, strCheckList);
                    }
                }
            }
            catch (SystemException ex)
            {
                ex.ToString();
            }
            RefreshStats();
        }
        private void RefreshStats()
        {

        }
        private void toolStripMenuItem_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_SelNode_z != null)
                {
                    InspectItem selItem = InspectFunction.GetEnumCheckItem(m_SelNode_z);
                    if (selItem != InspectItem.Default)
                    {
                        if (null == treeViewFun.SelectedNode.Parent)
                        {
                            return;
                        }
                        foreach (TreeNode node in treeViewFun.SelectedNode.Parent.Nodes)
                        {
                            if (node.Text == m_SelNode_z)
                            {
                                treeViewFun.SelectedNode.Parent.Nodes.Remove(node);
                                break;
                            }
                        }
                    }
                    RefreshCheckList();
                }
            }
            catch (SystemException ex)
            {
                ex.ToString();
            }
        }
        private void TreeViewFun_AfterSelect(object sender, TreeViewEventArgs e)
        {
            int selCamID = -1;
            string strSel = treeViewFun.SelectedNode.Text;
            if (null != treeViewFun.SelectedNode.Parent)
            {
                label_SelCam.Text = treeViewFun.SelectedNode.Parent.Text;
                if (GlobalData.Config._language == EnumData.Language.english)
                {
                    ts_Label_cam.Text = "Edit:" + treeViewFun.SelectedNode.Parent.Text;
                }
                else
                {
                    ts_Label_cam.Text = "编辑：" + treeViewFun.SelectedNode.Parent.Text;
                }
                selCamID = int.Parse(Regex.Replace(label_SelCam.Text, "[^0-9]", ""));
                RefreshUI(selCamID);
            }
            StaticFun.UIConfig.MoveCamPos(selCamID);
            InspectItem selItem = InspectFunction.GetEnumCheckItem(strSel);
            this.panel.Controls.Clear();
            Control form = new Control();
            switch (selItem)
            {
                case InspectItem.Front:
                    form = new CtrlHome(selCamID, InspectItem.Front);
                    break;
                case InspectItem.LeftSide:
                    form = new CtrlHome(selCamID, InspectItem.LeftSide);
                    break;
                case InspectItem.RightSide:
                    form = new CtrlHome(selCamID, InspectItem.RightSide);
                    break;
                default: break;
            }
            this.panel.Controls.Add(form);

        }
        private void treeViewFun_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)//判断点的是不是右键
                {
                    System.Drawing.Point ClickPoint = new System.Drawing.Point(e.X, e.Y);
                    CurrentNode = treeViewFun.GetNodeAt(ClickPoint);
                    if (CurrentNode != null && CurrentNode.Parent == null)//判断点的是不是一个节点
                    {
                        CurrentNode.ContextMenuStrip = contextMenuStrip1;
                        treeViewFun.SelectedNode = CurrentNode;
                        m_SelNode_z = CurrentNode.Text;
                    }
                    else if (CurrentNode != null && CurrentNode.Parent != null)
                    {
                        m_item = InspectFunction.GetEnumCheckItem(CurrentNode.Text);
                        contextMenuStrip2.Items.Clear();
                        contextMenuStrip2.Items.Add(del);
                        del.Click += new EventHandler(toolStripMenuItem_Delete_Click);

                        if (CurrentNode.Text == "多根-端子检测" || CurrentNode.Text == "Multi-Terminal detection")
                        {
                            string strAdd = GlobalData.Config._language == EnumData.Language.english ? "" : "检测项配置";
                            contextMenuStrip2.Items.Add(strAdd);
                        }
                        if (GlobalData.Config._language == EnumData.Language.english)
                        {
                            contextMenuStrip2.Items.Add("Display Settings");
                        }
                        else
                        {
                            contextMenuStrip2.Items.Add("显示设置");
                        }

                        //添加IO点位配置
                        if (_InitConfig.initConfig.comMode.TYPE == EnumData.COMType.IO)
                        {
                            item_IOIn.DropDownItems.Clear();
                            item_IOOut.DropDownItems.Clear();
                            cb_IO = new ToolStripComboBox();
                            int total_io = 8;
                            if (_InitConfig.initConfig.comMode.IO == EnumData.IO.WENYU16)
                            {
                                total_io = 16;
                            }
                            else if (_InitConfig.initConfig.comMode.IO == EnumData.IO.WENYU232)
                            {
                                total_io = 12;
                            }
                            for (int io = 0; io < total_io; io++)
                            {
                                cb_IO.Items.Add(io);
                            }
                            cb_IO.SelectedIndexChanged += new EventHandler(IO_SelectIn_Click);
                            bool bContain = false;

                            for (int n = 0; n < DataSerializer._COMConfig.listIOSet.Count; n++)
                            {
                                IOSet io = DataSerializer._COMConfig.listIOSet[n];
                                //if (io.camItem.cam == ncam && io.camItem.item == m_item)
                                //{
                                //    nPreIO_in = io.read;
                                //    bContain = true;
                                //}
                            }
                            if (!bContain)
                            {
                                nPreIO_in = -1;
                            }
                            if (GlobalData.Config._language == EnumData.Language.english)
                            {
                                item_IOIn.DropDownItems.Add("Current point:" + nPreIO_in);
                            }
                            else
                            {
                                item_IOIn.DropDownItems.Add("当前点位：" + nPreIO_in);
                            }
                            item_IOIn.DropDownItems.Add(cb_IO);
                            contextMenuStrip2.Items.Add(item_IOIn);
                            contextMenuStrip2.Items.Add(item_IOOut);

                        }
                        //添加CamIO点位配置
                        if (_InitConfig.initConfig.comMode.TYPE == EnumData.COMType.CamIO)
                        {
                            item_IOIn.DropDownItems.Clear();
                            item_IOOut.DropDownItems.Clear();
                            cb_IO = new ToolStripComboBox();
                            int total_io = 3;
                            for (int io = 0; io < total_io; io++)
                            {
                                cb_IO.Items.Add(io);
                            }
                            cb_IO.SelectedIndexChanged += new EventHandler(IO_SelectIn_Click);
                            bool bContain = false;
                            for (int n = 0; n < DataSerializer._COMConfig.listIOSet.Count; n++)
                            {
                                IOSet io = DataSerializer._COMConfig.listIOSet[n];
                                //if (io.camItem.cam == ncam && io.camItem.item == m_item)
                                //{
                                //    nPreIO_in = io.read;
                                //    bContain = true;
                                //}
                            }
                            if (!bContain)
                            {
                                nPreIO_in = -1;
                            }
                            if (GlobalData.Config._language == EnumData.Language.english)
                            {
                                item_IOIn.DropDownItems.Add("Current point:" + nPreIO_in);
                            }
                            else
                            {
                                item_IOIn.DropDownItems.Add("当前点位：" + nPreIO_in);
                            }

                            item_IOIn.DropDownItems.Add(cb_IO);
                            contextMenuStrip2.Items.Add(item_IOIn);
                            contextMenuStrip2.Items.Add(item_IOOut);
                        }
                        CurrentNode.ContextMenuStrip = contextMenuStrip2;
                        treeViewFun.SelectedNode = CurrentNode;
                        m_SelNode_z = CurrentNode.Text;
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString().Log();
            }
        }
        private void IO_SelectIn_Click(object sender, EventArgs e)
        {
            try
            {
                int nSelIO = cb_IO.SelectedIndex;
                if (GlobalData.Config._language == EnumData.Language.english)
                {
                    item_IOIn.DropDownItems[0].Text = "Current point:" + nSelIO;
                }
                else
                {
                    item_IOIn.DropDownItems[0].Text = "当前点位：" + nSelIO;
                }

                IOSet ioSet = new IOSet
                {
                    read = nSelIO
                };
                ioSet.camItem.cam = 10;///???
                ioSet.camItem.item = m_item;
                bool bContain = false;
                for (int n = 0; n < DataSerializer._COMConfig.listIOSet.Count; n++)
                {
                    IOSet io = DataSerializer._COMConfig.listIOSet[n];
                    if (10 == io.camItem.cam && m_item == io.camItem.item)
                    {
                        io.read = nSelIO;
                        DataSerializer._COMConfig.listIOSet[n] = io;
                        ioSet = io;
                        bContain = true;
                    }
                }
                if (!bContain)
                {
                    DataSerializer._COMConfig.listIOSet.Add(ioSet);
                }
                StaticFun.SaveData.SaveIOConfig(ioSet);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        FormShowSet formShowSet;
        private void ContextMenuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            string strItem = e.ClickedItem.Text;
            string strNode = CurrentNode.Parent.Text;
            int camID = int.Parse(Regex.Replace(strNode, "[^0-9]", ""));
            if ("删除" == strItem || "Delete" == strItem)
            {
                try
                {
                    if (m_SelNode_z != null)
                    {
                        string strCam = m_SelNode_z;
                        if (strCam == "剥皮检测" || strCam == "插壳检测" || strCam == "端子检测" || strCam == "线序检测" || strCam == "插壳检测-侧面" || strCam == "Peeling detection" || strCam == "Shell insertion detection" ||
                        strCam == "Terminal detection" || strCam == "Line sequence detection" ||
                        strCam == "Shell Insertion Inspection-Side")
                        {
                            foreach (TreeNode node in treeViewFun.SelectedNode.Parent.Nodes)
                            {
                                if (node.Text == strCam)
                                {
                                    treeViewFun.SelectedNode.Parent.Nodes.Remove(node);
                                    break;
                                }
                            }

                        }
                        RefreshCheckList();
                    }
                }
                catch (SystemException ex)
                {
                    ex.ToString();
                }
            }
            else if ("显示设置" == strItem || "Display Settings" == strItem)
            {
                if (null == formShowSet || formShowSet.IsDisposed)
                {
                    formShowSet = new FormShowSet(camID, InspectFunction.GetEnumCheckItem(m_SelNode_z))
                    {
                        TopMost = true
                    };
                    formShowSet.Show();
                }
                else
                {
                    formShowSet.TopMost = true;
                }
            }
            else if ("I/O输出点" == strItem || "I/O Output Point" == strItem)
            {
                if (null == formIOSend || formIOSend.IsDisposed)
                {
                    //formIOSend = new FormIOSend(10, m_SelNode_z, m_item)
                    //{
                    //    TopMost = true
                    //};
                    //formIOSend.Show();
                }
                else
                {
                    formIOSend.TopMost = true;
                }

            }
            
        }

    }
}

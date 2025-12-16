namespace VisionPlatform
{
    partial class CtrlLabelMove
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtrlLabelMove));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Remove = new System.Windows.Forms.ToolStripMenuItem();
            this.Clear = new System.Windows.Forms.ToolStripMenuItem();
            this.but_Test = new System.Windows.Forms.Button();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbBox_ImageSel = new System.Windows.Forms.ComboBox();
            this.ctrlNccModel = new VisionPlatform.CtrlNccModel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.panel_Item = new System.Windows.Forms.Panel();
            this.tLPanel_Point = new System.Windows.Forms.TableLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.tLPanel_Box = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_ShowBoxLine = new System.Windows.Forms.Button();
            this.but_BoxLineROI = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ctrlFitLine_Box = new VisionPlatform.CtrlFitLine();
            this.tLPanel_Label = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.ctrlFitLine_Label = new VisionPlatform.CtrlFitLine();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_ShowLabelLine = new System.Windows.Forms.Button();
            this.but_LabelLineROI = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.MoveValueRange = new VisionPlatform.CtrlValueRange();
            this.label_Name = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.listView_Item = new System.Windows.Forms.ListView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.DropDownBut_Add = new System.Windows.Forms.ToolStripDropDownButton();
            this.模板中心到边缘线的距离 = new System.Windows.Forms.ToolStripMenuItem();
            this.标签与边缘线的间距 = new System.Windows.Forms.ToolStripMenuItem();
            this.模板中心到点的矢量 = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.AngleValueRange = new VisionPlatform.CtrlValueRange();
            this.ctrlNccModel1 = new VisionPlatform.CtrlNccModel();
            this.contextMenuStrip1.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel_Item.SuspendLayout();
            this.tLPanel_Point.SuspendLayout();
            this.tLPanel_Box.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tLPanel_Label.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Remove,
            this.Clear});
            this.contextMenuStrip1.Name = "contextMenuStrip";
            this.contextMenuStrip1.Size = new System.Drawing.Size(101, 48);
            // 
            // Remove
            // 
            this.Remove.Name = "Remove";
            this.Remove.Size = new System.Drawing.Size(100, 22);
            this.Remove.Text = "删除";
            this.Remove.Click += new System.EventHandler(this.Remove_Click);
            // 
            // Clear
            // 
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(100, 22);
            this.Clear.Text = "清空";
            this.Clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // but_Test
            // 
            this.but_Test.BackColor = System.Drawing.SystemColors.Control;
            this.but_Test.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.but_Test.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.but_Test.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.but_Test.Location = new System.Drawing.Point(0, 447);
            this.but_Test.Margin = new System.Windows.Forms.Padding(2);
            this.but_Test.Name = "but_Test";
            this.but_Test.Size = new System.Drawing.Size(435, 30);
            this.but_Test.TabIndex = 0;
            this.but_Test.Text = "测试";
            this.but_Test.UseVisualStyleBackColor = true;
            this.but_Test.Click += new System.EventHandler(this.Inspect);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel4.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.cmbBox_ImageSel, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.ctrlNccModel, 1, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(515, 54);
            this.tableLayoutPanel4.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 9.45F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(1, 25);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 28);
            this.label4.TabIndex = 21;
            this.label4.Text = "标签匹配";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9.45F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(1, 1);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 23);
            this.label3.TabIndex = 19;
            this.label3.Text = "图像选择";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbBox_ImageSel
            // 
            this.cmbBox_ImageSel.Dock = System.Windows.Forms.DockStyle.Left;
            this.cmbBox_ImageSel.FormattingEnabled = true;
            this.cmbBox_ImageSel.Items.AddRange(new object[] {
            "图像1",
            "图像2",
            "图像3",
            "图像4"});
            this.cmbBox_ImageSel.Location = new System.Drawing.Point(68, 2);
            this.cmbBox_ImageSel.Margin = new System.Windows.Forms.Padding(1);
            this.cmbBox_ImageSel.Name = "cmbBox_ImageSel";
            this.cmbBox_ImageSel.Size = new System.Drawing.Size(121, 21);
            this.cmbBox_ImageSel.TabIndex = 20;
            this.cmbBox_ImageSel.SelectedIndexChanged += new System.EventHandler(this.cmbBox_ImageSel_SelectedIndexChanged);
            // 
            // ctrlNccModel
            // 
            this.ctrlNccModel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlNccModel.Location = new System.Drawing.Point(67, 25);
            this.ctrlNccModel.Margin = new System.Windows.Forms.Padding(0);
            this.ctrlNccModel.Name = "ctrlNccModel";
            this.ctrlNccModel.Size = new System.Drawing.Size(447, 28);
            this.ctrlNccModel.TabIndex = 25;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel3.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 77F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.panel_Item, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 100);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 478F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(515, 479);
            this.tableLayoutPanel3.TabIndex = 9;
            // 
            // panel_Item
            // 
            this.panel_Item.AutoScroll = true;
            this.panel_Item.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel_Item.Controls.Add(this.but_Test);
            this.panel_Item.Controls.Add(this.tLPanel_Point);
            this.panel_Item.Controls.Add(this.tLPanel_Box);
            this.panel_Item.Controls.Add(this.tLPanel_Label);
            this.panel_Item.Controls.Add(this.MoveValueRange);
            this.panel_Item.Controls.Add(this.label_Name);
            this.panel_Item.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Item.Location = new System.Drawing.Point(79, 1);
            this.panel_Item.Margin = new System.Windows.Forms.Padding(0);
            this.panel_Item.Name = "panel_Item";
            this.panel_Item.Size = new System.Drawing.Size(435, 477);
            this.panel_Item.TabIndex = 1;
            // 
            // tLPanel_Point
            // 
            this.tLPanel_Point.BackColor = System.Drawing.SystemColors.Control;
            this.tLPanel_Point.ColumnCount = 1;
            this.tLPanel_Point.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tLPanel_Point.Controls.Add(this.label6, 0, 0);
            this.tLPanel_Point.Dock = System.Windows.Forms.DockStyle.Top;
            this.tLPanel_Point.Location = new System.Drawing.Point(0, 307);
            this.tLPanel_Point.Name = "tLPanel_Point";
            this.tLPanel_Point.RowCount = 2;
            this.tLPanel_Point.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 21F));
            this.tLPanel_Point.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 79F));
            this.tLPanel_Point.Size = new System.Drawing.Size(435, 114);
            this.tLPanel_Point.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.LightSteelBlue;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Margin = new System.Windows.Forms.Padding(0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(435, 23);
            this.label6.TabIndex = 4;
            this.label6.Text = "盒体的点";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tLPanel_Box
            // 
            this.tLPanel_Box.BackColor = System.Drawing.SystemColors.Control;
            this.tLPanel_Box.ColumnCount = 1;
            this.tLPanel_Box.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tLPanel_Box.Controls.Add(this.tableLayoutPanel5, 0, 1);
            this.tLPanel_Box.Controls.Add(this.label5, 0, 0);
            this.tLPanel_Box.Controls.Add(this.ctrlFitLine_Box, 0, 2);
            this.tLPanel_Box.Dock = System.Windows.Forms.DockStyle.Top;
            this.tLPanel_Box.Location = new System.Drawing.Point(0, 178);
            this.tLPanel_Box.Name = "tLPanel_Box";
            this.tLPanel_Box.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.tLPanel_Box.RowCount = 3;
            this.tLPanel_Box.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tLPanel_Box.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tLPanel_Box.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tLPanel_Box.Size = new System.Drawing.Size(435, 129);
            this.tLPanel_Box.TabIndex = 3;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel5.ColumnCount = 4;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 67F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 68F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.btn_ShowBoxLine, 2, 0);
            this.tableLayoutPanel5.Controls.Add(this.but_BoxLineROI, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.label8, 0, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 23);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(435, 28);
            this.tableLayoutPanel5.TabIndex = 6;
            // 
            // btn_ShowBoxLine
            // 
            this.btn_ShowBoxLine.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btn_ShowBoxLine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_ShowBoxLine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ShowBoxLine.Location = new System.Drawing.Point(141, 2);
            this.btn_ShowBoxLine.Margin = new System.Windows.Forms.Padding(1);
            this.btn_ShowBoxLine.Name = "btn_ShowBoxLine";
            this.btn_ShowBoxLine.Size = new System.Drawing.Size(66, 24);
            this.btn_ShowBoxLine.TabIndex = 2;
            this.btn_ShowBoxLine.Text = "显示";
            this.btn_ShowBoxLine.UseVisualStyleBackColor = false;
            this.btn_ShowBoxLine.Click += new System.EventHandler(this.btn_ShowBoxLine_Click);
            // 
            // but_BoxLineROI
            // 
            this.but_BoxLineROI.BackColor = System.Drawing.Color.LightSteelBlue;
            this.but_BoxLineROI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.but_BoxLineROI.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.but_BoxLineROI.Location = new System.Drawing.Point(70, 2);
            this.but_BoxLineROI.Margin = new System.Windows.Forms.Padding(1);
            this.but_BoxLineROI.Name = "but_BoxLineROI";
            this.but_BoxLineROI.Size = new System.Drawing.Size(68, 24);
            this.but_BoxLineROI.TabIndex = 7;
            this.but_BoxLineROI.Text = "设置";
            this.but_BoxLineROI.UseVisualStyleBackColor = false;
            this.but_BoxLineROI.Click += new System.EventHandler(this.but_BoxLineROI_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Font = new System.Drawing.Font("宋体", 10F);
            this.label8.Location = new System.Drawing.Point(1, 1);
            this.label8.Margin = new System.Windows.Forms.Padding(0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 26);
            this.label8.TabIndex = 5;
            this.label8.Text = "检测位置";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.LightSteelBlue;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(0, 3);
            this.label5.Margin = new System.Windows.Forms.Padding(0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(435, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "盒体边线";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ctrlFitLine_Box
            // 
            this.ctrlFitLine_Box.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlFitLine_Box.Font = new System.Drawing.Font("宋体", 10F);
            this.ctrlFitLine_Box.Location = new System.Drawing.Point(1, 52);
            this.ctrlFitLine_Box.Margin = new System.Windows.Forms.Padding(1);
            this.ctrlFitLine_Box.Name = "ctrlFitLine_Box";
            this.ctrlFitLine_Box.Size = new System.Drawing.Size(433, 76);
            this.ctrlFitLine_Box.TabIndex = 3;
            // 
            // tLPanel_Label
            // 
            this.tLPanel_Label.BackColor = System.Drawing.SystemColors.Control;
            this.tLPanel_Label.ColumnCount = 1;
            this.tLPanel_Label.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tLPanel_Label.Controls.Add(this.label1, 0, 0);
            this.tLPanel_Label.Controls.Add(this.ctrlFitLine_Label, 0, 2);
            this.tLPanel_Label.Controls.Add(this.tableLayoutPanel1, 0, 1);
            this.tLPanel_Label.Dock = System.Windows.Forms.DockStyle.Top;
            this.tLPanel_Label.Location = new System.Drawing.Point(0, 46);
            this.tLPanel_Label.Name = "tLPanel_Label";
            this.tLPanel_Label.RowCount = 3;
            this.tLPanel_Label.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tLPanel_Label.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tLPanel_Label.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tLPanel_Label.Size = new System.Drawing.Size(435, 132);
            this.tLPanel_Label.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(435, 22);
            this.label1.TabIndex = 4;
            this.label1.Text = "标签边线";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ctrlFitLine_Label
            // 
            this.ctrlFitLine_Label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlFitLine_Label.Font = new System.Drawing.Font("宋体", 10F);
            this.ctrlFitLine_Label.Location = new System.Drawing.Point(1, 51);
            this.ctrlFitLine_Label.Margin = new System.Windows.Forms.Padding(1);
            this.ctrlFitLine_Label.Name = "ctrlFitLine_Label";
            this.ctrlFitLine_Label.Size = new System.Drawing.Size(433, 80);
            this.ctrlFitLine_Label.TabIndex = 3;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 67F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 68F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.btn_ShowLabelLine, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.but_LabelLineROI, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 22);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(435, 28);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // btn_ShowLabelLine
            // 
            this.btn_ShowLabelLine.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btn_ShowLabelLine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_ShowLabelLine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ShowLabelLine.Location = new System.Drawing.Point(141, 2);
            this.btn_ShowLabelLine.Margin = new System.Windows.Forms.Padding(1);
            this.btn_ShowLabelLine.Name = "btn_ShowLabelLine";
            this.btn_ShowLabelLine.Size = new System.Drawing.Size(66, 24);
            this.btn_ShowLabelLine.TabIndex = 2;
            this.btn_ShowLabelLine.Text = "显示";
            this.btn_ShowLabelLine.UseVisualStyleBackColor = false;
            this.btn_ShowLabelLine.Click += new System.EventHandler(this.btn_ShowLabelLine_Click);
            // 
            // but_LabelLineROI
            // 
            this.but_LabelLineROI.BackColor = System.Drawing.Color.LightSteelBlue;
            this.but_LabelLineROI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.but_LabelLineROI.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.but_LabelLineROI.Location = new System.Drawing.Point(70, 2);
            this.but_LabelLineROI.Margin = new System.Windows.Forms.Padding(1);
            this.but_LabelLineROI.Name = "but_LabelLineROI";
            this.but_LabelLineROI.Size = new System.Drawing.Size(68, 24);
            this.but_LabelLineROI.TabIndex = 7;
            this.but_LabelLineROI.Text = "设置";
            this.but_LabelLineROI.UseVisualStyleBackColor = false;
            this.but_LabelLineROI.Click += new System.EventHandler(this.but_LabelLineROI_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Font = new System.Drawing.Font("宋体", 10F);
            this.label7.Location = new System.Drawing.Point(1, 1);
            this.label7.Margin = new System.Windows.Forms.Padding(0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 26);
            this.label7.TabIndex = 5;
            this.label7.Text = "检测位置";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MoveValueRange
            // 
            this.MoveValueRange.BackColor = System.Drawing.SystemColors.Control;
            this.MoveValueRange.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MoveValueRange.Dock = System.Windows.Forms.DockStyle.Top;
            this.MoveValueRange.Location = new System.Drawing.Point(0, 19);
            this.MoveValueRange.Margin = new System.Windows.Forms.Padding(0);
            this.MoveValueRange.Name = "MoveValueRange";
            this.MoveValueRange.Size = new System.Drawing.Size(435, 27);
            this.MoveValueRange.TabIndex = 6;
            // 
            // label_Name
            // 
            this.label_Name.AutoSize = true;
            this.label_Name.Dock = System.Windows.Forms.DockStyle.Top;
            this.label_Name.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.label_Name.Location = new System.Drawing.Point(0, 0);
            this.label_Name.Name = "label_Name";
            this.label_Name.Size = new System.Drawing.Size(51, 19);
            this.label_Name.TabIndex = 1;
            this.label_Name.Text = "检测项";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.listView_Item);
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(77, 477);
            this.panel1.TabIndex = 0;
            // 
            // listView_Item
            // 
            this.listView_Item.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listView_Item.ContextMenuStrip = this.contextMenuStrip1;
            this.listView_Item.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView_Item.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listView_Item.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listView_Item.HideSelection = false;
            this.listView_Item.LargeImageList = this.imageList;
            this.listView_Item.Location = new System.Drawing.Point(0, 40);
            this.listView_Item.Margin = new System.Windows.Forms.Padding(1);
            this.listView_Item.MultiSelect = false;
            this.listView_Item.Name = "listView_Item";
            this.listView_Item.Size = new System.Drawing.Size(77, 437);
            this.listView_Item.SmallImageList = this.imageList;
            this.listView_Item.TabIndex = 3;
            this.listView_Item.UseCompatibleStateImageBehavior = false;
            this.listView_Item.View = System.Windows.Forms.View.SmallIcon;
            this.listView_Item.SelectedIndexChanged += new System.EventHandler(this.listView_Item_SelectedIndexChanged);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "点到线.png");
            this.imageList.Images.SetKeyName(1, "线到线.png");
            this.imageList.Images.SetKeyName(2, "点到点.png");
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DropDownBut_Add});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(77, 40);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // DropDownBut_Add
            // 
            this.DropDownBut_Add.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.模板中心到边缘线的距离,
            this.标签与边缘线的间距,
            this.模板中心到点的矢量});
            this.DropDownBut_Add.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DropDownBut_Add.Image = ((System.Drawing.Image)(resources.GetObject("DropDownBut_Add.Image")));
            this.DropDownBut_Add.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DropDownBut_Add.Name = "DropDownBut_Add";
            this.DropDownBut_Add.Size = new System.Drawing.Size(57, 37);
            this.DropDownBut_Add.Text = "新增项";
            this.DropDownBut_Add.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.DropDownBut_Add.Click += new System.EventHandler(this.DropDownBut_Add_Click);
            // 
            // 模板中心到边缘线的距离
            // 
            this.模板中心到边缘线的距离.Image = ((System.Drawing.Image)(resources.GetObject("模板中心到边缘线的距离.Image")));
            this.模板中心到边缘线的距离.Name = "模板中心到边缘线的距离";
            this.模板中心到边缘线的距离.Size = new System.Drawing.Size(208, 22);
            this.模板中心到边缘线的距离.Text = "模板中心到边缘线的距离";
            this.模板中心到边缘线的距离.Click += new System.EventHandler(this.but_AddItem_Click);
            // 
            // 标签与边缘线的间距
            // 
            this.标签与边缘线的间距.Image = ((System.Drawing.Image)(resources.GetObject("标签与边缘线的间距.Image")));
            this.标签与边缘线的间距.Name = "标签与边缘线的间距";
            this.标签与边缘线的间距.Size = new System.Drawing.Size(208, 22);
            this.标签与边缘线的间距.Text = "标签与边缘线的间距";
            this.标签与边缘线的间距.Click += new System.EventHandler(this.but_AddItem_Click);
            // 
            // 模板中心到点的矢量
            // 
            this.模板中心到点的矢量.Image = ((System.Drawing.Image)(resources.GetObject("模板中心到点的矢量.Image")));
            this.模板中心到点的矢量.Name = "模板中心到点的矢量";
            this.模板中心到点的矢量.Size = new System.Drawing.Size(208, 22);
            this.模板中心到点的矢量.Text = "模板中心到点的矢量";
            this.模板中心到点的矢量.Click += new System.EventHandler(this.but_AddItem_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(0, 54);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(515, 20);
            this.label2.TabIndex = 25;
            this.label2.Text = "参数设置";
            // 
            // AngleValueRange
            // 
            this.AngleValueRange.BackColor = System.Drawing.SystemColors.Control;
            this.AngleValueRange.Dock = System.Windows.Forms.DockStyle.Top;
            this.AngleValueRange.Location = new System.Drawing.Point(0, 74);
            this.AngleValueRange.Margin = new System.Windows.Forms.Padding(0);
            this.AngleValueRange.Name = "AngleValueRange";
            this.AngleValueRange.Size = new System.Drawing.Size(515, 26);
            this.AngleValueRange.TabIndex = 25;
            // 
            // ctrlNccModel1
            // 
            this.ctrlNccModel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlNccModel1.Location = new System.Drawing.Point(71, 25);
            this.ctrlNccModel1.Margin = new System.Windows.Forms.Padding(0);
            this.ctrlNccModel1.Name = "ctrlNccModel1";
            this.ctrlNccModel1.Size = new System.Drawing.Size(359, 26);
            this.ctrlNccModel1.TabIndex = 22;
            // 
            // CtrlLabelMove
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.Controls.Add(this.tableLayoutPanel3);
            this.Controls.Add(this.AngleValueRange);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tableLayoutPanel4);
            this.Font = new System.Drawing.Font("宋体", 10F);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "CtrlLabelMove";
            this.Size = new System.Drawing.Size(515, 579);
            this.contextMenuStrip1.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.panel_Item.ResumeLayout(false);
            this.panel_Item.PerformLayout();
            this.tLPanel_Point.ResumeLayout(false);
            this.tLPanel_Point.PerformLayout();
            this.tLPanel_Box.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tLPanel_Label.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem Remove;
        private System.Windows.Forms.ToolStripMenuItem Clear;
        private System.Windows.Forms.Button but_Test;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbBox_ImageSel;
        private System.Windows.Forms.Label label4;
        private CtrlNccModel ctrlNccModel1;
        private CtrlNccModel ctrlNccModel;
        private System.Windows.Forms.Label label2;
        private CtrlValueRange AngleValueRange;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView listView_Item;
        private System.Windows.Forms.Panel panel_Item;
        private System.Windows.Forms.Label label_Name;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton DropDownBut_Add;
        private System.Windows.Forms.ToolStripMenuItem 模板中心到边缘线的距离;
        private System.Windows.Forms.ToolStripMenuItem 标签与边缘线的间距;
        private System.Windows.Forms.ToolStripMenuItem 模板中心到点的矢量;
        private System.Windows.Forms.TableLayoutPanel tLPanel_Label;
        private CtrlFitLine ctrlFitLine_Label;
        private System.Windows.Forms.TableLayoutPanel tLPanel_Box;
        private System.Windows.Forms.Label label5;
        private CtrlFitLine ctrlFitLine_Box;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tLPanel_Point;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Button btn_ShowBoxLine;
        private System.Windows.Forms.Button but_BoxLineROI;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btn_ShowLabelLine;
        private System.Windows.Forms.Button but_LabelLineROI;
        private CtrlValueRange MoveValueRange;
    }
}

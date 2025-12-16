namespace VisionPlatform
{
    partial class CtrlSealedLabel
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
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbBox_ImageSel = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.ctrlNccModel1 = new VisionPlatform.CtrlNccModel();
            this.tLPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.tLPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.ctrlNccModel2 = new VisionPlatform.CtrlNccModel();
            this.but_Test = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.panel_Item = new System.Windows.Forms.Panel();
            this.tLPanel_Label = new System.Windows.Forms.TableLayoutPanel();
            this.ctrlFitLine = new VisionPlatform.CtrlFitLine();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_ShowLabelLine = new System.Windows.Forms.Button();
            this.but_LabelLineROI = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.ValueRange1 = new VisionPlatform.CtrlValueRange();
            this.label_Name = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.listView_Item = new System.Windows.Forms.ListView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Remove = new System.Windows.Forms.ToolStripMenuItem();
            this.Clear = new System.Windows.Forms.ToolStripMenuItem();
            this.but_Add = new System.Windows.Forms.Button();
            this.ValueRange2 = new VisionPlatform.CtrlValueRange();
            this.tableLayoutPanel4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tLPanel1.SuspendLayout();
            this.tLPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel_Item.SuspendLayout();
            this.tLPanel_Label.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel4.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.cmbBox_ImageSel, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.panel1, 1, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(439, 55);
            this.tableLayoutPanel4.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9.45F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(1, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 28);
            this.label1.TabIndex = 26;
            this.label1.Text = "标签数量";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9.45F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(1, 1);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 24);
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
            this.cmbBox_ImageSel.Location = new System.Drawing.Point(73, 2);
            this.cmbBox_ImageSel.Margin = new System.Windows.Forms.Padding(1);
            this.cmbBox_ImageSel.Name = "cmbBox_ImageSel";
            this.cmbBox_ImageSel.Size = new System.Drawing.Size(140, 21);
            this.cmbBox_ImageSel.TabIndex = 20;
            this.cmbBox_ImageSel.SelectedIndexChanged += new System.EventHandler(this.cmbBox_ImageSel_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.checkBox2);
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(72, 26);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(366, 28);
            this.panel1.TabIndex = 27;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.checkBox2.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox2.Location = new System.Drawing.Point(39, 0);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(36, 28);
            this.checkBox2.TabIndex = 1;
            this.checkBox2.Text = "2";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.checkBox1.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox1.Location = new System.Drawing.Point(0, 0);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.checkBox1.Size = new System.Drawing.Size(39, 28);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "1";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // ctrlNccModel1
            // 
            this.ctrlNccModel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlNccModel1.Location = new System.Drawing.Point(72, 2);
            this.ctrlNccModel1.Margin = new System.Windows.Forms.Padding(0);
            this.ctrlNccModel1.Name = "ctrlNccModel1";
            this.ctrlNccModel1.Size = new System.Drawing.Size(366, 29);
            this.ctrlNccModel1.TabIndex = 25;
            // 
            // tLPanel1
            // 
            this.tLPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.tLPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tLPanel1.ColumnCount = 2;
            this.tLPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tLPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tLPanel1.Controls.Add(this.label2, 0, 0);
            this.tLPanel1.Controls.Add(this.ctrlNccModel1, 1, 0);
            this.tLPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tLPanel1.Location = new System.Drawing.Point(0, 55);
            this.tLPanel1.Margin = new System.Windows.Forms.Padding(1);
            this.tLPanel1.Name = "tLPanel1";
            this.tLPanel1.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.tLPanel1.RowCount = 1;
            this.tLPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tLPanel1.Size = new System.Drawing.Size(439, 32);
            this.tLPanel1.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9.45F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(1, 2);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 29);
            this.label2.TabIndex = 22;
            this.label2.Text = "标签1匹配";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tLPanel2
            // 
            this.tLPanel2.BackColor = System.Drawing.SystemColors.Control;
            this.tLPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tLPanel2.ColumnCount = 2;
            this.tLPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tLPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tLPanel2.Controls.Add(this.label4, 0, 0);
            this.tLPanel2.Controls.Add(this.ctrlNccModel2, 1, 0);
            this.tLPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tLPanel2.Location = new System.Drawing.Point(0, 87);
            this.tLPanel2.Margin = new System.Windows.Forms.Padding(1);
            this.tLPanel2.Name = "tLPanel2";
            this.tLPanel2.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.tLPanel2.RowCount = 1;
            this.tLPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tLPanel2.Size = new System.Drawing.Size(439, 32);
            this.tLPanel2.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 9.45F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(1, 2);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 29);
            this.label4.TabIndex = 22;
            this.label4.Text = "标签2匹配";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ctrlNccModel2
            // 
            this.ctrlNccModel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlNccModel2.Location = new System.Drawing.Point(72, 2);
            this.ctrlNccModel2.Margin = new System.Windows.Forms.Padding(0);
            this.ctrlNccModel2.Name = "ctrlNccModel2";
            this.ctrlNccModel2.Size = new System.Drawing.Size(366, 29);
            this.ctrlNccModel2.TabIndex = 25;
            // 
            // but_Test
            // 
            this.but_Test.BackColor = System.Drawing.SystemColors.Control;
            this.but_Test.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.but_Test.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.but_Test.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.but_Test.Location = new System.Drawing.Point(0, 550);
            this.but_Test.Margin = new System.Windows.Forms.Padding(2);
            this.but_Test.Name = "but_Test";
            this.but_Test.Size = new System.Drawing.Size(439, 30);
            this.but_Test.TabIndex = 14;
            this.but_Test.Text = "测试";
            this.but_Test.UseVisualStyleBackColor = true;
            this.but_Test.Click += new System.EventHandler(this.Inspect);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel3.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.panel_Item, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 119);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(439, 431);
            this.tableLayoutPanel3.TabIndex = 15;
            // 
            // panel_Item
            // 
            this.panel_Item.AutoScroll = true;
            this.panel_Item.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel_Item.Controls.Add(this.tLPanel_Label);
            this.panel_Item.Controls.Add(this.ValueRange2);
            this.panel_Item.Controls.Add(this.ValueRange1);
            this.panel_Item.Controls.Add(this.label_Name);
            this.panel_Item.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Item.Location = new System.Drawing.Point(72, 1);
            this.panel_Item.Margin = new System.Windows.Forms.Padding(0);
            this.panel_Item.Name = "panel_Item";
            this.panel_Item.Size = new System.Drawing.Size(366, 429);
            this.panel_Item.TabIndex = 1;
            // 
            // tLPanel_Label
            // 
            this.tLPanel_Label.BackColor = System.Drawing.SystemColors.Control;
            this.tLPanel_Label.ColumnCount = 1;
            this.tLPanel_Label.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tLPanel_Label.Controls.Add(this.ctrlFitLine, 0, 1);
            this.tLPanel_Label.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.tLPanel_Label.Dock = System.Windows.Forms.DockStyle.Top;
            this.tLPanel_Label.Location = new System.Drawing.Point(0, 75);
            this.tLPanel_Label.Name = "tLPanel_Label";
            this.tLPanel_Label.RowCount = 2;
            this.tLPanel_Label.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tLPanel_Label.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tLPanel_Label.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tLPanel_Label.Size = new System.Drawing.Size(366, 109);
            this.tLPanel_Label.TabIndex = 2;
            // 
            // ctrlFitLine
            // 
            this.ctrlFitLine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlFitLine.Font = new System.Drawing.Font("宋体", 10F);
            this.ctrlFitLine.Location = new System.Drawing.Point(1, 29);
            this.ctrlFitLine.Margin = new System.Windows.Forms.Padding(1);
            this.ctrlFitLine.Name = "ctrlFitLine";
            this.ctrlFitLine.Size = new System.Drawing.Size(364, 79);
            this.ctrlFitLine.TabIndex = 3;
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
            this.tableLayoutPanel1.Controls.Add(this.label9, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(366, 28);
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
            this.btn_ShowLabelLine.Click += new System.EventHandler(this.btn_ShowROI_Click);
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
            this.but_LabelLineROI.Click += new System.EventHandler(this.but_LineROI_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Font = new System.Drawing.Font("宋体", 10F);
            this.label9.Location = new System.Drawing.Point(1, 1);
            this.label9.Margin = new System.Windows.Forms.Padding(0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 26);
            this.label9.TabIndex = 5;
            this.label9.Text = "检测位置";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ValueRange1
            // 
            this.ValueRange1.BackColor = System.Drawing.SystemColors.Control;
            this.ValueRange1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ValueRange1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ValueRange1.Location = new System.Drawing.Point(0, 19);
            this.ValueRange1.Margin = new System.Windows.Forms.Padding(0);
            this.ValueRange1.Name = "ValueRange1";
            this.ValueRange1.Size = new System.Drawing.Size(366, 27);
            this.ValueRange1.TabIndex = 6;
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
            // panel2
            // 
            this.panel2.Controls.Add(this.listView_Item);
            this.panel2.Controls.Add(this.but_Add);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(1, 1);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(70, 429);
            this.panel2.TabIndex = 0;
            // 
            // listView_Item
            // 
            this.listView_Item.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listView_Item.ContextMenuStrip = this.contextMenuStrip1;
            this.listView_Item.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView_Item.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listView_Item.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listView_Item.HideSelection = false;
            this.listView_Item.Location = new System.Drawing.Point(0, 28);
            this.listView_Item.Margin = new System.Windows.Forms.Padding(1);
            this.listView_Item.MultiSelect = false;
            this.listView_Item.Name = "listView_Item";
            this.listView_Item.Size = new System.Drawing.Size(70, 401);
            this.listView_Item.TabIndex = 3;
            this.listView_Item.UseCompatibleStateImageBehavior = false;
            this.listView_Item.View = System.Windows.Forms.View.SmallIcon;
            this.listView_Item.SelectedIndexChanged += new System.EventHandler(this.listView_Item_SelectedIndexChanged);
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
            // but_Add
            // 
            this.but_Add.BackColor = System.Drawing.Color.LightSteelBlue;
            this.but_Add.Dock = System.Windows.Forms.DockStyle.Top;
            this.but_Add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.but_Add.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.but_Add.Location = new System.Drawing.Point(0, 0);
            this.but_Add.Margin = new System.Windows.Forms.Padding(1);
            this.but_Add.Name = "but_Add";
            this.but_Add.Size = new System.Drawing.Size(70, 28);
            this.but_Add.TabIndex = 4;
            this.but_Add.Text = "新增";
            this.but_Add.UseVisualStyleBackColor = false;
            this.but_Add.Click += new System.EventHandler(this.but_AddItem_Click);
            // 
            // ValueRange2
            // 
            this.ValueRange2.BackColor = System.Drawing.SystemColors.Control;
            this.ValueRange2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ValueRange2.Dock = System.Windows.Forms.DockStyle.Top;
            this.ValueRange2.Location = new System.Drawing.Point(0, 46);
            this.ValueRange2.Margin = new System.Windows.Forms.Padding(0);
            this.ValueRange2.Name = "ValueRange2";
            this.ValueRange2.Size = new System.Drawing.Size(366, 29);
            this.ValueRange2.TabIndex = 7;
            // 
            // CtrlSealedLabel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel3);
            this.Controls.Add(this.but_Test);
            this.Controls.Add(this.tLPanel2);
            this.Controls.Add(this.tLPanel1);
            this.Controls.Add(this.tableLayoutPanel4);
            this.Font = new System.Drawing.Font("宋体", 10F);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "CtrlSealedLabel";
            this.Size = new System.Drawing.Size(439, 580);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tLPanel1.ResumeLayout(false);
            this.tLPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.panel_Item.ResumeLayout(false);
            this.panel_Item.PerformLayout();
            this.tLPanel_Label.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbBox_ImageSel;
        private CtrlNccModel ctrlNccModel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TableLayoutPanel tLPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel tLPanel2;
        private System.Windows.Forms.Label label4;
        private CtrlNccModel ctrlNccModel2;
        private System.Windows.Forms.Button but_Test;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Panel panel_Item;
        private System.Windows.Forms.TableLayoutPanel tLPanel_Label;
        private CtrlFitLine ctrlFitLine;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btn_ShowLabelLine;
        private System.Windows.Forms.Button but_LabelLineROI;
        private System.Windows.Forms.Label label9;
        private CtrlValueRange ValueRange1;
        private System.Windows.Forms.Label label_Name;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListView listView_Item;
        private System.Windows.Forms.Button but_Add;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem Remove;
        private System.Windows.Forms.ToolStripMenuItem Clear;
        private CtrlValueRange ValueRange2;
    }
}

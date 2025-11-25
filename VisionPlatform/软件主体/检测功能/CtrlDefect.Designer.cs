namespace VisionPlatform
{
    partial class CtrlDefect
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
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.but_Test = new System.Windows.Forms.Button();
            this.but_SaveParam = new System.Windows.Forms.Button();
            this.tableLayoutPanel10 = new System.Windows.Forms.TableLayoutPanel();
            this.label13 = new System.Windows.Forms.Label();
            this.tLPanel_Broken = new System.Windows.Forms.TableLayoutPanel();
            this.but_SetBrokenROI = new System.Windows.Forms.Button();
            this.btn_ShowBrokenROI = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.numUpD_DirtyScore = new System.Windows.Forms.NumericUpDown();
            this.label_Name = new System.Windows.Forms.Label();
            this.numUpD_BrokenScore = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel10.SuspendLayout();
            this.tLPanel_Broken.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpD_DirtyScore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpD_BrokenScore)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.comboBox1, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(389, 23);
            this.tableLayoutPanel4.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9.45F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 23);
            this.label3.TabIndex = 19;
            this.label3.Text = "图像选择";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "法向量",
            "反照率信息图",
            "梯度信息图",
            "曲率",
            "高度信息图"});
            this.comboBox1.Location = new System.Drawing.Point(70, 1);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(1);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(127, 20);
            this.comboBox1.TabIndex = 20;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoScroll = true;
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 53.43915F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.69312F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.86773F));
            this.tableLayoutPanel2.Controls.Add(this.but_Test, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.but_SaveParam, 3, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 478);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(389, 33);
            this.tableLayoutPanel2.TabIndex = 12;
            // 
            // but_Test
            // 
            this.but_Test.BackColor = System.Drawing.SystemColors.Control;
            this.but_Test.Dock = System.Windows.Forms.DockStyle.Fill;
            this.but_Test.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.but_Test.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.but_Test.Location = new System.Drawing.Point(199, 2);
            this.but_Test.Margin = new System.Windows.Forms.Padding(2);
            this.but_Test.Name = "but_Test";
            this.but_Test.Size = new System.Drawing.Size(76, 29);
            this.but_Test.TabIndex = 0;
            this.but_Test.Text = "测试";
            this.but_Test.UseVisualStyleBackColor = false;
            this.but_Test.Click += new System.EventHandler(this.but_Test_Click);
            // 
            // but_SaveParam
            // 
            this.but_SaveParam.BackColor = System.Drawing.SystemColors.Control;
            this.but_SaveParam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.but_SaveParam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.but_SaveParam.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.but_SaveParam.Location = new System.Drawing.Point(299, 2);
            this.but_SaveParam.Margin = new System.Windows.Forms.Padding(2);
            this.but_SaveParam.Name = "but_SaveParam";
            this.but_SaveParam.Size = new System.Drawing.Size(88, 29);
            this.but_SaveParam.TabIndex = 1;
            this.but_SaveParam.Text = "保存设置";
            this.but_SaveParam.UseVisualStyleBackColor = false;
            this.but_SaveParam.Click += new System.EventHandler(this.but_SaveParam_Click);
            // 
            // tableLayoutPanel10
            // 
            this.tableLayoutPanel10.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel10.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel10.ColumnCount = 2;
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 66F));
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel10.Controls.Add(this.label13, 0, 1);
            this.tableLayoutPanel10.Controls.Add(this.tLPanel_Broken, 1, 0);
            this.tableLayoutPanel10.Controls.Add(this.label12, 0, 0);
            this.tableLayoutPanel10.Controls.Add(this.tableLayoutPanel1, 1, 1);
            this.tableLayoutPanel10.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel10.Font = new System.Drawing.Font("宋体", 10F);
            this.tableLayoutPanel10.Location = new System.Drawing.Point(0, 23);
            this.tableLayoutPanel10.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel10.Name = "tableLayoutPanel10";
            this.tableLayoutPanel10.RowCount = 2;
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 12F));
            this.tableLayoutPanel10.Size = new System.Drawing.Size(389, 80);
            this.tableLayoutPanel10.TabIndex = 41;
            // 
            // label13
            // 
            this.label13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label13.Font = new System.Drawing.Font("宋体", 10F);
            this.label13.Location = new System.Drawing.Point(1, 30);
            this.label13.Margin = new System.Windows.Forms.Padding(0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(66, 49);
            this.label13.TabIndex = 40;
            this.label13.Text = "最低分数";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tLPanel_Broken
            // 
            this.tLPanel_Broken.BackColor = System.Drawing.SystemColors.Control;
            this.tLPanel_Broken.ColumnCount = 3;
            this.tLPanel_Broken.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tLPanel_Broken.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tLPanel_Broken.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tLPanel_Broken.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tLPanel_Broken.Controls.Add(this.but_SetBrokenROI, 0, 0);
            this.tLPanel_Broken.Controls.Add(this.btn_ShowBrokenROI, 1, 0);
            this.tLPanel_Broken.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tLPanel_Broken.Location = new System.Drawing.Point(68, 1);
            this.tLPanel_Broken.Margin = new System.Windows.Forms.Padding(0);
            this.tLPanel_Broken.Name = "tLPanel_Broken";
            this.tLPanel_Broken.RowCount = 1;
            this.tLPanel_Broken.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tLPanel_Broken.Size = new System.Drawing.Size(320, 28);
            this.tLPanel_Broken.TabIndex = 38;
            // 
            // but_SetBrokenROI
            // 
            this.but_SetBrokenROI.BackColor = System.Drawing.Color.LightSteelBlue;
            this.but_SetBrokenROI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.but_SetBrokenROI.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.but_SetBrokenROI.Location = new System.Drawing.Point(1, 1);
            this.but_SetBrokenROI.Margin = new System.Windows.Forms.Padding(1);
            this.but_SetBrokenROI.Name = "but_SetBrokenROI";
            this.but_SetBrokenROI.Size = new System.Drawing.Size(63, 26);
            this.but_SetBrokenROI.TabIndex = 7;
            this.but_SetBrokenROI.Text = "设定";
            this.but_SetBrokenROI.UseVisualStyleBackColor = false;
            this.but_SetBrokenROI.Click += new System.EventHandler(this.but_SetBrokenROI_Click);
            // 
            // btn_ShowBrokenROI
            // 
            this.btn_ShowBrokenROI.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btn_ShowBrokenROI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_ShowBrokenROI.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ShowBrokenROI.Location = new System.Drawing.Point(66, 1);
            this.btn_ShowBrokenROI.Margin = new System.Windows.Forms.Padding(1);
            this.btn_ShowBrokenROI.Name = "btn_ShowBrokenROI";
            this.btn_ShowBrokenROI.Size = new System.Drawing.Size(63, 26);
            this.btn_ShowBrokenROI.TabIndex = 2;
            this.btn_ShowBrokenROI.Text = "显示";
            this.btn_ShowBrokenROI.UseVisualStyleBackColor = false;
            this.btn_ShowBrokenROI.Click += new System.EventHandler(this.btn_ShowBrokenROI_Click);
            // 
            // label12
            // 
            this.label12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label12.Font = new System.Drawing.Font("宋体", 10F);
            this.label12.Location = new System.Drawing.Point(1, 1);
            this.label12.Margin = new System.Windows.Forms.Padding(0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(66, 28);
            this.label12.TabIndex = 39;
            this.label12.Text = "限定区域";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 76F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.numUpD_DirtyScore, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label_Name, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.numUpD_BrokenScore, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(68, 30);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(320, 49);
            this.tableLayoutPanel1.TabIndex = 41;
            // 
            // numUpD_DirtyScore
            // 
            this.numUpD_DirtyScore.DecimalPlaces = 2;
            this.numUpD_DirtyScore.Dock = System.Windows.Forms.DockStyle.Left;
            this.numUpD_DirtyScore.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numUpD_DirtyScore.Location = new System.Drawing.Point(77, 25);
            this.numUpD_DirtyScore.Margin = new System.Windows.Forms.Padding(1);
            this.numUpD_DirtyScore.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUpD_DirtyScore.Name = "numUpD_DirtyScore";
            this.numUpD_DirtyScore.Size = new System.Drawing.Size(72, 23);
            this.numUpD_DirtyScore.TabIndex = 42;
            this.numUpD_DirtyScore.Value = new decimal(new int[] {
            25,
            0,
            0,
            131072});
            // 
            // label_Name
            // 
            this.label_Name.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Name.Font = new System.Drawing.Font("宋体", 10F);
            this.label_Name.Location = new System.Drawing.Point(3, 0);
            this.label_Name.Name = "label_Name";
            this.label_Name.Size = new System.Drawing.Size(70, 24);
            this.label_Name.TabIndex = 2;
            this.label_Name.Text = "鼓包褶皱";
            this.label_Name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numUpD_BrokenScore
            // 
            this.numUpD_BrokenScore.DecimalPlaces = 2;
            this.numUpD_BrokenScore.Dock = System.Windows.Forms.DockStyle.Left;
            this.numUpD_BrokenScore.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numUpD_BrokenScore.Location = new System.Drawing.Point(77, 1);
            this.numUpD_BrokenScore.Margin = new System.Windows.Forms.Padding(1);
            this.numUpD_BrokenScore.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUpD_BrokenScore.Name = "numUpD_BrokenScore";
            this.numUpD_BrokenScore.Size = new System.Drawing.Size(72, 23);
            this.numUpD_BrokenScore.TabIndex = 41;
            this.numUpD_BrokenScore.Value = new decimal(new int[] {
            25,
            0,
            0,
            131072});
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("宋体", 10F);
            this.label1.Location = new System.Drawing.Point(3, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "脏污";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CtrlDefect
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.Controls.Add(this.tableLayoutPanel10);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel4);
            this.Name = "CtrlDefect";
            this.Size = new System.Drawing.Size(389, 511);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel10.ResumeLayout(false);
            this.tLPanel_Broken.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numUpD_DirtyScore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpD_BrokenScore)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button but_Test;
        private System.Windows.Forms.Button but_SaveParam;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel10;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TableLayoutPanel tLPanel_Broken;
        private System.Windows.Forms.Button but_SetBrokenROI;
        private System.Windows.Forms.Button btn_ShowBrokenROI;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.NumericUpDown numUpD_DirtyScore;
        private System.Windows.Forms.Label label_Name;
        private System.Windows.Forms.NumericUpDown numUpD_BrokenScore;
        private System.Windows.Forms.Label label1;
    }
}

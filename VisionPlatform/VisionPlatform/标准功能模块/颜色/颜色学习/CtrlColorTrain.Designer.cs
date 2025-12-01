namespace VisionPlatform
{
    partial class CtrlColorTrain
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
            this.comboBox_ColorRegion = new System.Windows.Forms.ComboBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.清空 = new System.Windows.Forms.ToolStripMenuItem();
            this.but_Del = new System.Windows.Forms.Button();
            this.but_Add = new System.Windows.Forms.Button();
            this.but_Show = new System.Windows.Forms.Button();
            this.tLPanelaa = new System.Windows.Forms.TableLayoutPanel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tLPanel = new System.Windows.Forms.TableLayoutPanel();
            this.numUpD_RejThd = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.but_Test = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            this.tLPanelaa.SuspendLayout();
            this.tLPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpD_RejThd)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox_ColorRegion
            // 
            this.comboBox_ColorRegion.ContextMenuStrip = this.contextMenuStrip1;
            this.comboBox_ColorRegion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox_ColorRegion.FormattingEnabled = true;
            this.comboBox_ColorRegion.Location = new System.Drawing.Point(76, 3);
            this.comboBox_ColorRegion.Name = "comboBox_ColorRegion";
            this.comboBox_ColorRegion.Size = new System.Drawing.Size(67, 20);
            this.comboBox_ColorRegion.TabIndex = 4;
            this.comboBox_ColorRegion.SelectedIndexChanged += new System.EventHandler(this.comboBox_ColorRegion_SelectedIndexChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.清空});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(101, 26);
            // 
            // 清空
            // 
            this.清空.Name = "清空";
            this.清空.Size = new System.Drawing.Size(100, 22);
            this.清空.Text = "清空";
            this.清空.Click += new System.EventHandler(this.清空_Click);
            // 
            // but_Del
            // 
            this.but_Del.Dock = System.Windows.Forms.DockStyle.Fill;
            this.but_Del.Location = new System.Drawing.Point(147, 1);
            this.but_Del.Margin = new System.Windows.Forms.Padding(1);
            this.but_Del.Name = "but_Del";
            this.but_Del.Size = new System.Drawing.Size(71, 23);
            this.but_Del.TabIndex = 2;
            this.but_Del.Text = "删除当前";
            this.but_Del.UseVisualStyleBackColor = true;
            this.but_Del.Click += new System.EventHandler(this.but_Del_Click);
            // 
            // but_Add
            // 
            this.but_Add.Dock = System.Windows.Forms.DockStyle.Fill;
            this.but_Add.Location = new System.Drawing.Point(1, 1);
            this.but_Add.Margin = new System.Windows.Forms.Padding(1);
            this.but_Add.Name = "but_Add";
            this.but_Add.Size = new System.Drawing.Size(71, 23);
            this.but_Add.TabIndex = 0;
            this.but_Add.Text = "添加";
            this.but_Add.UseVisualStyleBackColor = true;
            this.but_Add.Click += new System.EventHandler(this.but_Add_Click);
            // 
            // but_Show
            // 
            this.but_Show.Dock = System.Windows.Forms.DockStyle.Fill;
            this.but_Show.Location = new System.Drawing.Point(220, 1);
            this.but_Show.Margin = new System.Windows.Forms.Padding(1);
            this.but_Show.Name = "but_Show";
            this.but_Show.Size = new System.Drawing.Size(71, 23);
            this.but_Show.TabIndex = 1;
            this.but_Show.Text = "显示所有";
            this.but_Show.UseVisualStyleBackColor = true;
            this.but_Show.Click += new System.EventHandler(this.but_Show_Click);
            // 
            // tLPanelaa
            // 
            this.tLPanelaa.ColumnCount = 4;
            this.tLPanelaa.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tLPanelaa.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tLPanelaa.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tLPanelaa.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tLPanelaa.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tLPanelaa.Controls.Add(this.but_Add, 0, 0);
            this.tLPanelaa.Controls.Add(this.comboBox_ColorRegion, 1, 0);
            this.tLPanelaa.Controls.Add(this.but_Del, 2, 0);
            this.tLPanelaa.Controls.Add(this.but_Show, 3, 0);
            this.tLPanelaa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tLPanelaa.Location = new System.Drawing.Point(65, 1);
            this.tLPanelaa.Margin = new System.Windows.Forms.Padding(0);
            this.tLPanelaa.Name = "tLPanelaa";
            this.tLPanelaa.RowCount = 1;
            this.tLPanelaa.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tLPanelaa.Size = new System.Drawing.Size(292, 25);
            this.tLPanelaa.TabIndex = 4;
            // 
            // tLPanel
            // 
            this.tLPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tLPanel.ColumnCount = 2;
            this.tLPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 63F));
            this.tLPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tLPanel.Controls.Add(this.numUpD_RejThd, 1, 1);
            this.tLPanel.Controls.Add(this.label1, 0, 1);
            this.tLPanel.Controls.Add(this.tLPanelaa, 1, 0);
            this.tLPanel.Controls.Add(this.label5, 0, 0);
            this.tLPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tLPanel.Location = new System.Drawing.Point(0, 0);
            this.tLPanel.Margin = new System.Windows.Forms.Padding(0);
            this.tLPanel.Name = "tLPanel";
            this.tLPanel.RowCount = 2;
            this.tLPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tLPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tLPanel.Size = new System.Drawing.Size(358, 51);
            this.tLPanel.TabIndex = 6;
            // 
            // numUpD_RejThd
            // 
            this.numUpD_RejThd.DecimalPlaces = 2;
            this.numUpD_RejThd.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numUpD_RejThd.Location = new System.Drawing.Point(66, 28);
            this.numUpD_RejThd.Margin = new System.Windows.Forms.Padding(1);
            this.numUpD_RejThd.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUpD_RejThd.Name = "numUpD_RejThd";
            this.numUpD_RejThd.Size = new System.Drawing.Size(75, 21);
            this.numUpD_RejThd.TabIndex = 0;
            this.numUpD_RejThd.Value = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(4, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 23);
            this.label1.TabIndex = 8;
            this.label1.Text = "差异度 ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(1, 1);
            this.label5.Margin = new System.Windows.Forms.Padding(0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 25);
            this.label5.TabIndex = 24;
            this.label5.Text = "颜色区域";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // but_Test
            // 
            this.but_Test.BackColor = System.Drawing.Color.LightSteelBlue;
            this.but_Test.Dock = System.Windows.Forms.DockStyle.Right;
            this.but_Test.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.but_Test.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.but_Test.Location = new System.Drawing.Point(358, 0);
            this.but_Test.Margin = new System.Windows.Forms.Padding(1);
            this.but_Test.Name = "but_Test";
            this.but_Test.Size = new System.Drawing.Size(52, 51);
            this.but_Test.TabIndex = 5;
            this.but_Test.Text = "学习";
            this.but_Test.UseVisualStyleBackColor = false;
            this.but_Test.Click += new System.EventHandler(this.but_Test_Click);
            // 
            // CtrlColorTrain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tLPanel);
            this.Controls.Add(this.but_Test);
            this.Name = "CtrlColorTrain";
            this.Size = new System.Drawing.Size(410, 51);
            this.contextMenuStrip1.ResumeLayout(false);
            this.tLPanelaa.ResumeLayout(false);
            this.tLPanel.ResumeLayout(false);
            this.tLPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpD_RejThd)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox comboBox_ColorRegion;
        private System.Windows.Forms.Button but_Add;
        private System.Windows.Forms.Button but_Del;
        private System.Windows.Forms.Button but_Show;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 清空;
        private System.Windows.Forms.TableLayoutPanel tLPanelaa;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TableLayoutPanel tLPanel;
        private System.Windows.Forms.Button but_Test;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numUpD_RejThd;
        private System.Windows.Forms.Label label5;
    }
}

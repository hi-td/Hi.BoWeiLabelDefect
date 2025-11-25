namespace VisionPlatform
{
    partial class CtrlRatioRange
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
            this.tLPanel = new System.Windows.Forms.TableLayoutPanel();
            this.numUpD_Min = new System.Windows.Forms.NumericUpDown();
            this.numUpD_Max = new System.Windows.Forms.NumericUpDown();
            this.label_Max = new System.Windows.Forms.Label();
            this.label_Min = new System.Windows.Forms.Label();
            this.numUpD_Val = new System.Windows.Forms.NumericUpDown();
            this.tLPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpD_Min)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpD_Max)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpD_Val)).BeginInit();
            this.SuspendLayout();
            // 
            // tLPanel
            // 
            this.tLPanel.ColumnCount = 5;
            this.tLPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tLPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tLPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tLPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tLPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tLPanel.Controls.Add(this.numUpD_Min, 1, 0);
            this.tLPanel.Controls.Add(this.numUpD_Max, 3, 0);
            this.tLPanel.Controls.Add(this.label_Max, 4, 0);
            this.tLPanel.Controls.Add(this.label_Min, 0, 0);
            this.tLPanel.Controls.Add(this.numUpD_Val, 2, 0);
            this.tLPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tLPanel.Location = new System.Drawing.Point(0, 0);
            this.tLPanel.Margin = new System.Windows.Forms.Padding(0);
            this.tLPanel.Name = "tLPanel";
            this.tLPanel.RowCount = 1;
            this.tLPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tLPanel.Size = new System.Drawing.Size(357, 23);
            this.tLPanel.TabIndex = 1;
            // 
            // numUpD_Min
            // 
            this.numUpD_Min.DecimalPlaces = 2;
            this.numUpD_Min.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numUpD_Min.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numUpD_Min.Location = new System.Drawing.Point(71, 0);
            this.numUpD_Min.Margin = new System.Windows.Forms.Padding(0);
            this.numUpD_Min.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUpD_Min.Name = "numUpD_Min";
            this.numUpD_Min.Size = new System.Drawing.Size(71, 21);
            this.numUpD_Min.TabIndex = 1;
            this.numUpD_Min.Value = new decimal(new int[] {
            75,
            0,
            0,
            131072});
            this.numUpD_Min.ValueChanged += new System.EventHandler(this.Inspect);
            // 
            // numUpD_Max
            // 
            this.numUpD_Max.DecimalPlaces = 2;
            this.numUpD_Max.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numUpD_Max.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numUpD_Max.Location = new System.Drawing.Point(213, 0);
            this.numUpD_Max.Margin = new System.Windows.Forms.Padding(0);
            this.numUpD_Max.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            65536});
            this.numUpD_Max.Name = "numUpD_Max";
            this.numUpD_Max.Size = new System.Drawing.Size(71, 21);
            this.numUpD_Max.TabIndex = 1;
            this.numUpD_Max.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUpD_Max.ValueChanged += new System.EventHandler(this.Inspect);
            // 
            // label_Max
            // 
            this.label_Max.AutoSize = true;
            this.label_Max.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Max.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_Max.Location = new System.Drawing.Point(284, 0);
            this.label_Max.Margin = new System.Windows.Forms.Padding(0);
            this.label_Max.Name = "label_Max";
            this.label_Max.Size = new System.Drawing.Size(73, 23);
            this.label_Max.TabIndex = 8;
            this.label_Max.Text = "-";
            this.label_Max.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Min
            // 
            this.label_Min.AutoSize = true;
            this.label_Min.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Min.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_Min.Location = new System.Drawing.Point(0, 0);
            this.label_Min.Margin = new System.Windows.Forms.Padding(0);
            this.label_Min.Name = "label_Min";
            this.label_Min.Size = new System.Drawing.Size(71, 23);
            this.label_Min.TabIndex = 7;
            this.label_Min.Text = "-";
            this.label_Min.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numUpD_Val
            // 
            this.numUpD_Val.DecimalPlaces = 2;
            this.numUpD_Val.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numUpD_Val.Location = new System.Drawing.Point(142, 0);
            this.numUpD_Val.Margin = new System.Windows.Forms.Padding(0);
            this.numUpD_Val.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.numUpD_Val.Name = "numUpD_Val";
            this.numUpD_Val.Size = new System.Drawing.Size(71, 21);
            this.numUpD_Val.TabIndex = 9;
            this.numUpD_Val.ValueChanged += new System.EventHandler(this.Inspect);
            // 
            // CtrlRatioRange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tLPanel);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "CtrlRatioRange";
            this.Size = new System.Drawing.Size(357, 23);
            this.tLPanel.ResumeLayout(false);
            this.tLPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpD_Min)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpD_Max)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpD_Val)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tLPanel;
        private System.Windows.Forms.NumericUpDown numUpD_Min;
        private System.Windows.Forms.NumericUpDown numUpD_Max;
        private System.Windows.Forms.Label label_Min;
        private System.Windows.Forms.Label label_Max;
        private System.Windows.Forms.NumericUpDown numUpD_Val;
    }
}

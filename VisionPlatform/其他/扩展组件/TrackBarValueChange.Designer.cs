namespace VisionPlatform
{
    partial class TrackBarValueChange
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
            this.trackBar_value = new System.Windows.Forms.TrackBar();
            this.numUpD_value = new System.Windows.Forms.NumericUpDown();
            this.tLPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_value)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpD_value)).BeginInit();
            this.SuspendLayout();
            // 
            // tLPanel
            // 
            this.tLPanel.ColumnCount = 2;
            this.tLPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tLPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tLPanel.Controls.Add(this.trackBar_value, 1, 0);
            this.tLPanel.Controls.Add(this.numUpD_value, 0, 0);
            this.tLPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tLPanel.Location = new System.Drawing.Point(0, 0);
            this.tLPanel.Margin = new System.Windows.Forms.Padding(0);
            this.tLPanel.Name = "tLPanel";
            this.tLPanel.RowCount = 1;
            this.tLPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tLPanel.Size = new System.Drawing.Size(312, 26);
            this.tLPanel.TabIndex = 30;
            // 
            // trackBar_value
            // 
            this.trackBar_value.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trackBar_value.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.trackBar_value.Location = new System.Drawing.Point(63, 3);
            this.trackBar_value.Maximum = 2255;
            this.trackBar_value.Minimum = -2255;
            this.trackBar_value.Name = "trackBar_value";
            this.trackBar_value.Size = new System.Drawing.Size(246, 20);
            this.trackBar_value.TabIndex = 22;
            this.trackBar_value.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar_value.Value = 5;
            this.trackBar_value.Scroll += new System.EventHandler(this.trackBar_value_Scroll);
            // 
            // numUpD_value
            // 
            this.numUpD_value.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numUpD_value.Font = new System.Drawing.Font("宋体", 10F);
            this.numUpD_value.Location = new System.Drawing.Point(1, 1);
            this.numUpD_value.Margin = new System.Windows.Forms.Padding(1);
            this.numUpD_value.Maximum = new decimal(new int[] {
            2255,
            0,
            0,
            0});
            this.numUpD_value.Minimum = new decimal(new int[] {
            2255,
            0,
            0,
            -2147483648});
            this.numUpD_value.Name = "numUpD_value";
            this.numUpD_value.Size = new System.Drawing.Size(58, 23);
            this.numUpD_value.TabIndex = 19;
            this.numUpD_value.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numUpD_value.ValueChanged += new System.EventHandler(this.Inspect);
            // 
            // TrackBarValueChange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tLPanel);
            this.Name = "TrackBarValueChange";
            this.Size = new System.Drawing.Size(312, 26);
            this.tLPanel.ResumeLayout(false);
            this.tLPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_value)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpD_value)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tLPanel;
        private System.Windows.Forms.TrackBar trackBar_value;
        private System.Windows.Forms.NumericUpDown numUpD_value;
    }
}

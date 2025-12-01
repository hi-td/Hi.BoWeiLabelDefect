namespace VisionPlatform
{
    partial class CtrlLEDSet
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
            this.label_CH = new System.Windows.Forms.Label();
            this.trackBar_Brightness = new System.Windows.Forms.TrackBar();
            this.numUpD_Brightness = new System.Windows.Forms.NumericUpDown();
            this.checkBox_bSel = new System.Windows.Forms.CheckBox();
            this.tLPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Brightness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpD_Brightness)).BeginInit();
            this.SuspendLayout();
            // 
            // tLPanel
            // 
            this.tLPanel.ColumnCount = 4;
            this.tLPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tLPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tLPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tLPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tLPanel.Controls.Add(this.label_CH, 1, 0);
            this.tLPanel.Controls.Add(this.trackBar_Brightness, 3, 0);
            this.tLPanel.Controls.Add(this.numUpD_Brightness, 2, 0);
            this.tLPanel.Controls.Add(this.checkBox_bSel, 0, 0);
            this.tLPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tLPanel.Location = new System.Drawing.Point(0, 0);
            this.tLPanel.Margin = new System.Windows.Forms.Padding(0);
            this.tLPanel.Name = "tLPanel";
            this.tLPanel.RowCount = 1;
            this.tLPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tLPanel.Size = new System.Drawing.Size(279, 23);
            this.tLPanel.TabIndex = 15;
            // 
            // label_CH
            // 
            this.label_CH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_CH.Location = new System.Drawing.Point(20, 0);
            this.label_CH.Margin = new System.Windows.Forms.Padding(0);
            this.label_CH.Name = "label_CH";
            this.label_CH.Size = new System.Drawing.Size(25, 23);
            this.label_CH.TabIndex = 5;
            this.label_CH.Text = "CH1";
            this.label_CH.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // trackBar_Brightness
            // 
            this.trackBar_Brightness.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trackBar_Brightness.LargeChange = 1;
            this.trackBar_Brightness.Location = new System.Drawing.Point(108, 3);
            this.trackBar_Brightness.Maximum = 255;
            this.trackBar_Brightness.Name = "trackBar_Brightness";
            this.trackBar_Brightness.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.trackBar_Brightness.Size = new System.Drawing.Size(168, 17);
            this.trackBar_Brightness.TabIndex = 0;
            this.trackBar_Brightness.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar_Brightness.Scroll += new System.EventHandler(this.trackBar_Brightness_Scroll);
            // 
            // numUpD_Brightness
            // 
            this.numUpD_Brightness.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numUpD_Brightness.Location = new System.Drawing.Point(46, 1);
            this.numUpD_Brightness.Margin = new System.Windows.Forms.Padding(1);
            this.numUpD_Brightness.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numUpD_Brightness.Name = "numUpD_Brightness";
            this.numUpD_Brightness.Size = new System.Drawing.Size(58, 21);
            this.numUpD_Brightness.TabIndex = 6;
            this.numUpD_Brightness.ValueChanged += new System.EventHandler(this.Inspect);
            // 
            // checkBox_bSel
            // 
            this.checkBox_bSel.AutoSize = true;
            this.checkBox_bSel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBox_bSel.Location = new System.Drawing.Point(3, 3);
            this.checkBox_bSel.Name = "checkBox_bSel";
            this.checkBox_bSel.Size = new System.Drawing.Size(14, 17);
            this.checkBox_bSel.TabIndex = 7;
            this.checkBox_bSel.UseVisualStyleBackColor = true;
            this.checkBox_bSel.CheckedChanged += new System.EventHandler(this.Inspect);
            // 
            // CtrlLEDSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tLPanel);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "CtrlLEDSet";
            this.Size = new System.Drawing.Size(279, 23);
            this.tLPanel.ResumeLayout(false);
            this.tLPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Brightness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpD_Brightness)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tLPanel;
        private System.Windows.Forms.Label label_CH;
        private System.Windows.Forms.TrackBar trackBar_Brightness;
        private System.Windows.Forms.NumericUpDown numUpD_Brightness;
        private System.Windows.Forms.CheckBox checkBox_bSel;
    }
}

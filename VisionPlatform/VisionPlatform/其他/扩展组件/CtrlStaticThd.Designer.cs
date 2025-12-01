namespace VisionPlatform
{
    partial class CtrlStaticThd
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
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.checkBox_Thd255 = new System.Windows.Forms.CheckBox();
            this.checkBox_Thd0 = new System.Windows.Forms.CheckBox();
            this.trackBar_Thd = new System.Windows.Forms.TrackBar();
            this.numUpD_Thd = new System.Windows.Forms.NumericUpDown();
            this.tLPanel.SuspendLayout();
            this.tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Thd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpD_Thd)).BeginInit();
            this.SuspendLayout();
            // 
            // tLPanel
            // 
            this.tLPanel.ColumnCount = 2;
            this.tLPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tLPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tLPanel.Controls.Add(this.tableLayoutPanel, 1, 0);
            this.tLPanel.Controls.Add(this.numUpD_Thd, 0, 0);
            this.tLPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tLPanel.Location = new System.Drawing.Point(0, 0);
            this.tLPanel.Margin = new System.Windows.Forms.Padding(0);
            this.tLPanel.Name = "tLPanel";
            this.tLPanel.RowCount = 1;
            this.tLPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tLPanel.Size = new System.Drawing.Size(367, 25);
            this.tLPanel.TabIndex = 24;
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 3;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel.Controls.Add(this.checkBox_Thd255, 2, 0);
            this.tableLayoutPanel.Controls.Add(this.checkBox_Thd0, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.trackBar_Thd, 1, 0);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(60, 0);
            this.tableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 1;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(307, 25);
            this.tableLayoutPanel.TabIndex = 38;
            // 
            // checkBox_Thd255
            // 
            this.checkBox_Thd255.AutoSize = true;
            this.checkBox_Thd255.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBox_Thd255.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkBox_Thd255.Location = new System.Drawing.Point(257, 0);
            this.checkBox_Thd255.Margin = new System.Windows.Forms.Padding(0);
            this.checkBox_Thd255.Name = "checkBox_Thd255";
            this.checkBox_Thd255.Size = new System.Drawing.Size(50, 25);
            this.checkBox_Thd255.TabIndex = 1;
            this.checkBox_Thd255.Text = "255";
            this.checkBox_Thd255.UseVisualStyleBackColor = true;
            this.checkBox_Thd255.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // checkBox_Thd0
            // 
            this.checkBox_Thd0.AutoSize = true;
            this.checkBox_Thd0.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBox_Thd0.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkBox_Thd0.Location = new System.Drawing.Point(0, 0);
            this.checkBox_Thd0.Margin = new System.Windows.Forms.Padding(0);
            this.checkBox_Thd0.Name = "checkBox_Thd0";
            this.checkBox_Thd0.Size = new System.Drawing.Size(30, 25);
            this.checkBox_Thd0.TabIndex = 0;
            this.checkBox_Thd0.Text = "0";
            this.checkBox_Thd0.UseVisualStyleBackColor = true;
            this.checkBox_Thd0.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // trackBar_Thd
            // 
            this.trackBar_Thd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trackBar_Thd.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.trackBar_Thd.Location = new System.Drawing.Point(33, 3);
            this.trackBar_Thd.Maximum = 255;
            this.trackBar_Thd.Name = "trackBar_Thd";
            this.trackBar_Thd.Size = new System.Drawing.Size(221, 19);
            this.trackBar_Thd.TabIndex = 18;
            this.trackBar_Thd.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar_Thd.Value = 100;
            this.trackBar_Thd.Scroll += new System.EventHandler(this.trackBar_Thd_Scroll);
            // 
            // numUpD_Thd
            // 
            this.numUpD_Thd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numUpD_Thd.Font = new System.Drawing.Font("宋体", 10F);
            this.numUpD_Thd.Location = new System.Drawing.Point(1, 1);
            this.numUpD_Thd.Margin = new System.Windows.Forms.Padding(1);
            this.numUpD_Thd.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numUpD_Thd.Name = "numUpD_Thd";
            this.numUpD_Thd.Size = new System.Drawing.Size(58, 23);
            this.numUpD_Thd.TabIndex = 19;
            this.numUpD_Thd.ValueChanged += new System.EventHandler(this.numUpD_Thd_ValueChanged);
            // 
            // CtrlThdO_255
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tLPanel);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "CtrlThdO_255";
            this.Size = new System.Drawing.Size(367, 25);
            this.tLPanel.ResumeLayout(false);
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Thd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpD_Thd)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tLPanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.CheckBox checkBox_Thd255;
        private System.Windows.Forms.CheckBox checkBox_Thd0;
        private System.Windows.Forms.TrackBar trackBar_Thd;
        private System.Windows.Forms.NumericUpDown numUpD_Thd;
    }
}

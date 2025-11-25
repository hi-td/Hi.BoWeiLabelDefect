namespace VisionPlatform
{
    partial class RectROIMove
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
            this.numUpD_YMove = new System.Windows.Forms.NumericUpDown();
            this.label51 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.numUpD_Width = new System.Windows.Forms.NumericUpDown();
            this.numUpD_Height = new System.Windows.Forms.NumericUpDown();
            this.numUpD_XMove = new System.Windows.Forms.NumericUpDown();
            this.trackBar_Width = new System.Windows.Forms.TrackBar();
            this.trackBar_Height = new System.Windows.Forms.TrackBar();
            this.trackBar_XMove = new System.Windows.Forms.TrackBar();
            this.trackBar_YMove = new System.Windows.Forms.TrackBar();
            this.tLPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpD_YMove)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpD_Width)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpD_Height)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpD_XMove)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Width)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Height)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_XMove)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_YMove)).BeginInit();
            this.SuspendLayout();
            // 
            // tLPanel
            // 
            this.tLPanel.BackColor = System.Drawing.SystemColors.Control;
            this.tLPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tLPanel.ColumnCount = 3;
            this.tLPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tLPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tLPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tLPanel.Controls.Add(this.numUpD_YMove, 0, 3);
            this.tLPanel.Controls.Add(this.label51, 0, 3);
            this.tLPanel.Controls.Add(this.label8, 0, 0);
            this.tLPanel.Controls.Add(this.label10, 0, 1);
            this.tLPanel.Controls.Add(this.label7, 0, 2);
            this.tLPanel.Controls.Add(this.numUpD_Width, 1, 0);
            this.tLPanel.Controls.Add(this.numUpD_Height, 1, 1);
            this.tLPanel.Controls.Add(this.numUpD_XMove, 1, 2);
            this.tLPanel.Controls.Add(this.trackBar_Width, 2, 0);
            this.tLPanel.Controls.Add(this.trackBar_Height, 2, 1);
            this.tLPanel.Controls.Add(this.trackBar_XMove, 2, 2);
            this.tLPanel.Controls.Add(this.trackBar_YMove, 2, 3);
            this.tLPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tLPanel.Font = new System.Drawing.Font("宋体", 10F);
            this.tLPanel.Location = new System.Drawing.Point(0, 0);
            this.tLPanel.Margin = new System.Windows.Forms.Padding(0);
            this.tLPanel.Name = "tLPanel";
            this.tLPanel.RowCount = 4;
            this.tLPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tLPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tLPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tLPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tLPanel.Size = new System.Drawing.Size(426, 100);
            this.tLPanel.TabIndex = 15;
            // 
            // numUpD_YMove
            // 
            this.numUpD_YMove.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numUpD_YMove.Location = new System.Drawing.Point(68, 74);
            this.numUpD_YMove.Margin = new System.Windows.Forms.Padding(1);
            this.numUpD_YMove.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.numUpD_YMove.Minimum = new decimal(new int[] {
            600,
            0,
            0,
            -2147483648});
            this.numUpD_YMove.Name = "numUpD_YMove";
            this.numUpD_YMove.Size = new System.Drawing.Size(63, 23);
            this.numUpD_YMove.TabIndex = 35;
            this.numUpD_YMove.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numUpD_YMove.ValueChanged += new System.EventHandler(this.Inspect);
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label51.Font = new System.Drawing.Font("宋体", 10F);
            this.label51.Location = new System.Drawing.Point(1, 73);
            this.label51.Margin = new System.Windows.Forms.Padding(0);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(65, 26);
            this.label51.TabIndex = 33;
            this.label51.Text = "垂直移动";
            this.label51.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(1, 1);
            this.label8.Margin = new System.Windows.Forms.Padding(0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 23);
            this.label8.TabIndex = 31;
            this.label8.Text = "宽度";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(1, 25);
            this.label10.Margin = new System.Windows.Forms.Padding(0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 23);
            this.label10.TabIndex = 32;
            this.label10.Text = "高度";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(1, 49);
            this.label7.Margin = new System.Windows.Forms.Padding(0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 23);
            this.label7.TabIndex = 30;
            this.label7.Text = "水平移动";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numUpD_Width
            // 
            this.numUpD_Width.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numUpD_Width.Location = new System.Drawing.Point(68, 2);
            this.numUpD_Width.Margin = new System.Windows.Forms.Padding(1);
            this.numUpD_Width.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numUpD_Width.Name = "numUpD_Width";
            this.numUpD_Width.Size = new System.Drawing.Size(63, 23);
            this.numUpD_Width.TabIndex = 16;
            this.numUpD_Width.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numUpD_Width.ValueChanged += new System.EventHandler(this.Inspect);
            // 
            // numUpD_Height
            // 
            this.numUpD_Height.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numUpD_Height.Location = new System.Drawing.Point(68, 26);
            this.numUpD_Height.Margin = new System.Windows.Forms.Padding(1);
            this.numUpD_Height.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numUpD_Height.Name = "numUpD_Height";
            this.numUpD_Height.Size = new System.Drawing.Size(63, 23);
            this.numUpD_Height.TabIndex = 18;
            this.numUpD_Height.ValueChanged += new System.EventHandler(this.Inspect);
            // 
            // numUpD_XMove
            // 
            this.numUpD_XMove.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numUpD_XMove.Location = new System.Drawing.Point(68, 50);
            this.numUpD_XMove.Margin = new System.Windows.Forms.Padding(1);
            this.numUpD_XMove.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numUpD_XMove.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.numUpD_XMove.Name = "numUpD_XMove";
            this.numUpD_XMove.Size = new System.Drawing.Size(63, 23);
            this.numUpD_XMove.TabIndex = 15;
            this.numUpD_XMove.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numUpD_XMove.ValueChanged += new System.EventHandler(this.Inspect);
            // 
            // trackBar_Width
            // 
            this.trackBar_Width.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trackBar_Width.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.trackBar_Width.Location = new System.Drawing.Point(136, 4);
            this.trackBar_Width.Maximum = 1000;
            this.trackBar_Width.Name = "trackBar_Width";
            this.trackBar_Width.Size = new System.Drawing.Size(286, 17);
            this.trackBar_Width.TabIndex = 11;
            this.trackBar_Width.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar_Width.Scroll += new System.EventHandler(this.trackBar_Width_Scroll);
            // 
            // trackBar_Height
            // 
            this.trackBar_Height.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trackBar_Height.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.trackBar_Height.Location = new System.Drawing.Point(136, 28);
            this.trackBar_Height.Maximum = 500;
            this.trackBar_Height.Name = "trackBar_Height";
            this.trackBar_Height.Size = new System.Drawing.Size(286, 17);
            this.trackBar_Height.TabIndex = 19;
            this.trackBar_Height.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar_Height.Scroll += new System.EventHandler(this.trackBar_Height_Scroll);
            // 
            // trackBar_XMove
            // 
            this.trackBar_XMove.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trackBar_XMove.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.trackBar_XMove.Location = new System.Drawing.Point(136, 52);
            this.trackBar_XMove.Maximum = 1000;
            this.trackBar_XMove.Minimum = -1000;
            this.trackBar_XMove.Name = "trackBar_XMove";
            this.trackBar_XMove.Size = new System.Drawing.Size(286, 17);
            this.trackBar_XMove.TabIndex = 29;
            this.trackBar_XMove.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar_XMove.Scroll += new System.EventHandler(this.trackBar_XMove_Scroll);
            // 
            // trackBar_YMove
            // 
            this.trackBar_YMove.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trackBar_YMove.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.trackBar_YMove.Location = new System.Drawing.Point(136, 76);
            this.trackBar_YMove.Maximum = 600;
            this.trackBar_YMove.Minimum = -600;
            this.trackBar_YMove.Name = "trackBar_YMove";
            this.trackBar_YMove.Size = new System.Drawing.Size(286, 20);
            this.trackBar_YMove.TabIndex = 34;
            this.trackBar_YMove.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar_YMove.Scroll += new System.EventHandler(this.trackBar_YMove_Scroll);
            // 
            // RectROIMove
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tLPanel);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "RectROIMove";
            this.Size = new System.Drawing.Size(426, 100);
            this.tLPanel.ResumeLayout(false);
            this.tLPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpD_YMove)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpD_Width)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpD_Height)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpD_XMove)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Width)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Height)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_XMove)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_YMove)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tLPanel;
        private System.Windows.Forms.TrackBar trackBar_Height;
        private System.Windows.Forms.TrackBar trackBar_Width;
        private System.Windows.Forms.TrackBar trackBar_XMove;
        private System.Windows.Forms.NumericUpDown numUpD_Height;
        private System.Windows.Forms.NumericUpDown numUpD_Width;
        private System.Windows.Forms.NumericUpDown numUpD_XMove;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.NumericUpDown numUpD_YMove;
        private System.Windows.Forms.TrackBar trackBar_YMove;
    }
}

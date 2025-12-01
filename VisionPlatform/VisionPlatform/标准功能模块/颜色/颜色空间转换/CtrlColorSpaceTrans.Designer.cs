namespace VisionPlatform
{
    partial class CtrlColorSpaceTrans
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tLPanel_colorSpace = new System.Windows.Forms.TableLayoutPanel();
            this.checkBox_imageR = new System.Windows.Forms.CheckBox();
            this.checkBox_imageG = new System.Windows.Forms.CheckBox();
            this.checkBox_imageB = new System.Windows.Forms.CheckBox();
            this.checkBox_image1 = new System.Windows.Forms.CheckBox();
            this.checkBox_image2 = new System.Windows.Forms.CheckBox();
            this.checkBox_image3 = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbBox_ColorSpace = new System.Windows.Forms.ComboBox();
            this.checkBox_gray = new System.Windows.Forms.CheckBox();
            this.checkBox_Cont = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.tLPanel_colorSpace.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tLPanel_colorSpace, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(343, 50);
            this.tableLayoutPanel1.TabIndex = 16;
            // 
            // tLPanel_colorSpace
            // 
            this.tLPanel_colorSpace.BackColor = System.Drawing.SystemColors.Control;
            this.tLPanel_colorSpace.ColumnCount = 6;
            this.tLPanel_colorSpace.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66668F));
            this.tLPanel_colorSpace.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tLPanel_colorSpace.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tLPanel_colorSpace.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tLPanel_colorSpace.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tLPanel_colorSpace.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tLPanel_colorSpace.Controls.Add(this.checkBox_imageR, 0, 0);
            this.tLPanel_colorSpace.Controls.Add(this.checkBox_imageG, 1, 0);
            this.tLPanel_colorSpace.Controls.Add(this.checkBox_imageB, 2, 0);
            this.tLPanel_colorSpace.Controls.Add(this.checkBox_image1, 3, 0);
            this.tLPanel_colorSpace.Controls.Add(this.checkBox_image2, 4, 0);
            this.tLPanel_colorSpace.Controls.Add(this.checkBox_image3, 5, 0);
            this.tLPanel_colorSpace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tLPanel_colorSpace.Font = new System.Drawing.Font("宋体", 10F);
            this.tLPanel_colorSpace.Location = new System.Drawing.Point(1, 25);
            this.tLPanel_colorSpace.Margin = new System.Windows.Forms.Padding(0);
            this.tLPanel_colorSpace.Name = "tLPanel_colorSpace";
            this.tLPanel_colorSpace.RowCount = 1;
            this.tLPanel_colorSpace.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tLPanel_colorSpace.Size = new System.Drawing.Size(341, 24);
            this.tLPanel_colorSpace.TabIndex = 14;
            // 
            // checkBox_imageR
            // 
            this.checkBox_imageR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBox_imageR.Location = new System.Drawing.Point(3, 1);
            this.checkBox_imageR.Margin = new System.Windows.Forms.Padding(3, 1, 1, 1);
            this.checkBox_imageR.Name = "checkBox_imageR";
            this.checkBox_imageR.Size = new System.Drawing.Size(52, 22);
            this.checkBox_imageR.TabIndex = 0;
            this.checkBox_imageR.Text = "R";
            this.checkBox_imageR.UseVisualStyleBackColor = true;
            this.checkBox_imageR.CheckedChanged += new System.EventHandler(this.checkBox_Images_CheckedChanged);
            // 
            // checkBox_imageG
            // 
            this.checkBox_imageG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBox_imageG.Location = new System.Drawing.Point(59, 1);
            this.checkBox_imageG.Margin = new System.Windows.Forms.Padding(3, 1, 1, 1);
            this.checkBox_imageG.Name = "checkBox_imageG";
            this.checkBox_imageG.Size = new System.Drawing.Size(52, 22);
            this.checkBox_imageG.TabIndex = 1;
            this.checkBox_imageG.Text = "G";
            this.checkBox_imageG.UseVisualStyleBackColor = true;
            this.checkBox_imageG.CheckedChanged += new System.EventHandler(this.checkBox_Images_CheckedChanged);
            // 
            // checkBox_imageB
            // 
            this.checkBox_imageB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBox_imageB.Location = new System.Drawing.Point(115, 1);
            this.checkBox_imageB.Margin = new System.Windows.Forms.Padding(3, 1, 1, 1);
            this.checkBox_imageB.Name = "checkBox_imageB";
            this.checkBox_imageB.Size = new System.Drawing.Size(52, 22);
            this.checkBox_imageB.TabIndex = 2;
            this.checkBox_imageB.Text = "B";
            this.checkBox_imageB.UseVisualStyleBackColor = true;
            this.checkBox_imageB.CheckedChanged += new System.EventHandler(this.checkBox_Images_CheckedChanged);
            // 
            // checkBox_image1
            // 
            this.checkBox_image1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBox_image1.Location = new System.Drawing.Point(171, 1);
            this.checkBox_image1.Margin = new System.Windows.Forms.Padding(3, 1, 1, 1);
            this.checkBox_image1.Name = "checkBox_image1";
            this.checkBox_image1.Size = new System.Drawing.Size(52, 22);
            this.checkBox_image1.TabIndex = 3;
            this.checkBox_image1.Text = "图1";
            this.checkBox_image1.UseVisualStyleBackColor = true;
            this.checkBox_image1.CheckedChanged += new System.EventHandler(this.checkBox_Images_CheckedChanged);
            // 
            // checkBox_image2
            // 
            this.checkBox_image2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBox_image2.Location = new System.Drawing.Point(227, 1);
            this.checkBox_image2.Margin = new System.Windows.Forms.Padding(3, 1, 1, 1);
            this.checkBox_image2.Name = "checkBox_image2";
            this.checkBox_image2.Size = new System.Drawing.Size(52, 22);
            this.checkBox_image2.TabIndex = 4;
            this.checkBox_image2.Text = "图2";
            this.checkBox_image2.UseVisualStyleBackColor = true;
            this.checkBox_image2.CheckedChanged += new System.EventHandler(this.checkBox_Images_CheckedChanged);
            // 
            // checkBox_image3
            // 
            this.checkBox_image3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBox_image3.Location = new System.Drawing.Point(283, 1);
            this.checkBox_image3.Margin = new System.Windows.Forms.Padding(3, 1, 1, 1);
            this.checkBox_image3.Name = "checkBox_image3";
            this.checkBox_image3.Size = new System.Drawing.Size(57, 22);
            this.checkBox_image3.TabIndex = 5;
            this.checkBox_image3.Text = "图3";
            this.checkBox_image3.UseVisualStyleBackColor = true;
            this.checkBox_image3.CheckedChanged += new System.EventHandler(this.checkBox_Images_CheckedChanged);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.cmbBox_ColorSpace, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.checkBox_gray, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.checkBox_Cont, 3, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Font = new System.Drawing.Font("宋体", 10F);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(1, 1);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(341, 23);
            this.tableLayoutPanel2.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 23);
            this.label1.TabIndex = 6;
            this.label1.Text = "颜色空间";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbBox_ColorSpace
            // 
            this.cmbBox_ColorSpace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbBox_ColorSpace.FormattingEnabled = true;
            this.cmbBox_ColorSpace.Items.AddRange(new object[] {
            "hsv",
            "hsi"});
            this.cmbBox_ColorSpace.Location = new System.Drawing.Point(66, 1);
            this.cmbBox_ColorSpace.Margin = new System.Windows.Forms.Padding(1);
            this.cmbBox_ColorSpace.Name = "cmbBox_ColorSpace";
            this.cmbBox_ColorSpace.Size = new System.Drawing.Size(58, 21);
            this.cmbBox_ColorSpace.TabIndex = 7;
            // 
            // checkBox_gray
            // 
            this.checkBox_gray.AutoSize = true;
            this.checkBox_gray.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBox_gray.Location = new System.Drawing.Point(128, 1);
            this.checkBox_gray.Margin = new System.Windows.Forms.Padding(3, 1, 1, 1);
            this.checkBox_gray.Name = "checkBox_gray";
            this.checkBox_gray.Size = new System.Drawing.Size(71, 21);
            this.checkBox_gray.TabIndex = 8;
            this.checkBox_gray.Text = "灰度图";
            this.checkBox_gray.UseVisualStyleBackColor = true;
            this.checkBox_gray.CheckedChanged += new System.EventHandler(this.checkBox_Images_CheckedChanged);
            // 
            // checkBox_Cont
            // 
            this.checkBox_Cont.AutoSize = true;
            this.checkBox_Cont.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBox_Cont.Location = new System.Drawing.Point(203, 1);
            this.checkBox_Cont.Margin = new System.Windows.Forms.Padding(3, 1, 1, 1);
            this.checkBox_Cont.Name = "checkBox_Cont";
            this.checkBox_Cont.Size = new System.Drawing.Size(71, 21);
            this.checkBox_Cont.TabIndex = 9;
            this.checkBox_Cont.Text = "轮廓图";
            this.checkBox_Cont.UseVisualStyleBackColor = true;
            this.checkBox_Cont.CheckedChanged += new System.EventHandler(this.checkBox_Images_CheckedChanged);
            // 
            // CtrlColorSpaceTrans
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "CtrlColorSpaceTrans";
            this.Size = new System.Drawing.Size(343, 50);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tLPanel_colorSpace.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tLPanel_colorSpace;
        private System.Windows.Forms.CheckBox checkBox_imageR;
        private System.Windows.Forms.CheckBox checkBox_imageG;
        private System.Windows.Forms.CheckBox checkBox_imageB;
        private System.Windows.Forms.CheckBox checkBox_image1;
        private System.Windows.Forms.CheckBox checkBox_image2;
        private System.Windows.Forms.CheckBox checkBox_image3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbBox_ColorSpace;
        private System.Windows.Forms.CheckBox checkBox_gray;
        private System.Windows.Forms.CheckBox checkBox_Cont;
    }
}

namespace VisionPlatform
{
    partial class FormPhotometricStereo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPhotometricStereo));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel6 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.Lbl_NormalField = new System.Windows.Forms.ToolStripLabel();
            this.Lbl_Albedo = new System.Windows.Forms.ToolStripLabel();
            this.Lbl_Gradient = new System.Windows.Forms.ToolStripLabel();
            this.Lbl_Curvature = new System.Windows.Forms.ToolStripLabel();
            this.Lbl_HeightField = new System.Windows.Forms.ToolStripLabel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.hWndCtrl4 = new HalconDotNet.HWindowControl();
            this.hWndCtrl3 = new HalconDotNet.HWindowControl();
            this.hWndCtrl2 = new HalconDotNet.HWindowControl();
            this.hWndCtrl1 = new HalconDotNet.HWindowControl();
            this.hWndCtrl = new HalconDotNet.HWindowControl();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel7 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tSBut_Grab = new System.Windows.Forms.ToolStripButton();
            this.tSBut_Load = new System.Windows.Forms.ToolStripButton();
            this.tSBut_Fusion = new System.Windows.Forms.ToolStripButton();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.toolStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStrip1.GripMargin = new System.Windows.Forms.Padding(0);
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel6,
            this.toolStripSeparator1,
            this.Lbl_NormalField,
            this.Lbl_Albedo,
            this.Lbl_Gradient,
            this.Lbl_Curvature,
            this.Lbl_HeightField});
            this.toolStrip1.Location = new System.Drawing.Point(195, 1);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(633, 31);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel6
            // 
            this.toolStripLabel6.BackColor = System.Drawing.Color.Transparent;
            this.toolStripLabel6.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.toolStripLabel6.Name = "toolStripLabel6";
            this.toolStripLabel6.Size = new System.Drawing.Size(126, 28);
            this.toolStripLabel6.Text = "2.5D预处理效果图";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // Lbl_NormalField
            // 
            this.Lbl_NormalField.Name = "Lbl_NormalField";
            this.Lbl_NormalField.Size = new System.Drawing.Size(65, 28);
            this.Lbl_NormalField.Text = "法向量图";
            this.Lbl_NormalField.Click += new System.EventHandler(this.Lbl_NormalField_Click);
            // 
            // Lbl_Albedo
            // 
            this.Lbl_Albedo.Name = "Lbl_Albedo";
            this.Lbl_Albedo.Size = new System.Drawing.Size(65, 28);
            this.Lbl_Albedo.Text = "反照率图";
            this.Lbl_Albedo.Click += new System.EventHandler(this.Lbl_Albedo_Click);
            // 
            // Lbl_Gradient
            // 
            this.Lbl_Gradient.Name = "Lbl_Gradient";
            this.Lbl_Gradient.Size = new System.Drawing.Size(51, 28);
            this.Lbl_Gradient.Text = "梯度图";
            this.Lbl_Gradient.Click += new System.EventHandler(this.Lbl_Gradient_Click);
            // 
            // Lbl_Curvature
            // 
            this.Lbl_Curvature.Name = "Lbl_Curvature";
            this.Lbl_Curvature.Size = new System.Drawing.Size(51, 28);
            this.Lbl_Curvature.Text = "曲率图";
            this.Lbl_Curvature.Click += new System.EventHandler(this.Lbl_Curvature_Click);
            // 
            // Lbl_HeightField
            // 
            this.Lbl_HeightField.Name = "Lbl_HeightField";
            this.Lbl_HeightField.Size = new System.Drawing.Size(79, 28);
            this.Lbl_HeightField.Text = "高度信息图";
            this.Lbl_HeightField.Visible = false;
            this.Lbl_HeightField.Click += new System.EventHandler(this.Lbl_HeightField_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.hWndCtrl4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.hWndCtrl3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.hWndCtrl2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.hWndCtrl1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(1, 33);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(193, 526);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // hWndCtrl4
            // 
            this.hWndCtrl4.BackColor = System.Drawing.Color.Black;
            this.hWndCtrl4.BorderColor = System.Drawing.Color.Black;
            this.hWndCtrl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hWndCtrl4.ImagePart = new System.Drawing.Rectangle(0, 0, 640, 480);
            this.hWndCtrl4.Location = new System.Drawing.Point(3, 396);
            this.hWndCtrl4.Name = "hWndCtrl4";
            this.hWndCtrl4.Size = new System.Drawing.Size(187, 127);
            this.hWndCtrl4.TabIndex = 5;
            this.hWndCtrl4.WindowSize = new System.Drawing.Size(187, 127);
            // 
            // hWndCtrl3
            // 
            this.hWndCtrl3.BackColor = System.Drawing.Color.Black;
            this.hWndCtrl3.BorderColor = System.Drawing.Color.Black;
            this.hWndCtrl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hWndCtrl3.ImagePart = new System.Drawing.Rectangle(0, 0, 640, 480);
            this.hWndCtrl3.Location = new System.Drawing.Point(3, 265);
            this.hWndCtrl3.Name = "hWndCtrl3";
            this.hWndCtrl3.Size = new System.Drawing.Size(187, 125);
            this.hWndCtrl3.TabIndex = 4;
            this.hWndCtrl3.WindowSize = new System.Drawing.Size(187, 125);
            // 
            // hWndCtrl2
            // 
            this.hWndCtrl2.BackColor = System.Drawing.Color.Black;
            this.hWndCtrl2.BorderColor = System.Drawing.Color.Black;
            this.hWndCtrl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hWndCtrl2.ImagePart = new System.Drawing.Rectangle(0, 0, 640, 480);
            this.hWndCtrl2.Location = new System.Drawing.Point(3, 134);
            this.hWndCtrl2.Name = "hWndCtrl2";
            this.hWndCtrl2.Size = new System.Drawing.Size(187, 125);
            this.hWndCtrl2.TabIndex = 3;
            this.hWndCtrl2.WindowSize = new System.Drawing.Size(187, 125);
            // 
            // hWndCtrl1
            // 
            this.hWndCtrl1.BackColor = System.Drawing.Color.Black;
            this.hWndCtrl1.BorderColor = System.Drawing.Color.Black;
            this.hWndCtrl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hWndCtrl1.ImagePart = new System.Drawing.Rectangle(0, 0, 640, 480);
            this.hWndCtrl1.Location = new System.Drawing.Point(3, 3);
            this.hWndCtrl1.Name = "hWndCtrl1";
            this.hWndCtrl1.Size = new System.Drawing.Size(187, 125);
            this.hWndCtrl1.TabIndex = 2;
            this.hWndCtrl1.WindowSize = new System.Drawing.Size(187, 125);
            // 
            // hWndCtrl
            // 
            this.hWndCtrl.BackColor = System.Drawing.Color.Black;
            this.hWndCtrl.BorderColor = System.Drawing.Color.Black;
            this.hWndCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hWndCtrl.ImagePart = new System.Drawing.Rectangle(0, 0, 640, 480);
            this.hWndCtrl.Location = new System.Drawing.Point(198, 36);
            this.hWndCtrl.Name = "hWndCtrl";
            this.hWndCtrl.Size = new System.Drawing.Size(627, 520);
            this.hWndCtrl.TabIndex = 1;
            this.hWndCtrl.WindowSize = new System.Drawing.Size(627, 520);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 193F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.toolStrip2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.toolStrip1, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel1, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.hWndCtrl, 1, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(829, 560);
            this.tableLayoutPanel2.TabIndex = 6;
            // 
            // toolStrip2
            // 
            this.toolStrip2.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStrip2.GripMargin = new System.Windows.Forms.Padding(0);
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel7,
            this.toolStripSeparator2,
            this.tSBut_Grab,
            this.tSBut_Load,
            this.tSBut_Fusion});
            this.toolStrip2.Location = new System.Drawing.Point(1, 1);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(193, 31);
            this.toolStrip2.TabIndex = 3;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripLabel7
            // 
            this.toolStripLabel7.BackColor = System.Drawing.Color.Transparent;
            this.toolStripLabel7.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.toolStripLabel7.Name = "toolStripLabel7";
            this.toolStripLabel7.Size = new System.Drawing.Size(57, 28);
            this.toolStripLabel7.Text = "2D原图";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 31);
            // 
            // tSBut_Grab
            // 
            this.tSBut_Grab.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tSBut_Grab.Image = ((System.Drawing.Image)(resources.GetObject("tSBut_Grab.Image")));
            this.tSBut_Grab.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSBut_Grab.Name = "tSBut_Grab";
            this.tSBut_Grab.Size = new System.Drawing.Size(23, 28);
            this.tSBut_Grab.Text = "拍照";
            this.tSBut_Grab.Click += new System.EventHandler(this.tSBut_Grab_Click);
            // 
            // tSBut_Load
            // 
            this.tSBut_Load.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tSBut_Load.Image = ((System.Drawing.Image)(resources.GetObject("tSBut_Load.Image")));
            this.tSBut_Load.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSBut_Load.Name = "tSBut_Load";
            this.tSBut_Load.Size = new System.Drawing.Size(23, 28);
            this.tSBut_Load.Text = "导入图像";
            this.tSBut_Load.Click += new System.EventHandler(this.tSBut_Load_Click);
            // 
            // tSBut_Fusion
            // 
            this.tSBut_Fusion.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tSBut_Fusion.Image = ((System.Drawing.Image)(resources.GetObject("tSBut_Fusion.Image")));
            this.tSBut_Fusion.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSBut_Fusion.Name = "tSBut_Fusion";
            this.tSBut_Fusion.Size = new System.Drawing.Size(23, 28);
            this.tSBut_Fusion.Text = "融合";
            this.tSBut_Fusion.Click += new System.EventHandler(this.tSBut_Fusion_Click);
            // 
            // FormPhotometricStereo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(829, 560);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Name = "FormPhotometricStereo";
            this.Text = "光度立体";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStripLabel Lbl_NormalField;
        private HalconDotNet.HWindowControl hWndCtrl;
        private System.Windows.Forms.ToolStripLabel Lbl_Albedo;
        private System.Windows.Forms.ToolStripLabel Lbl_Gradient;
        private System.Windows.Forms.ToolStripLabel Lbl_Curvature;
        private System.Windows.Forms.ToolStripLabel Lbl_HeightField;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel7;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tSBut_Grab;
        private System.Windows.Forms.ToolStripButton tSBut_Load;
        private System.Windows.Forms.ToolStripButton tSBut_Fusion;
        private HalconDotNet.HWindowControl hWndCtrl4;
        private HalconDotNet.HWindowControl hWndCtrl3;
        private HalconDotNet.HWindowControl hWndCtrl2;
        private HalconDotNet.HWindowControl hWndCtrl1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}
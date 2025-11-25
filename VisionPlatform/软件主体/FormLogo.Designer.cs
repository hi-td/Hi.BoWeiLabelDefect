namespace VisionPlatform
{
    partial class FormLogo
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
            this.components = new System.ComponentModel.Container();
            this.picBox_Logo = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.import_LOGO = new System.Windows.Forms.ToolStripMenuItem();
            this.Del = new System.Windows.Forms.ToolStripMenuItem();
            this.显示模式ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.填充 = new System.Windows.Forms.ToolStripMenuItem();
            this.按图像大小 = new System.Windows.Forms.ToolStripMenuItem();
            this.居中显示 = new System.Windows.Forms.ToolStripMenuItem();
            this.图像自适应 = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.picBox_Logo)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // picBox_Logo
            // 
            this.picBox_Logo.ContextMenuStrip = this.contextMenuStrip1;
            this.picBox_Logo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picBox_Logo.Location = new System.Drawing.Point(0, 0);
            this.picBox_Logo.Margin = new System.Windows.Forms.Padding(0);
            this.picBox_Logo.Name = "picBox_Logo";
            this.picBox_Logo.Size = new System.Drawing.Size(800, 450);
            this.picBox_Logo.TabIndex = 0;
            this.picBox_Logo.TabStop = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.import_LOGO,
            this.显示模式ToolStripMenuItem,
            this.Del});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 92);
            // 
            // import_LOGO
            // 
            this.import_LOGO.Name = "import_LOGO";
            this.import_LOGO.Size = new System.Drawing.Size(180, 22);
            this.import_LOGO.Text = "导入公司LOGO";
            this.import_LOGO.Click += new System.EventHandler(this.import_LOGO_Click);
            // 
            // Del
            // 
            this.Del.Name = "Del";
            this.Del.Size = new System.Drawing.Size(180, 22);
            this.Del.Text = "清除";
            this.Del.Click += new System.EventHandler(this.Del_Click);
            // 
            // 显示模式ToolStripMenuItem
            // 
            this.显示模式ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.填充,
            this.按图像大小,
            this.居中显示,
            this.图像自适应});
            this.显示模式ToolStripMenuItem.Name = "显示模式ToolStripMenuItem";
            this.显示模式ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.显示模式ToolStripMenuItem.Text = "显示模式";
            // 
            // 填充
            // 
            this.填充.Name = "填充";
            this.填充.Size = new System.Drawing.Size(180, 22);
            this.填充.Text = "填充";
            this.填充.Click += new System.EventHandler(this.填充_Click);
            // 
            // 按图像大小
            // 
            this.按图像大小.Name = "按图像大小";
            this.按图像大小.Size = new System.Drawing.Size(180, 22);
            this.按图像大小.Text = "按图像大小";
            this.按图像大小.Click += new System.EventHandler(this.按图像大小_Click);
            // 
            // 居中显示
            // 
            this.居中显示.Name = "居中显示";
            this.居中显示.Size = new System.Drawing.Size(180, 22);
            this.居中显示.Text = "居中显示";
            this.居中显示.Click += new System.EventHandler(this.居中显示_Click);
            // 
            // 图像自适应
            // 
            this.图像自适应.Name = "图像自适应";
            this.图像自适应.Size = new System.Drawing.Size(180, 22);
            this.图像自适应.Text = "图像自适应";
            this.图像自适应.Click += new System.EventHandler(this.图像自适应_Click);
            // 
            // FormLogo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.picBox_Logo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormLogo";
            this.Text = "FormLogo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormLogo_FormClosing);
            this.Load += new System.EventHandler(this.FormLogo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBox_Logo)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picBox_Logo;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem import_LOGO;
        private System.Windows.Forms.ToolStripMenuItem Del;
        private System.Windows.Forms.ToolStripMenuItem 显示模式ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 填充;
        private System.Windows.Forms.ToolStripMenuItem 按图像大小;
        private System.Windows.Forms.ToolStripMenuItem 居中显示;
        private System.Windows.Forms.ToolStripMenuItem 图像自适应;
    }
}
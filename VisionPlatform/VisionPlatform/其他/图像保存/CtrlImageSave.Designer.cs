namespace VisionPlatform
{
    partial class CtrlImageSave
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtrlImageSave));
            this.tLPanel = new System.Windows.Forms.TableLayoutPanel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.显示1 = new System.Windows.Forms.ToolStripMenuItem();
            this.显示2 = new System.Windows.Forms.ToolStripMenuItem();
            this.checkBox_SaveResultImgOK = new System.Windows.Forms.CheckBox();
            this.checkBox_SaveOrgImageOK = new System.Windows.Forms.CheckBox();
            this.checkBox_SaveResultImgNG = new System.Windows.Forms.CheckBox();
            this.checkBox_SaveOrgImageNG = new System.Windows.Forms.CheckBox();
            this.checkBox_ShowData = new System.Windows.Forms.CheckBox();
            this.tLPanel.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tLPanel
            // 
            this.tLPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tLPanel.ColumnCount = 1;
            this.tLPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tLPanel.ContextMenuStrip = this.contextMenuStrip1;
            this.tLPanel.Controls.Add(this.checkBox_SaveResultImgOK, 0, 2);
            this.tLPanel.Controls.Add(this.checkBox_SaveOrgImageOK, 0, 1);
            this.tLPanel.Controls.Add(this.checkBox_SaveResultImgNG, 0, 4);
            this.tLPanel.Controls.Add(this.checkBox_SaveOrgImageNG, 0, 3);
            this.tLPanel.Controls.Add(this.checkBox_ShowData, 0, 0);
            this.tLPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tLPanel.Font = new System.Drawing.Font("宋体", 10F);
            this.tLPanel.Location = new System.Drawing.Point(0, 0);
            this.tLPanel.Margin = new System.Windows.Forms.Padding(0);
            this.tLPanel.Name = "tLPanel";
            this.tLPanel.RowCount = 5;
            this.tLPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tLPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tLPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tLPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tLPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tLPanel.Size = new System.Drawing.Size(118, 141);
            this.tLPanel.TabIndex = 2;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.AutoSize = false;
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.显示1,
            this.显示2});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(100, 60);
            // 
            // 显示1
            // 
            this.显示1.Image = ((System.Drawing.Image)(resources.GetObject("显示1.Image")));
            this.显示1.Name = "显示1";
            this.显示1.Size = new System.Drawing.Size(107, 22);
            this.显示1.Text = "显示1";
            this.显示1.Click += new System.EventHandler(this.显示1_Click);
            // 
            // 显示2
            // 
            this.显示2.Image = ((System.Drawing.Image)(resources.GetObject("显示2.Image")));
            this.显示2.Name = "显示2";
            this.显示2.Size = new System.Drawing.Size(107, 22);
            this.显示2.Text = "显示2";
            this.显示2.Click += new System.EventHandler(this.显示2_Click);
            // 
            // checkBox_SaveResultImgOK
            // 
            this.checkBox_SaveResultImgOK.AutoSize = true;
            this.checkBox_SaveResultImgOK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBox_SaveResultImgOK.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkBox_SaveResultImgOK.Location = new System.Drawing.Point(4, 58);
            this.checkBox_SaveResultImgOK.Margin = new System.Windows.Forms.Padding(3, 1, 1, 1);
            this.checkBox_SaveResultImgOK.Name = "checkBox_SaveResultImgOK";
            this.checkBox_SaveResultImgOK.Size = new System.Drawing.Size(112, 25);
            this.checkBox_SaveResultImgOK.TabIndex = 8;
            this.checkBox_SaveResultImgOK.Text = "保存OK结果图";
            this.checkBox_SaveResultImgOK.UseVisualStyleBackColor = true;
            this.checkBox_SaveResultImgOK.CheckedChanged += new System.EventHandler(this.Save);
            // 
            // checkBox_SaveOrgImageOK
            // 
            this.checkBox_SaveOrgImageOK.AutoSize = true;
            this.checkBox_SaveOrgImageOK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBox_SaveOrgImageOK.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkBox_SaveOrgImageOK.Location = new System.Drawing.Point(4, 30);
            this.checkBox_SaveOrgImageOK.Margin = new System.Windows.Forms.Padding(3, 1, 1, 1);
            this.checkBox_SaveOrgImageOK.Name = "checkBox_SaveOrgImageOK";
            this.checkBox_SaveOrgImageOK.Size = new System.Drawing.Size(112, 25);
            this.checkBox_SaveOrgImageOK.TabIndex = 7;
            this.checkBox_SaveOrgImageOK.Text = "保存OK原图";
            this.checkBox_SaveOrgImageOK.UseVisualStyleBackColor = true;
            this.checkBox_SaveOrgImageOK.CheckedChanged += new System.EventHandler(this.Save);
            // 
            // checkBox_SaveResultImgNG
            // 
            this.checkBox_SaveResultImgNG.AutoSize = true;
            this.checkBox_SaveResultImgNG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBox_SaveResultImgNG.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkBox_SaveResultImgNG.Location = new System.Drawing.Point(4, 114);
            this.checkBox_SaveResultImgNG.Margin = new System.Windows.Forms.Padding(3, 1, 1, 1);
            this.checkBox_SaveResultImgNG.Name = "checkBox_SaveResultImgNG";
            this.checkBox_SaveResultImgNG.Size = new System.Drawing.Size(112, 25);
            this.checkBox_SaveResultImgNG.TabIndex = 9;
            this.checkBox_SaveResultImgNG.Text = "保存NG结果图";
            this.checkBox_SaveResultImgNG.UseVisualStyleBackColor = true;
            this.checkBox_SaveResultImgNG.CheckedChanged += new System.EventHandler(this.Save);
            // 
            // checkBox_SaveOrgImageNG
            // 
            this.checkBox_SaveOrgImageNG.AutoSize = true;
            this.checkBox_SaveOrgImageNG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBox_SaveOrgImageNG.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkBox_SaveOrgImageNG.Location = new System.Drawing.Point(4, 86);
            this.checkBox_SaveOrgImageNG.Margin = new System.Windows.Forms.Padding(3, 1, 1, 1);
            this.checkBox_SaveOrgImageNG.Name = "checkBox_SaveOrgImageNG";
            this.checkBox_SaveOrgImageNG.Size = new System.Drawing.Size(112, 25);
            this.checkBox_SaveOrgImageNG.TabIndex = 8;
            this.checkBox_SaveOrgImageNG.Text = "保存NG原图";
            this.checkBox_SaveOrgImageNG.UseVisualStyleBackColor = true;
            this.checkBox_SaveOrgImageNG.CheckedChanged += new System.EventHandler(this.Save);
            // 
            // checkBox_ShowData
            // 
            this.checkBox_ShowData.AutoSize = true;
            this.checkBox_ShowData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBox_ShowData.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkBox_ShowData.Location = new System.Drawing.Point(4, 2);
            this.checkBox_ShowData.Margin = new System.Windows.Forms.Padding(3, 1, 1, 1);
            this.checkBox_ShowData.Name = "checkBox_ShowData";
            this.checkBox_ShowData.Size = new System.Drawing.Size(112, 25);
            this.checkBox_ShowData.TabIndex = 11;
            this.checkBox_ShowData.Text = "显示数据";
            this.checkBox_ShowData.UseVisualStyleBackColor = true;
            this.checkBox_ShowData.CheckedChanged += new System.EventHandler(this.Save);
            // 
            // CtrlImageSave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.tLPanel);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "CtrlImageSave";
            this.Size = new System.Drawing.Size(118, 141);
            this.Load += new System.EventHandler(this.CtrlImageSave_Load);
            this.tLPanel.ResumeLayout(false);
            this.tLPanel.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tLPanel;
        private System.Windows.Forms.CheckBox checkBox_SaveResultImgOK;
        private System.Windows.Forms.CheckBox checkBox_SaveOrgImageOK;
        private System.Windows.Forms.CheckBox checkBox_SaveResultImgNG;
        private System.Windows.Forms.CheckBox checkBox_SaveOrgImageNG;
        private System.Windows.Forms.CheckBox checkBox_ShowData;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 显示1;
        private System.Windows.Forms.ToolStripMenuItem 显示2;
    }
}

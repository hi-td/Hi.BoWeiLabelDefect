namespace VisionPlatform
{
    partial class CtrlColorMethod
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
            this.panel4 = new System.Windows.Forms.Panel();
            this.checkBox_AddNew = new System.Windows.Forms.CheckBox();
            this.checkBox_Train = new System.Windows.Forms.CheckBox();
            this.checkBox_ColorSpaceThd = new System.Windows.Forms.CheckBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.清空 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tabPage_AddNew = new System.Windows.Forms.TabPage();
            this.ctrlColorTrain_Add = new VisionPlatform.CtrlColorTrain();
            this.tabPage_Train = new System.Windows.Forms.TabPage();
            this.ctrlColorTrain = new VisionPlatform.CtrlColorTrain();
            this.tabCtrl = new System.Windows.Forms.TabControl();
            this.tabPage_colorSpaceThd = new System.Windows.Forms.TabPage();
            this.ctrlColorSpaceThd = new VisionPlatform.CtrlColorSpaceThd();
            this.panel4.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.tabPage_AddNew.SuspendLayout();
            this.tabPage_Train.SuspendLayout();
            this.tabCtrl.SuspendLayout();
            this.tabPage_colorSpaceThd.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.Control;
            this.panel4.Controls.Add(this.checkBox_AddNew);
            this.panel4.Controls.Add(this.checkBox_Train);
            this.panel4.Controls.Add(this.checkBox_ColorSpaceThd);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(392, 22);
            this.panel4.TabIndex = 19;
            // 
            // checkBox_AddNew
            // 
            this.checkBox_AddNew.AutoSize = true;
            this.checkBox_AddNew.Dock = System.Windows.Forms.DockStyle.Left;
            this.checkBox_AddNew.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox_AddNew.Location = new System.Drawing.Point(159, 0);
            this.checkBox_AddNew.Name = "checkBox_AddNew";
            this.checkBox_AddNew.Size = new System.Drawing.Size(99, 22);
            this.checkBox_AddNew.TabIndex = 4;
            this.checkBox_AddNew.Text = "新增颜色模型";
            this.checkBox_AddNew.UseVisualStyleBackColor = true;
            this.checkBox_AddNew.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // checkBox_Train
            // 
            this.checkBox_Train.AutoSize = true;
            this.checkBox_Train.Dock = System.Windows.Forms.DockStyle.Left;
            this.checkBox_Train.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox_Train.Location = new System.Drawing.Point(81, 0);
            this.checkBox_Train.Name = "checkBox_Train";
            this.checkBox_Train.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.checkBox_Train.Size = new System.Drawing.Size(78, 22);
            this.checkBox_Train.TabIndex = 2;
            this.checkBox_Train.Text = "训练模型";
            this.checkBox_Train.UseVisualStyleBackColor = true;
            this.checkBox_Train.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // checkBox_ColorSpaceThd
            // 
            this.checkBox_ColorSpaceThd.AutoSize = true;
            this.checkBox_ColorSpaceThd.BackColor = System.Drawing.SystemColors.Control;
            this.checkBox_ColorSpaceThd.Dock = System.Windows.Forms.DockStyle.Left;
            this.checkBox_ColorSpaceThd.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox_ColorSpaceThd.Location = new System.Drawing.Point(0, 0);
            this.checkBox_ColorSpaceThd.Margin = new System.Windows.Forms.Padding(10, 3, 6, 3);
            this.checkBox_ColorSpaceThd.Name = "checkBox_ColorSpaceThd";
            this.checkBox_ColorSpaceThd.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.checkBox_ColorSpaceThd.Size = new System.Drawing.Size(81, 22);
            this.checkBox_ColorSpaceThd.TabIndex = 5;
            this.checkBox_ColorSpaceThd.Text = "颜色空间";
            this.checkBox_ColorSpaceThd.UseVisualStyleBackColor = false;
            this.checkBox_ColorSpaceThd.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
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
            // 
            // tabPage_AddNew
            // 
            this.tabPage_AddNew.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage_AddNew.Controls.Add(this.ctrlColorTrain_Add);
            this.tabPage_AddNew.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabPage_AddNew.Location = new System.Drawing.Point(4, 26);
            this.tabPage_AddNew.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage_AddNew.Name = "tabPage_AddNew";
            this.tabPage_AddNew.Size = new System.Drawing.Size(384, 111);
            this.tabPage_AddNew.TabIndex = 2;
            this.tabPage_AddNew.Text = "新增颜色模型";
            // 
            // ctrlColorTrain_Add
            // 
            this.ctrlColorTrain_Add.Dock = System.Windows.Forms.DockStyle.Top;
            this.ctrlColorTrain_Add.Location = new System.Drawing.Point(0, 0);
            this.ctrlColorTrain_Add.Margin = new System.Windows.Forms.Padding(0);
            this.ctrlColorTrain_Add.Name = "ctrlColorTrain_Add";
            this.ctrlColorTrain_Add.Size = new System.Drawing.Size(384, 51);
            this.ctrlColorTrain_Add.TabIndex = 0;
            // 
            // tabPage_Train
            // 
            this.tabPage_Train.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage_Train.Controls.Add(this.ctrlColorTrain);
            this.tabPage_Train.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabPage_Train.Location = new System.Drawing.Point(4, 26);
            this.tabPage_Train.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage_Train.Name = "tabPage_Train";
            this.tabPage_Train.Size = new System.Drawing.Size(384, 111);
            this.tabPage_Train.TabIndex = 0;
            this.tabPage_Train.Text = "学习训练";
            // 
            // ctrlColorTrain
            // 
            this.ctrlColorTrain.Dock = System.Windows.Forms.DockStyle.Top;
            this.ctrlColorTrain.Location = new System.Drawing.Point(0, 0);
            this.ctrlColorTrain.Margin = new System.Windows.Forms.Padding(0);
            this.ctrlColorTrain.Name = "ctrlColorTrain";
            this.ctrlColorTrain.Size = new System.Drawing.Size(384, 51);
            this.ctrlColorTrain.TabIndex = 0;
            // 
            // tabCtrl
            // 
            this.tabCtrl.Controls.Add(this.tabPage_Train);
            this.tabCtrl.Controls.Add(this.tabPage_AddNew);
            this.tabCtrl.Controls.Add(this.tabPage_colorSpaceThd);
            this.tabCtrl.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabCtrl.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabCtrl.Location = new System.Drawing.Point(0, 22);
            this.tabCtrl.Margin = new System.Windows.Forms.Padding(0);
            this.tabCtrl.Name = "tabCtrl";
            this.tabCtrl.SelectedIndex = 0;
            this.tabCtrl.Size = new System.Drawing.Size(392, 141);
            this.tabCtrl.TabIndex = 20;
            // 
            // tabPage_colorSpaceThd
            // 
            this.tabPage_colorSpaceThd.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage_colorSpaceThd.Controls.Add(this.ctrlColorSpaceThd);
            this.tabPage_colorSpaceThd.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabPage_colorSpaceThd.Location = new System.Drawing.Point(4, 26);
            this.tabPage_colorSpaceThd.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage_colorSpaceThd.Name = "tabPage_colorSpaceThd";
            this.tabPage_colorSpaceThd.Size = new System.Drawing.Size(384, 111);
            this.tabPage_colorSpaceThd.TabIndex = 3;
            this.tabPage_colorSpaceThd.Text = "颜色空间";
            // 
            // ctrlColorSpaceThd
            // 
            this.ctrlColorSpaceThd.Dock = System.Windows.Forms.DockStyle.Top;
            this.ctrlColorSpaceThd.Location = new System.Drawing.Point(0, 0);
            this.ctrlColorSpaceThd.Margin = new System.Windows.Forms.Padding(0);
            this.ctrlColorSpaceThd.Name = "ctrlColorSpaceThd";
            this.ctrlColorSpaceThd.Size = new System.Drawing.Size(384, 111);
            this.ctrlColorSpaceThd.TabIndex = 0;
            // 
            // CtrlColorMethod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.Controls.Add(this.tabCtrl);
            this.Controls.Add(this.panel4);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "CtrlColorMethod";
            this.Size = new System.Drawing.Size(392, 163);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.tabPage_AddNew.ResumeLayout(false);
            this.tabPage_Train.ResumeLayout(false);
            this.tabCtrl.ResumeLayout(false);
            this.tabPage_colorSpaceThd.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.CheckBox checkBox_Train;
        private System.Windows.Forms.CheckBox checkBox_AddNew;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 清空;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TabPage tabPage_AddNew;
        private CtrlColorTrain ctrlColorTrain_Add;
        private System.Windows.Forms.TabPage tabPage_Train;
        private CtrlColorTrain ctrlColorTrain;
        private System.Windows.Forms.TabControl tabCtrl;
        private System.Windows.Forms.CheckBox checkBox_ColorSpaceThd;
        private System.Windows.Forms.TabPage tabPage_colorSpaceThd;
        private CtrlColorSpaceThd ctrlColorSpaceThd;
    }
}

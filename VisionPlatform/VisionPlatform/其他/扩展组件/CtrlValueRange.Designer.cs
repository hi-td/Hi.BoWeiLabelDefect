namespace VisionPlatform
{
    partial class CtrlValueRange
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
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.numUpD_Max = new System.Windows.Forms.NumericUpDown();
            this.label72 = new System.Windows.Forms.Label();
            this.numUpD_Min = new System.Windows.Forms.NumericUpDown();
            this.checkBox_Name = new System.Windows.Forms.CheckBox();
            this.label_Name = new System.Windows.Forms.Label();
            this.tLPanel_LableName = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpD_Max)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpD_Min)).BeginInit();
            this.tLPanel_LableName.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 4;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Controls.Add(this.numUpD_Max, 2, 0);
            this.tableLayoutPanel.Controls.Add(this.label72, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.numUpD_Min, 0, 0);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(121, 0);
            this.tableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 1;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(204, 26);
            this.tableLayoutPanel.TabIndex = 15;
            // 
            // numUpD_Max
            // 
            this.numUpD_Max.DecimalPlaces = 2;
            this.numUpD_Max.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numUpD_Max.Font = new System.Drawing.Font("宋体", 10F);
            this.numUpD_Max.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numUpD_Max.Location = new System.Drawing.Point(76, 1);
            this.numUpD_Max.Margin = new System.Windows.Forms.Padding(1);
            this.numUpD_Max.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numUpD_Max.Name = "numUpD_Max";
            this.numUpD_Max.Size = new System.Drawing.Size(63, 23);
            this.numUpD_Max.TabIndex = 5;
            this.numUpD_Max.Value = new decimal(new int[] {
            95,
            0,
            0,
            131072});
            this.numUpD_Max.ValueChanged += new System.EventHandler(this.Inspect);
            // 
            // label72
            // 
            this.label72.AutoSize = true;
            this.label72.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label72.Font = new System.Drawing.Font("宋体", 10F);
            this.label72.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label72.Location = new System.Drawing.Point(65, 0);
            this.label72.Margin = new System.Windows.Forms.Padding(0);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(10, 26);
            this.label72.TabIndex = 6;
            this.label72.Text = "-";
            this.label72.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numUpD_Min
            // 
            this.numUpD_Min.DecimalPlaces = 2;
            this.numUpD_Min.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numUpD_Min.Font = new System.Drawing.Font("宋体", 10F);
            this.numUpD_Min.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numUpD_Min.Location = new System.Drawing.Point(1, 1);
            this.numUpD_Min.Margin = new System.Windows.Forms.Padding(1);
            this.numUpD_Min.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numUpD_Min.Name = "numUpD_Min";
            this.numUpD_Min.Size = new System.Drawing.Size(63, 23);
            this.numUpD_Min.TabIndex = 4;
            this.numUpD_Min.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numUpD_Min.ValueChanged += new System.EventHandler(this.Inspect);
            // 
            // checkBox_Name
            // 
            this.checkBox_Name.AutoSize = true;
            this.checkBox_Name.Checked = true;
            this.checkBox_Name.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_Name.Dock = System.Windows.Forms.DockStyle.Left;
            this.checkBox_Name.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.checkBox_Name.Location = new System.Drawing.Point(0, 0);
            this.checkBox_Name.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.checkBox_Name.Name = "checkBox_Name";
            this.checkBox_Name.Size = new System.Drawing.Size(56, 26);
            this.checkBox_Name.TabIndex = 16;
            this.checkBox_Name.Text = "名字";
            this.checkBox_Name.UseVisualStyleBackColor = true;
            this.checkBox_Name.CheckedChanged += new System.EventHandler(this.Inspect);
            // 
            // label_Name
            // 
            this.label_Name.AutoSize = true;
            this.label_Name.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Name.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.label_Name.Location = new System.Drawing.Point(0, 0);
            this.label_Name.Margin = new System.Windows.Forms.Padding(0);
            this.label_Name.Name = "label_Name";
            this.label_Name.Size = new System.Drawing.Size(65, 26);
            this.label_Name.TabIndex = 17;
            this.label_Name.Text = "Name ";
            this.label_Name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_Name.Visible = false;
            // 
            // tLPanel_LableName
            // 
            this.tLPanel_LableName.ColumnCount = 1;
            this.tLPanel_LableName.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tLPanel_LableName.Controls.Add(this.label_Name, 0, 0);
            this.tLPanel_LableName.Dock = System.Windows.Forms.DockStyle.Left;
            this.tLPanel_LableName.Location = new System.Drawing.Point(56, 0);
            this.tLPanel_LableName.Margin = new System.Windows.Forms.Padding(0);
            this.tLPanel_LableName.Name = "tLPanel_LableName";
            this.tLPanel_LableName.RowCount = 1;
            this.tLPanel_LableName.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tLPanel_LableName.Size = new System.Drawing.Size(65, 26);
            this.tLPanel_LableName.TabIndex = 17;
            // 
            // CtrlValueRange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel);
            this.Controls.Add(this.tLPanel_LableName);
            this.Controls.Add(this.checkBox_Name);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "CtrlValueRange";
            this.Size = new System.Drawing.Size(325, 26);
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpD_Max)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpD_Min)).EndInit();
            this.tLPanel_LableName.ResumeLayout(false);
            this.tLPanel_LableName.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.NumericUpDown numUpD_Max;
        private System.Windows.Forms.Label label72;
        private System.Windows.Forms.NumericUpDown numUpD_Min;
        private System.Windows.Forms.CheckBox checkBox_Name;
        private System.Windows.Forms.Label label_Name;
        private System.Windows.Forms.TableLayoutPanel tLPanel_LableName;
    }
}

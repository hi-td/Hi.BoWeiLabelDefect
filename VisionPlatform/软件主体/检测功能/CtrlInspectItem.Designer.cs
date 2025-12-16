namespace VisionPlatform
{
    partial class CtrlInspectItem
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
            this.checkBox_Font = new System.Windows.Forms.CheckBox();
            this.checkBox_Back = new System.Windows.Forms.CheckBox();
            this.checkBox_Top = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.checkBox_Font, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.checkBox_Back, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.checkBox_Top, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(201, 31);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // checkBox_Font
            // 
            this.checkBox_Font.AutoSize = true;
            this.checkBox_Font.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBox_Font.Location = new System.Drawing.Point(4, 4);
            this.checkBox_Font.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox_Font.Name = "checkBox_Font";
            this.checkBox_Font.Size = new System.Drawing.Size(59, 23);
            this.checkBox_Font.TabIndex = 0;
            this.checkBox_Font.Text = "正面";
            this.checkBox_Font.UseVisualStyleBackColor = true;
            this.checkBox_Font.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // checkBox_Back
            // 
            this.checkBox_Back.AutoSize = true;
            this.checkBox_Back.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBox_Back.Location = new System.Drawing.Point(71, 4);
            this.checkBox_Back.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox_Back.Name = "checkBox_Back";
            this.checkBox_Back.Size = new System.Drawing.Size(59, 23);
            this.checkBox_Back.TabIndex = 1;
            this.checkBox_Back.Text = "背面";
            this.checkBox_Back.UseVisualStyleBackColor = true;
            this.checkBox_Back.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // checkBox_Top
            // 
            this.checkBox_Top.AutoSize = true;
            this.checkBox_Top.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBox_Top.Location = new System.Drawing.Point(138, 4);
            this.checkBox_Top.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox_Top.Name = "checkBox_Top";
            this.checkBox_Top.Size = new System.Drawing.Size(59, 23);
            this.checkBox_Top.TabIndex = 2;
            this.checkBox_Top.Text = "顶面";
            this.checkBox_Top.UseVisualStyleBackColor = true;
            this.checkBox_Top.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // CtrlInspectItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "CtrlInspectItem";
            this.Size = new System.Drawing.Size(201, 31);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.CheckBox checkBox_Font;
        private System.Windows.Forms.CheckBox checkBox_Back;
        private System.Windows.Forms.CheckBox checkBox_Top;
    }
}

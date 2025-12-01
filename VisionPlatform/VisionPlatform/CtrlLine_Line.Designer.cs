namespace VisionPlatform
{
    partial class CtrlLine_Line
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
            this.label6 = new System.Windows.Forms.Label();
            this.ctrlFitLine2 = new VisionPlatform.CtrlFitLine();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(47, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 19);
            this.label6.TabIndex = 1;
            this.label6.Text = "盒体边线";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ctrlFitLine2
            // 
            this.ctrlFitLine2.Font = new System.Drawing.Font("宋体", 10F);
            this.ctrlFitLine2.Location = new System.Drawing.Point(0, 81);
            this.ctrlFitLine2.Margin = new System.Windows.Forms.Padding(1);
            this.ctrlFitLine2.Name = "ctrlFitLine2";
            this.ctrlFitLine2.Size = new System.Drawing.Size(435, 77);
            this.ctrlFitLine2.TabIndex = 3;
            // 
            // CtrlLine_Line
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ctrlFitLine2);
            this.Controls.Add(this.label6);
            this.Name = "CtrlLine_Line";
            this.Size = new System.Drawing.Size(441, 280);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label6;
        private CtrlFitLine ctrlFitLine2;
    }
}

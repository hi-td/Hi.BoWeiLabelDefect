namespace VisionPlatform
{
    partial class but_run
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(but_run));
            this.butRun = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // butRun
            // 
            this.butRun.BackColor = System.Drawing.SystemColors.Control;
            this.butRun.Dock = System.Windows.Forms.DockStyle.Fill;
            this.butRun.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butRun.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.butRun.Image = ((System.Drawing.Image)(resources.GetObject("butRun.Image")));
            this.butRun.Location = new System.Drawing.Point(0, 0);
            this.butRun.Margin = new System.Windows.Forms.Padding(1);
            this.butRun.Name = "butRun";
            this.butRun.Size = new System.Drawing.Size(163, 80);
            this.butRun.TabIndex = 1;
            this.butRun.TabStop = false;
            this.butRun.Text = "运行";
            this.butRun.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butRun.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.butRun.UseVisualStyleBackColor = true;
            this.butRun.Click += new System.EventHandler(this.ButRun_Click);
            // 
            // but_run
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.butRun);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "but_run";
            this.Size = new System.Drawing.Size(163, 80);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button butRun;
    }
}

namespace VisionPlatform.多线插.PLC交互窗口
{
    partial class Axises
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
            this.htc_Axis = new Hi.Ltd.Windows.Forms.HTabControl();
            this.tp_Z = new System.Windows.Forms.TabPage();
            this.tp_T = new System.Windows.Forms.TabPage();
            this.htc_Axis.SuspendLayout();
            this.SuspendLayout();
            // 
            // htc_Axis
            // 
            this.htc_Axis.Controls.Add(this.tp_Z);
            this.htc_Axis.Controls.Add(this.tp_T);
            this.htc_Axis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.htc_Axis.ItemSize = new System.Drawing.Size(85, 32);
            this.htc_Axis.Location = new System.Drawing.Point(0, 0);
            this.htc_Axis.Name = "htc_Axis";
            this.htc_Axis.Radius = 0;
            this.htc_Axis.SelectedIndex = 0;
            this.htc_Axis.Size = new System.Drawing.Size(523, 516);
            this.htc_Axis.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.htc_Axis.TabIndex = 0;
            this.htc_Axis.TabsVisible = true;
            this.htc_Axis.TitleBackColor = System.Drawing.Color.Yellow;
            this.htc_Axis.TitleForeColor = System.Drawing.Color.Black;
            this.htc_Axis.TitleSelectedBackColor = System.Drawing.Color.Blue;
            this.htc_Axis.TitleSelectedForeColor = System.Drawing.Color.White;
            this.htc_Axis.SelectedIndexChanged += new System.EventHandler(this.Htc_Axis_SelectedIndexChanged);
            // 
            // tp_Z
            // 
            this.tp_Z.BackColor = System.Drawing.SystemColors.Control;
            this.tp_Z.Location = new System.Drawing.Point(4, 36);
            this.tp_Z.Name = "tp_Z";
            this.tp_Z.Padding = new System.Windows.Forms.Padding(3);
            this.tp_Z.Size = new System.Drawing.Size(515, 476);
            this.tp_Z.TabIndex = 0;
            this.tp_Z.Text = "相机1升降轴";
            // 
            // tp_T
            // 
            this.tp_T.BackColor = System.Drawing.SystemColors.Control;
            this.tp_T.Location = new System.Drawing.Point(4, 36);
            this.tp_T.Name = "tp_T";
            this.tp_T.Size = new System.Drawing.Size(515, 476);
            this.tp_T.TabIndex = 5;
            this.tp_T.Text = "相机二平移轴";
            // 
            // Axises
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.htc_Axis);
            this.Name = "Axises";
            this.Size = new System.Drawing.Size(523, 516);
            this.htc_Axis.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Hi.Ltd.Windows.Forms.HTabControl htc_Axis;
        private System.Windows.Forms.TabPage tp_Z;
        private System.Windows.Forms.TabPage tp_T;
    }
}

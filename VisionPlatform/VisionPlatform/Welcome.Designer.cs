namespace VisionPlatform
{
    partial class Welcome
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Welcome));
            this.lbl_Progress = new System.Windows.Forms.Label();
            this.pgb_Welcome = new System.Windows.Forms.ProgressBar();
            this.lbl_Content = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_Progress
            // 
            resources.ApplyResources(this.lbl_Progress, "lbl_Progress");
            this.lbl_Progress.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Progress.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbl_Progress.Name = "lbl_Progress";
            // 
            // pgb_Welcome
            // 
            resources.ApplyResources(this.pgb_Welcome, "pgb_Welcome");
            this.pgb_Welcome.BackColor = System.Drawing.Color.LightSteelBlue;
            this.pgb_Welcome.Name = "pgb_Welcome";
            // 
            // lbl_Content
            // 
            resources.ApplyResources(this.lbl_Content, "lbl_Content");
            this.lbl_Content.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Content.ForeColor = System.Drawing.Color.White;
            this.lbl_Content.Name = "lbl_Content";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Name = "label1";
            // 
            // Welcome
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_Progress);
            this.Controls.Add(this.pgb_Welcome);
            this.Controls.Add(this.lbl_Content);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Welcome";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Progress;
        private System.Windows.Forms.ProgressBar pgb_Welcome;
        private System.Windows.Forms.Label lbl_Content;
        private System.Windows.Forms.Label label1;
    }
}
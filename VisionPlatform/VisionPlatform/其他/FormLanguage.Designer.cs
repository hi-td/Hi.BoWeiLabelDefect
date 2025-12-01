namespace VisionPlatform
{
    partial class FormLanguage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLanguage));
            this.checkBox_Chinese = new System.Windows.Forms.CheckBox();
            this.checkBox_English = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.but_Save = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkBox_Chinese
            // 
            resources.ApplyResources(this.checkBox_Chinese, "checkBox_Chinese");
            this.checkBox_Chinese.Checked = true;
            this.checkBox_Chinese.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_Chinese.Name = "checkBox_Chinese";
            this.checkBox_Chinese.UseVisualStyleBackColor = true;
            this.checkBox_Chinese.CheckedChanged += new System.EventHandler(this.checkBox_Chinese_CheckedChanged);
            // 
            // checkBox_English
            // 
            resources.ApplyResources(this.checkBox_English, "checkBox_English");
            this.checkBox_English.Name = "checkBox_English";
            this.checkBox_English.UseVisualStyleBackColor = true;
            this.checkBox_English.CheckedChanged += new System.EventHandler(this.checkBox_English_CheckedChanged);
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.checkBox_Chinese, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.checkBox_English, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.but_Save, 1, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // but_Save
            // 
            resources.ApplyResources(this.but_Save, "but_Save");
            this.but_Save.ForeColor = System.Drawing.Color.Navy;
            this.but_Save.Name = "but_Save";
            this.but_Save.UseVisualStyleBackColor = true;
            this.but_Save.Click += new System.EventHandler(this.but_Save_Click);
            // 
            // FormLanguage
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormLanguage";
            this.Load += new System.EventHandler(this.FormLanguage_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBox_Chinese;
        private System.Windows.Forms.CheckBox checkBox_English;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button but_Save;
    }
}
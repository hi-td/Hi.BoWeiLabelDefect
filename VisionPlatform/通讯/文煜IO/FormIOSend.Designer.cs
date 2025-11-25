namespace VisionPlatform
{
    partial class FormIOSend
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormIOSend));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label_PreSendOK = new System.Windows.Forms.Label();
            this.label_PreSendNG = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.checkBox_OK = new System.Windows.Forms.CheckBox();
            this.checkBox_NG = new System.Windows.Forms.CheckBox();
            this.comboBox_OK = new System.Windows.Forms.ComboBox();
            this.comboBox_NG = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.numUpD_Sleep = new System.Windows.Forms.NumericUpDown();
            this.checkBox_Invert = new System.Windows.Forms.CheckBox();
            this.tLPanel_Sleep = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.but_SaveSet = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpD_Sleep)).BeginInit();
            this.tLPanel_Sleep.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label_PreSendOK, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label_PreSendNG, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label_PreSendOK
            // 
            resources.ApplyResources(this.label_PreSendOK, "label_PreSendOK");
            this.label_PreSendOK.Name = "label_PreSendOK";
            // 
            // label_PreSendNG
            // 
            resources.ApplyResources(this.label_PreSendNG, "label_PreSendNG");
            this.label_PreSendNG.Name = "label_PreSendNG";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // tableLayoutPanel2
            // 
            resources.ApplyResources(this.tableLayoutPanel2, "tableLayoutPanel2");
            this.tableLayoutPanel2.Controls.Add(this.checkBox_OK, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.checkBox_NG, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.comboBox_OK, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.comboBox_NG, 1, 1);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            // 
            // checkBox_OK
            // 
            resources.ApplyResources(this.checkBox_OK, "checkBox_OK");
            this.checkBox_OK.Name = "checkBox_OK";
            this.checkBox_OK.UseVisualStyleBackColor = true;
            this.checkBox_OK.CheckedChanged += new System.EventHandler(this.checkBox_OK_CheckedChanged);
            // 
            // checkBox_NG
            // 
            resources.ApplyResources(this.checkBox_NG, "checkBox_NG");
            this.checkBox_NG.Name = "checkBox_NG";
            this.checkBox_NG.UseVisualStyleBackColor = true;
            this.checkBox_NG.CheckedChanged += new System.EventHandler(this.checkBox_NG_CheckedChanged);
            // 
            // comboBox_OK
            // 
            resources.ApplyResources(this.comboBox_OK, "comboBox_OK");
            this.comboBox_OK.FormattingEnabled = true;
            this.comboBox_OK.Name = "comboBox_OK";
            this.comboBox_OK.SelectedIndexChanged += new System.EventHandler(this.comboBox_OK_SelectedIndexChanged);
            // 
            // comboBox_NG
            // 
            resources.ApplyResources(this.comboBox_NG, "comboBox_NG");
            this.comboBox_NG.FormattingEnabled = true;
            this.comboBox_NG.Name = "comboBox_NG";
            this.comboBox_NG.SelectedIndexChanged += new System.EventHandler(this.comboBox_NG_SelectedIndexChanged);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // numUpD_Sleep
            // 
            resources.ApplyResources(this.numUpD_Sleep, "numUpD_Sleep");
            this.numUpD_Sleep.Name = "numUpD_Sleep";
            this.numUpD_Sleep.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // checkBox_Invert
            // 
            resources.ApplyResources(this.checkBox_Invert, "checkBox_Invert");
            this.checkBox_Invert.Checked = true;
            this.checkBox_Invert.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_Invert.Name = "checkBox_Invert";
            this.checkBox_Invert.UseVisualStyleBackColor = true;
            this.checkBox_Invert.CheckedChanged += new System.EventHandler(this.checkBox_Invert_CheckedChanged);
            // 
            // tLPanel_Sleep
            // 
            resources.ApplyResources(this.tLPanel_Sleep, "tLPanel_Sleep");
            this.tLPanel_Sleep.Controls.Add(this.tableLayoutPanel3, 1, 0);
            this.tLPanel_Sleep.Controls.Add(this.label4, 0, 0);
            this.tLPanel_Sleep.Name = "tLPanel_Sleep";
            // 
            // tableLayoutPanel3
            // 
            resources.ApplyResources(this.tableLayoutPanel3, "tableLayoutPanel3");
            this.tableLayoutPanel3.Controls.Add(this.label6, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.numUpD_Sleep, 0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            // 
            // but_SaveSet
            // 
            this.but_SaveSet.BackColor = System.Drawing.Color.LightSteelBlue;
            resources.ApplyResources(this.but_SaveSet, "but_SaveSet");
            this.but_SaveSet.Name = "but_SaveSet";
            this.but_SaveSet.UseVisualStyleBackColor = false;
            this.but_SaveSet.Click += new System.EventHandler(this.but_SaveSet_Click);
            // 
            // FormIOSend
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.but_SaveSet);
            this.Controls.Add(this.tLPanel_Sleep);
            this.Controls.Add(this.checkBox_Invert);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormIOSend";
            this.Load += new System.EventHandler(this.FormIOSend_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpD_Sleep)).EndInit();
            this.tLPanel_Sleep.ResumeLayout(false);
            this.tLPanel_Sleep.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_PreSendOK;
        private System.Windows.Forms.Label label_PreSendNG;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.CheckBox checkBox_OK;
        private System.Windows.Forms.CheckBox checkBox_NG;
        private System.Windows.Forms.ComboBox comboBox_OK;
        private System.Windows.Forms.ComboBox comboBox_NG;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBox_Invert;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numUpD_Sleep;
        private System.Windows.Forms.TableLayoutPanel tLPanel_Sleep;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button but_SaveSet;
    }
}
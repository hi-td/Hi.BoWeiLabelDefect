
namespace VisionPlatform
{
    partial class FormLED
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLED));
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_openPort = new System.Windows.Forms.Button();
            this.btn_closePort = new System.Windows.Forms.Button();
            this.lbl_statu = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.cbx_portName = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbx_stopBit = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbx_parityBit = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbx_dataBit = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbx_baudRate = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel2
            // 
            resources.ApplyResources(this.tableLayoutPanel2, "tableLayoutPanel2");
            this.tableLayoutPanel2.Controls.Add(this.button1, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.btn_openPort, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.btn_closePort, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.lbl_statu, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label6, 0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_openPort
            // 
            resources.ApplyResources(this.btn_openPort, "btn_openPort");
            this.btn_openPort.Name = "btn_openPort";
            this.btn_openPort.UseVisualStyleBackColor = true;
            this.btn_openPort.Click += new System.EventHandler(this.btn_openPort_Click);
            // 
            // btn_closePort
            // 
            resources.ApplyResources(this.btn_closePort, "btn_closePort");
            this.btn_closePort.Name = "btn_closePort";
            this.btn_closePort.UseVisualStyleBackColor = true;
            this.btn_closePort.Click += new System.EventHandler(this.btn_closePort_Click);
            // 
            // lbl_statu
            // 
            resources.ApplyResources(this.lbl_statu, "lbl_statu");
            this.lbl_statu.ForeColor = System.Drawing.Color.Red;
            this.lbl_statu.Name = "lbl_statu";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbx_portName, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.cbx_stopBit, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.label5, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.cbx_parityBit, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.label3, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.tbx_dataBit, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.cbx_baudRate, 2, 1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // cbx_portName
            // 
            this.cbx_portName.BackColor = System.Drawing.Color.DarkGray;
            resources.ApplyResources(this.cbx_portName, "cbx_portName");
            this.cbx_portName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_portName.FormattingEnabled = true;
            this.cbx_portName.Name = "cbx_portName";
            this.cbx_portName.SelectedIndexChanged += new System.EventHandler(this.cbx_portName_SelectedIndexChanged);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // cbx_stopBit
            // 
            this.cbx_stopBit.BackColor = System.Drawing.Color.DarkGray;
            resources.ApplyResources(this.cbx_stopBit, "cbx_stopBit");
            this.cbx_stopBit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_stopBit.FormattingEnabled = true;
            this.cbx_stopBit.Name = "cbx_stopBit";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // cbx_parityBit
            // 
            this.cbx_parityBit.BackColor = System.Drawing.Color.DarkGray;
            resources.ApplyResources(this.cbx_parityBit, "cbx_parityBit");
            this.cbx_parityBit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_parityBit.FormattingEnabled = true;
            this.cbx_parityBit.Name = "cbx_parityBit";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // tbx_dataBit
            // 
            resources.ApplyResources(this.tbx_dataBit, "tbx_dataBit");
            this.tbx_dataBit.FormattingEnabled = true;
            this.tbx_dataBit.Name = "tbx_dataBit";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // cbx_baudRate
            // 
            resources.ApplyResources(this.cbx_baudRate, "cbx_baudRate");
            this.cbx_baudRate.FormattingEnabled = true;
            this.cbx_baudRate.Name = "cbx_baudRate";
            // 
            // tableLayoutPanel3
            // 
            resources.ApplyResources(this.tableLayoutPanel3, "tableLayoutPanel3");
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            // 
            // FormLED
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormLED";
            this.Load += new System.EventHandler(this.FormLED_Load);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox cbx_parityBit;
        private System.Windows.Forms.ComboBox cbx_stopBit;
        private System.Windows.Forms.ComboBox tbx_dataBit;
        private System.Windows.Forms.ComboBox cbx_baudRate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbx_portName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_statu;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_closePort;
        private System.Windows.Forms.Button btn_openPort;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
    }
}
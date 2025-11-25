
namespace VisionPlatform
{
    partial class FormLEDCom
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
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_openPort = new System.Windows.Forms.Button();
            this.btn_closePort = new System.Windows.Forms.Button();
            this.lbl_statu = new System.Windows.Forms.Label();
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
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.button1, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.label6, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btn_openPort, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.btn_closePort, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.lbl_statu, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(220, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(202, 156);
            this.tableLayoutPanel2.TabIndex = 47;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Location = new System.Drawing.Point(2, 119);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 35);
            this.button1.TabIndex = 45;
            this.button1.Text = "保存配置";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Margin = new System.Windows.Forms.Padding(0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 39);
            this.label6.TabIndex = 31;
            this.label6.Text = "当前串口状态：";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btn_openPort
            // 
            this.btn_openPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_openPort.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_openPort.Location = new System.Drawing.Point(2, 41);
            this.btn_openPort.Margin = new System.Windows.Forms.Padding(2);
            this.btn_openPort.Name = "btn_openPort";
            this.btn_openPort.Size = new System.Drawing.Size(116, 35);
            this.btn_openPort.TabIndex = 29;
            this.btn_openPort.Text = "更新串口配置";
            this.btn_openPort.UseVisualStyleBackColor = true;
            this.btn_openPort.Click += new System.EventHandler(this.btn_openPort_Click);
            // 
            // btn_closePort
            // 
            this.btn_closePort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_closePort.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_closePort.Location = new System.Drawing.Point(2, 80);
            this.btn_closePort.Margin = new System.Windows.Forms.Padding(2);
            this.btn_closePort.Name = "btn_closePort";
            this.btn_closePort.Size = new System.Drawing.Size(116, 35);
            this.btn_closePort.TabIndex = 30;
            this.btn_closePort.Text = "关闭串口";
            this.btn_closePort.UseVisualStyleBackColor = true;
            this.btn_closePort.Click += new System.EventHandler(this.btn_closePort_Click);
            // 
            // lbl_statu
            // 
            this.lbl_statu.AutoSize = true;
            this.lbl_statu.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbl_statu.ForeColor = System.Drawing.Color.Red;
            this.lbl_statu.Location = new System.Drawing.Point(124, 0);
            this.lbl_statu.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_statu.Name = "lbl_statu";
            this.lbl_statu.Size = new System.Drawing.Size(49, 39);
            this.lbl_statu.TabIndex = 32;
            this.lbl_statu.Text = "未打开";
            this.lbl_statu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
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
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutPanel1.Font = new System.Drawing.Font("宋体", 10F);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(217, 156);
            this.tableLayoutPanel1.TabIndex = 46;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Right;
            this.label1.Location = new System.Drawing.Point(59, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "端口：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbx_portName
            // 
            this.cbx_portName.BackColor = System.Drawing.Color.DarkGray;
            this.cbx_portName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbx_portName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_portName.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbx_portName.FormattingEnabled = true;
            this.cbx_portName.Location = new System.Drawing.Point(109, 1);
            this.cbx_portName.Margin = new System.Windows.Forms.Padding(1);
            this.cbx_portName.Name = "cbx_portName";
            this.cbx_portName.Size = new System.Drawing.Size(68, 21);
            this.cbx_portName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Right;
            this.label2.Location = new System.Drawing.Point(45, 31);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 31);
            this.label2.TabIndex = 2;
            this.label2.Text = "波特率：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbx_stopBit
            // 
            this.cbx_stopBit.BackColor = System.Drawing.Color.DarkGray;
            this.cbx_stopBit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbx_stopBit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_stopBit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbx_stopBit.FormattingEnabled = true;
            this.cbx_stopBit.Location = new System.Drawing.Point(109, 94);
            this.cbx_stopBit.Margin = new System.Windows.Forms.Padding(1);
            this.cbx_stopBit.Name = "cbx_stopBit";
            this.cbx_stopBit.Size = new System.Drawing.Size(68, 21);
            this.cbx_stopBit.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Right;
            this.label5.Location = new System.Drawing.Point(45, 93);
            this.label5.Margin = new System.Windows.Forms.Padding(0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 31);
            this.label5.TabIndex = 8;
            this.label5.Text = "停止位：";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbx_parityBit
            // 
            this.cbx_parityBit.BackColor = System.Drawing.Color.DarkGray;
            this.cbx_parityBit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbx_parityBit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_parityBit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbx_parityBit.FormattingEnabled = true;
            this.cbx_parityBit.Location = new System.Drawing.Point(109, 125);
            this.cbx_parityBit.Margin = new System.Windows.Forms.Padding(1);
            this.cbx_parityBit.Name = "cbx_parityBit";
            this.cbx_parityBit.Size = new System.Drawing.Size(68, 21);
            this.cbx_parityBit.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Right;
            this.label3.Location = new System.Drawing.Point(45, 62);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 31);
            this.label3.TabIndex = 4;
            this.label3.Text = "数据位：";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbx_dataBit
            // 
            this.tbx_dataBit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbx_dataBit.FormattingEnabled = true;
            this.tbx_dataBit.Location = new System.Drawing.Point(109, 63);
            this.tbx_dataBit.Margin = new System.Windows.Forms.Padding(1);
            this.tbx_dataBit.Name = "tbx_dataBit";
            this.tbx_dataBit.Size = new System.Drawing.Size(68, 21);
            this.tbx_dataBit.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Right;
            this.label4.Location = new System.Drawing.Point(45, 124);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 32);
            this.label4.TabIndex = 6;
            this.label4.Text = "效验位：";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbx_baudRate
            // 
            this.cbx_baudRate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbx_baudRate.FormattingEnabled = true;
            this.cbx_baudRate.Location = new System.Drawing.Point(109, 32);
            this.cbx_baudRate.Margin = new System.Windows.Forms.Padding(1);
            this.cbx_baudRate.Name = "cbx_baudRate";
            this.cbx_baudRate.Size = new System.Drawing.Size(68, 21);
            this.cbx_baudRate.TabIndex = 10;
            // 
            // FormLEDCom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 156);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Font = new System.Drawing.Font("宋体", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "FormLEDCom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "光源串口设置";
            this.Load += new System.EventHandler(this.FormLED_Load);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
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
    }
}
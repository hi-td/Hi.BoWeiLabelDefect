
namespace VisionPlatform
{
    partial class FormPLCRTU
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
            this.btn_closePort = new System.Windows.Forms.Button();
            this.lnk_clear = new System.Windows.Forms.LinkLabel();
            this.label9 = new System.Windows.Forms.Label();
            this.lbl_statu = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_openPort = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbx_parityBit = new System.Windows.Forms.ComboBox();
            this.cbx_stopBit = new System.Windows.Forms.ComboBox();
            this.tbx_dataBit = new System.Windows.Forms.ComboBox();
            this.cbx_baudRate = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbx_portName = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.btn_ReadReg = new System.Windows.Forms.Button();
            this.btn_SetSingleReg = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txt_DecAdd = new System.Windows.Forms.TextBox();
            this.txt_Address = new System.Windows.Forms.TextBox();
            this.txt_Length = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btn_Save_hou = new System.Windows.Forms.Button();
            this.btn_Save_qian = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_closePort
            // 
            this.btn_closePort.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_closePort.Location = new System.Drawing.Point(105, 234);
            this.btn_closePort.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_closePort.Name = "btn_closePort";
            this.btn_closePort.Size = new System.Drawing.Size(87, 33);
            this.btn_closePort.TabIndex = 28;
            this.btn_closePort.Text = "关闭串口";
            this.btn_closePort.UseVisualStyleBackColor = true;
            this.btn_closePort.Click += new System.EventHandler(this.btn_closePort_Click);
            // 
            // lnk_clear
            // 
            this.lnk_clear.AutoSize = true;
            this.lnk_clear.Location = new System.Drawing.Point(160, 299);
            this.lnk_clear.Name = "lnk_clear";
            this.lnk_clear.Size = new System.Drawing.Size(29, 12);
            this.lnk_clear.TabIndex = 27;
            this.lnk_clear.TabStop = true;
            this.lnk_clear.Text = "清空";
            this.lnk_clear.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnk_clear_LinkClicked);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(205, 175);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 26;
            this.label9.Text = "通讯记录";
            // 
            // lbl_statu
            // 
            this.lbl_statu.AutoSize = true;
            this.lbl_statu.ForeColor = System.Drawing.Color.Red;
            this.lbl_statu.Location = new System.Drawing.Point(35, 299);
            this.lbl_statu.Name = "lbl_statu";
            this.lbl_statu.Size = new System.Drawing.Size(41, 12);
            this.lbl_statu.TabIndex = 22;
            this.lbl_statu.Text = "未打开";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 299);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 21;
            this.label6.Text = "状态：";
            // 
            // btn_openPort
            // 
            this.btn_openPort.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_openPort.Location = new System.Drawing.Point(6, 234);
            this.btn_openPort.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_openPort.Name = "btn_openPort";
            this.btn_openPort.Size = new System.Drawing.Size(87, 33);
            this.btn_openPort.TabIndex = 20;
            this.btn_openPort.Text = "打开串口";
            this.btn_openPort.UseVisualStyleBackColor = true;
            this.btn_openPort.Click += new System.EventHandler(this.btn_openPort_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbx_parityBit);
            this.groupBox1.Controls.Add(this.cbx_stopBit);
            this.groupBox1.Controls.Add(this.tbx_dataBit);
            this.groupBox1.Controls.Add(this.cbx_baudRate);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbx_portName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(6, 12);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(186, 214);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "串口设置";
            // 
            // cbx_parityBit
            // 
            this.cbx_parityBit.BackColor = System.Drawing.Color.DarkGray;
            this.cbx_parityBit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_parityBit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbx_parityBit.FormattingEnabled = true;
            this.cbx_parityBit.Location = new System.Drawing.Point(69, 163);
            this.cbx_parityBit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbx_parityBit.Name = "cbx_parityBit";
            this.cbx_parityBit.Size = new System.Drawing.Size(99, 20);
            this.cbx_parityBit.TabIndex = 13;
            // 
            // cbx_stopBit
            // 
            this.cbx_stopBit.BackColor = System.Drawing.Color.DarkGray;
            this.cbx_stopBit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_stopBit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbx_stopBit.FormattingEnabled = true;
            this.cbx_stopBit.Location = new System.Drawing.Point(69, 131);
            this.cbx_stopBit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbx_stopBit.Name = "cbx_stopBit";
            this.cbx_stopBit.Size = new System.Drawing.Size(99, 20);
            this.cbx_stopBit.TabIndex = 12;
            // 
            // tbx_dataBit
            // 
            this.tbx_dataBit.FormattingEnabled = true;
            this.tbx_dataBit.Location = new System.Drawing.Point(69, 99);
            this.tbx_dataBit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbx_dataBit.Name = "tbx_dataBit";
            this.tbx_dataBit.Size = new System.Drawing.Size(99, 20);
            this.tbx_dataBit.TabIndex = 11;
            // 
            // cbx_baudRate
            // 
            this.cbx_baudRate.FormattingEnabled = true;
            this.cbx_baudRate.Location = new System.Drawing.Point(69, 67);
            this.cbx_baudRate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbx_baudRate.Name = "cbx_baudRate";
            this.cbx_baudRate.Size = new System.Drawing.Size(99, 20);
            this.cbx_baudRate.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 134);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "停止位：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 166);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "效验位：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "数据位：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "波特率：";
            // 
            // cbx_portName
            // 
            this.cbx_portName.BackColor = System.Drawing.Color.DarkGray;
            this.cbx_portName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_portName.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbx_portName.FormattingEnabled = true;
            this.cbx_portName.Location = new System.Drawing.Point(69, 35);
            this.cbx_portName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbx_portName.Name = "cbx_portName";
            this.cbx_portName.Size = new System.Drawing.Size(99, 20);
            this.cbx_portName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "端口：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(280, 47);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(0, 12);
            this.label10.TabIndex = 33;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(363, 35);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 30;
            this.label8.Text = "数据长度";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(284, 35);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 31;
            this.label11.Text = "起始地址";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(205, 35);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 32;
            this.label12.Text = "从站地址";
            // 
            // btn_ReadReg
            // 
            this.btn_ReadReg.Location = new System.Drawing.Point(435, 46);
            this.btn_ReadReg.Margin = new System.Windows.Forms.Padding(2);
            this.btn_ReadReg.Name = "btn_ReadReg";
            this.btn_ReadReg.Size = new System.Drawing.Size(76, 38);
            this.btn_ReadReg.TabIndex = 34;
            this.btn_ReadReg.Text = "读寄存器";
            this.btn_ReadReg.UseVisualStyleBackColor = true;
            this.btn_ReadReg.Click += new System.EventHandler(this.btn_ReadReg_Click);
            // 
            // btn_SetSingleReg
            // 
            this.btn_SetSingleReg.Location = new System.Drawing.Point(435, 129);
            this.btn_SetSingleReg.Margin = new System.Windows.Forms.Padding(2);
            this.btn_SetSingleReg.Name = "btn_SetSingleReg";
            this.btn_SetSingleReg.Size = new System.Drawing.Size(76, 38);
            this.btn_SetSingleReg.TabIndex = 35;
            this.btn_SetSingleReg.Text = "写入寄存器";
            this.btn_SetSingleReg.UseVisualStyleBackColor = true;
            this.btn_SetSingleReg.Click += new System.EventHandler(this.btn_SetSingleReg_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(281, 119);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 36;
            this.label7.Text = "写入地址";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(361, 119);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 12);
            this.label13.TabIndex = 37;
            this.label13.Text = "写入数据";
            // 
            // txt_DecAdd
            // 
            this.txt_DecAdd.Location = new System.Drawing.Point(207, 63);
            this.txt_DecAdd.Margin = new System.Windows.Forms.Padding(2);
            this.txt_DecAdd.Name = "txt_DecAdd";
            this.txt_DecAdd.Size = new System.Drawing.Size(49, 21);
            this.txt_DecAdd.TabIndex = 38;
            this.txt_DecAdd.Text = "1";
            // 
            // txt_Address
            // 
            this.txt_Address.Location = new System.Drawing.Point(285, 63);
            this.txt_Address.Margin = new System.Windows.Forms.Padding(2);
            this.txt_Address.Name = "txt_Address";
            this.txt_Address.Size = new System.Drawing.Size(49, 21);
            this.txt_Address.TabIndex = 39;
            this.txt_Address.Text = "1000";
            // 
            // txt_Length
            // 
            this.txt_Length.Location = new System.Drawing.Point(363, 63);
            this.txt_Length.Margin = new System.Windows.Forms.Padding(2);
            this.txt_Length.Name = "txt_Length";
            this.txt_Length.Size = new System.Drawing.Size(53, 21);
            this.txt_Length.TabIndex = 40;
            this.txt_Length.Text = "1";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(282, 146);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(49, 21);
            this.textBox1.TabIndex = 41;
            this.textBox1.Text = "1000";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(363, 146);
            this.textBox2.Margin = new System.Windows.Forms.Padding(2);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(53, 21);
            this.textBox2.TabIndex = 42;
            this.textBox2.Text = "3";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(207, 189);
            this.listBox1.Margin = new System.Windows.Forms.Padding(2);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(304, 124);
            this.listBox1.TabIndex = 43;
            // 
            // btn_Save_hou
            // 
            this.btn_Save_hou.Location = new System.Drawing.Point(391, 331);
            this.btn_Save_hou.Name = "btn_Save_hou";
            this.btn_Save_hou.Size = new System.Drawing.Size(120, 36);
            this.btn_Save_hou.TabIndex = 44;
            this.btn_Save_hou.Text = "后端保存配置";
            this.btn_Save_hou.UseVisualStyleBackColor = true;
            this.btn_Save_hou.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // btn_Save_qian
            // 
            this.btn_Save_qian.Location = new System.Drawing.Point(252, 331);
            this.btn_Save_qian.Name = "btn_Save_qian";
            this.btn_Save_qian.Size = new System.Drawing.Size(133, 36);
            this.btn_Save_qian.TabIndex = 44;
            this.btn_Save_qian.Text = "前端保存配置";
            this.btn_Save_qian.UseVisualStyleBackColor = true;
            this.btn_Save_qian.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // FormPLCRTU
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 367);
            this.Controls.Add(this.btn_Save_qian);
            this.Controls.Add(this.btn_Save_hou);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.txt_Length);
            this.Controls.Add(this.txt_Address);
            this.Controls.Add(this.txt_DecAdd);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btn_SetSingleReg);
            this.Controls.Add(this.btn_ReadReg);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.btn_closePort);
            this.Controls.Add(this.lnk_clear);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lbl_statu);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btn_openPort);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormPLCRTU";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PLC通讯测试";
            this.Load += new System.EventHandler(this.FormPLCRTU_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_closePort;
        private System.Windows.Forms.LinkLabel lnk_clear;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lbl_statu;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_openPort;
        private System.Windows.Forms.GroupBox groupBox1;
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
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btn_ReadReg;
        private System.Windows.Forms.Button btn_SetSingleReg;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txt_DecAdd;
        private System.Windows.Forms.TextBox txt_Address;
        private System.Windows.Forms.TextBox txt_Length;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btn_Save_hou;
        private System.Windows.Forms.Button btn_Save_qian;
    }
}
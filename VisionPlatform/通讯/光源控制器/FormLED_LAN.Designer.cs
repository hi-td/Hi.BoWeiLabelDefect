namespace VisionPlatform.通讯.光源控制器
{
    partial class FormLED_LAN
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
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.textBox_IP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_Port = new System.Windows.Forms.TextBox();
            this.cbx_ipList = new System.Windows.Forms.ComboBox();
            this.button_add = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_openPort = new System.Windows.Forms.Button();
            this.btn_closePort = new System.Windows.Forms.Button();
            this.lbl_statu = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.AutoScroll = true;
            this.flowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(539, 78);
            this.flowLayoutPanel.TabIndex = 50;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 101F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 206F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.textBox_IP, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox_Port, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbx_ipList, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.button_add, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutPanel1.Font = new System.Drawing.Font("宋体", 10F);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 78);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(307, 180);
            this.tableLayoutPanel1.TabIndex = 51;
            // 
            // textBox_IP
            // 
            this.textBox_IP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_IP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_IP.Location = new System.Drawing.Point(102, 41);
            this.textBox_IP.Margin = new System.Windows.Forms.Padding(1, 5, 1, 5);
            this.textBox_IP.Name = "textBox_IP";
            this.textBox_IP.Size = new System.Drawing.Size(204, 27);
            this.textBox_IP.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Right;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(20, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "端口号：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Right;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(19, 36);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 36);
            this.label2.TabIndex = 2;
            this.label2.Text = "IP地址：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox_Port
            // 
            this.textBox_Port.BackColor = System.Drawing.SystemColors.Window;
            this.textBox_Port.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_Port.Location = new System.Drawing.Point(102, 5);
            this.textBox_Port.Margin = new System.Windows.Forms.Padding(1, 5, 1, 5);
            this.textBox_Port.Name = "textBox_Port";
            this.textBox_Port.Size = new System.Drawing.Size(103, 27);
            this.textBox_Port.TabIndex = 3;
            // 
            // cbx_ipList
            // 
            this.cbx_ipList.BackColor = System.Drawing.Color.DarkGray;
            this.cbx_ipList.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbx_ipList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_ipList.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbx_ipList.FormattingEnabled = true;
            this.cbx_ipList.Location = new System.Drawing.Point(102, 77);
            this.cbx_ipList.Margin = new System.Windows.Forms.Padding(1, 5, 1, 5);
            this.cbx_ipList.Name = "cbx_ipList";
            this.cbx_ipList.Size = new System.Drawing.Size(204, 25);
            this.cbx_ipList.TabIndex = 5;
            this.cbx_ipList.SelectedIndexChanged += new System.EventHandler(this.cbx_ipList_SelectedIndexChanged);
            // 
            // button_add
            // 
            this.button_add.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_add.Location = new System.Drawing.Point(1, 73);
            this.button_add.Margin = new System.Windows.Forms.Padding(1);
            this.button_add.Name = "button_add";
            this.button_add.Size = new System.Drawing.Size(99, 34);
            this.button_add.TabIndex = 6;
            this.button_add.Text = "添加";
            this.button_add.UseVisualStyleBackColor = true;
            this.button_add.Click += new System.EventHandler(this.button_add_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 92F));
            this.tableLayoutPanel2.Controls.Add(this.button1, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.btn_openPort, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.btn_closePort, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.lbl_statu, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label6, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Font = new System.Drawing.Font("宋体", 10F);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(307, 78);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(232, 180);
            this.tableLayoutPanel2.TabIndex = 52;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button1.Location = new System.Drawing.Point(1, 136);
            this.button1.Margin = new System.Windows.Forms.Padding(1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(138, 43);
            this.button1.TabIndex = 45;
            this.button1.Text = "保存配置";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_openPort
            // 
            this.btn_openPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_openPort.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_openPort.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_openPort.Location = new System.Drawing.Point(1, 46);
            this.btn_openPort.Margin = new System.Windows.Forms.Padding(1);
            this.btn_openPort.Name = "btn_openPort";
            this.btn_openPort.Size = new System.Drawing.Size(138, 43);
            this.btn_openPort.TabIndex = 29;
            this.btn_openPort.Text = "更新网口配置";
            this.btn_openPort.UseVisualStyleBackColor = true;
            this.btn_openPort.Click += new System.EventHandler(this.btn_openPort_Click);
            // 
            // btn_closePort
            // 
            this.btn_closePort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_closePort.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_closePort.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_closePort.Location = new System.Drawing.Point(1, 91);
            this.btn_closePort.Margin = new System.Windows.Forms.Padding(1);
            this.btn_closePort.Name = "btn_closePort";
            this.btn_closePort.Size = new System.Drawing.Size(138, 43);
            this.btn_closePort.TabIndex = 30;
            this.btn_closePort.Text = "关闭网口";
            this.btn_closePort.UseVisualStyleBackColor = true;
            this.btn_closePort.Click += new System.EventHandler(this.btn_closePort_Click);
            // 
            // lbl_statu
            // 
            this.lbl_statu.AutoSize = true;
            this.lbl_statu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_statu.ForeColor = System.Drawing.Color.Red;
            this.lbl_statu.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbl_statu.Location = new System.Drawing.Point(140, 0);
            this.lbl_statu.Margin = new System.Windows.Forms.Padding(0);
            this.lbl_statu.Name = "lbl_statu";
            this.lbl_statu.Size = new System.Drawing.Size(92, 45);
            this.lbl_statu.TabIndex = 32;
            this.lbl_statu.Text = "未打开";
            this.lbl_statu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Margin = new System.Windows.Forms.Padding(0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(140, 45);
            this.label6.TabIndex = 31;
            this.label6.Text = "当前网口状态：";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FormLED_LAN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 258);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.flowLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormLED_LAN";
            this.Text = "光源控制器网口设置";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_openPort;
        private System.Windows.Forms.Button btn_closePort;
        private System.Windows.Forms.Label lbl_statu;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_IP;
        private System.Windows.Forms.TextBox textBox_Port;
        private System.Windows.Forms.ComboBox cbx_ipList;
        private System.Windows.Forms.Button button_add;
    }
}
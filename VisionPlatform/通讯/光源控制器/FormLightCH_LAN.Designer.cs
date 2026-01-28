namespace VisionPlatform.通讯.光源控制器
{
    partial class FormLightCH_LAN
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmbBox_IP = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ctrlLEDSet_LAN6 = new VisionPlatform.通讯.光源控制器.CtrlLEDSet_LAN();
            this.ctrlLEDSet_LAN5 = new VisionPlatform.通讯.光源控制器.CtrlLEDSet_LAN();
            this.ctrlLEDSet_LAN4 = new VisionPlatform.通讯.光源控制器.CtrlLEDSet_LAN();
            this.ctrlLEDSet_LAN3 = new VisionPlatform.通讯.光源控制器.CtrlLEDSet_LAN();
            this.ctrlLEDSet_LAN2 = new VisionPlatform.通讯.光源控制器.CtrlLEDSet_LAN();
            this.ctrlLEDSet_LAN1 = new VisionPlatform.通讯.光源控制器.CtrlLEDSet_LAN();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.cmbBox_IP, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(270, 23);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "网口IP";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbBox_IP
            // 
            this.cmbBox_IP.FormattingEnabled = true;
            this.cmbBox_IP.Location = new System.Drawing.Point(55, 1);
            this.cmbBox_IP.Margin = new System.Windows.Forms.Padding(1);
            this.cmbBox_IP.Name = "cmbBox_IP";
            this.cmbBox_IP.Size = new System.Drawing.Size(162, 20);
            this.cmbBox_IP.TabIndex = 1;
            this.cmbBox_IP.SelectedIndexChanged += new System.EventHandler(this.cmbBox_PortName_SelectedIndexChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.ctrlLEDSet_LAN6, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.ctrlLEDSet_LAN5, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.ctrlLEDSet_LAN4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.ctrlLEDSet_LAN3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.ctrlLEDSet_LAN2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.ctrlLEDSet_LAN1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Font = new System.Drawing.Font("宋体", 10F);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 23);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(270, 159);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // ctrlLEDSet_LAN6
            // 
            this.ctrlLEDSet_LAN6.Dock = System.Windows.Forms.DockStyle.Top;
            this.ctrlLEDSet_LAN6.Location = new System.Drawing.Point(1, 131);
            this.ctrlLEDSet_LAN6.Margin = new System.Windows.Forms.Padding(1);
            this.ctrlLEDSet_LAN6.Name = "ctrlLEDSet_LAN6";
            this.ctrlLEDSet_LAN6.Size = new System.Drawing.Size(268, 25);
            this.ctrlLEDSet_LAN6.TabIndex = 11;
            // 
            // ctrlLEDSet_LAN5
            // 
            this.ctrlLEDSet_LAN5.Dock = System.Windows.Forms.DockStyle.Top;
            this.ctrlLEDSet_LAN5.Location = new System.Drawing.Point(1, 105);
            this.ctrlLEDSet_LAN5.Margin = new System.Windows.Forms.Padding(1);
            this.ctrlLEDSet_LAN5.Name = "ctrlLEDSet_LAN5";
            this.ctrlLEDSet_LAN5.Size = new System.Drawing.Size(268, 24);
            this.ctrlLEDSet_LAN5.TabIndex = 10;
            // 
            // ctrlLEDSet_LAN4
            // 
            this.ctrlLEDSet_LAN4.Dock = System.Windows.Forms.DockStyle.Top;
            this.ctrlLEDSet_LAN4.Location = new System.Drawing.Point(1, 79);
            this.ctrlLEDSet_LAN4.Margin = new System.Windows.Forms.Padding(1);
            this.ctrlLEDSet_LAN4.Name = "ctrlLEDSet_LAN4";
            this.ctrlLEDSet_LAN4.Size = new System.Drawing.Size(268, 24);
            this.ctrlLEDSet_LAN4.TabIndex = 9;
            // 
            // ctrlLEDSet_LAN3
            // 
            this.ctrlLEDSet_LAN3.Dock = System.Windows.Forms.DockStyle.Top;
            this.ctrlLEDSet_LAN3.Location = new System.Drawing.Point(1, 53);
            this.ctrlLEDSet_LAN3.Margin = new System.Windows.Forms.Padding(1);
            this.ctrlLEDSet_LAN3.Name = "ctrlLEDSet_LAN3";
            this.ctrlLEDSet_LAN3.Size = new System.Drawing.Size(268, 24);
            this.ctrlLEDSet_LAN3.TabIndex = 8;
            // 
            // ctrlLEDSet_LAN2
            // 
            this.ctrlLEDSet_LAN2.Dock = System.Windows.Forms.DockStyle.Top;
            this.ctrlLEDSet_LAN2.Location = new System.Drawing.Point(1, 27);
            this.ctrlLEDSet_LAN2.Margin = new System.Windows.Forms.Padding(1);
            this.ctrlLEDSet_LAN2.Name = "ctrlLEDSet_LAN2";
            this.ctrlLEDSet_LAN2.Size = new System.Drawing.Size(268, 24);
            this.ctrlLEDSet_LAN2.TabIndex = 7;
            // 
            // ctrlLEDSet_LAN1
            // 
            this.ctrlLEDSet_LAN1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ctrlLEDSet_LAN1.Location = new System.Drawing.Point(1, 1);
            this.ctrlLEDSet_LAN1.Margin = new System.Windows.Forms.Padding(1);
            this.ctrlLEDSet_LAN1.Name = "ctrlLEDSet_LAN1";
            this.ctrlLEDSet_LAN1.Size = new System.Drawing.Size(268, 23);
            this.ctrlLEDSet_LAN1.TabIndex = 6;
            // 
            // FormLightCH_LAN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(270, 182);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.tableLayoutPanel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormLightCH_LAN";
            this.Text = "FormLightCH_LAN";
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbBox_IP;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private CtrlLEDSet_LAN ctrlLEDSet_LAN6;
        private CtrlLEDSet_LAN ctrlLEDSet_LAN5;
        private CtrlLEDSet_LAN ctrlLEDSet_LAN4;
        private CtrlLEDSet_LAN ctrlLEDSet_LAN3;
        private CtrlLEDSet_LAN ctrlLEDSet_LAN2;
        private CtrlLEDSet_LAN ctrlLEDSet_LAN1;
    }
}
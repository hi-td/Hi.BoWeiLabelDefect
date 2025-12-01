
namespace VisionPlatform
{
    partial class FormCamParamSet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCamParamSet));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label_expourse = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.trackBar_Exposure = new System.Windows.Forms.TrackBar();
            this.trackBar_Gain = new System.Windows.Forms.TrackBar();
            this.label_gain = new System.Windows.Forms.Label();
            this.textBox_expourse = new System.Windows.Forms.TextBox();
            this.textBox_gain = new System.Windows.Forms.TextBox();
            this.tabCtrl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox_Light = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Exposure)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Gain)).BeginInit();
            this.tabCtrl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label_expourse, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.trackBar_Exposure, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.trackBar_Gain, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.label_gain, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox_expourse, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBox_gain, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Font = new System.Drawing.Font("宋体", 10F);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 20);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(440, 50);
            this.tableLayoutPanel1.TabIndex = 9;
            // 
            // label_expourse
            // 
            this.label_expourse.AutoSize = true;
            this.label_expourse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_expourse.Location = new System.Drawing.Point(133, 1);
            this.label_expourse.Margin = new System.Windows.Forms.Padding(0);
            this.label_expourse.Name = "label_expourse";
            this.label_expourse.Size = new System.Drawing.Size(65, 23);
            this.label_expourse.TabIndex = 11;
            this.label_expourse.Text = "0";
            this.label_expourse.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(1, 1);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "曝光时间";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(1, 25);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 24);
            this.label3.TabIndex = 1;
            this.label3.Text = "增益";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // trackBar_Exposure
            // 
            this.trackBar_Exposure.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trackBar_Exposure.Location = new System.Drawing.Point(202, 4);
            this.trackBar_Exposure.Maximum = 99999;
            this.trackBar_Exposure.Name = "trackBar_Exposure";
            this.trackBar_Exposure.Size = new System.Drawing.Size(234, 17);
            this.trackBar_Exposure.TabIndex = 3;
            this.trackBar_Exposure.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar_Exposure.Scroll += new System.EventHandler(this.trackBar_Exposure_Scroll);
            // 
            // trackBar_Gain
            // 
            this.trackBar_Gain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trackBar_Gain.Location = new System.Drawing.Point(202, 28);
            this.trackBar_Gain.Maximum = 20;
            this.trackBar_Gain.Name = "trackBar_Gain";
            this.trackBar_Gain.Size = new System.Drawing.Size(234, 18);
            this.trackBar_Gain.TabIndex = 4;
            this.trackBar_Gain.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar_Gain.Scroll += new System.EventHandler(this.trackBar_Gain_Scroll);
            // 
            // label_gain
            // 
            this.label_gain.AutoSize = true;
            this.label_gain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_gain.Location = new System.Drawing.Point(133, 25);
            this.label_gain.Margin = new System.Windows.Forms.Padding(0);
            this.label_gain.Name = "label_gain";
            this.label_gain.Size = new System.Drawing.Size(65, 24);
            this.label_gain.TabIndex = 12;
            this.label_gain.Text = "0";
            this.label_gain.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox_expourse
            // 
            this.textBox_expourse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_expourse.Location = new System.Drawing.Point(67, 1);
            this.textBox_expourse.Margin = new System.Windows.Forms.Padding(0);
            this.textBox_expourse.Name = "textBox_expourse";
            this.textBox_expourse.Size = new System.Drawing.Size(65, 23);
            this.textBox_expourse.TabIndex = 14;
            this.textBox_expourse.TextChanged += new System.EventHandler(this.textBox_expourse_TextChanged);
            // 
            // textBox_gain
            // 
            this.textBox_gain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_gain.Location = new System.Drawing.Point(67, 25);
            this.textBox_gain.Margin = new System.Windows.Forms.Padding(0);
            this.textBox_gain.Name = "textBox_gain";
            this.textBox_gain.Size = new System.Drawing.Size(65, 23);
            this.textBox_gain.TabIndex = 15;
            this.textBox_gain.TextChanged += new System.EventHandler(this.textBox_gain_TextChanged);
            // 
            // tabCtrl
            // 
            this.tabCtrl.Controls.Add(this.tabPage1);
            this.tabCtrl.Controls.Add(this.tabPage2);
            this.tabCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabCtrl.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabCtrl.Location = new System.Drawing.Point(0, 0);
            this.tabCtrl.Margin = new System.Windows.Forms.Padding(0);
            this.tabCtrl.Name = "tabCtrl";
            this.tabCtrl.SelectedIndex = 0;
            this.tabCtrl.Size = new System.Drawing.Size(448, 325);
            this.tabCtrl.TabIndex = 12;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tabPage1.Controls.Add(this.groupBox_Light);
            this.tabPage1.Controls.Add(this.tableLayoutPanel1);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold);
            this.tabPage1.Location = new System.Drawing.Point(4, 28);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(440, 293);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "亮度调节";
            // 
            // groupBox_Light
            // 
            this.groupBox_Light.BackColor = System.Drawing.Color.Transparent;
            this.groupBox_Light.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_Light.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold);
            this.groupBox_Light.Location = new System.Drawing.Point(0, 70);
            this.groupBox_Light.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox_Light.Name = "groupBox_Light";
            this.groupBox_Light.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox_Light.Size = new System.Drawing.Size(440, 223);
            this.groupBox_Light.TabIndex = 11;
            this.groupBox_Light.TabStop = false;
            this.groupBox_Light.Text = "光源";
            this.groupBox_Light.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(3);
            this.label1.Size = new System.Drawing.Size(43, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "相机";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Location = new System.Drawing.Point(4, 28);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(440, 293);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "饱和度调节";
            // 
            // FormCamParamSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(448, 325);
            this.Controls.Add(this.tabCtrl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormCamParamSet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "画质调节";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormCamParamSet_FormClosing);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Exposure)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Gain)).EndInit();
            this.tabCtrl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label_expourse;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar trackBar_Exposure;
        private System.Windows.Forms.TrackBar trackBar_Gain;
        private System.Windows.Forms.Label label_gain;
        private System.Windows.Forms.TextBox textBox_expourse;
        private System.Windows.Forms.TextBox textBox_gain;
        private System.Windows.Forms.TabControl tabCtrl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox_Light;
    }
}
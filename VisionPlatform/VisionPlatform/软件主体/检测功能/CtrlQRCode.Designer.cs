using System.Windows.Forms;

namespace VisionPlatform
{
    partial class CtrlQRCode
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
        private Label label1;
        private ComboBox cb_CodeType;
        private Button Btn_Test;
        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.Btn_Test = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cb_CodeType = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel18 = new System.Windows.Forms.TableLayoutPanel();
            this.but_SetROI = new System.Windows.Forms.Button();
            this.but_ShowROI = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.but_Save = new System.Windows.Forms.Button();
            this.but_Create = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label_OrgCode = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label_Code = new System.Windows.Forms.Label();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.num_COdeLength = new System.Windows.Forms.NumericUpDown();
            this.num_COdeCaptureLength = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel18.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_COdeLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_COdeCaptureLength)).BeginInit();
            this.SuspendLayout();
            // 
            // Btn_Test
            // 
            this.Btn_Test.BackColor = System.Drawing.Color.LightSteelBlue;
            this.Btn_Test.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_Test.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Test.Font = new System.Drawing.Font("宋体", 10F);
            this.Btn_Test.Location = new System.Drawing.Point(1, 35);
            this.Btn_Test.Margin = new System.Windows.Forms.Padding(1);
            this.Btn_Test.Name = "Btn_Test";
            this.Btn_Test.Size = new System.Drawing.Size(83, 32);
            this.Btn_Test.TabIndex = 1;
            this.Btn_Test.Text = "测试";
            this.Btn_Test.UseVisualStyleBackColor = false;
            this.Btn_Test.Click += new System.EventHandler(this.Test_Btn_Click);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("宋体", 10F);
            this.label1.Location = new System.Drawing.Point(1, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "二维码类型";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cb_CodeType
            // 
            this.cb_CodeType.Dock = System.Windows.Forms.DockStyle.Left;
            this.cb_CodeType.Font = new System.Drawing.Font("宋体", 10F);
            this.cb_CodeType.FormattingEnabled = true;
            this.cb_CodeType.Items.AddRange(new object[] {
            "QR Code",
            "Data Matrix ECC 200",
            "Micro QR Code",
            "PDF417",
            "Aztec Code",
            "GS1 DataMatrix",
            "GS1 QR Code",
            "GS1 Aztec Code"});
            this.cb_CodeType.Location = new System.Drawing.Point(0, 0);
            this.cb_CodeType.Margin = new System.Windows.Forms.Padding(2);
            this.cb_CodeType.Name = "cb_CodeType";
            this.cb_CodeType.Size = new System.Drawing.Size(185, 21);
            this.cb_CodeType.TabIndex = 1;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel3.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel18, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel1, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.panel1, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.label_OrgCode, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel2, 1, 3);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 4;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(399, 184);
            this.tableLayoutPanel3.TabIndex = 26;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("宋体", 10F);
            this.label2.Location = new System.Drawing.Point(1, 54);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 25);
            this.label2.TabIndex = 22;
            this.label2.Text = "原码内容";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel18
            // 
            this.tableLayoutPanel18.ColumnCount = 3;
            this.tableLayoutPanel18.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 93F));
            this.tableLayoutPanel18.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 93F));
            this.tableLayoutPanel18.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel18.Controls.Add(this.but_SetROI, 0, 0);
            this.tableLayoutPanel18.Controls.Add(this.but_ShowROI, 1, 0);
            this.tableLayoutPanel18.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel18.Location = new System.Drawing.Point(87, 1);
            this.tableLayoutPanel18.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel18.Name = "tableLayoutPanel18";
            this.tableLayoutPanel18.RowCount = 1;
            this.tableLayoutPanel18.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel18.Size = new System.Drawing.Size(311, 28);
            this.tableLayoutPanel18.TabIndex = 19;
            // 
            // but_SetROI
            // 
            this.but_SetROI.BackColor = System.Drawing.Color.LightSteelBlue;
            this.but_SetROI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.but_SetROI.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.but_SetROI.Location = new System.Drawing.Point(1, 1);
            this.but_SetROI.Margin = new System.Windows.Forms.Padding(1);
            this.but_SetROI.Name = "but_SetROI";
            this.but_SetROI.Size = new System.Drawing.Size(91, 26);
            this.but_SetROI.TabIndex = 7;
            this.but_SetROI.Text = "设定";
            this.but_SetROI.UseVisualStyleBackColor = false;
            this.but_SetROI.Click += new System.EventHandler(this.but_SetROI_Click);
            // 
            // but_ShowROI
            // 
            this.but_ShowROI.BackColor = System.Drawing.Color.LightSteelBlue;
            this.but_ShowROI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.but_ShowROI.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.but_ShowROI.Location = new System.Drawing.Point(94, 1);
            this.but_ShowROI.Margin = new System.Windows.Forms.Padding(1);
            this.but_ShowROI.Name = "but_ShowROI";
            this.but_ShowROI.Size = new System.Drawing.Size(91, 26);
            this.but_ShowROI.TabIndex = 2;
            this.but_ShowROI.Text = "显示";
            this.but_ShowROI.UseVisualStyleBackColor = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.but_Save, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.but_Create, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.Btn_Test, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(1, 80);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(85, 103);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // but_Save
            // 
            this.but_Save.BackColor = System.Drawing.Color.LightSteelBlue;
            this.but_Save.Dock = System.Windows.Forms.DockStyle.Fill;
            this.but_Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.but_Save.Font = new System.Drawing.Font("宋体", 10F);
            this.but_Save.Location = new System.Drawing.Point(1, 69);
            this.but_Save.Margin = new System.Windows.Forms.Padding(1);
            this.but_Save.Name = "but_Save";
            this.but_Save.Size = new System.Drawing.Size(83, 33);
            this.but_Save.TabIndex = 9;
            this.but_Save.Text = "保存信息";
            this.but_Save.UseVisualStyleBackColor = false;
            this.but_Save.Click += new System.EventHandler(this.but_Save_Click);
            // 
            // but_Create
            // 
            this.but_Create.BackColor = System.Drawing.Color.LightSteelBlue;
            this.but_Create.Dock = System.Windows.Forms.DockStyle.Fill;
            this.but_Create.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.but_Create.Location = new System.Drawing.Point(1, 1);
            this.but_Create.Margin = new System.Windows.Forms.Padding(1);
            this.but_Create.Name = "but_Create";
            this.but_Create.Size = new System.Drawing.Size(83, 32);
            this.but_Create.TabIndex = 8;
            this.but_Create.Text = "创建模型";
            this.but_Create.UseVisualStyleBackColor = false;
            this.but_Create.Click += new System.EventHandler(this.but_Create_Click);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(1, 1);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 28);
            this.label3.TabIndex = 18;
            this.label3.Text = "识别区域";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cb_CodeType);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(87, 30);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(311, 23);
            this.panel1.TabIndex = 20;
            // 
            // label_OrgCode
            // 
            this.label_OrgCode.AutoSize = true;
            this.label_OrgCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_OrgCode.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_OrgCode.Location = new System.Drawing.Point(90, 54);
            this.label_OrgCode.Name = "label_OrgCode";
            this.label_OrgCode.Size = new System.Drawing.Size(305, 25);
            this.label_OrgCode.TabIndex = 23;
            this.label_OrgCode.Text = "原码内容";
            this.label_OrgCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.label_Code, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(87, 80);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(311, 103);
            this.tableLayoutPanel2.TabIndex = 24;
            // 
            // label_Code
            // 
            this.label_Code.AutoSize = true;
            this.label_Code.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Code.Location = new System.Drawing.Point(0, 58);
            this.label_Code.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.label_Code.Name = "label_Code";
            this.label_Code.Size = new System.Drawing.Size(311, 42);
            this.label_Code.TabIndex = 21;
            this.label_Code.Text = "二维码内容";
            this.label_Code.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel4.ColumnCount = 3;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 67F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 63F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.label5, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.num_COdeLength, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.num_COdeCaptureLength, 1, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(1, 1);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(1);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(309, 53);
            this.tableLayoutPanel4.TabIndex = 22;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(1, 1);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 25);
            this.label4.TabIndex = 0;
            this.label4.Text = "码长度";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(1, 27);
            this.label5.Margin = new System.Windows.Forms.Padding(0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 25);
            this.label5.TabIndex = 0;
            this.label5.Text = "对比长度";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // num_COdeLength
            // 
            this.num_COdeLength.Dock = System.Windows.Forms.DockStyle.Fill;
            this.num_COdeLength.Location = new System.Drawing.Point(70, 2);
            this.num_COdeLength.Margin = new System.Windows.Forms.Padding(1);
            this.num_COdeLength.Name = "num_COdeLength";
            this.num_COdeLength.Size = new System.Drawing.Size(61, 23);
            this.num_COdeLength.TabIndex = 1;
            // 
            // num_COdeCaptureLength
            // 
            this.num_COdeCaptureLength.Dock = System.Windows.Forms.DockStyle.Fill;
            this.num_COdeCaptureLength.Location = new System.Drawing.Point(70, 28);
            this.num_COdeCaptureLength.Margin = new System.Windows.Forms.Padding(1);
            this.num_COdeCaptureLength.Name = "num_COdeCaptureLength";
            this.num_COdeCaptureLength.Size = new System.Drawing.Size(61, 23);
            this.num_COdeCaptureLength.TabIndex = 2;
            // 
            // CtrlQRCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.Controls.Add(this.tableLayoutPanel3);
            this.Font = new System.Drawing.Font("宋体", 10F);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "CtrlQRCode";
            this.Size = new System.Drawing.Size(399, 478);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel18.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.num_COdeLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_COdeCaptureLength)).EndInit();
            this.ResumeLayout(false);

        }


        #endregion

        private TableLayoutPanel tableLayoutPanel3;
        private TableLayoutPanel tableLayoutPanel18;
        private Button but_SetROI;
        private Button but_ShowROI;
        private Label label3;
        private Button but_Create;
        private Panel panel1;
        private TableLayoutPanel tableLayoutPanel1;
        private Button but_Save;
        private Label label_Code;
        private Label label2;
        private Label label_OrgCode;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel4;
        private Label label4;
        private Label label5;
        private NumericUpDown num_COdeLength;
        private NumericUpDown num_COdeCaptureLength;
    }
}

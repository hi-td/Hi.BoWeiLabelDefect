namespace VisionPlatform
{
    partial class CtrlPNCode
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel18 = new System.Windows.Forms.TableLayoutPanel();
            this.but_SetROI = new System.Windows.Forms.Button();
            this.but_ShowROI = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.but_Test = new System.Windows.Forms.Button();
            this.but_SaveParam = new System.Windows.Forms.Button();
            this.label_Code = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label_OrgCode = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel18.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 84F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel18, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(384, 91);
            this.tableLayoutPanel1.TabIndex = 24;
            // 
            // tableLayoutPanel18
            // 
            this.tableLayoutPanel18.ColumnCount = 3;
            this.tableLayoutPanel18.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 89F));
            this.tableLayoutPanel18.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 89F));
            this.tableLayoutPanel18.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel18.Controls.Add(this.but_SetROI, 0, 0);
            this.tableLayoutPanel18.Controls.Add(this.but_ShowROI, 1, 0);
            this.tableLayoutPanel18.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel18.Location = new System.Drawing.Point(86, 1);
            this.tableLayoutPanel18.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel18.Name = "tableLayoutPanel18";
            this.tableLayoutPanel18.RowCount = 1;
            this.tableLayoutPanel18.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel18.Size = new System.Drawing.Size(297, 29);
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
            this.but_SetROI.Size = new System.Drawing.Size(87, 27);
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
            this.but_ShowROI.Location = new System.Drawing.Point(90, 1);
            this.but_ShowROI.Margin = new System.Windows.Forms.Padding(1);
            this.but_ShowROI.Name = "but_ShowROI";
            this.but_ShowROI.Size = new System.Drawing.Size(87, 27);
            this.but_ShowROI.TabIndex = 2;
            this.but_ShowROI.Text = "显示";
            this.but_ShowROI.UseVisualStyleBackColor = false;
            this.but_ShowROI.Click += new System.EventHandler(this.but_ShowROI_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(1, 1);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 29);
            this.label1.TabIndex = 18;
            this.label1.Text = "检测区域";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoScroll = true;
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel2.Controls.Add(this.label_OrgCode, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.but_Test, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(86, 31);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(297, 29);
            this.tableLayoutPanel2.TabIndex = 26;
            // 
            // but_Test
            // 
            this.but_Test.BackColor = System.Drawing.Color.LightSteelBlue;
            this.but_Test.Dock = System.Windows.Forms.DockStyle.Fill;
            this.but_Test.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.but_Test.Font = new System.Drawing.Font("宋体", 10F);
            this.but_Test.Location = new System.Drawing.Point(218, 1);
            this.but_Test.Margin = new System.Windows.Forms.Padding(1);
            this.but_Test.Name = "but_Test";
            this.but_Test.Size = new System.Drawing.Size(78, 27);
            this.but_Test.TabIndex = 0;
            this.but_Test.Text = "测试";
            this.but_Test.UseVisualStyleBackColor = false;
            this.but_Test.Click += new System.EventHandler(this.Inspect);
            // 
            // but_SaveParam
            // 
            this.but_SaveParam.BackColor = System.Drawing.Color.LightSteelBlue;
            this.but_SaveParam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.but_SaveParam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.but_SaveParam.Font = new System.Drawing.Font("宋体", 10F);
            this.but_SaveParam.Location = new System.Drawing.Point(218, 1);
            this.but_SaveParam.Margin = new System.Windows.Forms.Padding(1);
            this.but_SaveParam.Name = "but_SaveParam";
            this.but_SaveParam.Size = new System.Drawing.Size(78, 27);
            this.but_SaveParam.TabIndex = 1;
            this.but_SaveParam.Text = "保存信息";
            this.but_SaveParam.UseVisualStyleBackColor = false;
            this.but_SaveParam.Click += new System.EventHandler(this.but_SaveParam_Click);
            // 
            // label_Code
            // 
            this.label_Code.AutoSize = true;
            this.label_Code.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Code.Location = new System.Drawing.Point(0, 3);
            this.label_Code.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.label_Code.Name = "label_Code";
            this.label_Code.Size = new System.Drawing.Size(217, 23);
            this.label_Code.TabIndex = 27;
            this.label_Code.Text = "周期码";
            this.label_Code.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel3.Controls.Add(this.label_Code, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.but_SaveParam, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(86, 61);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(297, 29);
            this.tableLayoutPanel3.TabIndex = 27;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(1, 31);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 29);
            this.label2.TabIndex = 28;
            this.label2.Text = "原码：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(1, 61);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 29);
            this.label3.TabIndex = 29;
            this.label3.Text = "识别结果:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_OrgCode
            // 
            this.label_OrgCode.AutoSize = true;
            this.label_OrgCode.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label_OrgCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_OrgCode.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold);
            this.label_OrgCode.Location = new System.Drawing.Point(0, 0);
            this.label_OrgCode.Margin = new System.Windows.Forms.Padding(0);
            this.label_OrgCode.Name = "label_OrgCode";
            this.label_OrgCode.Size = new System.Drawing.Size(217, 29);
            this.label_OrgCode.TabIndex = 30;
            this.label_OrgCode.Text = "原码";
            this.label_OrgCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CtrlPNCode
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("宋体", 10F);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "CtrlPNCode";
            this.Size = new System.Drawing.Size(384, 560);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel18.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel18;
        private System.Windows.Forms.Button but_SetROI;
        private System.Windows.Forms.Button but_ShowROI;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button but_Test;
        private System.Windows.Forms.Button but_SaveParam;
        private System.Windows.Forms.Label label_Code;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_OrgCode;
    }
}

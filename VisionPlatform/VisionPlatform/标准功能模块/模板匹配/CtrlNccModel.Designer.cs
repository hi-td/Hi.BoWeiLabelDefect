namespace VisionPlatform
{
    partial class CtrlNccModel
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
            this.tableLayoutPanel18 = new System.Windows.Forms.TableLayoutPanel();
            this.numUpD_Score = new System.Windows.Forms.NumericUpDown();
            this.but_TestNccModel = new System.Windows.Forms.Button();
            this.but_CreateNCCModel = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.tableLayoutPanel18.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpD_Score)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel18
            // 
            this.tableLayoutPanel18.ColumnCount = 5;
            this.tableLayoutPanel18.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel18.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel18.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tableLayoutPanel18.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tableLayoutPanel18.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel18.Controls.Add(this.numUpD_Score, 1, 0);
            this.tableLayoutPanel18.Controls.Add(this.but_TestNccModel, 3, 0);
            this.tableLayoutPanel18.Controls.Add(this.but_CreateNCCModel, 2, 0);
            this.tableLayoutPanel18.Controls.Add(this.label5, 0, 0);
            this.tableLayoutPanel18.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel18.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel18.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel18.Name = "tableLayoutPanel18";
            this.tableLayoutPanel18.RowCount = 1;
            this.tableLayoutPanel18.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel18.Size = new System.Drawing.Size(273, 26);
            this.tableLayoutPanel18.TabIndex = 17;
            // 
            // numUpD_Score
            // 
            this.numUpD_Score.DecimalPlaces = 2;
            this.numUpD_Score.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numUpD_Score.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numUpD_Score.Location = new System.Drawing.Point(56, 2);
            this.numUpD_Score.Margin = new System.Windows.Forms.Padding(1, 2, 1, 1);
            this.numUpD_Score.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUpD_Score.Name = "numUpD_Score";
            this.numUpD_Score.Size = new System.Drawing.Size(53, 21);
            this.numUpD_Score.TabIndex = 13;
            this.numUpD_Score.Value = new decimal(new int[] {
            65,
            0,
            0,
            131072});
            // 
            // but_TestNccModel
            // 
            this.but_TestNccModel.BackColor = System.Drawing.Color.LightSteelBlue;
            this.but_TestNccModel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.but_TestNccModel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.but_TestNccModel.Location = new System.Drawing.Point(176, 1);
            this.but_TestNccModel.Margin = new System.Windows.Forms.Padding(1);
            this.but_TestNccModel.Name = "but_TestNccModel";
            this.but_TestNccModel.Size = new System.Drawing.Size(63, 24);
            this.but_TestNccModel.TabIndex = 2;
            this.but_TestNccModel.Text = "测试";
            this.but_TestNccModel.UseVisualStyleBackColor = false;
            this.but_TestNccModel.Click += new System.EventHandler(this.but_TestNccModel_Click);
            // 
            // but_CreateNCCModel
            // 
            this.but_CreateNCCModel.BackColor = System.Drawing.Color.LightSteelBlue;
            this.but_CreateNCCModel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.but_CreateNCCModel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.but_CreateNCCModel.Location = new System.Drawing.Point(111, 1);
            this.but_CreateNCCModel.Margin = new System.Windows.Forms.Padding(1);
            this.but_CreateNCCModel.Name = "but_CreateNCCModel";
            this.but_CreateNCCModel.Size = new System.Drawing.Size(63, 24);
            this.but_CreateNCCModel.TabIndex = 7;
            this.but_CreateNCCModel.Text = "创建模板";
            this.but_CreateNCCModel.UseVisualStyleBackColor = false;
            this.but_CreateNCCModel.Click += new System.EventHandler(this.but_CreateNCCModel_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Margin = new System.Windows.Forms.Padding(0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 26);
            this.label5.TabIndex = 8;
            this.label5.Text = "匹配分数";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CtrlNccModel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel18);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "CtrlNccModel";
            this.Size = new System.Drawing.Size(273, 26);
            this.tableLayoutPanel18.ResumeLayout(false);
            this.tableLayoutPanel18.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpD_Score)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel18;
        private System.Windows.Forms.NumericUpDown numUpD_Score;
        private System.Windows.Forms.Button but_TestNccModel;
        private System.Windows.Forms.Button but_CreateNCCModel;
        private System.Windows.Forms.Label label5;
    }
}

namespace VisionPlatform
{
    partial class CtrlHome
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
            this.but_SaveParam = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.but_Test = new System.Windows.Forms.Button();
            this.tabPage_BarCode = new System.Windows.Forms.TabPage();
            this.tabPage_PNCode = new System.Windows.Forms.TabPage();
            this.tabPage_LabelMove = new System.Windows.Forms.TabPage();
            this.tabPage_Fold = new System.Windows.Forms.TabPage();
            this.checkBox_Fold = new System.Windows.Forms.CheckBox();
            this.tabCtrl = new System.Windows.Forms.TabControl();
            this.checkBox_LabelMove = new System.Windows.Forms.CheckBox();
            this.checkBox_BarCode = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.checkBox_PNCode = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3.SuspendLayout();
            this.tabCtrl.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // but_SaveParam
            // 
            this.but_SaveParam.BackColor = System.Drawing.SystemColors.Control;
            this.but_SaveParam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.but_SaveParam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.but_SaveParam.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.but_SaveParam.Location = new System.Drawing.Point(134, 32);
            this.but_SaveParam.Margin = new System.Windows.Forms.Padding(1);
            this.but_SaveParam.Name = "but_SaveParam";
            this.but_SaveParam.Size = new System.Drawing.Size(198, 30);
            this.but_SaveParam.TabIndex = 1;
            this.but_SaveParam.Text = "保存设置";
            this.but_SaveParam.UseVisualStyleBackColor = false;
            this.but_SaveParam.Click += new System.EventHandler(this.but_SaveParam_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoScroll = true;
            this.tableLayoutPanel3.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.but_Test, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.but_SaveParam, 1, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 557);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(467, 63);
            this.tableLayoutPanel3.TabIndex = 13;
            // 
            // but_Test
            // 
            this.but_Test.BackColor = System.Drawing.SystemColors.Control;
            this.but_Test.Dock = System.Windows.Forms.DockStyle.Fill;
            this.but_Test.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.but_Test.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.but_Test.Location = new System.Drawing.Point(134, 1);
            this.but_Test.Margin = new System.Windows.Forms.Padding(1);
            this.but_Test.Name = "but_Test";
            this.but_Test.Size = new System.Drawing.Size(198, 29);
            this.but_Test.TabIndex = 0;
            this.but_Test.Text = "综合测试";
            this.but_Test.UseVisualStyleBackColor = false;
            this.but_Test.Click += new System.EventHandler(this.Inspect);
            // 
            // tabPage_BarCode
            // 
            this.tabPage_BarCode.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tabPage_BarCode.Location = new System.Drawing.Point(4, 28);
            this.tabPage_BarCode.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage_BarCode.Name = "tabPage_BarCode";
            this.tabPage_BarCode.Size = new System.Drawing.Size(459, 492);
            this.tabPage_BarCode.TabIndex = 0;
            this.tabPage_BarCode.Text = "二维码识别";
            // 
            // tabPage_PNCode
            // 
            this.tabPage_PNCode.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tabPage_PNCode.Location = new System.Drawing.Point(4, 28);
            this.tabPage_PNCode.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage_PNCode.Name = "tabPage_PNCode";
            this.tabPage_PNCode.Size = new System.Drawing.Size(459, 492);
            this.tabPage_PNCode.TabIndex = 1;
            this.tabPage_PNCode.Text = "周期码识别";
            // 
            // tabPage_LabelMove
            // 
            this.tabPage_LabelMove.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tabPage_LabelMove.Location = new System.Drawing.Point(4, 28);
            this.tabPage_LabelMove.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage_LabelMove.Name = "tabPage_LabelMove";
            this.tabPage_LabelMove.Size = new System.Drawing.Size(459, 492);
            this.tabPage_LabelMove.TabIndex = 2;
            this.tabPage_LabelMove.Text = "标签偏移";
            // 
            // tabPage_Fold
            // 
            this.tabPage_Fold.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tabPage_Fold.Location = new System.Drawing.Point(4, 28);
            this.tabPage_Fold.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage_Fold.Name = "tabPage_Fold";
            this.tabPage_Fold.Size = new System.Drawing.Size(459, 492);
            this.tabPage_Fold.TabIndex = 3;
            this.tabPage_Fold.Text = "鼓包褶皱";
            // 
            // checkBox_Fold
            // 
            this.checkBox_Fold.AutoSize = true;
            this.checkBox_Fold.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBox_Fold.Location = new System.Drawing.Point(304, 0);
            this.checkBox_Fold.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.checkBox_Fold.Name = "checkBox_Fold";
            this.checkBox_Fold.Size = new System.Drawing.Size(90, 31);
            this.checkBox_Fold.TabIndex = 5;
            this.checkBox_Fold.Text = "鼓包褶皱";
            this.checkBox_Fold.UseVisualStyleBackColor = true;
            this.checkBox_Fold.CheckedChanged += new System.EventHandler(this.checkBox_Item_CheckedChanged);
            // 
            // tabCtrl
            // 
            this.tabCtrl.Controls.Add(this.tabPage_BarCode);
            this.tabCtrl.Controls.Add(this.tabPage_PNCode);
            this.tabCtrl.Controls.Add(this.tabPage_LabelMove);
            this.tabCtrl.Controls.Add(this.tabPage_Fold);
            this.tabCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabCtrl.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.tabCtrl.Location = new System.Drawing.Point(0, 33);
            this.tabCtrl.Margin = new System.Windows.Forms.Padding(0);
            this.tabCtrl.Name = "tabCtrl";
            this.tabCtrl.SelectedIndex = 0;
            this.tabCtrl.Size = new System.Drawing.Size(467, 524);
            this.tabCtrl.TabIndex = 12;
            // 
            // checkBox_LabelMove
            // 
            this.checkBox_LabelMove.AutoSize = true;
            this.checkBox_LabelMove.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBox_LabelMove.Location = new System.Drawing.Point(212, 0);
            this.checkBox_LabelMove.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.checkBox_LabelMove.Name = "checkBox_LabelMove";
            this.checkBox_LabelMove.Size = new System.Drawing.Size(89, 31);
            this.checkBox_LabelMove.TabIndex = 2;
            this.checkBox_LabelMove.Text = "标签偏移";
            this.checkBox_LabelMove.UseVisualStyleBackColor = true;
            this.checkBox_LabelMove.CheckedChanged += new System.EventHandler(this.checkBox_Item_CheckedChanged);
            // 
            // checkBox_BarCode
            // 
            this.checkBox_BarCode.AutoSize = true;
            this.checkBox_BarCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBox_BarCode.Location = new System.Drawing.Point(3, 0);
            this.checkBox_BarCode.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.checkBox_BarCode.Name = "checkBox_BarCode";
            this.checkBox_BarCode.Size = new System.Drawing.Size(99, 31);
            this.checkBox_BarCode.TabIndex = 0;
            this.checkBox_BarCode.Text = "二维码识别";
            this.checkBox_BarCode.UseVisualStyleBackColor = true;
            this.checkBox_BarCode.CheckedChanged += new System.EventHandler(this.checkBox_Item_CheckedChanged);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(1, 1);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 31);
            this.label2.TabIndex = 1;
            this.label2.Text = "检测项";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.14213F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.15736F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.60406F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.09645F));
            this.tableLayoutPanel2.Controls.Add(this.checkBox_LabelMove, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.checkBox_PNCode, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.checkBox_BarCode, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.checkBox_Fold, 3, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(72, 1);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(394, 31);
            this.tableLayoutPanel2.TabIndex = 19;
            // 
            // checkBox_PNCode
            // 
            this.checkBox_PNCode.AutoSize = true;
            this.checkBox_PNCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBox_PNCode.Location = new System.Drawing.Point(105, 0);
            this.checkBox_PNCode.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.checkBox_PNCode.Name = "checkBox_PNCode";
            this.checkBox_PNCode.Size = new System.Drawing.Size(104, 31);
            this.checkBox_PNCode.TabIndex = 1;
            this.checkBox_PNCode.Text = "周期码识别";
            this.checkBox_PNCode.UseVisualStyleBackColor = true;
            this.checkBox_PNCode.CheckedChanged += new System.EventHandler(this.checkBox_Item_CheckedChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Font = new System.Drawing.Font("宋体", 10F);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(467, 33);
            this.tableLayoutPanel1.TabIndex = 11;
            // 
            // CtrlHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.Controls.Add(this.tabCtrl);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Name = "CtrlHome";
            this.Size = new System.Drawing.Size(467, 620);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tabCtrl.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button but_SaveParam;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button but_Test;
        private System.Windows.Forms.TabPage tabPage_BarCode;
        private System.Windows.Forms.TabPage tabPage_PNCode;
        private System.Windows.Forms.TabPage tabPage_LabelMove;
        private System.Windows.Forms.TabPage tabPage_Fold;
        private System.Windows.Forms.CheckBox checkBox_Fold;
        private System.Windows.Forms.TabControl tabCtrl;
        private System.Windows.Forms.CheckBox checkBox_LabelMove;
        private System.Windows.Forms.CheckBox checkBox_BarCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.CheckBox checkBox_PNCode;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}

namespace VisionPlatform
{
    partial class CtrlStates
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
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label_Result = new System.Windows.Forms.Label();
            this.label_Name = new System.Windows.Forms.Label();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.清除所有数据 = new System.Windows.Forms.ToolStripMenuItem();
            this.Clear_OK = new System.Windows.Forms.ToolStripMenuItem();
            this.Clear_NG = new System.Windows.Forms.ToolStripMenuItem();
            this.Clear_总数 = new System.Windows.Forms.ToolStripMenuItem();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label_TimeSpan = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label_OK = new System.Windows.Forms.Label();
            this.label_NG = new System.Windows.Forms.Label();
            this.label_Total = new System.Windows.Forms.Label();
            this.label_Yield = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label_Result, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label_Name, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(121, 50);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // label_Result
            // 
            this.label_Result.BackColor = System.Drawing.Color.LightSteelBlue;
            this.label_Result.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Result.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.label_Result.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_Result.Location = new System.Drawing.Point(0, 22);
            this.label_Result.Margin = new System.Windows.Forms.Padding(0);
            this.label_Result.Name = "label_Result";
            this.label_Result.Size = new System.Drawing.Size(121, 28);
            this.label_Result.TabIndex = 14;
            this.label_Result.Text = "--";
            this.label_Result.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Name
            // 
            this.label_Name.AutoSize = true;
            this.label_Name.BackColor = System.Drawing.Color.LightSteelBlue;
            this.label_Name.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Name.Font = new System.Drawing.Font("微软雅黑", 9.45F, System.Drawing.FontStyle.Bold);
            this.label_Name.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_Name.Location = new System.Drawing.Point(0, 0);
            this.label_Name.Margin = new System.Windows.Forms.Padding(0);
            this.label_Name.Name = "label_Name";
            this.label_Name.Size = new System.Drawing.Size(121, 22);
            this.label_Name.TabIndex = 13;
            this.label_Name.Text = "检测项1";
            this.label_Name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.AutoSize = true;
            this.tableLayoutPanel8.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel8.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel8.ColumnCount = 2;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel8.ContextMenuStrip = this.contextMenuStrip1;
            this.tableLayoutPanel8.Controls.Add(this.label13, 0, 1);
            this.tableLayoutPanel8.Controls.Add(this.label14, 0, 2);
            this.tableLayoutPanel8.Controls.Add(this.label15, 0, 3);
            this.tableLayoutPanel8.Controls.Add(this.label11, 0, 4);
            this.tableLayoutPanel8.Controls.Add(this.label_TimeSpan, 1, 0);
            this.tableLayoutPanel8.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel8.Controls.Add(this.label_OK, 1, 1);
            this.tableLayoutPanel8.Controls.Add(this.label_NG, 1, 2);
            this.tableLayoutPanel8.Controls.Add(this.label_Total, 1, 3);
            this.tableLayoutPanel8.Controls.Add(this.label_Yield, 1, 4);
            this.tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel8.Font = new System.Drawing.Font("宋体", 10F);
            this.tableLayoutPanel8.Location = new System.Drawing.Point(0, 50);
            this.tableLayoutPanel8.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 5;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(121, 119);
            this.tableLayoutPanel8.TabIndex = 12;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.清除所有数据,
            this.Clear_OK,
            this.Clear_NG,
            this.Clear_总数});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(149, 92);
            // 
            // 清除所有数据
            // 
            this.清除所有数据.AutoSize = false;
            this.清除所有数据.Name = "清除所有数据";
            this.清除所有数据.Size = new System.Drawing.Size(100, 22);
            this.清除所有数据.Text = "清除所有数据";
            this.清除所有数据.Click += new System.EventHandler(this.清除数据_Click);
            // 
            // Clear_OK
            // 
            this.Clear_OK.Name = "Clear_OK";
            this.Clear_OK.Size = new System.Drawing.Size(148, 22);
            this.Clear_OK.Text = "清除OK";
            this.Clear_OK.Click += new System.EventHandler(this.Text_OK_DoubleClick);
            // 
            // Clear_NG
            // 
            this.Clear_NG.Name = "Clear_NG";
            this.Clear_NG.Size = new System.Drawing.Size(148, 22);
            this.Clear_NG.Text = "清除NG";
            this.Clear_NG.Click += new System.EventHandler(this.Text_NG_DoubleClick);
            // 
            // Clear_总数
            // 
            this.Clear_总数.Name = "Clear_总数";
            this.Clear_总数.Size = new System.Drawing.Size(148, 22);
            this.Clear_总数.Text = "清除总数";
            this.Clear_总数.Click += new System.EventHandler(this.Text_Total_DoubleClick);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label13.Font = new System.Drawing.Font("宋体", 10F);
            this.label13.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label13.Location = new System.Drawing.Point(4, 24);
            this.label13.Margin = new System.Windows.Forms.Padding(3, 0, 1, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(55, 22);
            this.label13.TabIndex = 1;
            this.label13.Text = "OK数：";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label14.Font = new System.Drawing.Font("宋体", 10F);
            this.label14.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label14.Location = new System.Drawing.Point(4, 47);
            this.label14.Margin = new System.Windows.Forms.Padding(3, 0, 1, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(55, 22);
            this.label14.TabIndex = 2;
            this.label14.Text = "NG数：";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label15.Font = new System.Drawing.Font("宋体", 10F);
            this.label15.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label15.Location = new System.Drawing.Point(4, 70);
            this.label15.Margin = new System.Windows.Forms.Padding(3, 0, 1, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(55, 22);
            this.label15.TabIndex = 3;
            this.label15.Text = "总数：";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label11.Font = new System.Drawing.Font("宋体", 10F);
            this.label11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label11.Location = new System.Drawing.Point(4, 93);
            this.label11.Margin = new System.Windows.Forms.Padding(3, 0, 1, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(55, 25);
            this.label11.TabIndex = 7;
            this.label11.Text = "良率：";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_TimeSpan
            // 
            this.label_TimeSpan.AutoSize = true;
            this.label_TimeSpan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_TimeSpan.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_TimeSpan.Location = new System.Drawing.Point(61, 1);
            this.label_TimeSpan.Margin = new System.Windows.Forms.Padding(0);
            this.label_TimeSpan.Name = "label_TimeSpan";
            this.label_TimeSpan.Size = new System.Drawing.Size(59, 22);
            this.label_TimeSpan.TabIndex = 9;
            this.label_TimeSpan.Text = "00ms";
            this.label_TimeSpan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("宋体", 10F);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(4, 1);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 0, 1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 22);
            this.label1.TabIndex = 10;
            this.label1.Text = "用时：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_OK
            // 
            this.label_OK.AutoSize = true;
            this.label_OK.BackColor = System.Drawing.Color.Transparent;
            this.label_OK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_OK.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.label_OK.ForeColor = System.Drawing.Color.Green;
            this.label_OK.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_OK.Location = new System.Drawing.Point(61, 24);
            this.label_OK.Margin = new System.Windows.Forms.Padding(0);
            this.label_OK.Name = "label_OK";
            this.label_OK.Size = new System.Drawing.Size(59, 22);
            this.label_OK.TabIndex = 11;
            this.label_OK.Text = "0";
            this.label_OK.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_NG
            // 
            this.label_NG.AutoSize = true;
            this.label_NG.BackColor = System.Drawing.Color.Transparent;
            this.label_NG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_NG.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.label_NG.ForeColor = System.Drawing.Color.Red;
            this.label_NG.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_NG.Location = new System.Drawing.Point(61, 47);
            this.label_NG.Margin = new System.Windows.Forms.Padding(0);
            this.label_NG.Name = "label_NG";
            this.label_NG.Size = new System.Drawing.Size(59, 22);
            this.label_NG.TabIndex = 12;
            this.label_NG.Text = "0";
            this.label_NG.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_Total
            // 
            this.label_Total.AutoSize = true;
            this.label_Total.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Total.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Total.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_Total.Location = new System.Drawing.Point(61, 70);
            this.label_Total.Margin = new System.Windows.Forms.Padding(0);
            this.label_Total.Name = "label_Total";
            this.label_Total.Size = new System.Drawing.Size(59, 22);
            this.label_Total.TabIndex = 13;
            this.label_Total.Text = "0";
            this.label_Total.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_Yield
            // 
            this.label_Yield.AutoSize = true;
            this.label_Yield.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Yield.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Yield.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_Yield.Location = new System.Drawing.Point(61, 93);
            this.label_Yield.Margin = new System.Windows.Forms.Padding(0);
            this.label_Yield.Name = "label_Yield";
            this.label_Yield.Size = new System.Drawing.Size(59, 25);
            this.label_Yield.TabIndex = 14;
            this.label_Yield.Text = "0";
            this.label_Yield.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CtrlStates
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.Controls.Add(this.tableLayoutPanel8);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "CtrlStates";
            this.Size = new System.Drawing.Size(121, 169);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tableLayoutPanel8.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label_Name;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 清除所有数据;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label_TimeSpan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_OK;
        private System.Windows.Forms.Label label_NG;
        private System.Windows.Forms.Label label_Total;
        private System.Windows.Forms.Label label_Yield;
        private System.Windows.Forms.ToolStripMenuItem Clear_OK;
        private System.Windows.Forms.ToolStripMenuItem Clear_NG;
        private System.Windows.Forms.ToolStripMenuItem Clear_总数;
        private System.Windows.Forms.Label label_Result;
    }
}

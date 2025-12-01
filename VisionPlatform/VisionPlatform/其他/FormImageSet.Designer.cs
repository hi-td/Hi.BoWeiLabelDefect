namespace VisionPlatform
{
    partial class FormImageSet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormImageSet));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_ImagePath = new System.Windows.Forms.TextBox();
            this.label_ImagesNum = new System.Windows.Forms.Label();
            this.but_ImageSetPath = new System.Windows.Forms.Button();
            this.listView_ImagePath = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.but_Run = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9F));
            this.tableLayoutPanel1.Controls.Add(this.label3, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBox_ImagePath, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label_ImagesNum, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.but_ImageSetPath, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.but_Run, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.button1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(519, 44);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(471, 1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 42);
            this.label3.TabIndex = 4;
            this.label3.Text = "张图像";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(404, 1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 42);
            this.label2.TabIndex = 2;
            this.label2.Text = "共";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox_ImagePath
            // 
            this.textBox_ImagePath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_ImagePath.Location = new System.Drawing.Point(158, 4);
            this.textBox_ImagePath.Multiline = true;
            this.textBox_ImagePath.Name = "textBox_ImagePath";
            this.textBox_ImagePath.ReadOnly = true;
            this.textBox_ImagePath.Size = new System.Drawing.Size(239, 36);
            this.textBox_ImagePath.TabIndex = 0;
            // 
            // label_ImagesNum
            // 
            this.label_ImagesNum.AutoSize = true;
            this.label_ImagesNum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_ImagesNum.Location = new System.Drawing.Point(430, 1);
            this.label_ImagesNum.Name = "label_ImagesNum";
            this.label_ImagesNum.Size = new System.Drawing.Size(34, 42);
            this.label_ImagesNum.TabIndex = 3;
            this.label_ImagesNum.Text = "0";
            this.label_ImagesNum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // but_ImageSetPath
            // 
            this.but_ImageSetPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.but_ImageSetPath.Location = new System.Drawing.Point(96, 4);
            this.but_ImageSetPath.Name = "but_ImageSetPath";
            this.but_ImageSetPath.Size = new System.Drawing.Size(55, 36);
            this.but_ImageSetPath.TabIndex = 5;
            this.but_ImageSetPath.Text = "文件夹";
            this.but_ImageSetPath.UseVisualStyleBackColor = true;
            this.but_ImageSetPath.Click += new System.EventHandler(this.but_ImageSetPath_Click);
            // 
            // listView_ImagePath
            // 
            this.listView_ImagePath.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listView_ImagePath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView_ImagePath.FullRowSelect = true;
            this.listView_ImagePath.GridLines = true;
            this.listView_ImagePath.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView_ImagePath.HideSelection = false;
            this.listView_ImagePath.Location = new System.Drawing.Point(3, 53);
            this.listView_ImagePath.Name = "listView_ImagePath";
            this.listView_ImagePath.Size = new System.Drawing.Size(519, 337);
            this.listView_ImagePath.TabIndex = 1;
            this.listView_ImagePath.UseCompatibleStateImageBehavior = false;
            this.listView_ImagePath.View = System.Windows.Forms.View.Details;
            this.listView_ImagePath.SelectedIndexChanged += new System.EventHandler(this.listView_ImagePath_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "序号";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "路径";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 348;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "结果";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 91;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.listView_ImagePath, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(525, 393);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // but_Run
            // 
            this.but_Run.Dock = System.Windows.Forms.DockStyle.Fill;
            this.but_Run.Image = ((System.Drawing.Image)(resources.GetObject("but_Run.Image")));
            this.but_Run.Location = new System.Drawing.Point(4, 4);
            this.but_Run.Name = "but_Run";
            this.but_Run.Size = new System.Drawing.Size(39, 36);
            this.but_Run.TabIndex = 6;
            this.but_Run.Tag = "运行";
            this.but_Run.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.but_Run.UseVisualStyleBackColor = true;
            this.but_Run.Click += new System.EventHandler(this.but_Run_Click);
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Image = global::VisionPlatform.Properties.Resources.tgrss_xtrq6;
            this.button1.Location = new System.Drawing.Point(50, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(39, 36);
            this.button1.TabIndex = 7;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormImageSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(525, 393);
            this.Controls.Add(this.tableLayoutPanel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.Name = "FormImageSet";
            this.Text = "批量图像测试";
            this.Load += new System.EventHandler(this.FormImageSet_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_ImagePath;
        private System.Windows.Forms.Label label_ImagesNum;
        private System.Windows.Forms.Button but_ImageSetPath;
        private System.Windows.Forms.ListView listView_ImagePath;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button but_Run;
        private System.Windows.Forms.Button button1;
    }
}
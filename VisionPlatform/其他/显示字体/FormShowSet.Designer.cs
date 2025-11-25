namespace VisionPlatform
{
    partial class FormShowSet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormShowSet));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.trackBar_ColStart = new System.Windows.Forms.TrackBar();
            this.numUpD_ColStart = new System.Windows.Forms.NumericUpDown();
            this.numUpD_RowStart = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numUpD_RowGap = new System.Windows.Forms.NumericUpDown();
            this.numUpD_ColGap = new System.Windows.Forms.NumericUpDown();
            this.trackBar_RowGap = new System.Windows.Forms.TrackBar();
            this.trackBar_ColGap = new System.Windows.Forms.TrackBar();
            this.trackBar_RowStart = new System.Windows.Forms.TrackBar();
            this.numUpD_FrontSize = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label8 = new System.Windows.Forms.Label();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.trackBar_OKCol = new System.Windows.Forms.TrackBar();
            this.trackBar_OKRow = new System.Windows.Forms.TrackBar();
            this.numUpD_OKRow = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.numUpD_OKCol = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.numUpD_OKSize = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_ColStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpD_ColStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpD_RowStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpD_RowGap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpD_ColGap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_RowGap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_ColGap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_RowStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpD_FrontSize)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_OKCol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_OKRow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpD_OKRow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpD_OKCol)).BeginInit();
            this.tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpD_OKSize)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.trackBar_ColStart, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.numUpD_ColStart, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.numUpD_RowStart, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.numUpD_RowGap, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.numUpD_ColGap, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.trackBar_RowGap, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.trackBar_ColGap, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.trackBar_RowStart, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.numUpD_FrontSize, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // trackBar_ColStart
            // 
            resources.ApplyResources(this.trackBar_ColStart, "trackBar_ColStart");
            this.trackBar_ColStart.Maximum = 4000;
            this.trackBar_ColStart.Name = "trackBar_ColStart";
            this.trackBar_ColStart.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar_ColStart.Scroll += new System.EventHandler(this.trackBar_ColStart_Scroll);
            // 
            // numUpD_ColStart
            // 
            resources.ApplyResources(this.numUpD_ColStart, "numUpD_ColStart");
            this.numUpD_ColStart.Maximum = new decimal(new int[] {
            4000,
            0,
            0,
            0});
            this.numUpD_ColStart.Name = "numUpD_ColStart";
            this.numUpD_ColStart.ValueChanged += new System.EventHandler(this.RefreshData);
            // 
            // numUpD_RowStart
            // 
            resources.ApplyResources(this.numUpD_RowStart, "numUpD_RowStart");
            this.numUpD_RowStart.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numUpD_RowStart.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.numUpD_RowStart.Name = "numUpD_RowStart";
            this.numUpD_RowStart.ValueChanged += new System.EventHandler(this.RefreshData);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // numUpD_RowGap
            // 
            resources.ApplyResources(this.numUpD_RowGap, "numUpD_RowGap");
            this.numUpD_RowGap.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.numUpD_RowGap.Name = "numUpD_RowGap";
            this.numUpD_RowGap.ValueChanged += new System.EventHandler(this.RefreshData);
            // 
            // numUpD_ColGap
            // 
            resources.ApplyResources(this.numUpD_ColGap, "numUpD_ColGap");
            this.numUpD_ColGap.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numUpD_ColGap.Name = "numUpD_ColGap";
            this.numUpD_ColGap.ValueChanged += new System.EventHandler(this.RefreshData);
            // 
            // trackBar_RowGap
            // 
            resources.ApplyResources(this.trackBar_RowGap, "trackBar_RowGap");
            this.trackBar_RowGap.Maximum = 2000;
            this.trackBar_RowGap.Name = "trackBar_RowGap";
            this.trackBar_RowGap.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar_RowGap.Scroll += new System.EventHandler(this.trackBar_RowGap_Scroll);
            // 
            // trackBar_ColGap
            // 
            resources.ApplyResources(this.trackBar_ColGap, "trackBar_ColGap");
            this.trackBar_ColGap.Maximum = 5000;
            this.trackBar_ColGap.Name = "trackBar_ColGap";
            this.trackBar_ColGap.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar_ColGap.Scroll += new System.EventHandler(this.trackBar_ColGap_Scroll);
            // 
            // trackBar_RowStart
            // 
            resources.ApplyResources(this.trackBar_RowStart, "trackBar_RowStart");
            this.trackBar_RowStart.Maximum = 5000;
            this.trackBar_RowStart.Minimum = -1000;
            this.trackBar_RowStart.Name = "trackBar_RowStart";
            this.trackBar_RowStart.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar_RowStart.Scroll += new System.EventHandler(this.trackBar_RowStart_Scroll);
            // 
            // numUpD_FrontSize
            // 
            resources.ApplyResources(this.numUpD_FrontSize, "numUpD_FrontSize");
            this.numUpD_FrontSize.Maximum = new decimal(new int[] {
            80,
            0,
            0,
            0});
            this.numUpD_FrontSize.Minimum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.numUpD_FrontSize.Name = "numUpD_FrontSize";
            this.numUpD_FrontSize.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numUpD_FrontSize.ValueChanged += new System.EventHandler(this.RefreshData);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.LightSteelBlue;
            resources.ApplyResources(this.tableLayoutPanel2, "tableLayoutPanel2");
            this.tableLayoutPanel2.Controls.Add(this.label6, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel1, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.label7, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 1, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.tableLayoutPanel3, "tableLayoutPanel3");
            this.tableLayoutPanel3.Controls.Add(this.label8, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel5, 1, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // tableLayoutPanel4
            // 
            resources.ApplyResources(this.tableLayoutPanel4, "tableLayoutPanel4");
            this.tableLayoutPanel4.Controls.Add(this.trackBar_OKCol, 2, 1);
            this.tableLayoutPanel4.Controls.Add(this.trackBar_OKRow, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.numUpD_OKRow, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.label9, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.label10, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.numUpD_OKCol, 1, 1);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            // 
            // trackBar_OKCol
            // 
            resources.ApplyResources(this.trackBar_OKCol, "trackBar_OKCol");
            this.trackBar_OKCol.Maximum = 5000;
            this.trackBar_OKCol.Name = "trackBar_OKCol";
            this.trackBar_OKCol.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar_OKCol.Scroll += new System.EventHandler(this.trackBar_OKCol_Scroll);
            // 
            // trackBar_OKRow
            // 
            resources.ApplyResources(this.trackBar_OKRow, "trackBar_OKRow");
            this.trackBar_OKRow.Maximum = 4000;
            this.trackBar_OKRow.Name = "trackBar_OKRow";
            this.trackBar_OKRow.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar_OKRow.Value = 50;
            this.trackBar_OKRow.Scroll += new System.EventHandler(this.trackBar_OKRow_Scroll);
            // 
            // numUpD_OKRow
            // 
            resources.ApplyResources(this.numUpD_OKRow, "numUpD_OKRow");
            this.numUpD_OKRow.Maximum = new decimal(new int[] {
            4000,
            0,
            0,
            0});
            this.numUpD_OKRow.Name = "numUpD_OKRow";
            this.numUpD_OKRow.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numUpD_OKRow.ValueChanged += new System.EventHandler(this.RefreshData);
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // numUpD_OKCol
            // 
            resources.ApplyResources(this.numUpD_OKCol, "numUpD_OKCol");
            this.numUpD_OKCol.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numUpD_OKCol.Name = "numUpD_OKCol";
            this.numUpD_OKCol.ValueChanged += new System.EventHandler(this.RefreshData);
            // 
            // tableLayoutPanel5
            // 
            resources.ApplyResources(this.tableLayoutPanel5, "tableLayoutPanel5");
            this.tableLayoutPanel5.Controls.Add(this.numUpD_OKSize, 0, 1);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            // 
            // numUpD_OKSize
            // 
            resources.ApplyResources(this.numUpD_OKSize, "numUpD_OKSize");
            this.numUpD_OKSize.Maximum = new decimal(new int[] {
            80,
            0,
            0,
            0});
            this.numUpD_OKSize.Minimum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.numUpD_OKSize.Name = "numUpD_OKSize";
            this.numUpD_OKSize.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numUpD_OKSize.ValueChanged += new System.EventHandler(this.RefreshData);
            // 
            // FormShowSet
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormShowSet";
            this.Load += new System.EventHandler(this.FormShowSet_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_ColStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpD_ColStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpD_RowStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpD_RowGap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpD_ColGap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_RowGap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_ColGap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_RowStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpD_FrontSize)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_OKCol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_OKRow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpD_OKRow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpD_OKCol)).EndInit();
            this.tableLayoutPanel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numUpD_OKSize)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numUpD_RowGap;
        private System.Windows.Forms.NumericUpDown numUpD_ColGap;
        private System.Windows.Forms.NumericUpDown numUpD_FrontSize;
        private System.Windows.Forms.TrackBar trackBar_RowGap;
        private System.Windows.Forms.TrackBar trackBar_ColGap;
        private System.Windows.Forms.TrackBar trackBar_RowStart;
        private System.Windows.Forms.NumericUpDown numUpD_RowStart;
        private System.Windows.Forms.TrackBar trackBar_ColStart;
        private System.Windows.Forms.NumericUpDown numUpD_ColStart;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.NumericUpDown numUpD_OKSize;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.TrackBar trackBar_OKCol;
        private System.Windows.Forms.TrackBar trackBar_OKRow;
        private System.Windows.Forms.NumericUpDown numUpD_OKRow;
        private System.Windows.Forms.NumericUpDown numUpD_OKCol;
    }
}
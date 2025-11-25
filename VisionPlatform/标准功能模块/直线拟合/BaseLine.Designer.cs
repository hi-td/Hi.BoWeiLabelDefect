namespace VisionPlatform
{
    partial class BaseLine
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseLine));
            this.Panel_RubberAdd = new System.Windows.Forms.TableLayoutPanel();
            this.comboBox_Direction = new System.Windows.Forms.ComboBox();
            this.comboBox_TransPoint = new System.Windows.Forms.ComboBox();
            this.comboBox_Transition = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label50 = new System.Windows.Forms.Label();
            this.tableLayoutPanel28 = new System.Windows.Forms.TableLayoutPanel();
            this.trackBar_BaseLineThd = new System.Windows.Forms.TrackBar();
            this.numUpD_BaseLineThd = new System.Windows.Forms.NumericUpDown();
            this.label72 = new System.Windows.Forms.Label();
            this.label53 = new System.Windows.Forms.Label();
            this.tableLayoutPanel16 = new System.Windows.Forms.TableLayoutPanel();
            this.numUpD_BaseLineMoveX = new System.Windows.Forms.NumericUpDown();
            this.trackBar_BaseLineMoveX = new System.Windows.Forms.TrackBar();
            this.label29 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label54 = new System.Windows.Forms.Label();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.numUpD_BaseLineHeight = new System.Windows.Forms.NumericUpDown();
            this.trackBar_BaseLineHeight = new System.Windows.Forms.TrackBar();
            this.tableLayoutPanel18 = new System.Windows.Forms.TableLayoutPanel();
            this.numUpD_BaseLineWidth = new System.Windows.Forms.NumericUpDown();
            this.trackBar_BaseLineWidth = new System.Windows.Forms.TrackBar();
            this.tableLayoutPanel19 = new System.Windows.Forms.TableLayoutPanel();
            this.trackBar_BaseLineMoveY = new System.Windows.Forms.TrackBar();
            this.numUpD_BaseLineMoveY = new System.Windows.Forms.NumericUpDown();
            this.label48 = new System.Windows.Forms.Label();
            this.Panel_RubberAdd.SuspendLayout();
            this.tableLayoutPanel28.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_BaseLineThd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpD_BaseLineThd)).BeginInit();
            this.tableLayoutPanel16.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpD_BaseLineMoveX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_BaseLineMoveX)).BeginInit();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpD_BaseLineHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_BaseLineHeight)).BeginInit();
            this.tableLayoutPanel18.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpD_BaseLineWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_BaseLineWidth)).BeginInit();
            this.tableLayoutPanel19.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_BaseLineMoveY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpD_BaseLineMoveY)).BeginInit();
            this.SuspendLayout();
            // 
            // Panel_RubberAdd
            // 
            resources.ApplyResources(this.Panel_RubberAdd, "Panel_RubberAdd");
            this.Panel_RubberAdd.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Panel_RubberAdd.Controls.Add(this.comboBox_Direction, 1, 4);
            this.Panel_RubberAdd.Controls.Add(this.comboBox_TransPoint, 1, 6);
            this.Panel_RubberAdd.Controls.Add(this.comboBox_Transition, 1, 5);
            this.Panel_RubberAdd.Controls.Add(this.label1, 0, 6);
            this.Panel_RubberAdd.Controls.Add(this.label50, 0, 5);
            this.Panel_RubberAdd.Controls.Add(this.tableLayoutPanel28, 1, 7);
            this.Panel_RubberAdd.Controls.Add(this.label72, 0, 7);
            this.Panel_RubberAdd.Controls.Add(this.label53, 0, 2);
            this.Panel_RubberAdd.Controls.Add(this.tableLayoutPanel16, 1, 2);
            this.Panel_RubberAdd.Controls.Add(this.label29, 0, 0);
            this.Panel_RubberAdd.Controls.Add(this.label30, 0, 1);
            this.Panel_RubberAdd.Controls.Add(this.label54, 0, 3);
            this.Panel_RubberAdd.Controls.Add(this.tableLayoutPanel4, 1, 0);
            this.Panel_RubberAdd.Controls.Add(this.tableLayoutPanel18, 1, 1);
            this.Panel_RubberAdd.Controls.Add(this.tableLayoutPanel19, 1, 3);
            this.Panel_RubberAdd.Controls.Add(this.label48, 0, 4);
            this.Panel_RubberAdd.Name = "Panel_RubberAdd";
            // 
            // comboBox_Direction
            // 
            resources.ApplyResources(this.comboBox_Direction, "comboBox_Direction");
            this.comboBox_Direction.FormattingEnabled = true;
            this.comboBox_Direction.Items.AddRange(new object[] {
            resources.GetString("comboBox_Direction.Items"),
            resources.GetString("comboBox_Direction.Items1")});
            this.comboBox_Direction.Name = "comboBox_Direction";
            this.comboBox_Direction.SelectedIndexChanged += new System.EventHandler(this.ValueChanged);
            // 
            // comboBox_TransPoint
            // 
            resources.ApplyResources(this.comboBox_TransPoint, "comboBox_TransPoint");
            this.comboBox_TransPoint.FormattingEnabled = true;
            this.comboBox_TransPoint.Items.AddRange(new object[] {
            resources.GetString("comboBox_TransPoint.Items"),
            resources.GetString("comboBox_TransPoint.Items1")});
            this.comboBox_TransPoint.Name = "comboBox_TransPoint";
            // 
            // comboBox_Transition
            // 
            resources.ApplyResources(this.comboBox_Transition, "comboBox_Transition");
            this.comboBox_Transition.FormattingEnabled = true;
            this.comboBox_Transition.Items.AddRange(new object[] {
            resources.GetString("comboBox_Transition.Items"),
            resources.GetString("comboBox_Transition.Items1")});
            this.comboBox_Transition.Name = "comboBox_Transition";
            this.comboBox_Transition.SelectedIndexChanged += new System.EventHandler(this.ValueChanged);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label50
            // 
            resources.ApplyResources(this.label50, "label50");
            this.label50.Name = "label50";
            // 
            // tableLayoutPanel28
            // 
            resources.ApplyResources(this.tableLayoutPanel28, "tableLayoutPanel28");
            this.tableLayoutPanel28.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel28.Controls.Add(this.trackBar_BaseLineThd, 0, 0);
            this.tableLayoutPanel28.Controls.Add(this.numUpD_BaseLineThd, 0, 0);
            this.tableLayoutPanel28.Name = "tableLayoutPanel28";
            // 
            // trackBar_BaseLineThd
            // 
            resources.ApplyResources(this.trackBar_BaseLineThd, "trackBar_BaseLineThd");
            this.trackBar_BaseLineThd.Maximum = 255;
            this.trackBar_BaseLineThd.Minimum = 1;
            this.trackBar_BaseLineThd.Name = "trackBar_BaseLineThd";
            this.trackBar_BaseLineThd.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar_BaseLineThd.Value = 1;
            this.trackBar_BaseLineThd.Scroll += new System.EventHandler(this.trackBar_BaseLineThd_Scroll);
            // 
            // numUpD_BaseLineThd
            // 
            resources.ApplyResources(this.numUpD_BaseLineThd, "numUpD_BaseLineThd");
            this.numUpD_BaseLineThd.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numUpD_BaseLineThd.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUpD_BaseLineThd.Name = "numUpD_BaseLineThd";
            this.numUpD_BaseLineThd.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUpD_BaseLineThd.ValueChanged += new System.EventHandler(this.ValueChanged);
            // 
            // label72
            // 
            resources.ApplyResources(this.label72, "label72");
            this.label72.Name = "label72";
            // 
            // label53
            // 
            resources.ApplyResources(this.label53, "label53");
            this.label53.Name = "label53";
            // 
            // tableLayoutPanel16
            // 
            resources.ApplyResources(this.tableLayoutPanel16, "tableLayoutPanel16");
            this.tableLayoutPanel16.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel16.Controls.Add(this.numUpD_BaseLineMoveX, 0, 0);
            this.tableLayoutPanel16.Controls.Add(this.trackBar_BaseLineMoveX, 1, 0);
            this.tableLayoutPanel16.Name = "tableLayoutPanel16";
            // 
            // numUpD_BaseLineMoveX
            // 
            resources.ApplyResources(this.numUpD_BaseLineMoveX, "numUpD_BaseLineMoveX");
            this.numUpD_BaseLineMoveX.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numUpD_BaseLineMoveX.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.numUpD_BaseLineMoveX.Name = "numUpD_BaseLineMoveX";
            this.numUpD_BaseLineMoveX.ValueChanged += new System.EventHandler(this.ValueChanged);
            // 
            // trackBar_BaseLineMoveX
            // 
            resources.ApplyResources(this.trackBar_BaseLineMoveX, "trackBar_BaseLineMoveX");
            this.trackBar_BaseLineMoveX.Maximum = 1000;
            this.trackBar_BaseLineMoveX.Minimum = -1000;
            this.trackBar_BaseLineMoveX.Name = "trackBar_BaseLineMoveX";
            this.trackBar_BaseLineMoveX.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar_BaseLineMoveX.Scroll += new System.EventHandler(this.trackBar_BaseLineMoveX_Scroll);
            // 
            // label29
            // 
            resources.ApplyResources(this.label29, "label29");
            this.label29.Name = "label29";
            // 
            // label30
            // 
            resources.ApplyResources(this.label30, "label30");
            this.label30.Name = "label30";
            // 
            // label54
            // 
            resources.ApplyResources(this.label54, "label54");
            this.label54.Name = "label54";
            // 
            // tableLayoutPanel4
            // 
            resources.ApplyResources(this.tableLayoutPanel4, "tableLayoutPanel4");
            this.tableLayoutPanel4.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel4.Controls.Add(this.numUpD_BaseLineHeight, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.trackBar_BaseLineHeight, 1, 0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            // 
            // numUpD_BaseLineHeight
            // 
            resources.ApplyResources(this.numUpD_BaseLineHeight, "numUpD_BaseLineHeight");
            this.numUpD_BaseLineHeight.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numUpD_BaseLineHeight.Name = "numUpD_BaseLineHeight";
            this.numUpD_BaseLineHeight.ValueChanged += new System.EventHandler(this.ValueChanged);
            // 
            // trackBar_BaseLineHeight
            // 
            resources.ApplyResources(this.trackBar_BaseLineHeight, "trackBar_BaseLineHeight");
            this.trackBar_BaseLineHeight.Maximum = 1000;
            this.trackBar_BaseLineHeight.Name = "trackBar_BaseLineHeight";
            this.trackBar_BaseLineHeight.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar_BaseLineHeight.Scroll += new System.EventHandler(this.trackBar_BaseLineHeight_Scroll);
            // 
            // tableLayoutPanel18
            // 
            resources.ApplyResources(this.tableLayoutPanel18, "tableLayoutPanel18");
            this.tableLayoutPanel18.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel18.Controls.Add(this.numUpD_BaseLineWidth, 0, 0);
            this.tableLayoutPanel18.Controls.Add(this.trackBar_BaseLineWidth, 1, 0);
            this.tableLayoutPanel18.Name = "tableLayoutPanel18";
            // 
            // numUpD_BaseLineWidth
            // 
            resources.ApplyResources(this.numUpD_BaseLineWidth, "numUpD_BaseLineWidth");
            this.numUpD_BaseLineWidth.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.numUpD_BaseLineWidth.Name = "numUpD_BaseLineWidth";
            this.numUpD_BaseLineWidth.ValueChanged += new System.EventHandler(this.ValueChanged);
            // 
            // trackBar_BaseLineWidth
            // 
            resources.ApplyResources(this.trackBar_BaseLineWidth, "trackBar_BaseLineWidth");
            this.trackBar_BaseLineWidth.Maximum = 2000;
            this.trackBar_BaseLineWidth.Name = "trackBar_BaseLineWidth";
            this.trackBar_BaseLineWidth.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar_BaseLineWidth.Scroll += new System.EventHandler(this.trackBar_BaseLineWidth_Scroll);
            // 
            // tableLayoutPanel19
            // 
            resources.ApplyResources(this.tableLayoutPanel19, "tableLayoutPanel19");
            this.tableLayoutPanel19.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel19.Controls.Add(this.trackBar_BaseLineMoveY, 1, 0);
            this.tableLayoutPanel19.Controls.Add(this.numUpD_BaseLineMoveY, 0, 0);
            this.tableLayoutPanel19.Name = "tableLayoutPanel19";
            // 
            // trackBar_BaseLineMoveY
            // 
            resources.ApplyResources(this.trackBar_BaseLineMoveY, "trackBar_BaseLineMoveY");
            this.trackBar_BaseLineMoveY.Maximum = 1000;
            this.trackBar_BaseLineMoveY.Minimum = -1000;
            this.trackBar_BaseLineMoveY.Name = "trackBar_BaseLineMoveY";
            this.trackBar_BaseLineMoveY.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar_BaseLineMoveY.Scroll += new System.EventHandler(this.trackBar_BaseLineMoveY_Scroll);
            // 
            // numUpD_BaseLineMoveY
            // 
            resources.ApplyResources(this.numUpD_BaseLineMoveY, "numUpD_BaseLineMoveY");
            this.numUpD_BaseLineMoveY.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numUpD_BaseLineMoveY.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.numUpD_BaseLineMoveY.Name = "numUpD_BaseLineMoveY";
            this.numUpD_BaseLineMoveY.ValueChanged += new System.EventHandler(this.ValueChanged);
            // 
            // label48
            // 
            resources.ApplyResources(this.label48, "label48");
            this.label48.Name = "label48";
            // 
            // BaseLine
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Panel_RubberAdd);
            this.Name = "BaseLine";
            this.Load += new System.EventHandler(this.BaseLine_Load);
            this.Panel_RubberAdd.ResumeLayout(false);
            this.Panel_RubberAdd.PerformLayout();
            this.tableLayoutPanel28.ResumeLayout(false);
            this.tableLayoutPanel28.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_BaseLineThd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpD_BaseLineThd)).EndInit();
            this.tableLayoutPanel16.ResumeLayout(false);
            this.tableLayoutPanel16.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpD_BaseLineMoveX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_BaseLineMoveX)).EndInit();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpD_BaseLineHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_BaseLineHeight)).EndInit();
            this.tableLayoutPanel18.ResumeLayout(false);
            this.tableLayoutPanel18.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpD_BaseLineWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_BaseLineWidth)).EndInit();
            this.tableLayoutPanel19.ResumeLayout(false);
            this.tableLayoutPanel19.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_BaseLineMoveY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpD_BaseLineMoveY)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel Panel_RubberAdd;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel28;
        private System.Windows.Forms.TrackBar trackBar_BaseLineThd;
        private System.Windows.Forms.NumericUpDown numUpD_BaseLineThd;
        private System.Windows.Forms.Label label72;
        private System.Windows.Forms.Label label53;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel16;
        private System.Windows.Forms.NumericUpDown numUpD_BaseLineMoveX;
        private System.Windows.Forms.TrackBar trackBar_BaseLineMoveX;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.ComboBox comboBox_Transition;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.NumericUpDown numUpD_BaseLineHeight;
        private System.Windows.Forms.TrackBar trackBar_BaseLineHeight;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel18;
        private System.Windows.Forms.NumericUpDown numUpD_BaseLineWidth;
        private System.Windows.Forms.TrackBar trackBar_BaseLineWidth;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel19;
        private System.Windows.Forms.TrackBar trackBar_BaseLineMoveY;
        private System.Windows.Forms.NumericUpDown numUpD_BaseLineMoveY;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.ComboBox comboBox_Direction;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_TransPoint;
    }
}

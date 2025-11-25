namespace VisionPlatform
{
    partial class CtrlThd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtrlThd));
            this.tableLayoutPanel14 = new System.Windows.Forms.TableLayoutPanel();
            this.tLPanel_DynThd = new System.Windows.Forms.TableLayoutPanel();
            this.numUpD_DynThd = new System.Windows.Forms.NumericUpDown();
            this.numUpD_MeanMask = new System.Windows.Forms.NumericUpDown();
            this.label30 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.radioButton_light = new System.Windows.Forms.RadioButton();
            this.radioButton_dark = new System.Windows.Forms.RadioButton();
            this.checkBox_AutoThd = new System.Windows.Forms.CheckBox();
            this.tLPanel_StaticThd = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.trackBar_StaticThdMin = new System.Windows.Forms.TrackBar();
            this.numUpD_StaticThdMin = new System.Windows.Forms.NumericUpDown();
            this.label29 = new System.Windows.Forms.Label();
            this.numUpD_StaticThdMax = new System.Windows.Forms.NumericUpDown();
            this.trackBar_StaticThdMax = new System.Windows.Forms.TrackBar();
            this.checkBox_StaticThd = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel14.SuspendLayout();
            this.tLPanel_DynThd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpD_DynThd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpD_MeanMask)).BeginInit();
            this.tLPanel_StaticThd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_StaticThdMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpD_StaticThdMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpD_StaticThdMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_StaticThdMax)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel14
            // 
            resources.ApplyResources(this.tableLayoutPanel14, "tableLayoutPanel14");
            this.tableLayoutPanel14.Controls.Add(this.tLPanel_DynThd, 1, 0);
            this.tableLayoutPanel14.Controls.Add(this.checkBox_AutoThd, 0, 0);
            this.tableLayoutPanel14.Controls.Add(this.tLPanel_StaticThd, 1, 1);
            this.tableLayoutPanel14.Controls.Add(this.checkBox_StaticThd, 0, 1);
            this.tableLayoutPanel14.Name = "tableLayoutPanel14";
            // 
            // tLPanel_DynThd
            // 
            resources.ApplyResources(this.tLPanel_DynThd, "tLPanel_DynThd");
            this.tLPanel_DynThd.Controls.Add(this.numUpD_DynThd, 3, 0);
            this.tLPanel_DynThd.Controls.Add(this.numUpD_MeanMask, 1, 0);
            this.tLPanel_DynThd.Controls.Add(this.label30, 0, 0);
            this.tLPanel_DynThd.Controls.Add(this.label33, 2, 0);
            this.tLPanel_DynThd.Controls.Add(this.radioButton_light, 4, 0);
            this.tLPanel_DynThd.Controls.Add(this.radioButton_dark, 5, 0);
            this.tLPanel_DynThd.Name = "tLPanel_DynThd";
            // 
            // numUpD_DynThd
            // 
            resources.ApplyResources(this.numUpD_DynThd, "numUpD_DynThd");
            this.numUpD_DynThd.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numUpD_DynThd.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            -2147483648});
            this.numUpD_DynThd.Name = "numUpD_DynThd";
            this.numUpD_DynThd.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numUpD_DynThd.ValueChanged += new System.EventHandler(this.Inspect);
            // 
            // numUpD_MeanMask
            // 
            resources.ApplyResources(this.numUpD_MeanMask, "numUpD_MeanMask");
            this.numUpD_MeanMask.Maximum = new decimal(new int[] {
            511,
            0,
            0,
            0});
            this.numUpD_MeanMask.Name = "numUpD_MeanMask";
            this.numUpD_MeanMask.Value = new decimal(new int[] {
            35,
            0,
            0,
            0});
            this.numUpD_MeanMask.ValueChanged += new System.EventHandler(this.Inspect);
            // 
            // label30
            // 
            resources.ApplyResources(this.label30, "label30");
            this.label30.Name = "label30";
            // 
            // label33
            // 
            resources.ApplyResources(this.label33, "label33");
            this.label33.Name = "label33";
            // 
            // radioButton_light
            // 
            resources.ApplyResources(this.radioButton_light, "radioButton_light");
            this.radioButton_light.Name = "radioButton_light";
            this.radioButton_light.TabStop = true;
            this.radioButton_light.UseVisualStyleBackColor = true;
            this.radioButton_light.CheckedChanged += new System.EventHandler(this.Inspect);
            // 
            // radioButton_dark
            // 
            resources.ApplyResources(this.radioButton_dark, "radioButton_dark");
            this.radioButton_dark.Name = "radioButton_dark";
            this.radioButton_dark.TabStop = true;
            this.radioButton_dark.UseVisualStyleBackColor = true;
            this.radioButton_dark.CheckedChanged += new System.EventHandler(this.Inspect);
            // 
            // checkBox_AutoThd
            // 
            resources.ApplyResources(this.checkBox_AutoThd, "checkBox_AutoThd");
            this.checkBox_AutoThd.Checked = true;
            this.checkBox_AutoThd.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_AutoThd.Name = "checkBox_AutoThd";
            this.checkBox_AutoThd.UseVisualStyleBackColor = true;
            this.checkBox_AutoThd.CheckedChanged += new System.EventHandler(this.checkBox_AutoThd_CheckedChanged);
            // 
            // tLPanel_StaticThd
            // 
            resources.ApplyResources(this.tLPanel_StaticThd, "tLPanel_StaticThd");
            this.tLPanel_StaticThd.Controls.Add(this.label1, 0, 1);
            this.tLPanel_StaticThd.Controls.Add(this.trackBar_StaticThdMin, 2, 0);
            this.tLPanel_StaticThd.Controls.Add(this.numUpD_StaticThdMin, 1, 0);
            this.tLPanel_StaticThd.Controls.Add(this.label29, 0, 0);
            this.tLPanel_StaticThd.Controls.Add(this.numUpD_StaticThdMax, 1, 1);
            this.tLPanel_StaticThd.Controls.Add(this.trackBar_StaticThdMax, 2, 1);
            this.tLPanel_StaticThd.Name = "tLPanel_StaticThd";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // trackBar_StaticThdMin
            // 
            resources.ApplyResources(this.trackBar_StaticThdMin, "trackBar_StaticThdMin");
            this.trackBar_StaticThdMin.Maximum = 255;
            this.trackBar_StaticThdMin.Name = "trackBar_StaticThdMin";
            this.trackBar_StaticThdMin.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar_StaticThdMin.Scroll += new System.EventHandler(this.trackBar_StaticThd_Scroll);
            // 
            // numUpD_StaticThdMin
            // 
            resources.ApplyResources(this.numUpD_StaticThdMin, "numUpD_StaticThdMin");
            this.numUpD_StaticThdMin.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numUpD_StaticThdMin.Name = "numUpD_StaticThdMin";
            this.numUpD_StaticThdMin.ValueChanged += new System.EventHandler(this.Inspect);
            // 
            // label29
            // 
            resources.ApplyResources(this.label29, "label29");
            this.label29.Name = "label29";
            // 
            // numUpD_StaticThdMax
            // 
            resources.ApplyResources(this.numUpD_StaticThdMax, "numUpD_StaticThdMax");
            this.numUpD_StaticThdMax.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numUpD_StaticThdMax.Name = "numUpD_StaticThdMax";
            this.numUpD_StaticThdMax.ValueChanged += new System.EventHandler(this.Inspect);
            // 
            // trackBar_StaticThdMax
            // 
            resources.ApplyResources(this.trackBar_StaticThdMax, "trackBar_StaticThdMax");
            this.trackBar_StaticThdMax.Maximum = 255;
            this.trackBar_StaticThdMax.Name = "trackBar_StaticThdMax";
            this.trackBar_StaticThdMax.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar_StaticThdMax.Scroll += new System.EventHandler(this.trackBar_StaticThdMax_Scroll);
            // 
            // checkBox_StaticThd
            // 
            resources.ApplyResources(this.checkBox_StaticThd, "checkBox_StaticThd");
            this.checkBox_StaticThd.Name = "checkBox_StaticThd";
            this.checkBox_StaticThd.UseVisualStyleBackColor = true;
            this.checkBox_StaticThd.CheckedChanged += new System.EventHandler(this.checkBox_StaticThd_CheckedChanged);
            // 
            // CtrlThd
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel14);
            this.Name = "CtrlThd";
            this.tableLayoutPanel14.ResumeLayout(false);
            this.tableLayoutPanel14.PerformLayout();
            this.tLPanel_DynThd.ResumeLayout(false);
            this.tLPanel_DynThd.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpD_DynThd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpD_MeanMask)).EndInit();
            this.tLPanel_StaticThd.ResumeLayout(false);
            this.tLPanel_StaticThd.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_StaticThdMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpD_StaticThdMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpD_StaticThdMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_StaticThdMax)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel14;
        private System.Windows.Forms.TableLayoutPanel tLPanel_DynThd;
        private System.Windows.Forms.NumericUpDown numUpD_DynThd;
        private System.Windows.Forms.NumericUpDown numUpD_MeanMask;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.CheckBox checkBox_AutoThd;
        private System.Windows.Forms.CheckBox checkBox_StaticThd;
        private System.Windows.Forms.TableLayoutPanel tLPanel_StaticThd;
        private System.Windows.Forms.TrackBar trackBar_StaticThdMin;
        private System.Windows.Forms.NumericUpDown numUpD_StaticThdMin;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numUpD_StaticThdMax;
        private System.Windows.Forms.TrackBar trackBar_StaticThdMax;
        private System.Windows.Forms.RadioButton radioButton_light;
        private System.Windows.Forms.RadioButton radioButton_dark;
    }
}

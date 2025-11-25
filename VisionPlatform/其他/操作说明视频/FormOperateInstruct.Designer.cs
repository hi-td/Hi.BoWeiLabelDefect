namespace VisionPlatform
{
    partial class FormOperateInstruct
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormOperateInstruct));
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.trackBar = new System.Windows.Forms.TrackBar();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label_nowTime = new System.Windows.Forms.Label();
            this.label_totalTime = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.but_Pause = new System.Windows.Forms.Button();
            this.but_Play = new System.Windows.Forms.Button();
            this.vlcControl = new Vlc.DotNet.Forms.VlcControl();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vlcControl)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.tableLayoutPanel5);
            this.panel1.Controls.Add(this.vlcControl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(831, 567);
            this.panel1.TabIndex = 0;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.trackBar, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.tableLayoutPanel1, 0, 1);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 500);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(829, 65);
            this.tableLayoutPanel5.TabIndex = 2;
            // 
            // trackBar
            // 
            this.trackBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trackBar.Location = new System.Drawing.Point(4, 4);
            this.trackBar.Name = "trackBar";
            this.trackBar.Size = new System.Drawing.Size(821, 15);
            this.trackBar.TabIndex = 0;
            this.trackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar.Scroll += new System.EventHandler(this.trackBar_Scroll);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 8;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel1.Controls.Add(this.label_nowTime, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.label_totalTime, 7, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.but_Pause, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.but_Play, 3, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(4, 26);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(821, 35);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // label_nowTime
            // 
            this.label_nowTime.AutoSize = true;
            this.label_nowTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_nowTime.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_nowTime.Location = new System.Drawing.Point(658, 0);
            this.label_nowTime.Name = "label_nowTime";
            this.label_nowTime.Size = new System.Drawing.Size(69, 35);
            this.label_nowTime.TabIndex = 2;
            this.label_nowTime.Text = "---";
            this.label_nowTime.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label_totalTime
            // 
            this.label_totalTime.AutoSize = true;
            this.label_totalTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_totalTime.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_totalTime.Location = new System.Drawing.Point(748, 0);
            this.label_totalTime.Name = "label_totalTime";
            this.label_totalTime.Size = new System.Drawing.Size(70, 35);
            this.label_totalTime.TabIndex = 3;
            this.label_totalTime.Text = "—";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label3.Location = new System.Drawing.Point(733, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(9, 35);
            this.label3.TabIndex = 5;
            this.label3.Text = "/";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // but_Pause
            // 
            this.but_Pause.BackColor = System.Drawing.Color.Transparent;
            this.but_Pause.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("but_Pause.BackgroundImage")));
            this.but_Pause.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.but_Pause.Dock = System.Windows.Forms.DockStyle.Left;
            this.but_Pause.Location = new System.Drawing.Point(413, 3);
            this.but_Pause.Name = "but_Pause";
            this.but_Pause.Size = new System.Drawing.Size(31, 29);
            this.but_Pause.TabIndex = 1;
            this.toolTip1.SetToolTip(this.but_Pause, "暂停");
            this.but_Pause.UseVisualStyleBackColor = false;
            this.but_Pause.Click += new System.EventHandler(this.but_Pause_Click);
            // 
            // but_Play
            // 
            this.but_Play.BackColor = System.Drawing.Color.Transparent;
            this.but_Play.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("but_Play.BackgroundImage")));
            this.but_Play.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.but_Play.Dock = System.Windows.Forms.DockStyle.Right;
            this.but_Play.Location = new System.Drawing.Point(376, 3);
            this.but_Play.Name = "but_Play";
            this.but_Play.Size = new System.Drawing.Size(31, 29);
            this.but_Play.TabIndex = 0;
            this.toolTip1.SetToolTip(this.but_Play, "播放");
            this.but_Play.UseVisualStyleBackColor = false;
            this.but_Play.Click += new System.EventHandler(this.but_Play_Click);
            // 
            // vlcControl
            // 
            this.vlcControl.BackColor = System.Drawing.Color.Black;
            this.vlcControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vlcControl.Location = new System.Drawing.Point(0, 0);
            this.vlcControl.Name = "vlcControl";
            this.vlcControl.Size = new System.Drawing.Size(829, 565);
            this.vlcControl.Spu = -1;
            this.vlcControl.TabIndex = 0;
            this.vlcControl.Text = "vlcControl1";
            this.vlcControl.VlcLibDirectory = null;
            this.vlcControl.VlcMediaplayerOptions = null;
            this.vlcControl.VlcLibDirectoryNeeded += new System.EventHandler<Vlc.DotNet.Forms.VlcLibDirectoryNeededEventArgs>(this.vlcControl_VlcLibDirectoryNeeded);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FormOperateInstruct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 567);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormOperateInstruct";
            this.Text = "操作视频";
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vlcControl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Vlc.DotNet.Forms.VlcControl vlcControl;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button but_Play;
        private System.Windows.Forms.Button but_Pause;
        private System.Windows.Forms.Label label_nowTime;
        private System.Windows.Forms.Label label_totalTime;
        private System.Windows.Forms.TrackBar trackBar;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Label label3;
    }
}
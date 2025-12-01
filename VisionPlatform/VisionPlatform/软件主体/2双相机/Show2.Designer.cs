
namespace VisionPlatform
{
    partial class Show2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Show2));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.清除 = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tLPanel_CamShow = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tLPanel_tool = new System.Windows.Forms.TableLayoutPanel();
            this.panel_Message = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ctrlCamShow2 = new VisionPlatform.CtrlCamShow();
            this.ctrlCamShow1 = new VisionPlatform.CtrlCamShow();
            this.but_run1 = new VisionPlatform.but_run();
            this.ctrlImageSave = new VisionPlatform.CtrlImageSave();
            this.contextMenuStrip1.SuspendLayout();
            this.tLPanel_CamShow.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tLPanel_tool.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            // 
            // 清除
            // 
            this.清除.Name = "清除";
            resources.ApplyResources(this.清除, "清除");
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.清除});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            resources.ApplyResources(this.contextMenuStrip1, "contextMenuStrip1");
            this.contextMenuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip1_ItemClicked);
            // 
            // tLPanel_CamShow
            // 
            this.tLPanel_CamShow.BackColor = System.Drawing.Color.LightSteelBlue;
            resources.ApplyResources(this.tLPanel_CamShow, "tLPanel_CamShow");
            this.tLPanel_CamShow.Controls.Add(this.panel2, 1, 0);
            this.tLPanel_CamShow.Controls.Add(this.panel1, 0, 0);
            this.tLPanel_CamShow.Name = "tLPanel_CamShow";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add(this.ctrlCamShow2);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.ctrlCamShow1);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // tLPanel_tool
            // 
            this.tLPanel_tool.BackColor = System.Drawing.Color.LightSteelBlue;
            resources.ApplyResources(this.tLPanel_tool, "tLPanel_tool");
            this.tLPanel_tool.Controls.Add(this.but_run1, 0, 0);
            this.tLPanel_tool.Controls.Add(this.ctrlImageSave, 3, 0);
            this.tLPanel_tool.Controls.Add(this.panel_Message, 2, 0);
            this.tLPanel_tool.Name = "tLPanel_tool";
            // 
            // panel_Message
            // 
            resources.ApplyResources(this.panel_Message, "panel_Message");
            this.panel_Message.Name = "panel_Message";
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.tLPanel_CamShow, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tLPanel_tool, 0, 1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // ctrlCamShow2
            // 
            resources.ApplyResources(this.ctrlCamShow2, "ctrlCamShow2");
            this.ctrlCamShow2.Name = "ctrlCamShow2";
            // 
            // ctrlCamShow1
            // 
            resources.ApplyResources(this.ctrlCamShow1, "ctrlCamShow1");
            this.ctrlCamShow1.Name = "ctrlCamShow1";
            // 
            // but_run1
            // 
            resources.ApplyResources(this.but_run1, "but_run1");
            this.but_run1.Name = "but_run1";
            // 
            // ctrlImageSave
            // 
            this.ctrlImageSave.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.ctrlImageSave, "ctrlImageSave");
            this.ctrlImageSave.Name = "ctrlImageSave";
            // 
            // Show2
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Show2";
            this.Load += new System.EventHandler(this.Show2_Load);
            this.SizeChanged += new System.EventHandler(this.Show2_SizeChanged);
            this.contextMenuStrip1.ResumeLayout(false);
            this.tLPanel_CamShow.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tLPanel_tool.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem 清除;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        public System.Windows.Forms.TableLayoutPanel tLPanel_CamShow;
        public System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tLPanel_tool;
        public CtrlCamShow ctrlCamShow2;
        public CtrlCamShow ctrlCamShow1;
        private but_run but_run1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private CtrlImageSave ctrlImageSave;
        private System.Windows.Forms.Panel panel_Message;
    }
}
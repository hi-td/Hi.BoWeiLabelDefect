
namespace VisionPlatform
{
    partial class Show1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Show1));
            this.tLPanel_Run = new System.Windows.Forms.TableLayoutPanel();
            this.tLPanel_CamShow = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.清除 = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tLPanel = new System.Windows.Forms.TableLayoutPanel();
            this.panel_Message = new System.Windows.Forms.Panel();
            this.ctrlImageSave = new VisionPlatform.CtrlImageSave();
            this.ctrlCamShow1 = new VisionPlatform.CtrlCamShow();
            this.but_run = new VisionPlatform.but_run();
            this.tLPanel_Run.SuspendLayout();
            this.tLPanel_CamShow.SuspendLayout();
            this.panel1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tLPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tLPanel_Run
            // 
            resources.ApplyResources(this.tLPanel_Run, "tLPanel_Run");
            this.tLPanel_Run.Controls.Add(this.ctrlImageSave, 2, 0);
            this.tLPanel_Run.Controls.Add(this.but_run, 0, 0);
            this.tLPanel_Run.Name = "tLPanel_Run";
            // 
            // tLPanel_CamShow
            // 
            resources.ApplyResources(this.tLPanel_CamShow, "tLPanel_CamShow");
            this.tLPanel_CamShow.Controls.Add(this.panel1, 0, 0);
            this.tLPanel_CamShow.Name = "tLPanel_CamShow";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.ctrlCamShow1);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.清除});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            resources.ApplyResources(this.contextMenuStrip1, "contextMenuStrip1");
            this.contextMenuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip1_ItemClicked);
            // 
            // 清除
            // 
            resources.ApplyResources(this.清除, "清除");
            this.清除.Name = "清除";
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.tLPanel_CamShow, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tLPanel, 0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // tLPanel
            // 
            resources.ApplyResources(this.tLPanel, "tLPanel");
            this.tLPanel.Controls.Add(this.tLPanel_Run, 0, 0);
            this.tLPanel.Controls.Add(this.panel_Message, 0, 2);
            this.tLPanel.Name = "tLPanel";
            // 
            // panel_Message
            // 
            resources.ApplyResources(this.panel_Message, "panel_Message");
            this.panel_Message.Name = "panel_Message";
            // 
            // ctrlImageSave
            // 
            this.ctrlImageSave.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.ctrlImageSave, "ctrlImageSave");
            this.ctrlImageSave.Name = "ctrlImageSave";
            // 
            // ctrlCamShow1
            // 
            resources.ApplyResources(this.ctrlCamShow1, "ctrlCamShow1");
            this.ctrlCamShow1.Name = "ctrlCamShow1";
            // 
            // but_run
            // 
            resources.ApplyResources(this.but_run, "but_run");
            this.but_run.Name = "but_run";
            // 
            // Show1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Show1";
            this.Load += new System.EventHandler(this.Show1_Load);
            this.SizeChanged += new System.EventHandler(this.Show1_SizeChanged);
            this.tLPanel_Run.ResumeLayout(false);
            this.tLPanel_CamShow.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tLPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 清除;
        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.TableLayoutPanel tLPanel_CamShow;
        private System.Windows.Forms.TableLayoutPanel tLPanel_Run;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tLPanel;
        public System.Windows.Forms.Panel panel_Message;
        private CtrlImageSave ctrlImageSave;
        private but_run but_run;
        public CtrlCamShow ctrlCamShow1;
    }
}
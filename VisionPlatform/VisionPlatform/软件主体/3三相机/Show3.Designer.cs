
namespace VisionPlatform
{
    partial class Show3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Show3));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tLPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel_Message = new System.Windows.Forms.Panel();
            this.but_run = new VisionPlatform.but_run();
            this.ctrlImageSave = new VisionPlatform.CtrlImageSave();
            this.ctrlOK_NG = new VisionPlatform.CtrlOK_NG();
            this.tLPanel_CamShow = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ctrlCamShow1 = new VisionPlatform.CtrlCamShow();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ctrlCamShow2 = new VisionPlatform.CtrlCamShow();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ctrlCamShow3 = new VisionPlatform.CtrlCamShow();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tLPanel1.SuspendLayout();
            this.tLPanel_CamShow.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            resources.ApplyResources(this.contextMenuStrip1, "contextMenuStrip1");
            this.contextMenuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip1_ItemClicked);
            // 
            // tLPanel1
            // 
            resources.ApplyResources(this.tLPanel1, "tLPanel1");
            this.tLPanel1.Controls.Add(this.panel_Message, 3, 0);
            this.tLPanel1.Controls.Add(this.but_run, 0, 0);
            this.tLPanel1.Controls.Add(this.ctrlImageSave, 4, 0);
            this.tLPanel1.Controls.Add(this.ctrlOK_NG, 2, 0);
            this.tLPanel1.Name = "tLPanel1";
            // 
            // panel_Message
            // 
            resources.ApplyResources(this.panel_Message, "panel_Message");
            this.panel_Message.Name = "panel_Message";
            // 
            // but_run
            // 
            resources.ApplyResources(this.but_run, "but_run");
            this.but_run.Name = "but_run";
            // 
            // ctrlImageSave
            // 
            this.ctrlImageSave.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.ctrlImageSave, "ctrlImageSave");
            this.ctrlImageSave.Name = "ctrlImageSave";
            // 
            // ctrlOK_NG
            // 
            resources.ApplyResources(this.ctrlOK_NG, "ctrlOK_NG");
            this.ctrlOK_NG.Name = "ctrlOK_NG";
            // 
            // tLPanel_CamShow
            // 
            resources.ApplyResources(this.tLPanel_CamShow, "tLPanel_CamShow");
            this.tLPanel_CamShow.Controls.Add(this.panel1, 0, 0);
            this.tLPanel_CamShow.Controls.Add(this.panel2, 1, 0);
            this.tLPanel_CamShow.Controls.Add(this.panel3, 2, 0);
            this.tLPanel_CamShow.Name = "tLPanel_CamShow";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.ctrlCamShow1);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // ctrlCamShow1
            // 
            resources.ApplyResources(this.ctrlCamShow1, "ctrlCamShow1");
            this.ctrlCamShow1.Name = "ctrlCamShow1";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add(this.ctrlCamShow2);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // ctrlCamShow2
            // 
            resources.ApplyResources(this.ctrlCamShow2, "ctrlCamShow2");
            this.ctrlCamShow2.Name = "ctrlCamShow2";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.Controls.Add(this.ctrlCamShow3);
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.Name = "panel3";
            // 
            // ctrlCamShow3
            // 
            resources.ApplyResources(this.ctrlCamShow3, "ctrlCamShow3");
            this.ctrlCamShow3.Name = "ctrlCamShow3";
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.tLPanel_CamShow, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tLPanel1, 0, 1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // Show3
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Show3";
            this.Load += new System.EventHandler(this.Show3_Load);
            this.tLPanel1.ResumeLayout(false);
            this.tLPanel_CamShow.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TableLayoutPanel tLPanel1;
        public System.Windows.Forms.TableLayoutPanel tLPanel_CamShow;
        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel_Message;
        private but_run but_run;
        public CtrlCamShow ctrlCamShow1;
        public CtrlCamShow ctrlCamShow2;
        public CtrlCamShow ctrlCamShow3;
        private CtrlImageSave ctrlImageSave;
        private CtrlOK_NG ctrlOK_NG;
    }
}
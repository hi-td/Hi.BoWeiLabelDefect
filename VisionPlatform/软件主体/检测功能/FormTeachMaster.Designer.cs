
namespace VisionPlatform
{
    partial class FormTeachMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTeachMaster));
            this.panel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label_SelCam = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel_message = new System.Windows.Forms.Panel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.treeViewFun = new System.Windows.Forms.TreeView();
            this.panelWindow = new System.Windows.Forms.Panel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem_Add = new System.Windows.Forms.ToolStripMenuItem();
            this.正面检测 = new System.Windows.Forms.ToolStripMenuItem();
            this.背面检测 = new System.Windows.Forms.ToolStripMenuItem();
            this.顶面检测 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.ts_But_close = new System.Windows.Forms.ToolStripButton();
            this.ts_Label_cam = new System.Windows.Forms.ToolStripLabel();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.SystemColors.Control;
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 20);
            this.panel.Margin = new System.Windows.Forms.Padding(0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(237, 395);
            this.panel.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label_SelCam, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(130, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(237, 415);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label_SelCam
            // 
            this.label_SelCam.AutoSize = true;
            this.label_SelCam.BackColor = System.Drawing.Color.LightSteelBlue;
            this.label_SelCam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_SelCam.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold);
            this.label_SelCam.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label_SelCam.Location = new System.Drawing.Point(0, 0);
            this.label_SelCam.Margin = new System.Windows.Forms.Padding(0);
            this.label_SelCam.Name = "label_SelCam";
            this.label_SelCam.Size = new System.Drawing.Size(237, 20);
            this.label_SelCam.TabIndex = 3;
            this.label_SelCam.Text = "相机";
            this.label_SelCam.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panelWindow);
            this.splitContainer1.Size = new System.Drawing.Size(1026, 620);
            this.splitContainer1.SplitterDistance = 371;
            this.splitContainer1.TabIndex = 6;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.panel_message, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(369, 618);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // panel_message
            // 
            this.panel_message.BackColor = System.Drawing.SystemColors.Control;
            this.panel_message.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_message.Location = new System.Drawing.Point(1, 420);
            this.panel_message.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.panel_message.Name = "panel_message";
            this.panel_message.Size = new System.Drawing.Size(367, 197);
            this.panel_message.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.treeViewFun, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel1, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(1, 1);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(367, 415);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // treeViewFun
            // 
            this.treeViewFun.BackColor = System.Drawing.Color.LightSteelBlue;
            this.treeViewFun.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.treeViewFun.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewFun.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.treeViewFun.Location = new System.Drawing.Point(0, 0);
            this.treeViewFun.Margin = new System.Windows.Forms.Padding(0);
            this.treeViewFun.Name = "treeViewFun";
            this.treeViewFun.Size = new System.Drawing.Size(130, 415);
            this.treeViewFun.TabIndex = 1;
            this.treeViewFun.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeViewFun_AfterSelect);
            this.treeViewFun.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeViewFun_MouseDown);
            // 
            // panelWindow
            // 
            this.panelWindow.BackColor = System.Drawing.SystemColors.Control;
            this.panelWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelWindow.Location = new System.Drawing.Point(0, 0);
            this.panelWindow.Name = "panelWindow";
            this.panelWindow.Size = new System.Drawing.Size(649, 618);
            this.panelWindow.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_Add});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 48);
            // 
            // toolStripMenuItem_Add
            // 
            this.toolStripMenuItem_Add.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.正面检测,
            this.背面检测,
            this.顶面检测});
            this.toolStripMenuItem_Add.Name = "toolStripMenuItem_Add";
            this.toolStripMenuItem_Add.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem_Add.Text = "添加";
            // 
            // 正面检测
            // 
            this.正面检测.Name = "正面检测";
            this.正面检测.Size = new System.Drawing.Size(180, 22);
            this.正面检测.Text = "正面检测";
            this.正面检测.Click += new System.EventHandler(this.AddCheckItem);
            // 
            // 背面检测
            // 
            this.背面检测.Name = "背面检测";
            this.背面检测.Size = new System.Drawing.Size(180, 22);
            this.背面检测.Text = "背面检测";
            this.背面检测.Click += new System.EventHandler(this.AddCheckItem);
            // 
            // 顶面检测
            // 
            this.顶面检测.Name = "顶面检测";
            this.顶面检测.Size = new System.Drawing.Size(180, 22);
            this.顶面检测.Text = "顶面检测";
            this.顶面检测.Click += new System.EventHandler(this.AddCheckItem);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ts_But_close,
            this.ts_Label_cam});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1026, 25);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // ts_But_close
            // 
            this.ts_But_close.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.ts_But_close.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ts_But_close.Image = ((System.Drawing.Image)(resources.GetObject("ts_But_close.Image")));
            this.ts_But_close.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ts_But_close.Name = "ts_But_close";
            this.ts_But_close.Size = new System.Drawing.Size(23, 22);
            this.ts_But_close.Text = "关闭";
            this.ts_But_close.Click += new System.EventHandler(this.ts_But_close_Click);
            // 
            // ts_Label_cam
            // 
            this.ts_Label_cam.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.ts_Label_cam.ForeColor = System.Drawing.Color.MidnightBlue;
            this.ts_Label_cam.Name = "ts_Label_cam";
            this.ts_Label_cam.Size = new System.Drawing.Size(32, 22);
            this.ts_Label_cam.Text = "相机";
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(61, 4);
            this.contextMenuStrip2.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.ContextMenuStrip2_ItemClicked);
            // 
            // FormTeachMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(1026, 645);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormTeachMaster";
            this.Text = "Teachmaster";
            this.Load += new System.EventHandler(this.Teachmaster_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panelWindow;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Add;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel_message;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton ts_But_close;
        private System.Windows.Forms.ToolStripLabel ts_Label_cam;
        private System.Windows.Forms.TreeView treeViewFun;
        private System.Windows.Forms.Label label_SelCam;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.ToolStripMenuItem 正面检测;
        private System.Windows.Forms.ToolStripMenuItem 背面检测;
        private System.Windows.Forms.ToolStripMenuItem 顶面检测;
    }
}
namespace VisionPlatform
{
    partial class CtrlCamShow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtrlCamShow));
            this.panel2 = new System.Windows.Forms.Panel();
            this.but_PhotometricsStereo = new System.Windows.Forms.Button();
            this.checkBox_CenterCross = new System.Windows.Forms.CheckBox();
            this.but_ImageList = new System.Windows.Forms.Button();
            this.but_LoadImage = new System.Windows.Forms.Button();
            this.but_RecoverImg = new System.Windows.Forms.Button();
            this.but_SaveImg = new System.Windows.Forms.Button();
            this.but_GrabImage = new System.Windows.Forms.Button();
            this.but_Live = new System.Windows.Forms.Button();
            this.label_x = new System.Windows.Forms.Label();
            this.label_d = new System.Windows.Forms.Label();
            this.label_Edit = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.label_Cam = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.ts_Label_CamSer = new System.Windows.Forms.ToolStripLabel();
            this.ts_Label_state = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel_pos = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel_gray = new System.Windows.Forms.ToolStripLabel();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox_ImageList = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.listView_ImgList = new System.Windows.Forms.ListView();
            this.but_PreImage = new System.Windows.Forms.Button();
            this.but_NextImage = new System.Windows.Forms.Button();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.ts_But_ImageListClose = new System.Windows.Forms.ToolStripButton();
            this.tsBut_LoadOK = new System.Windows.Forms.ToolStripButton();
            this.tsBut_LoadNG = new System.Windows.Forms.ToolStripButton();
            this.tsBut_LoadFile = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel_hWnd = new System.Windows.Forms.Panel();
            this.hWndCtrl = new HalconDotNet.HWindowControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.关联相机 = new System.Windows.Forms.ToolStripMenuItem();
            this.画质调节 = new System.Windows.Forms.ToolStripMenuItem();
            this.绘制 = new System.Windows.Forms.ToolStripMenuItem();
            this.矩形1 = new System.Windows.Forms.ToolStripMenuItem();
            this.矩形2带方向 = new System.Windows.Forms.ToolStripMenuItem();
            this.圆 = new System.Windows.Forms.ToolStripMenuItem();
            this.任意形状 = new System.Windows.Forms.ToolStripMenuItem();
            this.直线 = new System.Windows.Forms.ToolStripMenuItem();
            this.显示设置 = new System.Windows.Forms.ToolStripMenuItem();
            this.图像镜像 = new System.Windows.Forms.ToolStripMenuItem();
            this.LoR = new System.Windows.Forms.ToolStripMenuItem();
            this.UoD = new System.Windows.Forms.ToolStripMenuItem();
            this.清除 = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.panel2.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.groupBox_ImageList.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.toolStrip3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel_hWnd.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Controls.Add(this.but_PhotometricsStereo);
            this.panel2.Controls.Add(this.checkBox_CenterCross);
            this.panel2.Controls.Add(this.but_ImageList);
            this.panel2.Controls.Add(this.but_LoadImage);
            this.panel2.Controls.Add(this.but_RecoverImg);
            this.panel2.Controls.Add(this.but_SaveImg);
            this.panel2.Controls.Add(this.but_GrabImage);
            this.panel2.Controls.Add(this.but_Live);
            this.panel2.Controls.Add(this.label_x);
            this.panel2.Controls.Add(this.label_d);
            this.panel2.Controls.Add(this.label_Edit);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(705, 57);
            this.panel2.TabIndex = 2;
            // 
            // but_PhotometricsStereo
            // 
            this.but_PhotometricsStereo.BackColor = System.Drawing.Color.Transparent;
            this.but_PhotometricsStereo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.but_PhotometricsStereo.Dock = System.Windows.Forms.DockStyle.Left;
            this.but_PhotometricsStereo.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.but_PhotometricsStereo.FlatAppearance.BorderSize = 0;
            this.but_PhotometricsStereo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.but_PhotometricsStereo.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.but_PhotometricsStereo.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.but_PhotometricsStereo.Image = ((System.Drawing.Image)(resources.GetObject("but_PhotometricsStereo.Image")));
            this.but_PhotometricsStereo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.but_PhotometricsStereo.Location = new System.Drawing.Point(406, 0);
            this.but_PhotometricsStereo.Name = "but_PhotometricsStereo";
            this.but_PhotometricsStereo.Size = new System.Drawing.Size(64, 57);
            this.but_PhotometricsStereo.TabIndex = 11;
            this.but_PhotometricsStereo.Text = "光度立体";
            this.but_PhotometricsStereo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.but_PhotometricsStereo.UseVisualStyleBackColor = false;
            this.but_PhotometricsStereo.Click += new System.EventHandler(this.but_PhotometricsStereo_Click);
            // 
            // checkBox_CenterCross
            // 
            this.checkBox_CenterCross.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.checkBox_CenterCross.Dock = System.Windows.Forms.DockStyle.Left;
            this.checkBox_CenterCross.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox_CenterCross.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox_CenterCross.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.checkBox_CenterCross.Image = ((System.Drawing.Image)(resources.GetObject("checkBox_CenterCross.Image")));
            this.checkBox_CenterCross.Location = new System.Drawing.Point(346, 0);
            this.checkBox_CenterCross.Name = "checkBox_CenterCross";
            this.checkBox_CenterCross.Size = new System.Drawing.Size(60, 57);
            this.checkBox_CenterCross.TabIndex = 10;
            this.checkBox_CenterCross.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolTip1.SetToolTip(this.checkBox_CenterCross, "图像中心十字线");
            this.checkBox_CenterCross.UseVisualStyleBackColor = true;
            this.checkBox_CenterCross.CheckedChanged += new System.EventHandler(this.checkBox_CenterCross_CheckedChanged);
            // 
            // but_ImageList
            // 
            this.but_ImageList.BackColor = System.Drawing.Color.Transparent;
            this.but_ImageList.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.but_ImageList.Dock = System.Windows.Forms.DockStyle.Left;
            this.but_ImageList.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.but_ImageList.FlatAppearance.BorderSize = 0;
            this.but_ImageList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.but_ImageList.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.but_ImageList.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.but_ImageList.Image = ((System.Drawing.Image)(resources.GetObject("but_ImageList.Image")));
            this.but_ImageList.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.but_ImageList.Location = new System.Drawing.Point(282, 0);
            this.but_ImageList.Name = "but_ImageList";
            this.but_ImageList.Size = new System.Drawing.Size(64, 57);
            this.but_ImageList.TabIndex = 8;
            this.but_ImageList.Text = "批量测试";
            this.but_ImageList.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.but_ImageList.UseVisualStyleBackColor = false;
            this.but_ImageList.Click += new System.EventHandler(this.but_ImageList_Click);
            // 
            // but_LoadImage
            // 
            this.but_LoadImage.BackColor = System.Drawing.Color.Transparent;
            this.but_LoadImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.but_LoadImage.Dock = System.Windows.Forms.DockStyle.Left;
            this.but_LoadImage.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.but_LoadImage.FlatAppearance.BorderSize = 0;
            this.but_LoadImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.but_LoadImage.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.but_LoadImage.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.but_LoadImage.Image = ((System.Drawing.Image)(resources.GetObject("but_LoadImage.Image")));
            this.but_LoadImage.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.but_LoadImage.Location = new System.Drawing.Point(218, 0);
            this.but_LoadImage.Name = "but_LoadImage";
            this.but_LoadImage.Size = new System.Drawing.Size(64, 57);
            this.but_LoadImage.TabIndex = 7;
            this.but_LoadImage.Text = "导入图像";
            this.but_LoadImage.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.but_LoadImage.UseVisualStyleBackColor = false;
            this.but_LoadImage.Click += new System.EventHandler(this.but_LoadImage_Click);
            // 
            // but_RecoverImg
            // 
            this.but_RecoverImg.BackColor = System.Drawing.Color.Transparent;
            this.but_RecoverImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.but_RecoverImg.Dock = System.Windows.Forms.DockStyle.Left;
            this.but_RecoverImg.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.but_RecoverImg.FlatAppearance.BorderSize = 0;
            this.but_RecoverImg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.but_RecoverImg.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.but_RecoverImg.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.but_RecoverImg.Image = ((System.Drawing.Image)(resources.GetObject("but_RecoverImg.Image")));
            this.but_RecoverImg.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.but_RecoverImg.Location = new System.Drawing.Point(154, 0);
            this.but_RecoverImg.Name = "but_RecoverImg";
            this.but_RecoverImg.Size = new System.Drawing.Size(64, 57);
            this.but_RecoverImg.TabIndex = 6;
            this.but_RecoverImg.Text = "原图比例";
            this.but_RecoverImg.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.but_RecoverImg.UseVisualStyleBackColor = false;
            this.but_RecoverImg.Click += new System.EventHandler(this.but_RecoverImg_Click);
            // 
            // but_SaveImg
            // 
            this.but_SaveImg.BackColor = System.Drawing.Color.Transparent;
            this.but_SaveImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.but_SaveImg.Dock = System.Windows.Forms.DockStyle.Left;
            this.but_SaveImg.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.but_SaveImg.FlatAppearance.BorderSize = 0;
            this.but_SaveImg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.but_SaveImg.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.but_SaveImg.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.but_SaveImg.Image = ((System.Drawing.Image)(resources.GetObject("but_SaveImg.Image")));
            this.but_SaveImg.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.but_SaveImg.Location = new System.Drawing.Point(90, 0);
            this.but_SaveImg.Name = "but_SaveImg";
            this.but_SaveImg.Size = new System.Drawing.Size(64, 57);
            this.but_SaveImg.TabIndex = 5;
            this.but_SaveImg.Text = "保存图像";
            this.but_SaveImg.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.but_SaveImg.UseVisualStyleBackColor = false;
            this.but_SaveImg.Click += new System.EventHandler(this.but_SaveImg_Click);
            // 
            // but_GrabImage
            // 
            this.but_GrabImage.BackColor = System.Drawing.Color.Transparent;
            this.but_GrabImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.but_GrabImage.Dock = System.Windows.Forms.DockStyle.Left;
            this.but_GrabImage.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.but_GrabImage.FlatAppearance.BorderSize = 0;
            this.but_GrabImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.but_GrabImage.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.but_GrabImage.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.but_GrabImage.Image = ((System.Drawing.Image)(resources.GetObject("but_GrabImage.Image")));
            this.but_GrabImage.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.but_GrabImage.Location = new System.Drawing.Point(45, 0);
            this.but_GrabImage.Name = "but_GrabImage";
            this.but_GrabImage.Size = new System.Drawing.Size(45, 57);
            this.but_GrabImage.TabIndex = 4;
            this.but_GrabImage.Text = "拍照";
            this.but_GrabImage.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.but_GrabImage.UseVisualStyleBackColor = false;
            this.but_GrabImage.Click += new System.EventHandler(this.but_GrabImage_Click);
            // 
            // but_Live
            // 
            this.but_Live.BackColor = System.Drawing.Color.Transparent;
            this.but_Live.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.but_Live.Dock = System.Windows.Forms.DockStyle.Left;
            this.but_Live.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.but_Live.FlatAppearance.BorderSize = 0;
            this.but_Live.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.but_Live.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.but_Live.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.but_Live.Image = ((System.Drawing.Image)(resources.GetObject("but_Live.Image")));
            this.but_Live.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.but_Live.Location = new System.Drawing.Point(0, 0);
            this.but_Live.Name = "but_Live";
            this.but_Live.Size = new System.Drawing.Size(45, 57);
            this.but_Live.TabIndex = 0;
            this.but_Live.Text = "实时";
            this.but_Live.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.but_Live.UseVisualStyleBackColor = false;
            this.but_Live.Click += new System.EventHandler(this.but_Live_Click);
            // 
            // label_x
            // 
            this.label_x.AutoSize = true;
            this.label_x.Dock = System.Windows.Forms.DockStyle.Right;
            this.label_x.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.label_x.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label_x.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_x.Location = new System.Drawing.Point(594, 0);
            this.label_x.Name = "label_x";
            this.label_x.Size = new System.Drawing.Size(37, 19);
            this.label_x.TabIndex = 3;
            this.label_x.Text = "缩小";
            this.label_x.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_x.Visible = false;
            this.label_x.Click += new System.EventHandler(this.label_x_Click);
            // 
            // label_d
            // 
            this.label_d.AutoSize = true;
            this.label_d.Dock = System.Windows.Forms.DockStyle.Right;
            this.label_d.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.label_d.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label_d.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_d.Location = new System.Drawing.Point(631, 0);
            this.label_d.Name = "label_d";
            this.label_d.Size = new System.Drawing.Size(37, 19);
            this.label_d.TabIndex = 2;
            this.label_d.Text = "放大";
            this.label_d.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_d.Visible = false;
            this.label_d.Click += new System.EventHandler(this.label_d_Click);
            // 
            // label_Edit
            // 
            this.label_Edit.AutoSize = true;
            this.label_Edit.BackColor = System.Drawing.Color.Transparent;
            this.label_Edit.Dock = System.Windows.Forms.DockStyle.Right;
            this.label_Edit.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold);
            this.label_Edit.ForeColor = System.Drawing.Color.White;
            this.label_Edit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_Edit.Location = new System.Drawing.Point(668, 0);
            this.label_Edit.Name = "label_Edit";
            this.label_Edit.Size = new System.Drawing.Size(37, 19);
            this.label_Edit.TabIndex = 9;
            this.label_Edit.Text = "编辑";
            this.label_Edit.Click += new System.EventHandler(this.label_Edit_Click);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(64, 64);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // toolStrip2
            // 
            this.toolStrip2.BackColor = System.Drawing.Color.Black;
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.label_Cam,
            this.toolStripSeparator3,
            this.ts_Label_CamSer,
            this.ts_Label_state,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.toolStripLabel_pos,
            this.toolStripSeparator2,
            this.toolStripLabel2,
            this.toolStripLabel_gray});
            this.toolStrip2.Location = new System.Drawing.Point(0, 516);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(705, 25);
            this.toolStrip2.TabIndex = 1;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // label_Cam
            // 
            this.label_Cam.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.label_Cam.ForeColor = System.Drawing.Color.White;
            this.label_Cam.Name = "label_Cam";
            this.label_Cam.Size = new System.Drawing.Size(32, 22);
            this.label_Cam.Text = "相机";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // ts_Label_CamSer
            // 
            this.ts_Label_CamSer.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.ts_Label_CamSer.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ts_Label_CamSer.Name = "ts_Label_CamSer";
            this.ts_Label_CamSer.Size = new System.Drawing.Size(44, 22);
            this.ts_Label_CamSer.Text = "序号：";
            // 
            // ts_Label_state
            // 
            this.ts_Label_state.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.ts_Label_state.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.ts_Label_state.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ts_Label_state.Name = "ts_Label_state";
            this.ts_Label_state.Size = new System.Drawing.Size(68, 22);
            this.ts_Label_state.Text = "当前状态：";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripLabel1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(44, 22);
            this.toolStripLabel1.Text = "坐标：";
            // 
            // toolStripLabel_pos
            // 
            this.toolStripLabel_pos.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripLabel_pos.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.toolStripLabel_pos.Name = "toolStripLabel_pos";
            this.toolStripLabel_pos.Size = new System.Drawing.Size(32, 22);
            this.toolStripLabel_pos.Text = "*，*";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripLabel2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(56, 22);
            this.toolStripLabel2.Text = "灰度值：";
            // 
            // toolStripLabel_gray
            // 
            this.toolStripLabel_gray.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripLabel_gray.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.toolStripLabel_gray.Name = "toolStripLabel_gray";
            this.toolStripLabel_gray.Size = new System.Drawing.Size(14, 22);
            this.toolStripLabel_gray.Text = "*";
            // 
            // groupBox_ImageList
            // 
            this.groupBox_ImageList.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.groupBox_ImageList.Controls.Add(this.tableLayoutPanel1);
            this.groupBox_ImageList.Controls.Add(this.toolStrip3);
            this.groupBox_ImageList.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox_ImageList.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox_ImageList.Location = new System.Drawing.Point(705, 0);
            this.groupBox_ImageList.Name = "groupBox_ImageList";
            this.groupBox_ImageList.Size = new System.Drawing.Size(137, 541);
            this.groupBox_ImageList.TabIndex = 3;
            this.groupBox_ImageList.TabStop = false;
            this.groupBox_ImageList.Visible = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.listView_ImgList, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.but_PreImage, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.but_NextImage, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 42);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(131, 496);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // listView_ImgList
            // 
            this.listView_ImgList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView_ImgList.FullRowSelect = true;
            this.listView_ImgList.HideSelection = false;
            this.listView_ImgList.Location = new System.Drawing.Point(1, 24);
            this.listView_ImgList.Margin = new System.Windows.Forms.Padding(1);
            this.listView_ImgList.Name = "listView_ImgList";
            this.listView_ImgList.Size = new System.Drawing.Size(129, 448);
            this.listView_ImgList.TabIndex = 0;
            this.listView_ImgList.UseCompatibleStateImageBehavior = false;
            this.listView_ImgList.Click += new System.EventHandler(this.listView_ImgList_Click);
            // 
            // but_PreImage
            // 
            this.but_PreImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.but_PreImage.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.but_PreImage.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.but_PreImage.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.but_PreImage.Image = ((System.Drawing.Image)(resources.GetObject("but_PreImage.Image")));
            this.but_PreImage.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.but_PreImage.Location = new System.Drawing.Point(0, 0);
            this.but_PreImage.Margin = new System.Windows.Forms.Padding(0);
            this.but_PreImage.Name = "but_PreImage";
            this.but_PreImage.Size = new System.Drawing.Size(131, 23);
            this.but_PreImage.TabIndex = 0;
            this.but_PreImage.Text = "上一张";
            this.but_PreImage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.but_PreImage.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.but_PreImage.UseVisualStyleBackColor = true;
            this.but_PreImage.Click += new System.EventHandler(this.but_PreImage_Click);
            // 
            // but_NextImage
            // 
            this.but_NextImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.but_NextImage.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.but_NextImage.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.but_NextImage.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.but_NextImage.Image = ((System.Drawing.Image)(resources.GetObject("but_NextImage.Image")));
            this.but_NextImage.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.but_NextImage.Location = new System.Drawing.Point(0, 473);
            this.but_NextImage.Margin = new System.Windows.Forms.Padding(0);
            this.but_NextImage.Name = "but_NextImage";
            this.but_NextImage.Size = new System.Drawing.Size(131, 23);
            this.but_NextImage.TabIndex = 1;
            this.but_NextImage.Text = "下一张";
            this.but_NextImage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.but_NextImage.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.but_NextImage.UseVisualStyleBackColor = true;
            this.but_NextImage.Click += new System.EventHandler(this.but_NextImage_Click);
            // 
            // toolStrip3
            // 
            this.toolStrip3.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ts_But_ImageListClose,
            this.tsBut_LoadOK,
            this.tsBut_LoadNG,
            this.tsBut_LoadFile});
            this.toolStrip3.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip3.Location = new System.Drawing.Point(3, 17);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip3.Size = new System.Drawing.Size(131, 25);
            this.toolStrip3.TabIndex = 0;
            // 
            // ts_But_ImageListClose
            // 
            this.ts_But_ImageListClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.ts_But_ImageListClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ts_But_ImageListClose.Image = ((System.Drawing.Image)(resources.GetObject("ts_But_ImageListClose.Image")));
            this.ts_But_ImageListClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ts_But_ImageListClose.Name = "ts_But_ImageListClose";
            this.ts_But_ImageListClose.Size = new System.Drawing.Size(23, 22);
            this.ts_But_ImageListClose.ToolTipText = "关闭";
            this.ts_But_ImageListClose.Click += new System.EventHandler(this.ts_But_ImageListClose_Click);
            // 
            // tsBut_LoadOK
            // 
            this.tsBut_LoadOK.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBut_LoadOK.Image = ((System.Drawing.Image)(resources.GetObject("tsBut_LoadOK.Image")));
            this.tsBut_LoadOK.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBut_LoadOK.Name = "tsBut_LoadOK";
            this.tsBut_LoadOK.Size = new System.Drawing.Size(23, 22);
            this.tsBut_LoadOK.ToolTipText = "导入OK图";
            this.tsBut_LoadOK.Click += new System.EventHandler(this.tsBut_LoadOK_Click);
            // 
            // tsBut_LoadNG
            // 
            this.tsBut_LoadNG.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBut_LoadNG.Image = ((System.Drawing.Image)(resources.GetObject("tsBut_LoadNG.Image")));
            this.tsBut_LoadNG.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBut_LoadNG.Name = "tsBut_LoadNG";
            this.tsBut_LoadNG.Size = new System.Drawing.Size(23, 22);
            this.tsBut_LoadNG.ToolTipText = "导入NG图";
            this.tsBut_LoadNG.Click += new System.EventHandler(this.tsBut_LoadNG_Click);
            // 
            // tsBut_LoadFile
            // 
            this.tsBut_LoadFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBut_LoadFile.Image = ((System.Drawing.Image)(resources.GetObject("tsBut_LoadFile.Image")));
            this.tsBut_LoadFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBut_LoadFile.Name = "tsBut_LoadFile";
            this.tsBut_LoadFile.Size = new System.Drawing.Size(23, 22);
            this.tsBut_LoadFile.Text = "toolStripButton3";
            this.tsBut_LoadFile.ToolTipText = "导入其他路径";
            this.tsBut_LoadFile.Click += new System.EventHandler(this.tsBut_LoadFile_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel_hWnd);
            this.panel1.Controls.Add(this.groupBox_ImageList);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(842, 541);
            this.panel1.TabIndex = 5;
            // 
            // panel_hWnd
            // 
            this.panel_hWnd.Controls.Add(this.hWndCtrl);
            this.panel_hWnd.Controls.Add(this.panel2);
            this.panel_hWnd.Controls.Add(this.toolStrip2);
            this.panel_hWnd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_hWnd.Location = new System.Drawing.Point(0, 0);
            this.panel_hWnd.Name = "panel_hWnd";
            this.panel_hWnd.Size = new System.Drawing.Size(705, 541);
            this.panel_hWnd.TabIndex = 1;
            // 
            // hWndCtrl
            // 
            this.hWndCtrl.BackColor = System.Drawing.Color.Black;
            this.hWndCtrl.BorderColor = System.Drawing.Color.Black;
            this.hWndCtrl.ContextMenuStrip = this.contextMenuStrip1;
            this.hWndCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hWndCtrl.ImagePart = new System.Drawing.Rectangle(0, 0, 640, 480);
            this.hWndCtrl.Location = new System.Drawing.Point(0, 57);
            this.hWndCtrl.Name = "hWndCtrl";
            this.hWndCtrl.Size = new System.Drawing.Size(705, 459);
            this.hWndCtrl.TabIndex = 0;
            this.hWndCtrl.WindowSize = new System.Drawing.Size(705, 459);
            this.hWndCtrl.HMouseMove += new HalconDotNet.HMouseEventHandler(this.hWndCtrl_HMouseMove);
            this.hWndCtrl.HMouseDown += new HalconDotNet.HMouseEventHandler(this.hWndCtrl_HMouseDown);
            this.hWndCtrl.HMouseWheel += new HalconDotNet.HMouseEventHandler(this.hWndCtrl_HMouseWheel);
            this.hWndCtrl.Resize += new System.EventHandler(this.hWndCtrl_Resize);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.关联相机,
            this.画质调节,
            this.绘制,
            this.显示设置,
            this.清除});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 118);
            // 
            // 关联相机
            // 
            this.关联相机.Name = "关联相机";
            this.关联相机.Size = new System.Drawing.Size(152, 26);
            this.关联相机.Text = "关联相机";
            this.关联相机.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.关联相机_DropDownItemClicked);
            // 
            // 画质调节
            // 
            this.画质调节.AutoSize = false;
            this.画质调节.Image = ((System.Drawing.Image)(resources.GetObject("画质调节.Image")));
            this.画质调节.Name = "画质调节";
            this.画质调节.Size = new System.Drawing.Size(120, 22);
            this.画质调节.Text = "画质调节";
            this.画质调节.Click += new System.EventHandler(this.画质调节ToolStripMenuItem_Click);
            // 
            // 绘制
            // 
            this.绘制.AutoSize = false;
            this.绘制.BackColor = System.Drawing.SystemColors.Control;
            this.绘制.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.矩形1,
            this.矩形2带方向,
            this.圆,
            this.任意形状,
            this.直线});
            this.绘制.Image = ((System.Drawing.Image)(resources.GetObject("绘制.Image")));
            this.绘制.Name = "绘制";
            this.绘制.Size = new System.Drawing.Size(120, 22);
            this.绘制.Text = "绘制";
            // 
            // 矩形1
            // 
            this.矩形1.AutoSize = false;
            this.矩形1.Image = ((System.Drawing.Image)(resources.GetObject("矩形1.Image")));
            this.矩形1.Name = "矩形1";
            this.矩形1.Size = new System.Drawing.Size(130, 22);
            this.矩形1.Text = "矩形1";
            this.矩形1.Click += new System.EventHandler(this.矩形1_Click);
            // 
            // 矩形2带方向
            // 
            this.矩形2带方向.AutoSize = false;
            this.矩形2带方向.Image = ((System.Drawing.Image)(resources.GetObject("矩形2带方向.Image")));
            this.矩形2带方向.Name = "矩形2带方向";
            this.矩形2带方向.Size = new System.Drawing.Size(130, 22);
            this.矩形2带方向.Text = "矩形2（带方向）";
            this.矩形2带方向.Click += new System.EventHandler(this.矩形2带方向_Click);
            // 
            // 圆
            // 
            this.圆.AutoSize = false;
            this.圆.Image = ((System.Drawing.Image)(resources.GetObject("圆.Image")));
            this.圆.Name = "圆";
            this.圆.Size = new System.Drawing.Size(130, 22);
            this.圆.Text = "圆形";
            this.圆.Click += new System.EventHandler(this.圆_Click);
            // 
            // 任意形状
            // 
            this.任意形状.Image = ((System.Drawing.Image)(resources.GetObject("任意形状.Image")));
            this.任意形状.Name = "任意形状";
            this.任意形状.Size = new System.Drawing.Size(167, 22);
            this.任意形状.Text = "任意形状";
            this.任意形状.Click += new System.EventHandler(this.任意形状_Click);
            // 
            // 直线
            // 
            this.直线.AutoSize = false;
            this.直线.Image = ((System.Drawing.Image)(resources.GetObject("直线.Image")));
            this.直线.Name = "直线";
            this.直线.Size = new System.Drawing.Size(130, 22);
            this.直线.Text = "直线";
            this.直线.Click += new System.EventHandler(this.直线_Click);
            // 
            // 显示设置
            // 
            this.显示设置.AutoSize = false;
            this.显示设置.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.图像镜像});
            this.显示设置.Image = ((System.Drawing.Image)(resources.GetObject("显示设置.Image")));
            this.显示设置.Name = "显示设置";
            this.显示设置.Size = new System.Drawing.Size(120, 22);
            this.显示设置.Text = "显示设置";
            // 
            // 图像镜像
            // 
            this.图像镜像.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LoR,
            this.UoD});
            this.图像镜像.Image = ((System.Drawing.Image)(resources.GetObject("图像镜像.Image")));
            this.图像镜像.Name = "图像镜像";
            this.图像镜像.Size = new System.Drawing.Size(124, 22);
            this.图像镜像.Text = "图像镜像";
            // 
            // LoR
            // 
            this.LoR.Name = "LoR";
            this.LoR.Size = new System.Drawing.Size(124, 22);
            this.LoR.Text = "左右镜像";
            this.LoR.Click += new System.EventHandler(this.LeftRightImage_Click);
            // 
            // UoD
            // 
            this.UoD.Name = "UoD";
            this.UoD.Size = new System.Drawing.Size(124, 22);
            this.UoD.Text = "上下镜像";
            this.UoD.Click += new System.EventHandler(this.UpDownImage_Click);
            // 
            // 清除
            // 
            this.清除.AutoSize = false;
            this.清除.Image = ((System.Drawing.Image)(resources.GetObject("清除.Image")));
            this.清除.Name = "清除";
            this.清除.Size = new System.Drawing.Size(120, 22);
            this.清除.Text = "清除显示图形";
            this.清除.Click += new System.EventHandler(this.清除_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // CtrlCamShow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "CtrlCamShow";
            this.Size = new System.Drawing.Size(842, 541);
            this.Load += new System.EventHandler(this.CtrlCamShow_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.groupBox_ImageList.ResumeLayout(false);
            this.groupBox_ImageList.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel_hWnd.ResumeLayout(false);
            this.panel_hWnd.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button but_ImageList;
        private System.Windows.Forms.Button but_LoadImage;
        private System.Windows.Forms.Button but_RecoverImg;
        private System.Windows.Forms.Button but_SaveImg;
        private System.Windows.Forms.Button but_GrabImage;
        private System.Windows.Forms.Button but_Live;
        public System.Windows.Forms.Label label_x;
        public System.Windows.Forms.Label label_d;
        private System.Windows.Forms.Label label_Edit;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripLabel label_Cam;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripLabel ts_Label_CamSer;
        private System.Windows.Forms.ToolStripLabel ts_Label_state;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_pos;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_gray;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.GroupBox groupBox_ImageList;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListView listView_ImgList;
        private System.Windows.Forms.Button but_PreImage;
        private System.Windows.Forms.Button but_NextImage;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripButton ts_But_ImageListClose;
        private System.Windows.Forms.ToolStripButton tsBut_LoadOK;
        private System.Windows.Forms.ToolStripButton tsBut_LoadNG;
        private System.Windows.Forms.ToolStripButton tsBut_LoadFile;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel_hWnd;
        private HalconDotNet.HWindowControl hWndCtrl;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 关联相机;
        private System.Windows.Forms.ToolStripMenuItem 画质调节;
        private System.Windows.Forms.ToolStripMenuItem 绘制;
        private System.Windows.Forms.ToolStripMenuItem 矩形1;
        private System.Windows.Forms.ToolStripMenuItem 矩形2带方向;
        private System.Windows.Forms.ToolStripMenuItem 圆;
        private System.Windows.Forms.ToolStripMenuItem 任意形状;
        private System.Windows.Forms.ToolStripMenuItem 直线;
        private System.Windows.Forms.ToolStripMenuItem 显示设置;
        private System.Windows.Forms.ToolStripMenuItem 图像镜像;
        private System.Windows.Forms.ToolStripMenuItem LoR;
        private System.Windows.Forms.ToolStripMenuItem UoD;
        private System.Windows.Forms.ToolStripMenuItem 清除;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.CheckBox checkBox_CenterCross;
        private System.Windows.Forms.Button but_PhotometricsStereo;
    }
}

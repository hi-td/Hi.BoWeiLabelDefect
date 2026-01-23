using System.Windows.Forms;

namespace VisionPlatform.多线插.PLC交互窗口
{
    partial class Manual
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Manual));
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.hButton17 = new Hi.Ltd.Windows.Forms.HButton();
            this.hButton16 = new Hi.Ltd.Windows.Forms.HButton();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.hButton15 = new Hi.Ltd.Windows.Forms.HButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.hButton14 = new Hi.Ltd.Windows.Forms.HButton();
            this.hButton5 = new Hi.Ltd.Windows.Forms.HButton();
            this.hButton2 = new Hi.Ltd.Windows.Forms.HButton();
            this.hButton7 = new Hi.Ltd.Windows.Forms.HButton();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.hButton1 = new Hi.Ltd.Windows.Forms.HButton();
            this.hButton20 = new Hi.Ltd.Windows.Forms.HButton();
            this.hButton3 = new Hi.Ltd.Windows.Forms.HButton();
            this.hButton6 = new Hi.Ltd.Windows.Forms.HButton();
            this.hButton8 = new Hi.Ltd.Windows.Forms.HButton();
            this.hButton11 = new Hi.Ltd.Windows.Forms.HButton();
            this.hButton10 = new Hi.Ltd.Windows.Forms.HButton();
            this.hButton13 = new Hi.Ltd.Windows.Forms.HButton();
            this.hButton23 = new Hi.Ltd.Windows.Forms.HButton();
            this.hButton24 = new Hi.Ltd.Windows.Forms.HButton();
            this.hButton22 = new Hi.Ltd.Windows.Forms.HButton();
            this.hButton19 = new Hi.Ltd.Windows.Forms.HButton();
            this.hButton26 = new Hi.Ltd.Windows.Forms.HButton();
            this.hButton28 = new Hi.Ltd.Windows.Forms.HButton();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.hButton18 = new Hi.Ltd.Windows.Forms.HButton();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.hButton4 = new Hi.Ltd.Windows.Forms.HButton();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.hButton9 = new Hi.Ltd.Windows.Forms.HButton();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.hButton12 = new Hi.Ltd.Windows.Forms.HButton();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.hButton25 = new Hi.Ltd.Windows.Forms.HButton();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.hButton21 = new Hi.Ltd.Windows.Forms.HButton();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.hButton27 = new Hi.Ltd.Windows.Forms.HButton();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.hButton17);
            this.groupBox3.Controls.Add(this.hButton16);
            this.groupBox3.Controls.Add(this.textBox2);
            this.groupBox3.Controls.Add(this.hButton15);
            this.groupBox3.Controls.Add(this.textBox1);
            this.groupBox3.Controls.Add(this.hButton14);
            this.groupBox3.Controls.Add(this.hButton5);
            this.groupBox3.Controls.Add(this.hButton2);
            this.groupBox3.Controls.Add(this.hButton7);
            this.groupBox3.Controls.Add(this.textBox4);
            this.groupBox3.Controls.Add(this.label1);
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // hButton17
            // 
            this.hButton17.ActionType = Hi.Ltd.Enumerations.ActionType.Switch;
            this.hButton17.Address.DataType = Hi.Ltd.Enumerations.DataType.Int16;
            this.hButton17.Address.Length = ((ushort)(0));
            this.hButton17.BackColor = System.Drawing.SystemColors.Control;
            this.hButton17.FilletStyle = ((Hi.Ltd.Windows.Designs.FilletStyle)((((Hi.Ltd.Windows.Designs.FilletStyle.LeftTop | Hi.Ltd.Windows.Designs.FilletStyle.RightTop) 
            | Hi.Ltd.Windows.Designs.FilletStyle.RightBottom) 
            | Hi.Ltd.Windows.Designs.FilletStyle.LeftBottom)));
            this.hButton17.FlatAppearance.BorderSize = 0;
            this.hButton17.ForeColor = System.Drawing.SystemColors.ControlText;
            this.hButton17.Gradient.Angle = 0F;
            resources.ApplyResources(this.hButton17, "hButton17");
            this.hButton17.MaximumAddress.Enabled = false;
            this.hButton17.MaximumAddress.Length = ((ushort)(1));
            this.hButton17.MaximumValue = 99999999D;
            this.hButton17.MinimumAddress.Enabled = false;
            this.hButton17.MinimumAddress.Length = ((ushort)(1));
            this.hButton17.MinimumValue = 0D;
            this.hButton17.MonitorAddress.Enabled = false;
            this.hButton17.MonitorAddress.Length = ((ushort)(1));
            this.hButton17.Name = "hButton17";
            this.hButton17.NegationEnabled = false;
            this.hButton17.Radius = 0;
            this.hButton17.Rights = ((uint)(0u));
            this.hButton17.SetValue = 1;
            this.hButton17.Tag = "2034";
            this.hButton17.TouchEnabled = false;
            this.hButton17.UseVisualStyleBackColor = false;
            // 
            // hButton16
            // 
            this.hButton16.ActionType = Hi.Ltd.Enumerations.ActionType.Switch;
            this.hButton16.Address.DataType = Hi.Ltd.Enumerations.DataType.Int16;
            this.hButton16.Address.Length = ((ushort)(0));
            this.hButton16.BackColor = System.Drawing.SystemColors.Control;
            this.hButton16.FilletStyle = ((Hi.Ltd.Windows.Designs.FilletStyle)((((Hi.Ltd.Windows.Designs.FilletStyle.LeftTop | Hi.Ltd.Windows.Designs.FilletStyle.RightTop) 
            | Hi.Ltd.Windows.Designs.FilletStyle.RightBottom) 
            | Hi.Ltd.Windows.Designs.FilletStyle.LeftBottom)));
            this.hButton16.FlatAppearance.BorderSize = 0;
            this.hButton16.ForeColor = System.Drawing.SystemColors.ControlText;
            this.hButton16.Gradient.Angle = 0F;
            resources.ApplyResources(this.hButton16, "hButton16");
            this.hButton16.MaximumAddress.Enabled = false;
            this.hButton16.MaximumAddress.Length = ((ushort)(1));
            this.hButton16.MaximumValue = 99999999D;
            this.hButton16.MinimumAddress.Enabled = false;
            this.hButton16.MinimumAddress.Length = ((ushort)(1));
            this.hButton16.MinimumValue = 0D;
            this.hButton16.MonitorAddress.Enabled = false;
            this.hButton16.MonitorAddress.Length = ((ushort)(1));
            this.hButton16.Name = "hButton16";
            this.hButton16.NegationEnabled = false;
            this.hButton16.Radius = 0;
            this.hButton16.Rights = ((uint)(0u));
            this.hButton16.SetValue = 1;
            this.hButton16.Tag = "2082";
            this.hButton16.TouchEnabled = false;
            this.hButton16.UseVisualStyleBackColor = false;
            // 
            // textBox2
            // 
            resources.ApplyResources(this.textBox2, "textBox2");
            this.textBox2.Name = "textBox2";
            this.textBox2.Tag = "F2046";
            // 
            // hButton15
            // 
            this.hButton15.ActionType = Hi.Ltd.Enumerations.ActionType.Switch;
            this.hButton15.Address.DataType = Hi.Ltd.Enumerations.DataType.Int16;
            this.hButton15.Address.Length = ((ushort)(0));
            this.hButton15.BackColor = System.Drawing.SystemColors.Control;
            this.hButton15.FilletStyle = ((Hi.Ltd.Windows.Designs.FilletStyle)((((Hi.Ltd.Windows.Designs.FilletStyle.LeftTop | Hi.Ltd.Windows.Designs.FilletStyle.RightTop) 
            | Hi.Ltd.Windows.Designs.FilletStyle.RightBottom) 
            | Hi.Ltd.Windows.Designs.FilletStyle.LeftBottom)));
            this.hButton15.FlatAppearance.BorderSize = 0;
            this.hButton15.ForeColor = System.Drawing.SystemColors.ControlText;
            this.hButton15.Gradient.Angle = 0F;
            resources.ApplyResources(this.hButton15, "hButton15");
            this.hButton15.MaximumAddress.Enabled = false;
            this.hButton15.MaximumAddress.Length = ((ushort)(1));
            this.hButton15.MaximumValue = 99999999D;
            this.hButton15.MinimumAddress.Enabled = false;
            this.hButton15.MinimumAddress.Length = ((ushort)(1));
            this.hButton15.MinimumValue = 0D;
            this.hButton15.MonitorAddress.Enabled = false;
            this.hButton15.MonitorAddress.Length = ((ushort)(1));
            this.hButton15.Name = "hButton15";
            this.hButton15.NegationEnabled = false;
            this.hButton15.Radius = 0;
            this.hButton15.Rights = ((uint)(0u));
            this.hButton15.SetValue = 1;
            this.hButton15.Tag = "2081";
            this.hButton15.TouchEnabled = false;
            this.hButton15.UseVisualStyleBackColor = false;
            // 
            // textBox1
            // 
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textBox1.Name = "textBox1";
            this.textBox1.Tag = "F2044";
            // 
            // hButton14
            // 
            this.hButton14.ActionType = Hi.Ltd.Enumerations.ActionType.Switch;
            this.hButton14.Address.DataType = Hi.Ltd.Enumerations.DataType.Int16;
            this.hButton14.Address.Length = ((ushort)(0));
            this.hButton14.BackColor = System.Drawing.SystemColors.Control;
            this.hButton14.FilletStyle = ((Hi.Ltd.Windows.Designs.FilletStyle)((((Hi.Ltd.Windows.Designs.FilletStyle.LeftTop | Hi.Ltd.Windows.Designs.FilletStyle.RightTop) 
            | Hi.Ltd.Windows.Designs.FilletStyle.RightBottom) 
            | Hi.Ltd.Windows.Designs.FilletStyle.LeftBottom)));
            this.hButton14.FlatAppearance.BorderSize = 0;
            this.hButton14.ForeColor = System.Drawing.SystemColors.ControlText;
            this.hButton14.Gradient.Angle = 0F;
            resources.ApplyResources(this.hButton14, "hButton14");
            this.hButton14.MaximumAddress.Enabled = false;
            this.hButton14.MaximumAddress.Length = ((ushort)(1));
            this.hButton14.MaximumValue = 99999999D;
            this.hButton14.MinimumAddress.Enabled = false;
            this.hButton14.MinimumAddress.Length = ((ushort)(1));
            this.hButton14.MinimumValue = 0D;
            this.hButton14.MonitorAddress.Enabled = false;
            this.hButton14.MonitorAddress.Length = ((ushort)(1));
            this.hButton14.Name = "hButton14";
            this.hButton14.NegationEnabled = false;
            this.hButton14.Radius = 0;
            this.hButton14.Rights = ((uint)(0u));
            this.hButton14.SetValue = 1;
            this.hButton14.Tag = "2033";
            this.hButton14.TouchEnabled = false;
            this.hButton14.UseVisualStyleBackColor = false;
            // 
            // hButton5
            // 
            this.hButton5.ActionType = Hi.Ltd.Enumerations.ActionType.Switch;
            this.hButton5.Address.DataType = Hi.Ltd.Enumerations.DataType.Int16;
            this.hButton5.Address.Length = ((ushort)(0));
            this.hButton5.BackColor = System.Drawing.SystemColors.Control;
            this.hButton5.FilletStyle = ((Hi.Ltd.Windows.Designs.FilletStyle)((((Hi.Ltd.Windows.Designs.FilletStyle.LeftTop | Hi.Ltd.Windows.Designs.FilletStyle.RightTop) 
            | Hi.Ltd.Windows.Designs.FilletStyle.RightBottom) 
            | Hi.Ltd.Windows.Designs.FilletStyle.LeftBottom)));
            this.hButton5.FlatAppearance.BorderSize = 0;
            this.hButton5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.hButton5.Gradient.Angle = 0F;
            resources.ApplyResources(this.hButton5, "hButton5");
            this.hButton5.MaximumAddress.Enabled = false;
            this.hButton5.MaximumAddress.Length = ((ushort)(1));
            this.hButton5.MaximumValue = 99999999D;
            this.hButton5.MinimumAddress.Enabled = false;
            this.hButton5.MinimumAddress.Length = ((ushort)(1));
            this.hButton5.MinimumValue = 0D;
            this.hButton5.MonitorAddress.Enabled = false;
            this.hButton5.MonitorAddress.Length = ((ushort)(1));
            this.hButton5.Name = "hButton5";
            this.hButton5.NegationEnabled = false;
            this.hButton5.Radius = 0;
            this.hButton5.Rights = ((uint)(0u));
            this.hButton5.SetValue = 1;
            this.hButton5.Tag = "2010";
            this.hButton5.TouchEnabled = false;
            this.hButton5.UseVisualStyleBackColor = false;
            // 
            // hButton2
            // 
            this.hButton2.ActionType = Hi.Ltd.Enumerations.ActionType.Switch;
            this.hButton2.Address.DataType = Hi.Ltd.Enumerations.DataType.Int16;
            this.hButton2.Address.Length = ((ushort)(0));
            this.hButton2.BackColor = System.Drawing.SystemColors.Control;
            this.hButton2.BackgroundImage = global::VisionPlatform.Properties.Resources.MoveRightOff;
            resources.ApplyResources(this.hButton2, "hButton2");
            this.hButton2.FilletStyle = ((Hi.Ltd.Windows.Designs.FilletStyle)((((Hi.Ltd.Windows.Designs.FilletStyle.LeftTop | Hi.Ltd.Windows.Designs.FilletStyle.RightTop) 
            | Hi.Ltd.Windows.Designs.FilletStyle.RightBottom) 
            | Hi.Ltd.Windows.Designs.FilletStyle.LeftBottom)));
            this.hButton2.FlatAppearance.BorderSize = 0;
            this.hButton2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.hButton2.Gradient.Angle = 0F;
            this.hButton2.MaximumAddress.Enabled = false;
            this.hButton2.MaximumAddress.Length = ((ushort)(1));
            this.hButton2.MaximumValue = 99999999D;
            this.hButton2.MinimumAddress.Enabled = false;
            this.hButton2.MinimumAddress.Length = ((ushort)(1));
            this.hButton2.MinimumValue = 0D;
            this.hButton2.MonitorAddress.Enabled = false;
            this.hButton2.MonitorAddress.Length = ((ushort)(1));
            this.hButton2.Name = "hButton2";
            this.hButton2.NegationEnabled = false;
            this.hButton2.Radius = 0;
            this.hButton2.Rights = ((uint)(0u));
            this.hButton2.SetValue = 1;
            this.hButton2.Tag = "2017";
            this.toolTip1.SetToolTip(this.hButton2, resources.GetString("hButton2.ToolTip"));
            this.hButton2.TouchEnabled = false;
            this.hButton2.UseVisualStyleBackColor = false;
            // 
            // hButton7
            // 
            this.hButton7.ActionType = Hi.Ltd.Enumerations.ActionType.Switch;
            this.hButton7.Address.DataType = Hi.Ltd.Enumerations.DataType.Int16;
            this.hButton7.Address.Length = ((ushort)(0));
            this.hButton7.BackColor = System.Drawing.SystemColors.Control;
            this.hButton7.BackgroundImage = global::VisionPlatform.Properties.Resources.MoveLeftOff;
            resources.ApplyResources(this.hButton7, "hButton7");
            this.hButton7.FilletStyle = ((Hi.Ltd.Windows.Designs.FilletStyle)((((Hi.Ltd.Windows.Designs.FilletStyle.LeftTop | Hi.Ltd.Windows.Designs.FilletStyle.RightTop) 
            | Hi.Ltd.Windows.Designs.FilletStyle.RightBottom) 
            | Hi.Ltd.Windows.Designs.FilletStyle.LeftBottom)));
            this.hButton7.FlatAppearance.BorderSize = 0;
            this.hButton7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.hButton7.Gradient.Angle = 0F;
            this.hButton7.MaximumAddress.Enabled = false;
            this.hButton7.MaximumAddress.Length = ((ushort)(1));
            this.hButton7.MaximumValue = 99999999D;
            this.hButton7.MinimumAddress.Enabled = false;
            this.hButton7.MinimumAddress.Length = ((ushort)(1));
            this.hButton7.MinimumValue = 0D;
            this.hButton7.MonitorAddress.Enabled = false;
            this.hButton7.MonitorAddress.Length = ((ushort)(1));
            this.hButton7.Name = "hButton7";
            this.hButton7.NegationEnabled = false;
            this.hButton7.Radius = 0;
            this.hButton7.Rights = ((uint)(0u));
            this.hButton7.SetValue = 1;
            this.hButton7.Tag = "2018";
            this.toolTip1.SetToolTip(this.hButton7, resources.GetString("hButton7.ToolTip"));
            this.hButton7.TouchEnabled = false;
            this.hButton7.UseVisualStyleBackColor = false;
            // 
            // textBox4
            // 
            resources.ApplyResources(this.textBox4, "textBox4");
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Tag = "F2014";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // hButton1
            // 
            this.hButton1.ActionType = Hi.Ltd.Enumerations.ActionType.Switch;
            this.hButton1.Address.DataType = Hi.Ltd.Enumerations.DataType.Int16;
            this.hButton1.Address.Length = ((ushort)(0));
            this.hButton1.BackColor = System.Drawing.SystemColors.Control;
            this.hButton1.BackgroundImage = global::VisionPlatform.Properties.Resources.MoveUpOff;
            resources.ApplyResources(this.hButton1, "hButton1");
            this.hButton1.FilletStyle = ((Hi.Ltd.Windows.Designs.FilletStyle)((((Hi.Ltd.Windows.Designs.FilletStyle.LeftTop | Hi.Ltd.Windows.Designs.FilletStyle.RightTop) 
            | Hi.Ltd.Windows.Designs.FilletStyle.RightBottom) 
            | Hi.Ltd.Windows.Designs.FilletStyle.LeftBottom)));
            this.hButton1.FlatAppearance.BorderSize = 0;
            this.hButton1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.hButton1.Gradient.Angle = 0F;
            this.hButton1.MaximumAddress.Enabled = false;
            this.hButton1.MaximumAddress.Length = ((ushort)(1));
            this.hButton1.MaximumValue = 99999999D;
            this.hButton1.MinimumAddress.Enabled = false;
            this.hButton1.MinimumAddress.Length = ((ushort)(1));
            this.hButton1.MinimumValue = 0D;
            this.hButton1.MonitorAddress.Enabled = false;
            this.hButton1.MonitorAddress.Length = ((ushort)(1));
            this.hButton1.Name = "hButton1";
            this.hButton1.NegationEnabled = false;
            this.hButton1.Radius = 0;
            this.hButton1.Rights = ((uint)(0u));
            this.hButton1.SetValue = 1;
            this.hButton1.Tag = "2718";
            this.toolTip1.SetToolTip(this.hButton1, resources.GetString("hButton1.ToolTip"));
            this.hButton1.TouchEnabled = false;
            this.hButton1.UseVisualStyleBackColor = false;
            // 
            // hButton20
            // 
            this.hButton20.ActionType = Hi.Ltd.Enumerations.ActionType.Switch;
            this.hButton20.Address.DataType = Hi.Ltd.Enumerations.DataType.Int16;
            this.hButton20.Address.Length = ((ushort)(0));
            this.hButton20.BackColor = System.Drawing.SystemColors.Control;
            this.hButton20.BackgroundImage = global::VisionPlatform.Properties.Resources.MoveDownOff;
            resources.ApplyResources(this.hButton20, "hButton20");
            this.hButton20.FilletStyle = ((Hi.Ltd.Windows.Designs.FilletStyle)((((Hi.Ltd.Windows.Designs.FilletStyle.LeftTop | Hi.Ltd.Windows.Designs.FilletStyle.RightTop) 
            | Hi.Ltd.Windows.Designs.FilletStyle.RightBottom) 
            | Hi.Ltd.Windows.Designs.FilletStyle.LeftBottom)));
            this.hButton20.FlatAppearance.BorderSize = 0;
            this.hButton20.ForeColor = System.Drawing.SystemColors.ControlText;
            this.hButton20.Gradient.Angle = 0F;
            this.hButton20.MaximumAddress.Enabled = false;
            this.hButton20.MaximumAddress.Length = ((ushort)(1));
            this.hButton20.MaximumValue = 99999999D;
            this.hButton20.MinimumAddress.Enabled = false;
            this.hButton20.MinimumAddress.Length = ((ushort)(1));
            this.hButton20.MinimumValue = 0D;
            this.hButton20.MonitorAddress.Enabled = false;
            this.hButton20.MonitorAddress.Length = ((ushort)(1));
            this.hButton20.Name = "hButton20";
            this.hButton20.NegationEnabled = false;
            this.hButton20.Radius = 0;
            this.hButton20.Rights = ((uint)(0u));
            this.hButton20.SetValue = 1;
            this.hButton20.Tag = "2717";
            this.toolTip1.SetToolTip(this.hButton20, resources.GetString("hButton20.ToolTip"));
            this.hButton20.TouchEnabled = false;
            this.hButton20.UseVisualStyleBackColor = false;
            // 
            // hButton3
            // 
            this.hButton3.ActionType = Hi.Ltd.Enumerations.ActionType.Switch;
            this.hButton3.Address.DataType = Hi.Ltd.Enumerations.DataType.Int16;
            this.hButton3.Address.Length = ((ushort)(0));
            this.hButton3.BackColor = System.Drawing.SystemColors.Control;
            this.hButton3.BackgroundImage = global::VisionPlatform.Properties.Resources.MoveRightOff;
            resources.ApplyResources(this.hButton3, "hButton3");
            this.hButton3.FilletStyle = ((Hi.Ltd.Windows.Designs.FilletStyle)((((Hi.Ltd.Windows.Designs.FilletStyle.LeftTop | Hi.Ltd.Windows.Designs.FilletStyle.RightTop) 
            | Hi.Ltd.Windows.Designs.FilletStyle.RightBottom) 
            | Hi.Ltd.Windows.Designs.FilletStyle.LeftBottom)));
            this.hButton3.FlatAppearance.BorderSize = 0;
            this.hButton3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.hButton3.Gradient.Angle = 0F;
            this.hButton3.MaximumAddress.Enabled = false;
            this.hButton3.MaximumAddress.Length = ((ushort)(1));
            this.hButton3.MaximumValue = 99999999D;
            this.hButton3.MinimumAddress.Enabled = false;
            this.hButton3.MinimumAddress.Length = ((ushort)(1));
            this.hButton3.MinimumValue = 0D;
            this.hButton3.MonitorAddress.Enabled = false;
            this.hButton3.MonitorAddress.Length = ((ushort)(1));
            this.hButton3.Name = "hButton3";
            this.hButton3.NegationEnabled = false;
            this.hButton3.Radius = 0;
            this.hButton3.Rights = ((uint)(0u));
            this.hButton3.SetValue = 1;
            this.hButton3.Tag = "2317";
            this.toolTip1.SetToolTip(this.hButton3, resources.GetString("hButton3.ToolTip"));
            this.hButton3.TouchEnabled = false;
            this.hButton3.UseVisualStyleBackColor = false;
            // 
            // hButton6
            // 
            this.hButton6.ActionType = Hi.Ltd.Enumerations.ActionType.Switch;
            this.hButton6.Address.DataType = Hi.Ltd.Enumerations.DataType.Int16;
            this.hButton6.Address.Length = ((ushort)(0));
            this.hButton6.BackColor = System.Drawing.SystemColors.Control;
            this.hButton6.BackgroundImage = global::VisionPlatform.Properties.Resources.MoveLeftOff;
            resources.ApplyResources(this.hButton6, "hButton6");
            this.hButton6.FilletStyle = ((Hi.Ltd.Windows.Designs.FilletStyle)((((Hi.Ltd.Windows.Designs.FilletStyle.LeftTop | Hi.Ltd.Windows.Designs.FilletStyle.RightTop) 
            | Hi.Ltd.Windows.Designs.FilletStyle.RightBottom) 
            | Hi.Ltd.Windows.Designs.FilletStyle.LeftBottom)));
            this.hButton6.FlatAppearance.BorderSize = 0;
            this.hButton6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.hButton6.Gradient.Angle = 0F;
            this.hButton6.MaximumAddress.Enabled = false;
            this.hButton6.MaximumAddress.Length = ((ushort)(1));
            this.hButton6.MaximumValue = 99999999D;
            this.hButton6.MinimumAddress.Enabled = false;
            this.hButton6.MinimumAddress.Length = ((ushort)(1));
            this.hButton6.MinimumValue = 0D;
            this.hButton6.MonitorAddress.Enabled = false;
            this.hButton6.MonitorAddress.Length = ((ushort)(1));
            this.hButton6.Name = "hButton6";
            this.hButton6.NegationEnabled = false;
            this.hButton6.Radius = 0;
            this.hButton6.Rights = ((uint)(0u));
            this.hButton6.SetValue = 1;
            this.hButton6.Tag = "2318";
            this.toolTip1.SetToolTip(this.hButton6, resources.GetString("hButton6.ToolTip"));
            this.hButton6.TouchEnabled = false;
            this.hButton6.UseVisualStyleBackColor = false;
            // 
            // hButton8
            // 
            this.hButton8.ActionType = Hi.Ltd.Enumerations.ActionType.Switch;
            this.hButton8.Address.DataType = Hi.Ltd.Enumerations.DataType.Int16;
            this.hButton8.Address.Length = ((ushort)(0));
            this.hButton8.BackColor = System.Drawing.SystemColors.Control;
            this.hButton8.BackgroundImage = global::VisionPlatform.Properties.Resources.MoveRightOff;
            resources.ApplyResources(this.hButton8, "hButton8");
            this.hButton8.FilletStyle = ((Hi.Ltd.Windows.Designs.FilletStyle)((((Hi.Ltd.Windows.Designs.FilletStyle.LeftTop | Hi.Ltd.Windows.Designs.FilletStyle.RightTop) 
            | Hi.Ltd.Windows.Designs.FilletStyle.RightBottom) 
            | Hi.Ltd.Windows.Designs.FilletStyle.LeftBottom)));
            this.hButton8.FlatAppearance.BorderSize = 0;
            this.hButton8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.hButton8.Gradient.Angle = 0F;
            this.hButton8.MaximumAddress.Enabled = false;
            this.hButton8.MaximumAddress.Length = ((ushort)(1));
            this.hButton8.MaximumValue = 99999999D;
            this.hButton8.MinimumAddress.Enabled = false;
            this.hButton8.MinimumAddress.Length = ((ushort)(1));
            this.hButton8.MinimumValue = 0D;
            this.hButton8.MonitorAddress.Enabled = false;
            this.hButton8.MonitorAddress.Length = ((ushort)(1));
            this.hButton8.Name = "hButton8";
            this.hButton8.NegationEnabled = false;
            this.hButton8.Radius = 0;
            this.hButton8.Rights = ((uint)(0u));
            this.hButton8.SetValue = 1;
            this.hButton8.Tag = "2617";
            this.toolTip1.SetToolTip(this.hButton8, resources.GetString("hButton8.ToolTip"));
            this.hButton8.TouchEnabled = false;
            this.hButton8.UseVisualStyleBackColor = false;
            // 
            // hButton11
            // 
            this.hButton11.ActionType = Hi.Ltd.Enumerations.ActionType.Switch;
            this.hButton11.Address.DataType = Hi.Ltd.Enumerations.DataType.Int16;
            this.hButton11.Address.Length = ((ushort)(0));
            this.hButton11.BackColor = System.Drawing.SystemColors.Control;
            this.hButton11.BackgroundImage = global::VisionPlatform.Properties.Resources.MoveLeftOff;
            resources.ApplyResources(this.hButton11, "hButton11");
            this.hButton11.FilletStyle = ((Hi.Ltd.Windows.Designs.FilletStyle)((((Hi.Ltd.Windows.Designs.FilletStyle.LeftTop | Hi.Ltd.Windows.Designs.FilletStyle.RightTop) 
            | Hi.Ltd.Windows.Designs.FilletStyle.RightBottom) 
            | Hi.Ltd.Windows.Designs.FilletStyle.LeftBottom)));
            this.hButton11.FlatAppearance.BorderSize = 0;
            this.hButton11.ForeColor = System.Drawing.SystemColors.ControlText;
            this.hButton11.Gradient.Angle = 0F;
            this.hButton11.MaximumAddress.Enabled = false;
            this.hButton11.MaximumAddress.Length = ((ushort)(1));
            this.hButton11.MaximumValue = 99999999D;
            this.hButton11.MinimumAddress.Enabled = false;
            this.hButton11.MinimumAddress.Length = ((ushort)(1));
            this.hButton11.MinimumValue = 0D;
            this.hButton11.MonitorAddress.Enabled = false;
            this.hButton11.MonitorAddress.Length = ((ushort)(1));
            this.hButton11.Name = "hButton11";
            this.hButton11.NegationEnabled = false;
            this.hButton11.Radius = 0;
            this.hButton11.Rights = ((uint)(0u));
            this.hButton11.SetValue = 1;
            this.hButton11.Tag = "2618";
            this.toolTip1.SetToolTip(this.hButton11, resources.GetString("hButton11.ToolTip"));
            this.hButton11.TouchEnabled = false;
            this.hButton11.UseVisualStyleBackColor = false;
            // 
            // hButton10
            // 
            this.hButton10.ActionType = Hi.Ltd.Enumerations.ActionType.Switch;
            this.hButton10.Address.DataType = Hi.Ltd.Enumerations.DataType.Int16;
            this.hButton10.Address.Length = ((ushort)(0));
            this.hButton10.BackColor = System.Drawing.SystemColors.Control;
            this.hButton10.BackgroundImage = global::VisionPlatform.Properties.Resources.MoveDownOff;
            resources.ApplyResources(this.hButton10, "hButton10");
            this.hButton10.FilletStyle = ((Hi.Ltd.Windows.Designs.FilletStyle)((((Hi.Ltd.Windows.Designs.FilletStyle.LeftTop | Hi.Ltd.Windows.Designs.FilletStyle.RightTop) 
            | Hi.Ltd.Windows.Designs.FilletStyle.RightBottom) 
            | Hi.Ltd.Windows.Designs.FilletStyle.LeftBottom)));
            this.hButton10.FlatAppearance.BorderSize = 0;
            this.hButton10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.hButton10.Gradient.Angle = 0F;
            this.hButton10.MaximumAddress.Enabled = false;
            this.hButton10.MaximumAddress.Length = ((ushort)(1));
            this.hButton10.MaximumValue = 99999999D;
            this.hButton10.MinimumAddress.Enabled = false;
            this.hButton10.MinimumAddress.Length = ((ushort)(1));
            this.hButton10.MinimumValue = 0D;
            this.hButton10.MonitorAddress.Enabled = false;
            this.hButton10.MonitorAddress.Length = ((ushort)(1));
            this.hButton10.Name = "hButton10";
            this.hButton10.NegationEnabled = false;
            this.hButton10.Radius = 0;
            this.hButton10.Rights = ((uint)(0u));
            this.hButton10.SetValue = 1;
            this.hButton10.Tag = "2117";
            this.toolTip1.SetToolTip(this.hButton10, resources.GetString("hButton10.ToolTip"));
            this.hButton10.TouchEnabled = false;
            this.hButton10.UseVisualStyleBackColor = false;
            // 
            // hButton13
            // 
            this.hButton13.ActionType = Hi.Ltd.Enumerations.ActionType.Switch;
            this.hButton13.Address.DataType = Hi.Ltd.Enumerations.DataType.Int16;
            this.hButton13.Address.Length = ((ushort)(0));
            this.hButton13.BackColor = System.Drawing.SystemColors.Control;
            this.hButton13.BackgroundImage = global::VisionPlatform.Properties.Resources.MoveUpOff;
            resources.ApplyResources(this.hButton13, "hButton13");
            this.hButton13.FilletStyle = ((Hi.Ltd.Windows.Designs.FilletStyle)((((Hi.Ltd.Windows.Designs.FilletStyle.LeftTop | Hi.Ltd.Windows.Designs.FilletStyle.RightTop) 
            | Hi.Ltd.Windows.Designs.FilletStyle.RightBottom) 
            | Hi.Ltd.Windows.Designs.FilletStyle.LeftBottom)));
            this.hButton13.FlatAppearance.BorderSize = 0;
            this.hButton13.ForeColor = System.Drawing.SystemColors.ControlText;
            this.hButton13.Gradient.Angle = 0F;
            this.hButton13.MaximumAddress.Enabled = false;
            this.hButton13.MaximumAddress.Length = ((ushort)(1));
            this.hButton13.MaximumValue = 99999999D;
            this.hButton13.MinimumAddress.Enabled = false;
            this.hButton13.MinimumAddress.Length = ((ushort)(1));
            this.hButton13.MinimumValue = 0D;
            this.hButton13.MonitorAddress.Enabled = false;
            this.hButton13.MonitorAddress.Length = ((ushort)(1));
            this.hButton13.Name = "hButton13";
            this.hButton13.NegationEnabled = false;
            this.hButton13.Radius = 0;
            this.hButton13.Rights = ((uint)(0u));
            this.hButton13.SetValue = 1;
            this.hButton13.Tag = "2118";
            this.toolTip1.SetToolTip(this.hButton13, resources.GetString("hButton13.ToolTip"));
            this.hButton13.TouchEnabled = false;
            this.hButton13.UseVisualStyleBackColor = false;
            // 
            // hButton23
            // 
            this.hButton23.ActionType = Hi.Ltd.Enumerations.ActionType.Switch;
            this.hButton23.Address.DataType = Hi.Ltd.Enumerations.DataType.Int16;
            this.hButton23.Address.Length = ((ushort)(0));
            this.hButton23.BackColor = System.Drawing.SystemColors.Control;
            this.hButton23.BackgroundImage = global::VisionPlatform.Properties.Resources.MoveUpOff;
            resources.ApplyResources(this.hButton23, "hButton23");
            this.hButton23.FilletStyle = ((Hi.Ltd.Windows.Designs.FilletStyle)((((Hi.Ltd.Windows.Designs.FilletStyle.LeftTop | Hi.Ltd.Windows.Designs.FilletStyle.RightTop) 
            | Hi.Ltd.Windows.Designs.FilletStyle.RightBottom) 
            | Hi.Ltd.Windows.Designs.FilletStyle.LeftBottom)));
            this.hButton23.FlatAppearance.BorderSize = 0;
            this.hButton23.ForeColor = System.Drawing.SystemColors.ControlText;
            this.hButton23.Gradient.Angle = 0F;
            this.hButton23.MaximumAddress.Enabled = false;
            this.hButton23.MaximumAddress.Length = ((ushort)(1));
            this.hButton23.MaximumValue = 99999999D;
            this.hButton23.MinimumAddress.Enabled = false;
            this.hButton23.MinimumAddress.Length = ((ushort)(1));
            this.hButton23.MinimumValue = 0D;
            this.hButton23.MonitorAddress.Enabled = false;
            this.hButton23.MonitorAddress.Length = ((ushort)(1));
            this.hButton23.Name = "hButton23";
            this.hButton23.NegationEnabled = false;
            this.hButton23.Radius = 0;
            this.hButton23.Rights = ((uint)(0u));
            this.hButton23.SetValue = 1;
            this.hButton23.Tag = "2218";
            this.toolTip1.SetToolTip(this.hButton23, resources.GetString("hButton23.ToolTip"));
            this.hButton23.TouchEnabled = false;
            this.hButton23.UseVisualStyleBackColor = false;
            // 
            // hButton24
            // 
            this.hButton24.ActionType = Hi.Ltd.Enumerations.ActionType.Switch;
            this.hButton24.Address.DataType = Hi.Ltd.Enumerations.DataType.Int16;
            this.hButton24.Address.Length = ((ushort)(0));
            this.hButton24.BackColor = System.Drawing.SystemColors.Control;
            this.hButton24.BackgroundImage = global::VisionPlatform.Properties.Resources.MoveDownOff;
            resources.ApplyResources(this.hButton24, "hButton24");
            this.hButton24.FilletStyle = ((Hi.Ltd.Windows.Designs.FilletStyle)((((Hi.Ltd.Windows.Designs.FilletStyle.LeftTop | Hi.Ltd.Windows.Designs.FilletStyle.RightTop) 
            | Hi.Ltd.Windows.Designs.FilletStyle.RightBottom) 
            | Hi.Ltd.Windows.Designs.FilletStyle.LeftBottom)));
            this.hButton24.FlatAppearance.BorderSize = 0;
            this.hButton24.ForeColor = System.Drawing.SystemColors.ControlText;
            this.hButton24.Gradient.Angle = 0F;
            this.hButton24.MaximumAddress.Enabled = false;
            this.hButton24.MaximumAddress.Length = ((ushort)(1));
            this.hButton24.MaximumValue = 99999999D;
            this.hButton24.MinimumAddress.Enabled = false;
            this.hButton24.MinimumAddress.Length = ((ushort)(1));
            this.hButton24.MinimumValue = 0D;
            this.hButton24.MonitorAddress.Enabled = false;
            this.hButton24.MonitorAddress.Length = ((ushort)(1));
            this.hButton24.Name = "hButton24";
            this.hButton24.NegationEnabled = false;
            this.hButton24.Radius = 0;
            this.hButton24.Rights = ((uint)(0u));
            this.hButton24.SetValue = 1;
            this.hButton24.Tag = "2217";
            this.toolTip1.SetToolTip(this.hButton24, resources.GetString("hButton24.ToolTip"));
            this.hButton24.TouchEnabled = false;
            this.hButton24.UseVisualStyleBackColor = false;
            // 
            // hButton22
            // 
            this.hButton22.ActionType = Hi.Ltd.Enumerations.ActionType.Switch;
            this.hButton22.Address.DataType = Hi.Ltd.Enumerations.DataType.Int16;
            this.hButton22.Address.Length = ((ushort)(0));
            this.hButton22.BackColor = System.Drawing.SystemColors.Control;
            this.hButton22.BackgroundImage = global::VisionPlatform.Properties.Resources.ClockWiseOff;
            resources.ApplyResources(this.hButton22, "hButton22");
            this.hButton22.FilletStyle = ((Hi.Ltd.Windows.Designs.FilletStyle)((((Hi.Ltd.Windows.Designs.FilletStyle.LeftTop | Hi.Ltd.Windows.Designs.FilletStyle.RightTop) 
            | Hi.Ltd.Windows.Designs.FilletStyle.RightBottom) 
            | Hi.Ltd.Windows.Designs.FilletStyle.LeftBottom)));
            this.hButton22.FlatAppearance.BorderSize = 0;
            this.hButton22.ForeColor = System.Drawing.SystemColors.ControlText;
            this.hButton22.Gradient.Angle = 0F;
            this.hButton22.MaximumAddress.Enabled = false;
            this.hButton22.MaximumAddress.Length = ((ushort)(1));
            this.hButton22.MaximumValue = 99999999D;
            this.hButton22.MinimumAddress.Enabled = false;
            this.hButton22.MinimumAddress.Length = ((ushort)(1));
            this.hButton22.MinimumValue = 0D;
            this.hButton22.MonitorAddress.Enabled = false;
            this.hButton22.MonitorAddress.Length = ((ushort)(1));
            this.hButton22.Name = "hButton22";
            this.hButton22.NegationEnabled = false;
            this.hButton22.Radius = 0;
            this.hButton22.Rights = ((uint)(0u));
            this.hButton22.SetValue = 1;
            this.hButton22.Tag = "2518";
            this.toolTip1.SetToolTip(this.hButton22, resources.GetString("hButton22.ToolTip"));
            this.hButton22.TouchEnabled = false;
            this.hButton22.UseVisualStyleBackColor = false;
            // 
            // hButton19
            // 
            this.hButton19.ActionType = Hi.Ltd.Enumerations.ActionType.Switch;
            this.hButton19.Address.DataType = Hi.Ltd.Enumerations.DataType.Int16;
            this.hButton19.Address.Length = ((ushort)(0));
            this.hButton19.BackColor = System.Drawing.SystemColors.Control;
            this.hButton19.BackgroundImage = global::VisionPlatform.Properties.Resources.CounterClockWiseOff;
            resources.ApplyResources(this.hButton19, "hButton19");
            this.hButton19.FilletStyle = ((Hi.Ltd.Windows.Designs.FilletStyle)((((Hi.Ltd.Windows.Designs.FilletStyle.LeftTop | Hi.Ltd.Windows.Designs.FilletStyle.RightTop) 
            | Hi.Ltd.Windows.Designs.FilletStyle.RightBottom) 
            | Hi.Ltd.Windows.Designs.FilletStyle.LeftBottom)));
            this.hButton19.FlatAppearance.BorderSize = 0;
            this.hButton19.ForeColor = System.Drawing.SystemColors.ControlText;
            this.hButton19.Gradient.Angle = 0F;
            this.hButton19.MaximumAddress.Enabled = false;
            this.hButton19.MaximumAddress.Length = ((ushort)(1));
            this.hButton19.MaximumValue = 99999999D;
            this.hButton19.MinimumAddress.Enabled = false;
            this.hButton19.MinimumAddress.Length = ((ushort)(1));
            this.hButton19.MinimumValue = 0D;
            this.hButton19.MonitorAddress.Enabled = false;
            this.hButton19.MonitorAddress.Length = ((ushort)(1));
            this.hButton19.Name = "hButton19";
            this.hButton19.NegationEnabled = false;
            this.hButton19.Radius = 0;
            this.hButton19.Rights = ((uint)(0u));
            this.hButton19.SetValue = 1;
            this.hButton19.Tag = "2517";
            this.toolTip1.SetToolTip(this.hButton19, resources.GetString("hButton19.ToolTip"));
            this.hButton19.TouchEnabled = false;
            this.hButton19.UseVisualStyleBackColor = false;
            // 
            // hButton26
            // 
            this.hButton26.ActionType = Hi.Ltd.Enumerations.ActionType.Switch;
            this.hButton26.Address.DataType = Hi.Ltd.Enumerations.DataType.Int16;
            this.hButton26.Address.Length = ((ushort)(0));
            this.hButton26.BackColor = System.Drawing.SystemColors.Control;
            this.hButton26.BackgroundImage = global::VisionPlatform.Properties.Resources.CounterClockWiseOff;
            resources.ApplyResources(this.hButton26, "hButton26");
            this.hButton26.FilletStyle = ((Hi.Ltd.Windows.Designs.FilletStyle)((((Hi.Ltd.Windows.Designs.FilletStyle.LeftTop | Hi.Ltd.Windows.Designs.FilletStyle.RightTop) 
            | Hi.Ltd.Windows.Designs.FilletStyle.RightBottom) 
            | Hi.Ltd.Windows.Designs.FilletStyle.LeftBottom)));
            this.hButton26.FlatAppearance.BorderSize = 0;
            this.hButton26.ForeColor = System.Drawing.SystemColors.ControlText;
            this.hButton26.Gradient.Angle = 0F;
            this.hButton26.MaximumAddress.Enabled = false;
            this.hButton26.MaximumAddress.Length = ((ushort)(1));
            this.hButton26.MaximumValue = 99999999D;
            this.hButton26.MinimumAddress.Enabled = false;
            this.hButton26.MinimumAddress.Length = ((ushort)(1));
            this.hButton26.MinimumValue = 0D;
            this.hButton26.MonitorAddress.Enabled = false;
            this.hButton26.MonitorAddress.Length = ((ushort)(1));
            this.hButton26.Name = "hButton26";
            this.hButton26.NegationEnabled = false;
            this.hButton26.Radius = 0;
            this.hButton26.Rights = ((uint)(0u));
            this.hButton26.SetValue = 1;
            this.hButton26.Tag = "2417";
            this.toolTip1.SetToolTip(this.hButton26, resources.GetString("hButton26.ToolTip"));
            this.hButton26.TouchEnabled = false;
            this.hButton26.UseVisualStyleBackColor = false;
            // 
            // hButton28
            // 
            this.hButton28.ActionType = Hi.Ltd.Enumerations.ActionType.Switch;
            this.hButton28.Address.DataType = Hi.Ltd.Enumerations.DataType.Int16;
            this.hButton28.Address.Length = ((ushort)(0));
            this.hButton28.BackColor = System.Drawing.SystemColors.Control;
            this.hButton28.BackgroundImage = global::VisionPlatform.Properties.Resources.ClockWiseOff;
            resources.ApplyResources(this.hButton28, "hButton28");
            this.hButton28.FilletStyle = ((Hi.Ltd.Windows.Designs.FilletStyle)((((Hi.Ltd.Windows.Designs.FilletStyle.LeftTop | Hi.Ltd.Windows.Designs.FilletStyle.RightTop) 
            | Hi.Ltd.Windows.Designs.FilletStyle.RightBottom) 
            | Hi.Ltd.Windows.Designs.FilletStyle.LeftBottom)));
            this.hButton28.FlatAppearance.BorderSize = 0;
            this.hButton28.ForeColor = System.Drawing.SystemColors.ControlText;
            this.hButton28.Gradient.Angle = 0F;
            this.hButton28.MaximumAddress.Enabled = false;
            this.hButton28.MaximumAddress.Length = ((ushort)(1));
            this.hButton28.MaximumValue = 99999999D;
            this.hButton28.MinimumAddress.Enabled = false;
            this.hButton28.MinimumAddress.Length = ((ushort)(1));
            this.hButton28.MinimumValue = 0D;
            this.hButton28.MonitorAddress.Enabled = false;
            this.hButton28.MonitorAddress.Length = ((ushort)(1));
            this.hButton28.Name = "hButton28";
            this.hButton28.NegationEnabled = false;
            this.hButton28.Radius = 0;
            this.hButton28.Rights = ((uint)(0u));
            this.hButton28.SetValue = 1;
            this.hButton28.Tag = "2418";
            this.toolTip1.SetToolTip(this.hButton28, resources.GetString("hButton28.ToolTip"));
            this.hButton28.TouchEnabled = false;
            this.hButton28.UseVisualStyleBackColor = false;
            // 
            // label16
            // 
            resources.ApplyResources(this.label16, "label16");
            this.label16.Name = "label16";
            // 
            // label17
            // 
            resources.ApplyResources(this.label17, "label17");
            this.label17.Name = "label17";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.hButton1);
            this.groupBox1.Controls.Add(this.hButton18);
            this.groupBox1.Controls.Add(this.hButton20);
            this.groupBox1.Controls.Add(this.textBox6);
            this.groupBox1.Controls.Add(this.label4);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // hButton18
            // 
            this.hButton18.ActionType = Hi.Ltd.Enumerations.ActionType.Switch;
            this.hButton18.Address.DataType = Hi.Ltd.Enumerations.DataType.Int16;
            this.hButton18.Address.Length = ((ushort)(0));
            this.hButton18.BackColor = System.Drawing.SystemColors.Control;
            this.hButton18.FilletStyle = ((Hi.Ltd.Windows.Designs.FilletStyle)((((Hi.Ltd.Windows.Designs.FilletStyle.LeftTop | Hi.Ltd.Windows.Designs.FilletStyle.RightTop) 
            | Hi.Ltd.Windows.Designs.FilletStyle.RightBottom) 
            | Hi.Ltd.Windows.Designs.FilletStyle.LeftBottom)));
            this.hButton18.FlatAppearance.BorderSize = 0;
            this.hButton18.ForeColor = System.Drawing.SystemColors.ControlText;
            this.hButton18.Gradient.Angle = 0F;
            resources.ApplyResources(this.hButton18, "hButton18");
            this.hButton18.MaximumAddress.Enabled = false;
            this.hButton18.MaximumAddress.Length = ((ushort)(1));
            this.hButton18.MaximumValue = 99999999D;
            this.hButton18.MinimumAddress.Enabled = false;
            this.hButton18.MinimumAddress.Length = ((ushort)(1));
            this.hButton18.MinimumValue = 0D;
            this.hButton18.MonitorAddress.Enabled = false;
            this.hButton18.MonitorAddress.Length = ((ushort)(1));
            this.hButton18.Name = "hButton18";
            this.hButton18.NegationEnabled = false;
            this.hButton18.Radius = 0;
            this.hButton18.Rights = ((uint)(0u));
            this.hButton18.SetValue = 1;
            this.hButton18.Tag = "2710";
            this.hButton18.TouchEnabled = false;
            this.hButton18.UseVisualStyleBackColor = false;
            // 
            // textBox6
            // 
            resources.ApplyResources(this.textBox6, "textBox6");
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            this.textBox6.Tag = "F2714";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.hButton3);
            this.groupBox4.Controls.Add(this.hButton4);
            this.groupBox4.Controls.Add(this.hButton6);
            this.groupBox4.Controls.Add(this.textBox3);
            this.groupBox4.Controls.Add(this.label6);
            resources.ApplyResources(this.groupBox4, "groupBox4");
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.TabStop = false;
            // 
            // hButton4
            // 
            this.hButton4.ActionType = Hi.Ltd.Enumerations.ActionType.Switch;
            this.hButton4.Address.DataType = Hi.Ltd.Enumerations.DataType.Int16;
            this.hButton4.Address.Length = ((ushort)(0));
            this.hButton4.BackColor = System.Drawing.SystemColors.Control;
            this.hButton4.FilletStyle = ((Hi.Ltd.Windows.Designs.FilletStyle)((((Hi.Ltd.Windows.Designs.FilletStyle.LeftTop | Hi.Ltd.Windows.Designs.FilletStyle.RightTop) 
            | Hi.Ltd.Windows.Designs.FilletStyle.RightBottom) 
            | Hi.Ltd.Windows.Designs.FilletStyle.LeftBottom)));
            this.hButton4.FlatAppearance.BorderSize = 0;
            this.hButton4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.hButton4.Gradient.Angle = 0F;
            resources.ApplyResources(this.hButton4, "hButton4");
            this.hButton4.MaximumAddress.Enabled = false;
            this.hButton4.MaximumAddress.Length = ((ushort)(1));
            this.hButton4.MaximumValue = 99999999D;
            this.hButton4.MinimumAddress.Enabled = false;
            this.hButton4.MinimumAddress.Length = ((ushort)(1));
            this.hButton4.MinimumValue = 0D;
            this.hButton4.MonitorAddress.Enabled = false;
            this.hButton4.MonitorAddress.Length = ((ushort)(1));
            this.hButton4.Name = "hButton4";
            this.hButton4.NegationEnabled = false;
            this.hButton4.Radius = 0;
            this.hButton4.Rights = ((uint)(0u));
            this.hButton4.SetValue = 1;
            this.hButton4.Tag = "2310";
            this.hButton4.TouchEnabled = false;
            this.hButton4.UseVisualStyleBackColor = false;
            // 
            // textBox3
            // 
            resources.ApplyResources(this.textBox3, "textBox3");
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Tag = "F2314";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.hButton8);
            this.groupBox2.Controls.Add(this.hButton9);
            this.groupBox2.Controls.Add(this.hButton11);
            this.groupBox2.Controls.Add(this.textBox7);
            this.groupBox2.Controls.Add(this.label5);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // hButton9
            // 
            this.hButton9.ActionType = Hi.Ltd.Enumerations.ActionType.Switch;
            this.hButton9.Address.DataType = Hi.Ltd.Enumerations.DataType.Int16;
            this.hButton9.Address.Length = ((ushort)(0));
            this.hButton9.BackColor = System.Drawing.SystemColors.Control;
            this.hButton9.FilletStyle = ((Hi.Ltd.Windows.Designs.FilletStyle)((((Hi.Ltd.Windows.Designs.FilletStyle.LeftTop | Hi.Ltd.Windows.Designs.FilletStyle.RightTop) 
            | Hi.Ltd.Windows.Designs.FilletStyle.RightBottom) 
            | Hi.Ltd.Windows.Designs.FilletStyle.LeftBottom)));
            this.hButton9.FlatAppearance.BorderSize = 0;
            this.hButton9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.hButton9.Gradient.Angle = 0F;
            resources.ApplyResources(this.hButton9, "hButton9");
            this.hButton9.MaximumAddress.Enabled = false;
            this.hButton9.MaximumAddress.Length = ((ushort)(1));
            this.hButton9.MaximumValue = 99999999D;
            this.hButton9.MinimumAddress.Enabled = false;
            this.hButton9.MinimumAddress.Length = ((ushort)(1));
            this.hButton9.MinimumValue = 0D;
            this.hButton9.MonitorAddress.Enabled = false;
            this.hButton9.MonitorAddress.Length = ((ushort)(1));
            this.hButton9.Name = "hButton9";
            this.hButton9.NegationEnabled = false;
            this.hButton9.Radius = 0;
            this.hButton9.Rights = ((uint)(0u));
            this.hButton9.SetValue = 1;
            this.hButton9.Tag = "2610";
            this.hButton9.TouchEnabled = false;
            this.hButton9.UseVisualStyleBackColor = false;
            // 
            // textBox7
            // 
            resources.ApplyResources(this.textBox7, "textBox7");
            this.textBox7.Name = "textBox7";
            this.textBox7.ReadOnly = true;
            this.textBox7.Tag = "F2614";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.hButton13);
            this.groupBox5.Controls.Add(this.textBox5);
            this.groupBox5.Controls.Add(this.hButton10);
            this.groupBox5.Controls.Add(this.hButton12);
            this.groupBox5.Controls.Add(this.label7);
            resources.ApplyResources(this.groupBox5, "groupBox5");
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.TabStop = false;
            // 
            // textBox5
            // 
            resources.ApplyResources(this.textBox5, "textBox5");
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Tag = "F2114";
            // 
            // hButton12
            // 
            this.hButton12.ActionType = Hi.Ltd.Enumerations.ActionType.Switch;
            this.hButton12.Address.DataType = Hi.Ltd.Enumerations.DataType.Int16;
            this.hButton12.Address.Length = ((ushort)(0));
            this.hButton12.BackColor = System.Drawing.SystemColors.Control;
            this.hButton12.FilletStyle = ((Hi.Ltd.Windows.Designs.FilletStyle)((((Hi.Ltd.Windows.Designs.FilletStyle.LeftTop | Hi.Ltd.Windows.Designs.FilletStyle.RightTop) 
            | Hi.Ltd.Windows.Designs.FilletStyle.RightBottom) 
            | Hi.Ltd.Windows.Designs.FilletStyle.LeftBottom)));
            this.hButton12.FlatAppearance.BorderSize = 0;
            this.hButton12.ForeColor = System.Drawing.SystemColors.ControlText;
            this.hButton12.Gradient.Angle = 0F;
            resources.ApplyResources(this.hButton12, "hButton12");
            this.hButton12.MaximumAddress.Enabled = false;
            this.hButton12.MaximumAddress.Length = ((ushort)(1));
            this.hButton12.MaximumValue = 99999999D;
            this.hButton12.MinimumAddress.Enabled = false;
            this.hButton12.MinimumAddress.Length = ((ushort)(1));
            this.hButton12.MinimumValue = 0D;
            this.hButton12.MonitorAddress.Enabled = false;
            this.hButton12.MonitorAddress.Length = ((ushort)(1));
            this.hButton12.Name = "hButton12";
            this.hButton12.NegationEnabled = false;
            this.hButton12.Radius = 0;
            this.hButton12.Rights = ((uint)(0u));
            this.hButton12.SetValue = 1;
            this.hButton12.Tag = "2110";
            this.hButton12.TouchEnabled = false;
            this.hButton12.UseVisualStyleBackColor = false;
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.hButton23);
            this.groupBox7.Controls.Add(this.textBox9);
            this.groupBox7.Controls.Add(this.hButton24);
            this.groupBox7.Controls.Add(this.hButton25);
            this.groupBox7.Controls.Add(this.label12);
            resources.ApplyResources(this.groupBox7, "groupBox7");
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.TabStop = false;
            // 
            // textBox9
            // 
            resources.ApplyResources(this.textBox9, "textBox9");
            this.textBox9.Name = "textBox9";
            this.textBox9.ReadOnly = true;
            this.textBox9.Tag = "F2214";
            // 
            // hButton25
            // 
            this.hButton25.ActionType = Hi.Ltd.Enumerations.ActionType.Switch;
            this.hButton25.Address.DataType = Hi.Ltd.Enumerations.DataType.Int16;
            this.hButton25.Address.Length = ((ushort)(0));
            this.hButton25.BackColor = System.Drawing.SystemColors.Control;
            this.hButton25.FilletStyle = ((Hi.Ltd.Windows.Designs.FilletStyle)((((Hi.Ltd.Windows.Designs.FilletStyle.LeftTop | Hi.Ltd.Windows.Designs.FilletStyle.RightTop) 
            | Hi.Ltd.Windows.Designs.FilletStyle.RightBottom) 
            | Hi.Ltd.Windows.Designs.FilletStyle.LeftBottom)));
            this.hButton25.FlatAppearance.BorderSize = 0;
            this.hButton25.ForeColor = System.Drawing.SystemColors.ControlText;
            this.hButton25.Gradient.Angle = 0F;
            resources.ApplyResources(this.hButton25, "hButton25");
            this.hButton25.MaximumAddress.Enabled = false;
            this.hButton25.MaximumAddress.Length = ((ushort)(1));
            this.hButton25.MaximumValue = 99999999D;
            this.hButton25.MinimumAddress.Enabled = false;
            this.hButton25.MinimumAddress.Length = ((ushort)(1));
            this.hButton25.MinimumValue = 0D;
            this.hButton25.MonitorAddress.Enabled = false;
            this.hButton25.MonitorAddress.Length = ((ushort)(1));
            this.hButton25.Name = "hButton25";
            this.hButton25.NegationEnabled = false;
            this.hButton25.Radius = 0;
            this.hButton25.Rights = ((uint)(0u));
            this.hButton25.SetValue = 1;
            this.hButton25.Tag = "2210";
            this.hButton25.TouchEnabled = false;
            this.hButton25.UseVisualStyleBackColor = false;
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.Name = "label12";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.hButton19);
            this.groupBox6.Controls.Add(this.hButton21);
            this.groupBox6.Controls.Add(this.hButton22);
            this.groupBox6.Controls.Add(this.textBox8);
            this.groupBox6.Controls.Add(this.label8);
            resources.ApplyResources(this.groupBox6, "groupBox6");
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.TabStop = false;
            // 
            // hButton21
            // 
            this.hButton21.ActionType = Hi.Ltd.Enumerations.ActionType.Switch;
            this.hButton21.Address.DataType = Hi.Ltd.Enumerations.DataType.Int16;
            this.hButton21.Address.Length = ((ushort)(0));
            this.hButton21.BackColor = System.Drawing.SystemColors.Control;
            this.hButton21.FilletStyle = ((Hi.Ltd.Windows.Designs.FilletStyle)((((Hi.Ltd.Windows.Designs.FilletStyle.LeftTop | Hi.Ltd.Windows.Designs.FilletStyle.RightTop) 
            | Hi.Ltd.Windows.Designs.FilletStyle.RightBottom) 
            | Hi.Ltd.Windows.Designs.FilletStyle.LeftBottom)));
            this.hButton21.FlatAppearance.BorderSize = 0;
            this.hButton21.ForeColor = System.Drawing.SystemColors.ControlText;
            this.hButton21.Gradient.Angle = 0F;
            resources.ApplyResources(this.hButton21, "hButton21");
            this.hButton21.MaximumAddress.Enabled = false;
            this.hButton21.MaximumAddress.Length = ((ushort)(1));
            this.hButton21.MaximumValue = 99999999D;
            this.hButton21.MinimumAddress.Enabled = false;
            this.hButton21.MinimumAddress.Length = ((ushort)(1));
            this.hButton21.MinimumValue = 0D;
            this.hButton21.MonitorAddress.Enabled = false;
            this.hButton21.MonitorAddress.Length = ((ushort)(1));
            this.hButton21.Name = "hButton21";
            this.hButton21.NegationEnabled = false;
            this.hButton21.Radius = 0;
            this.hButton21.Rights = ((uint)(0u));
            this.hButton21.SetValue = 1;
            this.hButton21.Tag = "2510";
            this.hButton21.TouchEnabled = false;
            this.hButton21.UseVisualStyleBackColor = false;
            // 
            // textBox8
            // 
            resources.ApplyResources(this.textBox8, "textBox8");
            this.textBox8.Name = "textBox8";
            this.textBox8.ReadOnly = true;
            this.textBox8.Tag = "F2514";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.hButton26);
            this.groupBox8.Controls.Add(this.hButton27);
            this.groupBox8.Controls.Add(this.hButton28);
            this.groupBox8.Controls.Add(this.textBox10);
            this.groupBox8.Controls.Add(this.label13);
            resources.ApplyResources(this.groupBox8, "groupBox8");
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.TabStop = false;
            // 
            // hButton27
            // 
            this.hButton27.ActionType = Hi.Ltd.Enumerations.ActionType.Switch;
            this.hButton27.Address.DataType = Hi.Ltd.Enumerations.DataType.Int16;
            this.hButton27.Address.Length = ((ushort)(0));
            this.hButton27.BackColor = System.Drawing.SystemColors.Control;
            this.hButton27.FilletStyle = ((Hi.Ltd.Windows.Designs.FilletStyle)((((Hi.Ltd.Windows.Designs.FilletStyle.LeftTop | Hi.Ltd.Windows.Designs.FilletStyle.RightTop) 
            | Hi.Ltd.Windows.Designs.FilletStyle.RightBottom) 
            | Hi.Ltd.Windows.Designs.FilletStyle.LeftBottom)));
            this.hButton27.FlatAppearance.BorderSize = 0;
            this.hButton27.ForeColor = System.Drawing.SystemColors.ControlText;
            this.hButton27.Gradient.Angle = 0F;
            resources.ApplyResources(this.hButton27, "hButton27");
            this.hButton27.MaximumAddress.Enabled = false;
            this.hButton27.MaximumAddress.Length = ((ushort)(1));
            this.hButton27.MaximumValue = 99999999D;
            this.hButton27.MinimumAddress.Enabled = false;
            this.hButton27.MinimumAddress.Length = ((ushort)(1));
            this.hButton27.MinimumValue = 0D;
            this.hButton27.MonitorAddress.Enabled = false;
            this.hButton27.MonitorAddress.Length = ((ushort)(1));
            this.hButton27.Name = "hButton27";
            this.hButton27.NegationEnabled = false;
            this.hButton27.Radius = 0;
            this.hButton27.Rights = ((uint)(0u));
            this.hButton27.SetValue = 1;
            this.hButton27.Tag = "2410";
            this.hButton27.TouchEnabled = false;
            this.hButton27.UseVisualStyleBackColor = false;
            // 
            // textBox10
            // 
            resources.ApplyResources(this.textBox10, "textBox10");
            this.textBox10.Name = "textBox10";
            this.textBox10.ReadOnly = true;
            this.textBox10.Tag = "F2414";
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.Name = "label13";
            // 
            // Manual
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.groupBox3);
            this.Name = "Manual";
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private GroupBox groupBox3;
        private Label label10;
        private ToolTip toolTip1;
       
        private Label label16;
        private Label label17;
        
        private Label label9;
        private Label label11;
        private Label label1;
        private TextBox textBox4;
       
        private Label label2;
        private Label label3;
        private Hi.Ltd.Windows.Forms.HButton hButton7;
        private Hi.Ltd.Windows.Forms.HButton hButton5;
        private Hi.Ltd.Windows.Forms.HButton hButton2;
        private Hi.Ltd.Windows.Forms.HButton hButton15;
        private TextBox textBox1;
        private Hi.Ltd.Windows.Forms.HButton hButton14;
        private GroupBox groupBox1;
        private Hi.Ltd.Windows.Forms.HButton hButton1;
        private Hi.Ltd.Windows.Forms.HButton hButton18;
        private Hi.Ltd.Windows.Forms.HButton hButton20;
        private TextBox textBox6;
        private Label label4;
        private GroupBox groupBox4;
        private Hi.Ltd.Windows.Forms.HButton hButton3;
        private Hi.Ltd.Windows.Forms.HButton hButton4;
        private Hi.Ltd.Windows.Forms.HButton hButton6;
        private TextBox textBox3;
        private Label label6;
        private GroupBox groupBox2;
        private Hi.Ltd.Windows.Forms.HButton hButton8;
        private Hi.Ltd.Windows.Forms.HButton hButton9;
        private Hi.Ltd.Windows.Forms.HButton hButton11;
        private TextBox textBox7;
        private Label label5;
        private GroupBox groupBox5;
        private Hi.Ltd.Windows.Forms.HButton hButton10;
        private Hi.Ltd.Windows.Forms.HButton hButton12;
        private Label label7;
        private Hi.Ltd.Windows.Forms.HButton hButton13;
        private TextBox textBox5;
        private GroupBox groupBox7;
        private Hi.Ltd.Windows.Forms.HButton hButton23;
        private TextBox textBox9;
        private Hi.Ltd.Windows.Forms.HButton hButton24;
        private Hi.Ltd.Windows.Forms.HButton hButton25;
        private Label label12;
        private GroupBox groupBox6;
        private Hi.Ltd.Windows.Forms.HButton hButton21;
        private Hi.Ltd.Windows.Forms.HButton hButton22;
        private TextBox textBox8;
        private Label label8;
        private TextBox textBox2;
        private Hi.Ltd.Windows.Forms.HButton hButton19;
        private GroupBox groupBox8;
        private Hi.Ltd.Windows.Forms.HButton hButton26;
        private Hi.Ltd.Windows.Forms.HButton hButton27;
        private Hi.Ltd.Windows.Forms.HButton hButton28;
        private TextBox textBox10;
        private Label label13;
        private Hi.Ltd.Windows.Forms.HButton hButton16;
        private Hi.Ltd.Windows.Forms.HButton hButton17;
    }
}

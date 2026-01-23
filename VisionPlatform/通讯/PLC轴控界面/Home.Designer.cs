using System.Windows.Forms;

namespace VisionPlatform.多线插.PLC交互窗口
{
    partial class Home
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.btn_Axis = new System.Windows.Forms.Button();
            this.pnl_Load = new System.Windows.Forms.Panel();
            this.button7 = new System.Windows.Forms.Button();
            this.btn_Home = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_Axis
            // 
            this.btn_Axis.BackColor = System.Drawing.Color.Aqua;
            this.btn_Axis.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btn_Axis, "btn_Axis");
            this.btn_Axis.Name = "btn_Axis";
            this.btn_Axis.UseVisualStyleBackColor = false;
            // 
            // pnl_Load
            // 
            this.pnl_Load.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.pnl_Load, "pnl_Load");
            this.pnl_Load.Name = "pnl_Load";
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.Yellow;
            this.button7.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.button7, "button7");
            this.button7.Name = "button7";
            this.button7.Tag = "5";
            this.button7.UseVisualStyleBackColor = false;
            // 
            // btn_Home
            // 
            this.btn_Home.BackColor = System.Drawing.Color.Aqua;
            this.btn_Home.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btn_Home, "btn_Home");
            this.btn_Home.Name = "btn_Home";
            this.btn_Home.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Lime;
            this.button1.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.Tag = "1";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Firebrick;
            this.button2.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.button2, "button2");
            this.button2.ForeColor = System.Drawing.SystemColors.Control;
            this.button2.Name = "button2";
            this.button2.Tag = "4";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button3.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.button3, "button3");
            this.button3.ForeColor = System.Drawing.SystemColors.Control;
            this.button3.Name = "button3";
            this.button3.Tag = "3";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button4.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.button4, "button4");
            this.button4.Name = "button4";
            this.button4.Tag = "2";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.SystemColors.ControlDark;
            this.button5.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.button5, "button5");
            this.button5.Name = "button5";
            this.button5.Tag = "24";
            this.button5.UseVisualStyleBackColor = false;
            // 
            // Home
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_Home);
            this.Controls.Add(this.pnl_Load);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.btn_Axis);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Home";
            this.ResumeLayout(false);

        }

        #endregion

        private Button btn_Axis;
        private Panel pnl_Load;
        private Button button7;
        private Button btn_Home;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
    }
}
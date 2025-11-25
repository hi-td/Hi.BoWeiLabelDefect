
namespace VisionPlatform
{
    partial class Registered
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
            this.button_login = new System.Windows.Forms.Button();
            this.textBox_registration = new System.Windows.Forms.TextBox();
            this.textBox_machine = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_login
            // 
            this.button_login.Font = new System.Drawing.Font("宋体", 18F);
            this.button_login.Location = new System.Drawing.Point(205, 135);
            this.button_login.Margin = new System.Windows.Forms.Padding(2);
            this.button_login.Name = "button_login";
            this.button_login.Size = new System.Drawing.Size(181, 40);
            this.button_login.TabIndex = 7;
            this.button_login.Text = "注册";
            this.button_login.UseVisualStyleBackColor = true;
            this.button_login.Click += new System.EventHandler(this.button_login_Click);
            // 
            // textBox_registration
            // 
            this.textBox_registration.Font = new System.Drawing.Font("宋体", 15F);
            this.textBox_registration.Location = new System.Drawing.Point(152, 84);
            this.textBox_registration.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_registration.Name = "textBox_registration";
            this.textBox_registration.Size = new System.Drawing.Size(385, 30);
            this.textBox_registration.TabIndex = 5;
            // 
            // textBox_machine
            // 
            this.textBox_machine.Font = new System.Drawing.Font("宋体", 15F);
            this.textBox_machine.Location = new System.Drawing.Point(152, 44);
            this.textBox_machine.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_machine.Name = "textBox_machine";
            this.textBox_machine.Size = new System.Drawing.Size(385, 30);
            this.textBox_machine.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 18F);
            this.label2.Location = new System.Drawing.Point(42, 90);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "注册码";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 18F);
            this.label1.Location = new System.Drawing.Point(42, 50);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 24);
            this.label1.TabIndex = 4;
            this.label1.Text = "机器码";
            // 
            // Registered
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 195);
            this.Controls.Add(this.button_login);
            this.Controls.Add(this.textBox_registration);
            this.Controls.Add(this.textBox_machine);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Registered";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "软件注册";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Registered_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_login;
        private System.Windows.Forms.TextBox textBox_registration;
        private System.Windows.Forms.TextBox textBox_machine;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}
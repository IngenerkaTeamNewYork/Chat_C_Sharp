namespace WindowsFormsApplication1
{
    partial class RegistrationForm
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
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.PotParolTextBox = new System.Windows.Forms.TextBox();
            this.ParolTextBox = new System.Windows.Forms.TextBox();
            this.loginTextBox = new System.Windows.Forms.TextBox();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(40, 123);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(123, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Зарегистрироваться";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(60, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Регистрация";
            // 
            // PotParolTextBox
            // 
            this.PotParolTextBox.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.PotParolTextBox.Location = new System.Drawing.Point(51, 97);
            this.PotParolTextBox.Name = "PotParolTextBox";
            this.PotParolTextBox.Size = new System.Drawing.Size(100, 20);
            this.PotParolTextBox.TabIndex = 3;
            this.PotParolTextBox.Text = "Повторите пароль";
            this.PotParolTextBox.Enter += new System.EventHandler(this.PotParolTextBox4_Enter);
            this.PotParolTextBox.Leave += new System.EventHandler(this.PotParolTextBox4_Leave);
            // 
            // ParolTextBox
            // 
            this.ParolTextBox.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ParolTextBox.Location = new System.Drawing.Point(51, 71);
            this.ParolTextBox.Name = "ParolTextBox";
            this.ParolTextBox.Size = new System.Drawing.Size(100, 20);
            this.ParolTextBox.TabIndex = 2;
            this.ParolTextBox.Text = "Введите пароль";
            this.ParolTextBox.Enter += new System.EventHandler(this.ParolTextBox_Enter);
            this.ParolTextBox.Leave += new System.EventHandler(this.ParolTextBox_Leave);
            // 
            // loginTextBox
            // 
            this.loginTextBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.loginTextBox.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.loginTextBox.Location = new System.Drawing.Point(51, 45);
            this.loginTextBox.Name = "loginTextBox";
            this.loginTextBox.Size = new System.Drawing.Size(100, 20);
            this.loginTextBox.TabIndex = 1;
            this.loginTextBox.Text = "Введите логин";
            this.loginTextBox.Enter += new System.EventHandler(this.Reg_Log_Enter);
            this.loginTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Space);
            this.loginTextBox.Leave += new System.EventHandler(this.Reg_Log_Leave);
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(81, 149);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(37, 13);
            this.linkLabel2.TabIndex = 5;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Войти";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // RegistrationForm
            // 
            this.ClientSize = new System.Drawing.Size(204, 175);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.loginTextBox);
            this.Controls.Add(this.ParolTextBox);
            this.Controls.Add(this.PotParolTextBox);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.linkLabel2);
            this.MaximumSize = new System.Drawing.Size(240, 220);
            this.MinimumSize = new System.Drawing.Size(220, 213);
            this.Name = "RegistrationForm";
            this.Text = "Регистрация";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox PotParolTextBox;
        private System.Windows.Forms.TextBox ParolTextBox;
        private System.Windows.Forms.TextBox loginTextBox;
        private System.Windows.Forms.LinkLabel linkLabel2;
    }
}
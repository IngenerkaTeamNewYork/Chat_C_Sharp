namespace WindowsFormsApplication1
{
    partial class LoginForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.PPorolTextBox = new System.Windows.Forms.TextBox();
            this.LoginTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.pictureBox_Log = new System.Windows.Forms.PictureBox();
            this.savepassbox = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Log)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 80);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Вход";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // PPorolTextBox
            // 
            this.PPorolTextBox.Location = new System.Drawing.Point(3, 54);
            this.PPorolTextBox.Name = "PPorolTextBox";
            this.PPorolTextBox.Size = new System.Drawing.Size(165, 20);
            this.PPorolTextBox.TabIndex = 2;
            this.PPorolTextBox.Text = "Пароль";
            this.PPorolTextBox.UseSystemPasswordChar = true;
            this.PPorolTextBox.Enter += new System.EventHandler(this.PPorolTextBox_Enter);
            this.PPorolTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LoginTextBox_KeyDown);
            this.PPorolTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.LoginTextBox_KeyPress);
            this.PPorolTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.LoginTextBox_KeyDown);
            this.PPorolTextBox.Leave += new System.EventHandler(this.textBox1_Leave);
            // 
            // LoginTextBox
            // 
            this.LoginTextBox.Location = new System.Drawing.Point(3, 28);
            this.LoginTextBox.Name = "LoginTextBox";
            this.LoginTextBox.Size = new System.Drawing.Size(165, 20);
            this.LoginTextBox.TabIndex = 1;
            this.LoginTextBox.Text = "Логин";
            this.LoginTextBox.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            this.LoginTextBox.Enter += new System.EventHandler(this.LoginTextBox_Enter);
            this.LoginTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LoginTextBox_KeyDown);
            this.LoginTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.LoginTextBox_KeyPress);
            this.LoginTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.LoginTextBox_KeyUp);
            this.LoginTextBox.Leave += new System.EventHandler(this.LoginTextBox_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Авторизация";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(51, 106);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(72, 13);
            this.linkLabel1.TabIndex = 4;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Регистрация\r\n";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // pictureBox_Log
            // 
            this.pictureBox_Log.Location = new System.Drawing.Point(-7, -7);
            this.pictureBox_Log.Name = "pictureBox_Log";
            this.pictureBox_Log.Size = new System.Drawing.Size(183, 137);
            this.pictureBox_Log.TabIndex = 5;
            this.pictureBox_Log.TabStop = false;
            // 
            // savepassbox
            // 
            this.savepassbox.AutoSize = true;
            this.savepassbox.Location = new System.Drawing.Point(84, 84);
            this.savepassbox.Name = "savepassbox";
            this.savepassbox.Size = new System.Drawing.Size(79, 17);
            this.savepassbox.TabIndex = 6;
            this.savepassbox.Text = "Сохранить";
            this.savepassbox.UseVisualStyleBackColor = true;
            this.savepassbox.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.ForeColor = System.Drawing.Color.Crimson;
            this.button2.Location = new System.Drawing.Point(144, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(19, 19);
            this.button2.TabIndex = 7;
            this.button2.Text = "X";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(173, 123);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.savepassbox);
            this.Controls.Add(this.LoginTextBox);
            this.Controls.Add(this.PPorolTextBox);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox_Log);
            this.Name = "LoginForm";
            this.Text = "Вход";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Log)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox PPorolTextBox;
        private System.Windows.Forms.TextBox LoginTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.PictureBox pictureBox_Log;
        private System.Windows.Forms.CheckBox savepassbox;
        private System.Windows.Forms.Button button2;
    }
}
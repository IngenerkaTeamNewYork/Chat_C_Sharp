﻿namespace WindowsFormsApplication1
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
            this.savepassbox = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(2, 104);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Вход";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
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
            this.PPorolTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.LoginTextBox_KeyDown);
            this.PPorolTextBox.Leave += new System.EventHandler(this.TextBox1_Leave);
            // 
            // LoginTextBox
            // 
            this.LoginTextBox.Location = new System.Drawing.Point(3, 28);
            this.LoginTextBox.Name = "LoginTextBox";
            this.LoginTextBox.Size = new System.Drawing.Size(165, 20);
            this.LoginTextBox.TabIndex = 1;
            this.LoginTextBox.Text = "Логин";
            this.LoginTextBox.Enter += new System.EventHandler(this.LoginTextBox_Enter);
            this.LoginTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LoginTextBox_KeyDown);
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
            this.linkLabel1.Location = new System.Drawing.Point(12, 130);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(72, 13);
            this.linkLabel1.TabIndex = 5;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Регистрация\r\n";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel1_LinkClicked);
            // 
            // savepassbox
            // 
            this.savepassbox.AutoSize = true;
            this.savepassbox.Location = new System.Drawing.Point(83, 108);
            this.savepassbox.Name = "savepassbox";
            this.savepassbox.Size = new System.Drawing.Size(79, 17);
            this.savepassbox.TabIndex = 4;
            this.savepassbox.Text = "Сохранить";
            this.savepassbox.UseVisualStyleBackColor = true;
            this.savepassbox.CheckedChanged += new System.EventHandler(this.CheckBox1_CheckedChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(3, 80);
            this.textBox1.Name = "textBox1";
            this.textBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBox1.Size = new System.Drawing.Size(165, 20);
            this.textBox1.TabIndex = 8;
            this.textBox1.Text = "peregovory";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(107, 124);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(61, 24);
            this.button3.TabIndex = 9;
            this.button3.Text = "Админ";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(171, 150);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.savepassbox);
            this.Controls.Add(this.LoginTextBox);
            this.Controls.Add(this.PPorolTextBox);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "LoginForm";
            this.Text = "Вход";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox PPorolTextBox;
        private System.Windows.Forms.TextBox LoginTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.CheckBox savepassbox;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button3;
    }
}

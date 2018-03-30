using System;

namespace WindowsFormsApplication1
{
    partial class Chat
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.убитьКотаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.pictureBox_Chat = new System.Windows.Forms.PictureBox();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.этоМатToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Chat)).BeginInit();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.contextMenuStrip1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
			
            // 
            // textBox1
            // 
            this.textBox1.ContextMenuStrip = this.contextMenuStrip2;
            this.textBox1.Location = new System.Drawing.Point(268, 437);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(250, 63);
            this.textBox1.TabIndex = 1;
            this.textBox1.Tag = "";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            this.textBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyUp);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.убитьКотаToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(218, 26);
            // 
            // убитьКотаToolStripMenuItem
            // 
            this.убитьКотаToolStripMenuItem.Name = "убитьКотаToolStripMenuItem";
            this.убитьКотаToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.убитьКотаToolStripMenuItem.Text = "Удалить слово из словаря";
            this.убитьКотаToolStripMenuItem.Click += new System.EventHandler(this.убитьКотаToolStripMenuItem_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(524, 437);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 63);
            this.button1.TabIndex = 2;
            this.button1.Text = "Отправить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.button1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.button1_KeyPress);
            // 
            // textBox2
            // 
            this.textBox2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textBox2.BackColor = System.Drawing.SystemColors.Control;
            this.textBox2.ContextMenuStrip = this.contextMenuStrip1;
            this.textBox2.Location = new System.Drawing.Point(269, 12);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox2.Size = new System.Drawing.Size(323, 419);
            this.textBox2.TabIndex = 0;
            this.textBox2.TabStop = false;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // pictureBox_Chat
            // 
            this.pictureBox_Chat.Location = new System.Drawing.Point(0, -3);
            this.pictureBox_Chat.Name = "pictureBox_Chat";
            this.pictureBox_Chat.Size = new System.Drawing.Size(605, 517);
            this.pictureBox_Chat.TabIndex = 4;
            this.pictureBox_Chat.TabStop = false;
            this.pictureBox_Chat.Click += new System.EventHandler(this.pictureBox_Chat_Click);
            // 
            // fontDialog1
            // 
            this.fontDialog1.Apply += new System.EventHandler(this.fontDialog1_Apply);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(25, 22);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(87, 32);
            this.button2.TabIndex = 0;
            this.button2.TabStop = false;
            this.button2.Text = "Для слепых";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(25, 60);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(198, 23);
            this.button3.TabIndex = 6;
            this.button3.Text = "Обновить чат";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.этоМатToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(120, 26);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // этоМатToolStripMenuItem
            // 
            this.этоМатToolStripMenuItem.Name = "этоМатToolStripMenuItem";
            this.этоМатToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.этоМатToolStripMenuItem.Text = "Это мат!";
            this.этоМатToolStripMenuItem.Click += new System.EventHandler(this.этоМатToolStripMenuItem_Click);			
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(72, 435);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(62, 20);
            this.textBox3.TabIndex = 7;
            this.textBox3.Text = "peregovory";
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(13, 437);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Подчат:";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripTextBox1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(344, 25);
            this.toolStrip1.TabIndex = 9;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(100, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(50, 22);
            this.toolStripLabel1.Text = "Подчат:";
            // 
            // Chat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 513);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.pictureBox_Chat);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox3);
            this.Name = "Chat";
            this.Text = "Siemens A35";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Chat)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.PictureBox pictureBox_Chat;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem этоМатToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem убитьКотаToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
    }
}
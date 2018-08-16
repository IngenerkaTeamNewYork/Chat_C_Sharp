using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Linq;

namespace WindowsFormsApplication1
{
    public partial class RegistrationForm : Form
    {

        public static Button[] LangButtons = new Button[100];
        public int LangBattonCount = 0;
        public void Buttons()
        {

            String LangPath = Application.StartupPath + "\\Lang";
            String[] FileList = Directory.GetFiles(LangPath, "*.txt");
            LangBattonCount = FileList.Length;
            for (int n = 0; n < LangBattonCount; n++)
            {
                LangButtons[n] = new Button();
                LangButtons[n].Top = 9+23 * n;
                LangButtons[n].Height = 23;
                LangButtons[n].Width = 60;
                LangButtons[n].Text = Path.GetFileName(FileList[n]).Replace(".txt", "");
                LangButtons[n].MouseClick += new MouseEventHandler(LangChange_Click);
                this.Controls.Add(LangButtons[n]);
            }

        }


        public void ChangeLang(String Lang, object sender, EventArgs e)
        {
            String FileName = Application.StartupPath + "\\Lang\\" + Lang + ".txt";
            StreamReader stream = new StreamReader(FileName, Encoding.UTF8);
            string CurrentLine = "";

            while (CurrentLine != null)
            {

                button2.Text = Parameter(CurrentLine, "SiGn Up", button2.Text);
                label2.Text = Parameter(CurrentLine, "SiGn Up", label2.Text);
                PotParolTextBox.Text = Parameter(CurrentLine, "RePeAtPaSsWoRd", PotParolTextBox.Text);
                ParolTextBox.Text = Parameter(CurrentLine, "PaSsWoRd", ParolTextBox.Text);
                loginTextBox.Text = Parameter(CurrentLine, "LoGiN", loginTextBox.Text);
                linkLabel2.Text = Parameter(CurrentLine, "SiGn In", linkLabel2.Text);
                this.Text = Parameter(CurrentLine, "ReGiStRaTiOn", this.Text);
                CurrentLine = " ";

                CurrentLine = stream.ReadLine();
                
            }
            //Потому что вот здесь она станет null, и больше никогда в условие не зайдет
            stream.Close();
        }
        public RegistrationForm()
        {
            InitializeComponent();
            Buttons();
        }
        public struct Polzovatel
        {
            public string one;
        }
        string Text_of_Chat = "";

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoginForm rf = new LoginForm();
            rf.ShowDialog();
        }

        private void Reg_Log_Enter(object sender, EventArgs e)
        {
            if (loginTextBox.Text == "Введите логин")
            {
                loginTextBox.Text = "";
            }

            choice_of_chat_SelectedIndexChanged(sender, e);
        }

        private void Reg_Log_Leave(object sender, EventArgs e)
        {
            if (loginTextBox.Text == "")
            {
                loginTextBox.Text = "Введите логин";
            }
        }

        private void ABC_Leave(object sender, EventArgs e)
        {
            if (SubChatTextBox.Text == "")
            {
                SubChatTextBox.Text = "peregovory";
            }
        }

        private void ABC_Enter(object sender, EventArgs e)
        {
            if (SubChatTextBox.Text == "peregovory")
            {
                SubChatTextBox.Text = "";
            }
        }

        private void ParolTextBox_Leave(object sender, EventArgs e)
        {
            if (ParolTextBox.Text == "")
            {
                ParolTextBox.Text = "Введите пароль";
            }
            else
            {
                ParolTextBox.PasswordChar = '*';
            }
        }

        private void PotParolTextBox4_Leave(object sender, EventArgs e)
        {
            if (PotParolTextBox.Text == "")
            {
                PotParolTextBox.Text = "Повторите пароль";
            }
            else
            {
                PotParolTextBox.PasswordChar = '*';
            }
        }

        private void PotParolTextBox4_Enter(object sender, EventArgs e)
        {
            if (PotParolTextBox.Text == "Повторите пароль")
            {
                PotParolTextBox.Text = "";
            }
        }

        private void ParolTextBox_Enter(object sender, EventArgs e)
        {
            if (ParolTextBox.Text == "Введите пароль")
            {
                ParolTextBox.Text = "";
            }
        }

        private void choice_of_chat_SelectedIndexChanged(object sender, EventArgs e)
        {        
            choice();
        }

        private void choice()
        {
            if (choice_of_chat.SelectedIndex == 2)
            {
                MessageBox.Show("Введите название вашего чата в графу ниже");
                //Text_of_Chat = SubChatTextBox.Text;
                SubChatTextBox.Visible = true;
            }
            else
            {
                File.AppendAllLines(choice_of_chat.Text + "-users.txt", new String[] { loginTextBox.Text });
                Text_of_Chat = choice_of_chat.Text;
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            int kolich = LoginForm.kolichestvo_userov;
            bool uzhe_byl = false;

            if (ParolTextBox.Text == "Введите пароль" || loginTextBox.Text == "Введите логин")
            {
                MessageBox.Show("Данные!");
                uzhe_byl = true;
            }
            else if (PotParolTextBox.Text == "Повторите пароль")
            {
                MessageBox.Show("Повтори пароль!");
                uzhe_byl = true;
            }
            else if (ParolTextBox.Text != PotParolTextBox.Text)
            {
                MessageBox.Show("Пароли не совпадают!!!");
                uzhe_byl = true;
            }
            else
            {
                for (int i = 0; i < kolich; i++)
                {
                    if (loginTextBox.Text == LoginForm.usery[i].login)
                    {
                        MessageBox.Show("Ты был уже!");
                        uzhe_byl = true;
                        break;
                    }
                    else if (ParolTextBox.Text == LoginForm.usery[i].password)
                    {
                        MessageBox.Show("Пароль занят!");
                        uzhe_byl = true;
                        break;
                    }
                }
            }

            if (!uzhe_byl)
            {
                string filename = "password3.txt";
                File.AppendAllText(filename, Environment.NewLine + loginTextBox.Text + " " + ParolTextBox.Text);
                LoginForm.usery[kolich].login = loginTextBox.Text;
                LoginForm.usery[kolich].password = ParolTextBox.Text;

                LoginForm.kolichestvo_userov++;

                if (SubChatTextBox.Visible)
                {                    
                    Text_of_Chat = SubChatTextBox.Text;

                    if (!File.Exists(SubChatTextBox.Text + "-users.txt"))
                    {
                        File.AppendAllLines(SubChatTextBox.Text + "-users.txt", new String[] { loginTextBox.Text });
                    }
                    if (!File.Exists(SubChatTextBox.Text + ".txt"))
                    {
                        File.WriteAllText(SubChatTextBox.Text + ".txt", "");
                    }
                }
                else
                {
                    Text_of_Chat = choice_of_chat.Text;
                }
                choice_of_chat.Items.Add(SubChatTextBox.Text);
                Chat chatForm = new Chat(loginTextBox.Text, Text_of_Chat);
                chatForm.ShowDialog();
            }
        }
        
        private void Space(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (int)Keys.Space)
                e.KeyChar = '\0';
        }

        private void LinkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.ShowDialog();
        }

        String Parameter(String LineFromFile, String ParamName, String DefaultValue)
        {
            String ParamValue = DefaultValue;
            String ParamFullName = ParamName + " = ";
            if ((LineFromFile.Length > ParamFullName.Length) && LineFromFile.Substring(0, ParamFullName.Length) == ParamFullName)
            {
                ParamValue = LineFromFile.Substring(ParamFullName.Length);
            }
            return ParamValue;
        }


        private void LangChange_Click(object sender, EventArgs e)
        {

            for (int n = 0; n < LangBattonCount; n++)
            {
                if (sender.Equals(LangButtons[n]))
                {
                    ChangeLang(LangButtons[n].Text, sender, e);
                }
            }

        }
    }
}
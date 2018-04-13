using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Linq;

namespace WindowsFormsApplication1
{
    public partial class RegistrationForm : Form
    {
        public RegistrationForm()
        {
            InitializeComponent();
        }
        public struct Polzovatel
        {
            public string one;
        }
        public static Polzovatel[] kol_vo = new Polzovatel[5];
        // public static List<String> list_of_chat = new List<string>(new string[] { });
        string[] file = File.ReadAllLines("чаты.txt");

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

        public void ReadList()
        {
            FileStream file2 = new FileStream("чаты.txt", FileMode.Open);
            StreamReader reader = new StreamReader(file2); // создаем «потоковый читатель» и связываем его с файловым потоком
            int i = 0;
            while (reader.Peek() >= 0)
            {
                string stroka_iz_faila = reader.ReadLine().Trim();
                string[] list = stroka_iz_faila.Split(new Char[] { ' ' });
                kol_vo[i].one = list[0];
                i++;
            }

            reader.Close(); //закрываем поток
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

                if (!uzhe_byl)
                {
                    string filename = "password3.txt";
                    File.AppendAllText(filename, Environment.NewLine + loginTextBox.Text + " " + ParolTextBox.Text);
                    LoginForm.usery[kolich].login = loginTextBox.Text;
                    LoginForm.usery[kolich].password = ParolTextBox.Text;
                    
                    string Text_of_Chat = "";

                   int index = 0;
                    //choice_of_chat.Items.AddRange(new string [] { "peregovory", "peregovory2", "your" });
                    choice_of_chat.Items[0] = "peregovory"; index++;
                    choice_of_chat.Items[1] = "peregovory2"; index++;
                    choice_of_chat.Items[2] = "your"; index++;

                    for (int i = 0; i<5; i++)
                    {
                        choice_of_chat.Items.Remove(choice_of_chat.Items[i]);
                        if (choice_of_chat.Text == "your")
                        {
                            MessageBox.Show("Введите название вашего чата в графу ниже");
                            if (!File.Exists(SubChatTextBox.Text + "-users.txt"))
                            {
                                File.AppendAllLines(SubChatTextBox.Text + "-users.txt", new String[] { loginTextBox.Text });
                            }
                            if (!File.Exists(SubChatTextBox.Text + ".txt"))
                            {
                                File.WriteAllText(SubChatTextBox.Text + ".txt", "");
                            }
                            Text_of_Chat = SubChatTextBox.Text;
                        }
                        else
                        {
                            File.AppendAllLines(choice_of_chat.Text + "-users.txt", new String[] { loginTextBox.Text });
                            Text_of_Chat = choice_of_chat.Text;
                        }
                    }


                    
                    

                    LoginForm.kolichestvo_userov++;

                    Chat chatForm = new Chat(loginTextBox.Text, Text_of_Chat);
                    chatForm.ShowDialog();
                }
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
    }
}



        
    

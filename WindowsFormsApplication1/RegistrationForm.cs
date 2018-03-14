using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class RegistrationForm : Form
    {
        public RegistrationForm()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoginForm rf = new LoginForm();
            rf.ShowDialog();
        }

        private void RegistrationForm_Load(object sender, EventArgs e)
        {

        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            textBox3.Text = "";
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            textBox3.Text = "";
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

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

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
            if(ParolTextBox.Text == "Введите пароль")
            {
                ParolTextBox.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int kolich = LoginForm.kolichestvo_userov;
            bool uzhe_byl = false;
            for (int i = 0; i < kolich; i++)
            {
                if (loginTextBox.Text == LoginForm.usery[i].login)
                {
                    MessageBox.Show("Ты был уже!");
                    uzhe_byl = true;
                    break;
                }

                if (ParolTextBox.Text == LoginForm.usery[i].password)
                {
                    MessageBox.Show("Пароль занят!");
                    uzhe_byl = true;
                    break;
                }                
            }

            if (!uzhe_byl)
            {
                string filename = "password3.txt";
                System.IO.File.AppendAllText(filename, Environment.NewLine + loginTextBox.Text + " " + ParolTextBox.Text);
                LoginForm.usery[kolich].login = loginTextBox.Text;
                LoginForm.usery[kolich].password = ParolTextBox.Text;
                LoginForm.kolichestvo_userov++;

                Chat chatForm = new Chat(loginTextBox.Text);
                chatForm.ShowDialog();
                //////////////////////////////////////////////////////////////////////////////////////////////////////////////// Polzovoteli   password3
                File.WriteAllText("AllPolzovoteli.txt", string.Empty);
                Process myProcess = Process.Start("get.exe", "password3.txt password3.txt");
                do
                {
                    if (!myProcess.HasExited)
                    {
                        // Refresh the current process property values.
                        myProcess.Refresh();
                    }
                }
                while (!myProcess.WaitForExit(10000));



                FileStream file2 = new FileStream("NewPolzovoteli.txt", FileMode.Open);
                StreamReader reader = new StreamReader(file2); // создаем «потоковый читатель» и связываем его с файловым потоком

                while (reader.Peek() >= 0)
                {
                    string stroka_iz_faila = reader.ReadLine().Trim();
                    File.AppendAllText("password3.txt", Environment.NewLine + stroka_iz_faila);
                }

                reader.Close(); //закрываем поток

                textBox2.Clear();

                Process.Start("put.exe", "password3.txt password3.txt");
                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                /*Process test = new Process();
                test.StartInfo.FileName = "cmd";
                test.StartInfo.Arguments = @"/C ""echo testing | grep test""";
                test.Start();*/
            };
        }

        private void Space(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (int)Keys.Space)
                e.KeyChar = '\0';
        }
    }

       
}

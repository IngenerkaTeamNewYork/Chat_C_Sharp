using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
//using System.Linq;
using System.Text;
//using System.Threading.Tasks;
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

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }       
}

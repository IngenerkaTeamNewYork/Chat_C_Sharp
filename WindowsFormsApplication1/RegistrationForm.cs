using System;
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
                    System.IO.File.AppendAllText(filename, Environment.NewLine + loginTextBox.Text + " " + ParolTextBox.Text);
                    LoginForm.usery[kolich].login = loginTextBox.Text;
                    LoginForm.usery[kolich].password = ParolTextBox.Text;
                    LoginForm.kolichestvo_userov++;

                    Chat chatForm = new Chat(loginTextBox.Text);
                    chatForm.ShowDialog();
                };
            }
        }

        private void Space(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (int)Keys.Space)
                e.KeyChar = '\0';
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.ShowDialog();
        }
    }       
}

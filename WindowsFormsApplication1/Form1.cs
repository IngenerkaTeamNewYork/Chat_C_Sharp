using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public struct Polzovatel
    {
        public string login;
        public string password;
    };
                        
    public partial class LoginForm : Form
    {
        public Polzovatel user1;
        public Polzovatel[] usery;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            usery = new Polzovatel[3];
            usery[0].login = "Демид";
            usery[0].password = "Демид";
            usery[1].login = "Алена";
            usery[1].password = "Алена";

          
            FileStream file2 = new FileStream("d:\\password.txt", FileMode.Open); //создаем файловый поток
            StreamReader reader = new StreamReader(file2); // создаем «потоковый читатель» и связываем его с файловым потоком 

            int i = 0;
            while (reader.Peek() >= 0)
            {
                usery[i].login = reader.ReadLine();
                i++;
            }
            /*Console.WriteLine(reader.ReadToEnd()); //считываем все данные с потока и выводим на экран*/
            reader.Close(); //закрываем поток

         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.ShowDialog();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
            RegistrationForm rf = new RegistrationForm();
            rf.ShowDialog();
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void LoginTextBox_Leave(object sender, EventArgs e)
        {
            user1.login = LoginTextBox.Text;
            if (LoginTextBox.Text == "")
            {
                LoginTextBox.Text = "Логин";
            }
        }

        private void LoginTextBox_Enter(object sender, EventArgs e)
        {
            if (LoginTextBox.Text == "Логин")
            {
                LoginTextBox.Text = "";
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (PPorolTextBox.Text == "")
            {
                PPorolTextBox.Text = "ПАроль";
            }
            else 
            {
                user1.password = PPorolTextBox.Text;
                PPorolTextBox.PasswordChar = '*';

                bool net_polzovatelya = true;
                bool ne_pomnit_parol = true;
                for (int i = 0; i < 2; i++ )
                {                   
                    if (usery[i].login == user1.login)
                    {
                        net_polzovatelya = false;
                        if (usery[i].password == user1.password)
                        {
                            ne_pomnit_parol = false;
                            MessageBox.Show("अच्छी तरह से किया, अनुवाद करें");
                        }

                    }
                }
                    if (net_polzovatelya)
                    {
                        MessageBox.Show("Сиди, вспоминай имя, идиот");
                    }
                    else if (ne_pomnit_parol)
                    {
                        MessageBox.Show("Сиди, вспоминай пароль, идиот");
                    }
                    
            }
        }

        private void PPorolTextBox_Enter(object sender, EventArgs e)
        {
            if (PPorolTextBox.Text == "ПАроль")
            {
                PPorolTextBox.Text = "";
            }
        }
    }
}
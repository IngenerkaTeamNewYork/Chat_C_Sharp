using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        
        public LoginForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

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
                PPorolTextBox.Text = "Пороль";
            }
            else 
            {
                user1.password = PPorolTextBox.Text;
                PPorolTextBox.PasswordChar = '*';
                //MessageBox.Show(user1.password);
            }
        }

        private void PPorolTextBox_Enter(object sender, EventArgs e)
        {
            if (PPorolTextBox.Text == "Пороль")
            {
                PPorolTextBox.Text = "";
            }
        }

    }
}

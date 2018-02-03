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
            textBox6.Text = "";
        }

        private void Reg_Log_Leave(object sender, EventArgs e)
        {
            textBox6.Text = "Введите логинг";
        }
    }

       
}

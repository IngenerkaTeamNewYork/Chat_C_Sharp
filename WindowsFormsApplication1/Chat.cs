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
{    public struct Soobshenie
    {
        public string login;
        public string text;
    };
    public partial class Chat : Form
    {
        public string login;

        public Chat(string _login)
        {
            InitializeComponent();
            login = _login;
           

            saveFileDialog1.Filter = "Text files(*SaveFileDialog.txt)|*.txt|All files(*.*)|*.*";
            openFileDialog1.Filter = "Text files(*OpenFileDialog.txt)|*.txt|All files(*.*)|*.*";
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            string filename = "peregovory.txt";
            string fileText = System.IO.File.ReadAllText(filename);
            pictureBox_Chat.Image = Image.FromFile("fon.jpg");
            
            textBox2.Text = fileText; 
        /*
            for (int n = 0; n < 11; n++)
            {
                DateTime thisDay = DateTime.Now;
                textBox2.Text += thisDay.ToString("dd-MM-yyyy hh:mm:ss") + Environment.NewLine + sobch[n].login + ":" + sobch[n].text + Environment.NewLine;
            }
        */
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            { }
        else
            {
            DateTime thisDay = DateTime.Now;
            textBox2.Text += thisDay.ToString("dd-MM-yyyy hh:mm:ss") + Environment.NewLine + login + ":   " + textBox1.Text + Environment.NewLine;
            textBox1.Text = "";
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            DateTime thisDay = DateTime.Now;
            string filename = "peregovory.txt";
           // System.IO.File.WriteAllText(filename, "");
            System.IO.File.AppendAllText(filename, Environment.NewLine + thisDay.ToString("dd-MM-yyyy hh:mm:ss") + "$~#~@*&" + login + "$~#~@*&" + textBox1.Text);
            

            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }
    }
}

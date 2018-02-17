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
    public partial class Form2 : Form
    {
        public Soobshenie[] sobch = new Soobshenie[11];

        public Form2()
        {
            InitializeComponent();
            sobch[0].login = "Жуков";
            sobch[0].text = "Я продал кота в рабство";
            sobch[1].login = "Жуков";
            sobch[1].text = "Я продал кота в рабство";
            sobch[2].login = "Жуков";
            sobch[2].text = "Я продал кота в рабство";
            sobch[3].login = "Жуков";
            sobch[3].text = "Я продал кота в рабство";
            sobch[4].login = "Жуков";
            sobch[4].text = "Я продал кота в рабство";
            sobch[5].login = "Жуков";
            sobch[5].text = "Я продал кота в рабство";
            sobch[6].login = "Жуков";
            sobch[6].text = "Я продал кота в рабство";
            sobch[7].login = "Жуков";
            sobch[7].text = "Я продал кота в рабство";
            sobch[8].login = "Жуков";
            sobch[8].text = "Я продал кота в рабство";
            sobch[9].login = "Жуков";
            sobch[9].text = "Я продал кота в рабство";
            sobch[10].login = "Жуков";
            sobch[10].text = "Я продал кота в рабство";

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
            textBox2.Text += thisDay.ToString("dd-MM-yyyy hh:mm:ss") + Environment.NewLine + sobch[0].login + ":   " + textBox1.Text + Environment.NewLine;
            textBox1.Text = "";
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            DateTime thisDay = DateTime.Now;
            string filename = "peregovory.txt";
           // System.IO.File.WriteAllText(filename, "");
            System.IO.File.AppendAllText(filename, Environment.NewLine + thisDay.ToString("dd-MM-yyyy hh:mm:ss") + "$~#~@*&" + sobch[0].login + "$~#~@*&" + textBox1.Text);

            textBox2.ScrollToCaret();
            

            
        }
    }
}

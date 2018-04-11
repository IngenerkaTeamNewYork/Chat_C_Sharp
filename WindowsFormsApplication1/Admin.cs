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
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            foreach (String filename in openFileDialog1.FileNames)
            {
                GetPut.Put(filename);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            foreach (String filename in openFileDialog1.FileNames)
            {
                GetPut.Get(filename);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            File.Delete("peregovory.txt");
        }
    }
}

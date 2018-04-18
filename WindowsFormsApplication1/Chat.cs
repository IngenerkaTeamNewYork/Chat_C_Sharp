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
    public partial class Chat : Form
    {
        public bool deleteMat = true;

        public static List<String> SwearWords = new List<string>(new string[] { });

        private static List<Soobshenie> messages;
        private static Polzovatel_view[] type = new Polzovatel_view[3];

        public string mess = "";
        public string login;
        public const string rasd = "$~#~@*&";
        public string subchat = "peregovory";

        

        public Chat(string _login, String _subchat = "peregovory")
        {
            ReadList();
            InitializeComponent();
            login = _login;
            subchat = _subchat;
            textBox3.Text = subchat;

            string[] file = File.ReadAllLines(subchat + "-users.txt");

            comboBox1.Items.Clear();
            for (int i = 0; i < LoginForm.kolichestvo_userov; i++)
            {
                comboBox1.Items.Add(LoginForm.usery[i].login);
            }
            foreach (String s in file)
            {
                comboBox1.Items.Remove(s);
            }
            saveFileDialog1.Filter = "Text files(*SaveFileDialog.txt)|*.txt|All files(*.*)|*.*";
            openFileDialog1.Filter = "Text files(*OpenFileDialog.txt)|*.txt|All files(*.*)|*.*";
        }

        public void SendFileLink(String file)
        {
            messages.Add(new Soobshenie
            {
                login = this.login,
                text = "&^& " + file,
                day = MyTime.GetNetworkTime()
            });
        }

        public void ReadList()
        {
            FileStream file2 = new FileStream("словарь мат.txt", FileMode.Open);
            StreamReader reader = new StreamReader(file2); // создаем «потоковый читатель» и связываем его с файловым потоком

            while (reader.Peek() >= 0)
            {
                string stroka_iz_faila = reader.ReadLine().Trim();
                SwearWords.Add(stroka_iz_faila);
            }

            reader.Close(); //закрываем поток
        }

        private void BadWords(ref TextBox tb)
        {
            if (!deleteMat)
            {
                return;
            }

            string[] podstroki = tb.Text.Split(new String[] { " ", ",", Environment.NewLine }, StringSplitOptions.None);

            for (int i = 0; i < podstroki.Length; i++)
            {
                foreach (String str in SwearWords)
                {
                    if (!String.IsNullOrEmpty(str) &&
                        !String.IsNullOrEmpty(podstroki[i]) && 
                        str.ToUpper() == podstroki[i].ToUpper())
                    {
                        string antipm = String.Concat(Enumerable.Repeat("*", podstroki[i].Length));
                        tb.Text = tb.Text.Replace(podstroki[i], antipm);
                    }
                }
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            ////////////////////////////////////////////////////////////////////////////////

            messages = new List<Soobshenie>();
            File.WriteAllText("Allmatt.txt", string.Empty);
            GetPut.Get("matt.txt");

            File.WriteAllText("matt1.txt", File.ReadAllText("matt.txt"));
            try
            {
                SubChat dsad = new SubChat(subchat);
                messages = dsad.LoadChat(login);
                textBox2.Text = dsad.PrintChat(login, messages);
            }
            catch (UnauthorizedAccessException err)
            {
                MessageBox.Show(err.ToString());
                Close();
                return;
            }

            ReadFontFromFile();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() != "")
            {
                DateTime thisDay = MyTime.GetNetworkTime();
                String dateStr = thisDay.ToString("yyyy-MM-ddTHH\\:mm\\:ss.fffffffzzz");

                textBox2.AppendText(dateStr + Environment.NewLine + login + ":   " +

                    textBox1.Text + Environment.NewLine);
                File.AppendAllText(subchat + ".txt", dateStr + rasd + login + rasd + textBox1.Text.Replace(Environment.NewLine, "%%%%"));
                File.AppendAllText("NewMessages.txt", dateStr + rasd + login + rasd + textBox1.Text.Replace(Environment.NewLine, "%%%%") + Environment.NewLine);
            }

            textBox1.Text = "";
            mess = "";
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {
            string[] podstroki;
            int i = 0;

            textBox2.Clear();

            FileStream file2 = new FileStream(subchat + ".txt", FileMode.Open); //создаем файловый поток
            StreamReader reader = new StreamReader(file2); // создаем «потоковый читатель» и связываем его с файловым потоком

            i = 0;

            while (reader.Peek() >= 0)
            {
                string stroka_iz_faila = reader.ReadLine().Trim();
                podstroki = stroka_iz_faila.Split(new String[] { rasd }, StringSplitOptions.None);

                if (podstroki.Length > 2)
                {
                    //messages[i].day = Convert.ToDateTime(podstroki[0]);

                    messages.Add(new Soobshenie
                    {
                        login = podstroki[1],
                        text = podstroki[2].Replace("%%%%", Environment.NewLine)
                    });
                    i++;
                }
            }

            int kolichestvo_soobsch = i;

            reader.Close(); //закрываем поток

            messages.Sort();

            for (i = 0; i < kolichestvo_soobsch; i++)
            {
                textBox2.AppendText(messages[i].day + Environment.NewLine);
                textBox2.AppendText("     " + messages[i].login + "  cказал(а):  ");
                textBox2.AppendText(messages[i].text + Environment.NewLine);
            }

            podstroki = textBox2.Text.Split(new String[] { " ", "," }, StringSplitOptions.None);

            BadWords(ref textBox2);
        }

        private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            BadWords(ref textBox1);
            BadWords(ref textBox2);
        }

        private void TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            mess = mess + e.KeyData.ToString();
            File.AppendAllText("NewMessages.txt", mess + Environment.NewLine);

            if (e.Shift && e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                Button1_Click(sender, e);
            }
        }

        private void ReadFontFromFile()
        {
            FileStream config = new FileStream("config.txt", FileMode.Open);
            StreamReader reader2 = new StreamReader(config);

            string stroka = reader2.ReadLine().Trim();
            string[] view = stroka.Split(new Char[] { '$' });
            config.Close();

            if (view.Length > 4)
            {
                Font fontFormFile = new Font(view[0], (float)Convert.ToDouble(view[1]));

                if (view[2] == "True")
                {
                    fontFormFile = new Font(view[0], (float)Convert.ToDouble(view[1]), FontStyle.Italic);
                }
                else if (view[3] == "True")
                {
                    fontFormFile = new Font(view[0], (float)Convert.ToDouble(view[1]), FontStyle.Bold);
                }

                textBox1.Font = fontFormFile;
                textBox2.Font = fontFormFile;
                button1.Font = fontFormFile;
                button2.Font = fontFormFile;
                button3.Font = fontFormFile;

                Color c1 = ColorTranslator.FromHtml(view[4]);

                textBox1.ForeColor = c1;
                textBox2.ForeColor = c1;
                button1.ForeColor = c1;
                button2.ForeColor = c1;
                button3.ForeColor = c1;
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowColor = true;
            fontDialog1.Font = textBox1.Font;
            fontDialog1.Color = textBox1.ForeColor;

            if (fontDialog1.ShowDialog() != DialogResult.Cancel)
            {
                ColorDialog MyDialog = new ColorDialog
                {
                    AllowFullOpen = false,
                    ShowHelp = true,
                    Color = textBox1.ForeColor
                };

                if (MyDialog.ShowDialog() == DialogResult.OK)
                {
                    textBox1.ForeColor = MyDialog.Color;
                }

                textBox1.Font = fontDialog1.Font;
                textBox2.Font = fontDialog1.Font;
                button1.Font = fontDialog1.Font;
                button2.Font = fontDialog1.Font;
                button3.Font = fontDialog1.Font;

                textBox1.ForeColor = fontDialog1.Color;
                textBox2.ForeColor = fontDialog1.Color;
                button1.ForeColor = fontDialog1.Color;
                button2.ForeColor = fontDialog1.Color;
                button3.ForeColor = fontDialog1.Color;

                File.WriteAllText("config.txt", textBox1.Font.FontFamily.Name.ToString() +
                    "$" + textBox1.Font.Size.ToString() +
                    "$" + textBox1.Font.Italic.ToString() +
                    "$" + textBox1.Font.Bold.ToString() +
                    "$" + textBox1.ForeColor.ToArgb());
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            File.WriteAllText("AllMessages.txt", string.Empty);
            GetPut.Get(subchat + ".txt");

            FileStream file2 = new FileStream("NewMessages.txt", FileMode.Open);
            StreamReader reader = new StreamReader(file2); // создаем «потоковый читатель» и связываем его с файловым потоком

            while (reader.Peek() >= 0)
            {
                string stroka_iz_faila = reader.ReadLine().Trim();
                File.AppendAllText(subchat + ".txt", Environment.NewLine + stroka_iz_faila);
            }

            reader.Close(); //закрываем поток

            textBox2.Clear();
            Form2_Load(sender, e);

            GetPut.Put(subchat + ".txt");

            BadWords(ref textBox2);
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {           
            BadWords(ref textBox1);
        }

        private void ThisisswearwordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox2.SelectedText))
            {
                return;
            }

            SwearWords.Add(textBox2.SelectedText);
            File.AppendAllText("словарь мат.txt", Environment.NewLine + textBox2.SelectedText);
        }

        private void ContextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            SwearWords.Add(textBox2.SelectedText);

            if (!String.IsNullOrEmpty(textBox2.SelectedText))
            {
                File.AppendAllText("словарь мат.txt", Environment.NewLine + textBox2.SelectedText);
            }
        }

        private void RemoveBadWordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(textBox1.SelectedText);
            SwearWords.Remove(textBox1.SelectedText);

            TextBox2_TextChanged(null, null);
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                GetPut.Get(subchat + ".txt");
                SubChat dsad = new SubChat(subchat);
                messages = dsad.LoadChat(login);
                textBox2.Text = dsad.PrintChat(login, messages);
                GetPut.Put(subchat + "-users.txt");
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            subchat = textBox3.Text;

            if (File.Exists(subchat + ".txt"))
            {
                textBox2.Text = File.ReadAllText(subchat + ".txt").Replace("%%%%", Environment.NewLine);
            }
            else
            {
                textBox2.Text = "";
                File.AppendAllLines(subchat + "-users.txt", new String[] { login });
            }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                Button4_Click(sender, e);
            }
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            File.AppendAllLines(subchat + "-users.txt", new String[] { comboBox1.Text });
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            deleteMat = !deleteMat;
            if (!deleteMat)
            {
                button6.Text = "Вернуть зазвездывание";
            }
            else
            {
                button6.Text = "Убрать зазвездывание";
                SubChat dsad = new SubChat(subchat);
                messages = dsad.LoadChat(login);
                textBox2.Text = dsad.PrintChat(login, messages);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            GetPut.Get(textBox4.Text);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            GetPut.Put(textBox5.Text);
        }
    }
}
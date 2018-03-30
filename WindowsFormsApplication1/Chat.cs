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
    public class Soobshenie
    {
        public string login;
        public string text;
        public DateTime day;
    };

    public struct Polzovatel_view
    {
        public string shrift;
        public string color;
    };

    public partial class Chat : Form
    {
        public static List<String> SwearWords = new List<string>(new string[]{ "Сцуко", "Антон", "Мирон",
            "Стас", "Эдик", "Денис", "Предаст", "Медиатор", "Педиатр", "Педогог", "Юра",
            "Педсовет", "Кедр", "Курва", "Лох", "Санкт", "Дурак", "Мудрак", "Ниггер",
            "Навальный", "Кретин", "Бандерлог", "Феномен", "Кусудама", "Куй", "Псина",
            "Мудак", "Йобайт", "Днище", "Уху есть", "Уху ели", "Апчхуй", "От сосиски",
            "Сосиска", "Промискуитет", "Голубой", "Е брат", "Епархия", "Ша", "болда",
            "Синий", "Переобуться", "Сумка", "Конь", "Путь Анна", "Путный", "Публичный",
            "Приватный", "Паразит", "Прости тут", "Менуэт", "Молодец", "Щель"});

        public static List<Soobshenie> messages = new List<Soobshenie>();
        public Polzovatel_view user2;
        public static Polzovatel_view[] type = new Polzovatel_view[3];

        public string login;
        public const string rasd = "$~#~@*&";
        public string str = " ";
        public string str2 = " ";
		public string subchat = "peregovory";

        public Chat(string _login)
        {
            InitializeComponent();
            login = _login;

            saveFileDialog1.Filter = "Text files(*SaveFileDialog.txt)|*.txt|All files(*.*)|*.*";
            openFileDialog1.Filter = "Text files(*OpenFileDialog.txt)|*.txt|All files(*.*)|*.*";
        }

        private void badWords()
        {
            string[] podstroki = textBox2.Text.Split(new String[] { " ", ",", Environment.NewLine }, StringSplitOptions.None);

            for (int i = 0; i < podstroki.Length; i++)
            {
                if (SwearWords.Contains(podstroki[i]))
                {
                    string antipm = String.Concat(Enumerable.Repeat("*", podstroki[i].Length)); //  in .NET 3.5: String.Concat(Enumerable.Repeat("Hello", 4).ToArray())

                    textBox2.Text = textBox2.Text.Replace(podstroki[i], antipm);
                }
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            ////////////////////////////////////////////////////////////////////////////////
            
            File.WriteAllText("Allmatt.txt", string.Empty);
            GetPut.Get("matt.txt");

            File.WriteAllText("matt1.txt", File.ReadAllText("matt.txt"));
            /*
            Process.Start("put.exe", "password3.txt password3.txt");

 
            file2 = new FileStream("password3.txt", FileMode.Open); 
            reader = new StreamReader(file2);

            int i = 0;
            while (reader.Peek() >= 0)
            {
                string stroka_iz_faila = reader.ReadLine().Trim();
                string[] podstroki = stroka_iz_faila.Split(new Char[] { ' ' });
                usery[i].login = podstroki[0];
                usery[i].password = podstroki[1];  
                i++;
            }

            kolichestvo_userov = i;
            reader.Close();
             */
            ////////////////////////////////////////////////////////////////////////////////
            FileStream file2;
            try
            {
                file2 = new FileStream(subchat + ".txt", FileMode.Open); //создаем файловый поток
            }
            catch (System.IO.FileNotFoundException)
            {
                textBox2.Text = "";
                return;
            }

            StreamReader reader = new StreamReader(file2); // создаем «потоковый читатель» и связываем его с файловым потоком

            this.Height = 651;
            this.Width = 630;

            int i = 0;
            while (reader.Peek() >= 0)
            {
                string stroka_iz_faila = reader.ReadLine().Trim();
                List<String> SubLines = new List<String>(stroka_iz_faila.Split(new String[] { rasd }, StringSplitOptions.None));

                if (SubLines.Count == 3)
                {
                    messages.Add(new Soobshenie());
                    messages[i].day = Convert.ToDateTime(SubLines[0]);
                    messages[i].login = SubLines[1];
                    messages[i].text = SubLines[2].Replace("%%%%", Environment.NewLine);
                    i++;
                } else
                {
                    throw new Exception("Malformed subchat.")
                }
            }

            int AmountOfMessages = i;

            reader.Close(); //закрываем поток

            for (i = 0; i < AmountOfMessages - 1; i++)
            {
                for (int j = i + 1; j < AmountOfMessages; j++)
                {
                    if (messages[i].day > messages[j].day)
                    {
                        Soobshenie soob = messages[j];

                        messages[j].day = messages[i].day;
                        messages[i].day = soob.day;
                        messages[j].login = messages[i].login;
                        messages[i].login = soob.login;
                        messages[j].text = messages[i].text;
                        messages[i].text = soob.text;
                    }
                }
            }

            for (i = 0; i < AmountOfMessages; i++)
            {
                textBox2.Text = textBox2.Text + messages[i].day + Environment.NewLine;
                textBox2.Text = textBox2.Text + "     " + messages[i].login + "  сказал(а):  ";
                textBox2.Text = textBox2.Text + messages[i].text + Environment.NewLine;
            }

            readFontFromFile();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() != "")
            {
                DateTime thisDay = MyTime.GetNetworkTime();
                String dateStr = thisDay.ToString("yyyy-MM-ddTHH\\:mm\\:ss.fffffffzzz");
                String dateStrfors = thisDay.ToString("yyyy-MM-ddTHH\\:mm\\:ss.fffffffzzz");

                textBox2.AppendText(dateStr + Environment.NewLine + login + ":   " +
                    textBox1.Text + Environment.NewLine);
                File.AppendAllText(subchat + ".txt", Environment.NewLine + dateStr + rasd + login + rasd + textBox1.Text.Replace(Environment.NewLine, "%%%%"));
                File.AppendAllText("NewMessages.txt", dateStr + rasd + login + rasd + textBox1.Text.Replace(Environment.NewLine, "%%%%") + Environment.NewLine);
            }

            textBox1.Text = null;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
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
                    Soobshenie temp = new Soobshenie();
                    temp.login = podstroki[1];
                    temp.text = podstroki[2].Replace("%%%%", Environment.NewLine);
                    messages.Add(temp);
                    i++;
                }
            }

            int kolichestvo_soobsch = i;

            reader.Close(); //закрываем поток

            for (i = 0; i < kolichestvo_soobsch - 1; i++)
            {
                for (int j = i + 1; j < kolichestvo_soobsch; j++)
                {
                    if (messages[i].day > messages[j].day)
                    {
                        Soobshenie soob = messages[j];

                        messages[j].day = messages[i].day;
                        messages[i].day = soob.day;
                        messages[j].login = messages[i].login;
                        messages[i].login = soob.login;
                        messages[j].text = messages[i].text;
                        messages[i].text = soob.text;
                    }
                }
            }

            for (i = 0; i < kolichestvo_soobsch; i++)
            {
                textBox2.AppendText(messages[i].day + Environment.NewLine);
                textBox2.AppendText("     " + messages[i].login + "  cказал(а):  ");
                textBox2.AppendText(messages[i].text + Environment.NewLine);
            }

            podstroki = textBox2.Text.Split(new String[] { " ", "," }, StringSplitOptions.None);

            badWords();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            badWords();
        }
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Shift && e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                button1_Click(sender, e);
            }
        }

        private void button1_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void fontDialog1_Apply(object sender, EventArgs e)
        {
        }

        private void readFontFromFile()
        {
            FileStream config = new FileStream("config.txt", FileMode.Open);
            StreamReader reader2 = new StreamReader(config);

            string stroka = reader2.ReadLine().Trim();
            string[] view = stroka.Split(new Char[] { '$' });
            config.Close();

            if (view.Length > 4)
            {
                Font fontFormFile = new Font (view[0], (float)Convert.ToDouble(view[1]));
                
                if (view[2] == "True")
                {
                    fontFormFile = new Font (view[0], (float)Convert.ToDouble(view[1]), FontStyle.Italic);
                }
                else if (view[3] == "True")
                {
                    fontFormFile = new Font (view[0], (float)Convert.ToDouble(view[1]), FontStyle.Bold);
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

        private void button2_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowColor = true;
            fontDialog1.Font = textBox1.Font;
            fontDialog1.Color = textBox1.ForeColor;

            if (fontDialog1.ShowDialog() != DialogResult.Cancel)
            {                
                ColorDialog MyDialog = new ColorDialog();
                MyDialog.AllowFullOpen = false;
                MyDialog.ShowHelp = true;
                MyDialog.Color = textBox1.ForeColor;
                
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

        private void button3_Click(object sender, EventArgs e)
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

            Process.Start("cmd", "/C start /B put.exe " + subchat + ".txt " + subchat + ".txt");

            badWords();
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            subchat = textBox3.Text;
            textBox2.Text = "";
            if (File.Exists(subchat + ".txt"))
            {
                textBox2.Text = File.ReadAllText(subchat + ".txt").Replace("%%%%", Environment.NewLine);
            }
        }
		
        private void button4_Click(object sender, EventArgs e)
        {
            // Process.Start("put.exe", subchat + ".txt " + subchat + ".txt"");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            badWords();
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
        }

        private void этоМатToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SwearWords.Add(textBox2.SelectedText);
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            SwearWords.Add(textBox2.SelectedText);
        }

        private void pictureBox_Chat_Click(object sender, EventArgs e)
        {

        }
		
		private void RemoveBadWordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(textBox1.SelectedText);
            SwearWords.Remove(textBox1.SelectedText);

            textBox2_TextChanged(null, null);
        }
    }
}
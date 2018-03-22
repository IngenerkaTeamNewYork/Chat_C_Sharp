using System;
using System.Threading;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;



namespace WindowsFormsApplication1
{
    public struct Soobshenie
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
        public static int kol_vo_bed_messages = 0;
        public static String[] bedMessages = new string[500];

        public static Soobshenie[] messages = new Soobshenie[15016];
        public Polzovatel_view user2;
        public static Polzovatel_view[] type = new Polzovatel_view[3];

        public string login;
        
        public string str = " ";
        public string str2 = " ";

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


        private void Form2_Load(object sender, EventArgs e)
        {
            ////////////////////////////////////////////////////////////////////////////////
            /*TimerCallback tm = new TimerCallback(button3_Click( sender, null));
            // создаем таймер
            Timer timer = new Timer(tm, null, 0, 2000);
            */
           // Timer t = new Timer(button3_Click(sender, null), null, 0, 2000);
            File.WriteAllText(Const.Allmatt, string.Empty);
            Process myProcess = Process.Start(Const.get, Const.matt);
            do
            {
                if (!myProcess.HasExited)
                {
                    myProcess.Refresh();
                }
            }
            while (!myProcess.WaitForExit(10000));

            FileStream file2 = new FileStream(Const.slovar, FileMode.Open);
            StreamReader reader1 = new StreamReader(file2);

            while (reader1.Peek() >= 0)
            {
                string stroka_iz_faila = reader1.ReadLine().Trim();
                File.AppendAllText(Const.matt, stroka_iz_faila + Environment.NewLine);
            }

            reader1.Close();
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
            bedMessages[kol_vo_bed_messages] = "Сцуко"; kol_vo_bed_messages++;
            bedMessages[kol_vo_bed_messages] = "Антон"; kol_vo_bed_messages++;
            bedMessages[kol_vo_bed_messages] = "Мирон"; kol_vo_bed_messages++;
            bedMessages[kol_vo_bed_messages] = "Стас"; kol_vo_bed_messages++;
            bedMessages[kol_vo_bed_messages] = "Эдик"; kol_vo_bed_messages++;
            bedMessages[kol_vo_bed_messages] = "Денис"; kol_vo_bed_messages++;
            bedMessages[kol_vo_bed_messages] = "Предаст"; kol_vo_bed_messages++;
            bedMessages[kol_vo_bed_messages] = "Медиатор"; kol_vo_bed_messages++;
            bedMessages[kol_vo_bed_messages] = "Педиатр"; kol_vo_bed_messages++;
            bedMessages[kol_vo_bed_messages] = "Педогог"; kol_vo_bed_messages++;
            bedMessages[kol_vo_bed_messages] = "Юра"; kol_vo_bed_messages++;
            bedMessages[kol_vo_bed_messages] = "Педсовет"; kol_vo_bed_messages++;
            bedMessages[kol_vo_bed_messages] = "Кедр"; kol_vo_bed_messages++;
            bedMessages[kol_vo_bed_messages] = "Курва"; kol_vo_bed_messages++;
            bedMessages[kol_vo_bed_messages] = "Лох"; kol_vo_bed_messages++;
            bedMessages[kol_vo_bed_messages] = "Санкт"; kol_vo_bed_messages++;
            bedMessages[kol_vo_bed_messages] = "Дурак"; kol_vo_bed_messages++;
            bedMessages[kol_vo_bed_messages] = "Мудрак"; kol_vo_bed_messages++;
            bedMessages[kol_vo_bed_messages] = "Ниггер"; kol_vo_bed_messages++;
            bedMessages[kol_vo_bed_messages] = "Навальный"; kol_vo_bed_messages++;
            bedMessages[kol_vo_bed_messages] = "Кретин"; kol_vo_bed_messages++;
            bedMessages[kol_vo_bed_messages] = "Бандерлог"; kol_vo_bed_messages++;
            bedMessages[kol_vo_bed_messages] = "Феномен"; kol_vo_bed_messages++;
            bedMessages[kol_vo_bed_messages] = "Кусудама"; kol_vo_bed_messages++;
            bedMessages[kol_vo_bed_messages] = "Куй"; kol_vo_bed_messages++;
            bedMessages[kol_vo_bed_messages] = "Псина"; kol_vo_bed_messages++;
            bedMessages[kol_vo_bed_messages] = "Мудак"; kol_vo_bed_messages++;
            bedMessages[kol_vo_bed_messages] = "Йобайт"; kol_vo_bed_messages++;
            bedMessages[kol_vo_bed_messages] = "Днище"; kol_vo_bed_messages++;
            bedMessages[kol_vo_bed_messages] = "Уху есть"; kol_vo_bed_messages++;
            bedMessages[kol_vo_bed_messages] = "Уху ели"; kol_vo_bed_messages++;
            bedMessages[kol_vo_bed_messages] = "Апчхуй"; kol_vo_bed_messages++;
            bedMessages[kol_vo_bed_messages] = "От сосиски"; kol_vo_bed_messages++;
            bedMessages[kol_vo_bed_messages] = "Сосиска"; kol_vo_bed_messages++;
            bedMessages[kol_vo_bed_messages] = "Промискуитет"; kol_vo_bed_messages++;
            bedMessages[kol_vo_bed_messages] = "Голубой"; kol_vo_bed_messages++;
            bedMessages[kol_vo_bed_messages] = "Е брат"; kol_vo_bed_messages++;
            bedMessages[kol_vo_bed_messages] = "Епархия"; kol_vo_bed_messages++;
            bedMessages[kol_vo_bed_messages] = "Ша"; kol_vo_bed_messages++;
            bedMessages[kol_vo_bed_messages] = "болда"; kol_vo_bed_messages++;
            bedMessages[kol_vo_bed_messages] = "Синий"; kol_vo_bed_messages++;
            bedMessages[kol_vo_bed_messages] = "Переобуться"; kol_vo_bed_messages++;
            bedMessages[kol_vo_bed_messages] = "Сумка"; kol_vo_bed_messages++;
            bedMessages[kol_vo_bed_messages] = "Конь"; kol_vo_bed_messages++;
            bedMessages[kol_vo_bed_messages] = "Путь Анна"; kol_vo_bed_messages++;
            bedMessages[kol_vo_bed_messages] = "Путный"; kol_vo_bed_messages++;
            bedMessages[kol_vo_bed_messages] = "Публичный"; kol_vo_bed_messages++;
            bedMessages[kol_vo_bed_messages] = "Приватный"; kol_vo_bed_messages++;
            bedMessages[kol_vo_bed_messages] = "Паразит"; kol_vo_bed_messages++;
            bedMessages[kol_vo_bed_messages] = "Прости тут"; kol_vo_bed_messages++;
            bedMessages[kol_vo_bed_messages] = "Менуэт"; kol_vo_bed_messages++;
            bedMessages[kol_vo_bed_messages] = "Молодец"; kol_vo_bed_messages++;
            bedMessages[kol_vo_bed_messages] = "Щель"; kol_vo_bed_messages++;

            bool sos = false;
            //FileStream file2 = null;


            try
            {
                file2 = new FileStream(Const.peregovory, FileMode.Open); //создаем файловый поток
            }
            catch (System.IO.FileNotFoundException)
            {
                sos = true;
                textBox2.Text = "";
                return;
            }

            file2.Close();
            file2 = new FileStream(Const.peregovory, FileMode.Open); //создаем файловый поток
            StreamReader reader = new StreamReader(file2); // создаем «потоковый читатель» и связываем его с файловым потоком

            this.Height = 651;
            this.Width = 630;

            int i = 0;
            while (reader.Peek() >= 0)
            {
                string stroka_iz_faila = reader.ReadLine().Trim();
                string[] podstroki = stroka_iz_faila.Split(new String[] { Const.rasd }, StringSplitOptions.None);

                if (podstroki.Length > 2)
                {
                    messages[i].day = Convert.ToDateTime(podstroki[0]);
                    messages[i].login = podstroki[1];
                    messages[i].text = podstroki[2].Replace(Const.rasd_enter, Environment.NewLine);

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
                DateTime thisDay = Time.GetNetworkTime();
                String dateStr = thisDay.ToString(Const.data);
                String dateStrfors = thisDay.ToString(Const.data);

                textBox2.AppendText(dateStr + Environment.NewLine + login + ":   " +
                    textBox1.Text + Environment.NewLine);
                File.AppendAllText(Const.peregovory, Environment.NewLine + dateStr + Const.rasd + login + Const.rasd + textBox1.Text.Replace(Environment.NewLine, Const.rasd_enter));
                File.AppendAllText(Const.NewMessages, dateStr + Const.rasd + login + Const.rasd + textBox1.Text.Replace(Environment.NewLine, Const.rasd_enter) + Environment.NewLine);
            }

            textBox1.Text = null;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            string[] podstroki = textBox1.Text.Split(new String[] { " ", ",", Environment.NewLine }, StringSplitOptions.None);

            for (int i = 0; i < podstroki.Length; i++)
            {
                if (bedMessages.Contains(podstroki[i]))
                {
                    string antipm = "";
                    for (int irep = 0; irep < podstroki[i].Length; irep++)
                    {
                        antipm = antipm + "*";
                    }

                    textBox1.Text = textBox1.Text.Replace(podstroki[i], antipm);
                }
            }
        }
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            string[] podstroki = textBox2.Text.Split(new String[] { " ", ",", Environment.NewLine }, StringSplitOptions.None);

            for (int i = 0; i < podstroki.Length; i++)
            {
                if (bedMessages.Contains(podstroki[i]))
                {
                    string antipm = "";
                    for (int irep = 0; irep < podstroki[i].Length; irep++)
                    {
                        antipm = antipm + "*";
                    }

                    textBox2.Text = textBox2.Text.Replace(podstroki[i], antipm);
                }
            }
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
            FileStream config = new FileStream(Const.config, FileMode.Open);
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

                File.WriteAllText(Const.config, textBox1.Font.FontFamily.Name.ToString() +
                    "$" + textBox1.Font.Size.ToString() + 
                    "$" + textBox1.Font.Italic.ToString() +
                    "$" + textBox1.Font.Bold.ToString() + 
                    "$" + textBox1.ForeColor.ToArgb());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
            File.WriteAllText(Const.AllMessages, string.Empty);
            Process myProcess = Process.Start("cmd", "/C start /B get.exe Const.peregovory Const.peregovory");
            do
            {
                if (!myProcess.HasExited)
                {
                    // Refresh the current process property values.
                    myProcess.Refresh();
                }
            }
            while (!myProcess.WaitForExit(10000));


            FileStream file2 = new FileStream(Const.NewMessages, FileMode.Open);
            StreamReader reader = new StreamReader(file2); // создаем «потоковый читатель» и связываем его с файловым потоком

            while (reader.Peek() >= 0)
            {
                string stroka_iz_faila = reader.ReadLine().Trim();
                File.AppendAllText(Const.peregovory, Environment.NewLine + stroka_iz_faila);
            }

            reader.Close(); //закрываем поток

            textBox2.Clear();
            Form2_Load(sender, e);

            Process.Start("cmd", "/C start /B put.exe Const.peregovory Const.peregovory");


            string[] podstroki = textBox2.Text.Split(new String[] { " ", ",", Environment.NewLine }, StringSplitOptions.None);

            for (int i = 0; i < podstroki.Length; i++)
            {
                if (bedMessages.Contains(podstroki[i]))
                {
                    string antipm = "";
                    for (int irep = 0; irep < podstroki[i].Length; irep++)
                    {
                        antipm = antipm + "*";
                    }

                    textBox2.Text = textBox2.Text.Replace(podstroki[i], antipm);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Process.Start("put.exe", "peregovory.txt peregovory.txt");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string[] podstroki = textBox1.Text.Split(new String[] { " ", "," }, StringSplitOptions.None);
            
            for (int i = 0; i < podstroki.Length; i++)
            {
                if (bedMessages.Contains(podstroki[i]))
                {
                    string antipm = "";
                    for (int irep = 0; irep < podstroki[i].Length; irep++)
                    {
                        antipm = antipm + "*";
                    }

                    textBox1.Text = textBox1.Text.Replace(podstroki[i], antipm);
                }
            }
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
        }

        private void этоМатToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            bedMessages[kol_vo_bed_messages] = textBox2.SelectedText; kol_vo_bed_messages++;
        }

        private void pictureBox_Chat_Click(object sender, EventArgs e)
        {

        }
    }
}
using System;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{

    public struct Polzovatel
    {
        public string login;
        public string password;
    }

    public partial class LoginForm : Form
    {
        public Polzovatel user1;
        public static Polzovatel[] usery = new Polzovatel[500];
        public static int kolichestvo_userov = 0;
        public static bool savepass = false;
        public static string saveduser = File.ReadAllText("saveduser.txt");
        public static string savedparol = File.ReadAllText("savedparol.txt");
        public static Button[] LangButtons = new Button[100];
        public int LangBattonCount = 0;

        public void Buttons()
        {

            String LangPath = Application.StartupPath + "\\Lang";
            String[] FileList = Directory.GetFiles(LangPath, "*.txt");
            LangBattonCount = FileList.Length;
            for (int n = 0; n < LangBattonCount; n++)
            {
                LangButtons[n] = new Button();
                LangButtons[n].Top = 5 + 28 * n;
                LangButtons[n].Height = 23;
                LangButtons[n].Width = 50;
                LangButtons[n].Text = Path.GetFileName(FileList[n]).Replace(".txt", "");
                LangButtons[n].MouseClick += new MouseEventHandler(LangChange_Click);
                this.Controls.Add(LangButtons[n]);
            }

        }


        public void ChangeLang(String Lang, object sender, EventArgs e)
        {
            String FileName = Application.StartupPath + "\\Lang\\" + Lang + ".txt";
            StreamReader stream = new StreamReader(FileName, Encoding.UTF8);
            //Если не обнулять строку, у тебя один раз язык сменится и все
            string CurrentLine = "";

            while (CurrentLine != null)
            {
              
                    button1.Text = Parameter(CurrentLine, "SiGn In", button1.Text);
                    PPorolTextBox.Text = Parameter(CurrentLine, "PaSsWoRd", PPorolTextBox.Text);
                    LoginTextBox.Text = Parameter(CurrentLine, "LoGiN", LoginTextBox.Text);
                    label1.Text = Parameter(CurrentLine, "AuThOrIzAtIoN", label1.Text);
                    linkLabel1.Text = Parameter(CurrentLine, "SiGn Up", linkLabel1.Text);
                    savepassbox.Text = Parameter(CurrentLine, "SaVe", savepassbox.Text);
                    button3.Text = Parameter(CurrentLine, "AdMiN", button3.Text);
                    this.Text = Parameter(CurrentLine, "SiGn In", this.Text);
                    CurrentLine = " ";
                  
                CurrentLine = stream.ReadLine();

            }
            //Потому что вот здесь она станет null, и больше никогда в условие не зайдет
            stream.Close();
        }


           
        
        public LoginForm()
        {
            InitializeComponent();
            if (File.ReadAllText("savedparol.txt") == "Пароль") 
            {
                savepassbox.Checked = false;
                savepass = false;
            }
            else
            {
                savepassbox.Checked = true;
                savepass = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoginTextBox.Text = File.ReadAllText("saveduser.txt");
            PPorolTextBox.Text = File.ReadAllText("savedparol.txt");

            File.WriteAllText("AllPolzovoteli.txt", string.Empty);
            GetPut.Get("password3.txt");

            FileStream file2 = new FileStream("NewPolzovoteli.txt", FileMode.Open);
            StreamReader reader = new StreamReader(file2);

            while (reader.Peek() >= 0)
            {
                string stroka_iz_faila = reader.ReadLine().Trim();
                File.AppendAllText("password3.txt", Environment.NewLine + stroka_iz_faila);
            }

            reader.Close();
            GetPut.Put("password3.txt");

            file2 = new FileStream("password3.txt", FileMode.Open);
            reader = new StreamReader(file2);

            int i = 0;
            while (reader.Peek() >= 0)
            {
                string stroka_iz_faila = reader.ReadLine().Trim();
                string[] podstroki = stroka_iz_faila.Split(new Char[] { ' ' });

                if (podstroki.Length > 1 &&
                    !String.IsNullOrEmpty(podstroki[0]) &&
                    !String.IsNullOrEmpty(podstroki[1]))
                {
                    usery[i].login = podstroki[0];
                    usery[i].password = podstroki[1];
                    i++;
                }
            }
            kolichestvo_userov = i;
            reader.Close();
            Buttons();
        }


        private void Button1_Click(object sender, EventArgs e)
        {
            user1.password = PPorolTextBox.Text;
            PPorolTextBox.PasswordChar = '*';

            string user = user1.login;
            string password = user1.password;

            bool net_polzovatelya = true;
            bool ne_pomnit_parol = true;
            for (int i = 0; i < kolichestvo_userov; i++)
            {
                if (usery[i].login == user)
                {
                    net_polzovatelya = false;
                    if (usery[i].password == user1.password)
                    {
                        ne_pomnit_parol = false;
                    }
                }
            }

            if (net_polzovatelya)
            {
                MessageBox.Show("Сиди, вспоминай имя, идиот/n Invalid login");
            }
            else if (ne_pomnit_parol)
            {
                MessageBox.Show("Сиди, вспоминай пароль, идиот/n Wrong password");
            }
            else
            {
                if (!File.Exists(textBox1.Text + "-users.txt"))
                {
                    File.AppendAllLines(textBox1.Text + "-users.txt", new string[]{LoginTextBox.Text});
                }
                if (!File.Exists(textBox1.Text + ".txt"))
                {
                    File.WriteAllText(textBox1.Text + ".txt", "");
                }
                Chat chatForm = new Chat(LoginTextBox.Text, textBox1.Text);                
                chatForm.ShowDialog();
			      }

	          if (savepass)
    	      {
	              File.WriteAllText("saveduser.txt", user);
                File.WriteAllText("savedparol.txt", password);
  	        }
            else
            {
                File.WriteAllText("saveduser.txt", user);
                File.WriteAllText("savedparol.txt", "Пароль");
            }
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegistrationForm rf = new RegistrationForm();
            rf.ShowDialog();
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

        private void TextBox1_Leave(object sender, EventArgs e)
        {
            if (PPorolTextBox.Text == "")
            {
                PPorolTextBox.Text = "Пароль";
            }
        }

        private void PPorolTextBox_Enter(object sender, EventArgs e)
        {
            if (PPorolTextBox.Text == "Пароль")
            {
                PPorolTextBox.Text = "";
            }
        }

        private void LoginTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Button1_Click(sender, null);
            }
        }

        private void PPorolTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Button1_Click(sender, null);
            }
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            savepass = savepassbox.Checked;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Admin adm = new Admin();
            adm.ShowDialog();
        }
       
        String Parameter (String LineFromFile, String ParamName, String DefaultValue)
        {
            String ParamValue = DefaultValue;
            String ParamFullName = ParamName + " = ";
            if ((LineFromFile.Length > ParamFullName.Length) && LineFromFile.Substring(0, ParamFullName.Length) == ParamFullName)
            {
                ParamValue = LineFromFile.Substring(ParamFullName.Length);
            }
            return ParamValue;
        }
       /* private void LangButtonClick(object sender, EventArgs e)
        {
            for (int n = 0; n<LangBattonCount; n++)
            {
                if (sender.Equals(LangButtons[n]))
                {
                    ChangeLang(LangButtons[n].Text);
                }
            }
        }*/

        public void LangChange_Click(object sender, EventArgs e)
        {
            for (int n = 0; n < LangBattonCount; n++)
            {
                //Получается, ты последовательно меняла все языки по клику на любую кнопку. Надо же только один раз менять
                if (sender.Equals(LangButtons[n]))
                {
                    ChangeLang(LangButtons[n].Text, sender, e);
                }
            }
            
        }
    }
}

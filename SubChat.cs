using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    namespace ChatProcessing
    {
        

        public class Soobshenie : IComparable
        {
            public String login;
            public String text;
            public DateTime day;
            public int CompareTo(object obj)
            {
                Soobshenie othermessage = obj as Soobshenie;
                return this.day.CompareTo(othermessage.day);
            }
        };

        public struct Polzovatel_view
        {
            public String shrift;
            public String color;
        };

        public class SubChat
        {
            public List<String> usersallowed;
            public String subchatname;
            public SubChat(String subchatname)
            {
                this.subchatname = subchatname;
                try
                {
                    usersallowed = new List<String>(File.ReadAllLines(subchatname + "-users.txt"));
                } catch (FileNotFoundException)
                {
                    usersallowed = new List<String> { "" };
                }
            }

            public String PrintChat(String user, List<Soobshenie> messages)
            {
                if (!usersallowed.Contains(user))
                {
                    throw new UnauthorizedAccessException();
                }

                String text = "";

                messages.Sort();

                for (int i = 0; i < messages.Count(); i++)
                {
                    text += messages[i].day + Environment.NewLine;
                    text += "     " + messages[i].login + "  сказал(а):  ";
                    text += messages[i].text + Environment.NewLine;
                }
                return text;
            }
            public List<Soobshenie> LoadChat(String user)
            {
                if (!usersallowed.Contains(user))
                {
                    throw new UnauthorizedAccessException();
                }
                List<Soobshenie> messages = new List<Soobshenie>();
                File.WriteAllText(subchatname + ".txt", File.ReadAllText(subchatname + ".txt").Trim(new char[] { '\r', '\n' }));
                FileStream file2;
                file2 = new FileStream(subchatname + ".txt", FileMode.Open); //создаем файловый поток
                StreamReader reader = new StreamReader(file2); // создаем «потоковый читатель» и связываем его с файловым потоком

                int i = 0;
                while (reader.Peek() >= 0)
                {
                    string stroka_iz_faila = reader.ReadLine().Trim();
                    List<String> SubLines = new List<String>(stroka_iz_faila.Split(new String[] { "$~#~@*&" }, StringSplitOptions.None));

                    if (SubLines.Count >= 3)
                    {
                        messages.Add(new Soobshenie());
                        messages[i].day = Convert.ToDateTime(SubLines[0]);
                        messages[i].login = SubLines[1];
                        messages[i].text = SubLines[2].Replace("%%%%", Environment.NewLine);
                        i++;
                    }
                    else
                    {
                        //throw new Exception("Malformed subchat.");
                    }
                }
                reader.Close(); //закрываем поток
                return messages;
            }
        }
    }
    
}

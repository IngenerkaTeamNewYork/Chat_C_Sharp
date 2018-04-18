using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WindowsFormsApplication1
{
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
            }
            catch (FileNotFoundException)
            {
                //FIXME купить пирожком
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
                if (messages[i].text.Split(new char[]{' '})[0] != "&^&") {
                    text += messages[i].day + Environment.NewLine;
                    text += "     " + messages[i].login + "  сказал(а):  ";
                    text += messages[i].text + Environment.NewLine;
                } 
                else
                {
                    text += messages[i].day + Environment.NewLine;
                    text += "     " + messages[i].login + "  отправил(а):  ";
                    text += " -== Ссылка на файл " + messages[i].text.Split(new char[] { ' ' })[1] + " ==-" + Environment.NewLine;
                }
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
            FileStream file2 = new FileStream(subchatname + ".txt", FileMode.Open); //создаем файловый поток
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

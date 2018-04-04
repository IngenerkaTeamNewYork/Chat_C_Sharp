using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
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
    }

    public struct Polzovatel_view
    {
        public String shrift;
        public String color;
    }
}

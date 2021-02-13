using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter
{
    public class Czas : IKonwerter
    {
        public string Name => "Zegar";

        public List<string> Unit => new List<string>()
        {
            "24h",
            "12h"
        };
        public string Konwert(string Z, string Do, string wartosc)
        {
            if (Z == "24h")
            {
                DateTime t;
                t = DateTime.Parse(wartosc);
                if (Do == "12h")
                {
                    return t.ToString("hh:mm tt");
                }
            }
            if (Z == "12h")
            {
                DateTime t;
                t = DateTime.Parse(wartosc);
                if (Do == "24h")
                {
                    return t.ToString("HH:mm");
                }
            }
            return " ";
        }
    }
}
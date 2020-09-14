using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterJednostek2
{
    public class KonwerterTemperatury: iKonwerter
    {
        public KonwerterTemperatury() { }

        public string Name => "KonwerterTemperatury";

        public List<string> Units => new List<string>()
        {
            "C", "F", "K"
        };

        public double convert(double a, string from, string to)
        {
            double b=a;

            if(from == "C" && to == "F")
            {
                b = a * 9 / 5 + 32;
            }
            else if (from == "F" && to == "C")
            {
                b = (a - 32) * 5 / 9;
            }
            else if (from == "C" && to == "K")
            {
                b = a + 273.15;
            }
            else if (from == "K" && to == "C")
            {
                b = a - 273.15;
            }
            else if (from == "K" && to == "F")
            {
                b = (a - 273.15) * 9 / 5 + 32;
            }
            else if (from == "F" && to == "K")
            {
                b = (a - 32) * 5 / 9 + 273.15;
            }

            return b;
        }
        public override string ToString() { return Name; }
    }
}

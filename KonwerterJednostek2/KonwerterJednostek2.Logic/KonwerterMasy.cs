using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterJednostek2
{
    public class KonwerterMasy: iKonwerter
    {
        public KonwerterMasy() { }

        public string Name => "KonwerterMasy";

        public List<string> Units => new List<string>()
        {
            "kg", "lbs", "dag"
        };

        public double convert(double a, string from, string to)
        {
            double b = a;

            if (from == "kg" && to == "lbs")
            {
                b = a * 2.20462262;
            }
            else if (from == "lbs" && to == "kg")
            {
                b = a * 1 / 2.20462262;
            }
            else if (from == "kg" && to == "dag")
            {
                b = a * 100;
            }
            else if (from == "lbs" && to == "dag")
            {
                b = a * (1 / 2.20462262) * 100;
            }
            else if (from == "dag" && to == "kg")
            {
                b = a / 100;
            }
            else if (from == "dag" && to == "lbs")
            {
                b = a * 2.20462262 / 100;
            }

            return b;
        }
        public override string ToString() { return Name; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterJednostek2
{
    public class KonwerterPowierzchni : iKonwerter
    {
        public string Name => "KonwerterPowierzchni";

        public List<string> Units => new List<string>()
        {
            "ha", "ar"
        };

        public double convert(double a, string from, string to)
        {
            double b = a;

            if (from == Units[0] && to == Units[1])
            {
                b = a * 100;
            }
            else if (from == Units[1] && to == Units[0])
            {
                b = a / 100;
            }

            return b;
        }
        public override string ToString() { return Name; }
    }
}

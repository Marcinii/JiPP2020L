using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterJednostek
{
    public class KonwerterZegar : IKonwerter
    {
        public string Name => "Zegar";

        public List<string> Units => new List<string>()
        {
            "24h", "12h"
        };

        public decimal Konwerter(string jednostkaZ, string jednostkaDO, decimal konwertowanaWartosc)
        {
            decimal b = konwertowanaWartosc;

            if (konwertowanaWartosc > 11)
            {
                b = konwertowanaWartosc - 12;
            }

            return b;
        }

        public override string ToString() { return Name; }
    }
}
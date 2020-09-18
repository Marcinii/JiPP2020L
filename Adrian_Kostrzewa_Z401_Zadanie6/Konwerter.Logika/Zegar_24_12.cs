using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter.Logika
{
    public class Zegar_12_24 : Ikonwenter
    {
        public string Nazwa => "Czas:12_24";

        public List<string> Jednostki => new List<string>()
        {
            "24h",
            "12h"
        };

        public double Konwer(string z, string n, double w)
        {
            if (w == 0 || w == 12 || w == 24) { return 12; }
            else if (w < 12) { return w; }
            else { return w - 12; }
        }
    }
}

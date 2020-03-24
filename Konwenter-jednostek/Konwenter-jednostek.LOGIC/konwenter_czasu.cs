using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwenter_jednostek
{
    public class konwenter_czasu : IKonwenter
    {

        public List<string> Jednostki => new List<string>()
        {
            "24h",
            "12h"
        };
        public string Nazwa => "Czasu";
        public string jednostkii => "24h, 12h";
        public double Konwertuj(string z, string doo, double a)
        {
            if (z == "24h" & doo == "12h" & a>12)
            {
                return a - 12 ;
            }
            else if (z == "12h" & doo == "24h" & a>12)
            {
                return a + 12;
            }

            return a;
        }
    }
}
 
    
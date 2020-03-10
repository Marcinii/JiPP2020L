using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterJednostek
{
    public class KonwerterPredkosc: IKonwerter
    {
        public List<string> Jednostki => new List<string>()
        {
            "Km/h",
            "M/s",
        };

        public string Name => "Prędkości";
        public string jednostki => "km/h m/s";
        public double Konwertuj(string jw, string jdo, double wynik)
        {
            if ( jw== "Km/h" & jdo == "M/s")
            {
                return wynik / 3.6;
            }
            else if (jw == "M/s" & jdo == "Km/h")
            {
                return wynik * 3.6;
            }

            return wynik;
        }
    }
}

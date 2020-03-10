using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterJednostek
{
    public class KonwerterOdleglosc: IKonwerter
    {
        public List<string> Jednostki => new List<string>()
        {
            "Kilometry",
            "Mile",
        };

        public string Name => "Odległości";
        public string jednostki => "km, mile";

        public double Konwertuj(string jw, string jd, double wynik)
        {
            if (jw == "Kilometry" && jd == "Mile")
            {
                return wynik * 0.62137;
            }
            else if (jw == "Mile" & jd == "Kilometry")
            {
                return wynik / 0.62137;
            }

            return wynik;
        }
    }
}

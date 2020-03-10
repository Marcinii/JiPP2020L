using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterJednostek
{
    public class KonwerterWaga : IKonwerter
    {
        public List<string> Jednostki => new List<string>()
        {
            "Kilogramy",
            "Funty"
        };

        public string Name => "Wagi";
        public string jednostki => "kg, funty";
        public double Konwertuj(string jw, string jd, double wynik)
        {

            if (jw == "Kilogramy" & jd == "Funty")
            {
                return wynik * 2.2046;
            }
            else if (jw == "Funty" & jd == "Kilogramy")
            {
                return wynik / 2.2046;
            }

            return wynik;
        }
    }
}

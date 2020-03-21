using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter_jednostek
{
    public class Odleglosc : IKonwerter
    {
        public string Nazwa => "Dlugosci";

        public List<string> Jednostki => new List<string>()
        {
            "km",
            "mi"
        };

        public string Konwerter(string JednostkaZ, string JednostkaNa, string WDK)
        {
            double WartoscDoKonwersji = double.Parse(WDK);
            double Wynik = 0;
            if (JednostkaZ == "km" && JednostkaNa == "mi")
            {
                Wynik = WartoscDoKonwersji / 1.609344;
            }

            if (JednostkaZ == "mi" && JednostkaNa == "km")
            {
                Wynik = WartoscDoKonwersji * 1.609344;
            }

            if (JednostkaZ == "km" && JednostkaNa == "km")
            {
                Wynik = WartoscDoKonwersji;
            }

            if (JednostkaZ == "mi" && JednostkaNa == "mi")
            {
                Wynik = WartoscDoKonwersji;
            }

            return Wynik.ToString("F");
        }
    }
}


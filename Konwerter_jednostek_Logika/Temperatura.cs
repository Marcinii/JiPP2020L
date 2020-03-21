using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter_jednostek
{
    public class Temperatura : IKonwerter
    {
        public string Nazwa => "Temperatury";

        public List<string> Jednostki => new List<string>()
        {
            "C",
            "K",
            "F"
        };

        public string Konwerter(string JednostkaZ, string JednostkaNa, string WDK)
        {
            double WartoscDoKonwersji = double.Parse(WDK);
            double Wynik=0;
            if (JednostkaZ == "C" && JednostkaNa == "F") {
                Wynik = 32.0 + 9.0 / 5.0 * WartoscDoKonwersji;
            }

            if (JednostkaZ == "F" && JednostkaNa == "C")
            {
                Wynik = 5.0 / 9.0 * (WartoscDoKonwersji- 32.0);
            }

            if (JednostkaZ == "C" && JednostkaNa == "K")
            {
                Wynik = WartoscDoKonwersji + 273.15;
            }

            if (JednostkaZ == "K" && JednostkaNa == "C")
            {
                Wynik = WartoscDoKonwersji - 273.15;
            }

            if (JednostkaZ == "K" && JednostkaNa == "F")
            {
                Wynik = 32.0 + 9.0 / 5.0 * (WartoscDoKonwersji - 273.15);
            }

            if (JednostkaZ == "F" && JednostkaNa == "K")
            {
                Wynik = 5.0 / 9.0 * (WartoscDoKonwersji - 241.15);
            }

            if (JednostkaZ == "C" && JednostkaNa == "C")
            {
                Wynik = WartoscDoKonwersji;
            }

            if (JednostkaZ == "K" && JednostkaNa == "K")
            {
                Wynik = WartoscDoKonwersji;
            }

            if (JednostkaZ == "F" && JednostkaNa == "F")
            {
                Wynik = WartoscDoKonwersji;
            }

            return Wynik.ToString("F");
        }
    }
}

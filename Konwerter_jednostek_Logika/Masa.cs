using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter_jednostek
{
    public class Masa : IKonwerter
    {
        public string Nazwa => "Masy";

        public List<string> Jednostki => new List<string>()
        {
            "kg",
            "f"
        };

        public string Konwerter(string JednostkaZ, string JednostkaNa, string WDK)
        {
            double WartoscDoKonwersji = double.Parse(WDK);
            double Wynik = 0;
            if (JednostkaZ == "kg" && JednostkaNa == "f")
            {
                Wynik = WartoscDoKonwersji * 2.20462;
            }

            if (JednostkaZ == "f" && JednostkaNa == "kg")
            {
                Wynik = WartoscDoKonwersji / 2.20462;
            }

            if (JednostkaZ == "kg" && JednostkaNa == "kg")
            {
                Wynik = WartoscDoKonwersji;
            }

            if (JednostkaZ == "f" && JednostkaNa == "f")
            {
                Wynik = WartoscDoKonwersji;
            }

            return Wynik.ToString("F");
        }
    }
}

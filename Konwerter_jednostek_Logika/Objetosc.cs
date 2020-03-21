using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter_jednostek
{
    public class Objetosc : IKonwerter
    {
        public string Nazwa => "Objetosci";

        public List<string> Jednostki => new List<string>()
        {
            "l",
            "gal"
        };

        public string Konwerter(string JednostkaZ, string JednostkaNa, string WDK)
        {
            double WartoscDoKonwersji = double.Parse(WDK);
            double Wynik = 0;
            if (JednostkaZ == "l" && JednostkaNa == "gal")
            {
                Wynik = WartoscDoKonwersji / 4.54609;
            }

            if (JednostkaZ == "gal" && JednostkaNa == "l")
            {
                Wynik = WartoscDoKonwersji * 4.54609;
            }

            if (JednostkaZ == "l" && JednostkaNa == "l")
            {
                Wynik = WartoscDoKonwersji;
            }

            if (JednostkaZ == "gal" && JednostkaNa == "gal")
            {
                Wynik = WartoscDoKonwersji;
            }

            return Wynik.ToString("F");
        }
    }
}

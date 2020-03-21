using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter_jednostek
{
    class Czas : IKonwerter
    {
        public string Nazwa => "Czas";

        public List<string> Jednostki => new List<string>()
        {
            "24h (gg:mm)",
            "12h (gg:mmAM/PM)"
        };

        public string Konwerter(string JednostkaZ, string JednostkaNa, string WartoscDoKonwersji)
        {
            string Wynik = "błędne dane";

            if (JednostkaZ == "24h (gg:mm)" && JednostkaNa == "12h (gg:mmAM/PM)")
            {
                int godzina = int.Parse(String.Concat(WartoscDoKonwersji[0], WartoscDoKonwersji[1]));
                if ((WartoscDoKonwersji.Length == 5) && (godzina>=0) && (godzina <24))
                {
                    if (godzina == 0) Wynik = String.Concat("12:", WartoscDoKonwersji[3], WartoscDoKonwersji[4], "AM");
                    if ((godzina > 0) && (godzina < 10)) Wynik = String.Concat("0", godzina.ToString(), ":", WartoscDoKonwersji[3], WartoscDoKonwersji[4], "AM");
                    if ((godzina >= 10) && (godzina < 12)) Wynik = String.Concat(godzina.ToString(), ":", WartoscDoKonwersji[3], WartoscDoKonwersji[4], "AM");
                    if (godzina == 12) Wynik = String.Concat("12:", WartoscDoKonwersji[3], WartoscDoKonwersji[4], "PM");
                    if ((godzina > 12) && (godzina < 22)) Wynik = String.Concat("0", (godzina-12).ToString(), ":", WartoscDoKonwersji[3], WartoscDoKonwersji[4], "PM");
                    if ((godzina == 22) || (godzina == 23)) Wynik = String.Concat((godzina-12).ToString(), ":", WartoscDoKonwersji[3], WartoscDoKonwersji[4], "PM");
                }
            }
           
            if (JednostkaZ == "12h (gg:mmAM/PM)" && JednostkaNa == "24h (gg:mm)")
            {
                int godzina = int.Parse(String.Concat(WartoscDoKonwersji[0], WartoscDoKonwersji[1]));
                if ((WartoscDoKonwersji.Length == 7) && (godzina >= 1) && (godzina <= 12))
                {
                    if ((godzina == 12) && (String.Concat(WartoscDoKonwersji[5], WartoscDoKonwersji[6])=="AM")) Wynik = String.Concat("00:", WartoscDoKonwersji[3], WartoscDoKonwersji[4]);
                    if ((godzina >= 1) && (godzina < 10) && (String.Concat(WartoscDoKonwersji[5], WartoscDoKonwersji[6]) == "AM")) Wynik = String.Concat("0", godzina.ToString(), ":", WartoscDoKonwersji[3], WartoscDoKonwersji[4]);
                    if ((godzina >= 10) && (godzina < 12) && (String.Concat(WartoscDoKonwersji[5], WartoscDoKonwersji[6]) == "AM")) Wynik = String.Concat(godzina.ToString(), ":", WartoscDoKonwersji[3], WartoscDoKonwersji[4]);
                    if ((godzina == 12) && (String.Concat(WartoscDoKonwersji[5], WartoscDoKonwersji[6]) == "PM")) Wynik = String.Concat("12:", WartoscDoKonwersji[3], WartoscDoKonwersji[4]);
                    if ((godzina >= 1) && (godzina <= 12) && (String.Concat(WartoscDoKonwersji[5], WartoscDoKonwersji[6]) == "PM")) Wynik = String.Concat((godzina + 12).ToString(), ":", WartoscDoKonwersji[3], WartoscDoKonwersji[4]);
                }
            }

            if (JednostkaZ == "24h (gg:mm)" && JednostkaNa == "24h (gg:mm)")
            {
                Wynik = WartoscDoKonwersji;
            }

            if (JednostkaZ == "12h (gg:mmAM/PM)" && JednostkaNa == "12h (gg:mmAM/PM)")
            {
                Wynik = WartoscDoKonwersji;
            }

            return Wynik;
        }
    }
}

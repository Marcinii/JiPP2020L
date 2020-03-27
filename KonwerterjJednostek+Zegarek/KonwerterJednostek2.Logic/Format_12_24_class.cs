using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterjJednostek2
{
    public class Format_12_24_class : IKonwerter
    {
        public string Name => "12_24";

        public List<string> Units => new List<string>()
        {
            "24",
            "12"
        };

        public double Konwerter(string jednostka_bazowa, string jednostka_docelowa, double wartosc)
        {
            double wynik = 0;


            //przelicza 24 na 12
            if (jednostka_bazowa == "24" && jednostka_docelowa == "12")
            {
                int godzina_liczba;
                string godzina_tekst;

                if (wartosc > 720)
                {
                    wartosc = wartosc - 720;
                }

                godzina_tekst = (wartosc.ToString()).Remove(2);
                godzina_liczba = int.Parse(godzina_tekst);
                

                wynik = godzina_liczba;
            }

            //przelicza 12 na 24
            if (jednostka_bazowa == "12" && jednostka_docelowa == "24")
            {
                wynik = 0;
            }

            return wynik;

        }

        public string Konwerter2(string wartosc)
        {
            string godzina_tekst = wartosc.Remove(2);
            string minuta_tekst = wartosc.Remove(0, 2);
            string wynik = "";

            if (double.Parse(godzina_tekst)<12)
            {
                for(int i=1;i<13;i++)
                {
                    if (double.Parse(godzina_tekst) == i) { wynik = godzina_tekst + minuta_tekst + " AM"; }
                }
            }

            if (double.Parse(godzina_tekst) >= 12)
            {
                for (int i = 12; i < 22; i++)
                {
                    if (double.Parse(godzina_tekst) == i) { wynik = "0"+ (i-12).ToString() +  minuta_tekst + " PM"; }
                }

                for (int i = 22; i < 24; i++)
                {
                    if (double.Parse(godzina_tekst) == i) { wynik = (i - 12).ToString() +  minuta_tekst + " PM"; }
                }
            }

            return wynik;
        }
    }
}

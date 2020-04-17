using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterJednostek2.Logic
{
    public class Czas_class: IKonwerter
    {
        public string Name => "Czas";

        public List<string> Units => new List<string>()
        {
            "G",
            "M",
            "S",

        };

        public double Konwerter(string jednostka_bazowa, string jednostka_docelowa, double wartosc)
        {
            double wynik = 0;

            //przelicza minute na godzine
            if (jednostka_bazowa == "M" && jednostka_docelowa == "G")
            {
                //Console.WriteLine("Ilosc Kilogramow: ");
                wynik = wartosc / 60;
            }

            //przelicza godzine na minute
            if (jednostka_bazowa == "G" && jednostka_docelowa == "M")
            {
                //Console.WriteLine("Ilosc Funtow: ");
                wynik = wartosc * 60;
            }

            //przelicza sekunde na minute
            if (jednostka_bazowa == "S" && jednostka_docelowa == "M")
            {
                //Console.WriteLine("Ilosc Funtow: ");
                wynik = wartosc / 60;
            }

            //przelicza minute na sekunde
            if (jednostka_bazowa == "M" && jednostka_docelowa == "S")
            {
                //Console.WriteLine("Ilosc Funtow: ");
                wynik = wartosc * 60;
            }

            //przelicza 24 na 12
            if (jednostka_bazowa == "24" && jednostka_docelowa == "12")
            {
                string godzina_tekst;
                double godzina_liczba;
                string minuta;
                string wynik_tmp;

                godzina_tekst = (wartosc.ToString()).Remove(2);
                minuta = (wartosc.ToString()).Remove(0,2);

                godzina_liczba = double.Parse(godzina_tekst);

                if(godzina_liczba>12)
                {
                    godzina_liczba = godzina_liczba - 12;
                }

                wynik_tmp = godzina_liczba.ToString() + minuta;

                wynik= double.Parse(wynik_tmp);
            }

            //przelicza 12 na 24
            if (jednostka_bazowa == "12" && jednostka_docelowa == "24")
            {
                wynik = 0;
            }

            return wynik;
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterjJednostek2
{
    public class Czas_class: IKonwerter
    {
        public string Name => "Czas";

        public List<string> Units => new List<string>()
        {
            "Godzina",
            "Minuta",
            "Sekunda"
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

            return wynik;
        }
    }
}


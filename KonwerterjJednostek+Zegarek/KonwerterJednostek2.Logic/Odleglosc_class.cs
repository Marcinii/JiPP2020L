using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterjJednostek2
{
    public class Odleglosc_class : IKonwerter
    {
        public string Name => "Odleglosc";

        public List<string> Units => new List<string>()
        {
            "KM",
            "MI",
            "M"
        };

        public double Konwerter(string jednostka_bazowa, string jednostka_docelowa, double wartosc)
        {
            double wynik = 0;

            //przelicza kilometry na Mile
            if (jednostka_bazowa == "KM" && jednostka_docelowa == "MI")
            {
                //Console.WriteLine("Ilosc Mil: ");
                wynik = wartosc / 1.609344;
            }

            //przelicza mile na kilometry
            if (jednostka_bazowa == "MI" && jednostka_docelowa == "KM")
            {
                //Console.WriteLine("Ilosc Kilometrow: ");
                wynik = wartosc * 1.609344;
            }

            //przelicza metry na kilometry
            if (jednostka_bazowa == "M" && jednostka_docelowa == "KM")
            {
                //Console.WriteLine("Ilosc Kilometrow: ");
                wynik = wartosc / 1000;
            }

            //przelicza kilometry na metry
            if (jednostka_bazowa == "KM" && jednostka_docelowa == "M")
            {
                //Console.WriteLine("Ilosc Kilometrow: ");
                wynik = wartosc * 1000;
            }


            return wynik;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterJednostek2.Logic
{
    public class Masa_class : IKonwerter
    {
        public string Name => "Masa";

        public List<string> Units => new List<string>()
        {
            "KG",
            "F",
            "G"
        };

        public double Konwerter(string jednostka_bazowa, string jednostka_docelowa, double wartosc)
        {
            double wynik = 0;

            //przelicza funt na kilogram
            if (jednostka_bazowa == "F" && jednostka_docelowa == "KG")
            {
                //Console.WriteLine("Ilosc Kilogramow: ");
                wynik = wartosc * 0.45359237;
            }

            //przelicza kilogram na Funt
            if (jednostka_bazowa == "KG" && jednostka_docelowa == "F")
            {
                //Console.WriteLine("Ilosc Funtow: ");
                wynik = wartosc / 0.45359237;
            }

            //przelicza gram na kilogram
            if (jednostka_bazowa == "G" && jednostka_docelowa == "KG")
            {
                //Console.WriteLine("Ilosc Kilogramow: ");
                wynik = wartosc /1000;
            }

            //przelicza kilogram na gram
            if (jednostka_bazowa == "KG" && jednostka_docelowa == "G")
            {
                //Console.WriteLine("Ilosc Kilogramow: ");
                wynik = wartosc * 1000;
            }

            return wynik;
        }
    }
}

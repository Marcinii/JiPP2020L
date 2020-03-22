using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterjJednostek2
{
    public class Temperatura_class: IKonwerter
    {
        public string Name => "Temperatura";

        public List<string> Units => new List<string>()
        {
            "Celsjusz",
            "Farenheit",
            "Kelvin"
        };
     
        public double Konwerter(string jednostka_bazowa, string jednostka_docelowa, double wartosc)
        {
            double wynik = 0;

            //przelicza celsjusza na faranhajty
            if (jednostka_bazowa == "C" && jednostka_docelowa == "F")
            {
                //Console.WriteLine("Ilosc stopni Farenheita: ");
                wynik = wartosc * 1.8 + 32;
            }

            //przelicza faranhajty na celsjusza
            if (jednostka_bazowa == "F" && jednostka_docelowa == "C")
            {
                //Console.WriteLine("Ilosc stopni Celsjusza: ");
                wynik = (wartosc - 32) / 1.8;
            }

            //przelicza celsjusza na kelwina
            if (jednostka_bazowa == "C" && jednostka_docelowa == "K")
            {
                //Console.WriteLine("Ilosc stopni Celsjusza: ");
                wynik = wartosc + 273.15;
            }

            //przelicza kelwina na celsjusza
            if (jednostka_bazowa == "K" && jednostka_docelowa == "C")
            {
                //Console.WriteLine("Ilosc stopni Celsjusza: ");
                wynik = wartosc - 273.15;
            }
            
            return wynik;
        }
    }
}

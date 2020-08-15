using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie_1
{
    public class Przelicznik
    {
        public static double ZamianaTemperatur(double jednostka, string wartosc)
        {
            double wynik;
            if (wartosc == "1") // C na F
            {
                wynik = jednostka * 1.8000 + 32.00; return wynik;
            }
            else if (wartosc == "2") // F na C
            {
                wynik = (jednostka - 32.00) / 1.8000; return wynik;
            }
            else
            {
                Console.WriteLine("Niewlasciwa liczba!");
                return 0;
            }
        }
        public static double ZamianaDlugosci(double jednostka, string wartosc)
        {
            double wynik;
            if (wartosc == "1") // Kilometry na Mile
            {
                wynik = jednostka * 0.62137;
                return wynik;
            }
            else if (wartosc == "2") // Mile na kilometry
            {
                wynik = jednostka / 0.62137;
                return wynik;
            }
            else
            {
                Console.WriteLine("Niewlasciwa liczba!");
                return 0;
            }
        }
        public static double ZamianaMas(double jednostka, string wartosc)
        {
            double wynik;
            if (wartosc == "1") // Kilogramy na Funty
            {
                wynik = jednostka * 2.2046;
                return wynik;
            }
            else if (wartosc == "2") // Funty na Kilogramy
            {
                wynik = jednostka / 2.2046;
                return wynik;
            }
            else
            {
                Console.WriteLine("Niewlasciwa liczba!");
                return 0;
            }
        }
    }
}
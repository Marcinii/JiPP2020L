using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter_jednostek
{
    class Konwersja
    {
        public double Temperatura(double Celsjusz, double Farenheit)
        {
            double wynik = 0;

            //przelicza na faranhajty
            if (Celsjusz != 0)
            {
                Console.WriteLine("Ilosc stopni Farenheita: ");
                wynik = Celsjusz * 1.8 + 32;
            }

            //przelicza na celsjusza
            if (Farenheit != 0)
            {
                Console.WriteLine("Ilosc stopni Celsjusza: ");
                wynik = (Farenheit - 32) / 1.8;
            }

            return wynik;
        }

        public double Odleglosc(double Kilometr, double Mila)
        {
            double wynik = 0;

            //przelicza na Mile
            if (Kilometr != 0)
            {
                Console.WriteLine("Ilosc Mil: ");
                wynik = Kilometr / 1.609344;
            }

            //przelicza na kilometry
            if (Mila != 0)
            {
                Console.WriteLine("Ilosc Kilometrow: ");
                wynik = Mila * 1.609344;
            }

            return wynik;
        }

        public double Masa(double Kilogram, double Funt)
        {
            double wynik = 0;

            //przelicza na Kilogram
            if (Funt != 0)
            {
                Console.WriteLine("Ilosc Kilogramow: ");
                wynik = Funt * 0.45359237;
            }

            //przelicza na Funt
            if (Kilogram != 0)
            {
                Console.WriteLine("Ilosc Funtow: ");
                wynik = Kilogram / 0.45359237;
            }

            return wynik;
        }
    }

class Program
    {
        static void Main(string[] args)
        {

            int wybor = 0;
            double dane = 0;
            Konwersja konwertowanie = new Konwersja();

            while (wybor != 8)
            {
                Console.WriteLine
                ("Wybierz rodzaj konwersji: \n " +
                "1) Celsjusz na Fahrenheit \n " +
                "2) Fahrenheit na Celsjusz \n " +
                "3) Kilometry na Mile \n " +
                "4) Mile na Kilometry \n " +
                "5) Funty na Kilogramy \n " +
                "6) Kilogramy na Funty \n " +
                "7) EXIT");

                wybor = int.Parse(Console.ReadLine());

                if (wybor == 7) { break; }

                Console.WriteLine("Podaj dane: ");

                dane = int.Parse(Console.ReadLine());

                switch (wybor)
                {
                    case 1:
                        Console.WriteLine(konwertowanie.Temperatura(dane, 0));
                        break;
                    case 2:
                        Console.WriteLine(konwertowanie.Temperatura(0, dane));
                        break;

                    case 3:
                        Console.WriteLine(konwertowanie.Odleglosc(dane, 0));
                        break;
                    case 4:
                        Console.WriteLine(konwertowanie.Odleglosc(0, dane));
                        break;

                    case 5:
                        Console.WriteLine(konwertowanie.Masa(0, dane));
                        break;
                    case 6:
                        Console.WriteLine(konwertowanie.Masa(dane, 0));
                        break;

                    default:
                        Console.WriteLine("Podaj wartosc z zakresu 1-7");
                        break;
                }
                Console.WriteLine("");
            }

        }
    }
}

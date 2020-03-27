using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterjJednostek2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IKonwerter> Konwerters = new List<IKonwerter>()
            {
                new Temperatura_class(),
                new Odleglosc_class(),
                new Masa_class(),
                new Czas_class(),
                new Format_12_24_class()
            };

            Temperatura_class t1 = new Temperatura_class();
            bool czy_kontynowac = true;

            while (czy_kontynowac)
            {
                Console.WriteLine("Wybierz rodzaj konwersji: ");

                for(int i =0; i<Konwerters.Count; i++)
                {
                    Console.WriteLine("({0}) {1}", i + 1, Konwerters[i].Name);
                }

                //pobiera rodzaj miary
                string rodzaj_konwersji1 = Console.ReadLine();
                int rodzaj_konwersji2 = int.Parse(rodzaj_konwersji1);

                //pobiera jednostke bazową
                Console.WriteLine("Podaj jednostke bazowa:");
                string jednostka_bazowa1 = Console.ReadLine();

                //pobiera jednostke docelową
                Console.WriteLine("Podaj jednostke docelowa:");
                string jednostka_docelowa = Console.ReadLine();

                //pobiera wartość do konwersji
                Console.WriteLine("Podaj liczbe do konwersji");
                string wartosc1 = Console.ReadLine();

                //konwertuje pobraną wartość na liczbę
                double wartosc2 = double.Parse(wartosc1);

                double wynik = Konwerters[rodzaj_konwersji2 - 1].Konwerter(jednostka_bazowa1, jednostka_docelowa, wartosc2);

                Console.WriteLine("Wynik konwersji: {0}", wynik);
                Console.WriteLine("");

            }

        }
    }
}

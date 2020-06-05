using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterPrzedrostkow
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IPrzedrostki> Konwerters = new List<IPrzedrostki>()
            {
                new Deka_class(),
                new Hekto_class(),
                new Kilo_class()
                
            };

            bool czy_kontynowac = true;

            while (czy_kontynowac)
            {
                Console.WriteLine("Wybierz rodzaj konwersji: ");

                for (int i = 0; i < Konwerters.Count; i++)
                {
                    Console.WriteLine("({0}) {1}", i + 1, Konwerters[i].Name);
                }

                //pobiera rodzaj miary
                string rodzaj_konwersji1 = Console.ReadLine();
                int rodzaj_konwersji2 = int.Parse(rodzaj_konwersji1);

                //pobiera wartość do konwersji
                Console.WriteLine("Podaj liczbe do konwersji");
                string wartosc1 = Console.ReadLine();

                //konwertuje pobraną wartość na liczbę
                double wartosc2 = double.Parse(wartosc1);

                double wynik = Konwerters[rodzaj_konwersji2 - 1].Konwerter(wartosc2);

                Console.WriteLine("Wynik konwersji: {0}", wynik);
                Console.WriteLine("");

            }

        }
    }
}

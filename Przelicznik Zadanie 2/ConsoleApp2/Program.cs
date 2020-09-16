using System;
using System.Collections.Generic;

namespace PrzelicznikLogic
{
    class Program
    {
        static void Main(string[] args)
        {
            List<PrzelicznikI> przeliczniki = new List<PrzelicznikI>()
       {
            new Masa(),
            new Prędkość(),
            new Temperatury(),
            new Długości(),

        };
            Console.WriteLine("Wybierz przelicznik: ");
            for (int i = 0; i < przeliczniki.Count; i++)
            {
                Console.WriteLine("{0}. {1}", i + 1, przeliczniki[i].Name);
            }
            string wyborW = Console.ReadLine();
            int wybor = int.Parse(wyborW);
            Console.WriteLine("Podaj jednostę wyjściowią: ");
            string jednostkaW = Console.ReadLine();
            Console.WriteLine("Podaj jednostkę docelową: ");
            string jednostkaD = Console.ReadLine();
            Console.WriteLine("Podaj liczbę do konwersji: ");
            string liczbaPodana = Console.ReadLine();
            int liczba = int.Parse(liczbaPodana);

            double wynik = przeliczniki[wybor - 1].przelicz(jednostkaW, jednostkaD, liczba);
            Console.WriteLine("Wynik konwersji: {0}", wynik);
            Console.ReadKey();
        }
    }
}

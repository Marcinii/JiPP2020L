using System;
using System.Collections.Generic;

namespace KonwerterJednostek
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IKonwerter> konwertery = new List<IKonwerter>()
            {
                new KonwerterTemperatury(),
                new KonwerterDlugosci(),
                new KonwerterMasy(),
                new KonwerterCzasu()
            };

            bool shouldContinue = true; 

            while (shouldContinue)
            {

                Console.WriteLine("---------------------------\n");
                Console.WriteLine("    KONWERTER JEDNOSTEK\n");
                Console.WriteLine("---------------------------\n");
                Console.WriteLine("Witaj w konwerterze jednostek, wybierz jedną z dostępnych opcji:\n");


                for(int i = 0; i < konwertery.Count; i++)
                {
                    Console.WriteLine("({0}) {1}", i + 1, konwertery[i].Name);
                }

                string wprowadzonyWybor = Console.ReadLine();
                int wybor = int.Parse(wprowadzonyWybor);

                Console.WriteLine("Podaj jednostkę Z: ");
                string jednostkaZ = Console.ReadLine();

                Console.WriteLine("Podaj jednostkę DO: ");
                string jednostkaDO = Console.ReadLine();

                Console.WriteLine("Podaj liczbę do konwersji: ");
                string wprowadzonaWartosc = Console.ReadLine();
                decimal wartosc = decimal.Parse(wprowadzonaWartosc);

                decimal rezultat = konwertery[wybor - 1].Konwerter(jednostkaZ, jednostkaDO, wartosc);
                Console.WriteLine("Wynik konwersji: {0}", rezultat);

                shouldContinue = false;
                }
            }
        }
    }

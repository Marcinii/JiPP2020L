using System;
using System.Collections.Generic;

namespace Konwerter_console
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Iconverter> converters = new List<Iconverter>()
            {
                new CelToFar(),
                new FarToCel(),
                new KgToFu(),
                new FuToKg(),
                new KmToMi(),
                new MiToKm(),
                new MeToKm(),
                new MinToSec(),
                new SecToMin()
            };

            bool shouldContinue = true;

            while (shouldContinue)
            {
                Console.WriteLine("Wybierz Opcje: ");

                for(int i=0; i < converters.Count; i++)
                {
                    Console.WriteLine("({0}) {1}", i+1, converters[i].name);
                }

                string inputChoice = Console.ReadLine();
                int choice = int.Parse(inputChoice);

                Console.WriteLine("Podaj liczbe do konwersji: ");
                string inputValue = Console.ReadLine();
                double value = double.Parse(inputValue);

                double result = converters[choice - 1].Convert(value);

                Console.WriteLine("Wynik konwersji: {0}", result);

                shouldContinue = false;
            }
        }
    }
}

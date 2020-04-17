using przelicznik;
using System;
using System.Collections.Generic;

namespace Konwerter
{

    class Konwerter
    {
        static void Main(string[] args)
        {
            List<IConverter> converters = new List<IConverter>()
            {
            new TemperatureConverter(),
            new WeightConverter(),
            new LenghtConverter(),
            new TimeConverter(),
            new ClockConverter()
            };
            bool shouldContinue = true;
            while (shouldContinue)
            {
                Console.WriteLine("Konwerter jednostek\r\n");
                Console.WriteLine("Jaką operację chcesz wykonać? Wybierz z listy poniżej:\n");
                for (int i = 0; i < converters.Count; i++)
                {
                    Console.WriteLine("({0}) {1}", i + 1, converters[i].Name);
                }
                string inputChoice = Console.ReadLine();
                int choice = int.Parse(inputChoice); //

                Console.WriteLine("Podaj jednostkę Z: ");
                string unitFrom = Console.ReadLine();

                Console.WriteLine("Podaj jednostkę Do: ");
                string unitTo = Console.ReadLine();

                Console.WriteLine("Podaj liczbę do konwersji: ");
                string inputValue = Console.ReadLine();
                decimal value = decimal.Parse(inputValue);
               
                decimal result = converters[choice - 1].Convert(unitFrom, unitTo, value);

                Console.WriteLine("Wynik konwersji: {0}", result);
            }
        }
    }
}


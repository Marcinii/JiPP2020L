using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IConverter> converters = new List<IConverter>()
            {
                new TemperatureConverter(),
                new LengthConverter(),
                new WeightConverter(),
                new TimeConverter()
            };

            Console.WriteLine("Project 1 - Maciej Dziub Z404");
            Console.WriteLine("------------------------------------");
            Console.WriteLine("CONVERTER 2.0 | C/F | km/mi | kg/g/lb | min/s");
            Console.WriteLine("------------------------------------");

            bool shouldContinue = true;

            while (shouldContinue)
            {
                Console.WriteLine("Wybierz opcje: ");
                for(int i = 0; i < converters.Count; i++)
                {
                    Console.WriteLine($"{i + 1} {converters[i].Name}");
                }

                string inputChoice = Console.ReadLine();
                int choice = int.Parse(inputChoice);

                Console.WriteLine("Podaj jednostke z: ");
                string unitFrom = Console.ReadLine().ToLower();

                Console.WriteLine("Podaj jednostke do: ");
                string unitTo = Console.ReadLine().ToLower();

                Console.WriteLine("Podaj liczbe: ");
                string inputValue = Console.ReadLine();
                decimal value = decimal.Parse(inputValue);

                decimal result = converters[choice - 1].Convert(unitFrom, unitTo, value);

                Console.WriteLine($"Wynik konwersji: {result}");

                shouldContinue = false;
            }

            Console.ReadKey();
        }
    }
}
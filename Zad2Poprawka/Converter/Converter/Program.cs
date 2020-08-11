using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converter
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IConverter> converters = new List<IConverter>
            {
                new LenghtConverter(),
                new TemperatureConverter(),
                new WeightConverter(),
                new QuantityConverter()
            };



            bool shouldContinue = true;
            while (shouldContinue)
            {
                Console.WriteLine("Wybierz konwerter: \n");

                for (int i = 0; i < converters.Count; i++)
                {
                    Console.WriteLine("({0}) {1}", i + 1, converters[i].name);
                }

                string inputChoice = Console.ReadLine();

                List<string> units = converters[int.Parse(inputChoice) - 1].Units;
                Console.WriteLine("\nDostępne jednostki wybranego konwertera: ");

                for (int i = 0; i < units.Count; i++)
                {
                    Console.WriteLine(units[i]);
                }

                Console.WriteLine("\n");

                Console.WriteLine("Podaj jednoste z: ");
                string unitFrom = Console.ReadLine();

                Console.WriteLine("Podaj jednoste do: ");
                string unitTo = Console.ReadLine();

                Console.WriteLine("Podaj liczbe do konwersji: ");
                string inputValue = Console.ReadLine();

                int choice = int.Parse(inputChoice);
                int intInputValue = int.Parse(inputValue);

                decimal result = converters[choice - 1].Convert(unitFrom, unitTo, intInputValue);

                Console.WriteLine("Wynik konwersji: {0}", result);
            }
        }


    }
}

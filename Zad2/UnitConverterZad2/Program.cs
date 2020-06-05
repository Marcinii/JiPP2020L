using System;
using System.Collections.Generic;
using UnitConverterZad2;

namespace UnitConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IConverter> converters = new List<IConverter>()
            {
                new LengthConverter(),
                new TemperatureConverter(),
                new MassConverter(),
                new PowerConverter()
            };

            bool pom = true;

            while (pom)
            {
                for (int i = 0; i < converters.Count; i++)
                {
                    Console.Write("({0}) {1} (", i + 1, converters[i].Name);
                    foreach (string unit in converters[i].Units)
                    {
                        Console.Write("{0} ", unit);
                    }
                    Console.WriteLine(")");
                }

                string inputChoice = Console.ReadLine();
                int choice = int.Parse(inputChoice);

                Console.WriteLine("Podaj jednostke Z: ");
                string unitFrom = Console.ReadLine();

                Console.WriteLine("Podaj jednostke Do: ");
                string unitTo = Console.ReadLine();

                Console.WriteLine("Podaj liczbe do konwersji: ");
                string inputValue = Console.ReadLine();
                decimal value = decimal.Parse(inputValue);

                decimal result = converters[choice - 1].Convert(unitFrom, unitTo, value);
                Console.WriteLine("Wynik konwersji: {0}", result);
            }
        }
    }
}
using System;
using System.Collections.Generic;

namespace UnitConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            List<ConverterInterface> converters = new List<ConverterInterface>()
            {
                new TemperatureConverter(),
                new LenghtConverter(),
                new WeightConverter(),
            };

            for (int i = 0; i < converters.Count; i++)
            {
                Console.WriteLine("({0}) {1}", i, converters[i].Name);
            }
            string userInputConverter = Console.ReadLine();
            int converter = int.Parse(userInputConverter);
            Console.WriteLine("Unit we are converting from: ");
            string from = Console.ReadLine();
            Console.WriteLine("Unit we are converting to: ");
            string to = Console.ReadLine();
            Console.WriteLine("Unit value: ");
            string userInputValue = Console.ReadLine();
            decimal value = decimal.Parse(userInputValue);

            decimal result = converters[converter].Convert(from, to, value);
            Console.WriteLine("{0}: {1}", to, result);
        }
    }
}
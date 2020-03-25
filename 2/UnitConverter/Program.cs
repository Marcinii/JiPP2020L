using System.Collections.Generic;

namespace UnitConverter
{
    class Program
    {
        static void Main()
        {
            List<IConverter> Converters = new List<IConverter>()
            {
                new TemperatureConverter(),
                new LenghtConverter(),
                new WeightConverter(),
            };

            for (int i = 0; i < Converters.Count; i++)
            {
                System.Console.WriteLine("({0}) {1}", i, Converters[i].Name);
            }
            string userInputConverter = System.Console.ReadLine();
            int converter = int.Parse(userInputConverter);
            System.Console.WriteLine("Unit we are converting from: ");
            string from = System.Console.ReadLine();
            System.Console.WriteLine("Unit we are converting to: ");
            string to = System.Console.ReadLine();
            System.Console.WriteLine("Unit value: ");
            string userInputValue = System.Console.ReadLine();
            decimal value = decimal.Parse(userInputValue);

            decimal result = Converters[converter].Convert(from, to, value);
            System.Console.WriteLine("{0}: {1}", to, result);
        }
    }
}
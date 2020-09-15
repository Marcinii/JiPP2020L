using System;
using System.Collections.Generic;

namespace KonwerterJednostek
{
    class Program
    {
        private void Konwerter()
        {
            List<IConverter> converters = new List<IConverter>()
            {
                new TemperatureConverter(),
                new LengthConverter(),
                new WeightConverter()
            };
            bool shouldContinue = true;
            while (shouldContinue)
            {
                Console.WriteLine("Jaki rodzaj jednostkek chciałbyś przekonwertować?");
                for (int i = 0; i < converters.Count; i++)
                {
                    Console.WriteLine("({0}) {1}", i + 1, converters[i].Name);
                }
                Console.WriteLine("--------------------------------------------------------");

                Console.Write("Wybor: ");
                int.TryParse(Console.ReadLine(), out int choise);

                Console.Write("Podaj jednostkę do konwersji: ");
                string unitFrom = Console.ReadLine();

                Console.Write("Podaj jednostkę na którą konwertujesz: ");
                string unitTo = Console.ReadLine();

                Console.Write("Podaj liczbę do konwersji: ");
                decimal.TryParse(Console.ReadLine(), out decimal value);

                decimal result = converters[choise - 1].Convert(unitFrom, unitTo, value);
                Console.WriteLine(value + unitFrom + " = " + result + unitTo);

                Console.WriteLine("Czy zakończyć program? Y/N");
                shouldContinue = false;
                if (Console.ReadLine().ToUpper() != "Y")
                {
                    shouldContinue = true;
                    Console.Clear();
                }
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Witaj!");
            new Program().Konwerter();
        }
    }
}

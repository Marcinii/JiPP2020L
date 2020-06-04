using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter
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
                new VolumeConverter(),
                new ClockConverter()
            };

            bool shouldContinue = true;

            while (shouldContinue)
            {
                Console.WriteLine("Wybierz opcję: ");
                
                for(int i = 0; i < converters.Count; i++)
                {
                    Console.WriteLine("({0}) {1}", i + 1, converters[i].Name);
                }

                string inputChoice = Console.ReadLine();
                int choice = int.Parse(inputChoice); // TryParse!

                Console.WriteLine("Podaj jednostkę Z: ");
                string unitFrom = Console.ReadLine();

                Console.WriteLine("Podaj jednostkę Do: ");
                string unitTo = Console.ReadLine();

                Console.WriteLine("Podaj liczbę do konwersji: ");
                string inputValue = Console.ReadLine();              
                string value = inputValue; // TryParse!

                string result = converters[choice - 1].Convert(unitFrom, unitTo, value);

                Console.WriteLine("Wynik konwersji: {0}", result);

                shouldContinue = false;
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitCorventer
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IConverter> converters = new List<IConverter>()
            {
                new TemperaturConv(),
                new LenghtConv(),
                new WeightConv(),
                new SurfaceConv()
            };

            bool shouldControle = true;
            while (shouldControle)
            {

                Console.WriteLine("Wybierz");
                
                for(int i = 0; i < converters.Count; i++)
                {
                    Console.WriteLine("({0}) {1}", i + 1, converters[i].Name);
                }

                string inputChoice = Console.ReadLine();
                int choice = int.Parse(inputChoice);

                Console.WriteLine("Podaj jednostkę z: ");
                string unitFrom = Console.ReadLine();

                Console.WriteLine("Podaj jednostkę do: ");
                string unitTo = Console.ReadLine();

                Console.WriteLine("Podaj liczbę do konwersji: ");
                string inputValue = Console.ReadLine();


                decimal value = decimal.Parse(inputValue);

                decimal result = converters[choice - 1].Convert(unitFrom, unitTo, value);
                Console.WriteLine("Wynik to: {0}", result);

                shouldControle = false;

            }
        }
    }
}
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
            List<Interface> converters = new List<Interface>()
            {
                new Speed(),
                new Length(),
                new Weight(),
                new Temperature(),
                new Time()
            };

            bool shouldContinue = true;

            while (shouldContinue)
            {
                Console.WriteLine("konwertery: ");

                for(int i = 0; i < converters.Count; i++)
                {
                    Console.WriteLine("({0}) {1}", i + 1, converters[i].Name);
                }

                string inputChoice = Console.ReadLine();


                Console.WriteLine("Jednostka bazowa");
                string unitFrom = Console.ReadLine();

                Console.WriteLine("Jednostka Finalna");
                string unitTo = Console.ReadLine();

                Console.WriteLine("liczba");
                string inputValue = Console.ReadLine();

                int choice = int.Parse(inputChoice);
                double value = double.Parse(inputValue); 

                Console.WriteLine("Wynik : {0}", converters[choice - 1].Convert(unitFrom, unitTo, value));

                shouldContinue = false;
            }
        }
    }
}

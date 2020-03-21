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
                new TimeConverter()
            };

            while (true)
            {
                Console.WriteLine("---- Unit Converter ----");
                Console.WriteLine("Choose an operation");
                for (int i = 0; i < converters.Count; i++)
                {
                    Console.WriteLine("{0} - {1} Converter", i + 1, converters[i].Name);
                }

                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Please enter a valid operation");
                }


                double number;
                Console.WriteLine("Please enter a unit to convert from");
                string unitFrom = Console.ReadLine();

                Console.WriteLine("Please enter a unit to convert to");
                string unitTo = Console.ReadLine();

                Console.WriteLine("Please enter the value to convert");
                if (!double.TryParse(Console.ReadLine(), out number))
                {
                    Console.WriteLine("Please enter a valid number");
                }
                else
                {
                    double result = converters[choice - 1].convert(unitFrom, unitTo, number);
                    Console.WriteLine("{0} {1}", result, converters[choice - 1].Shortcuts[unitTo]);
                }
            }
            


        }
    }
}

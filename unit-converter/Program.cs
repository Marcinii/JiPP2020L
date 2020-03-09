using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace unit_converter
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IConverter> availableConverters = new List<IConverter>()
            {
                new LengthConverter(),
                new TemperatureConverter(),
                new WeightConverter(),
                new TimeConverter(),
            };

            Console.WriteLine("*** Unit converter ***");
            for (int i = 0; i < availableConverters.Count; i++)
            {
                Console.WriteLine("{0} - {1}", i + 1, availableConverters[i].Name);
            }

            bool programRunning = true;
            IConverter selectedConverter;

            string oper;
            while (programRunning)
            {
                Console.WriteLine("Please select a category: ");
                oper = Console.ReadLine();
                switch (oper)
                {
                    case "1":
                        selectedConverter = availableConverters[0];
                        break;
                    case "2":
                        selectedConverter = availableConverters[1];
                        break;
                    case "3":
                        selectedConverter = availableConverters[2];
                        break;
                    case "4":
                        selectedConverter = availableConverters[3];
                        break;
                    default:
                        Console.WriteLine("*** Invalid selection ***");
                        break;
                }
            }
        }
    }
}

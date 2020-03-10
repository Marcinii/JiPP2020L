using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace unit_converter
{
    class Program
    {
        static void EnterData(IConverter converter)
        {
            Console.WriteLine("*** Available Units ***");
            foreach (string unit in converter.AvailableUnits)
            {
                Console.WriteLine(unit);
            }
            Console.WriteLine("Please enter the source unit: ");
            string sourceUnit = Console.ReadLine();
            if (converter.AvailableUnits.IndexOf(sourceUnit) == -1)
            {
                Console.WriteLine("*** Invalid unit selected ***");
            }
            else
            {
                Console.WriteLine("Please enter the target unit: ");
                string targetUnit = Console.ReadLine();
                if (converter.AvailableUnits.IndexOf(targetUnit) == -1)
                {
                    Console.WriteLine("*** Invalid unit selected ***");
                }
                else
                {
                    Console.WriteLine("Please enter the value to convert: ");
                    string strValue = Console.ReadLine();
                    if (!converter.IsInputValid(strValue))
                    {
                        Console.WriteLine("*** Invalid value ***");
                    }
                    else
                    {
                        double result = converter.Convert(sourceUnit, targetUnit, double.Parse(strValue));
                        Console.WriteLine($"\nConversion result: {Math.Round(result, 2, MidpointRounding.AwayFromZero)}\n");
                    }
                }
            }
        }
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
            bool programRunning = true;
            IConverter selectedConverter;

            string oper;
            while (programRunning)
            {
                Console.WriteLine("Please select a category: ");
                for (int i = 0; i < availableConverters.Count; i++)
                {
                    Console.WriteLine($"{i + 1} - {availableConverters[i].Name}");
                }
                Console.WriteLine("0 - Exit");

                oper = Console.ReadLine();
                switch (oper)
                {
                    case "1":
                        selectedConverter = availableConverters[0];
                        EnterData(selectedConverter);
                        break;
                    case "2":
                        selectedConverter = availableConverters[1];
                        EnterData(selectedConverter);
                        break;
                    case "3":
                        selectedConverter = availableConverters[2];
                        EnterData(selectedConverter);
                        break;
                    case "4":
                        selectedConverter = availableConverters[3];
                        EnterData(selectedConverter);
                        break;
                    case "0":
                        programRunning = false;
                        break;
                    default:
                        Console.WriteLine("*** Invalid selection ***");
                        break;
                }
            }
        }
    }
}

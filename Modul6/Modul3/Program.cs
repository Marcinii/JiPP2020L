using Modul2;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            List <IConverter> converters = new List<IConverter>()
            {
                new TempConverter(),
                new DistConverter(),
                new WeightConverter(),
                new BytesConverter()
            };

            bool condition = true;
            while (condition)
            {
                Console.WriteLine("Select converter: ");

                for (int i=0; i < converters.Count; i++)
                {
                    Console.WriteLine("({0}) {1}", i + 1, converters[i].Name);
                }
                Console.WriteLine("(5) EXIT");
                
                Console.Write("Your choice: ");
                string caseSwitch = Console.ReadLine();
                int choice = int.Parse(caseSwitch);

                if(choice == 5)
                {
                    condition = false;
                }
                else
                {
                    Console.Write("Select start unit: ");
                    string unitFrom = Console.ReadLine();

                    Console.Write("Select end unit: ");
                    string unitTo = Console.ReadLine();

                    Console.Write("Write amount to be converted: ");
                    string valueToConvert = Console.ReadLine();
                    double value = double.Parse(valueToConvert);

                    double result = converters[choice - 1].Convert(unitFrom, unitTo, value);

                    Console.WriteLine("Result: {0} {1} = {2} {3}", value, unitFrom, result, unitTo);
                }
            }
            }
    }
}
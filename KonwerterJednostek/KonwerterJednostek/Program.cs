using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace KonwerterJednostek
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IConverter> listOfConverters = new List<IConverter>()
            {
                new LengthConverter(),
                new TemperatureConverter(),
                new WeightConverter(),
                new PowerConverter()
            };

            int option = -1;
            while (option != 0)
            {
                Console.WriteLine("Wybierz konwerter:");
                for (int i = 0; i < listOfConverters.Count; i++){ 
                    Console.WriteLine("{0} - {1}", i + 1, listOfConverters[i].Name);
                }
                Int32.TryParse(Console.ReadLine(), out option);

                Console.WriteLine("Dostępne jednostki: ");
                for (int i = 0; i < listOfConverters[option-1].Units.Count; i++)
                {
                    Console.WriteLine("{0} - {1}", i + 1, listOfConverters[option-1].Units[i]);
                }

                Console.Write("Jednostka przeliczana: ");
                int from;
                Int32.TryParse(Console.ReadLine(), out from);

                Console.Write("Jednostka docelowa: ");
                int to;
                Int32.TryParse(Console.ReadLine(), out to);

                Console.Write("Wartość przeliczana: ");
                double unitToConvert;
                Double.TryParse(Console.ReadLine(), out unitToConvert);

                double result = listOfConverters[option-1].Convert(from - 1, to - 1, unitToConvert);
                Console.WriteLine("Wynik konwersji to: {0} \n", result);
            }
            Console.ReadKey();
                       













            //private const int NUMBER_OF_OPTIONS = 6;
            //static void Main(string[] args)
            //{            
            //    UnitConverterService unitConverterService = new UnitConverterService();
            //    double result;
            //    unitConverterService.welcomeScreen();
            //    unitConverterService.displayMainMenu();
            //    int option = unitConverterService.getOptionFromUser();
            //    while (option != 0)
            //    {
            //        if (option <= NUMBER_OF_OPTIONS && option>=0)
            //        {
            //            result = unitConverterService.unitConversion(option);
            //            unitConverterService.printResult(result);
            //            unitConverterService.displayMainMenu();
            //            option = unitConverterService.getOptionFromUser();
            //        }
            //        else
            //        {
            //            Console.WriteLine("There is no option, try again");
            //            option = unitConverterService.getOptionFromUser();
            //        }
            //    }
            //}
        }
    }
}

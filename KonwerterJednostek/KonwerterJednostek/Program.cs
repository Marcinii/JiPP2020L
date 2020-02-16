using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterJednostek
{
    class Program
    {
        private const int NUMBER_OF_OPTIONS = 6;
        static void Main(string[] args)
        {            
            UnitConverterService unitConverterService = new UnitConverterService();
            double result;
            unitConverterService.welcomeScreen();
            unitConverterService.displayMainMenu();
            int option = unitConverterService.getOptionFromUser();
            while (option != 0)
            {
                if (option <= NUMBER_OF_OPTIONS)
                {
                    result = unitConverterService.unitConversion(option);
                    unitConverterService.printResult(result);
                    unitConverterService.displayMainMenu();
                    option = unitConverterService.getOptionFromUser();
                }
                else
                {
                    Console.WriteLine("There is no option, try again");
                    option = unitConverterService.getOptionFromUser();
                }
            }
        }
    }
}

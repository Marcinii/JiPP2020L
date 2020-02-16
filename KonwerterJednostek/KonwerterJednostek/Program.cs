using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterJednostek
{
    class Program
    {
        static void Main(string[] args)
        {            
            UnitConverterService unitConverterService = new UnitConverterService();
            double result;
            unitConverterService.welcomeScreen();
            unitConverterService.displayMainMenu();
            int option = unitConverterService.getOptionFromUser();
            while (option != 0)
            {
                result = unitConverterService.unitConversion(option);
                unitConverterService.printResult(result);
                unitConverterService.displayMainMenu();
                option = unitConverterService.getOptionFromUser();
            }
        }
    }
}

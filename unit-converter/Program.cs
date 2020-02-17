using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace unit_converter
{
    class Program
    {
        static void printMenu()
        {
            Console.WriteLine("1 - Celsius to Farenheit");
            Console.WriteLine("2 - Farenheit to Celsius");
            Console.WriteLine("3 - Kilometers to Miles");
            Console.WriteLine("4 - Miles to Kilometers");
            Console.WriteLine("5 - Kilograms to Pounds");
            Console.WriteLine("6 - Pounds to Kilograms");
        }
        static void Main(string[] args)
        {
            Console.WriteLine("*** Unit converter ***");
            Converter converter = new Converter();
            printMenu();
            string oper = Console.ReadLine();
            
            switch(oper)
            {
                case "1":
                    converter.celsiusToFahrenheit();
                    break;
                case "2":
                    converter.fahrenheitToCelsius();
                    break;
                case "3":
                    converter.kilometersToMiles();
                    break;
                case "4":
                    converter.milesToKilometers();
                    break;
                case "5":
                    converter.kilogramsToPounds();
                    break;
                case "6":
                    converter.poundsToKilograms();
                    break;
                default:
                    break;

            }
        }
    }
}

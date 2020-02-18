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
            Console.WriteLine("7 - Exit");
        }
        static void Main(string[] args)
        {
            Console.WriteLine("*** Unit converter ***");
            Converter converter = new Converter();
            printMenu();

            bool programRunning = true;
            string oper;

            while (programRunning)
            {
                Console.WriteLine("Please enter your selection: ");
                oper = Console.ReadLine();
                switch (oper)
                {
                    case "1":
                        Console.WriteLine("*** Converting Celsius to Farenheit ***");
                        converter.celsiusToFahrenheit();
                        break;
                    case "2":
                        Console.WriteLine("*** Converting Farenheit to Celsius ***");
                        converter.fahrenheitToCelsius();
                        break;
                    case "3":
                        Console.WriteLine("*** Converting Kilometers to Miles ***");
                        converter.kilometersToMiles();
                        break;
                    case "4":
                        Console.WriteLine("*** Converting Miles to Kilometers ***");
                        converter.milesToKilometers();
                        break;
                    case "5":
                        Console.WriteLine("*** Converting Kilograms to Pounds ***");
                        converter.kilogramsToPounds();
                        break;
                    case "6":
                        Console.WriteLine("*** Converting Pounds to Kilograms ***");
                        converter.poundsToKilograms();
                        break;
                    case "7":
                        Console.WriteLine("*** Exiting the program ***");
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

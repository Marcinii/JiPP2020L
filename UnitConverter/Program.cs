using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter
{
    class Program
    {
        static void printMenu()
        {
            Console.WriteLine("---- Unit Converter ----");
            Console.WriteLine("Choose an operation");
            Console.WriteLine("0 - Celsius to Farenheit");
            Console.WriteLine("1 - Farenheit to Celsius");
            Console.WriteLine("2 - Kilometers to Miles");
            Console.WriteLine("3 - Miles to Kilometers");
            Console.WriteLine("4 - Kilograms to Pounds");
            Console.WriteLine("5 - Pounds to Kilograms");
        }
        static void Main(string[] args)
        {
            printMenu();
            string operation = Console.ReadLine();
            int number = Convert.ToInt32(Console.ReadLine());
            double convertedValue;
            switch (operation)
            {
                case "0":
                    convertedValue = number * 1.8 + 32;
                    Console.WriteLine("{0}F", convertedValue);
                    break;
                case "1":
                    convertedValue = ((number - 32) * 5) / 9.0;
                    Console.WriteLine("{0}C", convertedValue);
                    break;
                case "2":
                    convertedValue = number * 0.62137;
                    Console.WriteLine("{0}mi", convertedValue);
                    break;
                case "3":
                    convertedValue = (number / 5.0) * 8;
                    Console.WriteLine("{0}km", convertedValue);
                    break;
                case "4":
                    convertedValue = number * 2.20462;
                    Console.WriteLine("{0}lbs", convertedValue);
                    break;
                case "5":
                    convertedValue = number / 2.2046;
                    Console.WriteLine("{0}kg", convertedValue);
                    break;
            }


        }
    }
}

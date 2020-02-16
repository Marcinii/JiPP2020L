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
            printMenu();
            string oper = Console.ReadLine();
            string input;
            double num;
            switch(oper)
            {
                case "1":
                    Console.WriteLine("Please enter the value to convert: ");
                    input = Console.ReadLine();
                    if (!Double.TryParse(input, out num))
                    {
                        Console.WriteLine("Invalid value. Please try again.");
                    }
                    else
                    {
                        Console.WriteLine($"{num} C equals to {(num * 1.8) + 32} F");
                    }
                    break;
                case "2":
                    break;
                case "3":
                    break;
                case "4":
                    break;
                case "5":
                    break;
                case "6":
                    break;
                default:
                    break;

            }
        }
    }
}

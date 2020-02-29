using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter
{
    class Converter
    {
        public Converter()
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
        protected void changeCelsiusToFahrenheit(double value)
        {
            double convertedValue = value * 1.8 + 32;
            Console.WriteLine("{0}F", convertedValue);
        }

        protected void changeFahrenheitToCelsius(double value)
        {
            double convertedValue = ((value - 32) * 5) / 9.0;
            Console.WriteLine("{0}C", convertedValue);
        }

        protected void changeKilometersToMiles(double value)
        {
            double convertedValue = value * 0.62137;
            Console.WriteLine("{0}mi", convertedValue);
        }

        protected void changeMilesToKilometers(double value)
        {
            double convertedValue = (value / 5.0) * 8;
            Console.WriteLine("{0}km", convertedValue);
        }

        protected void changeKilogramsToPounds(double value)
        {
            double convertedValue = value * 2.20462;
            Console.WriteLine("{0}lbs", convertedValue);
        }

        protected void changePoundsToKilograms(double value)
        {
            double convertedValue = value / 2.2046;
            Console.WriteLine("{0}kg", convertedValue);
        }

        protected void printError(string message)
        {
            Console.WriteLine(message);
        }

        public void convert() 
        {
            string operation = Console.ReadLine();
            double number;
            if (!double.TryParse(Console.ReadLine(), out number))
            {
                printError("Please enter a valid number");
            } else
            {
                switch (operation)
                {
                    case "0":
                        changeCelsiusToFahrenheit(number);
                        break;
                    case "1":
                        changeFahrenheitToCelsius(number);
                        break;
                    case "2":
                        changeKilometersToMiles(number);
                        break;
                    case "3":
                        changeMilesToKilometers(number);
                        break;
                    case "4":
                        changeKilogramsToPounds(number);
                        break;
                    case "5":
                        changePoundsToKilograms(number);
                        break;
                    default:
                        printError("Please enter a valid operation");
                        break;
                }
            }
        }
    }
}

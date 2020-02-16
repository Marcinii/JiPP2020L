using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterJednostek
{
    class UnitConverterService
    {
        public void welcomeScreen()
        {
            Console.WriteLine("Unit Converter" + Environment.NewLine);
        }
        public void displayMainMenu()
        {
            Console.WriteLine("1 - Celsius to Fahrenheit");
            Console.WriteLine("2 - Fahrenheit to Celsius");
            Console.WriteLine("3 - Kilometers to Miles");
            Console.WriteLine("4 - Miles to Kilometers");
            Console.WriteLine("5 - Kilograms to Pounds");
            Console.WriteLine("6 - Pounds to Kilograms");
            Console.WriteLine("0 - exit");
            Console.WriteLine(Environment.NewLine);
        }

        public int getOptionFromUser()
        {
            Console.Write("Choose option: ");
            int option = Convert.ToInt32(Console.ReadLine());
            return option;
        }

        private double getValueToConvertFromUser()
        {
            Console.Write("Value to convert: ");
            double variable = Convert.ToDouble(Console.ReadLine());
            return variable;
        }

        public double unitConversion(int option){
            Calculations calculations = new Calculations();
            double valueToConvert = getValueToConvertFromUser();
            switch (option)
            {
                case 1:
                    return calculations.convertCelsiusToFahrenheit(valueToConvert);
                case 2:
                    return calculations.convertFahrenheitToCelsius(valueToConvert);
                case 3:
                    return calculations.convertKilometersToMiles(valueToConvert);
                case 4:
                    return calculations.convertMilesToKilometers(valueToConvert);
                case 5:
                    return calculations.convertKilogramsToPounds(valueToConvert);
                case 6:
                    return calculations.convertPoundsToKilograms(valueToConvert);
                case 0:
                    return 0;
                default:
                    Console.WriteLine("There is no option, try again");
                    return 0;
            }
        }

        public void printResult(double result)
        {
            Console.WriteLine("Result: " + result + Environment.NewLine);
        }
    }
}

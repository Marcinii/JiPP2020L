using System;

namespace UnitConverter
{
    public class UnitConverter
    {
        private const string MenuKmToMiles = "1";
        private const string MenuMilesToKm = "2";
        private const string MenuLbToKg = "3";
        private const string MenuKgToLb = "4";
        private const string MenuCelsiusToFh = "5";
        private const string MenuFhToCelsius = "6";
        private const string MenuExit = "Q";
        private const string MenuExitAlternative = "q";

        public UnitConverter()
        {
            ShowMenu();
            GetMenuValueFromUser();
        }

        public static void ShowMenu()
        {
            Console.WriteLine("Welcome to Unit Converter, select option from menu below to start:");
            Console.WriteLine(MenuKmToMiles + " : convert Kilometers to Miles");
            Console.WriteLine(MenuMilesToKm + " : convert Miles to Kilometers");
            Console.WriteLine(MenuLbToKg + " : convert Pounds to Kilograms");
            Console.WriteLine(MenuKgToLb + " : convert Kilograms to Pounds");
            Console.WriteLine(MenuCelsiusToFh + " : convert Celsius to Fahrenheit");
            Console.WriteLine(MenuFhToCelsius + " : convert Fahrenheit to Celsius");
            Console.WriteLine(MenuExit + " : Quit");
        }

        public void GetMenuValueFromUser()
        {
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case MenuKmToMiles:
                    Console.WriteLine("Insert distance in" + UnitNamesConsts.Kilometers);
                    double kmDistance = System.Convert.ToDouble(Console.ReadLine());
                    double miles = new DistanceConverter().KilometersToMiles(kmDistance);
                    LogResultToConsole(UnitNamesConsts.Kilometers, kmDistance, UnitNamesConsts.Miles, miles);
                    break;
                case MenuMilesToKm:
                    Console.WriteLine("Insert distance in" + UnitNamesConsts.Miles);
                    double milesDistance = System.Convert.ToDouble(Console.ReadLine());
                    double km = new DistanceConverter().KilometersToMiles(milesDistance);
                    LogResultToConsole(UnitNamesConsts.Miles, milesDistance, UnitNamesConsts.Kilometers, km);
                    break;
                case MenuCelsiusToFh:
                    Console.WriteLine("Insert temperature in Celsius");
                    double tempCelsius = System.Convert.ToDouble(Console.ReadLine());
                    double fh = new TemperatureConverter().CelsiusToFahrenheit(tempCelsius);
                    LogResultToConsole(UnitNamesConsts.CelsiusDegrees, tempCelsius, UnitNamesConsts.FahrenheitDegrees,
                        fh);
                    break;
                case MenuFhToCelsius:
                    Console.WriteLine("Insert temperature in Fahrenheit");
                    double fhTemp = System.Convert.ToDouble(Console.ReadLine());
                    double celsius = new TemperatureConverter().FahrenheitToCelsius(fhTemp);
                    LogResultToConsole(UnitNamesConsts.FahrenheitDegrees, fhTemp, UnitNamesConsts.CelsiusDegrees,
                        celsius);
                    break;
                case MenuKgToLb:
                    Console.WriteLine("Insert weight in" + UnitNamesConsts.Kilograms);
                    double kgWeight = System.Convert.ToDouble(Console.ReadLine());
                    double pounds = new WeightConverter().KilogramsToPounds(kgWeight);
                    LogResultToConsole(UnitNamesConsts.Kilograms, kgWeight, UnitNamesConsts.Pounds, pounds);
                    break;
                case MenuLbToKg:
                    Console.WriteLine("Insert weight in" + UnitNamesConsts.Pounds);
                    double lbWeight = System.Convert.ToDouble(Console.ReadLine());
                    double kilograms = new WeightConverter().PoundsToKilograms(lbWeight);
                    LogResultToConsole(UnitNamesConsts.Pounds, lbWeight, UnitNamesConsts.Kilograms, kilograms);
                    break;
                case MenuExit:
                case MenuExitAlternative:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Wrong input, try again");
                    break;
            }

            GetMenuValueFromUser();
        }

        public void LogResultToConsole(string initialUnit, double initialValue, string resultUnit,
            double resultValue)
        {
            Console.WriteLine(initialValue + initialUnit + UnitNamesConsts.IsEqual +
                              resultValue + resultUnit);
        }
    }
}
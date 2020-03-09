using System;

namespace Converter
{
    public class Formulas
    {
        // Temperatures
        public static double CelsiusToFahrenheit(double inp) { return inp * (9 / 5) + 32; }
        public static double CelsiusToKelvin(double inp) { return inp + 273.15; }
        public static double FahrenheitToCelsius(double inp) { return (inp - 32) * 5 / 9; }
        public static double FahrenheitToKelvin(double inp) { return (inp + 459.67) * 5 / 9; }
        public static double KelvinToCelsius(double inp) { return inp - 273.15; }
        public static double KelvinToFahrenheit(double inp) { return (inp * 9 / 5) - 459.67; }
        // Mass
        public static double KilogramsToPounds(double inp) { return inp * 2.2046; }
        public static double KilogramsToOunces(double inp) { return inp * 35.2739619496; }
        public static double OuncesToPounds(double inp) { return inp * 0.0625; }
        public static double OuncesToKilograms(double inp) { return inp * 0.0283495231; }
        public static double PoundsToKilograms(double inp) { return inp / 2.2046; }
        public static double PoundsToOunces(double inp) { return inp / 0.0625; }
        // Distance
        public static double KilometersToMiles(double inp) { return inp * 0.621371192; }
        public static double MilesToKilometers(double inp) { return inp / 0.621371192; }

        //################################################

    }
    public class Units
    {
        public enum Unit
        {
            Celsius,
            Fahrenheit,
            Kelvin,
            Kilometers,
            Miles,
            Kilograms,
            Pounds,
            Ounces
        }
        public static string UnitName(Unit unit)
        {
            switch (unit)
            {
                case Unit.Celsius:
                    return "C";
                case Unit.Fahrenheit:
                    return "F";
                case Unit.Kelvin:
                    return "K";
                case Unit.Kilograms:
                    return "kg";
                case Unit.Pounds:
                    return "lb";
                case Unit.Ounces:
                    return "oz";
                case Unit.Kilometers:
                    return "km";
                case Unit.Miles:
                    return "mi";
                default:
                    return "";
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace UnitConverter.Lib
{
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
            Ounces,
            KilometersPerHour, // Kph
            MilesPerHour, // Mph
            MetersPerSecond, // Mps
            Knots
        }
        public static Unit UnitFromString(String unit)
        {
            switch (unit)
            {
                // Temperatures
                case "c":
                    return Unit.Celsius;
                case "f":
                    return Unit.Fahrenheit;
                case "k":
                    return Unit.Kelvin;
                // Mass
                case "kg":
                    return Unit.Kilograms;
                case "lb":
                    return Unit.Pounds;
                case "oz":
                    return Unit.Ounces;
                // Distance
                case "km":
                    return Unit.Kilometers;
                case "mi":
                    return Unit.Miles;
                // Speed
                case "km/h":
                    return Unit.KilometersPerHour;
                case "mi/h":
                    return Unit.MilesPerHour;
                case "m/s":
                    return Unit.MetersPerSecond;
                case "knots":
                    return Unit.Knots;
                default:
                    throw new UnexpectedEnumValueException<Unit>(unit);
            }
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
                case Unit.KilometersPerHour:
                    return "km/h";
                case Unit.MilesPerHour:
                    return "mi/h";
                case Unit.MetersPerSecond:
                    return "m/s";
                case Unit.Knots:
                    return "knots";
                default:
                    return "";
            }
        }
    }
}

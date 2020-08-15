using System;
using System.Collections.Generic;

namespace UnitConverter.Library
{
    public class DistanceConverter : IConverter
    {
        public string Name => "Distance";
        public List<string> Units => new List<string> { "km", "mi" };
        private static double conversionRatio = 0.621371;

        private double KilometersToMiles(double distance)
        {
            return distance * conversionRatio;
        }

        private double MilesToKilometers(double distance)
        {
            return distance / conversionRatio;
        }

        public double Convert(double inputValue, string inputUnit)
        {
            if (inputUnit == "km") 
            {
                return KilometersToMiles(inputValue);
            }
            else if (inputUnit == "mi")
            {
                return MilesToKilometers(inputValue);
            }
            throw new ArgumentException("Invalid input unit " + inputUnit);
        }
    }
}
using System;
using System.Collections.Generic;

namespace UnitConverter.Library
{
    public class WeightConverter : IConverter
    {
        public string Name => "Weight";
        public List<string> Units => new List<string> { "kg", "lb" };
        private static double conversionRatio = 2.2046;

        public double KilogramsToPounds(double weight)
        {
            return weight * conversionRatio;
        }

        public double PoundsToKilograms(double weight)
        {
            return weight / conversionRatio;
        }

        public double Convert(double inputValue, string inputUnit)
        {
            if (inputUnit == "kg")
            {
                return KilogramsToPounds(inputValue);
            }
            else if (inputUnit == "lb")
            {
                return PoundsToKilograms(inputValue);
            }
            throw new ArgumentException("Invalid input unit " + inputUnit);
        }

    }
}
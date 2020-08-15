using System;
using System.Collections.Generic;

namespace UnitConverter.Library
{
    public class PressureConverter : IConverter
    {
        public string Name => "Pressure";
        public List<string> Units => new List<string> { "pa", "tor" };
        private static double conversionRatio = 133;

        private double PascalToTorr(double pressure)
        {
            return pressure / conversionRatio;
        }

        private double TorrToPascal(double pressure)
        {
            return pressure * conversionRatio;
        }

        public double Convert(double inputValue, string inputUnit)
        {
            if (inputUnit == "pa") 
            {
                return PascalToTorr(inputValue);
            }
            else if (inputUnit == "tor")
            {
                return TorrToPascal(inputValue);
            }
            throw new ArgumentException("Invalid input unit " + inputUnit);
        }
    }
}
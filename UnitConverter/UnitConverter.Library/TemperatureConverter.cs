using System;
using System.Collections.Generic;

namespace UnitConverter
{
    public class TemperatureConverter : IConverter
    {
        public string Name => "Temperature";
        public List<string> Units => new List<string> { "km", "mi" };

        private double CelsiusToFahrenheit(double temperature)
        {
            return temperature * 1.8 + 32;
        }

        private double FahrenheitToCelsius(double temperature)
        {
            return (temperature - 32) / 1.8;
        }

        public double Convert(double inputValue, string inputUnit)
        {
            if (inputUnit == "C")
            {
                return CelsiusToFahrenheit(inputValue);
            }
            else if (inputUnit == "F")
            {
                return FahrenheitToCelsius(inputValue);
            }
            throw new ArgumentException("Invalid input unit " + inputUnit);
        }

    }
}
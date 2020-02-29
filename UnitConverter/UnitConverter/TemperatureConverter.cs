using System;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace UnitConverter
{
    public class TemperatureConverter
    {
        public double CelsiusToFahrenheit(double temperature)
        {
            return temperature * 1.8 + 32;
        }

        public double FahrenheitToCelsius(double temperature)
        {
            return (temperature - 32) / 1.8;
        }
    }
}
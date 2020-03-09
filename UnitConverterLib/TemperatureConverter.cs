using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace unit_converter
{
    public class TemperatureConverter : IConverter
    {
        public string Name => "Temperature";

        public List<string> AvailableUnits => new List<string>()
        {
            "Celsius",
            "Fahrenheit",
            "Kelvin",
        };

        public bool IsInputValid(string inputValue)
        {
            if (!double.TryParse(inputValue, out double tempValue))
            {
                return false;
            }
            else return true;
        }

        public double ToBaseUnit(string sourceUnit, double value)
        {
            if (sourceUnit == "Fahrenheit")
            {
                return (value - 32.0) / 1.80;
            }
            else if (sourceUnit == "Kelvin")
            {
                return value - 273.15;
            }
            else return value;
        }

        public double Convert(string sourceUnit, string targetUnit, double value)
        {
            double inCelsius = ToBaseUnit(sourceUnit, value);
            if (targetUnit == "Fahrenheit")
            {
                return (inCelsius * 1.80) + 32.0;
            }
            else if (targetUnit == "Kelvin")
            {
                return inCelsius + 273.15;
            }
            else return inCelsius;
        }
    }
}

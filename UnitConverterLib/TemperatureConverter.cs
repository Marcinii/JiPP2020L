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

        public bool IsInputValid(string inputValue, string sourceUnit)
        {
            if (!double.TryParse(inputValue, out double tempValue))
            {
                return false;
            }
            else return true;
        }

        public string ToBaseUnit(string sourceUnit, string strValue)
        {
            double value = double.Parse(strValue);
            if (sourceUnit == "Fahrenheit")
            {
                return ((value - 32.0) / 1.80).ToString();
            }
            else if (sourceUnit == "Kelvin")
            {
                return (value - 273.15).ToString();
            }
            else return value.ToString();
        }

        public string Convert(string sourceUnit, string targetUnit, string strValue)
        {
            double inCelsius = double.Parse(ToBaseUnit(sourceUnit, strValue));
            if (targetUnit == "Fahrenheit")
            {
                return ((inCelsius * 1.80) + 32.0).ToString();
            }
            else if (targetUnit == "Kelvin")
            {
                return (inCelsius + 273.15).ToString();
            }
            else return inCelsius.ToString();
        }
    }
}

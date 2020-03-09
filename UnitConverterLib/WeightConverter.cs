using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace unit_converter
{
    public class WeightConverter : IConverter
    {
        public string Name => "Weight";

        public List<string> AvailableUnits => new List<string>()
        {
            "Grams",
            "Kilograms",
            "Pounds",
        };

        public double Convert(string sourceUnit, string targetUnit, double value)
        {
            double inGrams = ToBaseUnit(sourceUnit, value);
            if (targetUnit == "Kilograms")
            {
                return inGrams / 1000.0;
            }
            else if (targetUnit == "Pounds")
            {
                return inGrams / 453.59237;
            }
            else return inGrams;
        }

        public bool IsInputValid(string inputValue)
        {
            if (!double.TryParse(inputValue, out double tempValue))
            {
                return false;
            }
            else
            {
                if (tempValue < 0)
                {
                    return false;
                }
                else return true;
            }
        }

        public double ToBaseUnit(string sourceUnit, double value)
        {
            if (sourceUnit == "Kilograms")
            {
                return value * 1000.0;
            }
            else if (sourceUnit == "Pounds")
            {
                return value * 453.59237;
            }
            else return value;
        }
    }
}

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

        public string Convert(string sourceUnit, string targetUnit, string strValue)
        {
            double inGrams = double.Parse(ToBaseUnit(sourceUnit, strValue));
            if (targetUnit == "Kilograms")
            {
                return (inGrams / 1000.0).ToString();
            }
            else if (targetUnit == "Pounds")
            {
                return (inGrams / 453.59237).ToString();
            }
            else return inGrams.ToString();
        }

        public bool IsInputValid(string inputValue, string sourceUnit)
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

        public string ToBaseUnit(string sourceUnit, string strValue)
        {
            double value = double.Parse(strValue);
            if (sourceUnit == "Kilograms")
            {
                return (value * 1000.0).ToString();
            }
            else if (sourceUnit == "Pounds")
            {
                return (value * 453.59237).ToString();
            }
            else return value.ToString();
        }
    }
}

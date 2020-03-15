using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace unit_converter
{
    public class DistanceConverter : IConverter
    {
        public string Name => "Length";

        public List<string> AvailableUnits => new List<string>()
        {
            "Meters",
            "Kilometers",
            "Miles",
        };

        public string Convert(string sourceUnit, string targetUnit, string strValue)
        {
            double inMeters = double.Parse(ToBaseUnit(sourceUnit, strValue));
            if (targetUnit == "Kilometers")
            {
                return (inMeters / 1000.0).ToString();
            }
            else if (targetUnit == "Miles")
            {
                return (inMeters / 1609.344).ToString();
            }
            else return inMeters.ToString();
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
            if (sourceUnit == "Kilometers")
            {
                return (value * 1000.0).ToString();
            }
            else if (sourceUnit == "Miles")
            {
                return (value * 1609.344).ToString();
            }
            else return value.ToString();
        }
    }
}

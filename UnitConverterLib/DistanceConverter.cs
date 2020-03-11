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

        public double Convert(string sourceUnit, string targetUnit, double value)
        {
            double inMeters = ToBaseUnit(sourceUnit, value);
            if (targetUnit == "Kilometers")
            {
                return inMeters / 1000.0;
            }
            else if (targetUnit == "Miles")
            {
                return inMeters / 1609.344;
            }
            else return inMeters;
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
            if (sourceUnit == "Kilometers")
            {
                return value * 1000.0;
            }
            else if (sourceUnit == "Miles")
            {
                return value * 1609.344;
            }
            else return value;
        }
    }
}

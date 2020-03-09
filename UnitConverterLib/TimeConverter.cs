using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace unit_converter
{
    public class TimeConverter : IConverter
    {
        public string Name => "Time";

        public List<string> AvailableUnits => new List<string>()
        {
            "Minutes",
            "Seconds",
            "Hours",
        };

        public double Convert(string sourceUnit, string targetUnit, double value)
        {
            double inMinutes = ToBaseUnit(sourceUnit, value);
            if (targetUnit == "Seconds")
            {
                return inMinutes * 60.0;
            }
            else if (targetUnit == "Hours")
            {
                return inMinutes / 60.0;
            }
            else return inMinutes;
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
            if (sourceUnit == "Seconds")
            {
                return value / 60.0;
            }
            else if (sourceUnit == "Hours")
            {
                return value * 60.0;
            }
            else return value;
        }
    }
}

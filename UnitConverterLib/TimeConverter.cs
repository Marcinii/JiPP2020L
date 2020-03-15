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

        public string Convert(string sourceUnit, string targetUnit, string strValue)
        {
            double inMinutes = double.Parse(ToBaseUnit(sourceUnit, strValue));
            if (targetUnit == "Seconds")
            {
                return (inMinutes * 60.0).ToString();
            }
            else if (targetUnit == "Hours")
            {
                return (inMinutes / 60.0).ToString();
            }
            else return inMinutes.ToString();
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
            if (sourceUnit == "Seconds")
            {
                return (value / 60.0).ToString();
            }
            else if (sourceUnit == "Hours")
            {
                return (value * 60.0).ToString();
            }
            else return value.ToString();
        }
    }
}

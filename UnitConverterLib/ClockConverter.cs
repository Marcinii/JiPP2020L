using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace unit_converter
{
    public class ClockConverter : IConverter
    {
        public string Name => "Clock";

        public List<string> AvailableUnits => new List<string>()
        {
            "24-hour",
            "12-hour",
        };

        public string Convert(string sourceUnit, string targetUnit, string strValue)
        {
            DateTime time = DateTime.Parse(strValue);
            if (targetUnit == "12-hour")
            {
                return time.ToString("h:mm tt");
            }
            else
            {
                return time.ToString("H:mm");
            }
        }

        public bool IsInputValid(string inputValue, string sourceUnit)
        {
            if (!DateTime.TryParse(inputValue, out DateTime tempValue))
            {
                return false;
            }
            else
            {
                if (sourceUnit == "12-hour" &&
                    !DateTime.TryParseExact(inputValue, "h:mm tt", new CultureInfo("pl-PL"), DateTimeStyles.None, out tempValue))
                {
                    return false;
                }
                else if (sourceUnit == "24-hour" &&
                    !DateTime.TryParseExact(inputValue, "H:mm", new CultureInfo("pl-PL"), DateTimeStyles.None, out tempValue))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public string ToBaseUnit(string sourceUnit, string strValue)
        {
            return strValue;
        }
    }
}

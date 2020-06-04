using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter
{
    public class LengthConverter : IConverter
    {
        public string Name => "Długości";

        public List<string> Units => new List<string>()
        {
            "km",
            "mi",
            "m"
        };

        public string Convert(string unitFrom, string unitTo, string valueToConvert)
        {
            if (unitFrom == "km")
            {
                if (unitTo == "mi")
                {
                    return (decimal.Parse(valueToConvert) * 0.62137m).ToString();
                }
                if (unitTo == "m")
                {
                    return (decimal.Parse(valueToConvert) * 1000).ToString();
                }
            }
            if (unitFrom == "mi")
            {
                if (unitTo == "km")
                {
                    return (decimal.Parse(valueToConvert) / 0.62137m).ToString();
                }
                if (unitTo == "m")
                {
                    return ((decimal.Parse(valueToConvert) / 0.62137m) * 1000).ToString();
                }
            }
            if (unitFrom == "m")
            {
                if (unitTo == "mi")
                {
                    return ((decimal.Parse(valueToConvert) / 1000) * 0.62137m).ToString();
                }
                if (unitTo == "km")
                {
                    return (decimal.Parse(valueToConvert) / 1000).ToString();
                }
            }
            return " ";
        }
    }
}

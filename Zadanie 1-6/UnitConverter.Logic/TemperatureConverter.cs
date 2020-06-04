using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter
{
    public class TemperatureConverter: IConverter
    {
        public string Name => "Temperatury";

        public List<string> Units => new List<string>()
        {
            "C",
            "F",
            "K"
        };

        public string Convert(string unitFrom, string unitTo, string valueToConvert)
        {
            if (unitFrom == "C")
            {
                if (unitTo == "F")
                {
                    return (decimal.Parse(valueToConvert) * 1,8m)+32.ToString();
                }
                if (unitTo == "K")
                {
                    return (decimal.Parse(valueToConvert) +273.15m).ToString();
                }
            }
            if (unitFrom == "F")
            {
                if (unitTo == "C")
                {
                    return ((decimal.Parse(valueToConvert) -32) /1.8m).ToString();
                }
                if (unitTo == "K")
                {
                    return ((decimal.Parse(valueToConvert) - 32) / 1.8m+273.15m).ToString();
                }
                if (unitFrom == "K")
                {
                    if (unitTo == "C")
                    {
                        return (decimal.Parse(valueToConvert) - 273.15m).ToString();
                    }
                    if (unitTo == "F")
                    {
                        return ((decimal.Parse(valueToConvert) - 273.15m) * 1.8m + 32).ToString();
                    }
                }
            }
            return " ";
        }
    }
}

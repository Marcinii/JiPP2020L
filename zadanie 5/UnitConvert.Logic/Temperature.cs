using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter
{
    public class Temperature: Interface
    {
        public List<string> Units => new List<string>()
        {
            "C",
            "F",
            "K"
        };

        public string Name => "zamiana C/K/F";

        public double Convert(string unitFrom, string unitTo, double valueToConvert)
        {

            if (unitFrom == "C" && unitTo == "K")
            {
                return valueToConvert * 1.8 + 32;
            }
            else if (unitFrom == "F" && unitTo == "C")
            {
                return valueToConvert - 32 * 5 / 9;
            }
            else if (unitFrom == "C" && unitTo == "K")
            {
                return valueToConvert +273.15;
            }
            else if (unitFrom == "K" && unitTo == "C")
            {
                return valueToConvert -273.15;
            }
            else if (unitFrom == "K" && unitTo == "F")
            {
                return valueToConvert * 1.8 + 32 + 273.15;
            }
            else if (unitFrom == "F" && unitTo == "K")
            {
                return valueToConvert * 1.8 + 32 - 273.15;
            }
            return valueToConvert;
        }
    }
}

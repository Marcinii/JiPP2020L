using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter
{
    public class Length : Interface
    {
        public List<string> Units => new List<string>()
        {
            "km",
            "m",
            "mi"
        };

        public string Name => "zamiana kilometrów na mile lub na metry";

        public double Convert(string unitFrom, string unitTo, double valueToConvert)
        {
            if (unitFrom == "km" && unitTo == "m")
            {
                return valueToConvert * 1000;
            }
            else if (unitFrom == "m" && unitTo == "km")
            {
                return valueToConvert / 1000;
            }
            else if (unitFrom == "km" && unitTo == "mi")
            {
                return valueToConvert *1.6;
            }
            else if (unitFrom == "mi" && unitTo == "km")
            {
                return valueToConvert /1.6;
            }
            else if (unitFrom == "m" && unitTo == "mi")
            {
                return valueToConvert /1000*1.6;
            }
            else if (unitFrom == "mi" && unitTo == "m")
            {
                return valueToConvert * 1000 *1.6;
            }
            return valueToConvert;
        }
    }
}

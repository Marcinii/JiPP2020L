using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter
{
    public class Speed : Interface
    {
        public List<string> Units => new List<string>()
        {
            "km",
            "mi",
            "W"
        };

        public string Name => "zamiana prędkości kilometry(km)/mile(mi)/węzeł(w)";

        public double Convert(string unitFrom, string unitTo, double valueToConvert)
        {

            if (unitFrom == "km" && unitTo == "mi")
            {
                return valueToConvert *0.6;
            }
            else if (unitFrom == "mi" && unitTo == "km")
            {
                return valueToConvert / 0.6;
            }
            else if (unitFrom == "km" && unitTo == "w")
            {
                return valueToConvert *0.54;
            }
            else if (unitFrom == "w" && unitTo == "km")
            {
                return valueToConvert /0.54;
            }
            else if (unitFrom == "mi" && unitTo == "w")
            {
                return valueToConvert *0.54*0.6;
            }
            else if (unitFrom == "w" && unitTo == "mi")
            {
                return valueToConvert * 0.54 * 0.6; ;
            }
            return valueToConvert;
        }
    }
}
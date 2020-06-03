using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter
{
    public class Time : Interface
    {
        public List<string> Units => new List<string>()
        {
            "12 godzinny",
            "24 godzinny"

        };

        public string Name => "zamiana czasu";

        public double Convert(string unitFrom, string unitTo, double valueToConvert)
        {
            if (unitFrom == "12 godzinny" && unitTo == "24 godzinny")
            {
                return valueToConvert + 12;
            }
            else if (unitFrom == "24 godzinny" && unitTo == "12 godzinny")
            {
                return valueToConvert - 12;
            }
            return valueToConvert;
        }
    }
}
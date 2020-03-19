using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter
{
    public class TimeConv : IConverter
    {
        public string Name => "Czas";

        public List<string> Units => new List<string>()
        {
            "24h",
            "12h"

        };

        public decimal Convert(string unitFrom, string unitTo, decimal valueToConvert)
        {
            if(unitFrom == "24h")
            {
                return valueToConvert - 12;
            }
            if (unitFrom == "12h")
            {
                return valueToConvert + 12;
            }
            return valueToConvert;
        }
    }
}

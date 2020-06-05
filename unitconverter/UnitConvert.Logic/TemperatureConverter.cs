using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter
{
    public class TemperatureConverter: IConverter
    {
        public List<string> Units => new List<string>()
        {
            "C",
            "K",
            "F"
        };

        public string Name => "Temperatury";

        public decimal Convert(string unitFrom, string unitTo, decimal valueToConvert)
        {
            if (unitFrom == unitTo)
                return valueToConvert;
            else if (unitFrom == "C" && unitTo == "K")
                return valueToConvert + (Decimal)273.15;
            else if (unitFrom == "C" && unitTo == "F")
                return valueToConvert * (9/5) + (Decimal)32;
            else if (unitFrom == "K" && unitTo == "C")
                return valueToConvert - (Decimal)273.15;
            else if (unitFrom == "K" && unitTo == "F")
                return valueToConvert * (9/5) - (Decimal)459.67;
            else if (unitFrom == "F" && unitTo == "C")
                return (valueToConvert - (Decimal)32) / (9/5);
            else if (unitFrom == "F" && unitTo == "K")
                return (valueToConvert + (Decimal)459.67) / (9/5);
            else
                return valueToConvert * 10;
        }
    }
}

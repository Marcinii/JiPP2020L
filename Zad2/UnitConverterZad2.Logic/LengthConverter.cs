using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitConverterZad2;

namespace UnitConverterZad2
{
    public class LengthConverter: IConverter
    {
        public string Name => "Długości";

        public List<string> Units => new List<string>()
        {
            "km",
            "mi",
            "m"
        };

        public decimal Convert(string unitFrom, string unitTo, decimal valueToConvert)
        {
            if (unitFrom=="km" && unitTo=="mi") { return valueToConvert * 0.621371192m; }
            else if (unitFrom == "mi" && unitTo == "km") { return  valueToConvert * 1.609344m; }
            else if (unitFrom == "km" && unitTo == "m") { return valueToConvert * 1000m; }
            else if (unitFrom == "m" && unitTo == "km") { return valueToConvert / 1000m; }
            else if (unitFrom == "m" && unitTo == "mi") { return valueToConvert * 1000m * 0.621371192m; }
            else if (unitFrom == "mi" && unitTo == "m") { return valueToConvert * 1.609344m / 1000m; }
            else return 0; 
        }
    }
}

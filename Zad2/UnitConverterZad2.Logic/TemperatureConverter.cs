using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverterZad2
{
    public class TemperatureConverter : IConverter
    {
        public string Name => "Temperatury";

        public List<string> Units => new List<string>()
        {
            "c",
            "f",
            "k"
        };

        public decimal Convert(string unitFrom, string unitTo, decimal valueToConvert)
        {
            if (unitFrom == "c" && unitTo == "f") { return (valueToConvert * 1.8m) + 32m; }
            else if (unitFrom == "f" && unitTo == "c") { return (valueToConvert - 32m) / 1.8m; }
            else if (unitFrom == "c" && unitTo == "k") { return valueToConvert * 273.15m; }
            else if (unitFrom == "k" && unitTo == "c") { return valueToConvert - 273.15m; }
            else if (unitFrom == "k" && unitTo == "f") { return (valueToConvert- 273.15m) *1.8m + 32m; }
            else if (unitFrom == "f" && unitTo == "k") { return (valueToConvert - 32m) / 1.8m +273.15m; }
            else return 0;
        }
    }
}

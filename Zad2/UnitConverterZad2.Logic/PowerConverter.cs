using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverterZad2
{
    public class PowerConverter : IConverter
    {
        public string Name => "Mocy";

        public List<string> Units => new List<string>()
        {
            "kW",
            "KM"
        };

        public decimal Convert(string unitFrom, string unitTo, decimal valueToConvert)
        {
            if (unitFrom == "KM" && unitTo == "kW") { return valueToConvert * 0.7355m; }
            else if (unitFrom == "kW" && unitTo == "KM") { return valueToConvert * 1.3596m; }
            else return 0;
        }
    }
}

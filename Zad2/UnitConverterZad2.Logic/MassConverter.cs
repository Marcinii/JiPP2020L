using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverterZad2
{
    public class MassConverter : IConverter
    {
        public string Name => "Masy";

        public List<string> Units => new List<string>()
        {
            "kg",
            "funty"
        };

        public decimal Convert(string unitFrom, string unitTo, decimal valueToConvert)
        {
            if (unitFrom == "kg" && unitTo == "funty") { return valueToConvert * 2.20462262m; }
            else if (unitFrom == "funty" && unitTo == "kg") { return valueToConvert * 0.45359237m; }
            else return 0;
        }
    }
}

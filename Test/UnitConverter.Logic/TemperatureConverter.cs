using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter
{
    public class TemperatureConverter: IConverter
    {
        public string Name => "Temperatury";

        public List<string> Units => new List<string>()
        {
            "C",
            "F",
            "K"
        };

        public decimal Convert(string unitFrom, string unitTo, decimal valueToConvert)
        {
            return valueToConvert * 2;
        }
    }
}

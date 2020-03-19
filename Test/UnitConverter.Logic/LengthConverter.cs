using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter
{
    public class LengthConverter: IConverter
    {
        public string Name => "Długości";

        public List<string> Units => new List<string>()
        {
            "km",
            "mi"
        };

        public decimal Convert(string unitFrom, string unitTo, decimal valueToConvert)
        {
            return valueToConvert * 10;
        }
    }
}

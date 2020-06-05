using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace UnitConverter.Logic
{
    public class LengthConverter : IConverter
    {
        public string Name => "Długości";
        public List<string> Units => new List<string>()
        {
            "km",
            "mi"
        };
        public decimal Converter(string unitFrom, string unitTo, decimal valueToConvert)
        {
            if (unitFrom == unitTo) return valueToConvert;
            if (unitFrom == Units[0] && unitTo == Units[1]) return Convert.ToDecimal(Convert.ToDouble(valueToConvert) / 1.609);
            if (unitFrom == Units[1] && unitTo == Units[0]) return valueToConvert * Convert.ToDecimal(1.609);
            else return 0;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter.Logic
{
    public class WeightConverter : IConverter
    {
        public string Name => "Wagi";
        public List<string> Units => new List<string>()
        {
            "kg",
            "funty"
        };
        public decimal Converter(string unitFrom, string unitTo, decimal valueToConvert)
        {
            if (unitFrom == unitTo) return valueToConvert;
            if (unitFrom == Units[0] && unitTo == Units[1]) return valueToConvert * Convert.ToDecimal(2.4419);
            if (unitFrom == Units[1] && unitTo == Units[0]) return valueToConvert / Convert.ToDecimal(2.4419);
            else return 0;
        }
    }
}

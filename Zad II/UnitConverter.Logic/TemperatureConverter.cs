using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter.Logic
{
    public class TemperatureConverter : IConverter
    {
        public string Name => "Temperatur";
        public List<string> Units => new List<string>()
        {
            "°C",
            "°F"
        };
        public decimal Converter(string unitFrom, string unitTo, decimal valueToConvert)
        {
            if (unitFrom == unitTo) return valueToConvert;
            if (unitFrom == Units[0] && unitTo == Units[1]) return (valueToConvert * 9 / 5) + 32;
            if (unitFrom == Units[1] && unitTo == Units[0]) return (valueToConvert - 32) * 5 / 9;
            else return 0;
        }
    }
}

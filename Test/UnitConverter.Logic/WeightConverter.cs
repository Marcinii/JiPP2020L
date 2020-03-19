using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter
{
    public class WeightConverter : IConverter
    {
        public string Name => "Masy";

        public List<string> Units => new List<string>()
        {
            "kg",
            "f"
        };

        public decimal Convert(string unitFrom, string unitTo, decimal valueToConvert)
        {
            return valueToConvert * 100;
        }
    }
}

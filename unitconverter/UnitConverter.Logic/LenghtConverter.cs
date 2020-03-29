using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter
{
    public class LenghtConverter : IConverter
    {
        public string Name => "Konwerter Dystansu";

        public List<string> Units => new List<string>()
        {
            "Kilometry", //0
            "Mile"//1
        };

        public decimal Convert(int fromUnit, int toUnit, decimal value)
        {
            if (fromUnit == 0)
            {
                value = value * (decimal)0.62137;
            }
            else
            {
                value = value / (decimal)0.62137;
            }

            return value;
        }
    }
}
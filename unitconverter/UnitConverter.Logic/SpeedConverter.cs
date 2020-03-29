using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter
{
    public class SpeedConverter : IConverter
    {
        public string Name => "Konwereter Prędkości";

        public List<string> Units => new List<string>()
        {
            "KM/H",
            "MPH"
        };

        public decimal Convert(int fromUnit, int toUnit, decimal value)
        {
            if (fromUnit == 0)
            {
                value = value /(decimal) 1.61;
            }
            else
            {
                value = value *(decimal) 1.61;
            }

            return value;
        }
    }
}
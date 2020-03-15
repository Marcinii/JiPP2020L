using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterJednostek
{
    public class TemperatureConverter:IConverter
    {
        public string Name => "Konwerter temperatury";

        public List<string> Units => new List<string>()
        {
            "C",
            "F",
            "K"
        };

        public decimal Convert(string unitFrom, string unitTo, decimal value)
        {
            if (unitFrom == "C")
            {
                if (unitTo == "F")
                {
                    return (9 / 5) * value + 32; 
                }
                else
                {
                    return value + 273.15m;
                }
            }
            else if (unitFrom == "F")
            {
                if (unitTo == "C")
                {
                    return (5 / 9) * (value - 32);
                }
                else
                {
                    return ((value - 32) / 1.8m) + 273.15m;
                }
            }
            else if (unitFrom == "K")
            {
                if (unitTo == "C")
                {
                    return value - 273.15m;
                }
                else
                {
                    return ((value - 273.15m) * 1.8m) + 32;
                }
            }
            return 0;
        }
    }
}

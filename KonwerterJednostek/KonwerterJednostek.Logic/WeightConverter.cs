using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterJednostek
{
    public class WeightConverter : IConverter
    {

        public string Name => "Konwerter masy";

        public List<string> Units => new List<string>()
        {
            "kg",
            "lb",
            "T"
        };

        
        public decimal Convert(string unitFrom, string unitTo, decimal value) {
            if (unitFrom == "kg") {
                if (unitTo == "lb")
                {
                    return value * 2.2046m; 
                } else
                {
                    return value / 1000;
                }
            } else if (unitFrom == "lb")
            {
                if(unitTo == "kg")
                {
                    return value / 2.2046m;
                } else
                {
                    return value / 2204.6m;
                }
            } else if (unitFrom == "T")
            { if(unitTo == "kg")
                {
                    return value * 1000;
                } else
                {
                    return value * 1000 * 2.2046m;
                }
            }
            return 0;
        }
    }
}

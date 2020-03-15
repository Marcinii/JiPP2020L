using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterJednostek
{
    public class LenghtConverter:IConverter
    {
        public string Name => "Konwerter długości";

        public List<string> Units => new List<string>()
        {
            "km",
            "mi",
            "in"
        };


        public decimal Convert(string unitFrom, string unitTo, decimal value)
        {
            if (unitFrom == "km")
            {
                if (unitTo == "mi")
                {
                    return value * 0.62137m;
                }
                else
                {
                    return value * 39370.098m;
                }
            }
            else if (unitFrom == "mi")
            {
                if (unitTo == "km")
                {
                    return value / 0.62137m;
                }
                else
                {
                    return value / 0.0000157828m;
                }
            }
            else if (unitFrom == "in")
            {
                if (unitTo == "km")
                {
                    return value / 39370.098m;
                }
                else
                {
                    return value * 0.0000157828m;
                }
            }
            return 0;
        }
    }
}

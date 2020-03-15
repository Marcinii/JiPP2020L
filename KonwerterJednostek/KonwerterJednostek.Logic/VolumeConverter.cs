using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterJednostek
{
    public class VolumeConverter : IConverter
    {
        public string Name => "Konwerter objętości";

        public List<string> Units => new List<string>()
        {
            "l",
            "lyzka",
            "gal"
        };

        public decimal Convert(string unitFrom, string unitTo, decimal value)
        {
            if (unitFrom == "l")
            {
                if (unitTo == "lyzka")
                {
                    return value / 0.015m;
                }
                else
                {
                    return value * 0.21997m;
                }
            }
            else if (unitFrom == "lyzka")
            {
                if (unitTo == "l")
                {
                    return value * 0.015m;
                }
                else
                {
                    return value * 15 / 219.97m;
                }
            }
            else if (unitFrom == "gal")
            {
                if (unitTo == "l")
                {
                    return value / 0.21997m;
                }
                else
                {
                    return (value / 0.21997m) / 0.015m;
                }
            }
            return 0;
        }
    }
}

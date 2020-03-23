using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter.Logic
{
    public class Pressure : IConverter
    {
        public string Name => "Ciśnienie";

        public List<string> Units => new List<string>()
        {
            "Pa",
            "hPa"
        };

        public double Convert(string unitFrom, string unitTo, double value)
        {
            if (unitFrom == this.Units[0])
            {
                if (unitTo == this.Units[0])
                {
                    return value;
                }
                else if (unitTo == this.Units[1])
                {
                    return value / 100;
                }
                else { return value; }
            }
            else if (unitFrom == this.Units[1])
            {
                if (unitTo == this.Units[0])
                {
                    return value * 100;
                }
                else if (unitTo == this.Units[1])
                {
                    return value;
                }
                else { return value; }
            }
            else { return value; }
        }
    }
}

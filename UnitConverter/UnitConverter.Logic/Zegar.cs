using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter.Logic
{
    class Zegar : IConverter
    {
        public string Name => "Zegar";

        public List<string> Units => new List<string>() { "24h", "12h" };

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
                    if (value > 12 && value < 25) { return value - 12; }
                    else { return value; }
                }
                else { return value; }
            }
            else if (unitFrom == this.Units[1])
            {
                return value;
            }
            else { return value; }
        }
    }
}

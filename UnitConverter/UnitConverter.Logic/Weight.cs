using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter.Logic
{
    public class Weight : IConverter
    {
        public string Name => "Waga";

        public List<string> Units => new List<string>()
        {
            "kg",
            "lb"
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
                    return value * 2.2046;
                }
                else { return value; }
            }
            else if (unitFrom == this.Units[1])
            {
                if (unitTo == this.Units[0])
                {
                    return value / 2.2046;
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter.Logic
{
    public class TemperatureConverter : IConverter
    {
        public string Name => "Temperatura";

        public List<string> Units => new List<string>()
        {
            "F",
            "C"
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
                    return value * 1.8 + 32;
                }
                else { return value; }
            }
            else if (unitFrom == this.Units[1])
            {
                if (unitTo == this.Units[0])
                {
                    return (value - 32) / 1.8;
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

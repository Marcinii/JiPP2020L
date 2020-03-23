using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter.Logic
{
    public class LengthConverter : IConverter
    {
        public string Name => "Długość"; //właściwości, które zwracam

        public List<string> Units => new List<string>() { "Km", "Mi", "Dec" };

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
                    return value * 0.62137;
                }
                else if (unitTo == this.Units[2])
                {
                    return value / 10000;
                }
            }
            else if (unitFrom == this.Units[1])
            {
                if (unitTo == this.Units[0])
                {
                    return value / 0.62137;
                }
                else if (unitTo == this.Units[1])
                {
                    return value;
                }
                else if (unitTo == this.Units[2])
                {
                    return value / 0.62137 / 10000;
                }
            }
            else if (unitFrom == this.Units[2])
            {
                if (unitTo == this.Units[0])
                {
                    return value * 10000;
                }
                else if (unitTo == this.Units[1])
                {
                    return value * 0.62137 * 10000;
                }
                else if (unitTo == this.Units[2])
                {
                    return value;
                }
                else { return value; }
            }
            return value;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class TempConverter : IConverter
    {
        public string Name { get => "Temperatura"; }


        public List<string> Units { get => new List<string> { "°C", "°F" }; }

        public double Convert(string unitFrom, string unitTo, double value)
        {
            if (unitFrom == Units[0] && unitTo == Units[1])
                return (value * 1.8d) + 32;
            else if (unitFrom == Units[1] && unitTo == Units[0])
                return (value - 32) / 1.8d;

            return value;
        }

    }
}

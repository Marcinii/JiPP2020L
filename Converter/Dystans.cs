using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converter
{
    class Dystans
    {
        public Dystans() { }
        public double convert(double a, string from, string to)
        {
            double b = a;

            if (from == "km" && to == "miles")
            {
                b = a * 0.621371192;
            }
            else if (from == "miles" && to == "km")
            {
                b = a * 1 / 0.621371192;
            }

            return b;
        }
    }
}
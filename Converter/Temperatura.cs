using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converter
{
    class Temperatura
    {
        public Temperatura() { }
        public double convert(double a, string from, string to)
        {
            double b=a;

            if(from == "C" && to == "F")
                {
                b = a * 9 / 5 + 32;
            }
                else if (from == "F" && to == "C")
            {
                b = (a - 32) * 5 / 9;
            }

            return b;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converter
{
    class Masa
    {
        public Masa() { }
        public double convert(double a, string from, string to)
        {
            double b = a;

            if (from == "kg" && to == "lbs")
            {
                b = a * 2.20462262;
            }
            else if (from == "lbs" && to == "kg")
            {
                b = a * 1 / 2.20462262;
            }

            return b;
        }
    }
}
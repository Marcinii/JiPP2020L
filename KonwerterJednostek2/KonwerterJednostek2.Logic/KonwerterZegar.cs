﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterJednostek2
{
    public class KonwerterZegar : iKonwerter
    {
        public string Name => "KonwerterZegar";

        public List<string> Units => new List<string>()
        {
            "24h", "12h"
        };

        public double convert(double a, string from, string to)
        {
            double b=a;

            if (a > 11)
            {
                b = a - 12;
            }

            return b;
        }

        public override string ToString() { return Name; }
    }
}

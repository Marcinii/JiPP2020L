﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter
{
    class Program
    {
     
        static void Main(string[] args)
        {
            Converter conv = new Converter();
            while (true)
            {
                conv.convert();
            }

        }
    }
}

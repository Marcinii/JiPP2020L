﻿using System;
using System.Collections.Generic;
using System.Text;

namespace UnitConverter
{
    interface IConverter
    {
        string Name { get; }
        List<string> Units { get; }

        double Convert(double inputValue, string inputUnit);
    }
}

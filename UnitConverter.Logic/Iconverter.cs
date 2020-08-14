using System;
using System.Collections.Generic;
using System.Text;

namespace UnitConverter.Logic
{
    public interface Iconverter
    {
        string name { get; }
        string unitFrom { get; }
        string unitTo { get; }
        double Convert(double ValueToConvert);
    }
}

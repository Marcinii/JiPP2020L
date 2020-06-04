using System;
using System.Collections.Generic;
using System.Text;

namespace Konwerter_console
{
    public interface Iconverter
    {
        string name { get; }
        string unitFrom { get; }
        string unitTo { get; }
        double Convert(double ValueToConvert);
    }
}

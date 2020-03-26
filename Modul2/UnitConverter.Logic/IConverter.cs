using System;
using System.Collections.Generic;
using System.Text;

namespace Modul2
{
    public interface IConverter
    {
        string Name { get; }
        List<string> Units { get; }
        double Convert(string unitFrom, string unitTo, double valueToConvert);
    }
}

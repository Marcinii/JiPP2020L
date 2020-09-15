using System;
using System.Collections.Generic;
using System.Text;

namespace KonwerterJednostek
{
    public interface IConverter
    {
        string Name { get; }
        List<string> Units { get; }
        decimal Convert(string unitFrom, string unitTo, decimal value);
    }
}

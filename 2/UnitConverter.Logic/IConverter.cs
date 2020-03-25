using System;
using System.Collections.Generic;

namespace UnitConverter
{
    public interface IConverter
    {
        string Name { get; }
        List<string> Units { get; }

        decimal Convert(string from, string to, decimal value);
    }
}

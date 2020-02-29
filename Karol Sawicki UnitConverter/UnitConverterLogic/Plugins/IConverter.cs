using System;
using System.Collections.Generic;
using System.Text;

namespace UnitConverterLogic.Plugins
{
    public interface IConverter
    {
        string Name { get; }
        List<string> Units { get; }
        int Converter(string unitFrom, string unitTo, string value);
    }
}

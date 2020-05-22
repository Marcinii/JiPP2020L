using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter.Logic
{
    public interface IConverter
    {
        string Name { get; }
        List<string> Units { get; }
        decimal Converter(string unitFrom, string unitTo, decimal valueToConvert);
    }
}

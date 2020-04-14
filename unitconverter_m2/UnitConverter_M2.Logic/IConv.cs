using System;
using System.Collections.Generic;
using System.Text;

namespace UnitConverter_M2
{
    public interface IConv
    {
        List<string> units { get; }
        string operationName { get; }
        string convert(string from, string to, decimal valueToConvert);
        string ToString();
    }
}

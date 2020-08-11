using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad1Poprawka
{

    public interface IConverter
    {
        string name { get; }
        List<string> Units { get; }
        decimal Convert(string convertFrom, string convertTo, decimal valueToConvert);
    }
}


using System;
using System.Collections.Generic;
using System.Text;

namespace UnitCorventer
{
    public interface IConverter
    {

        string Name { get; }
        List<string> Units { get; }
        void List_unit();
        decimal Convert();
        void Data_and_convert(string unitFrom, string unitTo, decimal valueToConwert);
    }
}

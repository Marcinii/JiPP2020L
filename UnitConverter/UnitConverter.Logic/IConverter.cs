using System;
using System.Collections.Generic;

namespace UnitConverter.Logic
{
    public interface IConverter
    {
        string Name { get; }
        List<String> Units { get; }
        Tuple<double, string> Convert(double input_value, string input_unit, string output_unit);
    }

}

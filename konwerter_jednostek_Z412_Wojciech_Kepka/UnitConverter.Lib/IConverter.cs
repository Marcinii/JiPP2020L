using System;
using System.Collections.Generic;
using static UnitConverter.Lib.Units;

namespace UnitConverter.Lib
{
    public interface IConverter
    {
        string Name { get; }
        List<Unit> SupportedUnits { get; }
        Tuple<double, Unit> Convert(double val, Unit inpUnit, Unit outUnit);
    }

}

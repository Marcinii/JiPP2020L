using System;
using static UnitConverter.Lib.Units;

namespace UnitConverter.Lib
{
    public interface IConverter
    {
        string name();
        Tuple<double, Unit> convert(double val, Unit inpUnit, Unit outUnit);
    }

}

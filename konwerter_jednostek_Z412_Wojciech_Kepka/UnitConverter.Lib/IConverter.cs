using System;
using System.Collections.Generic;
using static UnitConverter.Lib.Units;

namespace UnitConverter.Lib
{
    public interface IConverter<T, U>
    {
        string Name { get; }
        List<U> SupportedUnits { get; }
        Tuple<T, U> Convert(T val, U inpUnit, U outUnit);
    }

}

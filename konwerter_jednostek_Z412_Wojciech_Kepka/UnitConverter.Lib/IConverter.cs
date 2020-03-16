using System;

namespace UnitConverter.Lib
{
    public interface IConverter
    {
        double convert(double value, string fromUnit, string toUnit);
    }

}

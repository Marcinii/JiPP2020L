using static UnitConverter.Lib.Units;
using static UnitConverter.Lib.Formulas;

namespace UnitConverter.Lib
{
    public class SpeedConverter : IConverter
    {
        public double convert(double value, string fromUnit, string toUnit)
        {
            Unit inputUnit = UnitFromString(fromUnit);
            Unit outputUnit = UnitFromString(toUnit);

            switch (inputUnit)
            {
                case Unit.KilometersPerHour:
                    if (outputUnit == Unit.MilesPerHour)
                    {
                        return KphToMph(value);
                    }
                    else if (outputUnit == Unit.Knots)
                    {
                        return KphToKnots(value);
                    }
                    else if (outputUnit == Unit.MetersPerSecond)
                    {
                        return KphToMps(value);
                    }
                    break;
                case Unit.MilesPerHour:
                    if (outputUnit == Unit.KilometersPerHour)
                    {
                        return MphToKph(value);
                    }
                    else if (outputUnit == Unit.Knots)
                    {
                        return MphToKnots(value);
                    }
                    else if (outputUnit == Unit.MetersPerSecond)
                    {
                        return MphToMps(value);
                    }
                    break;
                case Unit.Knots:
                    if (outputUnit == Unit.MilesPerHour)
                    {
                        return KnotsToMph(value);
                    }
                    else if (outputUnit == Unit.KilometersPerHour)
                    {
                        return KnotsToKph(value);
                    }
                    else if (outputUnit == Unit.MetersPerSecond)
                    {
                        return KnotsToMps(value);
                    }
                    break;
                default:
                    throw new UnsupportedUnit(inputUnit);
            }

            throw new IncompatibleConversionUnits(inputUnit, outputUnit);
        }
    }
}

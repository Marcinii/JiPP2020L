using static UnitConverter.Lib.Units;
using static UnitConverter.Lib.Formulas;

namespace UnitConverter.Lib
{
    public class DistanceConverter : IConverter
    {
        public double convert(double value, string fromUnit, string toUnit)
        {
            Unit inputUnit = UnitFromString(fromUnit);
            Unit outputUnit = UnitFromString(toUnit);

            switch (inputUnit)
            {
                case Unit.Kilometers:
                    if (outputUnit == Unit.Miles)
                    {
                        return KilometersToMiles(value);
                    }
                    break;
                case Unit.Miles:
                    if (outputUnit == Unit.Kilometers)
                    {
                        return MilesToKilometers(value);
                    }
                    break;
                default:
                    throw new UnsupportedUnit(inputUnit);
            }

            throw new IncompatibleConversionUnits(inputUnit, outputUnit);
        }
    }
}

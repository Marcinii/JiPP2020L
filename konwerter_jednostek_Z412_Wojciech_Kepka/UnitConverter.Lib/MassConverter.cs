using static UnitConverter.Lib.Units;
using static UnitConverter.Lib.Formulas;

namespace UnitConverter.Lib
{
    public class MassConverter : IConverter
    {
        public double convert(double value, string fromUnit, string toUnit)
        {
            Unit inputUnit = UnitFromString(fromUnit);
            Unit outputUnit = UnitFromString(toUnit);
            switch (inputUnit)
            {
                case Unit.Kilograms:
                    if (outputUnit == Unit.Pounds)
                    {
                        return KilogramsToPounds(value);
                    }
                    else if (outputUnit == Unit.Ounces)
                    {
                        return KilogramsToOunces(value);
                    }
                    break;
                case Unit.Pounds:
                    if (outputUnit == Unit.Kilograms)
                    {
                        return PoundsToKilograms(value);
                    }
                    else if (outputUnit == Unit.Ounces)
                    {
                        return PoundsToOunces(value);
                    }
                    break;
                case Unit.Ounces:
                    if (outputUnit == Unit.Kilograms)
                    {
                        return OuncesToKilograms(value);
                    }
                    else if (outputUnit == Unit.Pounds)
                    {
                        return OuncesToPounds(value);
                    }
                    break;
                default:
                    throw new UnsupportedUnit(inputUnit);
            }

            throw new IncompatibleConversionUnits(inputUnit, outputUnit);
        }
    }
}

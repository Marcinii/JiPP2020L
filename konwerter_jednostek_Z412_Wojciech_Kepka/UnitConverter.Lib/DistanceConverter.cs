using System;
using static UnitConverter.Lib.Units;
using static UnitConverter.Lib.Formulas;

namespace UnitConverter.Lib
{
    public class DistanceConverter : IConverter
    {
        public string name()
        {
            return "Distance Converter";
        }
        public Tuple<double, Unit> convert(double val, Unit inpUnit, Unit outUnit)
        {
            double outVal = 0;
            bool calculated = false;

            switch (inpUnit)
            {
                case Unit.Kilometers:
                    if (outUnit == Unit.Miles)
                    {
                        outVal = KilometersToMiles(val);
                        calculated = true;
                    }
                    break;
                case Unit.Miles:
                    if (outUnit == Unit.Kilometers)
                    {
                        outVal = MilesToKilometers(val);
                        calculated = true;
                    }
                    break;
                default:
                    throw new UnsupportedUnit(inpUnit);
            }

            if (calculated)
            {
                return new Tuple<double, Unit>(outVal, outUnit);
            }
            else
            {
                throw new IncompatibleConversionUnits(inpUnit, outUnit);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using static UnitConverter.Lib.Units;
using static UnitConverter.Lib.Formulas;

namespace UnitConverter.Lib
{
    public class DistanceConverter : IConverter
    {
        public string Name => "Distance Converter";
        public List<Unit> SupportedUnits => new List<Unit>() {
            Unit.Kilometers,
            Unit.Miles,
        };
        public Tuple<double, Unit> Convert(double val, Unit inpUnit, Unit outUnit)
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

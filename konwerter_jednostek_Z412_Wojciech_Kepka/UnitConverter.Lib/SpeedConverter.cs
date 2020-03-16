using System;
using System.Collections.Generic;
using static UnitConverter.Lib.Units;
using static UnitConverter.Lib.Formulas;

namespace UnitConverter.Lib
{
    public class SpeedConverter : IConverter
    {
        public string Name => "Speed Converter";
        public List<Unit> SupportedUnits => new List<Unit>() {
            Unit.KilometersPerHour,
            Unit.MetersPerSecond,
            Unit.MilesPerHour,
            Unit.Knots
        };
        public Tuple<double, Unit> Convert(double val, Unit inpUnit, Unit outUnit)
        {
            double outVal = 0;
            bool calculated = false;

            switch (inpUnit)
            {
                case Unit.KilometersPerHour:
                    if (outUnit == Unit.MilesPerHour)
                    {
                        outVal =  KphToMph(val);
                        calculated = true;
                    }
                    else if (outUnit == Unit.Knots)
                    {
                        outVal = KphToKnots(val);
                        calculated = true;
                    }
                    else if (outUnit == Unit.MetersPerSecond)
                    {
                        outVal = KphToMps(val);
                        calculated = true;
                    }
                    break;
                case Unit.MilesPerHour:
                    if (outUnit == Unit.KilometersPerHour)
                    {
                        outVal = MphToKph(val);
                        calculated = true;
                    }
                    else if (outUnit == Unit.Knots)
                    {
                        outVal = MphToKnots(val);
                        calculated = true;
                    }
                    else if (outUnit == Unit.MetersPerSecond)
                    {
                        outVal = MphToMps(val);
                        calculated = true;
                    }
                    break;
                case Unit.Knots:
                    if (outUnit == Unit.MilesPerHour)
                    {
                        outVal = KnotsToMph(val);
                        calculated = true;
                    }
                    else if (outUnit == Unit.KilometersPerHour)
                    {
                        outVal = KnotsToKph(val);
                        calculated = true;
                    }
                    else if (outUnit == Unit.MetersPerSecond)
                    {
                        outVal = KnotsToMps(val);
                        calculated = true;
                    }
                    break;
                case Unit.MetersPerSecond:
                    if (outUnit == Unit.MilesPerHour)
                    {
                        outVal = MpsToMph(val);
                        calculated = true;
                    }
                    else if (outUnit == Unit.KilometersPerHour)
                    {
                        outVal = MpsToKph(val);
                        calculated = true;
                    }
                    else if (outUnit == Unit.Knots)
                    {
                        outVal = MpsToKnots(val);
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

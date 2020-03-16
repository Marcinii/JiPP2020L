using System;
using System.Collections.Generic;
using static UnitConverter.Lib.Units;
using static UnitConverter.Lib.Formulas;

namespace UnitConverter.Lib
{
    public class MassConverter : IConverter
    {
        public string Name => "Mass Converter";
        public List<Unit> SupportedUnits => new List<Unit>() {
            Unit.Kilograms,
            Unit.Pounds,
            Unit.Ounces,
        };
        public Tuple<double, Unit> Convert(double val, Unit inpUnit, Unit outUnit)
        {
            double outVal = 0;
            bool calculated = false;

            switch (inpUnit)
            {
                case Unit.Kilograms:
                    if (outUnit == Unit.Pounds)
                    {
                        outVal = KilogramsToPounds(val);
                        calculated = true;
                    }
                    else if (outUnit == Unit.Ounces)
                    {
                        outVal = KilogramsToOunces(val);
                        calculated = true;
                    }
                    break;
                case Unit.Pounds:
                    if (outUnit == Unit.Kilograms)
                    {
                        outVal = PoundsToKilograms(val);
                        calculated = true;
                    }
                    else if (outUnit == Unit.Ounces)
                    {
                        outVal = PoundsToOunces(val);
                        calculated = true;
                    }
                    break;
                case Unit.Ounces:
                    if (outUnit == Unit.Kilograms)
                    {
                        outVal = OuncesToKilograms(val);
                        calculated = true;
                    }
                    else if (outUnit == Unit.Pounds)
                    {
                        outVal = OuncesToPounds(val);
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

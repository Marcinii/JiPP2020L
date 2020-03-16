using static UnitConverter.Lib.Units;
using static UnitConverter.Lib.Formulas;

namespace UnitConverter.Lib
{
    public class TemperatureConverter : IConverter
    {
        public double convert(double value, string fromUnit, string toUnit)
        {
            Unit inputUnit = UnitFromString(fromUnit);
            Unit outputUnit = UnitFromString(toUnit);
            switch (inputUnit)
            {
                case Unit.Celsius:
                    if (outputUnit == Unit.Fahrenheit)
                    {
                        return CelsiusToFahrenheit(value);
                    } else if (outputUnit == Unit.Kelvin)
                    {
                        return CelsiusToKelvin(value);
                    }
                    break;
                case Unit.Fahrenheit:
                    if (outputUnit == Unit.Celsius)
                    {
                        return FahrenheitToCelsius(value);
                    }
                    else if (outputUnit == Unit.Kelvin)
                    {
                        return FahrenheitToKelvin(value);
                    }
                    break;
                case Unit.Kelvin:
                    if (outputUnit == Unit.Celsius)
                    {
                        return KelvinToCelsius(value);
                    }
                    else if (outputUnit == Unit.Kelvin)
                    {
                        return KelvinToFahrenheit(value);
                    }
                    break;
                default:
                throw new UnsupportedUnit(inputUnit);
            }

            throw new IncompatibleConversionUnits(inputUnit, outputUnit);
        }
    }
}

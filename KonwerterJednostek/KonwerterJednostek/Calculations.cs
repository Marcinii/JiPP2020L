using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterJednostek
{
    class Calculations
    {
        public double convertCelsiusToFahrenheit(double valueInCelsius)
        {
            return (valueInCelsius * 1.8) + 32;
        }
        public double convertFahrenheitToCelsius(double valueInFahrenheit)
        {
            return (valueInFahrenheit - 32) / 1.8;
        }
        public double convertKilometersToMiles(double valueInKilometers)
        {
            return (valueInKilometers / 8) * 5;
        }
        public double convertMilesToKilometers(double valueInMiles)
        {
            return (valueInMiles / 5) * 8;
        }
        public double convertKilogramsToPounds(double valueInKilograms)
        {
            return valueInKilograms * 2.2046;
        }
        public double convertPoundsToKilograms(double valueInPounds)
        {
            return valueInPounds / 2.2046;
        }
    }
}

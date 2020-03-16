using System;
using System.Collections.Generic;
using System.Text;

namespace UnitConverter.Lib
{
    public class Formulas
    {
        // Temperatures
        public static double CelsiusToFahrenheit(double inp) { return inp * (9 / 5) + 32; }
        public static double CelsiusToKelvin(double inp) { return inp + 273.15; }
        public static double FahrenheitToCelsius(double inp) { return (inp - 32) * 5 / 9; }
        public static double FahrenheitToKelvin(double inp) { return (inp + 459.67) * 5 / 9; }
        public static double KelvinToCelsius(double inp) { return inp - 273.15; }
        public static double KelvinToFahrenheit(double inp) { return (inp * 9 / 5) - 459.67; }
        // Mass
        public static double KilogramsToPounds(double inp) { return inp * 2.2046; }
        public static double KilogramsToOunces(double inp) { return inp * 35.2739619496; }
        public static double OuncesToPounds(double inp) { return inp * 0.0625; }
        public static double OuncesToKilograms(double inp) { return inp * 0.0283495231; }
        public static double PoundsToKilograms(double inp) { return inp / 2.2046; }
        public static double PoundsToOunces(double inp) { return inp / 0.0625; }
        // Distance
        public static double KilometersToMiles(double inp) { return inp * 0.621371192; }
        public static double MilesToKilometers(double inp) { return inp / 0.621371192; }
        // Speed
        public static double KphToMps(double inp) { return inp * 0.277778; } // km/h -> m(eters)/s
        public static double KphToMph(double inp) { return inp * 0.621371; } // km/h -> m(iles)/h
        public static double KphToKnots(double inp) { return inp * 0.539957; }
        public static double MphToKph(double inp) { return inp / 0.621371; }
        public static double MphToMps(double inp) { return inp * 0.447040; } // m(iles)/h -> m(eters)/s
        public static double MphToKnots(double inp) { return inp * 0.868976; }
        public static double MpsToKph(double inp) { return inp / 0.277778; }
        public static double MpsToMph(double inp) { return inp / 0.277778; } //  m(eters)/s -> m(iles)/h
        public static double MpsToKnots(double inp) { return inp * 1.94384; }
        public static double KnotsToKph(double inp) { return inp / 0.539957; }
        public static double KnotsToMph(double inp) { return inp / 0.868976; }
        public static double KnotsToMps(double inp) { return inp / 1.94384; }
    }
}

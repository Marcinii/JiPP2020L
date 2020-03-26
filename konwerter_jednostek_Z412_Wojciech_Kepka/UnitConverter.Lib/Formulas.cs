using System;
using System.Text;
using UnitConverter.Lib;

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
        // Time
        /// <summary>
        /// Converts 24-hour time to 12-hour
        /// </summary>
        /// <param name="inp">Time in format like: '23:50'</param>
        /// <returns>Converted time: '11:50 pm'</returns>
        public static string TwentyFourHToTwelveH(string inp)
        {
            var outStr = new StringBuilder("");

            try
            {
                var time = inp.Split(':');
                if (time.Length == 2)
                {
                    try
                    {
                        var hours = int.Parse(time[0]);

                        if (hours > 12)
                        {
                            return $"{hours - 12}:{time[1]} pm";
                        }
                        else
                        {
                            return $"{hours}:{time[1]} am";
                        }
                    }
                    catch (FormatException) { }
                }
            }
            catch (FormatException) { }



            
            throw new InvalidTimeFormat(inp);
        }
        /// <summary>
        /// Converts 12-hour time to 24-hour
        /// </summary>
        /// <param name="inp">Time in format like: '11:50 pm'</param>
        /// <returns>Converted time: '23:50'</returns>
        public static string TwelveHToTwentyFour(string inp)
        {
            var outStr = new StringBuilder("");
            try
            {
                var parts = inp.Split(' ');

                if (parts.Length == 2)
                {
                    try
                    {
                        var time = parts[0].Split(':');
                        if (time.Length == 2)
                        {
                            var hours = int.Parse(time[0]);

                            if (parts[1] == "am")
                            {
                                return $"{hours}:{time[1]}";
                            }
                            else if (parts[1] == "pm")
                            {
                                return $"{hours + 12}:{time[1]}";
                            }
                        }
                    }
                    catch (FormatException) { }
                }
            }
            catch (FormatException) { }

            throw new InvalidTimeFormat(inp);
        }
    }
}

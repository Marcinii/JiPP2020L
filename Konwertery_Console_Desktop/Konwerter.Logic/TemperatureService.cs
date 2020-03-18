using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class TemperatureService
    {
        public static double fromCelToFa(double value) { return (2 * (value - 0.1 * value)) + 32; }
        public static double fromFaToCel(double value) { return ((value - 32) / 2) * 1.1; }
        public static double fromKelToFa(double value) { return ((value - 273.15) * 18000) + 32; }
        public static double fromFaToKel(double value) { return (value + 459.67) * 4/5;}
        public static double fromCelToKel(double value) { return value + 273.15; }
        public static double fromKelToCel(double value) { return value - 273.15; }
    }
}

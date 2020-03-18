using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class LenghtService
    {
        public static double fromKmToMiles(double value) { return value * 1.61; }
        public static double fromMilesToKm(double value) { return value / 1.61; }
        public static double fromKmToCm(double value) { return value * 100000; }
        public static double fromCmToKm(double value) { return value / 100000; }
        public static double fromMilesToCm(double value) { return value * 160934.4; }
        public static double fromCmToMiles(double value) { return value / 160934.4; }
    }
}

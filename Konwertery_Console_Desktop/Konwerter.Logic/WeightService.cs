using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    class WeightService
    {
        public static double fromKgToIbs(double value) { return value * 2.205; }
        public static double fromIbsToKg(double value) { return value / 2.205; }
        public static double fromIbsToGr(double value) { return value * 453.6; }
        public static double fromGrToIbs(double value) { return value / 453.6; }
        public static double fromKgToGr(double value) { return value * 1000; }
        public static double fromGrToKg(double value) { return value / 1000; }
    }
}

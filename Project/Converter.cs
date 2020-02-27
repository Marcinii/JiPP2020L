using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public static class Converter
    {
        public static class Temperature
        {
            public static double CToF(double value = 0) => (value * 1.8) + 32;
            public static double FToC(double value = 0) => (value - 32) / 1.8;
        }
        public static class Length
        {
            public static double KmToMiles(double value) => value * 0.62137;
            public static double MilesToKm(double value) => value / 0.62137;
        }
        public static class Weight
        {
            public static double KgToLb(double value) => value * 2.2046;
            public static double LbToKg(double value) => value / 2.2046;

        }
    }
}

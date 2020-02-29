using System.Runtime.CompilerServices;

namespace UnitConverter
{
    public class DistanceConverter
    {
        private readonly double _conversionRatio;

        public DistanceConverter()
        {
            _conversionRatio = 0.621371;
        }

        public double KilometersToMiles(double distance)
        {
            return distance * _conversionRatio;
        }

        public double MilesToKilometers(double distance)
        {
            return distance / _conversionRatio;
        }
    }
}
namespace UnitConverter
{
    public class WeightConverter
    {
        private readonly double _conversionRatio;

        public WeightConverter()
        {
            _conversionRatio = 2.2046;
        }

        public double KilogramsToPounds(double weight)
        {
            return weight * _conversionRatio;
        }

        public double PoundsToKilograms(double weight)
        {
            return weight / _conversionRatio;
        }
    }
}
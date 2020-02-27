using UnitConverter.Core;

namespace UnitConverter.App
{
    /// <summary>
    /// Klasa dziedzicząca klasę Converter, która służy do konwersji jednostek długości.
    /// <see cref="Converter"/>
    /// </summary>
    class DistanceConverter : Converter
    {
        public DistanceConverter(double value, ConvertTo convertTo) : base(value, convertTo) {}

        protected override void setMessage()
        {
            switch (convertTo)
            {
                case ConvertTo.FIRST:  message = "# {0} metrów to {1} kilometrów"; break;
                case ConvertTo.SECOND: message = "# {0} kilometrów to {1} metrów"; break;
            }
        }

        protected override double convert()
        {
            switch (convertTo)
            {
                case ConvertTo.FIRST: return value / 1000;
                case ConvertTo.SECOND: return value * 1000;
                default: return 0;
            }
        }
    }
}

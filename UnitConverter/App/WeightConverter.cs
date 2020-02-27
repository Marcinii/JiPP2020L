using UnitConverter.Core;

namespace UnitConverter.App
{
    /// <summary>
    /// Klasa dziedzicząca klasę Converter, która służy do konwersji jednostek masy.
    /// <see cref="Converter"/>
    /// </summary>
    class WeightConverter : Converter
    {
        public WeightConverter(double value, ConvertTo convertTo) : base(value, convertTo) {}

        protected override void setMessage()
        {
            switch (convertTo)
            {
                case ConvertTo.FIRST:  message = "# {0} funt to {1} kilogramów"; break;
                case ConvertTo.SECOND: message = "# {0} kilogramów to {1} funtów"; break;
            }
        }

        protected override double convert()
        {
            switch (convertTo)
            {
                case ConvertTo.FIRST: return value * 0.45359237;
                case ConvertTo.SECOND: return value / 0.45359237;
                default: return 0;
            }
        }
    }
}

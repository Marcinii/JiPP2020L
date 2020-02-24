using UnitConverter.Core;

namespace UnitConverter.App
{
    class TemperatureConverter : Converter
    {
        public TemperatureConverter(double value, ConvertTo convertTo) : base(value, convertTo) {}

        protected override void setMessage()
        {
            switch (convertTo)
            {
                case ConvertTo.FIRST:  message = "{0} stopni Fahrenheitt'a to {1} stopni Celsjusza"; break;
                case ConvertTo.SECOND: message = "{0} stopni Celsjusza to {1} stopni Fahrenheitt'a"; break;
            }
        }

        protected override double convert()
        {
            switch(convertTo)
            {
                case ConvertTo.FIRST: return (value - 32) * 5 / 9;
                case ConvertTo.SECOND: return 9 * value / 5 + 32;
                default: return 0;
            }
        }
    }
}

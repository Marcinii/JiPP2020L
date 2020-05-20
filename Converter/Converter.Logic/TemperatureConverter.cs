using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converter.Logic
{
    public class TemperatureConverter : IConvert
    {

        readonly string ConvertedUnit;

        public TemperatureConverter(string convertedUnit)
        {
            ConvertedUnit = convertedUnit;
        }

        public string convertedTo()
        {
            return this.ConvertedUnit;
        }

        public float convertValue(float Value, ConverterType type)
        {
            switch (type)
            {
                case ConverterType.CELSIUS:
                    return Convert.ToInt32((Value - 32) / 1.8);
                case ConverterType.FARENHEIT:
                    return Convert.ToInt32((Value * 1.8) + 32);
                default:
                    return 1;
            }
        }
    }
}

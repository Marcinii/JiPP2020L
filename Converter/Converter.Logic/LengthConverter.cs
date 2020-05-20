using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converter.Logic
{
    public class LengthConverter : IConvert
    {

        readonly string ConvertedUnit;

        public LengthConverter(string convertedUnit)
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
                case ConverterType.KILOMETER:
                    return (float)(Value * 1.609344);
                case ConverterType.MILE:
                    return (float)(Value / 1.609344);
                default:
                    return -1;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converter.Logic
{
    public class LengthConverter : IConvert
    {
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

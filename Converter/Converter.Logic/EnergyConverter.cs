using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converter.Logic
{
    public class EnergyConverter : IConvert
    {

        readonly string ConvertedUnit;

        public EnergyConverter(string convertedUnit)
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
                case ConverterType.JOULE:
                    return (float) (Value * 0.238846);
                case ConverterType.CALORIES:
                    return (float) (Value / 4.1868);
                default:
                    return -1;
            }
        }
    }
}

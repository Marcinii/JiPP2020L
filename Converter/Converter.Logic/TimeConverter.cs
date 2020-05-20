using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converter.Logic
{
    public class TimeConverter : IConvert
    {


        readonly string ConvertedUnit;

        public TimeConverter(string convertedUnit)
        {
            ConvertedUnit = convertedUnit;
        }

        public string convertedTo()
        {
            return this.ConvertedUnit;
        }


        public float convertValue(float Value, ConverterType type)
        {
           if(Value >= 12)
            {
                return Value - 12;
            }
            return Value;
        }
    }
}

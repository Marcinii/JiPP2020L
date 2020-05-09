using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converter.Logic
{
    public class TimeConverter : IConvert
    {
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

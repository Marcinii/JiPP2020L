using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace unitConverterv2
{
    public class lengthCon : IConvert
    {
        public string Name => "length Converter";

        public List<string> Units => new List<string>()
        {
            "Kilometers", //0
            "Miles"//1
        };

        public decimal Convert(int fromUnit, int toUnit, decimal value)
        {
           if(fromUnit == 0)
            {
                value = value * (decimal)0.62137;
            }
           else
            {
                value = value / (decimal)0.62137;
            }

            return value;
        }
    }
}

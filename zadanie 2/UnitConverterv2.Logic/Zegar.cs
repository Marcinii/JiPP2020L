using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace unitConverterv2
{
    public class Clock : IConvert
    {
        public string Name => "Clock Converter";

        public List<string> Units => new List<string>()
        {
            "12h", //0
            "24h"//1
        };

        public decimal Convert(int fromUnit, int toUnit, decimal value)
        {

            return value % 12;
        }

        public string clockConvert(string value)
        {
            value = value.ToString().Replace(',', ':');


            return value;
        }
    }
}

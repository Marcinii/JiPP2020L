using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace unitConverterv2
{
   public class SurfaceConvert : IConvert
    {
        public string Name => "Surface Converter";

        public List<string> Units => new List<string>()
        {
            "acres",
            "square meters"
        };

        public decimal Convert(int fromUnit, int toUnit, decimal value)
        {
            if(fromUnit == 0)
            {
                value = value / (decimal)0.00010000;
            }
            else
            {
                value = value / 10000;
            }

            return value;
        }
    }
}

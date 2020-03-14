using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace unitConverterv2
{
    public class weightConverter : IConvert
    {
        public string Name => "weight Converter";

        public List<string> Units => new List<string>()
        {
            "Kilograms",//0
            "Funty"//1
        };

        public decimal Convert(int fromUnit, int toUnit, decimal value)
        {
            if(fromUnit==0)
            {
                value = value * (decimal)2.2046;
            }

            else
            {
                value = value / (decimal)2.2046;
            }
            return value;
        }
    }
}

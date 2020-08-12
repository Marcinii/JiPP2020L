using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converter
{
    public class WeightConverter : IConverter
    {
        public string name => "Masy";

        public List<string> Units => new List<string>{
            "Kg",
            "Lbs"
        };

        public decimal Convert(string convertFrom, string convertTo, decimal value)
        {
            if (convertFrom.Equals("Kg") && convertTo.Equals("Lbs"))
            {
                return value * 2.2046m; //1 kilogram = 2,20462262 funta
            }
            else if (convertFrom.Equals("Lbs") && convertTo.Equals("Kg"))
            {
                return value / 2.2046m;
            }
            return -1;
        }
    }
}

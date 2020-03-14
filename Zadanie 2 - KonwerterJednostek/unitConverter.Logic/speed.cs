using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniConverter
{
    public class speed : Iconventer
    {
        public string Name => "speedConverter";

        public List<string> Units => new List<string>()
        {
            "km/h",
            "mph",
            "m/s"
        };
        public decimal converterCalculator(int unitFrom, int unitTo, decimal value)
        {
           
            if (unitFrom == 0) // kilometry
            {
                if (unitTo == 0)
                {
                    value = value / (decimal)1.609344;
                    return value;
                }
                else
                {
                    value = value / (decimal)3.6;
                    return value;
                }
            }
            else if (unitFrom == 1) // mile
            {
                if (unitTo == 0)
                {
                    value = value * (decimal)1.609344;
                    return value;
                }
                else if (unitTo == 2)
                {
                    value = value * (decimal)1.609344 / (decimal)3.6;
                    return value;
                }
            }
            else // metry/sekunde
            {
                if (unitTo == 0)
                {
                    value = value * (decimal)3.6;
                    return value;
                }
                else if (unitTo == 1)
                {
                    value = value * (decimal)3.6 / (decimal)1.609344;
                    return value;
                }
            }
            return value;
        }
    }
}

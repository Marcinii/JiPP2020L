using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class LengthConverter: IConverter
    {
        public string Name => "Długość";

        public List<string> Units => new List<string>()
        {
            "km",
            "mi"
        };

        public decimal Convert(string unitFrom, string unitTo, decimal valueToConvert)
        {

            if (unitFrom == "km" && unitTo == "mi")
            {
                return valueToConvert * 0.62137m; ;
            }
            else if (unitFrom == "mi" && unitTo == "km")
            {
                return valueToConvert / 0.62137m;
            }
            else
            {
                Console.WriteLine("Error");
                return 0;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class WeightConverter : IConverter
    {
        public string Name => "Masa";

        public List<string> Units => new List<string>()
        {
            "kg",
            "lb",
            "g"
        };

        public decimal Convert(string unitFrom, string unitTo, decimal valueToConvert)
        {

            if (unitFrom == "kg" && unitTo == "lb")
            {
                return valueToConvert * 2.2046m;
            }
            else if (unitFrom == "lb" && unitTo == "kg")
            {
                return valueToConvert / 2.2046m;
            }
            else if (unitFrom == "g" && unitTo == "lb")
            {
                return valueToConvert * 2204.6m;
            }
            else if (unitFrom == "lb" && unitTo == "g")
            {
                return valueToConvert / 2204.6m;
            }
            else if (unitFrom == "g" && unitTo == "kg")
            {
                return valueToConvert / 1000;
            }
            else if (unitFrom == "kg" && unitTo == "g")
            {
                return valueToConvert * 1000;
            }
            else
            {
                Console.WriteLine("Error");
                return 0;
            }

        }
    }
}

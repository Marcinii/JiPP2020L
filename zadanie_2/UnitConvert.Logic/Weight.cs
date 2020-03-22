using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter
{
    public class Weight : Interface
    {
        public List<string> Units => new List<string>()
        {
            "kg",
            "g",
            "f"
        };

        public string Name => "Zamiana kilgoramy/gramy/funty";

        public double Convert(string unitFrom, string unitTo, double valueToConvert)
        {


            if (unitFrom == "kg" && unitTo == "g")
            {
                return valueToConvert * 1000;
            }
            else if (unitFrom == "g" && unitTo == "kg")
            {
                return valueToConvert / 1000;
            }
            else if (unitFrom == "kg" && unitTo == "f") 
            {
                return valueToConvert * 0.4535;
            }
            else if (unitFrom == "f" && unitTo == "kg")
            {
                return valueToConvert / 0.4535;
            }
            else if (unitFrom == "g" && unitTo == "f")
            {
                return valueToConvert / 0.4535 /1000;
            }
            else if (unitFrom == "f" && unitTo == "g")
            {
                return valueToConvert / 0.4535*1000;
            }
            return valueToConvert;


        }
    }
}

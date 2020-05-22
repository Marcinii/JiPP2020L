 using System;
using System.Collections.Generic;
using System.Text;

namespace Modul2
{

    public class TempConverter : IConverter
    {

        public string Name => "Temps";

        public List<string> Units => new List<string>()
        {
            "C",
            "F",
            "K"
        };

        public double Convert(string unitFrom, string unitTo, double valueToConvert)
        {
           
            
            
            if (unitFrom == "C" && unitTo == "F")
            {
                return 9.0 / 5.0 * valueToConvert + 32;
            }
            else if (unitFrom == "F" && unitTo == "C")
            {
                return 5.0 / 9.0 * (valueToConvert - 32);
            }
            else if(unitFrom == "C" && unitTo == "K")
            {
                return valueToConvert + 273.15;
            }
            else if(unitFrom == "K" && unitTo == "C")
            {
                return valueToConvert - 273.15;
            }
            else if(unitFrom == "F" && unitTo == "K")
            {
                return (valueToConvert + 459.67) * 5.0 / 9.0;
            }
            else if(unitFrom == "K" && unitTo == "F")
            {
                return valueToConvert * 9.0 / 5.0 - 459.67;
            }
            else
            {
                return 0;   
            }
        }
    }
}

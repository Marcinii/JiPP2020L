using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterJednostek
{
public class FahrenheitToCelcius : IKonwerter
    {
        public List<string> Units => new List<string>()
        {
            "C",
            "F"
        };

        public string Name => "Fahrenheit To Celcius";

        public double Convert(string unitFrom, string unitTo, double valueToConvert)
        {
            return (valueToConvert - 32)*1.8;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterJednostek.Logic
{
public class FahrenheitToCelcius : IKonwerter
    {
        public List<string> Units => new List<string>()
        {
            "C",
            "F"
        };

        public string Name => "Fahrenheit To Celcius";

        public double Convert(double valueToConvert)
        {
            return (valueToConvert - 32)*1.8;
        }
    }
}

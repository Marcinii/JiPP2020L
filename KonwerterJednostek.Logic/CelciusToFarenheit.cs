using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterJednostek
{
    public class CelciusToFarenheit : IKonwerter
    {
        public List<string> Units => new List<string>()
        {
            "c",
            "f"
        };

        public string Name => "Celcius To Farenheit";

        public double Convert(string unitFrom, string unitTo, double valueToConvert)
        {
            
            return (valueToConvert * 1.8) + 32;
        }
    }
}

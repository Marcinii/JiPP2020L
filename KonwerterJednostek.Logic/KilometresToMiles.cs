using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterJednostek
{
    public class KilometresToMiles : IKonwerter
    {
        public List<string> Units => new List<string>()
        {
            "km",
            "mil"
        };

        public string Name => "Kilometres To Miles";

        public double Convert(string unitFrom, string unitTo, double valueToConvert)
        {
            return valueToConvert *0.62137;
        }
    }
}

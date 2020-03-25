using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterJednostek.Logic
{
    public class KilometresToMiles : IKonwerter
    {
        public List<string> Units => new List<string>()
        {
            "km",
            "mil"
        };

        public string Name => "Kilometres To Miles";

        object IKonwerter.Convert(object valueToConvert) => Convert((double) valueToConvert);
        public double Convert(double valueToConvert)
        {
            return valueToConvert *0.62137;
        }
    }
}

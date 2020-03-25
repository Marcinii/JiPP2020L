using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterJednostek.Logic
{
    public class MilesToKilometres : IKonwerter
    {
        public List<string> Units => new List<string>()
        {
            "mil",
            "km"
        };

        public string Name => "Miles To Kilometres";

        object IKonwerter.Convert(object valueToConvert) => Convert((double) valueToConvert);
        public double Convert(double valueToConvert)
        {
            return valueToConvert / 0.62137;
        }
    }
}

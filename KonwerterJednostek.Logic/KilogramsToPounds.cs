using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterJednostek.Logic
{
    public class KilogramsToPounds : IKonwerter
    {
        public List<string> Units => new List<string>()
        {
            "kg",
            "lb"
        };


        public string Name => "Kilograms To Pounds";

        object IKonwerter.Convert(object valueToConvert) => Convert((double) valueToConvert);
        public double Convert(double valueToConvert)
        {
            return valueToConvert * 2.2046;
        }
    }
}

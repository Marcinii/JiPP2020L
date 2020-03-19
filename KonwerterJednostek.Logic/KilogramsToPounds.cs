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

        public double Convert(string unitFrom, string unitTo, double valueToConvert)
        {
            return valueToConvert / 0.45359237;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterJednostek.Logic
{
    public class PoundsToKilograms : IKonwerter
    {
        public List<string> Units => new List<string>()
        {
            "kg",
            "lb"
        };

        public string Name => "Pounds To Kilograms";

        public double Convert(string unitFrom, string unitTo, double valueToConvert)
        {
            return valueToConvert * 0.5359237;
        }
    }
}

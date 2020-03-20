using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter
{
    public class LengthConverter: IConverter
    {
        public string Name => "Długości";

        public List<string> Units => new List<string>()
        {
            "km",
            "mi"
        };

        public double Convert(string unitFrom, string unitTo, double valueToConvert)
        {
            double wynik = 0;

            if (unitFrom == "km" && unitTo == "mi")
            {
                wynik = valueToConvert * 0.62137;
            }

            else if (unitFrom == "mi" && unitTo == "km")
            {
                wynik = valueToConvert / 0.62137;
            }

            return wynik;
        }
    }
}

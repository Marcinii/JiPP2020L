using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter
{
    public class WeightConverter : IConverter
    {
        public string Name => "Waga";

        public List<string> Units => new List<string>()
        {
            "kg",
            "f",
            "t"
        };

        public double Convert(string unitFrom, string unitTo, double valueToConvert)
        {
            double wynik = 0;

            if (unitFrom == "kg" && unitTo == "f")
            {
                wynik = valueToConvert * 2.2046;
            }

            else if (unitFrom == "f" && unitTo == "kg")
            {
                wynik = valueToConvert / 2.2046;
            }

            else if (unitFrom == "kg" && unitTo == "t")
            {
                wynik = valueToConvert / 1000.0;
            }

            else if (unitFrom == "t" && unitTo == "kg")
            {
                wynik = valueToConvert * 1000.0;
            }

            else if (unitFrom == "f" && unitTo == "t")
            {
                wynik = valueToConvert / 2204.62262;
            }

            else if (unitFrom == "t" && unitTo == "f")
            {
                wynik = valueToConvert * 2204.62262;
            }

            return wynik;
        }
    }
}

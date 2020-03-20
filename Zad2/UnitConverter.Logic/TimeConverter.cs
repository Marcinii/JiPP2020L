using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter.Logic
{
    public class TimeConverter : IConverter
    {
        public string Name => "Czasy";

        public List<string> Units => new List<string>()
        {
            "godz",
            "min",
            "s"
        };

        public double Convert(string unitFrom, string unitTo, double valueToConvert)
        {
            double wynik = 0;

            if (unitFrom == "godz" && unitTo == "min")
            {
                wynik = valueToConvert * 60.0;
            }

            else if (unitFrom == "min" && unitTo == "godz")
            {
                wynik = valueToConvert / 60.0;
            }

            else if (unitFrom == "godz" && unitTo == "s")
            {
                wynik = valueToConvert * 3600.0;
            }

            else if (unitFrom == "s" && unitTo == "godz")
            {
                wynik = valueToConvert / 3600.0;
            }

            else if (unitFrom == "min" && unitTo == "s")
            {
                wynik = valueToConvert * 60.0;
            }

            else if (unitFrom == "s" && unitTo == "min")
            {
                wynik = valueToConvert / 60.0;
            }

            return wynik;
        }
    }
}

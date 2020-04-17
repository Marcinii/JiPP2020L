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

        public string Convert(string unitFrom, string unitTo, string valueToConvert)
        {
            double wynik = 0;

            if (unitFrom == "godz" && unitTo == "min")
            {
                wynik = System.Convert.ToDouble(valueToConvert) * 60.0;
            }

            else if (unitFrom == "min" && unitTo == "godz")
            {
                wynik = System.Convert.ToDouble(valueToConvert) / 60.0;
            }

            else if (unitFrom == "godz" && unitTo == "s")
            {
                wynik = System.Convert.ToDouble(valueToConvert) * 3600.0;
            }

            else if (unitFrom == "s" && unitTo == "godz")
            {
                wynik = System.Convert.ToDouble(valueToConvert) / 3600.0;
            }

            else if (unitFrom == "min" && unitTo == "s")
            {
                wynik = System.Convert.ToDouble(valueToConvert) * 60.0;
            }

            else if (unitFrom == "s" && unitTo == "min")
            {
                wynik = System.Convert.ToDouble(valueToConvert) / 60.0;
            }

            return System.Convert.ToString(wynik);
        }
    }
}

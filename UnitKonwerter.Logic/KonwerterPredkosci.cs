using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitKonwerter
{
    public class KonwerterPredkosci : IKonwerter
    {
        public string Name => "Predkosci";

        public List<string> Units => new List<string>()
            {
                "km/h",
                "m/s",
                "mph"
            };

        public decimal Convert(string unitFrom, string unitTo, decimal valueToConvert)
        {
            decimal wynik = 0;
            if (unitFrom == "km/h" && unitTo == "m/s")
            {
                wynik = decimal.Divide(valueToConvert, 3.6M);
                return wynik;
            }
            else
            {
                if (unitFrom == "km/h" && unitTo == "mph")
                {
                    wynik = decimal.Multiply(valueToConvert, 0.6214M);
                    return wynik;
                }

                if (unitFrom == "m/s" && unitTo == "km/h")
                {
                    wynik = decimal.Multiply(valueToConvert, 3.6M);
                    return wynik;
                }

                if (unitFrom == "m/s" && unitTo == "mph")
                {
                    wynik = decimal.Multiply(valueToConvert, 2.24M);
                    return wynik;
                }

                if (unitFrom == "mph" && unitTo == "km/h")
                {
                    wynik = decimal.Multiply(valueToConvert, 1.61M);
                    return wynik;
                }

                if (unitFrom == "mph" && unitTo == "m/s")
                {
                    wynik = decimal.Divide(valueToConvert, 2.24M);
                    return wynik;
                }
                return wynik;
            }

        }
    }
}



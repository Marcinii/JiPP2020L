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

        public string Convert(string unitFrom, string unitTo, string valueToConvert)
        {
            string wynik ="blad"; 
            if (unitFrom == "km/h" && unitTo == "m/s")
            {
                wynik = (double.Parse(valueToConvert) / 3.6).ToString();
                return wynik;
            }
            else
            {
                if (unitFrom == "km/h" && unitTo == "mph")
                {
                    wynik = (double.Parse(valueToConvert) / 0.6214).ToString();
                    return wynik;
                }

                if (unitFrom == "m/s" && unitTo == "km/h")
                {
                    wynik = (double.Parse(valueToConvert) * 3.6).ToString();
                    return wynik;
                }

                if (unitFrom == "m/s" && unitTo == "mph")
                {
                    wynik = (double.Parse(valueToConvert) * 2.4).ToString();
                    return wynik;
                }

                if (unitFrom == "mph" && unitTo == "km/h")
                {
                    wynik = (double.Parse(valueToConvert) * 1.6).ToString();
                    return wynik;
                }

                if (unitFrom == "mph" && unitTo == "m/s")
                {
                    wynik = (double.Parse(valueToConvert) / 2.24).ToString();
                    return wynik;
                }
                return wynik;
            }

        }
    }
}



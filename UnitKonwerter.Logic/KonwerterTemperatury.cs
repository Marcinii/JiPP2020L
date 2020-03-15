using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitKonwerter
{
    public class KonwerterTemperatury : IKonwerter
    {
        public string Name => "Temperatury";

        public List<string> Units => new List<string>()
            {
                "C",
                "F"
            };

        public decimal Convert(string unitFrom, string unitTo, decimal valueToConvert)
        {
            decimal wynik = 0;
            if (unitFrom == "C")
            {
                wynik = decimal.Multiply(valueToConvert, 1.8M);
                return wynik+32;
            }
            else
            {
                wynik = decimal.Divide(valueToConvert-32, 1.8M);
                return wynik;
            }
        }
    }
}
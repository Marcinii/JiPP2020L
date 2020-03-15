using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitKonwerter
{
    public class KonwerterMasy : IKonwerter
    {
        public string Name => "Masy";

        public List<string> Units => new List<string>()
            {
                "kg",
                "F"
            };

        public decimal Convert(string unitFrom, string unitTo, decimal valueToConvert)
        {
            decimal wynik = 0;
            if (unitFrom == "kg")
            {
                wynik = decimal.Multiply(valueToConvert, 2.2046M);
                return wynik;
            }
            else
            {
                wynik = decimal.Divide(valueToConvert, 2.2046M);
                return wynik;
            }
        }
    }
}
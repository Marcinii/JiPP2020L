using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitKonwerter
{
    public class KonwerterDlugosci : IKonwerter
    {
        public string Name => "Dlugosci";

        public List<string> Units => new List<string>()
            {
                "km",
                "m"
            };

        public decimal Convert(string unitFrom, string unitTo, decimal valueToConvert)
        {

            decimal wynik = 0;
            if (unitFrom == "km")
            {
                wynik = decimal.Multiply(valueToConvert, 1000M);
                return wynik;
            }
            else
            {
                wynik = decimal.Divide(valueToConvert, 1000M);
                return wynik;
            }
        }
    }
}
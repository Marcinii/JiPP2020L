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

        public string Convert(string unitFrom, string unitTo, string valueToConvert)
        {

            if (unitFrom == "km")
            {
                string wynik = (double.Parse(valueToConvert) * 1000).ToString();
                return wynik;
            }
            else
            {
                string wynik = (double.Parse(valueToConvert) / 1000).ToString();
                return wynik;
            }
        }
    }
}
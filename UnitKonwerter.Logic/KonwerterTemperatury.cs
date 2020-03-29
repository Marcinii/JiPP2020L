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

        public string Convert(string unitFrom, string unitTo, string valueToConvert)
        {
            
            if (unitFrom == "C")
            {
                
                string wynik = ((double.Parse(valueToConvert) * 9 / 5) + 32).ToString();
                return wynik;
            }
            else
            {
                string wynik = ((double.Parse(valueToConvert) -32)/1.8).ToString();
                return wynik;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitKonwerter
{
    public class KonwerterGodzin:IKonwerter
    {
        public string Name => "Godziny";

        public List<string> Units => new List<string>()
            {
                "24h",
                "12h"
            };

        public string Convert(string unitFrom, string unitTo, string valueToConvert)
        {
            string wynik;
            if (unitFrom == "24h")
            {
                
                wynik = DateTime.Parse(valueToConvert).ToString("hh:mm tt", CultureInfo.InvariantCulture);
                return wynik;
            }
            else
                wynik = DateTime.Parse(valueToConvert).ToString("HH:mm", CultureInfo.InvariantCulture);
                return wynik;
        }
    }
}

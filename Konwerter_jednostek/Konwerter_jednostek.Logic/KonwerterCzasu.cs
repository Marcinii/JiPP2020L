using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter_jednostek_wersja2
{
    public class KonwerterCzasu:Ikonwenter
    {
        public List<string> Units => new List<string>()
        {
            "24h",
            "12h"
        };

        public string Name => "Konwerter czasu z 24 godzinnego na 12 godzinny";
        public string Convert(string unitFrom, string unitTo, string valueToConvert)
        {
            return DateTime.Parse(valueToConvert).ToString("hh:mm tt");
        }
    }
}

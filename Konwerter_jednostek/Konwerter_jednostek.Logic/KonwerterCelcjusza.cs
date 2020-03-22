using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter_jednostek_wersja2
{
    public class KonwerterCelcjusza: Ikonwenter
    {
        public List<string> Units => new List<string>()
        {
            "Fahrenheita",
            "Celcjusza"
        };

        public string Name => "Konwerter Celcjusza na Fahrenheita";
        public string Convert(string unitFrom, string unitTo, string valueToConvert)
        {
            return ((double.Parse(valueToConvert) * 9 / 5) + 32).ToString();
        }
    }
}

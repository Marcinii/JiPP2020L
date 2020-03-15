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
            "f",
            "c"
        };

        public string Name => "Konwerter Celcjusza na Fahrenheita";
        public double Convert(string unitFrom, string unitTo, double valueToConvert)
        {
            return (valueToConvert * 9/5) + 32;
        }
    }
}

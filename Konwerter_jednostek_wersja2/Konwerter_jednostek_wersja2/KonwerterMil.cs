using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter_jednostek_wersja2
{
    public class KonwerterMil: Ikonwenter
    {
        public List<string> Units => new List<string>()
        {
            "m",
            "km"
        };

        public string Name => "Konwerter Mil na Kilometry";
        public double Convert(string unitFrom, string unitTo, double valueToConvert)
        {
            return valueToConvert * 1.61;
        }
    }
}
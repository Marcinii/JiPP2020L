using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter_jednostek_wersja2
{
   public class KonwerterKilkometrow: Ikonwenter
    {
        public List<string> Units => new List<string>()
        {
            "km",
            "m"
        };

        public string Name => "Konwerter Kilomertrów na Mile";
        public double Convert(string unitFrom, string unitTo, double valueToConvert)
        {
            return valueToConvert / 1.61;
        }
    }
}
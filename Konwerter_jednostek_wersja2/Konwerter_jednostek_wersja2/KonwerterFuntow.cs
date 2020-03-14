using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter_jednostek_wersja2
{
   public class KonwerterFuntow: Ikonwenter
    {
        public List<string> Units => new List<string>()
        {
            "f",
            "kg"
        };

        public string Name => "Konwerter Funtów na Kilogramy";
        public double Convert(string unitFrom, string unitTo, double valueToConvert)
        {
            return valueToConvert * 0.4535;
        }
    }
}
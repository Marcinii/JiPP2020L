using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter_jednostek_wersja2
{
    public class KonwerterCali: Ikonwenter
    {
        public List<string> Units => new List<string>()
        {
            "c",
            "cm"
        };

        public string Name => "Konwerter Cali na Centymetry";
        public double Convert(string unitFrom, string unitTo, double valueToConvert)
        {
            return valueToConvert * 2.54;
        }
    }
}
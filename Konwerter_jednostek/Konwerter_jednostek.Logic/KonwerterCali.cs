using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter_jednostek_wersja2
{
    public class KonwerterCali: Ikonwenter
    {
        public string Name => "Konwerter Cali na Centymerty";
        public List<string> Units => new List<string>()
        {
            "Cali",
            "Centymetrów"
        };


        public string Convert(string unitFrom, string unitTo, string valueToConvert)
        {
            return (double.Parse(valueToConvert) * 2.54).ToString();
        }
    }
}
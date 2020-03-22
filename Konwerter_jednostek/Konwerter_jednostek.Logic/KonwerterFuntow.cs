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
            "Funtów",
            "Kilogramy"
        };

        public string Name => "Konwerter Funtów na Kilogramy";
        public string Convert(string unitFrom, string unitTo, string valueToConvert)
        {
            return (double.Parse(valueToConvert) * 0.4535).ToString();
        }
    }
}
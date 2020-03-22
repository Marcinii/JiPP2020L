using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter_jednostek_wersja2
{
    public class KonwerterKilogramow: Ikonwenter
    {
        public List<string> Units => new List<string>()
        {
            "Kilogramów",
            "Funty"
        };

        public string Name => "Konwerter Kilogramów na Funty";
        public string Convert(string unitFrom, string unitTo, string valueToConvert)
        {
            return (double.Parse(valueToConvert) * 2.204).ToString();
        }
    }
}
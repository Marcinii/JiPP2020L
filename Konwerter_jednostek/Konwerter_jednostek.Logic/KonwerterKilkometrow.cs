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
            "Kilomertrów",
            "Mile"
        };

        public string Name => "Konwerter Kilomertrów na Mile";
        public string Convert(string unitFrom, string unitTo, string valueToConvert)
        {
            return (double.Parse(valueToConvert) / 1.61).ToString();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter_jednostek_wersja2
{
    public class KonwerterFahrenheita: Ikonwenter
    {
        public List<string> Units => new List<string>()
        {
            "Celcjusza",
            "Fahrenheita"
        };

        public string Name => "Konwerter Fahrenheita na Celcjusza";
        public string Convert(string unitFrom, string unitTo, string valueToConvert)
        {
            return ((double.Parse(valueToConvert) - 32) * 5 / 9).ToString();
        }
    }
}

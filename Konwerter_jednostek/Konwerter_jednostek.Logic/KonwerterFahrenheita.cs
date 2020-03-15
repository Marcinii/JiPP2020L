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
            "c",
            "f"  
        };

        public string Name => "Konwerter Fahrenheita na Celcjusza";
        public double Convert(string unitFrom, string unitTo, double valueToConvert)
        {
            return (valueToConvert - 32) * 5 / 9;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterJednostek.Logic
{
   public class Cisnienie_Pa_To_hPA : IKonwerter

    {
        public string Name => "Ciśnienie";

        public List<string> Units => new List<string>()
        {
            "Pa",
            "hpa"
        };

        public double Convert(string unitFrom, string unitTo, double valueToConvert)
        {
            return valueToConvert / 100;
        }
    }
}

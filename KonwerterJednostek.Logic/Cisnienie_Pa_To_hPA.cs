using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterJednostek.Logic
{
   public class Cisnienie_Pa_To_hPa : IKonwerter

    {
        public string Name => "Ciśnienie";

        public List<string> Units => new List<string>()
        {
            "Pa",
            "hPa"
        };

        object IKonwerter.Convert(object valueToConvert) => Convert((double) valueToConvert);
        public double Convert(double valueToConvert)
        {
            return valueToConvert / 100;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Konwerter_console
{
    public class FuToKg : Iconverter
    {
        public string name => "Funty na Kilogramy";

        public string unitFrom => "Funtow";

        public string unitTo => "Kilogramow";

        public double Convert(double valueToConvert)
        {
            return valueToConvert / 2.2046;
        }
    }
}

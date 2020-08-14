using System;
using System.Collections.Generic;
using System.Text;

namespace UnitConverter.Logic
{
    public class KgToFu : Iconverter
    {
        public string name => "Kilogramy na Funty";

        public string unitFrom => "Kilogramow";

        public string unitTo => "Funtow";

        public double Convert(double valueToConvert)
        {
            return valueToConvert * 2.2046;
        }
    }
}

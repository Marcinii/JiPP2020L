using System;
using System.Collections.Generic;
using System.Text;

namespace UnitConverter.Logic
{
    public class SecToMin :Iconverter
    {
        public string name => "Sekundy na Minuty";

        public string unitFrom => "Sekund";

        public string unitTo => "Minut";

        public double Convert(double valueToConvert)
        {
            return valueToConvert / 60;
        }
    }
}

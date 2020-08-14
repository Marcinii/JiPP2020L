using System;
using System.Collections.Generic;
using System.Text;

namespace UnitConverter.Logic
{
    public class MinToSec :Iconverter
    {
        public string name => "Minuty na Sekundy";

        public string unitFrom => "Minut";

        public string unitTo => "Sekund";

        public double Convert(double valueToConvert)
        {
            return valueToConvert * 60;
        }
    }
}

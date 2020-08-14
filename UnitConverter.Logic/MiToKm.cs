using System;
using System.Collections.Generic;
using System.Text;

namespace UnitConverter.Logic
{ 
    public class MiToKm : Iconverter
    {
        public string name => "Mile na Kilometry";

        public string unitFrom => "Mil";

        public string unitTo => "Kilometrow";

        public double Convert(double valueToConvert)
        {
            return valueToConvert / 0.62137;
        }
    }
}

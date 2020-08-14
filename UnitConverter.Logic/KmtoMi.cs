using System;
using System.Collections.Generic;
using System.Text;

namespace UnitConverter.Logic
{
    public class KmToMi : Iconverter
    {
        public string name => "Kilometry na Mile";

        public string unitFrom => "Kilometrow";

        public string unitTo => "Mil";

        public double Convert(double valueToConvert)
        {
            return valueToConvert * 0.62137;
        }
    }
}

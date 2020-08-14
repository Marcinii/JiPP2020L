using System;
using System.Collections.Generic;
using System.Text;

namespace UnitConverter.Logic
{
    public class CelToFar :Iconverter
    {
        public string name => "Celcjusze na Fahrenhaity";

        public string unitFrom => "Celcjusza";

        public string unitTo => "Fahrenheita";

        public double Convert(double valueToConvert)
        {
            return ((valueToConvert * 9) /5) + 32;
        }

    }
}

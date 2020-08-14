using System;
using System.Collections.Generic;
using System.Text;

namespace UnitConverter.Logic
{ 
    public class MeToKm :Iconverter
    {
        public string name => "Metry na Kilometry";

        public string unitFrom => "Metrow";

        public string unitTo => "Kilometrow";

        public double Convert(double valueToConvert)
        {
            return valueToConvert / 1000;
        }
    }
}

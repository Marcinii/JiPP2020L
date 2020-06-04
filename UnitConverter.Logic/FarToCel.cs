using System;
using System.Collections.Generic;
using System.Text;

namespace Konwerter_console
{
    public class FarToCel :Iconverter
    {
        public string name => "Fahrenheit na Celcjusze";
        public string unitFrom => "Fahrenheit";
        public string unitTo => "Celcjusz";
        public double Convert(double valueToConvert)
        {
            return ((valueToConvert - 32) / 9) * 5;
        }

    }
}

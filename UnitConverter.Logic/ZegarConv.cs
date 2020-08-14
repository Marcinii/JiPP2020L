using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter.Logic
{
    public class ZegarConv : Iconverter
    {
        public string name => "Konwerter Godziny";
        public string unitFrom => "24h"; 
        public string unitTo => "12h";
        public double Convert(double valueToConvert)
        {
            if (valueToConvert > 12)
            {
                return valueToConvert - 12;
            }
            else
            { 
                return valueToConvert;

            }

        }

    }
}


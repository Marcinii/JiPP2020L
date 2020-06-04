using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter.Logic
{
    class ClockConverter:IConverter
    {
        public string Name => "Zegar";

        public List<string> Units => new List<string>()
        {
            "24h",
            "12h"
        };
        public string Convert(string unitFrom, string unitTo, string valueToConvert)
        {
            if (unitFrom == "24h")
            {
                DateTime t;
                t = DateTime.Parse(valueToConvert);
                if (unitTo == "12h")
                {
                    return t.ToString("hh:mm tt");
                }
            }
            if (unitFrom == "12h")
            {
                DateTime t;
                t = DateTime.Parse(valueToConvert);
                if (unitTo == "24h")
                {
                    return t.ToString("HH:mm");
                }
            }
            return " ";
        }
    }
}

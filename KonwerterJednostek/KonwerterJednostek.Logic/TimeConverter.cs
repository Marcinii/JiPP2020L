using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterJednostek.Logic
{
    public class TimeConverter : IConverter
    {
        public string Name => "Konwerter godziny";

        public List<string> Units => new List<string>()
        {
            "24H",
            "12H"
        };

        public decimal Convert(string unitFrom, string unitTo, decimal value)
        {
            if(value == 0 || value == 24)
            {
                return 12;
            } else if (value > 12)
            {
                return value - 12;
            }
            return value;
        }

        public string Inscription(decimal value)
        {
            if (value == 12)
            {
                return "PM";
            } else if (value == 0 || value == 24)
            {
                return "AM";
            } else if (value > 12)
            {
                return "PM";
            }
            return "AM";
        }
    }
}

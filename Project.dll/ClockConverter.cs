using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class ClockConverter : IConverter
    {
        public string Name { get => "Zegar"; }

        public List<string> Units => new List<string>
        {
            "24h",
            "12h"
        };

        public string Convert(string unitFrom, string unitTo, string stringValue)
        {

            DateTime time;
            try
            {
                time = DateTime.Parse(stringValue);
            }
            catch (Exception)
            {
                return "";
            }

            if (unitFrom == "24h" && unitTo == "12h")
            {
                return time.ToString("hh:mm:ss tt");
            }
            else if (unitFrom == "12h" && unitTo == "24h")
            {
                return time.ToString("HH:mm:ss");
            }

            return "";
        }

    }
}

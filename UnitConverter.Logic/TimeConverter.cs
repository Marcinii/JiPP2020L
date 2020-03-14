using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class TimeConverter : IConverter
    {
        public string Name => "Czas";

        public List<string> Units => new List<string>()
        {
            "min",
            "s"
        };

        public decimal Convert(string unitFrom, string unitTo, decimal valueToConvert)
        {
            if (unitFrom == "min" && unitTo == "s")
            {
                return valueToConvert * 60;
            }
            else if (unitFrom == "s" && unitTo == "min")
            {
                return valueToConvert / 60;
            }
            else
            {
                Console.WriteLine("Error");
                return 0;
            }
        }
    }
}

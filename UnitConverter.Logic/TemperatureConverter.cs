using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class TemperatureConverter : IConverter
    {
        public string Name => "Temperatura";

        public List<string> Units => new List<string>()
        {
            "C",
            "F"
        };

        public decimal Convert(string unitFrom, string unitTo, decimal valueToConvert)
        {

            if (unitFrom == "c" && unitTo == "f")
            {
                return (valueToConvert * 1.8m) + 32;
            }
            else if (unitFrom == "f" && unitTo == "c")
            {
                return (valueToConvert - 32) / 1.8m;
            }
            else
            {
                Console.WriteLine("Error");
                return 0;
            }

        }
    }
}

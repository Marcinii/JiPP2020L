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

            if (unitFrom == "C" && unitTo == "F")
            {
                return (valueToConvert * 1.8m) + 32;
            }
            else if (unitFrom == "F" && unitTo == "C")
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

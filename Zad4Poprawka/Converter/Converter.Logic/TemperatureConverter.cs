using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converter
{
    public class TemperatureConverter : IConverter
    {
        public string name => "Temperatury";

        public List<string> Units => new List<string>
        {
            "C", //celcjusz
            "Fa", // farenhajt
            "K" //kelvin
        };

        public decimal Convert(string convertFrom, string convertTo, decimal value)
        {
            if (convertFrom.Equals("C") && convertTo.Equals("Fa"))
            {
                return (value + 32) * 1.8m; //°F = (°C + 32) * 1.8
            }
            else if (convertFrom.Equals("C") && convertTo.Equals("K"))
            {
                return value + 273.15m; //K = °C + 273.15
            }
            else if (convertFrom.Equals("Fa") && convertTo.Equals("C"))
            {
                return (value - 32) / 1.8m;  //°C = (°F − 32) /1.8
            }
            else if (convertFrom.Equals("Fa") && convertTo.Equals("K"))
            {
                return (value + 459.67m) * (5 / 9);  // K = (°F + 459.67) × 5 / 9
            }
            else if (convertFrom.Equals("K") && convertTo.Equals("C"))
            {
                return value - 273.15m;  //	°C = K − 273.15
            }
            else if (convertFrom.Equals("K") && convertTo.Equals("Fa"))
            {
                return (value * 1.8m) - 459.67m;   ///°F = (K × 1.8) - 459.67
            }
            else
            {
                return -1;
            }
        }
    }
}

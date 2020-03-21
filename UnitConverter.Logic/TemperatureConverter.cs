using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter
{
    public class TemperatureConverter: IConverter
    {
        public string Name => "Temperature";

        public Dictionary<string, Func<double, double>> UnitsToBasic => new Dictionary<string, Func<double, double>>
        {
            { "Celsius", value => value },
            { "Kelvin", value => value - 273.15 },
            { "Fahrenheit", value => (value - 32) / 1.8 },
        };

        public Dictionary<string, Func<double, double>> UnitsFromBasic => new Dictionary<string, Func<double, double>>
        {
            { "Celsius", value => value  },
            { "Kelvin", value => value + 273.15 },
            { "Fahrenheit", value => (value * 1.8) + 32},
        };

        public Dictionary<string, string> Shortcuts => new Dictionary<string, string>
        {
            { "Celsius", "C" },
            { "Fahrenheit", "F" },
            { "Kelvin", "K" },
        };

        public List<string> Units => new List<string>
        {
            "Celsius",
            "Fahrenheit",
            "Kelvin"
        };

        public double convert(string unitFrom, string unitTo, double value)
        {
            double basicUnit = UnitsToBasic[unitFrom](value);
            return UnitsFromBasic[unitTo](basicUnit);
        }
    }
}

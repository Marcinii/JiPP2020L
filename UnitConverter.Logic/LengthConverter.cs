using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter
{
    public class LengthConverter: IConverter
    {
        public string Name => "Length";

        public Dictionary<string, Func<double, double>> UnitsToBasic => new Dictionary<string, Func<double, double>>
        {
            { "Meter", value => value },
            { "Kilometer", value => value * 1000 },
            { "Mile", value => value * 1609.344 },
        };

        public Dictionary<string, Func<double, double>> UnitsFromBasic => new Dictionary<string, Func<double, double>>
        {
            { "Meter", value => value },
            { "Kilometer", value => value / 1000.0 },
            { "Mile", value => value / 1609.344 },
        };

        public Dictionary<string, string> Shortcuts => new Dictionary<string, string>
        {
            { "Meter", "m" },
            { "Kilometer", "km" },
            { "Mile", "mi" },
        };

        public List<string> Units => new List<string>
        {
            "Meter",
            "Kilometer",
            "Mile"
        };


        public double convert(string unitFrom, string unitTo, double value)
        {
            double basicUnit = UnitsToBasic[unitFrom](value);
            return UnitsFromBasic[unitTo](basicUnit);
        }
    }
}

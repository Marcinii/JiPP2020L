using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter
{
    public class WeightConverter: IConverter
    {
        public string Name => "Weight";

        public Dictionary<string, Func<double, double>> UnitsToBasic => new Dictionary<string, Func<double, double>>
        {
            { "Kilogram", value => value },
            { "Pound", value => value * 0.45359237 },
            { "Stone", value => value * 6.35029318 },
        };

        public Dictionary<string, Func<double, double>> UnitsFromBasic => new Dictionary<string, Func<double, double>>
        {
            { "Kilogram", value => value },
            { "Pound", value => value / 0.45359237 },
            { "Stone", value => value / 6.35029318 },
        };

        public Dictionary<string, string> Shortcuts => new Dictionary<string, string>
        {
            { "Kilogram", "Kg" },
            { "Pound", "Lb" },
            { "Stone", "Stone" },
        };

        public List<string> Units => new List<string>
        {
            "Kilogram",
            "Pound",
            "Stone"
        };

        public double convert(string unitFrom, string unitTo, double value)
        {
            double basicUnit = UnitsToBasic[unitFrom](value);
            return UnitsFromBasic[unitTo](basicUnit);
        }
    }
}

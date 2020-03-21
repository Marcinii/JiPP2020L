using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter
{
    public class TimeConverter: IConverter
    {
        public string Name => "Time";

        public Dictionary<string, Func<double, double>> UnitsToBasic => new Dictionary<string, Func<double, double>>
        {
            { "Second", value => value },
            { "Hour", value => value * 3600 },
            { "Minute", value => value * 60 },
        };

        public Dictionary<string, Func<double, double>> UnitsFromBasic => new Dictionary<string, Func<double, double>>
        {
            { "Second", value => value },
            { "Hour", value => value / 3600.0 },
            { "Minute", value => value / 60.0 },
        };

        public Dictionary<string, string> Shortcuts => new Dictionary<string, string>
        {
            { "Second", "s" },
            { "Hour", "h" },
            { "Minute", "min" },
        };

        public List<string> Units => new List<string>
        {
            "Second",
            "Hour",
            "Minute"
        };


        public double convert(string unitFrom, string unitTo, double value)
        {
            double basicUnit = UnitsToBasic[unitFrom](value);
            return UnitsFromBasic[unitTo](basicUnit);
        }
    }
}

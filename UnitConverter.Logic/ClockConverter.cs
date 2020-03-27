using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter
{
    public class ClockConverter : IConverter
    {
        public string Name => "Clock";

        public Dictionary<string, Func<double, double>> UnitsToBasic => new Dictionary<string, Func<double, double>>
        {
            { "12-hour", value => value > 12 ? value - 12 : value },
        };

        public Dictionary<string, Func<double, double>> UnitsFromBasic => new Dictionary<string, Func<double, double>>
        {
 
        };
    
        public Dictionary<string, string> Shortcuts => new Dictionary<string, string>
        {

        };

        public List<string> Units => new List<string>
        {
            "12-hour",
        };


        public double convert(string unitFrom, string unitTo, double value)
        {
            return UnitsToBasic[unitTo](value);
        }
    }
}

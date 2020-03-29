using KonwerterJednostek;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter.Logic
{
    public class TimeConverter : IConverter
    {
        public string Name => "Czas";

        public List<string> Units => new List<string>
        {
            "12",
            "24"
        };

        public double Convert(int from, int to, double valueToConvert)
        {
            //list all of available units and their conversion values
            double[][] factor =
                {
                    new double[] {valueToConvert, valueToConvert+12}, //12
                    new double[] {valueToConvert-12, valueToConvert}, //24
                };
            return factor[from][to];
        }
    }
}

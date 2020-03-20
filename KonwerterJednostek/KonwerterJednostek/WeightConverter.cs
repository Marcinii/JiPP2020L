using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterJednostek
{
    class WeightConverter: IConverter
    {
        public string Name => "Masy";

        public List<string> Units => new List<string>
        {
            "kg",
            "g",
            "lb"
        };

        public double Convert(int from, int to, double valueToConvert)
        {
            //list all of available units and their conversion values
            double[][] factor =
                {
                    new double[] {1, 1000, 2.20462262}, //kg
                    new double[] {0.001, 1, 0.00220462262}, //g
                    new double[] {0.45359237, 453.59237, 1} //lb
                };
            return valueToConvert * factor[from][to];
        }
    }
}

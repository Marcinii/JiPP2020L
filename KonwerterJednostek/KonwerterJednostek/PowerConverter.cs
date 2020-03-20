using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterJednostek
{
    class PowerConverter: IConverter
    {
        public string Name => "Moce";

        public List<string> Units => new List<string> {
            "W",
            "KW",
            "KM"
        };

        public double Convert(int from, int to, double valueToConvert)
        {
            //list all of available units and their conversion values
            double[][] factor =
                {
                    new double[] {1, 0.001, 0.001359621617}, //W
                    new double[] {1000, 1, 1.359621617}, //KW
                    new double[] {735.5, 0.7355, 1} //KM
                };
            return valueToConvert * factor[from][to];
        }

    }
}

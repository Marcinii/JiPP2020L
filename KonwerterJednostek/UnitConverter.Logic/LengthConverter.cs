using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterJednostek
{
    public class LengthConverter : IConverter
    {
        public string Name => "Dlugosci";

        public List<string> Units => new List<string> {
            "km",
            "m",
            "mi"
        };

        public double Convert(int from, int to, double valueToConvert)
        {
            //list all of available units and their conversion values
            double[][] factor =
                {
                    new double[] {1, 1000, 0.621371192}, //km
                    new double[] {0.001, 1, 0.000621371192}, //m
                    new double[] {1.609344, 1609.344, 1} //miles
                };
            return valueToConvert * factor[from][to];
        }



        //public enum TypesOfUnits
        //{
        //    Kilometers = 0,
        //    Meters = 1,
        //    Miles = 2
        //}

        //public TypesOfUnits ValuesInEnum { get; set; }

        //public double Convert(TypesOfUnits from, TypesOfUnits to, double valueToConvert)
        //{
        //    //list all of available units and their conversion values
        //    double[][] factor =
        //        {
        //            new double[] {1, 1000, 0.621371192},
        //            new double[] {0.001, 1, 0.000621371192},
        //            new double[] {1.609344, 1609.344, 1}
        //        };
        //    return valueToConvert * factor[(int)from][(int)to];
        //}

    }
}

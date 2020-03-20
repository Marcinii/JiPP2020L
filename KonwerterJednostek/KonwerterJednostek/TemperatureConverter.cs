using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterJednostek
{
    class TemperatureConverter: IConverter
    {
        public string Name => "Temperatury";

        public List<string> Units => new List<string>
        {
            "C",
            "F",
            "K"
        };

        public double Convert(int from, int to, double valueToConvert)
        {
            //list all of available units and their conversion values
            double[][] factor = 
                {
                    new double[] {valueToConvert, ((valueToConvert*1.8)+32), (valueToConvert+273.15) }, //values for C
                    new double[] {((valueToConvert-32)/1.8), valueToConvert, ((valueToConvert+459.67)*(5.0/9.0))}, //values for F
                    new double[] {(valueToConvert-273.15), ((valueToConvert*1.8)-459.67), valueToConvert} //values for K
                };
            return factor[from][to];
        }

        //public double Convert(string from, string to, double valueToConvert)
        //{
        //    double result=0;
        //    if (from.Equals("C") && to.Equals("F")){
        //        result = (valueToConvert * 1.8) + 32;
        //    }
        //    else if (from.Equals("F") && to.Equals("C")){
        //        result = (valueToConvert - 32) / 1.8;
        //    }
        //    return result;
        //}
    }
}

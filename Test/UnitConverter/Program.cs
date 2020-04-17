using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace UnitConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IConverter> converters = new List<IConverter>()
             {
               new TemperatureConverter(),
               new LengthConverter(),
               new WeightConverter()

             };
        }
     }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter
{
    public class WeightConverter : IConverter
    {
        public string Name => "Konwerter Wagi";

        public List<string> Units => new List<string>()
        {
            "Kilogramy",//0
            "Funty"//1
        };

        public decimal Convert(int fromUnit, int toUnit, decimal value)
        {
            if (fromUnit == 0)
            {
                value = value * (decimal)2.2046;
            }

            else
            {
                value = value / (decimal)2.2046;
            }
            return value;
        }
    }
}
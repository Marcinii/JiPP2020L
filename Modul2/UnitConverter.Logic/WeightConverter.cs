using System;
using System.Collections.Generic;
using System.Text;

namespace Modul2
{
    public class WeightConverter : IConverter
    {
        public string Name => "Weight";

        public List<string> Units => new List<string>()
        {
            "KG",
            "LB"
        };
        public double Convert(string unitFrom, string unitTo, double valueToConvert)
        {
            if (unitFrom == "KG")
            {
                return valueToConvert * 2.20462262;
            }
            else
            {
                return valueToConvert * 0.45359237;
            }
        }
    }
}

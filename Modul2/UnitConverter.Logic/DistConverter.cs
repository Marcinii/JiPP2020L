using System;
using System.Collections.Generic;
using System.Text;

namespace Modul2
{
    public class DistConverter : IConverter
    {
        public string Name => "Distance";

        public List<string> Units => new List<string>()
        {
            "KM",
            "MI"
        };
        public double Convert(string unitFrom, string unitTo, double valueToConvert)
        {
            if (unitFrom == "KM")
            {
                return valueToConvert * 0.621371192;
            }
            else
            {
                return valueToConvert * 1.609344;
            }
        }
    }
}

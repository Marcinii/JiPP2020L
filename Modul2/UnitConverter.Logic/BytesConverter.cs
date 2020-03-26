using System;
using System.Collections.Generic;
using System.Text;

namespace Modul2
{
    public class BytesConverter : IConverter
    {
        public string Name => "Bytest";

        public List<string> Units => new List<string>()
        {
            "GB",
            "MB"
        };
        public double Convert(string unitFrom, string unitTo, double valueToConvert)
        {
            if (unitFrom == "GB")
            {
                return valueToConvert * 1024;
            }
            else
            {
                return valueToConvert * 0.00097656;
            }
        }
    }
}

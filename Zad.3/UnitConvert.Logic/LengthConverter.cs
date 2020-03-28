using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter
{
    public class LengthConverter : IConverter
    {
        public List<string> Units => new List<string>()
        {
            "M",
            "KM",
            "MI"
        };

        public string Name => "Dlugosci";

        public decimal Convert(string unitFrom, string unitTo, decimal valueToConvert)
        {
            if (unitFrom == unitTo)
                return valueToConvert;
            else if (unitFrom == "M" && unitTo == "KM")
                return valueToConvert / 1000;
            else if (unitFrom == "M" && unitTo == "MI")
                return valueToConvert / (Decimal)1609.344;
            else if (unitFrom == "KM" && unitTo == "M")
                return valueToConvert * 1000;
            else if (unitFrom == "KM" && unitTo == "MI")
                return valueToConvert / (Decimal)1.609344;
            else if (unitFrom == "MI" && unitTo == "M")
                return valueToConvert * (Decimal)1609.344;
            else if (unitFrom == "MI" && unitTo == "KM")
                return valueToConvert * (Decimal)1.609344;
            else
                return valueToConvert * 2;
        }
    }
}

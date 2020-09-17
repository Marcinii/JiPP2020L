using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter
{
    public class WeightConverter : IConverter
    {
        public List<string> Units => new List<string>()
        {
            "KG",
            "G",
            "F"
        };

        public string Name => "Masy";

        public decimal Convert(string unitFrom, string unitTo, decimal valueToConvert)
        {
            if (unitFrom == unitTo)
                return valueToConvert;
            else if (unitFrom == "KG" && unitTo == "G")
                return valueToConvert * 1000;
            else if (unitFrom == "KG" && unitTo == "F")
                return valueToConvert / (Decimal)0.45359237;
            else if (unitFrom == "G" && unitTo == "KG")
                return valueToConvert / 1000;
            else if (unitFrom == "G" && unitTo == "F")
                return valueToConvert / (Decimal)453.59237;
            else if (unitFrom == "F" && unitTo == "KG")
                return valueToConvert * (Decimal)0.45359237;
            else if (unitFrom == "F" && unitTo == "G")
                return valueToConvert * (Decimal)453.59237;
            else
                return valueToConvert * 100;
        }

        public decimal Convert(object p1, object p2, decimal inputValue)
        {
            throw new NotImplementedException();
        }
    }
}

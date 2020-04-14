using System;
using System.Collections.Generic;
using System.Text;

namespace UnitConverter_M2
{
    public class MassConv : IConv
    {
        public string operationName => "Masa";
        public List<string> units => new List<string>() { "lb", "kg" };

        public string convert(string from, string to, decimal valueToConvert)
        {
            if (from.Equals(to)) return valueToConvert.ToString();

            if (from.Equals("lb") && to.Equals("kg"))
            {
                // z funtow na kilogramy
                return (valueToConvert * (decimal)0.45).ToString();
            }
            else
            {
                // z kilogramow na funty
                return (valueToConvert / (decimal)0.45).ToString();
            }
        }

        // zwraca nazwe typu konwersji
        public override string ToString()
        {
            return operationName;
        }
    }
}

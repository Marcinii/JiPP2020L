using System;
using System.Collections.Generic;
using System.Text;

namespace UnitConverter_M2
{
    public class PowerConv : IConv
    {
        public string operationName => "Moc";

        public List<string> units => new List<string>() { "w", "hp" };


        public decimal convert(string from, string to, decimal valueToConvert)
        {
            if (from.Equals("w") && to.Equals("hp"))
            {
                // z watow na konie parowe
                return valueToConvert / (decimal)745.69;
            }
            else
            {
                // w przeciwnym wypadku
                return valueToConvert * (decimal)745.69;
            }
        }

        // zwraca nazwe typu konwersji
        public override string ToString()
        {
            return operationName;
        }
    }
}

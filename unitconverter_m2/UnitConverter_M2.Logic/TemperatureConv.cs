using System;
using System.Collections.Generic;
using System.Text;

namespace UnitConverter_M2
{
    public class TemperatureConv: IConv 
    {
        public string operationName => "Temperatura";
        public List<string> units => new List<string>() { "f", "c" };

        public string convert(string from, string to, decimal valueToConvert)
        {
            if (from.Equals(to)) return valueToConvert.ToString();

            if (from.Equals("f") && to.Equals("c"))
            {
                // z fahrenheita na celsjusza
                return (((valueToConvert - 32) / 9) * 5).ToString();
            }
            else
            {
                // w przeciwnym wypadku
                return (((valueToConvert * 9) / 5) + 32).ToString();
            }
        }

        // zwraca nazwe typu konwersji
        public override string ToString()
        {
            return operationName;
        }
    }
}
    
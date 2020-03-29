using System;
using System.Collections.Generic;

namespace UnitConverter
{
    public class TemperatureConverter : IConverter
    {
        public string Name => "temperature";

        public List<string> Units => new List<string>()
        {
            "c",
            "f"
        };
        public string Convert(string from, string to, string value)
        {
            decimal DecimalValue = decimal.Parse(value);

            if (from == to)
            {
                return value;
            }
            if (from == "c")
            {
                if (to == "f")
                {
                    return ((DecimalValue * 9 / 5) + 32).ToString();
                }
            }
            if (from == "f")
            {
                if (to == "c")
                {
                    return ((DecimalValue - 32) * 5 / 9).ToString();
                }
            }
            throw new NotImplementedException();
        }
    }
}
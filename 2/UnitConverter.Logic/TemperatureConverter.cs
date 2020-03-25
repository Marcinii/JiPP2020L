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
        public decimal Convert(string from, string to, decimal value)
        {
            if (from == "c")
            {
                if (to == "f")
                {
                    return ((value * 9 / 5) + 32);
                }
            }
            if (from == "f")
            {
                if (to == "c")
                {
                    return ((value - 32) * 5 / 9);
                }
            }
            throw new NotImplementedException();
        }
    }
}
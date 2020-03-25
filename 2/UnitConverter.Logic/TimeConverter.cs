using System;
using System.Collections.Generic;

namespace UnitConverter
{
    public class TimeConverter : IConverter
    {
        public string Name => "time";

        public List<string> Units => new List<string>()
        {
            "s",
            "m"
        };

        public decimal Convert(string from, string to, decimal value)
        {
            if (from == "s")
            {
                if (to == "m")
                {
                    return Decimal.Divide(value, 60);
                }
            }
            if (from == "m")
            {
                if (to == "s")
                {
                    return Decimal.Multiply(value, 60);
                }
            }
            throw new NotImplementedException();
        }
    }
}

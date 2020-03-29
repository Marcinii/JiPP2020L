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

        public string Convert(string from, string to, string value)
        {
            decimal DecimalValue = decimal.Parse(value);

            if (from == to)
            {
                return value;
            }
            if (from == "s")
            {
                if (to == "m")
                {
                    return Decimal.Divide(DecimalValue, 60).ToString();
                }
            }
            if (from == "m")
            {
                if (to == "s")
                {
                    return Decimal.Multiply(DecimalValue, 60).ToString();
                }
            }
            throw new NotImplementedException();
        }
    }
}

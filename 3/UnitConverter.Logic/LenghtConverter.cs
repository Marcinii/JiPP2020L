using System;
using System.Collections.Generic;

namespace UnitConverter
{
    public class LenghtConverter : IConverter
    {
        public string Name => "lenght";

        public List<string> Units => new List<string>()
        {
            "km",
            "mi",
            "m"
        };

        public string Convert(string from, string to, string value)
        {
            decimal DecimalValue = decimal.Parse(value);

            if (from == to)
            {
                return value;
            }
            if (from == "km")
            {
                if (to == "mi")
                {
                    return Decimal.Divide(DecimalValue, (decimal)1.609).ToString();
                }
                if (to == "m")
                {
                    return Decimal.Multiply(DecimalValue, 1000).ToString();
                }
            }
            if (from == "mi")
            {
                if (to == "km")
                {
                    return Decimal.Multiply(DecimalValue, (decimal)1.609).ToString();
                }
                if (to == "m")
                {
                    return Decimal.Multiply(DecimalValue, 1609).ToString();
                }
            }
            if (from == "m")
            {
                if (to == "km")
                {
                    return Decimal.Divide(DecimalValue, 1000).ToString();
                }
                if (to == "mi")
                {
                    return Decimal.Divide(DecimalValue, 1609).ToString();
                }
            }
            throw new NotImplementedException();
        }
    }
}
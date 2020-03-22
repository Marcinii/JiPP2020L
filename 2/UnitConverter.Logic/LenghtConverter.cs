using System;
using System.Collections.Generic;

namespace UnitConverter
{
    public class LenghtConverter : ConverterInterface
    {
        public string Name => "lenght";

        public List<string> Units => new List<string>()
        {
            "km",
            "mi",
            "m"
        };

        public decimal Convert(string from, string to, decimal value)
        {
            if (from == "km")
            {
                if (to == "mi")
                {
                    return Decimal.Divide(value, (decimal)1.609);
                }
                if (to == "m")
                {
                    return Decimal.Multiply(value, 1000);
                }
            }
            if (from == "mi")
            {
                if (to == "km")
                {
                    return Decimal.Multiply(value, (decimal)1.609);
                }
                if (to == "m")
                {
                    return Decimal.Multiply(value, 1609);
                }
            }
            if (from == "m")
            {
                if (to == "km")
                {
                    return Decimal.Divide(value, 1000);
                }
                if (to == "mi")
                {
                    return Decimal.Divide(value, 1609);
                }
            }
            throw new NotImplementedException();
        }
    }
}
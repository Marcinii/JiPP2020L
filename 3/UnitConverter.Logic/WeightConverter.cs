using System;
using System.Collections.Generic;

namespace UnitConverter
{
    public class WeightConverter : IConverter
    {
        public string Name => "weight";

        public List<string> Units => new List<string>()
        {
            "kg",
            "lbs"
        };

        public string Convert(string from, string to, string value)
        {
            decimal DecimalValue = decimal.Parse(value);

            if (from == to)
            {
                return value;
            }
            if (from == "kg")
            {
                if (to == "lbs")
                {
                    return Decimal.Multiply(DecimalValue, (decimal)2.205).ToString();
                }
            }
            if (from == "lbs")
            {
                if (to == "kg")
                {
                    return Decimal.Divide(DecimalValue, (decimal)2.205).ToString();
                }
            }
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;

namespace UnitConverter
{
    public class WeightConverter : ConverterInterface
    {
        public string Name => "weight";

        public List<string> Units => new List<string>()
        {
            "kg",
            "lbs"
        };

        public decimal Convert(string from, string to, decimal value)
        {
            if (from == "kg")
            {
                if (to == "lbs")
                {
                    return Decimal.Multiply(value, (decimal)2.205);
                }
            }
            if (from == "lbs")
            {
                if (to == "kg")
                {
                    return Decimal.Divide(value, (decimal)2.205);
                }
            }
            throw new NotImplementedException();
        }
    }
}

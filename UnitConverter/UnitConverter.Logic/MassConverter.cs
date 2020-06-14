using System;
using System.Collections.Generic;

namespace UnitConverter.Logic
{
    public class MassConverter : IConverter
    {
        public string Name => "Mass";
        public List<string> Units => new List<string>
        {
            "kg",
            "lb",
            "oz"
        };
        public Tuple<double, string> Convert(double input_value, string input_unit, string output_unit)
        {
            if (input_unit == output_unit)
            {
                return new Tuple<double, string>(input_value, input_unit);
            }

            if (input_unit == "kg")
            {
                if (output_unit == "lb")
                {
                    return new Tuple<double, string>(input_value * 2.2046, output_unit);
                }
                else if (output_unit == "oz")
                {
                    return new Tuple<double, string>(input_value * 35.2739619496, output_unit);
                }
            }
            else if (input_unit == "lb")
            {
                if (output_unit == "kg")
                {
                    return new Tuple<double, string>(input_value / 2.2046, output_unit);
                }
                else if (output_unit == "oz")
                {
                    return new Tuple<double, string>(input_value / 0.0625, output_unit);
                }
            }
            else if (input_unit == "oz")
            {
                if (output_unit == "lb")
                {
                    return new Tuple<double, string>(input_value * 0.0625, output_unit);
                }
                else if (output_unit == "kg")
                {
                    return new Tuple<double, string>(input_value / 35.2739619496, output_unit);
                }
            }

            throw new ArgumentException("Invalid unit");
        }
    }
}

using System;
using System.Collections.Generic;

namespace UnitConverter.Logic
{
    public class ByteConverter : IConverter
    {
        public string Name => "Byte";
        public List<string> Units => new List<string>
        {
            "b",
            "kb",
            "mb",
            "gb",
        };
        public Tuple<double, string> Convert(double input_value, string input_unit, string output_unit)
        {
            if (input_unit == output_unit)
            {
                return new Tuple<double, string>(input_value, input_unit);
            }

            if (input_unit == "b")
            {
                if (output_unit == "kb")
                {
                    return new Tuple<double, string>(input_value / 1000, output_unit);
                }
                else if (output_unit == "mb")
                {
                    return new Tuple<double, string>(input_value / 10000, output_unit);
                }
                else if (output_unit == "gb")
                {
                    return new Tuple<double, string>(input_value / 100000, output_unit);
                }
            }
            else if (input_unit == "kb")
            {
                if (output_unit == "b")
                {
                    return new Tuple<double, string>(input_value * 1000, output_unit);
                }
                else if (output_unit == "mb")
                {
                    return new Tuple<double, string>(input_value / 1000, output_unit);
                }
                else if (output_unit == "gb")
                {
                    return new Tuple<double, string>(input_value / 10000, output_unit);
                }
            }
            else if (input_unit == "mb")
            {
                if (output_unit == "b")
                {
                    return new Tuple<double, string>(input_value * 10000, output_unit);
                }
                else if (output_unit == "kb")
                {
                    return new Tuple<double, string>(input_value * 1000, output_unit);
                }
                else if (output_unit == "gb")
                {
                    return new Tuple<double, string>(input_value / 1000, output_unit);
                }
            }
            else if (input_unit == "gb")
            {
                if (output_unit == "b")
                {
                    return new Tuple<double, string>(input_value * 100000, output_unit);
                }
                else if (output_unit == "kb")
                {
                    return new Tuple<double, string>(input_value * 10000, output_unit);
                }
                else if (output_unit == "mb")
                {
                    return new Tuple<double, string>(input_value * 1000, output_unit);
                }
            }

            throw new ArgumentException("Invalid unit");
        }
    }
}

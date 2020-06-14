using System;
using System.Collections.Generic;

namespace UnitConverter.Logic
{
    public class TemperatureConverter : IConverter
    {
        public string Name => "Temperature";
        public List<string> Units => new List<string>
        {
            "C",
            "F",
            "K"
        };
        public Tuple<double, string> Convert(double input_value, string input_unit, string output_unit)
        {
            if (input_unit == output_unit)
            {
                return new Tuple<double, string>(input_value, input_unit);
            }

            if (input_unit == "C")
            {
                if (output_unit == "F")
                {
                    return new Tuple<double, string>(input_value * (9/5) + 32, output_unit);
                }
                else if (output_unit == "K")
                {
                    return new Tuple<double, string>(input_value + 273.15, output_unit);
                }
            }
            else if (input_unit == "F")
            {
                if (output_unit == "C")
                {
                    return new Tuple<double, string>((input_value - 32) * 5/9, output_unit);
                }
                else if (output_unit == "K")
                {
                    return new Tuple<double, string>((input_value + 459.67) * 5/9, output_unit);
                }
            }
            else if (input_unit == "K")
            {
                if (output_unit == "C")
                {
                    return new Tuple<double, string>(input_value - 273.15, output_unit);
                }
                else if (output_unit == "F")
                {
                    return new Tuple<double, string>((input_value * 9/5) - 459.67, output_unit);
                }
            }

            throw new ArgumentException("Invalid unit");
        }
    }
}

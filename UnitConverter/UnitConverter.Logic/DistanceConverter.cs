using System;
using System.Collections.Generic;

namespace UnitConverter.Logic
{
    public class DistanceConverter : IConverter
    {
        public string Name => "Distance";
        public List<string> Units => new List<string>
        {
            "km",
            "mi"
        };
        public Tuple<double, string> Convert(double input_value, string input_unit, string output_unit)
        {
            if (input_unit == output_unit)
            {
                return new Tuple<double, string>(input_value, input_unit);
            }

            if (input_unit == "km")
            {
                return new Tuple<double, string>(input_value * 0.621371192, "mi");
            }
            else if (input_unit == "mi")
            {
                return new Tuple<double, string>(input_value / 0.621371192, "km");
            }

            throw new ArgumentException("Invalid unit");
        }
    }
}

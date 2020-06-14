using System;
using System.Text;
using System.Collections.Generic;

namespace UnitConverter.Logic
{
    public class TimeConverter : IConverter
    {
        public string Name => "Time";
        public List<string> Units => new List<string>() {
            "am",
            "pm",
            ""
        };
        public Tuple<double, string> Convert(double input_value, string input_unit, string output_unit)
        {
            if (input_unit == output_unit)
            {
                return new Tuple<double, string>(input_value, input_unit);
            }

            var hours = Math.Floor(input_value);
            var minutes = Math.Floor((input_value - hours) * 100);

            if (input_unit == "am")
            {
                if (hours > 12 || hours < 0 || minutes > 60 || minutes < 0)
                {
                    throw new ArgumentException("Invalid time format");
                }

                return new Tuple<double, string>(Double.Parse($"{hours}.{minutes}"), "");
            }
            else if (input_unit == "pm")
            {
                if (hours > 12 || hours < 0 || minutes > 60 || minutes < 0)
                {
                    throw new ArgumentException("Invalid time format");
                }

                return new Tuple<double, string>(Double.Parse($"{hours + 12}.{minutes}"), "");
            }
            else if (input_unit == "")
            {
                if (hours > 24 || hours < 0 || minutes > 60 || minutes < 0)
                {
                    throw new ArgumentException("Invalid time format");
                }

                if (hours > 12)
                {
                    return new Tuple<double, string>(Double.Parse($"{hours - 12}.{minutes}"), "pm");
                }
                else
                {
                    return new Tuple<double, string>(Double.Parse($"{hours}.{minutes}"), "am");
                }
            }

            throw new ArgumentException("Invalid time format");
        }
    }
}

using System;
using System.Collections.Generic;

namespace UnitConverter
{
    public class TimeConverter : IConverter
    {
        public string Name => "Czas";

        public List<string> Units => new List<string>()
        {
            "12h",
            "24h"
        };

        public string Convert(string from, string to, string value)
        {
            DateTime DateTimeValue = DateTime.Parse(value);

            if (from == to)
            {
                return value;
            }
            if (from == "12h")
            {
                DateTimeValue = DateTimeValue.AddHours(12);
                if (to == "24h")
                {
                    return DateTimeValue.ToString("H:mm");
                }
            }
            if (from == "24h")
            {
                if (to == "12h")
                {
                    return DateTimeValue.ToString("h:mm tt");
                }
            }
            throw new NotImplementedException();
        }
    }
}
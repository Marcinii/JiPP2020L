using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Konwerter;

namespace Converter.Logic
{
    public class TimeConverter : IEConverter
    {
        public string Name => "Czas";

        public List<string> Units => new List<string>()
        {
            "12hour",
            "24hour"
        };

        public float ConvertUnit(string from, string to, float Value)
        {
            float temp = Value;
            return 0f;
        }

        public string ConvertUnit(string from, string to, string Value)
        {
            string temp = Value;

            temp = DateTime.ParseExact(Value, "HH:mm", CultureInfo.CurrentCulture).ToString("hh:mm tt");

            return temp;
        }
    }
}

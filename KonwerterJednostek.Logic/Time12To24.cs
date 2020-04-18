using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace KonwerterJednostek.Logic
{
    public class Time12To24 : IKonwerter
    {
        public double T12;
        public double T24;
        private double valueToConvert;
        public Time12To24()
        {
            this.T12 = 0;
            this.T24 = 0;
            this.valueToConvert = 0;
        }

        public Time12To24(double valueToConvert)
        {
            this.valueToConvert = valueToConvert;
        }
        public List<string> Units => new List<string>()
        {
            "T12",
            "T24"
        };

        public string Name => "Zmiana czasu z 12h na 24h";

        static Regex t12regex = new Regex(@"(\d+):(\d+)(\w{2})");

        object IKonwerter.Convert(object valueToConvert) => Convert((string) valueToConvert);

        public string Convert(string valueToConvert)
        {
            var match = t12regex.Match(valueToConvert);
            int hour = int.Parse(match.Groups[1].Value);
            int minute = int.Parse(match.Groups[2].Value);
            var dayHalf = match.Groups[3].Value;
            if (dayHalf == "PM")
            {
                return $"{hour + 12}:{minute}";
            }
            else
            {
                return $"{hour}:{minute}";
            }
        }

        public string UnitConv(string unitFrom, string unitTo, string number)
        {
            bool success = double.TryParse(number, out double valueToConvert);
            if (!success) { valueToConvert = 0; }
            Time12To24 a = new Time12To24(valueToConvert);
            if (unitFrom == Units[0] && unitTo == Units[1])
            {
                return a.T24 + " 24h";
            }
            else if (unitFrom == Units[1] && unitTo == Units[0])
            {
                return a.T12 + " 12h";
            }
            else { return Error.Info(); }
        }
    }
}
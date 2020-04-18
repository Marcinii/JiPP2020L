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
        public double T24;
        public double T12;
        private double inputValue;

        public Time12To24(double inputValue)
        {
            this.inputValue = inputValue;
        }

        public Time12To24()
        {
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

        public string UnitConv(string from, string to, string number)
        {
            bool success = double.TryParse(number, out double inputValue);
            if (!success) { inputValue = 0; }
            Time12To24 a = new Time12To24(inputValue);
            if (from == Units[0] && to == Units[1])
            {
                return a.T24 + " 24h";
            }
            else if (from == Units[1] && to == Units[0])
            {
                return a.T12 + " 12h";
            }
            else { return Error.Info(); }
        }
    }
}
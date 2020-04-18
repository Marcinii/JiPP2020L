using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace KonwerterJednostek.Logic
{
    public class Time24To12 : IKonwerter
    {
        public double T24;
        public double T12;
        private double inputValue;

        public Time24To12(double inputValue)
        {
            this.inputValue = inputValue;
        }

        public Time24To12()
        {
        }

        public List<string> Units => new List<string>()
        {
            "T24",
            "T12"
        };

        public string Name => "Zmiana czasu z 24h na 12h";

        object IKonwerter.Convert(object valueToConvert) => Convert((string) valueToConvert);

        static Regex t24regex = new Regex(@"(\d+):(\d+)");

        public string Convert(string valueToConvert)
        {
            var match = t24regex.Match(valueToConvert);
            var hour = int.Parse(match.Groups[1].Value);
            var minute = int.Parse(match.Groups[2].Value);
            if (hour <= 12)
            {
                return $"{hour}:{minute}AM";
            }
            else
            {
                return $"{hour - 12}:{minute}PM";
            }
        }

        public string UnitConv(string from, string to, string number)
        {
                bool success = double.TryParse(number, out double inputValue);
                if (!success) { inputValue = 0; }
                Time24To12 a = new Time24To12(inputValue);
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
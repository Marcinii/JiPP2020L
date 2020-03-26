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
            var hour = int.Parse(match.Groups[1].Value);
            var minute = int.Parse(match.Groups[2].Value);
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
    }
}
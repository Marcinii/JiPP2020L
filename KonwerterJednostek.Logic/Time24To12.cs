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
    }
}

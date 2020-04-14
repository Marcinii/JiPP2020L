using System;
using System.Collections.Generic;
using System.Text;

namespace UnitConverter_M2
{
    public class TimeConv : IConv
    {
        public string operationName => "Czas";

        public List<string> units => new List<string>() { "24h", "12h" };


        public string convert(string from, string to, decimal valueToConvert)
        {
            if (from.Equals(to)) return valueToConvert.ToString().Replace(".", ":").Replace(",", ":");

            string liczba = valueToConvert.ToString().Replace(".", ":").Replace(",", ":");

            char[] separator = { ':' };

            string przekonwertowane = "";
            
            String[] strlist = liczba.Split(separator);
            int godziny = Int32.Parse(strlist[0]);

            if (godziny > 12) return (godziny - 12).ToString() + ":" + strlist[1] + "pm";
            else return liczba + "am";

        }

        // zwraca nazwe typu konwersji
        public override string ToString()
        {
            return operationName;
        }
    }
}

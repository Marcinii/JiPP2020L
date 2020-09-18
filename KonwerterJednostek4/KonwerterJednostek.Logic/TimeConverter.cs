using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterJednostek
{
    public class TimeConverter
    {
        public string Name => "Konwerter Czasu";

        public string Convert(string value)
        {
            int h1 = GetHour(value);
            int m1 = GetMinute(value);
            char[] chars = { value[3], value[4] };
            string m2 = new string(chars);
            string ampm;
            if (h1 >= 12 && h1 < 24 && m1 >= 0 && m1 <= 59)
            {
                ampm = "PM";
                if(h1 != 12)
                {
                    h1 %= 12;
                }
                value = h1 + ":" + m2 + ampm;
                return value;
            }
            else if(h1 >= 0 && h1 < 12 && m1 >= 0 && m1 <= 59)
            {
                ampm = "AM";
                if (h1 == 0)
                {
                    h1 = 12;
                }
                value = h1 + ":" + m2 + ampm;
                return value;
            }
            else
            {
                Console.WriteLine("Wprowadzono niepoprawną jednostkę, nastapi powrót do menu wyboru");
                return null;
            }
        }

        public int GetHour(string h)
        {
            int hour = 0;
            if(h.Length == 5)
            {
                hour = ((int)h[0] - '0') * 10 + (int)h[1] - '0';
            }
            return hour;
        }

        public int GetMinute(string m)
        {
            int mins = 0;
            if(m.Length == 5)
            {
                mins = ((int)m[3] - '0') * 10 + (int)m[4] - '0';
            }
            return mins;
        }

    }
}

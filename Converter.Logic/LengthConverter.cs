using System;
using System.Collections.Generic;
using System.Text;

namespace Konwerter
{
    public class LengthConverter : IEConverter
    {
        public string Name => "Dlugosc";

        public List<string> Units => new List<string>()
        {
            "km",
            "mil"
        };

        public float ConvertUnit(string from, string to, float Value)
        {
            float temp = Value;
            if (from == "km" && to == "mil")
            {
                Console.WriteLine("Wpisz dlugosc");
                float oldTemp = temp;
                temp = temp * 0.62137f;
                Console.WriteLine(oldTemp + " kilometrow to " + temp + " mil");
                return temp;
            }
            else if (from == "mil" && to == "km")
            {
                Console.WriteLine("Wpisz dlugosc");
                float oldTemp = temp;
                temp = temp / 0.62137f;
                Console.WriteLine(oldTemp + " mil to " + temp + " kilometrow");
                return temp;
            }
            else
            {
                Console.WriteLine("Błędne jednostki");
                return 0f;
            }
        }

        public string ConvertUnit(string from, string to, string Value)
        {
            throw new NotImplementedException();
        }
    }
}

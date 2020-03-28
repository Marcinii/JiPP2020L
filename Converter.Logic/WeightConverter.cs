using System;
using System.Collections.Generic;
using System.Text;

namespace Konwerter
{
    public class WeightConverter : IEConverter
    {
        public string Name => "Waga";
        public List<string> Units => new List<string>()
        {
            "kg",
            "f",
            "t"

        };
        public float ConvertUnit(string from, string to, float Value)
        {
            float temp = Value;
            if (from == "kg" && to == "f")
            {
                float oldTemp = temp;
                temp = temp * 2.2046f;
                Console.WriteLine(oldTemp + " kilogramow to " + temp + " funtow");
                return temp;
            }
            else if (from == "f" && to == "kg")
            {
                float oldTemp = temp;
                temp = temp / 2.2046f;
                Console.WriteLine(oldTemp + " funtow to " + temp + " kilogramy");
                return temp;
            }
            else if (from == "t" && to == "kg")
            {
                float oldTemp = temp;
                temp = temp * 1000f;
                Console.WriteLine(oldTemp + " ton to " + temp + " kilogramy");
                return temp;
            }
            else if (from == "kg" && to == "t")
            {
                float oldTemp = temp;
                temp = temp / 1000f;
                Console.WriteLine(oldTemp + " kilogramow to " + temp + " ton");
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

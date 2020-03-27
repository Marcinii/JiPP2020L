using System;
using System.Collections.Generic;
using System.Text;

namespace Konwerter
{
    public class TempConverter : IEConverter
    {
        public string Name => "Temperatury";
        public List<string> Units => new List<string>()
        {
            "C",
            "K"
        };

        public float ConvertUnit(string from, string to, float Value)
        {
            float temp = Value;

            if (from == "C" && to == "K")
            {
                float oldTemp = temp;
                temp = (temp * 1.8f) + 32f;
                Console.WriteLine(oldTemp + " Celsjuszy to " + temp + " Farenheitow");
                return temp;
            }
            else if (from == "K" && to == "C")
            {
                float oldTemp = temp;
                temp = (temp - 32f) / 1.8f;
                Console.WriteLine(oldTemp + " Farenheitow to " + temp + " Celsjuszy");
                return temp;
            }
            else 
            {
                    Console.WriteLine("Błędne jednostki");
                    return 0f;
             
            }
                
        }
    }
}

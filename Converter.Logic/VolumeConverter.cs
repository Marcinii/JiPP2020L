using System;
using System.Collections.Generic;
using System.Text;

namespace Konwerter
{
    public class VolumeConverter : IEConverter
    {
        public string Name => "Pojemnosc";
        public List<string> Units => new List<string>()
        {
            "ml",
            "l"
        };
        public float ConvertUnit(string from, string to, float Value)
        {
            float temp = Value;
            if (from == "l" && to == "ml")
            {
                float oldTemp = temp;
                temp = temp * 1000f;
                Console.WriteLine(oldTemp + " mililitrow to " + temp + " litrow");
                return temp;
            }
            else if (from == "l" && to == "ml")
            {
                float oldTemp = temp;
                temp = temp / 1000f;
                Console.WriteLine(oldTemp + " litrow to " + temp + " mililitrow");
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

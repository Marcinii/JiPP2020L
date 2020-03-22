using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
   public class Prędkość : PrzelicznikI
    {
        public string Name => "Konwerter Prędkości";

        public List<string> jednostka => new List<string>
        {
            "m/s",
            "mph"
        };

    public double przelicz(string jednostka1, string jednostka2, double liczba)
        {
            if (jednostka1 == "m/s" && jednostka2 == "mph")
            {
                return liczba * 2.2369;
            }
            else if (jednostka1 == "mph" && jednostka2 == "m/s")
            {
                return liczba * 0.4470400;
            }
            else return 0;
        }
    }
}

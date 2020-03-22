using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
   public class Długości : PrzelicznikI
    {
        public string Name => "Przelicznik Dlugosci";

        public List<string> jednostka => new List<string>
        {
            "km",
            "mi"
        };

        public double przelicz(string jednostka1, string jednostka2, double liczba)
        {
            {
                if (jednostka1 == "km" && jednostka2 == "mi")
                {
                    return liczba * 0.62137;
                }
                else if (jednostka1 == "mi" && jednostka2 == "km")
                {
                    return liczba / 0.62137;
                }
                else return 0;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Przelicznik.Logic
{
    public class Temperatury : PrzelicznikI
    {
        public string Name => "Konwerter Temperatur";

        public List<string> jednostka => new List<string>
        {
            "C",
            "F"
        };

        public double przelicz(string jednostka1, string jednostka2, double liczba)
        {
            if (jednostka1 == "C" && jednostka2 == "F")
            {
                return liczba * 1.8000 + 32.00;
            }
            else if (jednostka1 == "F" && jednostka2 == "C")
            {
                return (liczba - 32.00) / 1.8000;
            }
            else return 0;
        }

        public string przeliczCzas(string czas)
        {
            return "";
        }
    }
}

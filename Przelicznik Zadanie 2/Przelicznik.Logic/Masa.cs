using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    public class Masa : PrzelicznikI
    {
        public string Name => "Przelicznik Masy";
        public List<string> jednostka => new List<string>
        {
            "kg",
            "lb",
            "t",
        };

    public double przelicz(string jednostka1,string jednostka2, double liczba)
        {
            if(jednostka1 == "kg")
            {
                if(jednostka2 == "lb")
                {
                    return liczba * 2.2046;
                }
                else if(jednostka2 == "t")
                {
                    return liczba / 1000;
                }
                return 0;
            }
            else if (jednostka1 == "lb")
            {
                if (jednostka2 == "kg")
                {
                    return liczba * 0.45359237;
                }
                else if (jednostka2 == "t")
                {
                    return liczba * 0.00045359;
                }
                return 0;
            }
            else if (jednostka1 == "t")
            {
                if (jednostka2 == "kg")
                {
                    return liczba * 1000;
                }
                else if (jednostka2 == "lb")
                {
                    return liczba * 2204.6226;
                }
                else return 0;
            }
            else
            {
                return 0;
            }
        }
    }
}

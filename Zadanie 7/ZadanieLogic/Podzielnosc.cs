using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZadanieLogic
{
    public class Podzielnosc : IChecker
    {
        public string Name => "podzielny";

        public List<string> Units => new List<string>()
        {
            "3",
            "5"
        };

        public string Check(string podziel, string valueToCheck)
        {

            if (podziel == "3")
            {
                decimal check = decimal.Parse(valueToCheck) % 3;
                if (check == 0)
                {
                    return "TAK";
                }
                else
                {
                    return "NIE";
                }
            }
            if (podziel == "5")
            {
                decimal check = decimal.Parse(valueToCheck) % 5;
                if (check == 0)
                {
                    return "TAK";
                }
                else
                {
                    return "NIE";
                }

            }
            return " ";
        }
    }
}
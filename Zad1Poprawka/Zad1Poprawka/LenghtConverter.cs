using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad1Poprawka
{
    class LenghtConverter : IConverter{
        public string name => "Dlugosci";

        public List<string> Units => new List<string>
        {
            "Km",
            "Mi"
        };

        public decimal Convert(string convertFrom, string convertTo, decimal value)
        {
            if (convertFrom.Equals("Km") && convertTo.Equals("Mi"))
            {
                return value*0.621m; // 1 kilometr = 0,621371192 mili
            }
            else if (convertFrom.Equals("Mi") && convertTo.Equals("Km"))
            {
                return value/0.621m;
            }
            return -1;
        }
    }
}

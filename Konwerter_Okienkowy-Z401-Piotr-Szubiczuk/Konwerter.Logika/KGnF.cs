using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter
{
    public class KGnF : Ikonwenter
    {
        public string Nazwa => "Masa_KGnFF";

        public List<string> Jednostki => new List<string>()
        {
            "KM",
            "Mil"
        };

        public double Konwer(string zczego, string naco, double wartosc)
        {
            return wartosc * 2.20462262D;
        }
    }
}

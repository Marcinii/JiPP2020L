using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter
{
    public class FnKG : Ikonwenter
    {
        public string Nazwa => "Masa_FnKG";

        public List<string> Jednostki => new List<string>()
        {
            "KM",
            "Mil"
        };

        public double Konwer(string zczego, string naco, double wartosc)
        {
            return wartosc / 0.45359237D;
        }
    }
}

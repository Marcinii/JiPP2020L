using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter
{
    public class KWnW : Ikonwenter
    {
        public string Nazwa => "MOC_WATnKW";

        public List<string> Jednostki => new List<string>()
        {
            "W",
            "KW"
        };

        public double Konwer(string zczego, string naco, double wartosc)
        {
            return wartosc * 1000D;
        }
    }
}
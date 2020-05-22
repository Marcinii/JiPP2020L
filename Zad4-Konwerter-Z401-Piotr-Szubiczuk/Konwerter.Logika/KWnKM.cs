using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter
{
    public class KWnKM : Ikonwenter
    {
        public string Nazwa => "Moc_KWnKM";

        public List<string> Jednostki => new List<string>()
        {
            "KW",
            "KM"
        };

        public double Konwer(string zczego, string naco, double wartosc)
        {
            return wartosc * 1.36D;
        }
    }
}
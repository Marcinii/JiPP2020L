using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter.Logika
{
    public class MnKM : Ikonwenter
    {
        public string Nazwa => "Dlugosc_MnKM";

        public List<string> Jednostki => new List<string>()
        {
            "M",
            "KM"
        };

        public double Konwer(string zczego, string naco, double wartosc)
        {
            return wartosc * 1.609344D;
        }
    }
}

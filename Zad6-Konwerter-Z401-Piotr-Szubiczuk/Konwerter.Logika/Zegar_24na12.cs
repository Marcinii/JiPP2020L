using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter.Logika
{
    public class Zegar_24na12 : Ikonwenter
    {
        public string Nazwa => "Zegar_24na12";

        public List<string> Jednostki => new List<string>()
        {
            "24-godz",
            "12-godz"
        };

        public double Konwer(string zczego, string naco, double wartosc)
        {
            if (wartosc == 0 || wartosc == 12 || wartosc == 24) { return 12; }
            else if (wartosc < 12) { return wartosc; }
            else { return wartosc - 12; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter
{
    public class FunnaKil : Ikonwenter
    {
        public string Nazwa => "M:Funt_Kil";

        public List<string> Jednostki => new List<string>()
        {
            "KG",
            "F"
        };

        public double Konwer(string z, string n, double w)
        {
            return w / 0.45359237D;
        }
    }
}

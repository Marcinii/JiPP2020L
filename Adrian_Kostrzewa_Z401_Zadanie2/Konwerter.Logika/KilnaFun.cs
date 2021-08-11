using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter
{
    public class KilnaFun : Ikonwenter
    {
        public string Nazwa => "M:Kil_Funt";

        public List<string> Jednostki => new List<string>()
        {
            "KG",
            "F"
        };

        public double Konwer(string z, string n, double w)
        {
            return w * 2.20462262D;
        }
    }
}

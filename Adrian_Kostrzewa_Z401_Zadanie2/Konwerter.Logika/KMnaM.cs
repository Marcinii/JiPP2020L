using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter
{
    public class KMnaM : Ikonwenter
    {
        public string Nazwa => "D:KM_Mil";

        public List<string> Jednostki => new List<string>()
        {
            "KM",
            "M"
        };

        public double Konwer(string z, string n, double w)
        {
            return w/ 1.609344D;
        }
    }
}
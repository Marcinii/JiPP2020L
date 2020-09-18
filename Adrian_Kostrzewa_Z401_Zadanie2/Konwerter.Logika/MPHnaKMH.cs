using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter
{
    public class MPHnaKMH : Ikonwenter
    {
        public string Nazwa => "P:MPH_KMH";

        public List<string> Jednostki => new List<string>()
        {
            "MPH",
            "KMH"
        };

        public double Konwer(string z, string n, double w)
        {
            return w / 1.609344D;
        }
    }
}
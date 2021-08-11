using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter
{
    public class KMHnaMPH : Ikonwenter
    {
        public string Nazwa => "P:KMH_MPH";

        public List<string> Jednostki => new List<string>()
        {
            "KMH",
            "MPH"
        };

        public double Konwer(string z, string n, double w)
        {
            return w * 1.609344D;
        }
    }
}
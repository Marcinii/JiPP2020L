using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwenter_jednostek
{
    public class konwenter_dlugosci : IKonwenter
    {

        public List<string> Jednostki => new List<string>()
        {
            "km",
            "mile"
        };
        public string Nazwa => "Dlugosci";
        public string jednostkii => "km, mile";
        public double Konwertuj(string z, string doo, double a)
        {
            if (z == "km" & doo == "mile")
            {
                return a * 0.62;
            }
            else if (z == "mile" & doo == "km" )
            {
                return a * 1.61;
            }
            
            return a;
        }
    }
}

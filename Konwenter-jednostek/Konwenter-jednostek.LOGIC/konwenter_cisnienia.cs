using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwenter_jednostek
{
    public class konwenter_cisnienia : IKonwenter
    {

        public List<string> Jednostki => new List<string>()
        {
            "bar",
            "psi"
        };
        public string Nazwa => "Cisnienia";
        public string jednostkii => "bar, psi";
        public double Konwertuj(string z, string doo, double a)
        {
            if (z == "bar" & doo == "psi")
            {
                return a * 14.50;
            }
            else if (z == "psi" & doo == "bar")
            {
                return a * 0.07;
            }

            return a;
        }
    }
}
 
    
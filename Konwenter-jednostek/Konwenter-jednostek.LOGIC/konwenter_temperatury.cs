using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwenter_jednostek
{
    public class konwenter_temperatury : IKonwenter
    {

        public List<string> Jednostki => new List<string>()
        {
            "C",
            "F"
        };
        public string Nazwa => "Temperatury";
        public string jednostkii => "C, F";
        public double Konwertuj(string z, string doo, double a)
        {
            if (z == "C" & doo == "F")
            {
                return a * 9 / 5 + 32;
            }
            else if (z == "F" & doo == "C")
            {
                return (a - 32) * 5 / 9;
            }

            return a;
        }
    }
}




   
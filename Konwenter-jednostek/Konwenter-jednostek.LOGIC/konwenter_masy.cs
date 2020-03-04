using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwenter_jednostek
{
    public class konwenter_masy : IKonwenter
    {

        public List<string> Jednostki => new List<string>()
        {
            "kg",
            "funty",
            "tony"
        };
        public string Nazwa => "Masy";
        public string jednostkii => "kg, funty, tony";

        public double Konwertuj(string z, string doo, double a)
        {
            if (z == "kg" & doo == "funty")
            {
                return a * 2.20;
            }
            else if (z == "funty" & doo == "kg")
            {
                return a * 0.45;
            }
            else if (z=="kg" & doo == "tony")
            {
                return a / 1000;
            }
            else if (z == "tony" & doo == "kg")
            {
                return a * 1000;
            }
            else if (z == "funty" & doo == "tony")
            {
                return a* 0.00045;
            }
            else if (z == "tony" & doo == "funty")
            {
                return a* 2204.6;
            }
                return a;
        }
    }
}
 
     
    

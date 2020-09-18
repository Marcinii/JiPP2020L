using System;
using System.Collections.Generic;
using System.Text;

namespace Konwerter
{
    public class FahnaCel : Ikonwenter
    {
        public string Nazwa => "T:Fah_Cel";

        public List<string> Jednostki => new List<string>()
        {
            "F",
            "C"
        };
        public double Konwer(string z, string n, double w)
        {
            return (9D / 5 * w + 32);
        }
    }
}

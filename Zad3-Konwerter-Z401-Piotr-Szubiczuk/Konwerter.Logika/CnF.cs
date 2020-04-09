using System;
using System.Collections.Generic;
using System.Text;

namespace Konwerter
{
    public class CnF: Ikonwenter
    {
        public string Nazwa => "Temp_CnaF";

        public List<string> Jednostki => new List<string>()
        { 
            "C",
            "F"
        };

        public double Konwer(string zczego, string naco, double wartosc)
        {
            return (5D / 9 * (wartosc - 32));
        }
    }
}

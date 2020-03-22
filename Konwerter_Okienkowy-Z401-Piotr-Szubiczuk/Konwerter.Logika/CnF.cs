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
            "F",
            "C"
        };

        public double Konwer(string zczego, string naco, double wartosc)
        {
            double fahrenhait, celcjusz;
            fahrenhait = double.Parse(Console.ReadLine());
            celcjusz = 5D / 9 * (fahrenhait - 32);
            return celcjusz;
        }
    }
}

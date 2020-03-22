using System;
using System.Collections.Generic;
using System.Text;

namespace Konwerter
{
    public class FnC : Ikonwenter
    {
        public string Nazwa => "Temp_FnaC";

        public List<string> Jednostki => new List<string>()
        {
            "F",
            "C" 
        };

        public double Konwer(string zczego, string naco, double wartosc)
        {
            wartosc = double.Parse(Console.ReadLine());
 //           double fahrenhait, celcjusz;
 //            celcjusz = double.Parse(Console.ReadLine());
 //           fahrenhait = 9D / 5 * celcjusz + 32;
            return wartosc=(9D / 5 * wartosc + 32);
        }
    }
}

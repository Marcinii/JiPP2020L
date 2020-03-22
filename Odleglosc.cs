using System;
using System.Collections.Generic;
using System.Text;

namespace ZAD2
{
    public class Odleglosc: IProgram
    {
        string IProgram.Name => "Odleglosc";

        List<string> IProgram.j_ => new List<string>()
        {
            "km",
            "mi"
        };
        public double Konwersja(string j_z, string j_do, double liczba)
        {
            double km = 0, mi = 0;
            if (j_z == "mi" && j_do == "km")
            {
                mi = liczba;
                km = mi / 0.62137;
                return km;
            }
            else if(j_z == "km" && j_do == "mi")
            {
                km = liczba;
                mi = km * 0.62137;
                return mi;
            }
            else { return 0; }
        }

    }
}

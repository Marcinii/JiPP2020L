using System;
using System.Collections.Generic;
using System.Text;

namespace ZAD2
{
    public class Objetosc : IProgram
    {
        string IProgram.Name => "Objetosc";

        List<string> IProgram.j_ => new List<string>()
        {
        "l",
        "gal"
        };
        public double Konwersja(string j_z, string j_do, double liczba)
        {
            double l = 0, gal = 0;
            if (j_z == "l" && j_do == "gal")
            {
                l = liczba;
                gal = l *0.26417;
                return gal;
            }
            else if (j_z == "gal" && j_do == "l")
            {
                gal = liczba;
                l = gal / 0.26417;
                return l;
            }
            else { return 0; }
        }
    }
}

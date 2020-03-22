using System;
using System.Collections.Generic;
using System.Text;

namespace ZAD2
{
    public class Temperatura: IProgram
    {
        string IProgram.Name => "Temperatura";

        List<string> IProgram.j_ => new List<string>()
        {
            "C",
            "F"
        };
        public double Konwersja(string j_z,string j_do,double liczba)
        {
            double F = 0, C = 0;
            if (j_z == "C" && j_do == "F")
            {
                C = liczba;
                F = 32 + ((9.0 / 5.0) * C);
                return F;
            }
            else if(j_z == "F" && j_do == "C")
            {
                F = liczba;
                C = 5.0 / 9.0 * (F - 32);
                return C;
            }
            else { return 0; }
        }
    }
}

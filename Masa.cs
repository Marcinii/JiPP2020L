using System;
using System.Collections.Generic;
using System.Text;

namespace ZAD2
{
    public class Masa: IProgram
    {

        string IProgram.Name => "Masa";

        List<string> IProgram.j_ => new List<string>()
        {
            "kg",
            "lb",
            "oz"
        };

        public double Konwersja(string j_z, string j_do, double liczba)
        {
            double kg = 0, lb = 0,oz=0;
            if (j_z == "lb" && j_do == "kg")
            {
                lb = liczba;
                kg = lb / 2.2046;
                return kg;
            }
            else if(j_z == "kg" && j_do == "lb")
            {
                kg = liczba;
                lb = kg * 2.2046;
                return lb;
            }
            else if (j_z == "kg" && j_do == "oz")
            {
                kg = liczba;
                oz = kg * 35.274;
                return oz;
            }
            else if (j_z == "lb" && j_do == "oz")
            {
                lb = liczba;
                oz = lb * 16;
                return oz;
            }
            else if (j_z == "oz" && j_do == "kg")
            {
                oz = liczba;
                kg = oz / 35.274;
                return kg;
            }
            else if (j_z == "oz" && j_do == "lb")
            {
                oz = liczba;
                lb = oz * 0.0625;
                return lb;
            }
            else { return 0; }
        }

    }
}

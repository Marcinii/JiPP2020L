using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter
{
    public class Temperatura: IKonwerter
    {
        public string Name => "Temperatura";

        public List<string> Unit => new List<string>()
        {
            "C",
            "F",
            "K"
        };

        public double Konwert(string Z, string Do, double wartosc)
        {
            double Wynik = 0;

            if(Z=="C" && Do=="F")
            {
                Wynik = wartosc * 9 / 5 + 32;
            }
            if (Z == "F" && Do == "C")
            {
                Wynik = (wartosc - 32) * 5 / 9;
            }
            if(Z=="K" && Do=="C")
            {
                Wynik = wartosc - 273.15;
            }
            if (Z == "C" && Do == "K")
            {
                Wynik = wartosc + 273.15;
            }
            if (Z == "F" && Do == "K")
            {
                Wynik = (wartosc - 32) * 5 / 9 + 273.15;
            }
            if (Z == "K" && Do == "F")
            {
                Wynik = (wartosc - 273.15) * 9 / 5 + 32;
            }

            return Wynik;
        }

    }
}

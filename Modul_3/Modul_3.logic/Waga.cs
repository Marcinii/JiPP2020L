using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul_3
{

    public class Waga : Ikonwerter
    {
        public List<string> Unit => new List<string>() {
        "Kilogram-Funt",
        "Funt-Kilogram"};
        public string nazwa => "Waga";
        public double Zamiana(double wynik, int x)
        {
            if (x == 1)
                return wynik * 0.45359237; //Kilogramy
            if (x == 2)
                return wynik * 2.20462262;//Funty
            else return 0;
        }
    }
}

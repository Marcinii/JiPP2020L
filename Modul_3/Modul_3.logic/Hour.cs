using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul_3
{
    public class Hour : Ikonwerter
    {
        public string nazwa => "Zamiana";

        public List<string> Unit => new List<string>() { "Z 24h na 12h" };

        public double Zamiana(double wynik, int x)
        {
            if (wynik - 12 > 0)
            {
                wynik = wynik - 12;
                return wynik;
            }
            else
                return wynik;
        }
    }
}


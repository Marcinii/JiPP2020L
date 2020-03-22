using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul1
{
    class Czas : Ikonwerter
    {
        public string nazwa => "Czas";

        public List<string> Unit => new List<string>() {
            "Sekunda-Minuta",
            "Minuta-Sekunda"
        };

        public double Zamiana(double wynik, int x)
        {
            if (x == 1)
                return wynik / 60;
            if (x == 2)
                return wynik * 60;
            else return 0;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterPrzedrostkow
{
    public class Hekto_class : IPrzedrostki
    {
        public string Name => "Hekto";


        public double Konwerter(double wartosc_IN)
        {
            double wynik = 0;

            if (wartosc_IN >= 100) { wynik = wartosc_IN / 100; }

            return wynik;
        }
    }
}

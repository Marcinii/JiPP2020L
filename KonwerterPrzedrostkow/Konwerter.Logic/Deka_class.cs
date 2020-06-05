using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterPrzedrostkow
{
    public class Deka_class : IPrzedrostki
    {
        public string Name => "Deka";


        public double Konwerter(double wartosc_IN)
        {
            double wynik = 0;

            if (wartosc_IN >= 10) { wynik = wartosc_IN / 10; }

            return wynik;
        }
    }
}

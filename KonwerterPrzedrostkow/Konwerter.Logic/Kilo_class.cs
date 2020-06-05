using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterPrzedrostkow
{
    public class Kilo_class : IPrzedrostki
    {
        public string Name => "Kilo";


        public double Konwerter(double wartosc_IN)
        {
            double wynik = 0;

            if (wartosc_IN >= 1000) { wynik = wartosc_IN / 1000; }

            return wynik;
        }
    }
}

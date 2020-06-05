using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalkulator.Logic
{
    public class Mnozenie : IDzialanie
    {
        public string Nazwa => "Mnozenie";

        public double Oblicz(double pierwszaWartosc, double drugaWartosc)
        {
            return (pierwszaWartosc * drugaWartosc);
        }
    }
}

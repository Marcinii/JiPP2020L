using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalkulator.Logic
{
    public class Dzielenie : IDzialanie
    {
        public string Nazwa => "Dzielenie";

        public double Oblicz(double pierwszaWartosc, double drugaWartosc)
        {
            return Equals(drugaWartosc, 0) ? double.NegativeInfinity : pierwszaWartosc / drugaWartosc;
        }
    }
}

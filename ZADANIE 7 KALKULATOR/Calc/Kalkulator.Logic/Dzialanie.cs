using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalkulator.Logic
{
    public class Divide : IDzialanie
    {
        public string Nazwa => "Divide";

        public double Oblicz(double firstpick, double secondpick)
        {
            return Equals(secondpick, 0) ? double.NegativeInfinity : firstpick / secondpick;
        }
    }
}
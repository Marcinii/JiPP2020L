
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalkulator.Logic
{
    public class Multi : IDzialanie
    {
        public string Nazwa => "Multi";

        public double Oblicz(double firstpick, double secondpick)
        {
            return (firstpick * secondpick);
        }
    }
}
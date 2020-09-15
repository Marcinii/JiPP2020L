
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalkulator.Logic
{
    public interface IDzialanie
    {
        double Oblicz(double firstpick, double secondpick);
        string Nazwa { get; }
    }
}
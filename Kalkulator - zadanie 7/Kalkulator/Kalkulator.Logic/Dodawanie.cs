using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalkulator.Logic
{
    public class Dodawanie : IDzialanie
    {
        public string Nazwa => "Dodawanie";

        public double Oblicz(double pierwszaWartosc, double drugaWartosc)
        {
            return pierwszaWartosc + drugaWartosc;
        }
    }
}
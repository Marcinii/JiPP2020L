using System;
using System.Collections.Generic;
using System.Text;

namespace Konwerter2
{
    public class KilogramyNaFunty : IKonwerterWyboru
    {
        public string Name => "Z Kilogramow na Funty";

        public double Convert(double wartosc)
        {
            return ((9 / 5) * wartosc) + 32;
        }
    }
}
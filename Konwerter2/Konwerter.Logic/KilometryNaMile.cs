using System;
using System.Collections.Generic;
using System.Text;

namespace Konwerter2
{
    public class KilometryNaMile : IKonwerterWyboru
    {
        public string Name => "Kilometry na mile";

        public double Convert(double wartosc)
        {
            return wartosc * 1.609;
        }
    }
}
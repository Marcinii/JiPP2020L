using System;
using System.Collections.Generic;
using System.Text;

namespace Konwerter2
{
    public class SekundyNaMinuty : IKonwerterWyboru
    {
        public string Name => "Z Sekund na Minuty";

        public double Convert(double wartosc)
        {
            return wartosc / 60;
        }
    }
}
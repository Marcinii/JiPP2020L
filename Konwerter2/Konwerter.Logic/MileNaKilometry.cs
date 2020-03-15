using System;
using System.Collections.Generic;
using System.Text;

namespace Konwerter2
{
    public class MileNaKilometry : IKonwerterWyboru
    {
        public string Name => "Mile na kilometry";

        public double Convert(double wartosc)
        {
            return wartosc * 0.621371192;
        }
    }
}
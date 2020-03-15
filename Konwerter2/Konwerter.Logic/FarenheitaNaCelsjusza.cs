using System;
using System.Collections.Generic;
using System.Text;

namespace Konwerter2
{
    public class FarenheitaNaCelsjusza : IKonwerterWyboru
    {
        public string Name => "Z Farenheita na Celsjusza";

        public double Convert(double wartosc)
        {
            return (wartosc - 32) / (9 / 5);
        }
    }
}
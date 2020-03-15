using System;
using System.Collections.Generic;
using System.Text;

namespace Konwerter2
{
    public class CelsjuszaNaFarenheita : IKonwerterWyboru
    {
        public string Name => "Z Celsjusza na Farenheita";

        public double Convert(double wartosc)
        {
            return ((9 / 5) * wartosc) + 32;
        }
    }
}

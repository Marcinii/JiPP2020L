using System;
using System.Collections.Generic;
using System.Text;

namespace Konwerter2
{
    public class FuntyNaKilogramy : IKonwerterWyboru
    {
        public string Name => "Z Funtow na Kilogramy";

        public double Convert(double wartosc)
        {
            return wartosc * 0.45359237;
        }
    }
}

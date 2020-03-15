using System;
using System.Collections.Generic;
using System.Text;

namespace Konwerter2
{
    public class MinutyNaSekundy : IKonwerterWyboru
    {
        public string Name => "Z Minut na Sekundy";

        public double Convert(double wartosc)
        {
            return wartosc * 60;
        }
    }
}
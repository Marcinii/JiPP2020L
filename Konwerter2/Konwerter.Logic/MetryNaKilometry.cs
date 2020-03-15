using System;
using System.Collections.Generic;
using System.Text;

namespace Konwerter2
{
    public class MetryNaKilometry : IKonwerterWyboru
    {
        public string Name => "Metry na kilometry";

        public double Convert(double wartosc)
        {
            return wartosc / 1000;
        }
    }
}
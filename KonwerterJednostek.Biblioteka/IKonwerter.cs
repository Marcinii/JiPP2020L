using System;
using System.Collections.Generic;

namespace KonwerterJednostek.Biblioteka
{
    public interface IKonwerter
    {
        string Nazwa { get; }
        List<string> Jednostki { get; }
        double Konwertuj(double wartoscWejsciowa, string jednostkaWejsciowa, string jednostkaWyjsciowa);
    }
}

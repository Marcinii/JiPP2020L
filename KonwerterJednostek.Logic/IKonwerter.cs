using System;
using System.Collections.Generic;
using System.Text;

namespace KonwerterJednostek
{
    public interface IKonwerter
    {
        public string Nazwa { get; }
        List<string> Jednostki { get; }

        public double Konwertuj(string jednZ, string jednDo, double wartoscDoKonwersji);
    }
}

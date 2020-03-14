using System;
using System.Collections.Generic;
using System.Text;

namespace KonwerterJednostek
{
    public interface IKonwerter
    {
        string Name { get; }
        List<string> Units { get; }

        decimal Konwerter(string jednostkaZ, string jednostkaDO, decimal konwertowanaWartosc);
    }
}

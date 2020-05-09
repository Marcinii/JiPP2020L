using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterJednostek2.Logic
{
    public interface IKonwerter
    {
        string Name { get; }
        List<string> Units { get; }
        double Konwerter(string jednostka_bazowa, string jednostka_docelowa, double wartosc);
    }
}

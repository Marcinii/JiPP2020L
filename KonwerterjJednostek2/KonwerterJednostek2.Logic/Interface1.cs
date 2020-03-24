using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterjJednostek2
{
    public interface IKonwerter
    {
        string Name { get; } // to jest moj wspanialy interfejs
        List<string> Units { get; }
        double Konwerter(string jednostka_bazowa, string jednostka_docelowa, double wartosc);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterJednostek
{
    public interface IKonwerter {
    string Name { get; }
    string jednostki { get; }
    double Konwertuj(string jw, string jd, double wynik);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter
{
    public interface IKonwerter
    {
        string Name { get; }
        List<string> Unit { get; }
        double Konwert(string Z, string Do, double wartosc);
    }
}

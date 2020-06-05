using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterPrzedrostkow
{
    public interface IPrzedrostki
    {
        string Name { get; }
        double Konwerter(double wartosc_IN);
    }
}

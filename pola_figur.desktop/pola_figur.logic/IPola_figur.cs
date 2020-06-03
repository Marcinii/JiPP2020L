using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pola_figur.logic
{
    public interface IPola_figur
    {
        decimal Licz_pole(decimal x);
        decimal Licz_obwod(decimal x);
        List<string> obliczenia { get; }
        string Name { get; }
    }
}

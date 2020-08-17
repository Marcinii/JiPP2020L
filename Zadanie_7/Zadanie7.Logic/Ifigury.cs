using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie_7
{
    public interface Ifigury
    {
        string nazwa { get; }
        List<string> what { get; }
        double oblicz(string ktory, double a, double b, double c, double h);
    }
}

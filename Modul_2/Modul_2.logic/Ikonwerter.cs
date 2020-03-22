using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul_2
{
    public interface Ikonwerter        

    {
        string nazwa { get; }
        List<String> Unit { get; }
        double Zamiana(double wynik,int x);
    }
}

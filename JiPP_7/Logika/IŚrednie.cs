using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logika
{
    interface IŚrednie
    {
        string nazwa { get; }
        double wynik(double zmienna, int i);
    }
}

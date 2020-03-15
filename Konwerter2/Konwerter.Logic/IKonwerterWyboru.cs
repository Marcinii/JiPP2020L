using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter2
{
    public interface IKonwerterWyboru
    {
        string Name { get; }
        double Convert(double wartosc);
    }
}
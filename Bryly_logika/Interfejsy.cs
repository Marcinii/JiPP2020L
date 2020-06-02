using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplikacjaBryly
{
    public interface IFigura
    {
        double PolePow(string bokA, string bokB, string wyskoksch);
        string NazwaF { get; }
    }

    public interface IBryla
    {
        double Objetosc(double PP, string wysokoscH);
        string NazwaB { get; }
    }
}

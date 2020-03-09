using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter_jednostek
{
    public interface IKonwerter
    {
        string Nazwa { get; }
        List<string> Jednostki { get; }
        double Konwerter(string JednostkaZ, string JednostkaNa, double WartoscDoKonwersji);
    }
}

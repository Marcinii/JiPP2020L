using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter.Logic
{
    public class KonwerterCzasu : IKonwerterDomyslny
    {
        public override string Nazwa { get => "Czas"; }

        public KonwerterCzasu()
        {
            SlownikWartosci = new Dictionary<string, double>()
            {
                {"min", 1},
                {"h", 60},
                {"s", 1d/60},
            };
        }

    }
}

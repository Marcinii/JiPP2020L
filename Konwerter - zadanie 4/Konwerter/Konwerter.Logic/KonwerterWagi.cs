using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter.Logic
{
    public class KonwerterWagi : IKonwerterDomyslny
    {
        public override string Nazwa { get => "Waga"; }

        public KonwerterWagi()
        {
            SlownikWartosci = new Dictionary<string, double>()
            {
                {"kg", 1},
                {"lb", 0.45359237},
                {"g", 0.001d},
            };
        }

    }
}

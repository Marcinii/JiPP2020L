using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter.Logic
{
    public class KonwerterDlugosci : IKonwerterDomyslny
    {
        public override string Nazwa { get => "Dlugosci"; }

        public KonwerterDlugosci()
        {
            SlownikWartosci = new Dictionary<string, double>()
            {
                {"km", 1},
                {"mil", 1.609344},
                {"m", 1e-3},
            };
        }

    }
}

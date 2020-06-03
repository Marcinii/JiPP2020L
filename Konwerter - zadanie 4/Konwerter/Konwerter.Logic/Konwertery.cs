using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter.Logic
{
    public class Konwertery
    {
        public List<IKonwerter> WybierzKonwerter()
        {
            return new List<IKonwerter>()
            {
                new KonwerterTemperatury(),
                new KonwerterDlugosci(),
                new KonwerterWagi(),
                new KonwerterCzasu(),
                new KonwerterZegara()
            };
        }

    }
}

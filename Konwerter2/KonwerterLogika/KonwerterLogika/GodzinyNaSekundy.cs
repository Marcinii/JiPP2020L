using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterLogika
{
    public class GodzinyNaSekundy : IKonwerter
    {
        double wartosc;

        public void DodajWartosc(double wartosc)
        {
            this.wartosc = wartosc;
        }

        public double Przelicz()
        {
            return wartosc * 3600;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterLogika
{
    public class KilogramyNaFunty : IKonwerter
    {
        double wartosc;

        public void DodajWartosc(double wartosc)
        {
            this.wartosc = wartosc;
        }

        public double Przelicz()
        {
            return wartosc * 2.2046;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterLogika
{
    public class MileNaKilometry : IKonwerter
    {
        double wartosc;

        public void DodajWartosc(double wartosc)
        {
            this.wartosc = wartosc;
        }

        public double Przelicz()
        {
            return wartosc / 0.62137;
        }
    }
}

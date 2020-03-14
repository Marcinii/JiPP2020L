using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterLogika
{
    public interface IKonwerter
    {
        void DodajWartosc(double wartosc);
        double Przelicz();
    }
}

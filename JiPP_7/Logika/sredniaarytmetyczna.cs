using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logika
{
    class sredniaarytmetyczna : IŚrednie
    {
        public string nazwa => "Srednia Arytmetyczna";


        double IŚrednie.wynik(double zmienna, int i)
        {
            return zmienna / i;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplikacjaBryly
{
    class Trojkat : IFigura
    {
        public double PolePow(string bokA, string bokB, string wysokosch)
        {
            if (double.TryParse(bokA, out double bok1)) { }
            else bok1 = 0;


            if (double.TryParse(wysokosch, out double wysokosc)) { }
            else wysokosc = 0;

            if (bok1 <= 0 || wysokosc <= 0) return 0;

            return bok1 * wysokosc/2.0;
        }

        public string NazwaF => "Trójkąt";

    }
}

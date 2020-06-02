using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplikacjaBryly
{
    class Prostokat :IFigura
    {

        public double PolePow(string bokA, string bokB, string wyskoksch)
        {
            if (double.TryParse(bokA, out double bok1)) { }
            else bok1 = 0;


            if (double.TryParse(bokB, out double bok2)) { }
            else bok2 = 0;

            if (bok1 <= 0 || bok2<=0) return 0;

            return bok1 * bok2;
        }

        public string NazwaF => "Prostokąt";
    }
}

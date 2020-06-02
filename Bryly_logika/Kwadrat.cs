using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AplikacjaBryly
{

    class Kwadrat : IFigura
    {
        public double PolePow(string bokA, string bokB, string wyskoksch)
        {
            if (double.TryParse(bokA, out double bok)) { }
            else bok = 0;

            if (bok <= 0) return 0;

            return bok * bok;
        }

        public string NazwaF => "Kwadrat";

    }
}

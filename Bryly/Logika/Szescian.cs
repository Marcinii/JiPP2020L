using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logika
{
    public class Szescian : Prostopadloscian
    {
        public Szescian(double a) : base(a, a, a)
        {
        }

        new public string InputToString()
        {
            return "a=" + a;
        }

        new public string Name()
        {
            return "Sześcian";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logika
{
    public class Kula : IBryla
    {
        private double r;

        public Kula(double r)
        {
            this.r = r;
        }

        public string InputToString()
        {
            return "r=" + r;
        }

        public string Name()
        {
            return "Kula";
        }

        public double Oblicz()
        {
            return 4.0 / 3.0 * Math.PI * r * r;
        }
    }
}

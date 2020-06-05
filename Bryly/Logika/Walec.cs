using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logika
{
    public class Walec : IBryla
    {
        private double r, h;

        public Walec(double r, double h)
        {
            this.r = r;
            this.h = h;
        }

        public string InputToString()
        {
            return "r=" + r + ",h=" + h;
        }

        public double Oblicz()
        {
            return Math.PI * r * r * h;
        }

        public string Name()
        {
            return "Walec";
        }
    }
}

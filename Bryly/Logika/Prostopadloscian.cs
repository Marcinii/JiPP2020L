using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logika
{
    public class Prostopadloscian : IBryla
    {
        protected double a;
        protected double b;
        protected double h;

        public Prostopadloscian(double a, double b, double h)
        {
            this.a = a;
        }

        public string InputToString()
        {
            return "a=" + a + ",b=" + b + ",h=" + h;
        }

        public string Name()
        {
            return "Prostopadłościan";
        }

        public double Oblicz()
        {
            return a * b * h;
        }
    }
}

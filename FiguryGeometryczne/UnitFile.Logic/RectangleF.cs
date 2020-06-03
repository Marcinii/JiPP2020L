using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitFile.Logic
{
    public class RectangleF : IFigure
    {
        public string Nazwa => "Prostokąt";

        public double Calculate(double a, double b, double h)
        {
            double sideA = a;
            double sideB = b;

            return sideA * sideB;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitFile.Logic
{
    public class Trapeze : IFigure
    {
        public string Nazwa => "Trapez";

        public double Calculate(double a, double b, double h)
        {
            
            
                double sideA = a;
                double sideB = b;
                double sideH = h;
                return ((sideA + sideB) * sideH) / 2;
            
            
        }
    }
}

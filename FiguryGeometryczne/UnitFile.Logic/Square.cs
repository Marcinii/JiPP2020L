using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitFile.Logic
{
    public class Square : IFigure
    {
        public string Nazwa => "Kwadrat";

        public double Calculate(double a, double b, double h)
        {
            
            
                double sideA = a;

                return sideA * sideA;
            
            
        }
    }
}

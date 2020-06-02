using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;

namespace FunctionDrawer.Logic
{
    public class Quadratic : IPolynomial
    {
        public List<PlotPoint> PlotPoints { get; private set; }

        public string Info { get; private set; } = "a*x + b+x^2 + c";

        public int ParamsNum { get; private set; } = 3;

        public void Calculate(double fieldStart, double fieldStop, List<double> prm)
        {
            PlotPoints = new List<PlotPoint>();
            for (double i = fieldStart; i < fieldStop; i++)
            {
                PlotPoint plotPoint = new PlotPoint()
                {
                    X = i,
                    Y = i * prm[0] + (Math.Pow(i,2)) * prm[1] + prm[2]
                };
                PlotPoints.Add(plotPoint);
            }                       
        }     
    }
}

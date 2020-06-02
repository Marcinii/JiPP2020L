using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace FunctionDrawer.Logic
{
    public class Logarithmic : IPolynomial
    {
        public string Info { get; private set; } = "y = a*logb(x)";
        public int ParamsNum { get; private set; } = 3;

        public List<PlotPoint> PlotPoints { get; set; }

        public void Calculate(double fieldStart, double fieldStop, List<double> prm)
        {
            PlotPoints = new List<PlotPoint>();
            for (double i = 1; i < fieldStop; i++)
            {
                PlotPoint plotPoint = new PlotPoint()
                {
                    X = i,
                    Y = prm[0] * Math.Log(i, prm[1])
                };
                Debug.WriteLine($"X:{plotPoint.X} Y:{plotPoint.Y} ");
                PlotPoints.Add(plotPoint);
            }
        }
    }
}

using System.Collections.Generic;

namespace PlotDrawer.Logic
{
    public class Linear : IPolynomial
    {
        public List<PlotPoint> PlotPoints { get; private set; }

        public string Info { get; private set; } = "y = ax+c";
        public int ParamsNum { get; private set; } = 2;

        public void Calculate(double fieldStart, double fieldStop, List<double> prm)
        {
            PlotPoints = new List<PlotPoint>();
            for (double i = fieldStart; i < fieldStop; i++)
            {
                PlotPoint plotPoint = new PlotPoint()
                {
                    X = i,
                    Y = i * prm[0] + prm[1]
                };
                PlotPoints.Add(plotPoint);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows;

namespace FunctionDrawer.Logic
{
    public interface IPolynomial
    {
        string Info { get; }
        int ParamsNum { get; }
        List<PlotPoint> PlotPoints { get;}
        void Calculate(double fieldStart, double fieldStop, List<double> prm);
    }
}

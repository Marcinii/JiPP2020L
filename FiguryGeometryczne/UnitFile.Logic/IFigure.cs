using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitFile.Logic
{
    public interface IFigure
    {
        string Nazwa { get;  }
        double Calculate(double a, double b, double h);
    }

    
}

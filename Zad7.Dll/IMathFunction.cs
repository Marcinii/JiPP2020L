using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad7.Dll
{
    public interface IMathFunction
    {
        string Name { get; }
        double Calculate(double[] parameters);
        string[] ParameterNames { get; }
    }
}

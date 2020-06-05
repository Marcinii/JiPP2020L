using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad7.Dll
{
    class Pow : IMathFunction
    {
        public string Name => "Pierwiastek n-tego stopnia";

        public string[] ParameterNames { get { return new string[] { "liczba", "stopień pierwiastka" }; } }

        public double Calculate(double[] parameters)
        {
            return Math.Pow(parameters[0], parameters[1]);
        }
    }
}

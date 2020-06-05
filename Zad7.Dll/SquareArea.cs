using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad7.Dll
{
    class SquareArea : IMathFunction
    {
        public string Name => "Pole kwadratu";


        public string[] ParameterNames { get { return new string[] { "a" }; } }

        public double Calculate(double[] parameters)
        {
            return parameters[0] * parameters[0];
        }
    }
}

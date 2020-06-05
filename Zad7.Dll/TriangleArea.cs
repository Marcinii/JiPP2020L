using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad7.Dll
{
    public class TriangleArea : IMathFunction
    {
        public string Name => "Pole trójkąta";

        public string[] ParameterNames { get { return new string[] { "a", "h" }; } }


        public double Calculate(double[] parameters)
        {
            return (parameters[0] * parameters[1]) / 2;
        }
    }
}

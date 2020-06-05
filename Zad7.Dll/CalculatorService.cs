using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad7.Dll
{
    public class CalculatorService
    {
        public List<IMathFunction> GetFunctions() => new List<IMathFunction>
        {
                new TriangleArea(),
                new SquareArea(),
                new Pow()
        };

        
    }
}

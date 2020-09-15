using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalkulator.Logic
{
    public class Dzialania
    {
        public List<IDzialanie> WybierzDzialanie()
        {
            return new List<IDzialanie>()
            {
                new Add(),
                new Sub(),
                new Multi(),
                new Divide(),
            };
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZadanieLogic
{
    public interface IChecker
    {
        string Name { get; }
        List<string> Units { get; }
        string Check(string podziel, string valueToCheck);
    }
}

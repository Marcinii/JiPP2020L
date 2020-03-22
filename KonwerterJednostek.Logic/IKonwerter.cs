using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterJednostek.Logic
{
    public interface IKonwerter
    {
        string Name { get; }
        List<string> Units { get; }
        double Convert(double valueToConvert);
    }
}

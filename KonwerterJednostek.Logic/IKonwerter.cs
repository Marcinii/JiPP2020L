using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterJednostek.Logic
{
    public interface IKonwerter
    {
        string UnitConv(string from, string to, string number);
        string Name { get; }
        List<string> Units { get; }
        object Convert(object valueToConvert);
    }
}

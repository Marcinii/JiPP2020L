using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitKonwerter
{
    public interface IKonwerter
    {
        string Name{get; }
        List<string> Units { get; }

        decimal Convert(string unitFrom, string unitTo, decimal valueToConvert);
    
    }
}

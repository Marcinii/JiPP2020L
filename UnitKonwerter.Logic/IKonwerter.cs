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

        string Convert(string unitFrom, string unitTo, string valueToConvert);
    
    }
}

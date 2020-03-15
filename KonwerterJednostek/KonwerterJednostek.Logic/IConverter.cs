using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterJednostek
{
    public interface IConverter
    {
        string Name { get; }
        List<String> Units { get; }
        decimal Convert(string unitFrom, string unitTo, decimal valueConverted);
    }
}

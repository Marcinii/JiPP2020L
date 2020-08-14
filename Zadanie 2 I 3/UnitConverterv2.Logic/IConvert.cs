using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace unitConverterv2
{
    public interface IConvert
    {
        string Name { get; }
        List<string> Units { get; }

        decimal Convert(int fromUnit, int toUnit, decimal value);

    }
}

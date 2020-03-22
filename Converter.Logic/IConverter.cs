
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converter
{
    public interface IConverter
    {
        string Name { get; }

        List<string> Units { get; }

        double convert(double a, string from, string to);

        

    }
}

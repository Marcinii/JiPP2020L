
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterJednostek2
{
    public interface iKonwerter
    {
        string Name { get; }

        List<string> Units { get; }

        double convert(double a, string from, string to);

        

    }
}

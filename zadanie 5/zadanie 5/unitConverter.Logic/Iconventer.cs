using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniConverter
{
    public interface Iconventer
    {
        string Name { get; }
        List<string> Units { get; }

        decimal converterCalculator(int unitFrom, int unitTo, decimal value);


        

    }
}

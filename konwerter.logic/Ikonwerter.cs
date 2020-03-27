using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace konwerter.logic
{
    public interface Ikonwerter
    {
        string Name { get; }
        List<string> Units { get; }
        decimal Convert(string unitFrom, string unitTo, decimal valueToConvert);
    }

    public interface IkonwTime
    {
        
        decimal ConvTime(int godz, int min);
    }


}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterJednostekLK
{
    public interface IConverter
    {
        string getName { get; }

        List<string> units { get; }
        float Convert(int convertFrom, int convertTo, float value);
    }
}

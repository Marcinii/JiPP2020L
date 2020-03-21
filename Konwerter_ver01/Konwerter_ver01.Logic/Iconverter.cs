using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter_ver01
{
    public interface IConverter
    {
        string Name { get; }
        List<string> Jedn { get; }
        double Convert(string JednZ, string JednDo, double Wart);
    }
}

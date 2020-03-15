using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterJednostek
{
    public interface IConverter
    {
        void UnitConv();
        double Option1();
        double Option2();
        void Info();
        string Name { get; }
        List<string> Units { get; }
    }
}

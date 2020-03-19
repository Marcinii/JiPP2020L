using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterJednostek.Logic
{
    public interface IConverter
    {
        void UnitConv();
        string UnitConv(string from, string to, string number);
        double Option1();
        double Option2();
        void Info();
        string Name { get; }
        List<string> Units { get; }
    }
}

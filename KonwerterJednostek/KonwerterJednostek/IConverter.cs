using System;
using System.Collections.Generic;
using System.Text;

namespace KonwerterJednostek
{
    interface IConverter
    {
        public void UnitConv();
        public double Option1();
        public double Option2();
        public void Info();
        public string Name { get; }
        public List<string> Units { get; }
    }
}

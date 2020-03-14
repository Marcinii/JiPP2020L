using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class TimeConverter :IConverterDefault
    {
        public override string Name { get => "Czas"; }

        public TimeConverter()
        {
            ValueDictionary = new Dictionary<string, double>()
            {
                {"min", 1},
                {"h", 60},
                {"s", 1d/60},
                {"ms", 1d/6e4},
                {"ns", 1d/6e10},
            };
        }

    }
}

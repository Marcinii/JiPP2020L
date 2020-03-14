using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class LengthConverter : IConverterDefault
    {
        public override string Name { get => "Odległość"; }

        public LengthConverter()
        {
            ValueDictionary = new Dictionary<string, double>()
            {
                {"km", 1},
                {"mi", 1.609344},
                {"m", 1e-3},
            };
        }

    }
}

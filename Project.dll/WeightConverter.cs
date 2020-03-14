using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class WeightConverter : IConverterDefault
    {
        public override string Name { get => "Waga"; }

        public WeightConverter()
        {
            ValueDictionary = new Dictionary<string, double>()
            {
                {"kg", 1},
                {"lb", 0.45359237},
                {"g", 0.001d},
                {"dag", 0.01d},
                {"T", 1000},
            };
        }

    }
}

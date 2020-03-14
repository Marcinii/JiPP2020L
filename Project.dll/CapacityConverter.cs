using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Project
{
    public class CapacityConverter : IConverterDefault
    {
        public override string Name { get => "Pojemność"; }

        public CapacityConverter()
        {
            ValueDictionary = new Dictionary<string, double>()
            {
                {"b", 1d/8},
                {"B", 1},
                {"kiB", 1024},
                {"MiB", Math.Pow(1024,2)},
                {"GiB", Math.Pow(1024,3)},
                {"TiB", Math.Pow(1024,4)},
                {"PiB", Math.Pow(1024,5)},
                {"KB", 1000},
                {"MB", Math.Pow(1000,2)},
                {"GB", Math.Pow(1000,3)},
                {"TB", Math.Pow(1000,4)},
                {"PB", Math.Pow(1000,5)},
            };
        }




    }

}

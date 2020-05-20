using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converter.Logic
{
    public class ConverterManager
    {
        public static readonly List<Converter> converters = new List<Converter>();


        public List<Converter> Converters
        {
            get { return converters; }
        }

    }
}

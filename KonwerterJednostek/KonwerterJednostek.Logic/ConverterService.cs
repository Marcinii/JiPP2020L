using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterJednostek.Logic
{
    public class ConverterService
    {
        public List<IConverter> GetConverters()
        {
            return new List<IConverter>()
            {
                new Energy(),
                new Length(),
                new Temp(),
                new Weight(),
                new Clock()
            };
        }
    }
}
    
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterJednostek.Logic
{
    public class ConverterService
    {
        readonly List<IConverter> conv = new List<IConverter>
            {
                new LengthConverter(),
                new PowerConverter(),
                new TemperatureConverter(),
                new WeightConverter()
            };
        public List<IConverter> GetConverters()
        {
            return conv;
        }
    }
}

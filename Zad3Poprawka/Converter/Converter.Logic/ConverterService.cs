using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converter.Logic
{
    class ConverterService
    {
        public List<IConverter> getConverters()
        {
            return new List<IConverter>()
            {
                new LenghtConverter(),
                new TemperatureConverter(),
                new QuantityConverter(),
                new WeightConverter()                    //////Konwertery
            };
        }
    }
}

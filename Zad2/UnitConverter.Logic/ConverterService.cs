using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter.Logic
{
    public class ConverterService
    {
        public List<IConverter> GetConverters()
        {
            return new List<IConverter>()
            {
                new LengthConverter(),
                new TemperatureConverter(),
                new WeightConverter(),
                new TimeConverter()
            };
        }

    }
}

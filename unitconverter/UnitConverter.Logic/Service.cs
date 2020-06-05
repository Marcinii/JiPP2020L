using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitConverter;

namespace UnitConverter.Logic
{
    public class ConverterService
    {
        public List<IConverter> getConverters()
        {
            return new List<IConverter>()
            {
              new TemperatureConverter(),
              new LenghtConverter(),
              new WeightConverter(),
              new SpeedConverter(),
              new TimeConverter()

            };
        }
    }
}
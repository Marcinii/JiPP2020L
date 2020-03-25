using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class ConverterService
    {

        public List<IConverter> GetConverters() => new List<IConverter>
        {
                new TempConverter(),
                new WeightConverter(),
                new LengthConverter(),
                new TimeConverter(),
                new CapacityConverter(),
                new ClockConverter()
        };
    }
}

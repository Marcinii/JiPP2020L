using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace unit_converter
{
    public class ConverterService
    {
        public Dictionary<string, IConverter> GetConverters()
        {
            return new Dictionary<string, IConverter>()
            {
                { "Length", new DistanceConverter() },
                { "Temperature", new TemperatureConverter() },
                { "Weight", new WeightConverter() },
                { "Time", new TimeConverter() },
                { "Clock", new ClockConverter() },
            };
        }
    }
}

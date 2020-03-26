using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterJednostek.Logic
{
    public class KonwerterService
    {
        public List<IConverter> GetConverters()
        {
            return new List<IConverter>()
            {
            new WeightConverter(),
            new VolumeConverter(),
            new LenghtConverter(),
            new TemperatureConverter(),
            new TimeConverter()
            };
        }
    }
}

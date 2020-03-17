using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace przelicznik.Logic
{
    public class KonwerterService
    {
        public List<IConverter> GetConverters()
        {
            return new List<IConverter>()
            {
            new WeightConverter(),
            new TimeConverter(),
            new LenghtConverter(),
            new TemperatureConverter()
            };
        }
    }
}
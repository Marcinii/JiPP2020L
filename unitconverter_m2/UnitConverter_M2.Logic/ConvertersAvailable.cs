using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter_M2.Logic
{
    public class ConvertersAvailable
    {
        public List<IConv> getConverters()
        {
            return new List<IConv>()
            {
                new LengthConv(),
                new MassConv(),
                new PowerConv(),
                new TemperatureConv(),
                new TimeConv()
            };
        }

    }
}
